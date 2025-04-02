using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SistemaERP.Dados;
internal class ClientesRepositorio
{
    string stringConexao = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

    public DataTable BuscaTodosClientes(int Status)
    {

        string query = @"SELECT [Id], [CPF/CNPJ], [Razao], [Fantasia], [Email], [Telefone], [CEP], [Rua], [Numero], [Bairro], [Complemento], [Cidade], [Estado], [Obs] FROM Clientes WHERE [Ativo] = @status";


        // Usando SqlConnection para conectar ao banco de dados
        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            // Criando o comando SQL
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add(new SqlParameter("@status", System.Data.SqlDbType.Int) { Value = Status });

                try
                {
                    // Abrindo conexão
                    connection.Open();

                    // Executando o comando e obtendo os resultados em um SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verifica se há linhas retornadas
                        if (reader.HasRows)
                        {
                            // Para cada linha retornada, cria uma nova linha na DataTable
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

    public List<string> BuscaClienteId(int Id)
    {
        // Consulta SELECT
        string query = @"SELECT * FROM Clientes WHERE Id = @id";

        // Usando SqlConnection para conectar ao banco de dados
        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                // Abrindo conexão
                connection.Open();

                // Criando o comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adicionando parâmetros usando SqlParameter para maior controle de tipo
                    command.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int) { Value = Id });

                    // Executando o comando e obtendo os resultados em um SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verifica se há linhas retornadas
                        if (reader.HasRows)
                        {
                            // Lendo linha
                            if (reader.Read())
                            {
                                List<string> lista = new List<string>();
                                // Acessando os valores por índice ou nome da coluna
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    lista.Add(reader[i].ToString());
                                }

                                return lista;
                            }
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
                // Fechando conexão
                connection.Close();
            }
        }

        return new List<string>();
    }

    //  Insere um novo cliente no banco da dados com parâmetros
    public bool InsereCliente(string documento, string razao, string fantasia, string email, string telefone, string cep, string rua, string numero, string bairro, string complemento, string cidade, string estado, string obs)
    {
        // Comando para inserir um novo cliente
        var query = @"INSERT INTO Clientes ([CPF/CNPJ], [Razao], [Fantasia], [Email], [Telefone], [CEP], [Rua], [Numero], [Bairro], [Complemento], [Cidade], [Estado], [Obs]) VALUES (@cnpj, @razao, @fantasia, @email, @telefone, @cep, @rua, @numero, @bairro, @complemento, @cidade, @estado, @obs)";

        // Usando SqlConnection para conectar ao banco de dados
        using var connection = new SqlConnection(stringConexao);
        try
        {
            // Abrindo conexão
            connection.Open();

            // Criando o comando SQL
            using var command = new SqlCommand(query, connection);
            // Adicionando parâmetros usando SqlParameter para maior controle de tipo
            command.Parameters.Add(new SqlParameter("@cnpj", System.Data.SqlDbType.VarChar) { Value = documento });
            command.Parameters.Add(new SqlParameter("@razao", System.Data.SqlDbType.VarChar) { Value = razao });
            command.Parameters.Add(new SqlParameter("@fantasia", System.Data.SqlDbType.VarChar) { Value = fantasia });
            command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar) { Value = email });
            command.Parameters.Add(new SqlParameter("@telefone", System.Data.SqlDbType.VarChar) { Value = telefone });
            command.Parameters.Add(new SqlParameter("@cep", System.Data.SqlDbType.VarChar) { Value = cep });
            command.Parameters.Add(new SqlParameter("@rua", System.Data.SqlDbType.VarChar) { Value = rua });
            command.Parameters.Add(new SqlParameter("@numero", System.Data.SqlDbType.VarChar) { Value = numero });
            command.Parameters.Add(new SqlParameter("@bairro", System.Data.SqlDbType.VarChar) { Value = bairro });
            command.Parameters.Add(new SqlParameter("@complemento", System.Data.SqlDbType.VarChar) { Value = complemento });
            command.Parameters.Add(new SqlParameter("@cidade", System.Data.SqlDbType.VarChar) { Value = cidade });
            command.Parameters.Add(new SqlParameter("@estado", System.Data.SqlDbType.VarChar) { Value = estado });
            command.Parameters.Add(new SqlParameter("@obs", System.Data.SqlDbType.VarChar) { Value = obs });

            // Executando o comando
            command.ExecuteNonQuery();

            return true;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return false;
        }
    }


    public bool AlteraCliente(string id, string documento, string razao, string fantasia, string email, string telefone, string cep, string rua, string numero, string bairro, string complemento, string cidade, string estado, string obs)
    {
        // Comando para atualizar os dados do cliente
        var query = @"UPDATE Clientes SET [CPF/CNPJ] = @cnpj, [Razao] = @razao, [Fantasia] = @fantasia, [Email] = @email, [Telefone] = @telefone, [CEP] = @cep, [Rua] = @rua, [Numero] = @numero, [Bairro] = @bairro, [Complemento] = @complemento, [Cidade] = @cidade, [Estado] = @estado, [Obs] = @obs WHERE Id = @id";

        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Parâmetros para evitar SQL Injection
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@cnpj", SqlDbType.VarChar)).Value = documento;
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

                    // Executando o comando
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Retorna true se ao menos uma linha foi atualizada
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções de forma adequada
                Console.WriteLine("Erro ao atualizar o cliente: " + ex.Message);
                return false;
            }
        }
    }

    //Inativar ou ativar um cliente
    public bool InativaAtivaCliente(string id, bool status)
    {
        // Comando para inativar ou ativar um cliente
        var query = @"UPDATE Clientes SET [Ativo] = @status WHERE Id = @id";
        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Parâmetros para evitar SQL Injection
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Bit)).Value = status;
                    // Executando o comando
                    int rowsAffected = cmd.ExecuteNonQuery();
                    // Retorna true se ao menos uma linha foi atualizada
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções de forma adequada
                Console.WriteLine("Erro ao inativar o cliente: " + ex.Message);
                return false;
            }
        }
    }
}
