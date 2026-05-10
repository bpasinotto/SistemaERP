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

public partial class FormCadVendas : FormBase
{
    public FormCadVendas()
    {
        InitializeComponent();
        CarregarVendedores(); // Carrega os vendedores ao inicializar o formulário
    }

    private void CarregarVendedores()
    {
        try
        {
            var usuariosServico = new UsuariosServico();
            var usuarios = usuariosServico.RetornaTodosUsuarios(false);

            cbVendedor.DataSource = usuarios;
            cbVendedor.DisplayMember = "Nome"; // Ajuste conforme o nome da coluna que contém o nome do usuário
            cbVendedor.ValueMember = "Id";     // Ajuste conforme o nome da coluna que contém o ID do usuário
            cbVendedor.SelectedIndex = -1;     // Inicialmente sem seleção
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar vendedores: {ex.Message}", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void txtCodCliente__TextChanged(object sender, EventArgs e)
    {

    }

    private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Aceita apenas dígitos, backspace e delete
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
        {
            e.Handled = true;
        }
    }

    private void btnVoltar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void txtCodCliente_Leave(object sender, EventArgs e)
    {
        // Verifica se o texto digitado é um número e não está vazio
        if (!string.IsNullOrWhiteSpace(txtCodCliente.Texts) && int.TryParse(txtCodCliente.Texts, out int clienteId))
        {
            try
            {
                // Cria uma instância do serviço de clientes e busca o cliente pelo ID
                ClientesServico clientesServico = new ClientesServico();
                List<string> dadosCliente = clientesServico.BuscaClienteId(clienteId);

                // Se encontrou o cliente, atualiza a label com o nome (Razão Social) do cliente
                if (dadosCliente != null && dadosCliente.Count >= 3)
                {
                    // A razão social está na posição 2 da lista (índice 2)
                    lblNomeCliente.Text = dadosCliente[2];
                }
                else
                {
                    // Se não encontrou o cliente, limpa a label
                    lblNomeCliente.Text = "Cliente não encontrado";
                }
            }
            catch (Exception ex)
            {
                // Em caso de erro, exibe mensagem na label
                lblNomeCliente.Text = "Erro ao consultar cliente";
                // Poderia logar o erro aqui também
                // MessageBox.Show($"Erro ao consultar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            // Se não digitou um ID válido, limpa a label
            lblNomeCliente.Text = "Nome do Cliente";
        }
    }

    private void btnBuscaCliente_Click(object sender, EventArgs e)
    {
        FormClientes formClientesBusca = new FormClientes(txtCodCliente);
        // Ativa a barra de título e border quando aberto do FormCadVendas
        formClientesBusca.FormBorderStyle = FormBorderStyle.Sizable;
        formClientesBusca.ControlBox = true;

        // Aplica o tema atual ao novo formulário
        string temaSalvo = Properties.Settings.Default.Tema;
        if (!string.IsNullOrEmpty(temaSalvo))
        {
            formClientesBusca.AplicaTema(temaSalvo);
            formClientesBusca.MudaCorGrid(temaSalvo);
        }

        formClientesBusca.ShowDialog();

        // Dispara o evento Leave do txtCodCliente após fechar o FormClientes
        txtCodCliente_Leave(txtCodCliente, EventArgs.Empty);
    }
}
