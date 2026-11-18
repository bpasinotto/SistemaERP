using System.Data;
using SistemaERP.Negocio;
using SistemaERP.RJControls;

namespace SistemaERP.Apresentacao
{
    public partial class FormProdutos : FormBase2
    {
        private DataTable dt;
        private RJTextBox? txtCodProdutoRef;
        private bool isBuscaMode = false;

        public FormProdutos()
        {
            InitializeComponent();
            btnSelecionar.Visible = false;
        }

        // Construtor para modo busca
        public FormProdutos(RJTextBox txtCodProduto)
        {
            InitializeComponent();
            txtCodProdutoRef = txtCodProduto;
            isBuscaMode = true;
            btnSelecionar.Visible = true;
            cbInativos.Checked = false;
            cbInativos.Enabled = false;
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            if (isBuscaMode)
            {
                cbInativos.Checked = false;
                cbInativos.Enabled = false;
                btnSelecionar.Click += BtnSelecionar_Click;
            }

            PreencheGrid();
        }

        private void BtnSelecionar_Click(object? sender, EventArgs e)
        {
            if (cbInativos.Checked)
            {
                new FormMensagem("Atenção", "Não é permitido selecionar produtos inativos.").ShowDialog();
                return;
            }

            if (txtCodProdutoRef != null && dgProdutos.SelectedItems.Count > 0)
            {
                try
                {
                    var linhaSelecionada = dgProdutos.SelectedItems[0];

                    if (linhaSelecionada is DataRowView rowView)
                    {
                        int idProduto = Convert.ToInt32(rowView["Id"]);

                        var produto = new ProdutosServico().BuscaProdutoPorId(idProduto);
                        if (produto == null || !Convert.ToBoolean(produto["Ativo"]))
                        {
                            new FormMensagem("Atenção", "Não é permitido selecionar um produto inativo.").ShowDialog();
                            return;
                        }

                        txtCodProdutoRef.Texts = idProduto.ToString();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    FormMensagem mensagem = new FormMensagem("Erro", $"Erro ao selecionar produto: {ex.Message}");
                    mensagem.ShowDialog();
                }
            }
            else
            {
                FormMensagem mensagem = new FormMensagem("Atenção", "Selecione um produto para continuar.");
                mensagem.ShowDialog();
            }
        }

        internal void MudaCorGrid(string tema)
        {
            if (tema == "Escuro")
            {
                dgProdutos.BackColor = Color.FromArgb(44, 44, 44);
                dgProdutos.Style.CellStyle.BackColor = Color.FromArgb(44, 44, 44);
                dgProdutos.Style.CellStyle.TextColor = Color.White;
                dgProdutos.Style.HeaderStyle.BackColor = Color.LightGray;
                dgProdutos.Style.CurrentCellStyle.BackColor = Color.LightGray;
                dgProdutos.Style.SelectionStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgProdutos.BackColor = Color.White;
                dgProdutos.Style.CellStyle.BackColor = Color.White;
                dgProdutos.Style.CellStyle.TextColor = Color.FromArgb(44, 44, 44);
                dgProdutos.Style.HeaderStyle.BackColor = Color.LightGray;
                dgProdutos.Style.CurrentCellStyle.BackColor = Color.LightGray;
                dgProdutos.Style.SelectionStyle.BackColor = Color.LightGray;
            }
        }

        private void PreencheGrid()
        {
            // Instancia o serviço de produtos
            ProdutosServico produtosServico = new ProdutosServico();
            dt = new DataTable();
                       
            dt = produtosServico.RetornaTodosProdutos(cbInativos.Checked);

            // Define o DataTable como fonte de dados do DataGridView
            dgProdutos.DataSource = dt;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new FormCadProdutos().ShowDialog();
            PreencheGrid();
        }

        private void cbInativos_CheckedChanged(object sender, EventArgs e)
        {
            PreencheGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var idProduto = 0;

            // Verifica se há alguma linha selecionada
            if (dgProdutos.SelectedItems.Count > 0)
            {
                // Acessa o primeiro item selecionado
                var linhaSelecionada = dgProdutos.SelectedItems[0];

                // Faz o cast para DataRow
                if (linhaSelecionada is DataRowView rowView)
                {
                    idProduto = Convert.ToInt32(rowView["Id"]); // Substitua "Id" pelo nome da coluna no seu DataTable                
                }

                //ProdutosServico produtosServico = new ProdutosServico();
                //var dadosProduto = produtosServico.BuscaProdutoPorId(idProduto);

                //Abre o form de cadastro de usuário com os dados do usuário selecionado no dgUsuarios
                FormCadProdutos formCadProdutos = new FormCadProdutos(idProduto);
                formCadProdutos.ShowDialog();

                // Atualiza a lista            
                PreencheGrid();
            }
            else
            {
                FormMensagem mensagem = new FormMensagem("Atenção", "Selecione um produto para editar.");
                mensagem.ShowDialog();
            }
        }

        private void txtPesquisa__TextChanged(object sender, EventArgs e)
        {
            string filtro = txtPesquisa.Texts.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                PreencheGrid();
            }
            else
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Join(" OR ", dt.Columns.Cast<DataColumn>()
                    .Select(c => $"CONVERT([{c.ColumnName}], System.String) LIKE '%{filtro}%'"));
                dgProdutos.DataSource = dv.ToTable();
            }
        }
        
    }
}
