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
    public partial class FormFornecedores : FormBase2
    {
        private DataTable dt;

        public FormFornecedores()
        {
            InitializeComponent();
        }

        private void FormFornecedores_Load(object sender, EventArgs e)
        {
            PreencheGrid();
        }

        internal void MudaCorGrid(string tema)
        {
            if (tema == "Escuro")
            {
                dgFornecedores.BackColor = Color.FromArgb(44, 44, 44);
                dgFornecedores.Style.CellStyle.BackColor = Color.FromArgb(44, 44, 44);
                dgFornecedores.Style.CellStyle.TextColor = Color.White;
                dgFornecedores.Style.HeaderStyle.BackColor = Color.LightGray;
                dgFornecedores.Style.CurrentCellStyle.BackColor = Color.LightGray;
                dgFornecedores.Style.SelectionStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgFornecedores.BackColor = Color.White;
                dgFornecedores.Style.CellStyle.BackColor = Color.White;
                dgFornecedores.Style.CellStyle.TextColor = Color.FromArgb(44, 44, 44);
                dgFornecedores.Style.HeaderStyle.BackColor = Color.LightGray;
                dgFornecedores.Style.CurrentCellStyle.BackColor = Color.LightGray;
                dgFornecedores.Style.SelectionStyle.BackColor = Color.LightGray;
            }
        }

        private void PreencheGrid()
        {
            // Busca todos os fornecedores e atribui ao DataTable
            FornecedoresServico fornecedoresServico = new FornecedoresServico();
            dt = new DataTable();
            dt = fornecedoresServico.RetornaTodosFornecedores(cbInativos.Checked);

            dgFornecedores.DataSource = dt;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new FormCadFornecedores().ShowDialog();
            PreencheGrid();
        }

        private void cbInativos_CheckedChanged(object sender, EventArgs e)
        {
            PreencheGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var idFornecedor = 0;

            // Verifica se há alguma linha selecionada
            if (dgFornecedores.SelectedItems.Count > 0)
            {
                // Acessa o primeiro item selecionado
                var linhaSelecionada = dgFornecedores.SelectedItems[0];

                // Faz o cast para DataRow
                if (linhaSelecionada is DataRowView rowView)
                {
                    idFornecedor = Convert.ToInt32(rowView["Id"]); // Substitua "Id" pelo nome da coluna no seu DataTable                
                }

                FornecedoresServico fornecedoresServico = new FornecedoresServico();
                var dadosFornecedor = fornecedoresServico.BuscaFornecedorId(idFornecedor);

                // Abre o form de cadastro de fornecedor com os dados do fornecedor selecionado no dgFornecedores
                FormCadFornecedores formCadFornecedores = new FormCadFornecedores(dadosFornecedor);
                formCadFornecedores.ShowDialog();

                // Atualiza a lista            
                PreencheGrid();
            }
            else
            {
                FormMensagem mensagem = new FormMensagem("Atenção", "Selecione um fornecedor para editar.");
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
                dgFornecedores.DataSource = dv.ToTable();
            }
        }
    }
}
