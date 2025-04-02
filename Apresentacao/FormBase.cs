using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using SistemaERP.RJControls;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Controls;

namespace SistemaERP.Apresentacao;
public class FormBase : SfForm
{
    public FormBase()
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
            //Sets the back color of the client area.
            this.Style.BackColor = Color.FromArgb(32, 32, 32);

            this.AllowRoundedCorners = true;

            //Customize the shadow for active state
            this.Style.ShadowOpacity = 0;

            //Customize the shadow for inactive state
            this.Style.InactiveShadowOpacity = 0;

            //Altura da barra de título
            this.Style.TitleBar.Height = 30;

            //Sets the back color and fore color of the title bar.
            this.Style.TitleBar.BackColor = Color.FromArgb(32, 32, 32);
            this.Style.TitleBar.ForeColor = Color.White;

            //Sets the fore color of the title bar buttons
            this.Style.TitleBar.CloseButtonForeColor = Color.White;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.White;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.White;

            //Sets the hover state back color of the title bar buttons
            this.Style.TitleBar.CloseButtonHoverBackColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonHoverBackColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonHoverBackColor = Color.DarkGray;

            //Sets the pressed state back color of the title bar buttons
            this.Style.TitleBar.CloseButtonPressedBackColor = Color.Gray;
            this.Style.TitleBar.MaximizeButtonPressedBackColor = Color.Gray;
            this.Style.TitleBar.MinimizeButtonPressedBackColor = Color.Gray;

            this.Style.Border = new Pen(Color.FromArgb(32, 32, 32), 5);
            this.Style.InactiveBorder = new Pen(Color.Gray, 5);

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
