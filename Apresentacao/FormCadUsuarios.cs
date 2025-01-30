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
public partial class FormCadUsuarios : Form
{
    public FormCadUsuarios()
    {
        InitializeComponent();
        lblEmailErro.Visible = false;
    }

    private void btnOlho_MouseDown(object sender, MouseEventArgs e)
    {
        txtSenha.PasswordChar = false;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.Eye;

    }

    private void btnOlho_MouseUp(object sender, MouseEventArgs e)
    {
        txtSenha.PasswordChar = true;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
    }

    private void btnVoltar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        if(lblEmailErro.Visible == false)
        {
            UsuariosServico usuariosServico = new UsuariosServico();
            var resposta = usuariosServico.InsereUsuario(txtUsuario.Texts, txtEmail.Texts, txtSenha.Texts);            

            FormMensagem mensagem = new FormMensagem("Sucesso", resposta);
            mensagem.ShowDialog();
        }       

    }

    private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtEmail.Focus();
        }
    }

    private void txtEmail_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtSenha.Focus();
        }
    }

    private void txtEmail__TextChanged(object sender, EventArgs e)
    {
        ValidaEmail();
    }

    private void ValidaEmail()
    {
        // Validação de email
        if (txtEmail.Texts.Contains('@') && txtEmail.Texts.Contains('.'))
        {
            lblEmailErro.Visible = false;
        }
        else
        {
            lblEmailErro.Visible = true;
        }
    }
}
