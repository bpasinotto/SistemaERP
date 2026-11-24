using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaERP.Apresentacao;

namespace SistemaERP;
public partial class FormMensagem : FormBase
{
    private readonly bool _modoConfirmacao;

    public FormMensagem(string Titulo, string Mensagem)
    {
        InitializeComponent();
        Text = Titulo;
        lblMensagem.Text = Mensagem;
        btnNao.Visible = false;
        // Som de alerta
        System.Media.SystemSounds.Beep.Play();
    }

    public FormMensagem(string Titulo, string Mensagem, bool confirmacao) : this(Titulo, Mensagem)
    {
        _modoConfirmacao = confirmacao;

        if (_modoConfirmacao)
        {
            btnOK.Text = "Sim";
            btnOK.Location = new Point(168, 10);
            btnNao.Location = new Point(310, 10);
            btnNao.Visible = true;
        }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        DialogResult = _modoConfirmacao ? DialogResult.Yes : DialogResult.OK;
        Close();
    }

    private void btnNao_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.No;
        Close();
    }
}
