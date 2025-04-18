using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao;
public partial class FormLogin : FormBase
{
    public FormLogin()
    {
        InitializeComponent();
    }

    private void FormLogin_Load(object sender, EventArgs e)
    {
        UsuariosServico usuariosServico = new UsuariosServico();
        var resultado = usuariosServico.ExisteAdmin();

        if (resultado == 1)
        {
            FormMensagem mensagem = new FormMensagem("Atenção", "Crie o usuário que irá administrar o sistema.");
            mensagem.ShowDialog();

            FormCadUsuarios formCadUsuarios = new FormCadUsuarios();
            formCadUsuarios.ShowDialog();
        }
    }

    private void btnSair_Click(object sender, EventArgs e)
    {
        Application.Exit();
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

    private void lblEsqueciSenha_Click(object sender, EventArgs e)
    {
        FormMensagem mensagem = new FormMensagem("Atenção", "Esqueci minha senha.");
        mensagem.ShowDialog();
    }

    private void btnEntrar_Click(object sender, EventArgs e)
    {
        UsuariosServico usuariosServico = new UsuariosServico();

        if (string.IsNullOrWhiteSpace(txtUsuario.Texts) || string.IsNullOrWhiteSpace(txtSenha.Texts))
        {
            FormMensagem mensagem = new FormMensagem("Atenção", "Preencha Usuário e Senha.");
            mensagem.ShowDialog();
        }
        else
        {
            var resultado = usuariosServico.AutenticaLogin(txtUsuario.Texts, txtSenha.Texts);

            if (resultado.ContainsKey("id"))
            {
                // Mostra a tela de carregamento
                using (var formCarregamento = new FormCarregamento())
                {
                    formCarregamento.Show();
                    formCarregamento.Refresh();

                    // Carrega a tela principal
                    Hide();
                    FormPrincipal formPrincipal = new FormPrincipal(int.Parse(resultado["id"]), txtUsuario.Texts);
                    LimparCampos();
                    formPrincipal.Show();
                                        
                    formCarregamento.Close();
                }
            }
            else
            {
                FormMensagem mensagem = new FormMensagem("Atenção", resultado["erro"]);
                mensagem.ShowDialog();
            }
        }
    }

    // Limpar os campos
    private void LimparCampos()
    {
        txtUsuario.Texts = string.Empty;
        txtSenha.Texts = string.Empty;
        txtUsuario.Focus();
    }

    private void txtSenha_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnEntrar_Click(sender, EventArgs.Empty); // Passa EventArgs.Empty, que é compatível
        }
    }

    private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtSenha.Focus();
        }
    }
}
