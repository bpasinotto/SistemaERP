using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaERP.Apresentacao;
public partial class FormLogin : Form
{
    public FormLogin()
    {
        InitializeComponent();
    }

    private void FormClientes_Load(object sender, EventArgs e)
    {

    }

    private void rjButton1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(txtUsuario.Texts);
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void btnOlho_MouseDown(object sender, MouseEventArgs e)
    {
        txtSenha.PasswordChar = false;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.Eye;
        ;
    }

    private void btnOlho_MouseUp(object sender, MouseEventArgs e)
    {
        txtSenha.PasswordChar = true;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
    }

    private void btnSair_Click_1(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void lblEsqueciSenha_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Esqueci minha senha");
    }

    private void btnEntrar_Click(object sender, EventArgs e)
    {
        MessageBox.Show( txtUsuario.Texts + " entrou");
    }
}
