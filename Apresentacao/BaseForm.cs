using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using SistemaERP.RJControls;
using Syncfusion.WinForms.DataGrid;

namespace SistemaERP.Apresentacao;
public class BaseForm : Form
{
    public BaseForm()
    {
        this.Load += BaseForm_Load;
    }

    private void BaseForm_Load(object? sender, EventArgs e)
    {
        // Carregar o tema salvo
        string savedTheme = Properties.Settings.Default.Theme;
        if (!string.IsNullOrEmpty(savedTheme))
        {
            ApplyTheme(savedTheme);
        }
        else
        {
            // Aplicar um tema padrão caso não haja tema salvo
            ApplyTheme("Claro");
        }
    }

    internal void ApplyTheme(string theme)
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
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            foreach (Panel panel in this.Controls.OfType<Panel>())
            {
                panel.BackColor = Color.Black;
                panel.ForeColor = Color.White;
            }

            foreach (RJTextBox rJTextBox in this.Controls.OfType<RJTextBox>())
            {
                rJTextBox.BackColor = Color.FromArgb(2, 89, 89);
                rJTextBox.ForeColor = Color.White;
            }

            foreach (IconButton button in this.Controls.OfType<IconButton>())
            {
                button.BackColor = Color.Black;                
            }
                        

        }
    }
}
