using System.Data;
using System.Text;
using SistemaERP.Negocio;
using Syncfusion.WinForms.DataGrid.Events;

namespace SistemaERP.Apresentacao
{
    public partial class FormVendas : FormBase2
    {
        private DataTable dt = new();
        private DateTime? _dataInicioFiltro;
        private DateTime? _dataFimFiltro;

        public FormVendas()
        {
            InitializeComponent();
            dgVendas.AutoGeneratingColumn += DgVendas_AutoGeneratingColumn;
        }

        private void FormVendas_Load(object sender, EventArgs e)
        {
            sfDateTimeEdit1.Value = DateTime.Today;
            sfDateTimeEdit2.Value = DateTime.Today;

            string temaSalvo = Properties.Settings.Default.Tema;
            if (!string.IsNullOrEmpty(temaSalvo))
            {
                MudaCorGrid(temaSalvo);
            }

            PreencheGrid();
        }

        private void DgVendas_AutoGeneratingColumn(object? sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column == null)
                return;

            switch (e.Column.MappingName)
            {
                case "Id":
                    e.Column.HeaderText = "Id";
                    break;
                case "Cliente":
                    e.Column.HeaderText = "Cliente";
                    break;
                case "Vendedor":
                    e.Column.HeaderText = "Vendedor";
                    break;
                case "DataVenda":
                    e.Column.HeaderText = "Data da Venda";
                    e.Column.Format = "dd/MM/yyyy HH:mm";
                    break;
                case "ValorTotal":
                    e.Column.HeaderText = "Valor Total";
                    e.Column.Format = "C2";
                    break;
                case "Situacao":
                    e.Column.HeaderText = "Situação";
                    break;
                case "Observacao":
                    e.Column.HeaderText = "Observação";
                    break;
            }
        }

        internal void MudaCorGrid(string tema)
        {
            if (tema == "Escuro")
            {
                dgVendas.BackColor = Color.FromArgb(44, 44, 44);
                dgVendas.Style.CellStyle.BackColor = Color.FromArgb(44, 44, 44);
                dgVendas.Style.CellStyle.TextColor = Color.White;
                dgVendas.Style.HeaderStyle.BackColor = Color.LightGray;
                dgVendas.Style.CurrentCellStyle.BackColor = Color.LightGray;
                dgVendas.Style.SelectionStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgVendas.BackColor = Color.White;
                dgVendas.Style.CellStyle.BackColor = Color.White;
                dgVendas.Style.CellStyle.TextColor = Color.FromArgb(44, 44, 44);
                dgVendas.Style.HeaderStyle.BackColor = Color.LightGray;
                dgVendas.Style.CurrentCellStyle.BackColor = Color.LightGray;
                dgVendas.Style.SelectionStyle.BackColor = Color.LightGray;
            }
        }

        private void PreencheGrid()
        {
            VendasServico vendasServico = new VendasServico();
            dt = vendasServico.RetornaTodasVendas(_dataInicioFiltro, _dataFimFiltro) ?? new DataTable();

            AplicarFiltroPesquisa();
        }

        private void btnConsultar_Click(object? sender, EventArgs e)
        {
            if (!sfDateTimeEdit1.Value.HasValue || !sfDateTimeEdit2.Value.HasValue)
            {
                new FormMensagem("Atenção", "Selecione a data inicial e a data final para consultar.").ShowDialog();
                return;
            }

            DateTime dataInicio = sfDateTimeEdit1.Value.Value.Date;
            DateTime dataFim = sfDateTimeEdit2.Value.Value.Date;

            if (dataInicio > dataFim)
            {
                new FormMensagem("Atenção", "A data inicial não pode ser posterior à data final.").ShowDialog();
                return;
            }

            _dataInicioFiltro = dataInicio;
            _dataFimFiltro = dataFim;

            PreencheGrid();
        }

        private void txtPesquisa__TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltroPesquisa();
        }

        private void AplicarFiltroPesquisa()
        {
            if (dt == null || dt.Columns.Count == 0)
            {
                dgVendas.DataSource = dt;
                return;
            }

            string filtro = txtPesquisa.Texts.Trim();
            if (string.IsNullOrEmpty(filtro))
            {
                dt.DefaultView.RowFilter = string.Empty;
                dgVendas.DataSource = dt;
                return;
            }

            string filtroEscapado = EscaparValorRowFilter(filtro);
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Join(" OR ", dt.Columns.Cast<DataColumn>()
                .Select(c => $"CONVERT([{c.ColumnName}], System.String) LIKE '%{filtroEscapado}%'"));
            dgVendas.DataSource = dv.ToTable();
        }

        private static string EscaparValorRowFilter(string valor)
        {
            var sb = new StringBuilder(valor.Length);
            foreach (char c in valor)
            {
                switch (c)
                {
                    case '[':
                        sb.Append("[[]");
                        break;
                    case ']':
                        sb.Append("[]]");
                        break;
                    case '*':
                        sb.Append("[*]");
                        break;
                    case '%':
                        sb.Append("[%]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using FormCadVendas formCadVendas = new FormCadVendas();

            string temaSalvo = Properties.Settings.Default.Tema;
            if (!string.IsNullOrEmpty(temaSalvo))
            {
                formCadVendas.AplicaTema(temaSalvo);
            }

            if (formCadVendas.ShowDialog() == DialogResult.OK)
            {
                PreencheGrid();
            }
        }

        private void btnEditar_Click(object? sender, EventArgs e)
        {
            if (dgVendas.SelectedItems.Count > 0)
            {
                try
                {
                    var linhaSelecionada = dgVendas.SelectedItems[0];
                    if (linhaSelecionada is DataRowView rowView)
                    {
                        int idVenda = Convert.ToInt32(rowView["Id"]);

                        using FormCadVendas formVisualizarVenda = new FormCadVendas(idVenda);

                        string temaSalvo = Properties.Settings.Default.Tema;
                        if (!string.IsNullOrEmpty(temaSalvo))
                        {
                            formVisualizarVenda.AplicaTema(temaSalvo);
                        }

                        formVisualizarVenda.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    new FormMensagem("Erro", $"Erro ao abrir os detalhes da venda: {ex.Message}").ShowDialog();
                }
            }
            else
            {
                new FormMensagem("Atenção", "Selecione uma venda para visualizar.").ShowDialog();
            }
        }
    }
}
