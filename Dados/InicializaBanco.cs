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
            CreateTableVendas(connection);
            CreateTableVendaItens(connection);
            CreateTableEmpresa(connection);

            // Verificar e adicionar colunas conforme as definições das tabelas
            VerificarColunasClientes(connection);
            VerificarColunasFornecedores(connection);
            VerificarColunasProdutos(connection);
            VerificarColunasUsuarios(connection);
            VerificarColunasVendas(connection);
            VerificarColunasVendaItens(connection);
            VerificarColunasEmpresa(connection);

            // Criar chaves estrangeiras
            CriarChavesEstrangeiras(connection);

            // Insere usuário ADM
            ExecuteSqlCommand(connection, @"
                IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE ID = 1)
                BEGIN
                    INSERT INTO Usuarios (Nome, Email, Senha) 
                    VALUES ('PasiWare', 'suporte@pasiware.com', '1234');
                END
            ");

            // Insere empresa padrão se não existir
            ExecuteSqlCommand(connection, @"
                IF NOT EXISTS (SELECT 1 FROM Empresa)
                BEGIN
                    INSERT INTO Empresa (ClienteId, NomeCliente) 
                    VALUES (NEWID(), 'Empresa Principal');
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

    private static void CreateTableVendas(SqlConnection connection)
    {
        string createVendasTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Vendas' AND xtype='U')
            CREATE TABLE Vendas (
                Id INT IDENTITY(1,1) PRIMARY KEY
            );";
        ExecuteSqlCommand(connection, createVendasTable);
    }

    private static void CreateTableVendaItens(SqlConnection connection)
    {
        string createVendaItensTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='VendaItens' AND xtype='U')
            CREATE TABLE VendaItens (
                Id INT IDENTITY(1,1) PRIMARY KEY
            );";
        ExecuteSqlCommand(connection, createVendaItensTable);
    }

    private static void CreateTableEmpresa(SqlConnection connection)
    {
        string createEmpresaTable = @"
            IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Empresa' AND xtype='U')
            CREATE TABLE Empresa (
                ClienteId UNIQUEIDENTIFIER PRIMARY KEY
            );";
        ExecuteSqlCommand(connection, createEmpresaTable);
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
            new { Nome = "Estoque", Definicao = "DECIMAL(18,3) NOT NULL" },
            new { Nome = "Fornecedor", Definicao = "INT NOT NULL" },
            new { Nome = "Ativo", Definicao = "BIT DEFAULT 1 NOT NULL" },
            new { Nome = "DataCadastro", Definicao = "DATETIME DEFAULT GETDATE() NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Produtos", coluna.Nome, coluna.Definicao);
        }

        MigrarColunaEstoqueProdutos(connection);
    }

    private static void MigrarColunaEstoqueProdutos(SqlConnection connection)
    {
        string migrarEstoqueQuery = @"
            IF EXISTS (
                SELECT 1
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'Produtos'
                  AND COLUMN_NAME = 'Estoque'
                  AND (DATA_TYPE <> 'decimal' OR ISNULL(NUMERIC_PRECISION, 0) <> 18 OR ISNULL(NUMERIC_SCALE, 0) <> 3)
            )
            BEGIN
                DECLARE @DefaultConstraintName NVARCHAR(256);
                DECLARE @DefaultDefinition NVARCHAR(MAX);
                DECLARE @Sql NVARCHAR(MAX);

                -- Verifica se existe Default Constraint vinculada à coluna Estoque
                SELECT 
                    @DefaultConstraintName = dc.name,
                    @DefaultDefinition = dc.definition
                FROM sys.default_constraints dc
                INNER JOIN sys.columns c 
                    ON dc.parent_object_id = c.object_id 
                   AND dc.parent_column_id = c.column_id
                WHERE dc.parent_object_id = OBJECT_ID(N'Produtos')
                  AND c.name = N'Estoque';

                IF @DefaultConstraintName IS NOT NULL
                BEGIN
                    SET @Sql = N'ALTER TABLE [Produtos] DROP CONSTRAINT [' + @DefaultConstraintName + N'];';
                    EXEC sp_executesql @Sql;
                END

                -- Garante que não existam valores nulos antes de aplicar NOT NULL
                UPDATE [Produtos] SET [Estoque] = 0 WHERE [Estoque] IS NULL;

                -- Altera o tipo da coluna preservando todos os valores existentes
                ALTER TABLE [Produtos] ALTER COLUMN [Estoque] DECIMAL(18,3) NOT NULL;

                -- Recria a Default Constraint caso existisse anteriormente
                IF @DefaultConstraintName IS NOT NULL AND @DefaultDefinition IS NOT NULL
                BEGIN
                    SET @Sql = N'ALTER TABLE [Produtos] ADD CONSTRAINT [' + @DefaultConstraintName + N'] DEFAULT ' + @DefaultDefinition + N' FOR [Estoque];';
                    EXEC sp_executesql @Sql;
                END
            END;";

        ExecuteSqlCommand(connection, migrarEstoqueQuery);
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

    private static void VerificarColunasVendas(SqlConnection connection)
    {
        var colunasEsperadas = new[]
        {
            new { Nome = "IdCliente", Definicao = "INT NOT NULL" },
            new { Nome = "IdUsuario", Definicao = "INT NOT NULL" },
            new { Nome = "DataVenda", Definicao = "DATETIME DEFAULT GETDATE() NOT NULL" },
            new { Nome = "ValorTotal", Definicao = "DECIMAL(18,2) NOT NULL" },
            new { Nome = "Situacao", Definicao = "NVARCHAR(20) NOT NULL" },
            new { Nome = "Observacao", Definicao = "NVARCHAR(255)" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Vendas", coluna.Nome, coluna.Definicao);
        }
    }

    private static void VerificarColunasVendaItens(SqlConnection connection)
    {
        var colunasEsperadas = new[]
        {
            new { Nome = "IdVenda", Definicao = "INT NOT NULL" },
            new { Nome = "IdProduto", Definicao = "INT NOT NULL" },
            new { Nome = "Quantidade", Definicao = "DECIMAL(18,3) NOT NULL" },
            new { Nome = "ValorUnitario", Definicao = "DECIMAL(18,2) NOT NULL" },
            new { Nome = "ValorTotalItem", Definicao = "DECIMAL(18,2) NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "VendaItens", coluna.Nome, coluna.Definicao);
        }
    }

    private static void VerificarColunasEmpresa(SqlConnection connection)
    {
        // Definição das colunas esperadas para a tabela Empresa
        var colunasEsperadas = new[]
        {
            new { Nome = "NomeCliente", Definicao = "VARCHAR(100) NOT NULL" }
        };

        foreach (var coluna in colunasEsperadas)
        {
            VerificarEAdicionarColuna(connection, "Empresa", coluna.Nome, coluna.Definicao);
        }
    }

    private static void CriarChavesEstrangeiras(SqlConnection connection)
    {
        // Adiciona a chave estrangeira à tabela Produtos, vinculando o campo Fornecedor ao Id da tabela Fornecedores
        string adicionarFKProdutosFornecedorQuery = @"
            IF NOT EXISTS (
                SELECT * FROM sys.foreign_keys 
                WHERE object_id = OBJECT_ID(N'FK_Produtos_Fornecedor_Fornecedores_Id')
                  AND parent_object_id = OBJECT_ID(N'Produtos')
            )
            BEGIN
                ALTER TABLE Produtos
                ADD CONSTRAINT FK_Produtos_Fornecedor_Fornecedores_Id
                FOREIGN KEY (Fornecedor) REFERENCES Fornecedores(Id);
            END";
        ExecuteSqlCommand(connection, adicionarFKProdutosFornecedorQuery);

        // Adiciona a chave estrangeira à tabela Vendas, vinculando o campo IdCliente ao Id da tabela Clientes
        string adicionarFKVendasClienteQuery = @"
            IF NOT EXISTS (
                SELECT * FROM sys.foreign_keys 
                WHERE object_id = OBJECT_ID(N'FK_Vendas_IdCliente_Clientes_Id')
                  AND parent_object_id = OBJECT_ID(N'Vendas')
            )
            BEGIN
                ALTER TABLE Vendas
                ADD CONSTRAINT FK_Vendas_IdCliente_Clientes_Id
                FOREIGN KEY (IdCliente) REFERENCES Clientes(Id);
            END";
        ExecuteSqlCommand(connection, adicionarFKVendasClienteQuery);

        // Adiciona a chave estrangeira à tabela Vendas, vinculando o campo IdUsuario ao Id da tabela Usuarios
        string adicionarFKVendasUsuarioQuery = @"
            IF NOT EXISTS (
                SELECT * FROM sys.foreign_keys 
                WHERE object_id = OBJECT_ID(N'FK_Vendas_IdUsuario_Usuarios_Id')
                  AND parent_object_id = OBJECT_ID(N'Vendas')
            )
            BEGIN
                ALTER TABLE Vendas
                ADD CONSTRAINT FK_Vendas_IdUsuario_Usuarios_Id
                FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id);
            END";
        ExecuteSqlCommand(connection, adicionarFKVendasUsuarioQuery);

        // Adiciona a chave estrangeira à tabela VendaItens, vinculando o campo IdVenda ao Id da tabela Vendas
        string adicionarFKVendaItensVendaQuery = @"
            IF NOT EXISTS (
                SELECT * FROM sys.foreign_keys 
                WHERE object_id = OBJECT_ID(N'FK_VendaItens_IdVenda_Vendas_Id')
                  AND parent_object_id = OBJECT_ID(N'VendaItens')
            )
            BEGIN
                ALTER TABLE VendaItens
                ADD CONSTRAINT FK_VendaItens_IdVenda_Vendas_Id
                FOREIGN KEY (IdVenda) REFERENCES Vendas(Id);
            END";
        ExecuteSqlCommand(connection, adicionarFKVendaItensVendaQuery);

        // Adiciona a chave estrangeira à tabela VendaItens, vinculando o campo IdProduto ao Id da tabela Produtos
        string adicionarFKVendaItensProdutoQuery = @"
            IF NOT EXISTS (
                SELECT * FROM sys.foreign_keys 
                WHERE object_id = OBJECT_ID(N'FK_VendaItens_IdProduto_Produtos_Id')
                  AND parent_object_id = OBJECT_ID(N'VendaItens')
            )
            BEGIN
                ALTER TABLE VendaItens
                ADD CONSTRAINT FK_VendaItens_IdProduto_Produtos_Id
                FOREIGN KEY (IdProduto) REFERENCES Produtos(Id);
            END";
        ExecuteSqlCommand(connection, adicionarFKVendaItensProdutoQuery);
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
