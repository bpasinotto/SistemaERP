namespace SistemaERP.Apresentacao;

partial class FormInicio
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
        bpLogo = new PictureBox();
        ((System.ComponentModel.ISupportInitialize)bpLogo).BeginInit();
        SuspendLayout();
        // 
        // bpLogo
        // 
        bpLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        bpLogo.Image = Properties.Resources.LogoTransparenteComVerde;
        bpLogo.Location = new Point(776, 583);
        bpLogo.Name = "bpLogo";
        bpLogo.Size = new Size(209, 68);
        bpLogo.SizeMode = PictureBoxSizeMode.Zoom;
        bpLogo.TabIndex = 1;
        bpLogo.TabStop = false;
        // 
        // FormInicio
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1024, 768);
        Controls.Add(bpLogo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormInicio";
        StartPosition = FormStartPosition.Manual;
        Style.BackColor = Color.WhiteSmoke;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Text = "FormInicio";
        ((System.ComponentModel.ISupportInitialize)bpLogo).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox bpLogo;
}