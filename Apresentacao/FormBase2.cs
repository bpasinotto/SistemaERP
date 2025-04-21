using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using SistemaERP.RJControls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Controls;

namespace SistemaERP.Apresentacao;
public class FormBase2 : Form
{
    public FormBase2()
    {
        this.Load += FormBase_Load;
    }

    private void FormBase_Load(object? sender, EventArgs e)
    {
        // Carregar o tema salvo
        string temaSalvo = Properties.Settings.Default.Tema;
        if (!string.IsNullOrEmpty(temaSalvo))
        {
            AplicaTema(temaSalvo);
        }
        else
        {
            // Aplicar um tema padrão caso não haja tema salvo
            AplicaTema("Claro");
        }
    }

    internal void AplicaTema(string theme)
    {
        if (theme == "Claro")
        {
            this.BackColor = Color.White;
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                panel.BackColor = Color.White;
                panel.ForeColor = Color.Black;
            }

            foreach (RJTextBox rJTextBox in this.Controls.OfType<RJTextBox>())
            {
                rJTextBox.BackColor = Color.FromArgb(2, 89, 89);
                rJTextBox.ForeColor = Color.White;
            }

        }
        else if (theme == "Escuro")
        {
            //ALtera cor de fundo e cor da letra
            this.BackColor = Color.FromArgb(44, 44, 44);
            this.ForeColor = Color.White;
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                panel.BackColor = Color.FromArgb(44, 44, 44);
                panel.ForeColor = Color.White;
            }

            //Altera a cor do pnTopo do FormPrincipal
            if (this.Name == "FormPrincipal")
            {
                Panel pnTopo = (Panel)this.Controls.Find("pnTopo", true)[0];
                pnTopo.BackColor = Color.FromArgb(32, 32, 32);
            }

            foreach (RJTextBox rJTextBox in this.Controls.OfType<RJTextBox>())
            {
                rJTextBox.BackColor = Color.FromArgb(2, 89, 89);
                rJTextBox.ForeColor = Color.White;
            }

            foreach (IconButton button in this.Controls.OfType<IconButton>())
            {
                button.BackColor = Color.FromArgb(44, 44, 44);
                button.IconColor = Color.White;
            }
                       

        }
    }
}
