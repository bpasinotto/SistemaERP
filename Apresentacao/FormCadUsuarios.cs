using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao;
public partial class FormCadUsuarios : BaseForm
{

    public FormCadUsuarios()
    {
        InitializeComponent();

        lblEmailInvalido.Visible = lblSenhaInvalida.Visible = lblUsuarioInvalido.Visible = false;
    }

    private void FormCadUsuarios_Load(object sender, EventArgs e)
    {

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
        if (!lblUsuarioInvalido.Visible && !lblEmailInvalido.Visible && !lblSenhaInvalida.Visible && !txtUsuario.Texts.IsNullOrEmpty() && !txtEmail.Texts.IsNullOrEmpty() && !txtSenha.Texts.IsNullOrEmpty())
        {
            var sucesso = new UsuariosServico().InsereUsuario(txtUsuario.Texts, txtEmail.Texts, txtSenha.Texts);
            var mensagem = new FormMensagem(sucesso ? "Sucesso" : "Falha", sucesso ? "Usuário cadastrado com sucesso." : "Falha no cadastro do usuário.");
            mensagem.ShowDialog();

            if (sucesso) LimparCampos();
        }
    }

    private void LimparCampos()
    {
        txtUsuario.Texts = string.Empty;
        txtEmail.Texts = string.Empty;
        txtSenha.Texts = string.Empty;
        txtUsuario.Focus();
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


    private void txtSenha_KeyDown(object sender, KeyEventArgs e)
    {
        //chama o metodo salvar
        if (e.KeyCode == Keys.Enter)
        {
            btnSalvar_Click(sender, EventArgs.Empty); // Passa EventArgs.Empty, que é compatível
        }
    }

    private void txtUsuario__TextChanged(object sender, EventArgs e)
    {
        if (txtUsuario.Texts.Length > 0)
        {
            // chama a função de validação de nome
            lblUsuarioInvalido.Visible = !new UsuariosServico().ValidarNome(txtUsuario.Texts);
        }
        else
        {
            lblUsuarioInvalido.Visible = false;
        }
    }

    private void txtEmail__TextChanged(object sender, EventArgs e)
    {
        if (txtEmail.Texts.Length > 0)
        {
            // Validação de email
            lblEmailInvalido.Visible = !new UsuariosServico().ValidarEmail(txtEmail.Texts);
        }
        else
        {
            lblEmailInvalido.Visible = false;
        }
    }

    private void txtSenha__TextChanged(object sender, EventArgs e)
    {
        if (txtSenha.Texts.Length > 0)
        {
            // Chama a função de validação de senha
            lblSenhaInvalida.Visible = !new UsuariosServico().ValidarSenha(txtSenha.Texts);
        }
        else
        {
            lblSenhaInvalida.Visible = false;
        }
    }

   
}
