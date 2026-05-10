using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Apresentacao;
public partial class FormPrincipal : FormBase
{
    FormUsuarios formUsuarios = new FormUsuarios();
    FormClientes formClientes = new FormClientes();
    FormFornecedores formFornecedores = new FormFornecedores();
    FormInicio formInicio = new FormInicio();
    FormProdutos formProdutos = new FormProdutos();
    FormVendas formVendas = new FormVendas();
    int Id = 0;

    public FormPrincipal()
    {
        InitializeComponent();
    }

    public FormPrincipal(int id, string usuarioLogado)
    {
        InitializeComponent();

        Id = id;
        lblUsuarioLogado.Text = "Usuário: " + usuarioLogado;
    }

    private void FormPrincipal_Load(object sender, EventArgs e)
    {
        //cbTema.Items.Add("Claro");
        //cbTema.Items.Add("Escuro");

        // Carregar o tema salvo
        string savedTheme = Properties.Settings.Default.Tema;
        if (!string.IsNullOrEmpty(savedTheme))
        {
            cbTema.SelectedItem = savedTheme;
        }
    }

    internal void cbTema_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedTheme = cbTema.SelectedItem.ToString();

        // Salvar o tema selecionado
        Properties.Settings.Default.Tema = selectedTheme;
        Properties.Settings.Default.Save();

        //Atualiza o tema em todos os Forms
        foreach (Form form in Application.OpenForms)
        {
            if (form is FormBase)
            {
                ((FormBase)form).AplicaTema(selectedTheme);
            }
            if (form is FormBase2)
            {
                ((FormBase2)form).AplicaTema(selectedTheme);
            }
        }

        //Atualiza a cor do grid dos Forms de acordo com o tema selecionado
        formUsuarios.MudaCorGrid(selectedTheme);
        formClientes.MudaCorGrid(selectedTheme);
        formFornecedores.MudaCorGrid(selectedTheme);
        formProdutos.MudaCorGrid(selectedTheme);
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {

        if (Id < 3)
        {
            //Limpa o pnMeio do FormPrincipal
            pnMeio.Controls.Clear();

            //Define a cor de todos os botões como LightGray
            BotoesCinza();

            //Define somente a cor do botão selecionado para verde
            btnUsuarios.BackColor = Color.FromArgb(2, 89, 89);
            //Define cor da letra para branco
            btnUsuarios.ForeColor = Color.White;

            formUsuarios.TopLevel = false;
            pnMeio.Controls.Add(formUsuarios);
            formUsuarios.Show();

            //Expande o FormIncio para ocupar todo o pnMeio
            formUsuarios.Dock = DockStyle.Fill;
        }
        else
        {
            new FormMensagem("Atenção", "Apenas o Administrador tem acesso a tela de Usuários.").ShowDialog();
        }


    }

    private void btnSair_Click(object sender, EventArgs e)
    {
        //Fecha tudo
        Application.Exit();
    }

    private void btnTrocarUsuario_Click(object sender, EventArgs e)
    {
        Hide();
        FormLogin formLogin = new FormLogin();
        formLogin.Show();
    }

    private void btnInicio_Click(object sender, EventArgs e)
    {
        //Abre o FormInicio dentro do pnMeio do FormPrincipal
        pnMeio.Controls.Clear();

        //Define a cor de todos os botões como LightGray
        BotoesCinza();

        //Define somente a cor do botão selecionado para verde
        btnInicio.BackColor = Color.FromArgb(2, 89, 89);
        //Define cor da letra para branco
        btnInicio.ForeColor = Color.White;

        //Abre o FormInicio dentro do pnMeio

        formInicio.TopLevel = false;
        pnMeio.Controls.Add(formInicio);
        formInicio.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formInicio.Dock = DockStyle.Fill;
    }

    private void BotoesCinza()
    {
        //Define a cor da letra de todos os botões como preto
        btnInicio.ForeColor = Color.Black;
        btnProdutos.ForeColor = Color.Black;
        btnClientes.ForeColor = Color.Black;
        btnVendas.ForeColor = Color.Black;
        btnEstoque.ForeColor = Color.Black;
        btnUsuarios.ForeColor = Color.Black;
        btnFornecedores.ForeColor = Color.Black;

        //Define a cor de todos os botões como LightGray
        btnInicio.BackColor = Color.LightGray;
        btnProdutos.BackColor = Color.LightGray;
        btnClientes.BackColor = Color.LightGray;
        btnVendas.BackColor = Color.LightGray;
        btnEstoque.BackColor = Color.LightGray;
        btnUsuarios.BackColor = Color.LightGray;
        btnFornecedores.BackColor = Color.LightGray;
    }

    private void lblUsuarioLogado_Click(object sender, EventArgs e)
    {

    }

    private void btnClientes_Click(object sender, EventArgs e)
    {
        //Limpa o pnMeio do FormPrincipal
        pnMeio.Controls.Clear();

        //Define a cor de todos os botões como LightGray
        BotoesCinza();

        //Define somente a cor do botão selecionado para verde
        btnClientes.BackColor = Color.FromArgb(2, 89, 89);
        //Define cor da letra para branco
        btnClientes.ForeColor = Color.White;

        // Remove a barra de título ao abrir do FormPrincipal
        formClientes.FormBorderStyle = FormBorderStyle.None;
        formClientes.ControlBox = false;

        formClientes.TopLevel = false;
        pnMeio.Controls.Add(formClientes);
        formClientes.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formClientes.Dock = DockStyle.Fill;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void btnFornecedores_Click(object sender, EventArgs e)
    {
        //Limpa o pnMeio do FormPrincipal
        pnMeio.Controls.Clear();

        //Define a cor de todos os botões como LightGray
        BotoesCinza();

        //Define somente a cor do botão selecionado para verde
        btnFornecedores.BackColor = Color.FromArgb(2, 89, 89);
        //Define cor da letra para branco
        btnFornecedores.ForeColor = Color.White;


        formFornecedores.TopLevel = false;
        pnMeio.Controls.Add(formFornecedores);
        formFornecedores.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formFornecedores.Dock = DockStyle.Fill;
    }

    private void btnProdutos_Click(object sender, EventArgs e)
    {
        //Limpa o pnMeio do FormPrincipal
        pnMeio.Controls.Clear();

        //Define a cor de todos os botões como LightGray
        BotoesCinza();

        //Define somente a cor do botão selecionado para verde
        btnProdutos.BackColor = Color.FromArgb(2, 89, 89);
        //Define cor da letra para branco
        btnProdutos.ForeColor = Color.White;


        formProdutos.TopLevel = false;
        pnMeio.Controls.Add(formProdutos);
        formProdutos.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formProdutos.Dock = DockStyle.Fill;
    }

    private void btnVendas_Click(object sender, EventArgs e)
    {
        //Limpa o pnMeio do FormPrincipal
        pnMeio.Controls.Clear();

        //Define a cor de todos os botões como LightGray
        BotoesCinza();

        //Define somente a cor do botão selecionado para verde
        btnVendas.BackColor = Color.FromArgb(2, 89, 89);
        //Define cor da letra para branco
        btnVendas.ForeColor = Color.White;


        formVendas.TopLevel = false;
        pnMeio.Controls.Add(formVendas);
        formVendas.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formVendas.Dock = DockStyle.Fill;
    }

    private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }
    
}
