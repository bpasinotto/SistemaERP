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
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = @DatabaseName)
                BEGIN
                    CREATE DATABASE [" + databaseName + @"];
                END;";

            // Conectando à instância do SQL Server
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand(createDatabaseQuery, connection);
            command.Parameters.AddWithValue("@DatabaseName", databaseName);
            command.ExecuteNonQuery();

            connection.ChangeDatabase(databaseName);

            // Criar tabelas
            CreateTableClientes(connection);
            CreateTableFornecedores(connection);
            CreateTableProdutos(connection);
            CreateTableUsuarios(connection);

            // Verificar e adicionar colunas conforme as definições das tabelas
            VerificarColunasClientes(connection);
            VerificarColunasFornecedores(connection);
            VerificarColunasProdutos(connection);
            VerificarColunasUsuarios(connection);

            // Insere usuário ADM
            ExecuteSqlCommand(connection, @"
                IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE ID = 1)
                BEGIN
                    INSERT INTO Usuarios (Nome, Email, Senha) 
                    VALUES ('PasiWare', 'suporte@pasiware.com', 'Bpdo8787');
                END
            ");
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao criar o banco de dados: {ex.Message}");
        }
    }

    private static void CreateTableClientes(SqlConnection connection)
    {
        string createClientesTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clientes' AND xtype='U')
            CREATE TABLE Clientes (
                Id INT IDENTITY(1,1) PRIMARY KEY                
            );";

        ExecuteSqlCommand(connection, createClientesTable);
    }

    private static void CreateTableFornecedores(SqlConnection connection)
    {
        string createFornecedoresTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Fornecedores' AND xtype='U')
            CREATE TABLE Fornecedores (
                Id INT IDENTITY(1,1) PRIMARY KEY                
            );";

        ExecuteSqlCommand(connection, createFornecedoresTable);
    }

    private static void CreateTableProdutos(SqlConnection connection)
    {
        string createProdutosTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Produtos' AND xtype='U')
            CREATE TABLE Produtos (
                Id INT IDENTITY(1,1) PRIMARY KEY               
            );";

        ExecuteSqlCommand(connection, createProdutosTable);
    }

    private static void CreateTableUsuarios(SqlConnection connection)
    {
        string createUsuariosTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuarios' AND xtype='U')
            CREATE TABLE Usuarios (
                Id INT IDENTITY(1,1) PRIMARY KEY                
            );";

        ExecuteSqlCommand(connection, createUsuariosTable);
    }

    private static void VerificarColunasClientes(SqlConnection connection)
    {
        // Definição das colunas esperadas para a tabela Clientes
        var colunasEsperadas = new[]
        {
            //new { Nome = "Id", Definicao = "INT IDENTITY(1,1) PRIMARY KEY" },
            new { Nome = "CPF/CNPJ", Definicao = "NVARCHAR(20)" },
            new { Nome = "Razao", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Fantasia", Definicao = "NVARCHAR(100)" },
            new { Nome = "Email", Definicao = "NVARCHAR(100)" },
            new { Nome = "Telefone", Definicao = "NVARCHAR(15)" },
            new { Nome = "CEP", Definicao = "NVARCHAR(10)" },
            new { Nome = "Rua", Definicao = "NVARCHAR(100)" },
            new { Nome = "Numero", Definicao = "NVARCHAR(5)" },
            new { Nome = "Bairro", Definicao = "NVARCHAR(100)" },
            new { Nome = "Complemento", Definicao = "NVARCHAR(30)" },
            new { Nome = "Cidade", Definicao = "NVARCHAR(100)" },
            new { Nome = "Estado", Definicao = "NVARCHAR(2)" },
            new { Nome = "Obs", Definicao = "NVARCHAR(240)" },
            new { Nome = "Ativo", Definicao = "BIT DEFAULT 1 NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Clientes", coluna.Nome, coluna.Definicao);
        }
    }

    private static void VerificarColunasFornecedores(SqlConnection connection)
    {        
        var colunasEsperadas = new[]
        {            
            new { Nome = "CPF/CNPJ", Definicao = "NVARCHAR(20)" },
            new { Nome = "Razao", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Fantasia", Definicao = "NVARCHAR(100)" },
            new { Nome = "Email", Definicao = "NVARCHAR(100)" },
            new { Nome = "Telefone", Definicao = "NVARCHAR(15)" },
            new { Nome = "CEP", Definicao = "NVARCHAR(10)" },
            new { Nome = "Rua", Definicao = "NVARCHAR(100)" },
            new { Nome = "Numero", Definicao = "NVARCHAR(5)" },
            new { Nome = "Bairro", Definicao = "NVARCHAR(100)" },
            new { Nome = "Complemento", Definicao = "NVARCHAR(30)" },
            new { Nome = "Cidade", Definicao = "NVARCHAR(100)" },
            new { Nome = "Estado", Definicao = "NVARCHAR(2)" },
            new { Nome = "Obs", Definicao = "NVARCHAR(240)" },
            new { Nome = "Ativo", Definicao = "BIT DEFAULT 1 NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Fornecedores", coluna.Nome, coluna.Definicao);
        }
    }

    private static void VerificarColunasProdutos(SqlConnection connection)
    {
        // Definição das colunas esperadas para a tabela Produtos
        var colunasEsperadas = new[]
        {
            //new { Nome = "Id", Definicao = "INT IDENTITY(1,1) PRIMARY KEY" },
            new { Nome = "Nome", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Preco", Definicao = "DECIMAL(18,2) NOT NULL" },
            new { Nome = "Custo", Definicao = "DECIMAL(18,2) NOT NULL" },
            new { Nome = "Un", Definicao = "NVARCHAR(2) NOT NULL" },
            new { Nome = "Estoque", Definicao = "INT NOT NULL" },
            new { Nome = "Fornecedor", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Ativo", Definicao = "BIT DEFAULT 1 NOT NULL" },
            new { Nome = "DataCadastro", Definicao = "DATETIME DEFAULT GETDATE() NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Produtos", coluna.Nome, coluna.Definicao);
        }
    }

    private static void VerificarColunasUsuarios(SqlConnection connection)
    {
        // Definição das colunas esperadas para a tabela Usuarios
        var colunasEsperadas = new[]
        {
            //new { Nome = "Id", Definicao = "INT IDENTITY(1,1) PRIMARY KEY" },
            new { Nome = "Nome", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Email", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Senha", Definicao = "NVARCHAR(100) NOT NULL" },
            new { Nome = "Ativo", Definicao = "BIT DEFAULT 1 NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Usuarios", coluna.Nome, coluna.Definicao);
        }
    }

    private static void VerificarEAdicionarColuna(SqlConnection connection, string tabela, string coluna, string definicao)
    {
        string verificarColunaQuery = @"
            IF NOT EXISTS (
                SELECT * 
                FROM INFORMATION_SCHEMA.COLUMNS 
                WHERE TABLE_NAME = @Tabela 
                  AND COLUMN_NAME = @Coluna
            )
            BEGIN
                ALTER TABLE [" + tabela + @"] ADD [" + coluna + @"] " + definicao + @";
            END;";

        using SqlCommand command = new SqlCommand(verificarColunaQuery, connection);
        command.Parameters.AddWithValue("@Tabela", tabela);
        command.Parameters.AddWithValue("@Coluna", coluna);
        command.ExecuteNonQuery();
    }

    private static void ExecuteSqlCommand(SqlConnection connection, string commandText)
    {
        using SqlCommand command = new SqlCommand(commandText, connection);
        command.ExecuteNonQuery();
    }
}
