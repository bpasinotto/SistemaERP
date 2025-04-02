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

namespace SistemaERP.Apresentacao;
public partial class FormClientes : FormBase2
{
    private DataTable dt;

    public FormClientes()
    {
        InitializeComponent();
    }

    private void FormClientes_Load(object sender, EventArgs e)
    {
        PreencheGrid();
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
}
