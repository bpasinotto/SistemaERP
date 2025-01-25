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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
        pnLogin = new Panel();
        label1 = new Label();
        pictureBox2 = new PictureBox();
        lblEsqueciSenha = new Label();
        pnImagemLogin = new Panel();
        pictureBox1 = new PictureBox();
        txtUsuario = new RJTextBox();
        txtSenha = new RJTextBox();
        btnSair = new RJButton();
        btnOlho = new FontAwesome.Sharp.IconButton();
        btnEntrar = new RJButton();
        pnLogin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        pnImagemLogin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pnLogin
        // 
        pnLogin.BackColor = Color.White;
        pnLogin.Controls.Add(label1);
        pnLogin.Controls.Add(pictureBox2);
        pnLogin.Controls.Add(lblEsqueciSenha);
        pnLogin.Controls.Add(pnImagemLogin);
        pnLogin.Controls.Add(txtUsuario);
        pnLogin.Controls.Add(txtSenha);
        pnLogin.Controls.Add(btnSair);
        pnLogin.Controls.Add(btnOlho);
        pnLogin.Controls.Add(btnEntrar);
        pnLogin.Dock = DockStyle.Fill;
        pnLogin.Location = new Point(0, 0);
        pnLogin.Name = "pnLogin";
        pnLogin.Size = new Size(1008, 729);
        pnLogin.TabIndex = 18;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display Light", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.DimGray;
        label1.Location = new Point(639, 138);
        label1.Name = "label1";
        label1.Size = new Size(241, 46);
        label1.TabIndex = 28;
        label1.Text = "Seja Bem-Vindo";
        // 
        // pictureBox2
        // 
        pictureBox2.Anchor = AnchorStyles.None;
        pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
        pictureBox2.Location = new Point(639, 67);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(250, 68);
        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox2.TabIndex = 27;
        pictureBox2.TabStop = false;
        // 
        // lblEsqueciSenha
        // 
        lblEsqueciSenha.Anchor = AnchorStyles.None;
        lblEsqueciSenha.AutoSize = true;
        lblEsqueciSenha.Font = new Font("Segoe UI Variable Small Semilig", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblEsqueciSenha.ForeColor = Color.DimGray;
        lblEsqueciSenha.Location = new Point(634, 625);
        lblEsqueciSenha.Name = "lblEsqueciSenha";
        lblEsqueciSenha.Size = new Size(177, 24);
        lblEsqueciSenha.TabIndex = 26;
        lblEsqueciSenha.Text = "Esqueci minha senha";
        lblEsqueciSenha.Click += lblEsqueciSenha_Click;
        // 
        // pnImagemLogin
        // 
        pnImagemLogin.Controls.Add(pictureBox1);
        pnImagemLogin.Dock = DockStyle.Left;
        pnImagemLogin.Location = new Point(0, 0);
        pnImagemLogin.Name = "pnImagemLogin";
        pnImagemLogin.Size = new Size(532, 729);
        pnImagemLogin.TabIndex = 25;
        // 
        // pictureBox1
        // 
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(0, 0);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(532, 729);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 24;
        pictureBox1.TabStop = false;
        // 
        // txtUsuario
        // 
        txtUsuario.Anchor = AnchorStyles.None;
        txtUsuario.BackColor = Color.FromArgb(60, 117, 125);
        txtUsuario.BorderColor = Color.Empty;
        txtUsuario.BorderFocusColor = Color.Black;
        txtUsuario.BorderRadius = 20;
        txtUsuario.BorderSize = 2;
        txtUsuario.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtUsuario.ForeColor = Color.LightGray;
        txtUsuario.Location = new Point(634, 395);
        txtUsuario.Multiline = false;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Padding = new Padding(10, 7, 10, 7);
        txtUsuario.PasswordChar = false;
        txtUsuario.PlaceholderColor = Color.DarkGray;
        txtUsuario.PlaceholderText = "Usuário";
        txtUsuario.Size = new Size(250, 41);
        txtUsuario.TabIndex = 19;
        txtUsuario.Texts = "";
        txtUsuario.UnderlinedStyle = false;
        // 
        // txtSenha
        // 
        txtSenha.Anchor = AnchorStyles.None;
        txtSenha.BackColor = Color.FromArgb(60, 117, 125);
        txtSenha.BorderColor = Color.Empty;
        txtSenha.BorderFocusColor = Color.Black;
        txtSenha.BorderRadius = 20;
        txtSenha.BorderSize = 2;
        txtSenha.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtSenha.ForeColor = Color.LightGray;
        txtSenha.Location = new Point(634, 456);
        txtSenha.Multiline = false;
        txtSenha.Name = "txtSenha";
        txtSenha.Padding = new Padding(10, 7, 10, 7);
        txtSenha.PasswordChar = true;
        txtSenha.PlaceholderColor = Color.DarkGray;
        txtSenha.PlaceholderText = "Senha";
        txtSenha.Size = new Size(250, 41);
        txtSenha.TabIndex = 20;
        txtSenha.Texts = "";
        txtSenha.UnderlinedStyle = false;
        txtSenha.KeyDown += txtSenha_KeyDown;
        txtSenha.KeyPress += txtSenha_KeyPress;
        // 
        // btnSair
        // 
        btnSair.Anchor = AnchorStyles.None;
        btnSair.BackColor = Color.FromArgb(60, 117, 125);
        btnSair.BackgroundColor = Color.FromArgb(60, 117, 125);
        btnSair.BorderColor = Color.Empty;
        btnSair.BorderRadius = 20;
        btnSair.BorderSize = 0;
        btnSair.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSair.FlatStyle = FlatStyle.Flat;
        btnSair.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnSair.ForeColor = Color.White;
        btnSair.Location = new Point(762, 517);
        btnSair.Name = "btnSair";
        btnSair.Size = new Size(122, 41);
        btnSair.TabIndex = 22;
        btnSair.Text = "Sair";
        btnSair.TextColor = Color.White;
        btnSair.UseVisualStyleBackColor = false;
        btnSair.Click += btnSair_Click_1;
        // 
        // btnOlho
        // 
        btnOlho.Anchor = AnchorStyles.None;
        btnOlho.BackColor = Color.White;
        btnOlho.FlatAppearance.BorderSize = 0;
        btnOlho.FlatStyle = FlatStyle.Flat;
        btnOlho.ForeColor = Color.White;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
        btnOlho.IconColor = Color.FromArgb(60, 117, 125);
        btnOlho.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnOlho.IconSize = 32;
        btnOlho.Location = new Point(890, 461);
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
        btnEntrar.BackColor = Color.FromArgb(60, 117, 125);
        btnEntrar.BackgroundColor = Color.FromArgb(60, 117, 125);
        btnEntrar.BorderColor = Color.Empty;
        btnEntrar.BorderRadius = 20;
        btnEntrar.BorderSize = 0;
        btnEntrar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnEntrar.FlatStyle = FlatStyle.Flat;
        btnEntrar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEntrar.ForeColor = Color.White;
        btnEntrar.Location = new Point(634, 517);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(122, 41);
        btnEntrar.TabIndex = 18;
        btnEntrar.Text = "Entrar";
        btnEntrar.TextColor = Color.White;
        btnEntrar.UseVisualStyleBackColor = false;
        btnEntrar.Click += btnEntrar_Click;
        // 
        // FormLogin
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(60, 117, 125);
        ClientSize = new Size(1008, 729);
        Controls.Add(pnLogin);
        ForeColor = SystemColors.ControlText;
        MinimumSize = new Size(1024, 768);
        Name = "FormLogin";
        SizeGripStyle = SizeGripStyle.Show;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "PasiWare";
        WindowState = FormWindowState.Maximized;
        Load += FormClientes_Load;
        pnLogin.ResumeLayout(false);
        pnLogin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        pnImagemLogin.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnLogin;
    private RJTextBox txtUsuario;
    private RJTextBox txtSenha;
    private RJButton btnSair;
    private FontAwesome.Sharp.IconButton btnOlho;
    private RJButton btnEntrar;
    private PictureBox pictureBox1;
    private Panel pnImagemLogin;
    private Label lblEsqueciSenha;
    private Label label1;
    private PictureBox pictureBox2;
}