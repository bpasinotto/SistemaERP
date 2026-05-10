using System.Configuration;
using Microsoft.Data.SqlClient;

namespace SistemaERP.Dados;

internal class EmpresaRepositorio
{
    private string stringConexao = ConfigurationManager.ConnectionStrings["ComBanco"].ConnectionString;

    /// <summary>
    /// Obtém o ClienteId da tabela Empresa
    /// </summary>
    public Guid? ObterClienteId()
    {
        string query = @"SELECT TOP 1 ClienteId FROM Empresa";

        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            var clienteIdValue = reader["ClienteId"];
                            if (clienteIdValue != DBNull.Value)
                            {
                                return (Guid)clienteIdValue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar ClienteId da tabela Empresa.", ex);
            }
        }

        return null;
    }

    /// <summary>
    /// Insere um novo registro na tabela Empresa se não existir
    /// </summary>
    public void InserirEmpresaSePreciso()
    {
        string query = @"
            IF NOT EXISTS (SELECT 1 FROM Empresa)
            BEGIN
                INSERT INTO Empresa (ClienteId, NomeCliente)
                VALUES (@ClienteId, @NomeCliente)
            END
        ";

        using (SqlConnection connection = new SqlConnection(stringConexao))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var novoClienteId = Guid.NewGuid();
                    command.Parameters.AddWithValue("@ClienteId", novoClienteId);
                    command.Parameters.AddWithValue("@NomeCliente", "Empresa Principal");

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir empresa na tabela Empresa.", ex);
            }
        }
    }
}
