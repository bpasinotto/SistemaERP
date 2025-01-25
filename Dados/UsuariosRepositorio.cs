using System;
using System.Collections.Generic;
using System.Configuration;
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

    public List<string> Dados(string Nome, string Senha)
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
}
