using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SistemaERP.Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Syncfusion.Windows.Forms.Diagram;
using System.Windows.Navigation;

namespace SistemaERP.Dados;
public class UsuariosRepositorio
{
    string stringConexao = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

    public UsuariosRepositorio()
    {
    }


    public List<string> BuscaUsuarioId(int Id)
    {

        // Consulta SELECT
        string query = @"SELECT Id, Nome, Email, Senha, Ativo FROM dbo.Usuarios WHERE Id = @id";

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
                                // Acessando os valores por índice ou nome da coluna
                                return new List<string> { reader["Id"].ToString(), reader["Nome"].ToString(), reader["Email"].ToString(), reader["Senha"].ToString(), reader["Ativo"].ToString() };
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {                
                connection.Close();
            }
        }

        return new List<string>();
    }


    internal List<int> BuscaUsuarioNomeSenha(string Nome, string Senha)
    {
        string query = @"SELECT Id, Ativo FROM dbo.Usuarios WHERE Nome = @nome AND Senha = @senha";

        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar) { Value = Nome });
                    command.Parameters.Add(new SqlParameter("@senha", SqlDbType.VarChar) { Value = Senha });

                    // Executa o comando e obtem os resultados em um SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verifica se há linhas retornadas
                        if (reader.HasRows)
                        {
                            // Lê a linha
                            if (reader.Read())
                            {
                                // Acessa os valores por índice ou nome da coluna
                                return new List<int> { Convert.ToInt32(reader["Id"]), Convert.ToInt16(reader["Ativo"]) };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar usuário do banco de dados", ex);
            }

            return new List<int> { 0, 0 };

        }
        
    }


    public DataTable BuscaTodosUsuarios(int Status)
    {
        // Consulta SELECT
        string query = @"SELECT Id, Nome, Email FROM dbo.Usuarios WHERE Ativo = @status";

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

    //  Insere um novo usuário no banco da dados com parâmetros
    public bool InsereUsuario(string Nome, string Email, string Senha)
    {
        // Comando para inserir um novo usuário
        var query = @"INSERT INTO dbo.Usuarios (Nome, Email, Senha) VALUES (@nome, @email, @senha)";

        // Usando SqlConnection para conectar ao banco de dados
        using var connection = new SqlConnection(stringConexao);
        try
        {
            // Abrindo conexão
            connection.Open();

            // Criando o comando SQL
            using var command = new SqlCommand(query, connection);
            // Adicionando parâmetros usando SqlParameter para maior controle de tipo
            command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar) { Value = Nome });
            command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar) { Value = Email });
            command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar) { Value = Senha });

            // Executando o comando
            command.ExecuteNonQuery();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Recebe Id e altera Nome, Email e Senha do usuário
    public bool AlterarUsuario(string id, string nome, string email, string senha)
    {
        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();

                string query = "UPDATE Usuarios SET Nome = @Nome, Email = @Email, Senha = @Senha WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Parâmetros para evitar SQL Injection
                    cmd.Parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar)).Value = nome;
                    cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar)).Value = email;
                    cmd.Parameters.Add(new SqlParameter("@Senha", SqlDbType.NVarChar)).Value = senha;
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;                    

                    // Executando o comando
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Retorna true se ao menos uma linha foi atualizada
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções de forma adequada
                Console.WriteLine("Erro ao atualizar o usuário: " + ex.Message);
                return false;
            }
        }
    }


    public int ExisteAdmin()
    {

        string query = @"SELECT COUNT(*) FROM Usuarios;";

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
                    // Executando o comando e pegando o resultado
                    var resultado = command.ExecuteScalar();

                    // Fechando conexão
                    connection.Close();

                    // Convertendo o resultado para int 
                    int count = Convert.ToInt32(resultado);

                    // Se o resultado for igual a 1, significa que há usuários na tabela
                    return count;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar o banco de dados.", ex);
            }
        }
    }


    //Inativar e ativar usuário 
    public bool InativarAtivarUsuario(string id, bool status)
    {
        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();
                string query = "UPDATE Usuarios SET Ativo = @status WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // Parâmetros para evitar SQL Injection
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;
                    cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.Int)).Value = status;
                    // Executando o comando
                    int rowsAffected = cmd.ExecuteNonQuery();
                    // Retorna true se ao menos uma linha foi atualizada
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções de forma adequada
                Console.WriteLine("Erro ao atualizar o usuário: " + ex.Message);
                return false;
            }
        }
    }


}
