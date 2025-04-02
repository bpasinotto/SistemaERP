namespace SistemaERP.Apresentacao;

partial class FormCarregamento
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new Label();
        pbLogo = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display Light", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(255, 306);
        label1.Name = "label1";
        label1.Size = new Size(207, 46);
        label1.TabIndex = 30;
        label1.Text = "Carregando...";
        // 
        // pbLogo
        // 
        pbLogo.Anchor = AnchorStyles.None;
        pbLogo.Image = Properties.Resources.LogoTransparenteComVerde;
        pbLogo.Location = new Point(232, 210);
        pbLogo.Name = "pbLogo";
        pbLogo.Size = new Size(247, 93);
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
        pbLogo.TabIndex = 29;
        pbLogo.TabStop = false;
        // 
        // FormCarregamento
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(709, 617);
        Controls.Add(label1);
        Controls.Add(pbLogo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormCarregamento";
        StartPosition = FormStartPosition.CenterScreen;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Text = "FormCarregamento";
        ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private PictureBox pbLogo;
}