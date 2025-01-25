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
        FormUsuarios formUsuarios = new FormUsuarios();
        formUsuarios.ShowDialog();
    }
}
