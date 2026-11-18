using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SistemaERP.Dados
{
    class ProdutosRepositorio
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

        // Função para inserir um novo produto
        public bool InsereProduto(string nome, decimal preco, decimal custo, string un, decimal estoque, int fornecedor)
        {
            var query = @"INSERT INTO Produtos (Nome, Preco, Custo, Un, Estoque, Fornecedor) 
                              VALUES (@nome, @preco, @custo, @un, @estoque, @fornecedor)";

            using var connection = new SqlConnection(stringConexao);
            try
            {
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@nome", SqlDbType.NVarChar, 100) { Value = nome });
                command.Parameters.Add(new SqlParameter("@preco", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = preco });
                command.Parameters.Add(new SqlParameter("@custo", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = custo });
                command.Parameters.Add(new SqlParameter("@un", SqlDbType.NVarChar, 2) { Value = un });
                command.Parameters.Add(new SqlParameter("@estoque", SqlDbType.Decimal) { Precision = 18, Scale = 3, Value = estoque });
                command.Parameters.Add(new SqlParameter("@fornecedor", SqlDbType.Int) { Value = fornecedor });                

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir produto: " + ex.Message);
                return false;
            }
        }

        // Função para alterar um produto existente
        public bool AlteraProduto(int id, string nome, decimal preco, decimal custo, string un, decimal estoque, int fornecedor)
        {
            var query = @"UPDATE Produtos 
                              SET Nome = @nome, Preco = @preco, Custo = @custo, Un = @un, Estoque = @estoque, Fornecedor = @fornecedor 
                              WHERE Id = @id";

            using var connection = new SqlConnection(stringConexao);
            try
            {
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                command.Parameters.Add(new SqlParameter("@nome", SqlDbType.NVarChar, 100) { Value = nome });
                command.Parameters.Add(new SqlParameter("@preco", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = preco });
                command.Parameters.Add(new SqlParameter("@custo", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = custo });
                command.Parameters.Add(new SqlParameter("@un", SqlDbType.NVarChar, 2) { Value = un });
                command.Parameters.Add(new SqlParameter("@estoque", SqlDbType.Decimal) { Precision = 18, Scale = 3, Value = estoque });
                command.Parameters.Add(new SqlParameter("@fornecedor", SqlDbType.Int) { Value = fornecedor });                

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao alterar produto: " + ex.Message);
                return false;
            }
        }

        // Função para consultar todos os produtos
        public DataTable ConsultaTodosProdutos(int status)
        {
            var query = @"
                SELECT 
                    p.Id, 
                    p.Nome, 
                    p.Preco, 
                    p.Custo, 
                    p.Un, 
                    p.Estoque, 
                    f.Razao AS Fornecedor, 
                    p.DataCadastro 
                FROM Produtos p
                INNER JOIN Fornecedores f ON p.Fornecedor = f.Id
                WHERE p.Ativo = @status";

            using var connection = new SqlConnection(stringConexao);
            try
            {
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@status", SqlDbType.Int) { Value = status });

                using var reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar produtos: " + ex.Message);
                return null;
            }
        }

        // Função para consultar um produto pelo ID
        public DataRow ConsultaProdutoPorId(int id)
        {
            var query = @"SELECT Id, Nome, Preco, Custo, Un, Estoque, Fornecedor, Ativo, DataCadastro 
                              FROM Produtos 
                              WHERE Id = @id";

            using var connection = new SqlConnection(stringConexao);
            try
            {
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });

                using var reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar produto por ID: " + ex.Message);
                return null;
            }
        }

        // Função para ativar ou inativar um produto
        public bool AtivaInativaProduto(int id, bool ativo)
        {
            var query = @"UPDATE Produtos 
                          SET Ativo = @ativo 
                          WHERE Id = @id";

            using var connection = new SqlConnection(stringConexao);
            try
            {
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                command.Parameters.Add(new SqlParameter("@ativo", SqlDbType.Bit) { Value = ativo });

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ativar/inativar produto: " + ex.Message);
                return false;
            }
        }
        // Função para obter o fornecedor de um produto
        public Fornecedor ObterFornecedorPorProduto(int produtoId)
        {
            using (var connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                var query = @"
                    SELECT f.Id, f.Razao 
                    FROM Fornecedores f
                    INNER JOIN Produtos p ON p.Fornecedor = f.Id
                    WHERE p.Id = @ProdutoId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoId", produtoId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Fornecedor
                            {
                                Id = reader.GetInt32(0),
                                Razao = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
