using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao
{
    public partial class FormCadProdutos : FormBase
    {
        readonly int _produtoId;

        public FormCadProdutos()
        {
            InitializeComponent();
            ConfigurarValidacaoCampos();
        }

        public FormCadProdutos(int id)
        {
            InitializeComponent();
            _produtoId = id;
            ConfigurarValidacaoCampos();
        }

        private void FormCadProdutos_Load(object sender, EventArgs e)
        {
            lblDataCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CarregarFornecedores();
            cbFornecedor.SelectedIndex = -1;

            if (_produtoId > 0) // Se for edição
            {
                CarregarDadosProduto(_produtoId);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            // Exemplo de obtenção de valores dos campos do formulário
            string nome = txtNome.Texts; // Campo de texto para o nome do produto
            decimal preco = 0; // Campo de texto para o preço
            decimal custo = 0; // Campo de texto para o custo
            string un = cbUN.Text; // Campo de texto para a unidade de medida
            decimal estoque = 0; // Campo de texto para o estoque                            
            int fornecedor = Convert.ToInt32(cbFornecedor.SelectedValue); // Id do fornecedor selecionado
                                   

            // Validação Nome
            if (string.IsNullOrWhiteSpace(nome))
            {
                new FormMensagem("Atenção", "O nome do produto é obrigatório.").ShowDialog();
                return;
            }
            // Validação Preço          
            if (!decimal.TryParse(txtPreco.Texts, out preco) || preco <= 0)
            {
                new FormMensagem("Atenção", "O preço do produto deve ser maior que zero.").ShowDialog();
                return;
            }
            // Validação Custo
            if (!decimal.TryParse(txtCusto.Texts, out custo) || custo < 0)
            {
                new FormMensagem("Atenção", "O custo do produto não pode ser negativo.").ShowDialog();
                return;
            }
            // Validação Unidade de Medida
            if (string.IsNullOrWhiteSpace(un))
            {
                new FormMensagem("Atenção", "A unidade de medida é obrigatória.").ShowDialog();
                return;
            }
            // Validação Estoque
            if (!decimal.TryParse(txtEstoque.Texts, out estoque) || estoque < 0)
            {
                new FormMensagem("Atenção", "O estoque não pode ser negativo.").ShowDialog();
                return;
            }
            if (!ProdutosServico.ValidarQuantidadePorUnidade(estoque, un, permitirZero: true, out string erroEstoque))
            {
                new FormMensagem("Atenção", erroEstoque).ShowDialog();
                return;
            }
            // Validação Fornecedor
            if (fornecedor <= 0)
            {
                new FormMensagem("Atenção", "O fornecedor é obrigatório.").ShowDialog();
                return;
            }

            if (_produtoId > 0)
            {
                //chamar a função de alterar produto
                var produtosServico = new ProdutosServico();
                bool sucesso = produtosServico.AtualizaProduto(_produtoId, nome, preco, custo, un, estoque, fornecedor);
                // Exibe mensagem de sucesso ou erro
                if (sucesso)
                {
                    new FormMensagem("Sucesso", "Produto atualizado com sucesso!").ShowDialog();
                    LimparCampos();
                }
                else
                {
                    new FormMensagem("Erro", "Falha ao atualizar o produto.").ShowDialog();
                }
            }
            else
            {
                // Instancia o serviço e cadastra o produto
                var produtosServico = new ProdutosServico();
                bool sucesso = produtosServico.CadastraProduto(nome, preco, custo, un, estoque, fornecedor);

                // Exibe mensagem de sucesso ou erro
                if (sucesso)
                {
                    new FormMensagem("Sucesso", "Produto cadastrado com sucesso!").ShowDialog();
                    LimparCampos();
                }
                else
                {
                    new FormMensagem("Erro", "Falha ao cadastrar o produto.").ShowDialog();
                }
            }

        }

        private void LimparCampos()
        {
            txtNome.Texts = string.Empty;
            txtPreco.Texts = string.Empty;
            txtCusto.Texts = string.Empty;
            cbUN.SelectedIndex = -1;
            txtEstoque.Texts = string.Empty;
            cbFornecedor.SelectedIndex = -1;
            txtNome.Focus();
        }

        private void CarregarFornecedores()
        {
            var fornecedores = new FornecedoresServico().ObterTodosFornecedores();
            cbFornecedor.DataSource = fornecedores;
            cbFornecedor.DisplayMember = "Razao";
            cbFornecedor.ValueMember = "Id";
        }

        private void CarregarDadosProduto(int produtoId)
        {
            // Busca o produto pelo ID  
            var produto = new ProdutosServico().BuscaProdutoPorId(produtoId);

            if (produto != null)
            {
                // Verifica se o objeto retornado é um DataRow e acessa os valores corretamente  
                if (produto is DataRow dataRow)
                {
                    int status = Convert.ToInt32(dataRow["Ativo"]);
                    if (status == 0)
                    {
                        btnAtivaInativa.Text = "Ativar Produto";
                    }                   

                    lblDataCadastro.Text = Convert.ToDateTime(dataRow["DataCadastro"]).ToString("dd/MM/yyyy");
                    txtNome.Texts = dataRow["Nome"].ToString();
                    txtPreco.Texts = Convert.ToDecimal(dataRow["Preco"]).ToString();
                    txtCusto.Texts = Convert.ToDecimal(dataRow["Custo"]).ToString();
                    cbUN.Text = dataRow["Un"].ToString();
                    txtEstoque.Texts = Convert.ToDecimal(dataRow["Estoque"]).ToString("0.###");

                    // Seleciona o fornecedor correspondente no ComboBox  
                    cbFornecedor.SelectedValue = Convert.ToInt32(dataRow["Fornecedor"]);
                }
                else
                {
                    new FormMensagem("Erro", "Erro ao carregar os dados do produto.").ShowDialog();
                }
            }
            else
            {
                new FormMensagem("Erro", "Produto não encontrado.").ShowDialog();
                Close();
            }
        }


        private void ConfigurarValidacaoCampos()
        {
            // txtEstoque - Validação conforme a unidade de medida selecionada (inteiro para UN/CX/PC, até 3 casas decimais para as demais)
            txtEstoque.KeyPress += (sender, e) =>
            {
                if (char.IsControl(e.KeyChar))
                    return;

                bool exigeInteiro = ProdutosServico.UnidadeExigeInteiro(cbUN.Text);

                if (exigeInteiro)
                {
                    if (!char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                    {
                        e.Handled = true;
                        return;
                    }

                    if (e.KeyChar == ',' && txtEstoque.Texts.Contains(','))
                    {
                        e.Handled = true;
                        return;
                    }

                    int indiceVirgula = txtEstoque.Texts.IndexOf(',');
                    if (char.IsDigit(e.KeyChar) && indiceVirgula >= 0 && txtEstoque.SelectionStart > indiceVirgula)
                    {
                        string casasDecimais = txtEstoque.Texts[(indiceVirgula + 1)..];
                        if (casasDecimais.Length >= 3)
                        {
                            e.Handled = true;
                        }
                    }
                }
            };

            // txtPreco - Apenas números e vírgula
            txtPreco.KeyPress += (sender, e) =>
            {
                // Permite dígitos numéricos, vírgula e teclas de controle
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }

                // Garante apenas uma vírgula
                if (e.KeyChar == ',' && txtPreco.Texts.Contains(','))
                {
                    e.Handled = true;
                }
            };

            // txtCusto - Apenas números e vírgula
            txtCusto.KeyPress += (sender, e) =>
            {
                // Permite dígitos numéricos, vírgula e teclas de controle
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }

                // Garante apenas uma vírgula
                if (e.KeyChar == ',' && txtCusto.Texts.Contains(','))
                {
                    e.Handled = true;
                }
            };
        }

        private void btnAtivaInativa_Click(object sender, EventArgs e)
        {
            if (_produtoId <= 0)
            {
                // Não é possível ativar/inativar um produto que ainda não foi salvo
                new FormMensagem("Atenção", "É necessário salvar o produto primeiro para poder ativar/inativar.").ShowDialog();
                return;
            }

            // Busca o produto atual para verificar seu estado
            var produtosServico = new ProdutosServico();
            DataRow produto = produtosServico.BuscaProdutoPorId(_produtoId);

            if (produto == null)
            {
                new FormMensagem("Erro", "Não foi possível encontrar o produto.").ShowDialog();
                return;
            }

            // Verifica o estado atual do produto (1 = ativo, 0 = inativo)
            bool produtoAtual = Convert.ToBoolean(produto["Ativo"]);

            // Inverte o estado (se está ativo, inativa; se está inativo, ativa)
            bool novoEstado = !produtoAtual;

            // Chama o método para ativar/inativar o produto
            bool sucesso = produtosServico.AtivaInativaProduto(_produtoId, novoEstado);

            if (sucesso)
            { 
                string mensagem = novoEstado
                    ? "Produto ativado com sucesso!"
                    : "Produto inativado com sucesso!";

                new FormMensagem("Sucesso", mensagem).ShowDialog();
                Close();
            }
            else
            {
                new FormMensagem("Erro", "Falha ao alterar o status do produto.").ShowDialog();
            }
        }
    }
}
