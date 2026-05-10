namespace SistemaERP.Apresentacao;

partial class FormCadProdutos
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
        cbUN = new ComboBox();
        btnAtivaInativa = new SistemaERP.RJControls.RJButton();
        txtNome = new SistemaERP.RJControls.RJTextBox();
        btnVoltar = new SistemaERP.RJControls.RJButton();
        btnSalvar = new SistemaERP.RJControls.RJButton();
        label1 = new Label();
        label2 = new Label();
        txtPreco = new SistemaERP.RJControls.RJTextBox();
        label3 = new Label();
        txtCusto = new SistemaERP.RJControls.RJTextBox();
        label4 = new Label();
        txtEstoque = new SistemaERP.RJControls.RJTextBox();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        cbFornecedor = new ComboBox();
        label8 = new Label();
        lblDataCadastro = new Label();
        SuspendLayout();
        // 
        // cbUN
        // 
        cbUN.Anchor = AnchorStyles.None;
        cbUN.BackColor = Color.FromArgb(2, 89, 89);
        cbUN.DropDownStyle = ComboBoxStyle.DropDownList;
        cbUN.FlatStyle = FlatStyle.Flat;
        cbUN.Font = new Font("Segoe UI Variable Display", 16F);
        cbUN.ForeColor = Color.White;
        cbUN.FormattingEnabled = true;
        cbUN.Items.AddRange(new object[] { "UN", "CX", "PC", "KG", "G", "T", "M", "CM", "L", "ML", "M²", "M³" });
        cbUN.Location = new Point(560, 381);
        cbUN.Name = "cbUN";
        cbUN.Size = new Size(235, 36);
        cbUN.TabIndex = 6;
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
        btnAtivaInativa.Location = new Point(199, 638);
        btnAtivaInativa.Name = "btnAtivaInativa";
        btnAtivaInativa.Size = new Size(249, 41);
        btnAtivaInativa.TabIndex = 76;
        btnAtivaInativa.TabStop = false;
        btnAtivaInativa.Text = "Inativar Produto";
        btnAtivaInativa.TextColor = Color.White;
        btnAtivaInativa.UseVisualStyleBackColor = false;
        btnAtivaInativa.Click += btnAtivaInativa_Click;
        // 
        // txtNome
        // 
        txtNome.Anchor = AnchorStyles.None;
        txtNome.BackColor = Color.FromArgb(2, 89, 89);
        txtNome.BorderColor = Color.Empty;
        txtNome.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtNome.BorderRadius = 20;
        txtNome.BorderSize = 2;
        txtNome.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtNome.ForeColor = Color.White;
        txtNome.Location = new Point(199, 226);
        txtNome.MaxLength = 32767;
        txtNome.Multiline = false;
        txtNome.Name = "txtNome";
        txtNome.Padding = new Padding(10, 7, 10, 7);
        txtNome.PasswordChar = false;
        txtNome.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtNome.PlaceholderText = "";
        txtNome.SelectionStart = 0;
        txtNome.Size = new Size(250, 41);
        txtNome.TabIndex = 1;
        txtNome.Texts = "";
        txtNome.UnderlinedStyle = false;
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
        btnVoltar.Location = new Point(673, 638);
        btnVoltar.Name = "btnVoltar";
        btnVoltar.Size = new Size(122, 41);
        btnVoltar.TabIndex = 73;
        btnVoltar.TabStop = false;
        btnVoltar.Text = "Voltar";
        btnVoltar.TextColor = Color.White;
        btnVoltar.UseVisualStyleBackColor = false;
        btnVoltar.Click += btnVoltar_Click;
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
        btnSalvar.Location = new Point(545, 638);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(122, 41);
        btnSalvar.TabIndex = 72;
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
        label1.Location = new Point(338, 32);
        label1.Name = "label1";
        label1.Size = new Size(324, 46);
        label1.TabIndex = 74;
        label1.Text = "Cadastro de Produtos";
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI Variable Display", 10F);
        label2.Location = new Point(214, 209);
        label2.Name = "label2";
        label2.Size = new Size(46, 19);
        label2.TabIndex = 75;
        label2.Text = "Nome";
        // 
        // txtPreco
        // 
        txtPreco.Anchor = AnchorStyles.None;
        txtPreco.BackColor = Color.FromArgb(2, 89, 89);
        txtPreco.BorderColor = Color.Empty;
        txtPreco.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtPreco.BorderRadius = 20;
        txtPreco.BorderSize = 2;
        txtPreco.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtPreco.ForeColor = Color.White;
        txtPreco.Location = new Point(199, 302);
        txtPreco.MaxLength = 32767;
        txtPreco.Multiline = false;
        txtPreco.Name = "txtPreco";
        txtPreco.Padding = new Padding(10, 7, 10, 7);
        txtPreco.PasswordChar = false;
        txtPreco.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtPreco.PlaceholderText = "";
        txtPreco.SelectionStart = 0;
        txtPreco.Size = new Size(250, 41);
        txtPreco.TabIndex = 3;
        txtPreco.Texts = "0,00";
        txtPreco.UnderlinedStyle = false;
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.None;
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI Variable Display", 10F);
        label3.Location = new Point(214, 285);
        label3.Name = "label3";
        label3.Size = new Size(44, 19);
        label3.TabIndex = 79;
        label3.Text = "Preço";
        // 
        // txtCusto
        // 
        txtCusto.Anchor = AnchorStyles.None;
        txtCusto.BackColor = Color.FromArgb(2, 89, 89);
        txtCusto.BorderColor = Color.Empty;
        txtCusto.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtCusto.BorderRadius = 20;
        txtCusto.BorderSize = 2;
        txtCusto.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtCusto.ForeColor = Color.White;
        txtCusto.Location = new Point(545, 302);
        txtCusto.MaxLength = 32767;
        txtCusto.Multiline = false;
        txtCusto.Name = "txtCusto";
        txtCusto.Padding = new Padding(10, 7, 10, 7);
        txtCusto.PasswordChar = false;
        txtCusto.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCusto.PlaceholderText = "";
        txtCusto.SelectionStart = 0;
        txtCusto.Size = new Size(250, 41);
        txtCusto.TabIndex = 4;
        txtCusto.Texts = "0,00";
        txtCusto.UnderlinedStyle = false;
        // 
        // label4
        // 
        label4.Anchor = AnchorStyles.None;
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI Variable Display", 10F);
        label4.Location = new Point(560, 285);
        label4.Name = "label4";
        label4.Size = new Size(46, 19);
        label4.TabIndex = 81;
        label4.Text = "Custo";
        // 
        // txtEstoque
        // 
        txtEstoque.Anchor = AnchorStyles.None;
        txtEstoque.BackColor = Color.FromArgb(2, 89, 89);
        txtEstoque.BorderColor = Color.Empty;
        txtEstoque.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtEstoque.BorderRadius = 20;
        txtEstoque.BorderSize = 2;
        txtEstoque.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtEstoque.ForeColor = Color.White;
        txtEstoque.Location = new Point(545, 226);
        txtEstoque.MaxLength = 32767;
        txtEstoque.Multiline = false;
        txtEstoque.Name = "txtEstoque";
        txtEstoque.Padding = new Padding(10, 7, 10, 7);
        txtEstoque.PasswordChar = false;
        txtEstoque.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtEstoque.PlaceholderText = "";
        txtEstoque.SelectionStart = 0;
        txtEstoque.Size = new Size(250, 41);
        txtEstoque.TabIndex = 2;
        txtEstoque.Texts = "0";
        txtEstoque.UnderlinedStyle = false;
        // 
        // label5
        // 
        label5.Anchor = AnchorStyles.None;
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI Variable Display", 10F);
        label5.Location = new Point(560, 209);
        label5.Name = "label5";
        label5.Size = new Size(58, 19);
        label5.TabIndex = 83;
        label5.Text = "Estoque";
        // 
        // label6
        // 
        label6.Anchor = AnchorStyles.None;
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI Variable Display", 10F);
        label6.Location = new Point(560, 364);
        label6.Name = "label6";
        label6.Size = new Size(125, 19);
        label6.TabIndex = 84;
        label6.Text = "Unidade de Medida";
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.None;
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI Variable Display", 10F);
        label7.Location = new Point(214, 364);
        label7.Name = "label7";
        label7.Size = new Size(79, 19);
        label7.TabIndex = 86;
        label7.Text = "Fornecedor";
        // 
        // cbFornecedor
        // 
        cbFornecedor.Anchor = AnchorStyles.None;
        cbFornecedor.BackColor = Color.FromArgb(2, 89, 89);
        cbFornecedor.DropDownStyle = ComboBoxStyle.DropDownList;
        cbFornecedor.FlatStyle = FlatStyle.Flat;
        cbFornecedor.Font = new Font("Segoe UI Variable Display", 16F);
        cbFornecedor.ForeColor = Color.White;
        cbFornecedor.FormattingEnabled = true;
        cbFornecedor.Location = new Point(214, 381);
        cbFornecedor.Name = "cbFornecedor";
        cbFornecedor.Size = new Size(235, 36);
        cbFornecedor.TabIndex = 5;
        // 
        // label8
        // 
        label8.Anchor = AnchorStyles.None;
        label8.AutoSize = true;
        label8.Font = new Font("Segoe UI Variable Display", 10F);
        label8.Location = new Point(214, 159);
        label8.Name = "label8";
        label8.Size = new Size(121, 19);
        label8.TabIndex = 87;
        label8.Text = "Data de Cadastro: ";
        // 
        // lblDataCadastro
        // 
        lblDataCadastro.Anchor = AnchorStyles.None;
        lblDataCadastro.AutoSize = true;
        lblDataCadastro.Font = new Font("Segoe UI Variable Display", 10F);
        lblDataCadastro.Location = new Point(341, 159);
        lblDataCadastro.Name = "lblDataCadastro";
        lblDataCadastro.Size = new Size(85, 19);
        lblDataCadastro.TabIndex = 88;
        lblDataCadastro.Text = "00/00/0000";
        // 
        // FormCadProdutos
        // 
        AllowRoundedCorners = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 724);
        CloseButtonVisible = false;
        Controls.Add(lblDataCadastro);
        Controls.Add(label8);
        Controls.Add(cbFornecedor);
        Controls.Add(txtEstoque);
        Controls.Add(label5);
        Controls.Add(txtCusto);
        Controls.Add(label4);
        Controls.Add(txtPreco);
        Controls.Add(label3);
        Controls.Add(btnAtivaInativa);
        Controls.Add(txtNome);
        Controls.Add(btnVoltar);
        Controls.Add(btnSalvar);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(cbUN);
        Controls.Add(label6);
        Controls.Add(label7);
        IconSize = new Size(0, 0);
        MinimizeBox = false;
        MinimumSize = new Size(1024, 768);
        Name = "FormCadProdutos";
        StartPosition = FormStartPosition.CenterParent;
        Style.InactiveShadowOpacity = 0;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Style.ShadowOpacity = 0;
        Style.TitleBar.BackColor = Color.WhiteSmoke;
        WindowState = FormWindowState.Maximized;
        Load += FormCadProdutos_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox cbUN;
    private RJControls.RJButton btnAtivaInativa;
    private RJControls.RJTextBox txtNome;
    private RJControls.RJButton btnVoltar;
    private RJControls.RJButton btnSalvar;
    private Label label1;
    private Label label2;
    private RJControls.RJTextBox txtPreco;
    private Label label3;
    private RJControls.RJTextBox txtCusto;
    private Label label4;
    private RJControls.RJTextBox txtEstoque;
    private Label label5;
    private Label label6;
    private Label label7;
    private ComboBox cbFornecedor;
    private Label label8;
    private Label lblDataCadastro;
}