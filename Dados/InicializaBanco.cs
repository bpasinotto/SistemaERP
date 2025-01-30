using System.Configuration;
using Microsoft.Data.SqlClient;

public static class Banco
{
    public static void Inicializa()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["SemBanco"].ConnectionString;

        try
        {
            // Nome do banco de dados a ser criado
            var databaseName = "ERPDatabase";

            // Comando SQL para criar o banco de dados com uso de parâmetros
            var createDatabaseQuery = @"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ERPDatabase')
                BEGIN
                    CREATE DATABASE [ERPDatabase];
                END;";

            // Conectando à instância do SQL Server
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            using SqlCommand command = new SqlCommand(createDatabaseQuery, connection);
            command.ExecuteNonQuery();


            connection.ChangeDatabase("ERPDatabase");

            // Criar tabelas
            ExecuteSqlCommand(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clientes' AND xtype='U')
                CREATE TABLE Clientes (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nome NVARCHAR(100) NOT NULL,
                    Email NVARCHAR(100) NOT NULL
                );");

            ExecuteSqlCommand(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Produtos' AND xtype='U')
                CREATE TABLE Produtos (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nome NVARCHAR(100) NOT NULL,
                    Preco DECIMAL(18,2) NOT NULL
                );");

            ExecuteSqlCommand(connection, @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
                CREATE TABLE Usuarios (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nome NVARCHAR(100) NOT NULL,
                    Email NVARCHAR(100) NOT NULL,
                    Senha NVARCHAR(100) NOT NULL
                );");

            // Insere usuário ADM
            //ExecuteSqlCommand(connection, @"IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE ID = 1)
            //    BEGIN
            //    INSERT INTO Usuarios (Nome, Email, Senha) 
            //    VALUES ('Admin', 'admin@example.com', 'admin123');
            //    END
            //    ");

        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao criar o banco de dados: {ex.Message}");
        }
    }

    private static void ExecuteSqlCommand(SqlConnection connection, string commandText)
    {
        using SqlCommand command = new SqlCommand(commandText, connection);
        command.ExecuteNonQuery();
    }
}
