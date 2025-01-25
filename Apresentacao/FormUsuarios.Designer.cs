namespace SistemaERP.Apresentacao;

partial class FormUsuarios
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
        txtUsuario = new RJControls.RJTextBox();
        txtSenha = new RJControls.RJTextBox();
        btnOlho = new FontAwesome.Sharp.IconButton();
        btnSalvar = new RJControls.RJButton();
        txtEmail = new RJControls.RJTextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display Light", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.ForeColor = Color.DimGray;
        label1.Location = new Point(341, 187);
        label1.Name = "label1";
        label1.Size = new Size(316, 46);
        label1.TabIndex = 29;
        label1.Text = "Cadastro de Usuários";
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
        txtUsuario.Location = new Point(341, 278);
        txtUsuario.Multiline = false;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Padding = new Padding(10, 7, 10, 7);
        txtUsuario.PasswordChar = false;
        txtUsuario.PlaceholderColor = Color.DarkGray;
        txtUsuario.PlaceholderText = "Usuário";
        txtUsuario.Size = new Size(250, 41);
        txtUsuario.TabIndex = 31;
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
        txtSenha.Location = new Point(341, 400);
        txtSenha.Multiline = false;
        txtSenha.Name = "txtSenha";
        txtSenha.Padding = new Padding(10, 7, 10, 7);
        txtSenha.PasswordChar = true;
        txtSenha.PlaceholderColor = Color.DarkGray;
        txtSenha.PlaceholderText = "Senha";
        txtSenha.Size = new Size(250, 41);
        txtSenha.TabIndex = 32;
        txtSenha.Texts = "";
        txtSenha.UnderlinedStyle = false;
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
        btnOlho.Location = new Point(597, 405);
        btnOlho.Name = "btnOlho";
        btnOlho.Size = new Size(38, 36);
        btnOlho.TabIndex = 33;
        btnOlho.UseVisualStyleBackColor = false;
        btnOlho.MouseDown += btnOlho_MouseDown;
        btnOlho.MouseUp += btnOlho_MouseUp;
        // 
        // btnSalvar
        // 
        btnSalvar.Anchor = AnchorStyles.None;
        btnSalvar.BackColor = Color.FromArgb(60, 117, 125);
        btnSalvar.BackgroundColor = Color.FromArgb(60, 117, 125);
        btnSalvar.BorderColor = Color.Empty;
        btnSalvar.BorderRadius = 20;
        btnSalvar.BorderSize = 0;
        btnSalvar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnSalvar.ForeColor = Color.White;
        btnSalvar.Location = new Point(341, 461);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(122, 41);
        btnSalvar.TabIndex = 30;
        btnSalvar.Text = "Salvar";
        btnSalvar.TextColor = Color.White;
        btnSalvar.UseVisualStyleBackColor = false;
        // 
        // txtEmail
        // 
        txtEmail.Anchor = AnchorStyles.None;
        txtEmail.BackColor = Color.FromArgb(60, 117, 125);
        txtEmail.BorderColor = Color.Empty;
        txtEmail.BorderFocusColor = Color.Black;
        txtEmail.BorderRadius = 20;
        txtEmail.BorderSize = 2;
        txtEmail.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtEmail.ForeColor = Color.LightGray;
        txtEmail.Location = new Point(341, 338);
        txtEmail.Multiline = false;
        txtEmail.Name = "txtEmail";
        txtEmail.Padding = new Padding(10, 7, 10, 7);
        txtEmail.PasswordChar = false;
        txtEmail.PlaceholderColor = Color.DarkGray;
        txtEmail.PlaceholderText = "Email";
        txtEmail.Size = new Size(250, 41);
        txtEmail.TabIndex = 34;
        txtEmail.Texts = "";
        txtEmail.UnderlinedStyle = false;
        // 
        // FormUsuarios
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1008, 729);
        Controls.Add(txtEmail);
        Controls.Add(txtUsuario);
        Controls.Add(txtSenha);
        Controls.Add(btnOlho);
        Controls.Add(btnSalvar);
        Controls.Add(label1);
        MinimumSize = new Size(1024, 768);
        Name = "FormUsuarios";
        Text = "FormUsuarios";
        WindowState = FormWindowState.Maximized;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private RJControls.RJTextBox txtUsuario;
    private RJControls.RJTextBox txtSenha;
    private FontAwesome.Sharp.IconButton btnOlho;
    private RJControls.RJButton btnSalvar;
    private RJControls.RJTextBox txtEmail;
}