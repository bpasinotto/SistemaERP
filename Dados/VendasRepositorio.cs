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

