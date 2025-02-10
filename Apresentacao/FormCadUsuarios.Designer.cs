namespace SistemaERP.Apresentacao;

partial class FormCadUsuarios
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
        btnOlho = new FontAwesome.Sharp.IconButton();
        btnSalvar = new RJControls.RJButton();
        btnVoltar = new RJControls.RJButton();
        lblEmailInvalido = new Label();
        txtEmail = new RJControls.RJTextBox();
        txtSenha = new RJControls.RJTextBox();
        txtUsuario = new RJControls.RJTextBox();
        lblUsuarioInvalido = new Label();
        lblSenhaInvalida = new Label();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display Light", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.DimGray;
        label1.Location = new Point(349, 207);
        label1.Name = "label1";
        label1.Size = new Size(316, 46);
        label1.TabIndex = 29;
        label1.Text = "Cadastro de Usuários";
        // 
        // btnOlho
        // 
        btnOlho.Anchor = AnchorStyles.None;
        btnOlho.BackColor = Color.White;
        btnOlho.FlatAppearance.BorderSize = 0;
        btnOlho.FlatStyle = FlatStyle.Flat;
        btnOlho.ForeColor = Color.White;
        btnOlho.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
        btnOlho.IconColor = Color.FromArgb(2, 89, 89);
        btnOlho.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnOlho.IconSize = 32;
        btnOlho.Location = new Point(605, 422);
        btnOlho.Name = "btnOlho";
        btnOlho.Size = new Size(38, 36);
        btnOlho.TabIndex = 6;
        btnOlho.TabStop = false;
        btnOlho.UseVisualStyleBackColor = false;
        btnOlho.MouseDown += btnOlho_MouseDown;
        btnOlho.MouseUp += btnOlho_MouseUp;
        // 
        // btnSalvar
        // 
        btnSalvar.Anchor = AnchorStyles.None;
        btnSalvar.BackColor = Color.FromArgb(2, 89, 89);
        btnSalvar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnSalvar.BorderColor = Color.Empty;
        btnSalvar.BorderRadius = 20;
        btnSalvar.BorderSize = 0;
        btnSalvar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnSalvar.ForeColor = Color.White;
        btnSalvar.Location = new Point(349, 480);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(122, 41);
        btnSalvar.TabIndex = 4;
        btnSalvar.TabStop = false;
        btnSalvar.Text = "Salvar";
        btnSalvar.TextColor = Color.White;
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += btnSalvar_Click;
        // 
        // btnVoltar
        // 
        btnVoltar.Anchor = AnchorStyles.None;
        btnVoltar.BackColor = Color.FromArgb(2, 89, 89);
        btnVoltar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnVoltar.BorderColor = Color.Empty;
        btnVoltar.BorderRadius = 20;
        btnVoltar.BorderSize = 0;
        btnVoltar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnVoltar.ForeColor = Color.White;
        btnVoltar.Location = new Point(477, 480);
        btnVoltar.Name = "btnVoltar";
        btnVoltar.Size = new Size(122, 41);
        btnVoltar.TabIndex = 5;
        btnVoltar.TabStop = false;
        btnVoltar.Text = "Voltar";
        btnVoltar.TextColor = Color.White;
        btnVoltar.UseVisualStyleBackColor = false;
        btnVoltar.Click += btnVoltar_Click;
        // 
        // lblEmailInvalido
        // 
        lblEmailInvalido.Anchor = AnchorStyles.None;
        lblEmailInvalido.AutoSize = true;
        lblEmailInvalido.Font = new Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblEmailInvalido.ForeColor = Color.Red;
        lblEmailInvalido.Location = new Point(605, 368);
        lblEmailInvalido.Name = "lblEmailInvalido";
        lblEmailInvalido.Size = new Size(95, 20);
        lblEmailInvalido.TabIndex = 7;
        lblEmailInvalido.Text = "Email inválido";
        // 
        // txtEmail
        // 
        txtEmail.Anchor = AnchorStyles.None;
        txtEmail.BackColor = Color.FromArgb(2, 89, 89);
        txtEmail.BorderColor = Color.Empty;
        txtEmail.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtEmail.BorderRadius = 20;
        txtEmail.BorderSize = 2;
        txtEmail.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtEmail.ForeColor = Color.White;
        txtEmail.Location = new Point(349, 358);
        txtEmail.Multiline = false;
        txtEmail.Name = "txtEmail";
        txtEmail.Padding = new Padding(10, 7, 10, 7);
        txtEmail.PasswordChar = false;
        txtEmail.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtEmail.PlaceholderText = "Email";
        txtEmail.Size = new Size(250, 41);
        txtEmail.TabIndex = 2;
        txtEmail.Texts = "";
        txtEmail.UnderlinedStyle = false;
        txtEmail._TextChanged += txtEmail__TextChanged;
        txtEmail.KeyDown += txtEmail_KeyDown;
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
        txtSenha.Location = new Point(349, 419);
        txtSenha.Multiline = false;
        txtSenha.Name = "txtSenha";
        txtSenha.Padding = new Padding(10, 7, 10, 7);
        txtSenha.PasswordChar = true;
        txtSenha.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtSenha.PlaceholderText = "Senha";
        txtSenha.Size = new Size(250, 41);
        txtSenha.TabIndex = 3;
        txtSenha.Texts = "";
        txtSenha.UnderlinedStyle = false;
        txtSenha._TextChanged += txtSenha__TextChanged;
        txtSenha.KeyDown += txtSenha_KeyDown;
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
        txtUsuario.Location = new Point(349, 297);
        txtUsuario.Multiline = false;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Padding = new Padding(10, 7, 10, 7);
        txtUsuario.PasswordChar = false;
        txtUsuario.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtUsuario.PlaceholderText = "Usuário";
        txtUsuario.Size = new Size(250, 41);
        txtUsuario.TabIndex = 1;
        txtUsuario.Texts = "";
        txtUsuario.UnderlinedStyle = false;
        txtUsuario._TextChanged += txtUsuario__TextChanged;
        txtUsuario.KeyDown += txtUsuario_KeyDown;
        // 
        // lblUsuarioInvalido
        // 
        lblUsuarioInvalido.Anchor = AnchorStyles.None;
        lblUsuarioInvalido.AutoSize = true;
        lblUsuarioInvalido.Font = new Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblUsuarioInvalido.ForeColor = Color.Red;
        lblUsuarioInvalido.Location = new Point(605, 308);
        lblUsuarioInvalido.Name = "lblUsuarioInvalido";
        lblUsuarioInvalido.Size = new Size(142, 20);
        lblUsuarioInvalido.TabIndex = 30;
        lblUsuarioInvalido.Text = "Mínimo 3 caracteres";
        // 
        // lblSenhaInvalida
        // 
        lblSenhaInvalida.Anchor = AnchorStyles.None;
        lblSenhaInvalida.AutoSize = true;
        lblSenhaInvalida.Font = new Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSenhaInvalida.ForeColor = Color.Red;
        lblSenhaInvalida.Location = new Point(201, 429);
        lblSenhaInvalida.Name = "lblSenhaInvalida";
        lblSenhaInvalida.Size = new Size(142, 20);
        lblSenhaInvalida.TabIndex = 31;
        lblSenhaInvalida.Text = "Mínimo 4 caracteres";
        // 
        // FormCadUsuarios
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1024, 768);
        ControlBox = false;
        Controls.Add(lblSenhaInvalida);
        Controls.Add(lblUsuarioInvalido);
        Controls.Add(txtSenha);
        Controls.Add(txtEmail);
        Controls.Add(txtUsuario);
        Controls.Add(lblEmailInvalido);
        Controls.Add(btnVoltar);
        Controls.Add(btnOlho);
        Controls.Add(btnSalvar);
        Controls.Add(label1);
        ForeColor = Color.Black;
        MinimumSize = new Size(1024, 768);
        Name = "FormCadUsuarios";
        StartPosition = FormStartPosition.CenterParent;
        Text = " ";
        WindowState = FormWindowState.Maximized;
        Load += FormCadUsuarios_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;    
    private FontAwesome.Sharp.IconButton btnOlho;
    private RJControls.RJButton btnSalvar;    
    private RJControls.RJButton btnVoltar;
    private Label lblEmailInvalido;
    private RJControls.RJTextBox txtEmail;
    private RJControls.RJTextBox txtSenha;
    private RJControls.RJTextBox txtUsuario;
    private Label lblUsuarioInvalido;
    private Label lblSenhaInvalida;
}