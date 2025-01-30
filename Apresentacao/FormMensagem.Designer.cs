namespace SistemaERP;

partial class FormMensagem
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
        lblMensagem = new Label();
        pnTopo = new Panel();
        pnBaixo = new Panel();
        btnOK = new RJControls.RJButton();
        pnTopo.SuspendLayout();
        pnBaixo.SuspendLayout();
        SuspendLayout();
        // 
        // lblMensagem
        // 
        lblMensagem.Font = new Font("Segoe UI Variable Display", 14.25F);
        lblMensagem.Location = new Point(0, 34);
        lblMensagem.Name = "lblMensagem";
        lblMensagem.Size = new Size(600, 30);
        lblMensagem.TabIndex = 0;
        lblMensagem.Text = "Mensagem aqui";
        lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnTopo
        // 
        pnTopo.Controls.Add(lblMensagem);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(0, 0);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(600, 100);
        pnTopo.TabIndex = 1;
        // 
        // pnBaixo
        // 
        pnBaixo.Controls.Add(btnOK);
        pnBaixo.Dock = DockStyle.Bottom;
        pnBaixo.Location = new Point(0, 75);
        pnBaixo.Name = "pnBaixo";
        pnBaixo.Size = new Size(600, 100);
        pnBaixo.TabIndex = 2;
        // 
        // btnOK
        // 
        btnOK.Anchor = AnchorStyles.None;
        btnOK.BackColor = Color.FromArgb(2, 89, 89);
        btnOK.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnOK.BorderColor = Color.Empty;
        btnOK.BorderRadius = 20;
        btnOK.BorderSize = 0;
        btnOK.FlatAppearance.BorderColor = Color.DarkBlue;
        btnOK.FlatStyle = FlatStyle.Flat;
        btnOK.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnOK.ForeColor = Color.White;
        btnOK.Location = new Point(239, 30);
        btnOK.Name = "btnOK";
        btnOK.Size = new Size(122, 41);
        btnOK.TabIndex = 19;
        btnOK.Text = "OK";
        btnOK.TextColor = Color.White;
        btnOK.UseVisualStyleBackColor = false;
        btnOK.Click += btnOK_Click;
        // 
        // FormMensagem
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(600, 175);
        ControlBox = false;
        Controls.Add(pnBaixo);
        Controls.Add(pnTopo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Name = "FormMensagem";
        StartPosition = FormStartPosition.CenterParent;
        Text = "FormMensagem";
        pnTopo.ResumeLayout(false);
        pnBaixo.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Label lblMensagem;
    private Panel pnTopo;
    private Panel pnBaixo;
    private RJControls.RJButton btnOK;
}