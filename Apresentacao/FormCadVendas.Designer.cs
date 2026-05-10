namespace SistemaERP.Apresentacao;

partial class FormCadVendas
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
        txtCodCliente = new SistemaERP.RJControls.RJTextBox();
        label2 = new Label();
        lblNomeCliente = new Label();
        txtCodProduto = new SistemaERP.RJControls.RJTextBox();
        label1 = new Label();
        cbVendedor = new ComboBox();
        label7 = new Label();
        txtQuantidade = new SistemaERP.RJControls.RJTextBox();
        label3 = new Label();
        txtPrecoUnit = new SistemaERP.RJControls.RJTextBox();
        label4 = new Label();
        rjTextBox1 = new SistemaERP.RJControls.RJTextBox();
        label5 = new Label();
        btnBuscaCliente = new FontAwesome.Sharp.IconButton();
        btnVoltar = new SistemaERP.RJControls.RJButton();
        btnSalvar = new SistemaERP.RJControls.RJButton();
        pnBaixo = new Panel();
        lblTotalGeral = new Label();
        label6 = new Label();
        pnLateral = new Panel();
        dgProdutosVenda = new DataGridView();
        btnBuscaProduto = new FontAwesome.Sharp.IconButton();
        pnBaixo.SuspendLayout();
        pnLateral.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgProdutosVenda).BeginInit();
        SuspendLayout();
        // 
        // txtCodCliente
        // 
        txtCodCliente.BackColor = Color.FromArgb(2, 89, 89);
        txtCodCliente.BorderColor = Color.Empty;
        txtCodCliente.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtCodCliente.BorderRadius = 20;
        txtCodCliente.BorderSize = 2;
        txtCodCliente.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtCodCliente.ForeColor = Color.White;
        txtCodCliente.Location = new Point(70, 65);
        txtCodCliente.MaxLength = 32767;
        txtCodCliente.Multiline = false;
        txtCodCliente.Name = "txtCodCliente";
        txtCodCliente.Padding = new Padding(10, 7, 10, 7);
        txtCodCliente.PasswordChar = false;
        txtCodCliente.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCodCliente.PlaceholderText = "";
        txtCodCliente.SelectionStart = 0;
        txtCodCliente.Size = new Size(78, 41);
        txtCodCliente.TabIndex = 0;
        txtCodCliente.Texts = "";
        txtCodCliente.UnderlinedStyle = false;
        txtCodCliente._TextChanged += txtCodCliente__TextChanged;
        txtCodCliente.KeyPress += txtCodCliente_KeyPress;
        txtCodCliente.Leave += txtCodCliente_Leave;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI Variable Display", 10F);
        label2.Location = new Point(85, 48);
        label2.Name = "label2";
        label2.Size = new Size(52, 19);
        label2.TabIndex = 77;
        label2.Text = "Cliente";
        // 
        // lblNomeCliente
        // 
        lblNomeCliente.AutoSize = true;
        lblNomeCliente.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNomeCliente.Location = new Point(154, 72);
        lblNomeCliente.MaximumSize = new Size(234, 26);
        lblNomeCliente.Name = "lblNomeCliente";
        lblNomeCliente.Size = new Size(152, 26);
        lblNomeCliente.TabIndex = 78;
        lblNomeCliente.Text = "Nome do Cliente";
        // 
        // txtCodProduto
        // 
        txtCodProduto.BackColor = Color.FromArgb(2, 89, 89);
        txtCodProduto.BorderColor = Color.Empty;
        txtCodProduto.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtCodProduto.BorderRadius = 20;
        txtCodProduto.BorderSize = 2;
        txtCodProduto.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtCodProduto.ForeColor = Color.White;
        txtCodProduto.Location = new Point(70, 236);
        txtCodProduto.MaxLength = 32767;
        txtCodProduto.Multiline = false;
        txtCodProduto.Name = "txtCodProduto";
        txtCodProduto.Padding = new Padding(10, 7, 10, 7);
        txtCodProduto.PasswordChar = false;
        txtCodProduto.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCodProduto.PlaceholderText = "";
        txtCodProduto.SelectionStart = 0;
        txtCodProduto.Size = new Size(255, 41);
        txtCodProduto.TabIndex = 2;
        txtCodProduto.Texts = "";
        txtCodProduto.UnderlinedStyle = false;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display", 10F);
        label1.Location = new Point(85, 219);
        label1.Name = "label1";
        label1.Size = new Size(59, 19);
        label1.TabIndex = 80;
        label1.Text = "Produto";
        // 
        // cbVendedor
        // 
        cbVendedor.BackColor = Color.FromArgb(2, 89, 89);
        cbVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
        cbVendedor.FlatStyle = FlatStyle.Flat;
        cbVendedor.Font = new Font("Segoe UI Variable Display", 16F);
        cbVendedor.ForeColor = Color.White;
        cbVendedor.FormattingEnabled = true;
        cbVendedor.Location = new Point(70, 152);
        cbVendedor.Name = "cbVendedor";
        cbVendedor.Size = new Size(271, 36);
        cbVendedor.TabIndex = 1;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI Variable Display", 10F);
        label7.Location = new Point(85, 134);
        label7.Name = "label7";
        label7.Size = new Size(68, 19);
        label7.TabIndex = 88;
        label7.Text = "Vendedor";
        // 
        // txtQuantidade
        // 
        txtQuantidade.BackColor = Color.FromArgb(2, 89, 89);
        txtQuantidade.BorderColor = Color.Empty;
        txtQuantidade.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtQuantidade.BorderRadius = 20;
        txtQuantidade.BorderSize = 2;
        txtQuantidade.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtQuantidade.ForeColor = Color.White;
        txtQuantidade.Location = new Point(70, 319);
        txtQuantidade.MaxLength = 32767;
        txtQuantidade.Multiline = false;
        txtQuantidade.Name = "txtQuantidade";
        txtQuantidade.Padding = new Padding(10, 7, 10, 7);
        txtQuantidade.PasswordChar = false;
        txtQuantidade.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtQuantidade.PlaceholderText = "";
        txtQuantidade.SelectionStart = 0;
        txtQuantidade.Size = new Size(255, 41);
        txtQuantidade.TabIndex = 3;
        txtQuantidade.Texts = "1";
        txtQuantidade.UnderlinedStyle = false;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI Variable Display", 10F);
        label3.Location = new Point(85, 302);
        label3.Name = "label3";
        label3.Size = new Size(80, 19);
        label3.TabIndex = 90;
        label3.Text = "Quantidade";
        // 
        // txtPrecoUnit
        // 
        txtPrecoUnit.BackColor = Color.FromArgb(2, 89, 89);
        txtPrecoUnit.BorderColor = Color.Empty;
        txtPrecoUnit.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtPrecoUnit.BorderRadius = 20;
        txtPrecoUnit.BorderSize = 2;
        txtPrecoUnit.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtPrecoUnit.ForeColor = Color.White;
        txtPrecoUnit.Location = new Point(70, 403);
        txtPrecoUnit.MaxLength = 32767;
        txtPrecoUnit.Multiline = false;
        txtPrecoUnit.Name = "txtPrecoUnit";
        txtPrecoUnit.Padding = new Padding(10, 7, 10, 7);
        txtPrecoUnit.PasswordChar = false;
        txtPrecoUnit.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtPrecoUnit.PlaceholderText = "";
        txtPrecoUnit.SelectionStart = 0;
        txtPrecoUnit.Size = new Size(255, 41);
        txtPrecoUnit.TabIndex = 4;
        txtPrecoUnit.Texts = "R$: 0,00";
        txtPrecoUnit.UnderlinedStyle = false;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI Variable Display", 10F);
        label4.Location = new Point(85, 386);
        label4.Name = "label4";
        label4.Size = new Size(95, 19);
        label4.TabIndex = 92;
        label4.Text = "Preço Unitário";
        // 
        // rjTextBox1
        // 
        rjTextBox1.BackColor = Color.FromArgb(2, 89, 89);
        rjTextBox1.BorderColor = Color.Empty;
        rjTextBox1.BorderFocusColor = Color.FromArgb(3, 140, 140);
        rjTextBox1.BorderRadius = 20;
        rjTextBox1.BorderSize = 2;
        rjTextBox1.Enabled = false;
        rjTextBox1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        rjTextBox1.ForeColor = Color.White;
        rjTextBox1.Location = new Point(70, 485);
        rjTextBox1.MaxLength = 32767;
        rjTextBox1.Multiline = false;
        rjTextBox1.Name = "rjTextBox1";
        rjTextBox1.Padding = new Padding(10, 7, 10, 7);
        rjTextBox1.PasswordChar = false;
        rjTextBox1.PlaceholderColor = Color.FromArgb(191, 189, 180);
        rjTextBox1.PlaceholderText = "";
        rjTextBox1.SelectionStart = 0;
        rjTextBox1.Size = new Size(255, 41);
        rjTextBox1.TabIndex = 93;
        rjTextBox1.Texts = "R$: 0,00";
        rjTextBox1.UnderlinedStyle = false;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI Variable Display", 10F);
        label5.Location = new Point(85, 468);
        label5.Name = "label5";
        label5.Size = new Size(61, 19);
        label5.TabIndex = 94;
        label5.Text = "Subtotal";
        // 
        // btnBuscaCliente
        // 
        btnBuscaCliente.FlatAppearance.BorderSize = 0;
        btnBuscaCliente.FlatStyle = FlatStyle.Flat;
        btnBuscaCliente.ForeColor = Color.White;
        btnBuscaCliente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
        btnBuscaCliente.IconColor = Color.FromArgb(2, 89, 89);
        btnBuscaCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnBuscaCliente.IconSize = 32;
        btnBuscaCliente.Location = new Point(394, 72);
        btnBuscaCliente.Name = "btnBuscaCliente";
        btnBuscaCliente.Size = new Size(38, 36);
        btnBuscaCliente.TabIndex = 95;
        btnBuscaCliente.TabStop = false;
        btnBuscaCliente.UseVisualStyleBackColor = false;
        btnBuscaCliente.Click += btnBuscaCliente_Click;
        // 
        // btnVoltar
        // 
        btnVoltar.Anchor = AnchorStyles.Left;
        btnVoltar.BackColor = Color.FromArgb(2, 89, 89);
        btnVoltar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnVoltar.BorderColor = Color.Empty;
        btnVoltar.BorderRadius = 20;
        btnVoltar.BorderSize = 0;
        btnVoltar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnVoltar.FlatStyle = FlatStyle.Flat;
        btnVoltar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnVoltar.ForeColor = Color.White;
        btnVoltar.Location = new Point(201, 25);
        btnVoltar.Name = "btnVoltar";
        btnVoltar.Size = new Size(122, 41);
        btnVoltar.TabIndex = 6;
        btnVoltar.TabStop = false;
        btnVoltar.Text = "Voltar";
        btnVoltar.TextColor = Color.White;
        btnVoltar.UseVisualStyleBackColor = false;
        btnVoltar.Click += btnVoltar_Click;
        // 
        // btnSalvar
        // 
        btnSalvar.Anchor = AnchorStyles.Left;
        btnSalvar.BackColor = Color.FromArgb(2, 89, 89);
        btnSalvar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnSalvar.BorderColor = Color.Empty;
        btnSalvar.BorderRadius = 20;
        btnSalvar.BorderSize = 0;
        btnSalvar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnSalvar.ForeColor = Color.White;
        btnSalvar.Location = new Point(68, 25);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(122, 41);
        btnSalvar.TabIndex = 5;
        btnSalvar.TabStop = false;
        btnSalvar.Text = "Salvar";
        btnSalvar.TextColor = Color.White;
        btnSalvar.UseVisualStyleBackColor = false;
        // 
        // pnBaixo
        // 
        pnBaixo.Controls.Add(lblTotalGeral);
        pnBaixo.Controls.Add(label6);
        pnBaixo.Controls.Add(btnSalvar);
        pnBaixo.Controls.Add(btnVoltar);
        pnBaixo.Dock = DockStyle.Bottom;
        pnBaixo.Location = new Point(2, 636);
        pnBaixo.Name = "pnBaixo";
        pnBaixo.Size = new Size(996, 86);
        pnBaixo.TabIndex = 98;
        // 
        // lblTotalGeral
        // 
        lblTotalGeral.Anchor = AnchorStyles.Right;
        lblTotalGeral.AutoSize = true;
        lblTotalGeral.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTotalGeral.Location = new Point(828, 39);
        lblTotalGeral.Name = "lblTotalGeral";
        lblTotalGeral.Size = new Size(110, 36);
        lblTotalGeral.TabIndex = 101;
        lblTotalGeral.Text = "R$ 0,00";
        // 
        // label6
        // 
        label6.Anchor = AnchorStyles.Right;
        label6.AutoSize = true;
        label6.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label6.Location = new Point(832, 13);
        label6.Name = "label6";
        label6.Size = new Size(102, 26);
        label6.TabIndex = 100;
        label6.Text = "Total Geral";
        // 
        // pnLateral
        // 
        pnLateral.Controls.Add(dgProdutosVenda);
        pnLateral.Dock = DockStyle.Right;
        pnLateral.Location = new Point(497, 2);
        pnLateral.Name = "pnLateral";
        pnLateral.Size = new Size(501, 634);
        pnLateral.TabIndex = 99;
        // 
        // dgProdutosVenda
        // 
        dgProdutosVenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgProdutosVenda.Dock = DockStyle.Fill;
        dgProdutosVenda.Location = new Point(0, 0);
        dgProdutosVenda.Name = "dgProdutosVenda";
        dgProdutosVenda.Size = new Size(501, 634);
        dgProdutosVenda.TabIndex = 0;
        // 
        // btnBuscaProduto
        // 
        btnBuscaProduto.FlatAppearance.BorderSize = 0;
        btnBuscaProduto.FlatStyle = FlatStyle.Flat;
        btnBuscaProduto.ForeColor = Color.White;
        btnBuscaProduto.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassPlus;
        btnBuscaProduto.IconColor = Color.FromArgb(2, 89, 89);
        btnBuscaProduto.IconFont = FontAwesome.Sharp.IconFont.Auto;
        btnBuscaProduto.IconSize = 32;
        btnBuscaProduto.Location = new Point(331, 242);
        btnBuscaProduto.Name = "btnBuscaProduto";
        btnBuscaProduto.Size = new Size(38, 36);
        btnBuscaProduto.TabIndex = 100;
        btnBuscaProduto.TabStop = false;
        btnBuscaProduto.UseVisualStyleBackColor = false;
        // 
        // FormCadVendas
        // 
        AllowRoundedCorners = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 724);
        Controls.Add(btnBuscaProduto);
        Controls.Add(pnLateral);
        Controls.Add(pnBaixo);
        Controls.Add(btnBuscaCliente);
        Controls.Add(rjTextBox1);
        Controls.Add(label5);
        Controls.Add(txtPrecoUnit);
        Controls.Add(label4);
        Controls.Add(txtQuantidade);
        Controls.Add(label3);
        Controls.Add(cbVendedor);
        Controls.Add(label7);
        Controls.Add(txtCodProduto);
        Controls.Add(label1);
        Controls.Add(lblNomeCliente);
        Controls.Add(txtCodCliente);
        Controls.Add(label2);
        MinimumSize = new Size(1024, 768);
        Name = "FormCadVendas";
        StartPosition = FormStartPosition.CenterParent;
        Style.InactiveShadowOpacity = 0;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Style.ShadowOpacity = 0;
        Style.TitleBar.BackColor = Color.WhiteSmoke;
        Text = "Nova Venda";
        WindowState = FormWindowState.Maximized;
        pnBaixo.ResumeLayout(false);
        pnBaixo.PerformLayout();
        pnLateral.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgProdutosVenda).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RJControls.RJTextBox txtCodCliente;
    private Label label2;
    private Label lblNomeCliente;
    private RJControls.RJTextBox txtCodProduto;
    private Label label1;
    private ComboBox cbVendedor;
    private Label label7;
    private RJControls.RJTextBox txtQuantidade;
    private Label label3;
    private RJControls.RJTextBox txtPrecoUnit;
    private Label label4;
    private RJControls.RJTextBox rjTextBox1;
    private Label label5;
    private FontAwesome.Sharp.IconButton btnBuscaCliente;
    private RJControls.RJButton btnVoltar;
    private RJControls.RJButton btnSalvar;
    private Panel pnBaixo;
    private Panel pnLateral;
    private Label lblTotalGeral;
    private Label label6;
    private DataGridView dgProdutosVenda;
    private FontAwesome.Sharp.IconButton btnBuscaProduto;
}