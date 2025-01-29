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
        UsuariosServico usuariosServico = new UsuariosServico();
        var resposta = usuariosServico.InsereUsuario(txtUsuario.Texts, txtEmail.Texts, txtSenha.Texts);
        MessageBox.Show(resposta);
    }
}
