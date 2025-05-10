using System.Data;
using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao
{
    public partial class FormProdutos : FormBase2
    {
        private DataTable dt;

        public FormProdutos()
        {
            InitializeComponent();
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            PreencheGrid();
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
