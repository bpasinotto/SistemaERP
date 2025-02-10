using Microsoft.IdentityModel.Tokens;
using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao;
public partial class FormAlteraUsuarios : BaseForm
{
    string Id = "";

    public FormAlteraUsuarios(List<string> lista)
    {
        InitializeComponent();

        Id = lista[0];
        txtUsuario.Texts = lista[1];
        txtEmail.Texts = lista[2];
        txtSenha.Texts = lista[3];
        cbInativar.Checked = !bool.Parse(lista[4]);

        lblEmailInvalido.Visible = lblSenhaInvalida.Visible = lblUsuarioInvalido.Visible = false;
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
            var sucesso = new UsuariosServico().AlterarUsuario(Id, txtUsuario.Texts, txtEmail.Texts, txtSenha.Texts, cbInativar.Checked);
            var mensagem = new FormMensagem(sucesso ? "Sucesso" : "Falha", sucesso ? "Usuário atualizado com sucesso." : "Falha na atualização do usuário.");
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
        cbInativar.Checked = false;
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
