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
public partial class FormPrincipal : BaseForm
{
    FormUsuarios formUsuarios = new FormUsuarios();
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
        comboBoxThemes.Items.Add("Claro");
        comboBoxThemes.Items.Add("Escuro");
        //comboBoxThemes.SelectedIndexChanged += ComboBoxThemes_SelectedIndexChanged;

        // Carregar o tema salvo
        string savedTheme = Properties.Settings.Default.Theme;
        if (!string.IsNullOrEmpty(savedTheme))
        {
            comboBoxThemes.SelectedItem = savedTheme;
        }
    }

    internal void ComboBoxThemes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedTheme = comboBoxThemes.SelectedItem.ToString();
        ApplyTheme(selectedTheme);

        // Salvar o tema selecionado
        Properties.Settings.Default.Theme = selectedTheme;
        Properties.Settings.Default.Save();

        //Atuliza o tema em todos os Forms
        foreach (Form form in Application.OpenForms)
        {
            if (form is BaseForm)
            {
                ((BaseForm)form).ApplyTheme(selectedTheme);                
            }
        }

        formUsuarios.MudaCorGrid(selectedTheme);
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
        FormInicio formInicio = new FormInicio();
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
        btnVender.ForeColor = Color.Black;
        btnConsultaVendas.ForeColor = Color.Black;
        btnEstoque.ForeColor = Color.Black;
        btnUsuarios.ForeColor = Color.Black;

        //Define a cor de todos os botões como LightGray
        btnInicio.BackColor = Color.LightGray;
        btnProdutos.BackColor = Color.LightGray;
        btnClientes.BackColor = Color.LightGray;
        btnVender.BackColor = Color.LightGray;
        btnConsultaVendas.BackColor = Color.LightGray;
        btnEstoque.BackColor = Color.LightGray;
        btnUsuarios.BackColor = Color.LightGray;
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

        FormClientes formClientes = new FormClientes();
        formClientes.TopLevel = false;
        pnMeio.Controls.Add(formClientes);
        formClientes.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formClientes.Dock = DockStyle.Fill;
    }

    

}
