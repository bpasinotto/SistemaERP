namespace SistemaERP.Apresentacao;

partial class FormPrincipal
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
        pnTopo = new Panel();
        btnFornecedores = new SistemaERP.RJControls.RJButton();
        btnUsuarios = new SistemaERP.RJControls.RJButton();
        btnTrocarUsuario = new SistemaERP.RJControls.RJButton();
        btnConsultaVendas = new SistemaERP.RJControls.RJButton();
        btnSair = new SistemaERP.RJControls.RJButton();
        btnInicio = new SistemaERP.RJControls.RJButton();
        btnVender = new SistemaERP.RJControls.RJButton();
        pageSizeControl1 = new Syncfusion.Windows.Forms.Diagram.PageSizeControl();
        btnProdutos = new SistemaERP.RJControls.RJButton();
        btnEstoque = new SistemaERP.RJControls.RJButton();
        btnClientes = new SistemaERP.RJControls.RJButton();
        pnMeio = new Panel();
        pnBaixo = new Panel();
        label1 = new Label();
        cbTema = new ComboBox();
        lblUsuarioLogado = new Label();
        pnTopo.SuspendLayout();
        pnBaixo.SuspendLayout();
        SuspendLayout();
        // 
        // pnTopo
        // 
        pnTopo.BackColor = Color.White;
        pnTopo.Controls.Add(btnFornecedores);
        pnTopo.Controls.Add(btnUsuarios);
        pnTopo.Controls.Add(btnTrocarUsuario);
        pnTopo.Controls.Add(btnConsultaVendas);
        pnTopo.Controls.Add(btnSair);
        pnTopo.Controls.Add(btnInicio);
        pnTopo.Controls.Add(btnVender);
        pnTopo.Controls.Add(pageSizeControl1);
        pnTopo.Controls.Add(btnProdutos);
        pnTopo.Controls.Add(btnEstoque);
        pnTopo.Controls.Add(btnClientes);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(2, 2);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(996, 74);
        pnTopo.TabIndex = 0;
        // 
        // btnFornecedores
        // 
        btnFornecedores.BackColor = Color.LightGray;
        btnFornecedores.BackgroundColor = Color.LightGray;
        btnFornecedores.BorderColor = Color.Empty;
        btnFornecedores.BorderRadius = 20;
        btnFornecedores.BorderSize = 0;
        btnFornecedores.FlatAppearance.BorderSize = 0;
        btnFornecedores.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnFornecedores.FlatStyle = FlatStyle.Flat;
        btnFornecedores.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnFornecedores.ForeColor = Color.Black;
        btnFornecedores.Location = new Point(699, 15);
        btnFornecedores.Name = "btnFornecedores";
        btnFornecedores.Size = new Size(119, 41);
        btnFornecedores.TabIndex = 26;
        btnFornecedores.Text = "Fornecedores";
        btnFornecedores.TextColor = Color.Black;
        btnFornecedores.UseVisualStyleBackColor = false;
        btnFornecedores.Click += btnFornecedores_Click;
        // 
        // btnUsuarios
        // 
        btnUsuarios.BackColor = Color.LightGray;
        btnUsuarios.BackgroundColor = Color.LightGray;
        btnUsuarios.BorderColor = Color.Empty;
        btnUsuarios.BorderRadius = 20;
        btnUsuarios.BorderSize = 0;
        btnUsuarios.FlatAppearance.BorderSize = 0;
        btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnUsuarios.FlatStyle = FlatStyle.Flat;
        btnUsuarios.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnUsuarios.ForeColor = Color.Black;
        btnUsuarios.Location = new Point(606, 15);
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Size = new Size(87, 41);
        btnUsuarios.TabIndex = 25;
        btnUsuarios.Text = "Usuários";
        btnUsuarios.TextColor = Color.Black;
        btnUsuarios.UseVisualStyleBackColor = false;
        btnUsuarios.Click += btnUsuarios_Click;
        // 
        // btnTrocarUsuario
        // 
        btnTrocarUsuario.Anchor = AnchorStyles.Right;
        btnTrocarUsuario.BackColor = Color.FromArgb(2, 89, 89);
        btnTrocarUsuario.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnTrocarUsuario.BorderColor = Color.Empty;
        btnTrocarUsuario.BorderRadius = 20;
        btnTrocarUsuario.BorderSize = 0;
        btnTrocarUsuario.FlatAppearance.BorderColor = Color.DarkBlue;
        btnTrocarUsuario.FlatStyle = FlatStyle.Flat;
        btnTrocarUsuario.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnTrocarUsuario.ForeColor = Color.White;
        btnTrocarUsuario.Location = new Point(794, 15);
        btnTrocarUsuario.Name = "btnTrocarUsuario";
        btnTrocarUsuario.Size = new Size(127, 41);
        btnTrocarUsuario.TabIndex = 24;
        btnTrocarUsuario.Text = "Trocar Usuário";
        btnTrocarUsuario.TextColor = Color.White;
        btnTrocarUsuario.UseVisualStyleBackColor = false;
        btnTrocarUsuario.Click += btnTrocarUsuario_Click;
        // 
        // btnConsultaVendas
        // 
        btnConsultaVendas.BackColor = Color.LightGray;
        btnConsultaVendas.BackgroundColor = Color.LightGray;
        btnConsultaVendas.BorderColor = Color.Empty;
        btnConsultaVendas.BorderRadius = 20;
        btnConsultaVendas.BorderSize = 0;
        btnConsultaVendas.FlatAppearance.BorderSize = 0;
        btnConsultaVendas.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnConsultaVendas.FlatStyle = FlatStyle.Flat;
        btnConsultaVendas.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnConsultaVendas.ForeColor = Color.Black;
        btnConsultaVendas.Location = new Point(364, 15);
        btnConsultaVendas.Name = "btnConsultaVendas";
        btnConsultaVendas.Size = new Size(146, 41);
        btnConsultaVendas.TabIndex = 24;
        btnConsultaVendas.Text = "Consultar Vendas";
        btnConsultaVendas.TextColor = Color.Black;
        btnConsultaVendas.UseVisualStyleBackColor = false;
        // 
        // btnSair
        // 
        btnSair.Anchor = AnchorStyles.Right;
        btnSair.BackColor = Color.FromArgb(2, 89, 89);
        btnSair.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnSair.BorderColor = Color.Empty;
        btnSair.BorderRadius = 20;
        btnSair.BorderSize = 0;
        btnSair.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSair.FlatStyle = FlatStyle.Flat;
        btnSair.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnSair.ForeColor = Color.White;
        btnSair.Location = new Point(927, 15);
        btnSair.Name = "btnSair";
        btnSair.Size = new Size(57, 41);
        btnSair.TabIndex = 23;
        btnSair.Text = "Sair";
        btnSair.TextColor = Color.White;
        btnSair.UseVisualStyleBackColor = false;
        btnSair.Click += btnSair_Click;
        // 
        // btnInicio
        // 
        btnInicio.BackColor = Color.LightGray;
        btnInicio.BackgroundColor = Color.LightGray;
        btnInicio.BorderColor = Color.Empty;
        btnInicio.BorderRadius = 20;
        btnInicio.BorderSize = 0;
        btnInicio.FlatAppearance.BorderSize = 0;
        btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnInicio.FlatStyle = FlatStyle.Flat;
        btnInicio.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnInicio.ForeColor = Color.Black;
        btnInicio.Location = new Point(12, 15);
        btnInicio.Name = "btnInicio";
        btnInicio.Size = new Size(73, 41);
        btnInicio.TabIndex = 19;
        btnInicio.Text = "Inicio";
        btnInicio.TextColor = Color.Black;
        btnInicio.UseVisualStyleBackColor = false;
        btnInicio.Click += btnInicio_Click;
        // 
        // btnVender
        // 
        btnVender.BackColor = Color.LightGray;
        btnVender.BackgroundColor = Color.LightGray;
        btnVender.BorderColor = Color.Empty;
        btnVender.BorderRadius = 20;
        btnVender.BorderSize = 0;
        btnVender.FlatAppearance.BorderSize = 0;
        btnVender.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnVender.FlatStyle = FlatStyle.Flat;
        btnVender.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnVender.ForeColor = Color.Black;
        btnVender.Location = new Point(281, 15);
        btnVender.Name = "btnVender";
        btnVender.Size = new Size(77, 41);
        btnVender.TabIndex = 22;
        btnVender.Text = "Vender";
        btnVender.TextColor = Color.Black;
        btnVender.UseVisualStyleBackColor = false;
        // 
        // pageSizeControl1
        // 
        pageSizeControl1.Location = new Point(598, 71);
        pageSizeControl1.Margin = new Padding(4, 3, 4, 3);
        pageSizeControl1.Name = "pageSizeControl1";
        pageSizeControl1.Size = new Size(258, 308);
        pageSizeControl1.TabIndex = 1;
        // 
        // btnProdutos
        // 
        btnProdutos.BackColor = Color.LightGray;
        btnProdutos.BackgroundColor = Color.LightGray;
        btnProdutos.BorderColor = Color.Empty;
        btnProdutos.BorderRadius = 20;
        btnProdutos.BorderSize = 0;
        btnProdutos.FlatAppearance.BorderSize = 0;
        btnProdutos.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnProdutos.FlatStyle = FlatStyle.Flat;
        btnProdutos.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnProdutos.ForeColor = Color.Black;
        btnProdutos.Location = new Point(91, 15);
        btnProdutos.Name = "btnProdutos";
        btnProdutos.Size = new Size(94, 41);
        btnProdutos.TabIndex = 20;
        btnProdutos.Text = "Produtos";
        btnProdutos.TextColor = Color.Black;
        btnProdutos.UseVisualStyleBackColor = false;
        btnProdutos.Click += btnProdutos_Click;
        // 
        // btnEstoque
        // 
        btnEstoque.BackColor = Color.LightGray;
        btnEstoque.BackgroundColor = Color.LightGray;
        btnEstoque.BorderColor = Color.Empty;
        btnEstoque.BorderRadius = 20;
        btnEstoque.BorderSize = 0;
        btnEstoque.FlatAppearance.BorderSize = 0;
        btnEstoque.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnEstoque.FlatStyle = FlatStyle.Flat;
        btnEstoque.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEstoque.ForeColor = Color.Black;
        btnEstoque.Location = new Point(516, 15);
        btnEstoque.Name = "btnEstoque";
        btnEstoque.Size = new Size(84, 41);
        btnEstoque.TabIndex = 23;
        btnEstoque.Text = "Estoque";
        btnEstoque.TextColor = Color.Black;
        btnEstoque.UseVisualStyleBackColor = false;
        // 
        // btnClientes
        // 
        btnClientes.BackColor = Color.LightGray;
        btnClientes.BackgroundColor = Color.LightGray;
        btnClientes.BorderColor = Color.Empty;
        btnClientes.BorderRadius = 20;
        btnClientes.BorderSize = 0;
        btnClientes.FlatAppearance.BorderSize = 0;
        btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(2, 89, 89);
        btnClientes.FlatStyle = FlatStyle.Flat;
        btnClientes.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnClientes.ForeColor = Color.Black;
        btnClientes.Location = new Point(191, 15);
        btnClientes.Name = "btnClientes";
        btnClientes.Size = new Size(84, 41);
        btnClientes.TabIndex = 21;
        btnClientes.Text = "Clientes";
        btnClientes.TextColor = Color.Black;
        btnClientes.UseVisualStyleBackColor = false;
        btnClientes.Click += btnClientes_Click;
        // 
        // pnMeio
        // 
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(2, 76);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(996, 618);
        pnMeio.TabIndex = 2;
        // 
        // pnBaixo
        // 
        pnBaixo.Controls.Add(label1);
        pnBaixo.Controls.Add(cbTema);
        pnBaixo.Controls.Add(lblUsuarioLogado);
        pnBaixo.Dock = DockStyle.Bottom;
        pnBaixo.Location = new Point(2, 694);
        pnBaixo.Name = "pnBaixo";
        pnBaixo.Size = new Size(996, 28);
        pnBaixo.TabIndex = 3;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display", 11.25F);
        label1.Location = new Point(844, 3);
        label1.Name = "label1";
        label1.Size = new Size(47, 20);
        label1.TabIndex = 3;
        label1.Text = "Tema:";
        label1.Click += label1_Click;
        // 
        // cbTema
        // 
        cbTema.Anchor = AnchorStyles.Right;
        cbTema.FormattingEnabled = true;
        cbTema.Location = new Point(894, 2);
        cbTema.Name = "cbTema";
        cbTema.Size = new Size(90, 23);
        cbTema.TabIndex = 2;
        cbTema.SelectedIndexChanged += cbTema_SelectedIndexChanged;
        // 
        // lblUsuarioLogado
        // 
        lblUsuarioLogado.Font = new Font("Segoe UI Variable Display", 11.25F);
        lblUsuarioLogado.Location = new Point(12, 3);
        lblUsuarioLogado.Name = "lblUsuarioLogado";
        lblUsuarioLogado.Size = new Size(192, 20);
        lblUsuarioLogado.TabIndex = 1;
        lblUsuarioLogado.Text = "Usuário:";
        // 
        // FormPrincipal
        // 
        AllowRoundedCorners = true;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1000, 724);
        Controls.Add(pnMeio);
        Controls.Add(pnBaixo);
        Controls.Add(pnTopo);
        MinimumSize = new Size(1024, 768);
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Style.BackColor = Color.WhiteSmoke;
        Style.InactiveShadowOpacity = 0;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Style.ShadowOpacity = 0;
        Style.TitleBar.BackColor = Color.WhiteSmoke;
        Text = "PasiWare";
        WindowState = FormWindowState.Maximized;
        Load += FormPrincipal_Load;
        pnTopo.ResumeLayout(false);
        pnBaixo.ResumeLayout(false);
        pnBaixo.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnTopo;
    private Panel pnMeio;
    private RJControls.RJButton btnVender;
    private RJControls.RJButton btnClientes;
    private RJControls.RJButton btnProdutos;
    private RJControls.RJButton btnInicio;
    private RJControls.RJButton btnEstoque;
    private RJControls.RJButton btnConsultaVendas;
    private Syncfusion.Windows.Forms.Diagram.PageSizeControl pageSizeControl1;
    private RJControls.RJButton btnUsuarios;
    private RJControls.RJButton btnSair;
    private RJControls.RJButton btnTrocarUsuario;
    private Panel pnBaixo;
    private Label lblUsuarioLogado;
    internal ComboBox cbTema;
    private Label label1;
    private RJControls.RJButton btnFornecedores;
}