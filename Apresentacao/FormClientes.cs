using System.Data;
using SistemaERP.Negocio;
using SistemaERP.RJControls;

namespace SistemaERP.Apresentacao;
public partial class FormClientes : FormBase
{
    private DataTable dt;
    private RJTextBox txtCodClienteRef;
    private bool isBuscaMode = false;

    public FormClientes()
    {
        InitializeComponent();
        btnSelecionar.Visible = false; // Inicialmente invisível
    }

    // Construtor para modo busca
    public FormClientes(RJTextBox txtCodCliente)
    {
        InitializeComponent();
        txtCodClienteRef = txtCodCliente;
        isBuscaMode = true;
        btnSelecionar.Visible = true; // Visível apenas em modo busca
    }

    private void FormClientes_Load(object sender, EventArgs e)
    {
        PreencheGrid();

        // Registra o evento do botão apenas se for modo busca
        if (isBuscaMode)
        {
            btnSelecionar.Click += BtnSelecionar_Click;
        }
    }

    private void BtnSelecionar_Click(object sender, EventArgs e)
    {
        if (cbInativos.Checked)
        {
            new FormMensagem("Atenção", "Não é permitido selecionar um cliente inativo.").ShowDialog();
            return;
        }

        if (txtCodClienteRef != null && dgClientes.SelectedItems.Count > 0)
        {
            try
            {
                var linhaSelecionada = dgClientes.SelectedItems[0];

                if (linhaSelecionada is DataRowView rowView)
                {
                    int idCliente = Convert.ToInt32(rowView["Id"]);

                    var dadosCliente = new ClientesServico().BuscaClienteId(idCliente);
                    if (dadosCliente == null || dadosCliente.Count == 0 ||
                        (dadosCliente.Count > 14 && string.Equals(dadosCliente[14], "False", StringComparison.OrdinalIgnoreCase)))
                    {
                        new FormMensagem("Atenção", "Não é permitido selecionar um cliente inativo.").ShowDialog();
                        return;
                    }

                    // Insere o ID no txtCodCliente do FormCadVendas
                    txtCodClienteRef.Texts = idCliente.ToString();

                    // Fecha o FormClientes
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                FormMensagem mensagem = new FormMensagem("Erro", $"Erro ao selecionar cliente: {ex.Message}");
                mensagem.ShowDialog();
            }
        }
        else
        {
            FormMensagem mensagem = new FormMensagem("Atenção", "Selecione um cliente para continuar.");
            mensagem.ShowDialog();
        }
    }

    internal void MudaCorGrid(string tema)
    {
        if (tema == "Escuro")
        {
            dgClientes.BackColor = Color.FromArgb(44, 44, 44);
            dgClientes.Style.CellStyle.BackColor = Color.FromArgb(44, 44, 44);
            dgClientes.Style.CellStyle.TextColor = Color.White;
            dgClientes.Style.HeaderStyle.BackColor = Color.LightGray;
            dgClientes.Style.CurrentCellStyle.BackColor = Color.LightGray;
            dgClientes.Style.SelectionStyle.BackColor = Color.LightGray;
        }
        else
        {
            dgClientes.BackColor = Color.White;
            dgClientes.Style.CellStyle.BackColor = Color.White;
            dgClientes.Style.CellStyle.TextColor = Color.FromArgb(44, 44, 44);
            dgClientes.Style.HeaderStyle.BackColor = Color.LightGray;
            dgClientes.Style.CurrentCellStyle.BackColor = Color.LightGray;
            dgClientes.Style.SelectionStyle.BackColor = Color.LightGray;
        }
    }

    private void PreencheGrid()
    {
        // Busca todos os usuários e atribui ao DataTable
        ClientesServico clientesServico = new ClientesServico();
        dt = new DataTable();
        dt = clientesServico.RetornaTodosClientes(cbInativos.Checked);

        dgClientes.DataSource = dt;
    }

    private void btnNovo_Click(object sender, EventArgs e)
    {
        new FormCadClientes().ShowDialog();
        PreencheGrid();
    }

    private void cbInativos_CheckedChanged(object sender, EventArgs e)
    {
        PreencheGrid();
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        var idCliente = 0;

        // Verifica se há alguma linha selecionada
        if (dgClientes.SelectedItems.Count > 0)
        {
            // Acessa o primeiro item selecionado
            var linhaSelecionada = dgClientes.SelectedItems[0];

            // Faz o cast para DataRow
            if (linhaSelecionada is DataRowView rowView)
            {
                idCliente = Convert.ToInt32(rowView["Id"]); // Substitua "Id" pelo nome da coluna no seu DataTable                
            }

            ClientesServico clientesServico = new ClientesServico();
            var dadosCliente = clientesServico.BuscaClienteId(idCliente);

            //Abre o form de cadastro de usuário com os dados do usuário selecionado no dgUsuarios
            FormCadClientes formCadClientes = new FormCadClientes(dadosCliente);
            formCadClientes.ShowDialog();

            // Atualiza a lista            
            PreencheGrid();
        }
        else
        {
            FormMensagem mensagem = new FormMensagem("Atenção", "Selecione um cliente para editar.");
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
            dgClientes.DataSource = dv.ToTable();
        }
    }
}
