using SistemaERP.RJControls;

namespace SistemaERP.Apresentacao;

partial class FormLogin
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
        if (disposing)
        {
            // Verifica se os componentes não são nulos e os libera
            if (components != null)
            {
                components.Dispose();
            }
        }
        // Chama o método Dispose da classe base
        try
        {
            base.Dispose(disposing);
        }
        catch (Exception)
        {
            // Ignora
        }
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
        pnLogin = new Panel();
        label1 = new Label();
        pbLogo = new PictureBox();
        lblEsqueciSenha = new Label();
        pnImagemLogin = new Panel();
        pbImagemLogin = new PictureBox();
        txtUsuario = new RJTextBox();
        txtSenha = new RJTextBox();
        btnSair = new RJButton();
        btnOlho = new FontAwesome.Sharp.IconButton();
        btnEntrar = new RJButton();
        pnLogin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
        pnImagemLogin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pbImagemLogin).BeginInit();
        SuspendLayout();
        // 
        // pnLogin
        // 
        pnLogin.Controls.Add(label1);
        pnLogin.Controls.Add(pbLogo);
        pnLogin.Controls.Add(lblEsqueciSenha);
        pnLogin.Controls.Add(pnImagemLogin);
        pnLogin.Controls.Add(txtUsuario);
        pnLogin.Controls.Add(txtSenha);
        pnLogin.Controls.Add(btnSair);
        pnLogin.Controls.Add(btnOlho);
        pnLogin.Controls.Add(btnEntrar);
        pnLogin.Dock = DockStyle.Fill;
        pnLogin.Location = new Point(2, 2);
        pnLogin.Name = "pnLogin";
        pnLogin.Size = new Size(1004, 725);
        pnLogin.TabIndex = 18;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display Light", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(637, 136);
        label1.Name = "label1";
        label1.Size = new Size(241, 46);
        label1.TabIndex = 28;
        label1.Text = "Seja Bem-Vindo";
        // 
        // pbLogo
        // 
        pbLogo.Anchor = AnchorStyles.None;
        pbLogo.Image = Properties.Resources.LogoTransparenteComVerde;
        pbLogo.Location = new Point(635, 40);
        pbLogo.Name = "pbLogo";
        pbLogo.Size = new Size(247, 93);
        pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
        pbLogo.TabIndex = 27;
        pbLogo.TabStop = false;
        // 
        // lblEsqueciSenha
        // 
        lblEsqueciSenha.Anchor = AnchorStyles.None;
        lblEsqueciSenha.AutoSize = true;
        lblEsqueciSenha.Font = new Font("Segoe UI Variable Small Semilig", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblEsqueciSenha.Location = new Point(632, 623);
        lblEsqueciSenha.Name = "lblEsqueciSenha";
        lblEsqueciSenha.Size = new Size(177, 24);
        lblEsqueciSenha.TabIndex = 26;
        lblEsqueciSenha.Text = "Esqueci minha senha";
        lblEsqueciSenha.Click += lblEsqueciSenha_Click;
        // 
        // pnImagemLogin
        // 
        pnImagemLogin.Controls.Add(pbImagemLogin);
        pnImagemLogin.Dock = DockStyle.Left;
        pnImagemLogin.Location = new Point(0, 0);
        pnImagemLogin.Name = "pnImagemLogin";
        pnImagemLogin.Size = new Size(532, 725);
        pnImagemLogin.TabIndex = 25;
        // 
        // pbImagemLogin
        // 
        pbImagemLogin.Dock = DockStyle.Fill;
        pbImagemLogin.Image = (Image)resources.GetObject("pbImagemLogin.Image");
        pbImagemLogin.Location = new Point(0, 0);
        pbImagemLogin.Name = "pbImagemLogin";
        pbImagemLogin.Size = new Size(532, 725);
        pbImagemLogin.SizeMode = PictureBoxSizeMode.StretchImage;
        pbImagemLogin.TabIndex = 24;
        pbImagemLogin.TabStop = false;
        // 
        // txtUsuario
        // 
        txtUsuario.Anchor = AnchorStyles.None;
        txtUsuario.BackColor = Color.FromArgb(2, 89, 89);
        txtUsuario.BorderColor = Color.Empty;
        txtUsuario.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtUsuario.BorderRadius = 20;
        txtUsuario.BorderSize = 2;
        txtUsuario.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtUsuario.ForeColor = Color.White;
        txtUsuario.Location = new Point(632, 393);
        txtUsuario.Multiline = false;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Padding = new Padding(10, 7, 10, 7);
        txtUsuario.PasswordChar = false;
        txtUsuario.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtUsuario.PlaceholderText = "Usuário";
        txtUsuario.SelectionStart = 0;
        txtUsuario.Size = new Size(250, 41);
        txtUsuario.TabIndex = 1;
        txtUsuario.Texts = "";
        txtUsuario.UnderlinedStyle = false;
        txtUsuario.KeyDown += txtUsuario_KeyDown;
        // 
        // txtSenha
        // 
        txtSenha.Anchor = AnchorStyles.None;
        txtSenha.BackColor = Color.FromArgb(2, 89, 89);
        txtSenha.BorderColor = Color.Empty;
        txtSenha.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtSenha.BorderRadius = 20;
        txtSenha.BorderSize = 2;
        txtSenha.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtSenha.ForeColor = Color.White;
        txtSenha.Location = new Point(632, 454);
        txtSenha.Multiline = false;
        txtSenha.Name = "txtSenha";
        txtSenha.Padding = new Padding(10, 7, 10, 7);
        txtSenha.PasswordChar = true;
        txtSenha.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtSenha.PlaceholderText = "Senha";
        txtSenha.SelectionStart = 0;
        txtSenha.Size = new Size(250, 41);
        txtSenha.TabIndex = 2;
        txtSenha.Texts = "";
        txtSenha.UnderlinedStyle = false;
        txtSenha.KeyDown += txtSenha_KeyDown;
        // 
        // btnSair
        // 
        btnSair.Anchor = AnchorStyles.None;
        btnSair.BackColor = Color.FromArgb(2, 89, 89);
        btnSair.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnSair.BorderColor = Color.Empty;
        btnSair.BorderRadius = 20;
        btnSair.BorderSize = 0;
        btnSair.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSair.FlatStyle = FlatStyle.Flat;
        btnSair.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnSair.ForeColor = Color.White;
        btnSair.Location = new Point(760, 515);
        btnSair.Name = "btnSair";
        btnSair.Size = new Size(122, 41);
        btnSair.TabIndex = 4;
        btnSair.Text = "Sair";
        btnSair.TextColor = Color.White;
        btnSair.UseVisualStyleBackColor = false;
        btnSair.Click += btnSair_Click;
        // 
        // btnOlho
        // 
        btnOlho.Anchor = AnchorStyles.None;
        btnOlho.FlatAppearance.BorderSize = 0;
        btnOlho.FlatStyle = FlatStyle.Flat;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
        btnOlho.IconColor = Color.FromArgb(2, 89, 89);
        btnOlho.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnOlho.IconSize = 32;
        btnOlho.Location = new Point(888, 459);
        btnOlho.Name = "btnOlho";
        btnOlho.Size = new Size(38, 36);
        btnOlho.TabIndex = 21;
        btnOlho.UseVisualStyleBackColor = false;
        btnOlho.MouseDown += btnOlho_MouseDown;
        btnOlho.MouseUp += btnOlho_MouseUp;
        // 
        // btnEntrar
        // 
        btnEntrar.Anchor = AnchorStyles.None;
        btnEntrar.BackColor = Color.FromArgb(2, 89, 89);
        btnEntrar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnEntrar.BorderColor = Color.Empty;
        btnEntrar.BorderRadius = 20;
        btnEntrar.BorderSize = 0;
        btnEntrar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnEntrar.FlatStyle = FlatStyle.Flat;
        btnEntrar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEntrar.ForeColor = Color.White;
        btnEntrar.Location = new Point(632, 515);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(122, 41);
        btnEntrar.TabIndex = 3;
        btnEntrar.Text = "Entrar";
        btnEntrar.TextColor = Color.White;
        btnEntrar.UseVisualStyleBackColor = false;
        btnEntrar.Click += btnEntrar_Click;
        // 
        // FormLogin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1008, 729);
        Controls.Add(pnLogin);
        MinimumSize = new Size(1024, 768);
        Name = "FormLogin";
        SizeGripStyle = SizeGripStyle.Show;
        StartPosition = FormStartPosition.CenterParent;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Text = "PasiWare";
        WindowState = FormWindowState.Maximized;
        Load += FormLogin_Load;
        pnLogin.ResumeLayout(false);
        pnLogin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
        pnImagemLogin.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pbImagemLogin).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnLogin;
    private RJTextBox txtUsuario;
    private RJTextBox txtSenha;
    private RJButton btnSair;
    private FontAwesome.Sharp.IconButton btnOlho;
    private RJButton btnEntrar;
    private PictureBox pbImagemLogin;
    private Panel pnImagemLogin;
    private Label lblEsqueciSenha;
    private Label label1;
    private PictureBox pbLogo;
}