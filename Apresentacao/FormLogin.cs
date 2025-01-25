using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using SistemaERP.Negocio;
using Syncfusion.Windows.Forms.Diagram;

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
        this.Close();
    }

    private void lblEsqueciSenha_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Esqueci minha senha");
    }

    private void btnEntrar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsuario.Texts) || string.IsNullOrWhiteSpace(txtSenha.Texts))
        {
            MessageBox.Show("Preencha Usuário e Senha");
        }
        else
        {
            UsuariosServico usuario = new UsuariosServico();
            var resultado = usuario.Autenticar(txtUsuario.Texts, txtSenha.Texts);

            if (resultado)
            {
                MessageBox.Show("Login efetuado com sucesso");
                this.Hide();
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha inválidos");
            }
        }


    }

    private void txtSenha_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnEntrar_Click(sender, EventArgs.Empty); // Passa EventArgs.Empty, que é compatível
        }
    }

    private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
    {

    }



    //public bool AbrirFormPincipal(bool resultado)
    //{
    //    if (resultado)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

}
