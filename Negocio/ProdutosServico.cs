using System.Data;
using SistemaERP.Dados;

namespace SistemaERP.Negocio
{
    public class ProdutosServico
    {
        private readonly ProdutosRepositorio _produtosRepositorio;

        private static readonly HashSet<string> UnidadesInteiras = new(StringComparer.OrdinalIgnoreCase)
        {
            "UN", "CX", "PC"
        };

        private static readonly HashSet<string> UnidadesFracionaveis = new(StringComparer.OrdinalIgnoreCase)
        {
            "KG", "G", "T", "M", "CM", "L", "ML", "M²", "M³"
        };

        public ProdutosServico()
        {
            _produtosRepositorio = new ProdutosRepositorio();
        }

        /// <summary>
        /// Verifica se a unidade de medida exige valores estritamente inteiros (UN, CX, PC)
        /// </summary>
        public static bool UnidadeExigeInteiro(string? un)
        {
            if (string.IsNullOrWhiteSpace(un))
                return false;

            return UnidadesInteiras.Contains(un.Trim());
        }

        /// <summary>
        /// Verifica se a unidade de medida permite valores fracionados com até 3 casas decimais
        /// </summary>
        public static bool UnidadePermiteFracao(string? un)
        {
            if (string.IsNullOrWhiteSpace(un))
                return false;

            return UnidadesFracionaveis.Contains(un.Trim());
        }

        /// <summary>
        /// Verifica se o valor decimal possui mais de 3 casas decimais
        /// </summary>
        public static bool PossuiMaisDeTresCasasDecimais(decimal valor)
        {
            return decimal.Round(valor, 3) != valor;
        }

        /// <summary>
        /// Valida uma quantidade (de estoque ou de venda) de acordo com a unidade de medida do produto
        /// </summary>
        public static bool ValidarQuantidadePorUnidade(decimal quantidade, string? un, bool permitirZero, out string mensagemErro)
        {
            if (string.IsNullOrWhiteSpace(un))
            {
                mensagemErro = "A unidade de medida é obrigatória.";
                return false;
            }

            string unidade = un.Trim().ToUpperInvariant();

            if (permitirZero)
            {
                if (quantidade < 0)
                {
                    mensagemErro = "O estoque não pode ser negativo.";
                    return false;
                }
            }
            else
            {
                if (quantidade <= 0)
                {
                    mensagemErro = "A quantidade deve ser maior que zero.";
                    return false;
                }
            }

            if (UnidadeExigeInteiro(unidade))
            {
                if (quantidade % 1m != 0m)
                {
                    mensagemErro = $"A unidade de medida '{unidade}' aceita somente quantidades inteiras.";
                    return false;
                }

                mensagemErro = string.Empty;
                return true;
            }

            if (UnidadePermiteFracao(unidade))
            {
                if (PossuiMaisDeTresCasasDecimais(quantidade))
                {
                    mensagemErro = $"A unidade de medida '{unidade}' aceita no máximo 3 casas decimais.";
                    return false;
                }

                mensagemErro = string.Empty;
                return true;
            }

            mensagemErro = $"A unidade de medida '{unidade}' é inválida.";
            return false;
        }

        /// <summary>
        /// Cadastra um novo produto no sistema
        /// </summary>
        public bool CadastraProduto(string nome, decimal preco, decimal custo, string un, decimal estoque, int fornecedor)
        {
            if (!ValidarQuantidadePorUnidade(estoque, un, permitirZero: true, out _))
                return false;

            return _produtosRepositorio.InsereProduto(nome, preco, custo, un.Trim().ToUpperInvariant(), decimal.Round(estoque, 3), fornecedor);
        }

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        public bool AtualizaProduto(int id, string nome, decimal preco, decimal custo, string un, decimal estoque, int fornecedor)
        {
            if (!ValidarQuantidadePorUnidade(estoque, un, permitirZero: true, out _))
                return false;

            return _produtosRepositorio.AlteraProduto(id, nome, preco, custo, un.Trim().ToUpperInvariant(), decimal.Round(estoque, 3), fornecedor);
        }

        /// <summary>
        /// Retorna todos os produtos
        /// </summary>
        public DataTable RetornaTodosProdutos(bool Inativos)
        {
            var Status = 1;
            if (Inativos)
            {
                Status = 0;
            }

            return _produtosRepositorio.ConsultaTodosProdutos(Status);
        }

        /// <summary>
        /// Busca produto pelo ID
        /// </summary>
        public DataRow BuscaProdutoPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID do produto inválido");

            return _produtosRepositorio.ConsultaProdutoPorId(id);
        }

        /// <summary>
        /// Ativa ou inativa um produto
        /// </summary>
        public bool AtivaInativaProduto(int id, bool ativar)
        {
            if (id <= 0)
                throw new ArgumentException("ID do produto inválido");

            return _produtosRepositorio.AtivaInativaProduto(id, ativar);
        }
    }
}
