using System.Data;
using SistemaERP.Dados;

namespace SistemaERP.Negocio
{
    public class ProdutosServico
    {
        private readonly ProdutosRepositorio _produtosRepositorio;

        public ProdutosServico()
        {
            _produtosRepositorio = new ProdutosRepositorio();
        }

        /// <summary>
        /// Cadastra um novo produto no sistema
        /// </summary>
        public bool CadastraProduto(string nome, decimal preco, decimal custo, string un, int estoque, int fornecedor)
        {  
            return _produtosRepositorio.InsereProduto(nome, preco, custo, un, estoque, fornecedor);
        }

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        public bool AtualizaProduto(int id, string nome, decimal preco, decimal custo, string un, int estoque, int fornecedor)
        {
            return _produtosRepositorio.AlteraProduto(id, nome, preco, custo, un, estoque, fornecedor);
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
