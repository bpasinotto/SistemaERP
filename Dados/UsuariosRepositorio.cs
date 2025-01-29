using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SistemaERP.Negocio;

namespace SistemaERP.Dados;
public class UsuariosRepositorio
{

    public UsuariosRepositorio()
    {
    }

    public List<string> BuscaUsuarioNomeSenha(string Nome, string Senha)
    {       

        var connectionString = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

        // Consulta SELECT
        string query = @"SELECT Id, Nome, Email, Senha FROM dbo.Usuarios WHERE Nome = @nome AND Senha = @senha";

        // Usando SqlConnection para conectar ao banco de dados
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Abrindo conexão
                connection.Open();

                // Criando o comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adicionando parâmetros usando SqlParameter para maior controle de tipo
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar) { Value = Nome });
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar) { Value = Senha });

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
                                return new List<string> { reader["Id"].ToString(), reader["Nome"].ToString(), reader["Email"].ToString(), reader["Senha"].ToString() };
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao consultar o banco de dados.", ex);
            }
        }

        return null;
    }


    public DataTable BuscaTodosUsuarios()
    {

        var connectionString = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

        // Consulta SELECT
        string query = @"SELECT Id, Nome, Email FROM dbo.Usuarios";

        // Usando SqlConnection para conectar ao banco de dados
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Abrindo conexão
                connection.Open();

                // Criando o comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    // Executando o comando e obtendo os resultados em um SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verifica se há linhas retornadas
                        if (reader.HasRows)
                        {
                            //Para cado linha retornada, cria uma nova linha na DataTable
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            return dataTable;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar o banco de dados.", ex);
            }
        }
        
    }

    //  Insere um novo usuário no banco da dados com parâmetros
    public string InsereUsuario(string Nome, string Email, string Senha)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

        // Consulta INSERT
        string query = @"INSERT INTO dbo.Usuarios (Nome, Email, Senha) VALUES (@nome, @email, @senha)";

        // Usando SqlConnection para conectar ao banco de dados
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Abrindo conexão
                connection.Open();

                // Criando o comando SQL
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adicionando parâmetros usando SqlParameter para maior controle de tipo
                    command.Parameters.Add(new SqlParameter("@nome", System.Data.SqlDbType.VarChar) { Value = Nome });
                    command.Parameters.Add(new SqlParameter("@email", System.Data.SqlDbType.VarChar) { Value = Email });
                    command.Parameters.Add(new SqlParameter("@senha", System.Data.SqlDbType.VarChar) { Value = Senha });

                    // Executando o comando
                    command.ExecuteNonQuery();

                    // Fechando conexão
                    connection.Close();

                    return "Usuário cadastrado com sucesso!";

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir no banco de dados.", ex);
            }
        }
    }



}
