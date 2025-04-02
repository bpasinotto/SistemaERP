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
    public FormMensagem(string Titulo, string Mensagem)
    {
        InitializeComponent();
        Text = Titulo;
        lblMensagem.Text = Mensagem;
        // Som de alerta
        System.Media.SystemSounds.Beep.Play();

    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        Close();
    }
        
}
