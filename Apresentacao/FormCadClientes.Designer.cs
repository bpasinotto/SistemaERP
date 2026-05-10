namespace SistemaERP.Apresentacao;

partial class FormCadClientes
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
        components = new System.ComponentModel.Container();
        txtCNPJ = new SistemaERP.RJControls.RJTextBox();
        btnVoltar = new SistemaERP.RJControls.RJButton();
        btnBuscaCnpj = new FontAwesome.Sharp.IconButton();
        btnSalvar = new SistemaERP.RJControls.RJButton();
        label1 = new Label();
        txtFantasia = new SistemaERP.RJControls.RJTextBox();
        txtEmail = new SistemaERP.RJControls.RJTextBox();
        txtTelefone = new SistemaERP.RJControls.RJTextBox();
        txtCEP = new SistemaERP.RJControls.RJTextBox();
        txtRua = new SistemaERP.RJControls.RJTextBox();
        txtBairro = new SistemaERP.RJControls.RJTextBox();
        txtCidade = new SistemaERP.RJControls.RJTextBox();
        txtNumero = new SistemaERP.RJControls.RJTextBox();
        txtComplemento = new SistemaERP.RJControls.RJTextBox();
        txtEstado = new SistemaERP.RJControls.RJTextBox();
        btnBuscaCep = new FontAwesome.Sharp.IconButton();
        txtRazao = new SistemaERP.RJControls.RJTextBox();
        label2 = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        label9 = new Label();
        label10 = new Label();
        label11 = new Label();
        label12 = new Label();
        label13 = new Label();
        txtObs = new SistemaERP.RJControls.RJTextBox();
        label14 = new Label();
        label15 = new Label();
        btnAtivaInativa = new SistemaERP.RJControls.RJButton();
        toolTip1 = new ToolTip(components);
        SuspendLayout();
        // 
        // txtCNPJ
        // 
        txtCNPJ.Anchor = AnchorStyles.None;
        txtCNPJ.BackColor = Color.FromArgb(2, 89, 89);
        txtCNPJ.BorderColor = Color.Empty;
        txtCNPJ.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtCNPJ.BorderRadius = 20;
        txtCNPJ.BorderSize = 2;
        txtCNPJ.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtCNPJ.ForeColor = Color.White;
        txtCNPJ.Location = new Point(49, 182);
        txtCNPJ.MaxLength = 32767;
        txtCNPJ.Multiline = false;
        txtCNPJ.Name = "txtCNPJ";
        txtCNPJ.Padding = new Padding(10, 7, 10, 7);
        txtCNPJ.PasswordChar = false;
        txtCNPJ.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCNPJ.PlaceholderText = "";
        txtCNPJ.SelectionStart = 0;
        txtCNPJ.Size = new Size(250, 41);
        txtCNPJ.TabIndex = 32;
        txtCNPJ.Texts = "";
        txtCNPJ.UnderlinedStyle = false;
        txtCNPJ.KeyDown += txtCNPJ_KeyDown;
        txtCNPJ.KeyPress += txtCNPJ_KeyPress;
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
        btnVoltar.Location = new Point(524, 647);
        btnVoltar.Name = "btnVoltar";
        btnVoltar.Size = new Size(122, 41);
        btnVoltar.TabIndex = 36;
        btnVoltar.TabStop = false;
        btnVoltar.Text = "Voltar";
        btnVoltar.TextColor = Color.White;
        btnVoltar.UseVisualStyleBackColor = false;
        btnVoltar.Click += btnVoltar_Click;
        // 
        // btnBuscaCnpj
        // 
        btnBuscaCnpj.Anchor = AnchorStyles.None;
        btnBuscaCnpj.FlatAppearance.BorderSize = 0;
        btnBuscaCnpj.FlatStyle = FlatStyle.Flat;
        btnBuscaCnpj.ForeColor = Color.White;
        btnBuscaCnpj.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassArrowRight;
        btnBuscaCnpj.IconColor = Color.FromArgb(2, 89, 89);
        btnBuscaCnpj.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnBuscaCnpj.IconSize = 32;
        btnBuscaCnpj.Location = new Point(305, 186);
        btnBuscaCnpj.Name = "btnBuscaCnpj";
        btnBuscaCnpj.Size = new Size(38, 36);
        btnBuscaCnpj.TabIndex = 37;
        btnBuscaCnpj.TabStop = false;
        toolTip1.SetToolTip(btnBuscaCnpj, "Busca os dados utilizando o CNPJ");
        btnBuscaCnpj.UseVisualStyleBackColor = false;
        btnBuscaCnpj.Click += btnBuscaCnpj_Click;
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
        btnSalvar.Location = new Point(396, 647);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(122, 41);
        btnSalvar.TabIndex = 35;
        btnSalvar.TabStop = false;
        btnSalvar.Text = "Salvar";
        btnSalvar.TextColor = Color.White;
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += btnSalvar_Click;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display Light", 25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(349, 27);
        label1.Name = "label1";
        label1.Size = new Size(309, 46);
        label1.TabIndex = 39;
        label1.Text = "Cadastro de Clientes";
        // 
        // txtFantasia
        // 
        txtFantasia.Anchor = AnchorStyles.None;
        txtFantasia.BackColor = Color.FromArgb(2, 89, 89);
        txtFantasia.BorderColor = Color.Empty;
        txtFantasia.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtFantasia.BorderRadius = 20;
        txtFantasia.BorderSize = 2;
        txtFantasia.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtFantasia.ForeColor = Color.White;
        txtFantasia.Location = new Point(49, 304);
        txtFantasia.MaxLength = 100;
        txtFantasia.Multiline = false;
        txtFantasia.Name = "txtFantasia";
        txtFantasia.Padding = new Padding(10, 7, 10, 7);
        txtFantasia.PasswordChar = false;
        txtFantasia.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtFantasia.PlaceholderText = "";
        txtFantasia.SelectionStart = 0;
        txtFantasia.Size = new Size(250, 41);
        txtFantasia.TabIndex = 43;
        txtFantasia.Texts = "";
        txtFantasia.UnderlinedStyle = false;
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
        txtEmail.Location = new Point(49, 365);
        txtEmail.MaxLength = 100;
        txtEmail.Multiline = false;
        txtEmail.Name = "txtEmail";
        txtEmail.Padding = new Padding(10, 7, 10, 7);
        txtEmail.PasswordChar = false;
        txtEmail.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtEmail.PlaceholderText = "";
        txtEmail.SelectionStart = 0;
        txtEmail.Size = new Size(250, 41);
        txtEmail.TabIndex = 44;
        txtEmail.Texts = "";
        txtEmail.UnderlinedStyle = false;
        // 
        // txtTelefone
        // 
        txtTelefone.Anchor = AnchorStyles.None;
        txtTelefone.BackColor = Color.FromArgb(2, 89, 89);
        txtTelefone.BorderColor = Color.Empty;
        txtTelefone.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtTelefone.BorderRadius = 20;
        txtTelefone.BorderSize = 2;
        txtTelefone.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtTelefone.ForeColor = Color.White;
        txtTelefone.Location = new Point(49, 426);
        txtTelefone.MaxLength = 15;
        txtTelefone.Multiline = false;
        txtTelefone.Name = "txtTelefone";
        txtTelefone.Padding = new Padding(10, 7, 10, 7);
        txtTelefone.PasswordChar = false;
        txtTelefone.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtTelefone.PlaceholderText = "";
        txtTelefone.SelectionStart = 0;
        txtTelefone.Size = new Size(250, 41);
        txtTelefone.TabIndex = 45;
        txtTelefone.Texts = "";
        txtTelefone.UnderlinedStyle = false;
        txtTelefone.Leave += txtTelefone_Leave;
        // 
        // txtCEP
        // 
        txtCEP.Anchor = AnchorStyles.None;
        txtCEP.BackColor = Color.FromArgb(2, 89, 89);
        txtCEP.BorderColor = Color.Empty;
        txtCEP.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtCEP.BorderRadius = 20;
        txtCEP.BorderSize = 2;
        txtCEP.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtCEP.ForeColor = Color.White;
        txtCEP.Location = new Point(49, 487);
        txtCEP.MaxLength = 10;
        txtCEP.Multiline = false;
        txtCEP.Name = "txtCEP";
        txtCEP.Padding = new Padding(10, 7, 10, 7);
        txtCEP.PasswordChar = false;
        txtCEP.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCEP.PlaceholderText = "";
        txtCEP.SelectionStart = 0;
        txtCEP.Size = new Size(250, 41);
        txtCEP.TabIndex = 46;
        txtCEP.Texts = "";
        txtCEP.UnderlinedStyle = false;
        txtCEP.KeyDown += txtCEP_KeyDown;
        txtCEP.KeyPress += txtCEP_KeyPress;
        // 
        // txtRua
        // 
        txtRua.Anchor = AnchorStyles.None;
        txtRua.BackColor = Color.FromArgb(2, 89, 89);
        txtRua.BorderColor = Color.Empty;
        txtRua.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtRua.BorderRadius = 20;
        txtRua.BorderSize = 2;
        txtRua.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtRua.ForeColor = Color.White;
        txtRua.Location = new Point(396, 182);
        txtRua.MaxLength = 100;
        txtRua.Multiline = false;
        txtRua.Name = "txtRua";
        txtRua.Padding = new Padding(10, 7, 10, 7);
        txtRua.PasswordChar = false;
        txtRua.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtRua.PlaceholderText = "";
        txtRua.SelectionStart = 0;
        txtRua.Size = new Size(250, 41);
        txtRua.TabIndex = 47;
        txtRua.Texts = "";
        txtRua.UnderlinedStyle = false;
        // 
        // txtBairro
        // 
        txtBairro.Anchor = AnchorStyles.None;
        txtBairro.BackColor = Color.FromArgb(2, 89, 89);
        txtBairro.BorderColor = Color.Empty;
        txtBairro.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtBairro.BorderRadius = 20;
        txtBairro.BorderSize = 2;
        txtBairro.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtBairro.ForeColor = Color.White;
        txtBairro.Location = new Point(396, 243);
        txtBairro.MaxLength = 100;
        txtBairro.Multiline = false;
        txtBairro.Name = "txtBairro";
        txtBairro.Padding = new Padding(10, 7, 10, 7);
        txtBairro.PasswordChar = false;
        txtBairro.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtBairro.PlaceholderText = "";
        txtBairro.SelectionStart = 0;
        txtBairro.Size = new Size(250, 41);
        txtBairro.TabIndex = 48;
        txtBairro.Texts = "";
        txtBairro.UnderlinedStyle = false;
        // 
        // txtCidade
        // 
        txtCidade.Anchor = AnchorStyles.None;
        txtCidade.BackColor = Color.FromArgb(2, 89, 89);
        txtCidade.BorderColor = Color.Empty;
        txtCidade.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtCidade.BorderRadius = 20;
        txtCidade.BorderSize = 2;
        txtCidade.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtCidade.ForeColor = Color.White;
        txtCidade.Location = new Point(396, 304);
        txtCidade.MaxLength = 100;
        txtCidade.Multiline = false;
        txtCidade.Name = "txtCidade";
        txtCidade.Padding = new Padding(10, 7, 10, 7);
        txtCidade.PasswordChar = false;
        txtCidade.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCidade.PlaceholderText = "";
        txtCidade.SelectionStart = 0;
        txtCidade.Size = new Size(250, 41);
        txtCidade.TabIndex = 49;
        txtCidade.Texts = "";
        txtCidade.UnderlinedStyle = false;
        // 
        // txtNumero
        // 
        txtNumero.Anchor = AnchorStyles.None;
        txtNumero.BackColor = Color.FromArgb(2, 89, 89);
        txtNumero.BorderColor = Color.Empty;
        txtNumero.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtNumero.BorderRadius = 20;
        txtNumero.BorderSize = 2;
        txtNumero.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtNumero.ForeColor = Color.White;
        txtNumero.Location = new Point(396, 365);
        txtNumero.MaxLength = 5;
        txtNumero.Multiline = false;
        txtNumero.Name = "txtNumero";
        txtNumero.Padding = new Padding(10, 7, 10, 7);
        txtNumero.PasswordChar = false;
        txtNumero.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtNumero.PlaceholderText = "";
        txtNumero.SelectionStart = 0;
        txtNumero.Size = new Size(250, 41);
        txtNumero.TabIndex = 50;
        txtNumero.Texts = "";
        txtNumero.UnderlinedStyle = false;
        // 
        // txtComplemento
        // 
        txtComplemento.Anchor = AnchorStyles.None;
        txtComplemento.BackColor = Color.FromArgb(2, 89, 89);
        txtComplemento.BorderColor = Color.Empty;
        txtComplemento.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtComplemento.BorderRadius = 20;
        txtComplemento.BorderSize = 2;
        txtComplemento.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtComplemento.ForeColor = Color.White;
        txtComplemento.Location = new Point(396, 426);
        txtComplemento.MaxLength = 20;
        txtComplemento.Multiline = false;
        txtComplemento.Name = "txtComplemento";
        txtComplemento.Padding = new Padding(10, 7, 10, 7);
        txtComplemento.PasswordChar = false;
        txtComplemento.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtComplemento.PlaceholderText = "";
        txtComplemento.SelectionStart = 0;
        txtComplemento.Size = new Size(250, 41);
        txtComplemento.TabIndex = 51;
        txtComplemento.Texts = "";
        txtComplemento.UnderlinedStyle = false;
        // 
        // txtEstado
        // 
        txtEstado.Anchor = AnchorStyles.None;
        txtEstado.BackColor = Color.FromArgb(2, 89, 89);
        txtEstado.BorderColor = Color.Empty;
        txtEstado.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtEstado.BorderRadius = 20;
        txtEstado.BorderSize = 2;
        txtEstado.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtEstado.ForeColor = Color.White;
        txtEstado.Location = new Point(396, 487);
        txtEstado.MaxLength = 2;
        txtEstado.Multiline = false;
        txtEstado.Name = "txtEstado";
        txtEstado.Padding = new Padding(10, 7, 10, 7);
        txtEstado.PasswordChar = false;
        txtEstado.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtEstado.PlaceholderText = "";
        txtEstado.SelectionStart = 0;
        txtEstado.Size = new Size(250, 41);
        txtEstado.TabIndex = 52;
        txtEstado.Texts = "";
        txtEstado.UnderlinedStyle = false;
        // 
        // btnBuscaCep
        // 
        btnBuscaCep.Anchor = AnchorStyles.None;
        btnBuscaCep.FlatAppearance.BorderSize = 0;
        btnBuscaCep.FlatStyle = FlatStyle.Flat;
        btnBuscaCep.ForeColor = Color.White;
        btnBuscaCep.IconChar = FontAwesome.Sharp.IconChar.SearchLocation;
        btnBuscaCep.IconColor = Color.FromArgb(2, 89, 89);
        btnBuscaCep.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnBuscaCep.IconSize = 32;
        btnBuscaCep.Location = new Point(305, 492);
        btnBuscaCep.Name = "btnBuscaCep";
        btnBuscaCep.Size = new Size(38, 36);
        btnBuscaCep.TabIndex = 54;
        btnBuscaCep.TabStop = false;
        toolTip1.SetToolTip(btnBuscaCep, "Busca o endereço utilizando o CEP");
        btnBuscaCep.UseVisualStyleBackColor = false;
        btnBuscaCep.Click += btnBuscaCep_Click;
        // 
        // txtRazao
        // 
        txtRazao.Anchor = AnchorStyles.None;
        txtRazao.BackColor = Color.FromArgb(2, 89, 89);
        txtRazao.BorderColor = Color.Empty;
        txtRazao.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtRazao.BorderRadius = 20;
        txtRazao.BorderSize = 2;
        txtRazao.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtRazao.ForeColor = Color.White;
        txtRazao.Location = new Point(50, 243);
        txtRazao.MaxLength = 100;
        txtRazao.Multiline = false;
        txtRazao.Name = "txtRazao";
        txtRazao.Padding = new Padding(10, 7, 10, 7);
        txtRazao.PasswordChar = false;
        txtRazao.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtRazao.PlaceholderText = "";
        txtRazao.SelectionStart = 0;
        txtRazao.Size = new Size(250, 41);
        txtRazao.TabIndex = 33;
        txtRazao.Texts = "";
        txtRazao.UnderlinedStyle = false;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI Variable Display", 10F);
        label2.Location = new Point(64, 165);
        label2.Name = "label2";
        label2.Size = new Size(73, 19);
        label2.TabIndex = 55;
        label2.Text = "CPF/CNPJ";
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.None;
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI Variable Display", 10F);
        label3.Location = new Point(64, 226);
        label3.Name = "label3";
        label3.Size = new Size(84, 19);
        label3.TabIndex = 56;
        label3.Text = "Razão Social";
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.None;
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI Variable Display", 10F);
        label4.Location = new Point(64, 287);
        label4.Name = "label4";
        label4.Size = new Size(99, 19);
        label4.TabIndex = 57;
        label4.Text = "Nome Fantasia";
        // 
        // label5
        // 
        label5.Anchor = AnchorStyles.None;
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI Variable Display", 10F);
        label5.Location = new Point(64, 348);
        label5.Name = "label5";
        label5.Size = new Size(41, 19);
        label5.TabIndex = 58;
        label5.Text = "Email";
        // 
        // label6
        // 
        label6.Anchor = AnchorStyles.None;
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI Variable Display", 10F);
        label6.Location = new Point(64, 409);
        label6.Name = "label6";
        label6.Size = new Size(59, 19);
        label6.TabIndex = 59;
        label6.Text = "Telefone";
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.None;
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI Variable Display", 10F);
        label7.Location = new Point(65, 509);
        label7.Name = "label7";
        label7.Size = new Size(34, 19);
        label7.TabIndex = 60;
        label7.Text = "CEP";
        // 
        // label8
        // 
        label8.Anchor = AnchorStyles.None;
        label8.AutoSize = true;
        label8.Font = new Font("Segoe UI Variable Display", 10F);
        label8.Location = new Point(413, 165);
        label8.Name = "label8";
        label8.Size = new Size(32, 19);
        label8.TabIndex = 61;
        label8.Text = "Rua";
        // 
        // label9
        // 
        label9.Anchor = AnchorStyles.None;
        label9.AutoSize = true;
        label9.Font = new Font("Segoe UI Variable Display", 10F);
        label9.Location = new Point(413, 226);
        label9.Name = "label9";
        label9.Size = new Size(45, 19);
        label9.TabIndex = 62;
        label9.Text = "Bairro";
        // 
        // label10
        // 
        label10.Anchor = AnchorStyles.None;
        label10.AutoSize = true;
        label10.Font = new Font("Segoe UI Variable Display", 10F);
        label10.Location = new Point(413, 287);
        label10.Name = "label10";
        label10.Size = new Size(52, 19);
        label10.TabIndex = 63;
        label10.Text = "Cidade";
        // 
        // label11
        // 
        label11.Anchor = AnchorStyles.None;
        label11.AutoSize = true;
        label11.Font = new Font("Segoe UI Variable Display", 10F);
        label11.Location = new Point(413, 348);
        label11.Name = "label11";
        label11.Size = new Size(59, 19);
        label11.TabIndex = 64;
        label11.Text = "Número";
        // 
        // label12
        // 
        label12.Anchor = AnchorStyles.None;
        label12.AutoSize = true;
        label12.Font = new Font("Segoe UI Variable Display", 10F);
        label12.Location = new Point(413, 409);
        label12.Name = "label12";
        label12.Size = new Size(97, 19);
        label12.TabIndex = 65;
        label12.Text = "Complemento";
        // 
        // label13
        // 
        label13.Anchor = AnchorStyles.None;
        label13.AutoSize = true;
        label13.Font = new Font("Segoe UI Variable Display", 10F);
        label13.Location = new Point(413, 470);
        label13.Name = "label13";
        label13.Size = new Size(50, 19);
        label13.TabIndex = 66;
        label13.Text = "Estado";
        // 
        // txtObs
        // 
        txtObs.Anchor = AnchorStyles.None;
        txtObs.BackColor = Color.FromArgb(2, 89, 89);
        txtObs.BorderColor = Color.Empty;
        txtObs.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtObs.BorderRadius = 20;
        txtObs.BorderSize = 2;
        txtObs.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtObs.ForeColor = Color.White;
        txtObs.Location = new Point(708, 182);
        txtObs.MaxLength = 240;
        txtObs.Multiline = true;
        txtObs.Name = "txtObs";
        txtObs.Padding = new Padding(10, 7, 10, 7);
        txtObs.PasswordChar = false;
        txtObs.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtObs.PlaceholderText = "";
        txtObs.SelectionStart = 0;
        txtObs.Size = new Size(250, 346);
        txtObs.TabIndex = 67;
        txtObs.Texts = "";
        txtObs.UnderlinedStyle = false;
        // 
        // label14
        // 
        label14.Anchor = AnchorStyles.None;
        label14.AutoSize = true;
        label14.Font = new Font("Segoe UI Variable Display", 10F);
        label14.Location = new Point(725, 165);
        label14.Name = "label14";
        label14.Size = new Size(87, 19);
        label14.TabIndex = 68;
        label14.Text = "Observações";
        // 
        // label15
        // 
        label15.Anchor = AnchorStyles.None;
        label15.AutoSize = true;
        label15.Font = new Font("Segoe UI Variable Display", 10F);
        label15.Location = new Point(64, 470);
        label15.Name = "label15";
        label15.Size = new Size(34, 19);
        label15.TabIndex = 69;
        label15.Text = "CEP";
        // 
        // btnAtivaInativa
        // 
        btnAtivaInativa.Anchor = AnchorStyles.None;
        btnAtivaInativa.BackColor = Color.FromArgb(2, 89, 89);
        btnAtivaInativa.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnAtivaInativa.BorderColor = Color.Empty;
        btnAtivaInativa.BorderRadius = 20;
        btnAtivaInativa.BorderSize = 0;
        btnAtivaInativa.FlatAppearance.BorderColor = Color.DarkBlue;
        btnAtivaInativa.FlatStyle = FlatStyle.Flat;
        btnAtivaInativa.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnAtivaInativa.ForeColor = Color.White;
        btnAtivaInativa.Location = new Point(50, 647);
        btnAtivaInativa.Name = "btnAtivaInativa";
        btnAtivaInativa.Size = new Size(249, 41);
        btnAtivaInativa.TabIndex = 70;
        btnAtivaInativa.TabStop = false;
        btnAtivaInativa.Text = "Inativar Cliente";
        btnAtivaInativa.TextColor = Color.White;
        btnAtivaInativa.UseVisualStyleBackColor = false;
        btnAtivaInativa.Click += btnAtivaInativa_Click;
        // 
        // FormCadClientes
        // 
        AllowRoundedCorners = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 724);
        CloseButtonVisible = false;
        Controls.Add(btnAtivaInativa);
        Controls.Add(txtObs);
        Controls.Add(btnBuscaCep);
        Controls.Add(txtEstado);
        Controls.Add(txtComplemento);
        Controls.Add(txtNumero);
        Controls.Add(txtCidade);
        Controls.Add(txtBairro);
        Controls.Add(txtRua);
        Controls.Add(txtCEP);
        Controls.Add(txtTelefone);
        Controls.Add(txtEmail);
        Controls.Add(txtFantasia);
        Controls.Add(txtRazao);
        Controls.Add(txtCNPJ);
        Controls.Add(btnVoltar);
        Controls.Add(btnBuscaCnpj);
        Controls.Add(btnSalvar);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(label13);
        Controls.Add(label12);
        Controls.Add(label11);
        Controls.Add(label10);
        Controls.Add(label9);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label14);
        Controls.Add(label15);
        IconSize = new Size(0, 0);
        MinimizeBox = false;
        MinimumSize = new Size(1024, 768);
        Name = "FormCadClientes";
        StartPosition = FormStartPosition.CenterParent;
        Style.InactiveShadowOpacity = 0;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Style.ShadowOpacity = 0;
        Style.TitleBar.BackColor = Color.WhiteSmoke;
        Text = " ";
        WindowState = FormWindowState.Maximized;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private RJControls.RJTextBox txtCNPJ;
    private RJControls.RJButton btnVoltar;
    private FontAwesome.Sharp.IconButton btnBuscaCnpj;
    private RJControls.RJButton btnSalvar;
    private Label label1;
    private RJControls.RJTextBox txtFantasia;
    private RJControls.RJTextBox txtEmail;
    private RJControls.RJTextBox txtTelefone;
    private RJControls.RJTextBox txtCEP;
    private RJControls.RJTextBox txtRua;
    private RJControls.RJTextBox txtBairro;
    private RJControls.RJTextBox txtCidade;
    private RJControls.RJTextBox txtNumero;
    private RJControls.RJTextBox txtComplemento;
    private RJControls.RJTextBox txtEstado;
    private FontAwesome.Sharp.IconButton btnBuscaCep;
    private RJControls.RJTextBox txtRazao;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private RJControls.RJTextBox txtObs;
    private Label label14;
    private Label label15;
    private RJControls.RJButton btnAtivaInativa;
    private ToolTip toolTip1;
}