using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SistemaERP.Dados
{
    internal class FornecedoresRepositorio
    {
        string stringConexao = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

        public DataTable BuscaTodosFornecedores(int Status)
        {
            string query = @"SELECT [Id], [CPF/CNPJ], [Razao], [Fantasia], [Email], [Telefone], [CEP], [Rua], [Numero], [Bairro], [Complemento], [Cidade], [Estado], [Obs] FROM Fornecedores WHERE [Ativo] = @status";

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@status", SqlDbType.Int) { Value = Status });

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                DataTable dataTable = new DataTable();
                                dataTable.Load(reader);
                                return dataTable;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao consultar o banco de dados.", ex);
                    }
                }
            }

            return null;
        }

        public List<string> BuscaFornecedorId(int Id)
        {
            string query = @"SELECT * FROM Fornecedores WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = Id });

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                List<string> lista = new List<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    lista.Add(reader[i].ToString());
                                }

                                return lista;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao consultar o banco de dados.", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return new List<string>();
        }

        public bool InsereFornecedor(string cnpj, string razao, string fantasia, string email, string telefone, string cep, string rua, string numero, string bairro, string complemento, string cidade, string estado, string obs)
        {
            var query = @"INSERT INTO Fornecedores ([CPF/CNPJ], [Razao], [Fantasia], [Email], [Telefone], [CEP], [Rua], [Numero], [Bairro], [Complemento], [Cidade], [Estado], [Obs]) VALUES (@cnpj, @razao, @fantasia, @email, @telefone, @cep, @rua, @numero, @bairro, @complemento, @cidade, @estado, @obs)";

            using var connection = new SqlConnection(stringConexao);
            try
            {
                connection.Open();
                using var command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj });
                command.Parameters.Add(new SqlParameter("@razao", SqlDbType.VarChar) { Value = razao });
                command.Parameters.Add(new SqlParameter("@fantasia", SqlDbType.VarChar) { Value = fantasia });
                command.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar) { Value = email });
                command.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar) { Value = telefone });
                command.Parameters.Add(new SqlParameter("@cep", SqlDbType.VarChar) { Value = cep });
                command.Parameters.Add(new SqlParameter("@rua", SqlDbType.VarChar) { Value = rua });
                command.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar) { Value = numero });
                command.Parameters.Add(new SqlParameter("@bairro", SqlDbType.VarChar) { Value = bairro });
                command.Parameters.Add(new SqlParameter("@complemento", SqlDbType.VarChar) { Value = complemento });
                command.Parameters.Add(new SqlParameter("@cidade", SqlDbType.VarChar) { Value = cidade });
                command.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar) { Value = estado });
                command.Parameters.Add(new SqlParameter("@obs", SqlDbType.VarChar) { Value = obs });

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool AlteraFornecedor(string id, string cnpj, string razao, string fantasia, string email, string telefone, string cep, string rua, string numero, string bairro, string complemento, string cidade, string estado, string obs)
        {
            var query = @"UPDATE Fornecedores SET [CPF/CNPJ] = @cnpj, [Razao] = @razao, [Fantasia] = @fantasia, [Email] = @email, [Telefone] = @telefone, [CEP] = @cep, [Rua] = @rua, [Numero] = @numero, [Bairro] = @bairro, [Complemento] = @complemento, [Cidade] = @cidade, [Estado] = @estado, [Obs] = @obs WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        cmd.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar)).Value = cnpj;
                        cmd.Parameters.Add(new SqlParameter("@razao", SqlDbType.VarChar)).Value = razao;
                        cmd.Parameters.Add(new SqlParameter("@fantasia", SqlDbType.VarChar)).Value = fantasia;
                        cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = email;
                        cmd.Parameters.Add(new SqlParameter("@telefone", SqlDbType.VarChar)).Value = telefone;
                        cmd.Parameters.Add(new SqlParameter("@cep", SqlDbType.VarChar)).Value = cep;
                        cmd.Parameters.Add(new SqlParameter("@rua", SqlDbType.VarChar)).Value = rua;
                        cmd.Parameters.Add(new SqlParameter("@numero", SqlDbType.VarChar)).Value = numero;
                        cmd.Parameters.Add(new SqlParameter("@bairro", SqlDbType.VarChar)).Value = bairro;
                        cmd.Parameters.Add(new SqlParameter("@complemento", SqlDbType.VarChar)).Value = complemento;
                        cmd.Parameters.Add(new SqlParameter("@cidade", SqlDbType.VarChar)).Value = cidade;
                        cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar)).Value = estado;
                        cmd.Parameters.Add(new SqlParameter("@obs", SqlDbType.VarChar)).Value = obs;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao atualizar o fornecedor: " + ex.Message);
                    return false;
                }
            }
        }

        public bool InativaAtivaFornecedor(string id, bool status)
        {
            var query = @"UPDATE Fornecedores SET [Ativo] = @status WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(stringConexao))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                        cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Bit)).Value = status;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao inativar o fornecedor: " + ex.Message);
                    return false;
                }
            }
        }

        public List<Fornecedor> ObterTodosFornecedores()
        {
            var fornecedores = new List<Fornecedor>();
            using (var connection = new SqlConnection(stringConexao))
            {
                connection.Open();
                var query = "SELECT Id, Razao FROM Fornecedores WHERE Ativo = 1";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {                        
                        while (reader.Read())
                        {
                            fornecedores.Add(new Fornecedor
                            {
                                Id = reader.GetInt32(0),
                                Razao = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return fornecedores;
        }
    }
}
