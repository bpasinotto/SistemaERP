using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaERP.Modelo;
using SistemaERP.Negocio;

namespace SistemaERP.Dados;

internal class VendasRepositorio
{
    private readonly string stringConexao = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

    public bool InsereVenda(Venda venda)
    {
        return InsereVenda(venda, out _);
    }

    public bool InsereVenda(Venda venda, out string mensagemErro)
    {
        mensagemErro = string.Empty;

        const string insertVendaQuery = @"
            INSERT INTO Vendas (IdCliente, IdUsuario, DataVenda, ValorTotal, Situacao, Observacao)
            VALUES (@idCliente, @idUsuario, @dataVenda, @valorTotal, @situacao, @observacao);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        const string selectProdutoLockQuery = @"
            SELECT Nome, Un, Ativo
            FROM Produtos WITH (UPDLOCK, ROWLOCK)
            WHERE Id = @idProduto;";

        const string updateEstoqueAtomicoQuery = @"
            UPDATE Produtos
            SET Estoque = Estoque - @quantidade
            WHERE Id = @idProduto
              AND Ativo = 1
              AND Estoque >= @quantidade;";

        const string insertItemQuery = @"
            INSERT INTO VendaItens (IdVenda, IdProduto, Quantidade, ValorUnitario, ValorTotalItem)
            VALUES (@idVenda, @idProduto, @quantidade, @valorUnitario, @valorTotalItem);";

        using var connection = new SqlConnection(stringConexao);
        try
        {
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int idVenda;
                using (var cmdVenda = new SqlCommand(insertVendaQuery, connection, transaction))
                {
                    cmdVenda.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int) { Value = venda.IdCliente });
                    cmdVenda.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int) { Value = venda.IdUsuario });
                    cmdVenda.Parameters.Add(new SqlParameter("@dataVenda", SqlDbType.DateTime) { Value = venda.DataVenda });
                    cmdVenda.Parameters.Add(new SqlParameter("@valorTotal", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = decimal.Round(venda.ValorTotal, 2)
                    });
                    cmdVenda.Parameters.Add(new SqlParameter("@situacao", SqlDbType.NVarChar, 20)
                    {
                        Value = string.IsNullOrWhiteSpace(venda.Situacao) ? "Concluída" : venda.Situacao
                    });
                    cmdVenda.Parameters.Add(new SqlParameter("@observacao", SqlDbType.NVarChar, 255)
                    {
                        Value = string.IsNullOrWhiteSpace(venda.Observacao) ? DBNull.Value : venda.Observacao
                    });

                    object? result = cmdVenda.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        transaction.Rollback();
                        mensagemErro = "Não foi possível obter o identificador da venda registrada.";
                        return false;
                    }

                    idVenda = Convert.ToInt32(result);
                    venda.Id = idVenda;
                }

                foreach (var item in venda.Itens)
                {
                    string nomeProdutoBanco;
                    string unBanco;
                    bool ativoBanco;

                    using (var cmdProduto = new SqlCommand(selectProdutoLockQuery, connection, transaction))
                    {
                        cmdProduto.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = item.IdProduto });
                        using var reader = cmdProduto.ExecuteReader();
                        if (!reader.Read())
                        {
                            reader.Close();
                            transaction.Rollback();
                            mensagemErro = $"Produto (ID {item.IdProduto}) não encontrado.";
                            return false;
                        }

                        nomeProdutoBanco = reader["Nome"]?.ToString() ?? item.NomeProduto;
                        unBanco = reader["Un"]?.ToString() ?? string.Empty;
                        ativoBanco = Convert.ToBoolean(reader["Ativo"]);
                    }

                    if (!ativoBanco)
                    {
                        transaction.Rollback();
                        mensagemErro = $"O produto '{nomeProdutoBanco}' está inativo e não pode ser vendido.";
                        return false;
                    }

                    if (!ProdutosServico.ValidarQuantidadePorUnidade(item.Quantidade, unBanco, permitirZero: false, out string erroUnidade))
                    {
                        transaction.Rollback();
                        mensagemErro = $"Produto '{nomeProdutoBanco}': {erroUnidade}";
                        return false;
                    }

                    decimal quantidadeArredondada = decimal.Round(item.Quantidade, 3);
                    decimal valorUnitarioArredondado = decimal.Round(item.ValorUnitario, 2);
                    decimal valorTotalItemArredondado = decimal.Round(item.ValorTotalItem, 2);

                    using (var cmdEstoque = new SqlCommand(updateEstoqueAtomicoQuery, connection, transaction))
                    {
                        cmdEstoque.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = item.IdProduto });
                        cmdEstoque.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 3,
                            Value = quantidadeArredondada
                        });

                        int rowsAffected = cmdEstoque.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            mensagemErro = $"Estoque insuficiente para o produto '{nomeProdutoBanco}'.";
                            return false;
                        }
                    }

                    using (var cmdItem = new SqlCommand(insertItemQuery, connection, transaction))
                    {
                        cmdItem.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = idVenda });
                        cmdItem.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = item.IdProduto });
                        cmdItem.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 3,
                            Value = quantidadeArredondada
                        });
                        cmdItem.Parameters.Add(new SqlParameter("@valorUnitario", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Value = valorUnitarioArredondado
                        });
                        cmdItem.Parameters.Add(new SqlParameter("@valorTotalItem", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 2,
                            Value = valorTotalItemArredondado
                        });

                        cmdItem.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception exTransacao)
            {
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    // Ignora falha secundária de rollback
                }

                mensagemErro = $"Erro ao processar a transação da venda: {exTransacao.Message}";
                Console.WriteLine(mensagemErro);
                return false;
            }
        }
        catch (Exception ex)
        {
            mensagemErro = $"Erro ao conectar ao banco de dados: {ex.Message}";
            Console.WriteLine(mensagemErro);
            return false;
        }
    }

    public bool AlteraVenda(Venda venda, out string mensagemErro)
    {
        mensagemErro = string.Empty;

        const string selectVendaLockQuery = @"
            SELECT Situacao
            FROM Vendas WITH (UPDLOCK, ROWLOCK)
            WHERE Id = @idVenda;";

        const string selectItensAnterioresQuery = @"
            SELECT IdProduto, Quantidade
            FROM VendaItens
            WHERE IdVenda = @idVenda;";

        const string selectProdutoLockQuery = @"
            SELECT Nome, Un, Ativo
            FROM Produtos WITH (UPDLOCK, ROWLOCK)
            WHERE Id = @idProduto;";

        const string baixarEstoqueQuery = @"
            UPDATE Produtos
            SET Estoque = Estoque - @delta
            WHERE Id = @idProduto
              AND Estoque >= @delta;";

        const string devolverEstoqueQuery = @"
            UPDATE Produtos
            SET Estoque = Estoque + @devolucao
            WHERE Id = @idProduto;";

        const string deleteItensQuery = @"
            DELETE FROM VendaItens
            WHERE IdVenda = @idVenda;";

        const string insertItemQuery = @"
            INSERT INTO VendaItens (IdVenda, IdProduto, Quantidade, ValorUnitario, ValorTotalItem)
            VALUES (@idVenda, @idProduto, @quantidade, @valorUnitario, @valorTotalItem);";

        const string updateVendaQuery = @"
            UPDATE Vendas
            SET IdCliente = @idCliente,
                IdUsuario = @idUsuario,
                ValorTotal = @valorTotal,
                Observacao = @observacao
            WHERE Id = @idVenda
              AND Situacao = N'Concluída';";

        using var connection = new SqlConnection(stringConexao);
        try
        {
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // 1. Bloqueia e valida a situação da venda
                string? situacaoAtual;
                using (var cmdLockVenda = new SqlCommand(selectVendaLockQuery, connection, transaction))
                {
                    cmdLockVenda.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = venda.Id });
                    object? result = cmdLockVenda.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        transaction.Rollback();
                        mensagemErro = "Venda não encontrada.";
                        return false;
                    }
                    situacaoAtual = result.ToString();
                }

                if (!string.Equals(situacaoAtual, "Concluída", StringComparison.OrdinalIgnoreCase))
                {
                    transaction.Rollback();
                    mensagemErro = $"Somente vendas com situação 'Concluída' podem ser alteradas. Situação atual: '{situacaoAtual}'.";
                    return false;
                }

                // 2. Carrega as quantidades anteriores por produto
                var qtdAnteriorPorProduto = new Dictionary<int, decimal>();
                using (var cmdItensAnt = new SqlCommand(selectItensAnterioresQuery, connection, transaction))
                {
                    cmdItensAnt.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = venda.Id });
                    using var reader = cmdItensAnt.ExecuteReader();
                    while (reader.Read())
                    {
                        int idProd = Convert.ToInt32(reader["IdProduto"]);
                        decimal qtd = Convert.ToDecimal(reader["Quantidade"]);
                        qtdAnteriorPorProduto[idProd] = qtdAnteriorPorProduto.TryGetValue(idProd, out decimal acum)
                            ? decimal.Round(acum + qtd, 3)
                            : decimal.Round(qtd, 3);
                    }
                }

                // 3. Agrupa as novas quantidades por produto
                var qtdNovaPorProduto = new Dictionary<int, decimal>();
                foreach (var item in venda.Itens)
                {
                    decimal qtd = decimal.Round(item.Quantidade, 3);
                    qtdNovaPorProduto[item.IdProduto] = qtdNovaPorProduto.TryGetValue(item.IdProduto, out decimal acum)
                        ? decimal.Round(acum + qtd, 3)
                        : qtd;
                }

                // 4. Ajusta o estoque por diferença (delta) em ordem crescente de IdProduto para evitar deadlocks
                var produtosEnvolvidos = qtdAnteriorPorProduto.Keys
                    .Union(qtdNovaPorProduto.Keys)
                    .OrderBy(id => id)
                    .ToList();

                foreach (int idProduto in produtosEnvolvidos)
                {
                    qtdAnteriorPorProduto.TryGetValue(idProduto, out decimal qtdAnterior);
                    qtdNovaPorProduto.TryGetValue(idProduto, out decimal qtdNova);

                    string nomeProdutoBanco;
                    string unBanco;
                    bool ativoBanco;

                    using (var cmdProduto = new SqlCommand(selectProdutoLockQuery, connection, transaction))
                    {
                        cmdProduto.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = idProduto });
                        using var reader = cmdProduto.ExecuteReader();
                        if (!reader.Read())
                        {
                            reader.Close();
                            transaction.Rollback();
                            mensagemErro = $"Produto (ID {idProduto}) não encontrado.";
                            return false;
                        }

                        nomeProdutoBanco = reader["Nome"]?.ToString() ?? $"ID {idProduto}";
                        unBanco = reader["Un"]?.ToString() ?? string.Empty;
                        ativoBanco = Convert.ToBoolean(reader["Ativo"]);
                    }

                    if (qtdNova > 0)
                    {
                        if (!ativoBanco && qtdNova > qtdAnterior)
                        {
                            transaction.Rollback();
                            mensagemErro = $"O produto '{nomeProdutoBanco}' está inativo e não pode ser adicionado ou ter sua quantidade aumentada.";
                            return false;
                        }

                        foreach (var itemProduto in venda.Itens.Where(i => i.IdProduto == idProduto))
                        {
                            if (!ProdutosServico.ValidarQuantidadePorUnidade(itemProduto.Quantidade, unBanco, permitirZero: false, out string erroUnidade))
                            {
                                transaction.Rollback();
                                mensagemErro = $"Produto '{nomeProdutoBanco}': {erroUnidade}";
                                return false;
                            }
                        }
                    }

                    decimal delta = decimal.Round(qtdNova - qtdAnterior, 3);

                    if (delta > 0)
                    {
                        using var cmdBaixa = new SqlCommand(baixarEstoqueQuery, connection, transaction);
                        cmdBaixa.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = idProduto });
                        cmdBaixa.Parameters.Add(new SqlParameter("@delta", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 3,
                            Value = delta
                        });

                        int rowsAffected = cmdBaixa.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            transaction.Rollback();
                            mensagemErro = $"Estoque insuficiente para o produto '{nomeProdutoBanco}'.";
                            return false;
                        }
                    }
                    else if (delta < 0)
                    {
                        decimal devolucao = decimal.Round(Math.Abs(delta), 3);
                        using var cmdDevolve = new SqlCommand(devolverEstoqueQuery, connection, transaction);
                        cmdDevolve.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = idProduto });
                        cmdDevolve.Parameters.Add(new SqlParameter("@devolucao", SqlDbType.Decimal)
                        {
                            Precision = 18,
                            Scale = 3,
                            Value = devolucao
                        });

                        cmdDevolve.ExecuteNonQuery();
                    }
                }

                // 5. Substitui os itens da venda dentro da mesma transação
                using (var cmdDeleteItens = new SqlCommand(deleteItensQuery, connection, transaction))
                {
                    cmdDeleteItens.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = venda.Id });
                    cmdDeleteItens.ExecuteNonQuery();
                }

                foreach (var item in venda.Itens)
                {
                    using var cmdItem = new SqlCommand(insertItemQuery, connection, transaction);
                    cmdItem.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = venda.Id });
                    cmdItem.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = item.IdProduto });
                    cmdItem.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 3,
                        Value = decimal.Round(item.Quantidade, 3)
                    });
                    cmdItem.Parameters.Add(new SqlParameter("@valorUnitario", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = decimal.Round(item.ValorUnitario, 2)
                    });
                    cmdItem.Parameters.Add(new SqlParameter("@valorTotalItem", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = decimal.Round(item.ValorTotalItem, 2)
                    });

                    cmdItem.ExecuteNonQuery();
                }

                // 6. Atualiza o cabeçalho da venda
                using (var cmdUpdateVenda = new SqlCommand(updateVendaQuery, connection, transaction))
                {
                    cmdUpdateVenda.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = venda.Id });
                    cmdUpdateVenda.Parameters.Add(new SqlParameter("@idCliente", SqlDbType.Int) { Value = venda.IdCliente });
                    cmdUpdateVenda.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int) { Value = venda.IdUsuario });
                    cmdUpdateVenda.Parameters.Add(new SqlParameter("@valorTotal", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = decimal.Round(venda.ValorTotal, 2)
                    });
                    cmdUpdateVenda.Parameters.Add(new SqlParameter("@observacao", SqlDbType.NVarChar, 255)
                    {
                        Value = string.IsNullOrWhiteSpace(venda.Observacao) ? DBNull.Value : venda.Observacao
                    });

                    int rowsUpdated = cmdUpdateVenda.ExecuteNonQuery();
                    if (rowsUpdated == 0)
                    {
                        transaction.Rollback();
                        mensagemErro = "Não foi possível atualizar a venda. Verifique se ela ainda está concluída.";
                        return false;
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception exTransacao)
            {
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    // Ignora falha secundária de rollback
                }

                mensagemErro = $"Erro ao atualizar a venda: {exTransacao.Message}";
                Console.WriteLine(mensagemErro);
                return false;
            }
        }
        catch (Exception ex)
        {
            mensagemErro = $"Erro ao conectar ao banco de dados: {ex.Message}";
            Console.WriteLine(mensagemErro);
            return false;
        }
    }

    public bool CancelarVenda(int idVenda, out string mensagemErro)
    {
        mensagemErro = string.Empty;

        const string selectVendaLockQuery = @"
            SELECT Situacao
            FROM Vendas WITH (UPDLOCK, ROWLOCK)
            WHERE Id = @idVenda;";

        const string selectItensQuery = @"
            SELECT IdProduto, Quantidade
            FROM VendaItens
            WHERE IdVenda = @idVenda;";

        const string estornarEstoqueQuery = @"
            UPDATE Produtos
            SET Estoque = Estoque + @quantidade
            WHERE Id = @idProduto;";

        const string cancelarVendaQuery = @"
            UPDATE Vendas
            SET Situacao = N'Cancelada'
            WHERE Id = @idVenda
              AND Situacao = N'Concluída';";

        using var connection = new SqlConnection(stringConexao);
        try
        {
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string? situacaoAtual;
                using (var cmdLockVenda = new SqlCommand(selectVendaLockQuery, connection, transaction))
                {
                    cmdLockVenda.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = idVenda });
                    object? result = cmdLockVenda.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        transaction.Rollback();
                        mensagemErro = "Venda não encontrada.";
                        return false;
                    }
                    situacaoAtual = result.ToString();
                }

                if (!string.Equals(situacaoAtual, "Concluída", StringComparison.OrdinalIgnoreCase))
                {
                    transaction.Rollback();
                    mensagemErro = "Esta venda já está cancelada ou não pode ser cancelada.";
                    return false;
                }

                var qtdPorProduto = new Dictionary<int, decimal>();
                using (var cmdItens = new SqlCommand(selectItensQuery, connection, transaction))
                {
                    cmdItens.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = idVenda });
                    using var reader = cmdItens.ExecuteReader();
                    while (reader.Read())
                    {
                        int idProduto = Convert.ToInt32(reader["IdProduto"]);
                        decimal qtd = Convert.ToDecimal(reader["Quantidade"]);
                        qtdPorProduto[idProduto] = qtdPorProduto.TryGetValue(idProduto, out decimal acum)
                            ? decimal.Round(acum + qtd, 3)
                            : decimal.Round(qtd, 3);
                    }
                }

                foreach (var par in qtdPorProduto.OrderBy(p => p.Key))
                {
                    using var cmdEstorno = new SqlCommand(estornarEstoqueQuery, connection, transaction);
                    cmdEstorno.Parameters.Add(new SqlParameter("@idProduto", SqlDbType.Int) { Value = par.Key });
                    cmdEstorno.Parameters.Add(new SqlParameter("@quantidade", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 3,
                        Value = par.Value
                    });
                    cmdEstorno.ExecuteNonQuery();
                }

                using (var cmdCancelar = new SqlCommand(cancelarVendaQuery, connection, transaction))
                {
                    cmdCancelar.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = idVenda });
                    int rowsUpdated = cmdCancelar.ExecuteNonQuery();
                    if (rowsUpdated == 0)
                    {
                        transaction.Rollback();
                        mensagemErro = "Não foi possível cancelar a venda.";
                        return false;
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception exTransacao)
            {
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    // Ignora falha secundária de rollback
                }

                mensagemErro = $"Erro ao cancelar a venda: {exTransacao.Message}";
                Console.WriteLine(mensagemErro);
                return false;
            }
        }
        catch (Exception ex)
        {
            mensagemErro = $"Erro ao conectar ao banco de dados: {ex.Message}";
            Console.WriteLine(mensagemErro);
            return false;
        }
    }

    public DataTable ConsultaTodasVendas(DateTime? dataInicio = null, DateTime? dataFimExclusiva = null)
    {
        const string query = @"
            SELECT 
                v.Id,
                c.Razao AS Cliente,
                u.Nome AS Vendedor,
                v.DataVenda,
                v.ValorTotal,
                v.Situacao,
                v.Observacao
            FROM Vendas v
            INNER JOIN Clientes c ON v.IdCliente = c.Id
            INNER JOIN Usuarios u ON v.IdUsuario = u.Id
            WHERE (@dataInicio IS NULL OR v.DataVenda >= @dataInicio)
              AND (@dataFimExclusiva IS NULL OR v.DataVenda < @dataFimExclusiva)
            ORDER BY v.DataVenda DESC, v.Id DESC;";

        using var connection = new SqlConnection(stringConexao);
        try
        {
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@dataInicio", SqlDbType.DateTime)
            {
                Value = dataInicio.HasValue ? dataInicio.Value : DBNull.Value
            });
            command.Parameters.Add(new SqlParameter("@dataFimExclusiva", SqlDbType.DateTime)
            {
                Value = dataFimExclusiva.HasValue ? dataFimExclusiva.Value : DBNull.Value
            });

            using var reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar vendas: " + ex.Message);
            return new DataTable();
        }
    }

    public Venda? ConsultaVendaPorId(int idVenda)
    {
        const string query = @"
            SELECT 
                v.Id,
                v.IdCliente,
                c.Razao AS NomeCliente,
                v.IdUsuario,
                u.Nome AS NomeUsuario,
                v.DataVenda,
                v.ValorTotal,
                v.Situacao,
                v.Observacao
            FROM Vendas v
            INNER JOIN Clientes c ON v.IdCliente = c.Id
            INNER JOIN Usuarios u ON v.IdUsuario = u.Id
            WHERE v.Id = @id;";

        using var connection = new SqlConnection(stringConexao);
        try
        {
            connection.Open();
            Venda? venda = null;

            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = idVenda });
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    venda = new Venda
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        IdCliente = Convert.ToInt32(reader["IdCliente"]),
                        NomeCliente = reader["NomeCliente"]?.ToString() ?? string.Empty,
                        IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                        NomeUsuario = reader["NomeUsuario"]?.ToString() ?? string.Empty,
                        DataVenda = Convert.ToDateTime(reader["DataVenda"]),
                        ValorTotal = Convert.ToDecimal(reader["ValorTotal"]),
                        Situacao = reader["Situacao"]?.ToString() ?? "Concluída",
                        Observacao = reader["Observacao"] == DBNull.Value ? null : reader["Observacao"]?.ToString()
                    };
                }
            }

            if (venda != null)
            {
                venda.Itens = ConsultaItensPorVendaId(idVenda);
            }

            return venda;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar venda por ID: " + ex.Message);
            return null;
        }
    }

    public List<VendaItem> ConsultaItensPorVendaId(int idVenda)
    {
        const string query = @"
            SELECT 
                vi.Id,
                vi.IdVenda,
                vi.IdProduto,
                p.Nome AS NomeProduto,
                p.Un,
                vi.Quantidade,
                vi.ValorUnitario,
                vi.ValorTotalItem
            FROM VendaItens vi
            INNER JOIN Produtos p ON vi.IdProduto = p.Id
            WHERE vi.IdVenda = @idVenda
            ORDER BY vi.Id;";

        var itens = new List<VendaItem>();
        using var connection = new SqlConnection(stringConexao);
        try
        {
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@idVenda", SqlDbType.Int) { Value = idVenda });

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                itens.Add(new VendaItem
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    IdVenda = Convert.ToInt32(reader["IdVenda"]),
                    IdProduto = Convert.ToInt32(reader["IdProduto"]),
                    NomeProduto = reader["NomeProduto"]?.ToString() ?? string.Empty,
                    Un = reader["Un"]?.ToString() ?? string.Empty,
                    Quantidade = Convert.ToDecimal(reader["Quantidade"]),
                    ValorUnitario = Convert.ToDecimal(reader["ValorUnitario"]),
                    ValorTotalItem = Convert.ToDecimal(reader["ValorTotalItem"])
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao consultar itens da venda: " + ex.Message);
        }

        return itens;
    }
}

