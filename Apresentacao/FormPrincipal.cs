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
public partial class FormPrincipal : Form
{
    public FormPrincipal()
    {
        InitializeComponent();
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {
        //Limpa o pnMeio do FormPrincipal
        pnMeio.Controls.Clear();

        //Define a cor de todos os botões como LightGray
        BotoesCinza();

        //Define somente a cor do botão selecionado para verde
        btnUsuarios.BackColor = Color.FromArgb(2, 89, 89);
        //Define cor da letra para branco
        btnUsuarios.ForeColor = Color.White;

        FormUsuarios formUsuarios = new FormUsuarios();
        formUsuarios.TopLevel = false;
        pnMeio.Controls.Add(formUsuarios);
        formUsuarios.Show();

        //Expande o FormIncio para ocupar todo o pnMeio
        formUsuarios.Dock = DockStyle.Fill;
                
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnTrocarUsuario_Click(object sender, EventArgs e)
    {
        this.Hide();
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
}
