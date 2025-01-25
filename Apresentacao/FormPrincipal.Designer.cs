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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
        pnTopo = new Panel();
        pageSizeControl1 = new Syncfusion.Windows.Forms.Diagram.PageSizeControl();
        pictureBox1 = new PictureBox();
        pnLateral = new Panel();
        btnUsuarios = new RJControls.RJButton();
        btnConsultaVendas = new RJControls.RJButton();
        btnEstoque = new RJControls.RJButton();
        btnVender = new RJControls.RJButton();
        btnClientes = new RJControls.RJButton();
        btnProdutos = new RJControls.RJButton();
        btnInicio = new RJControls.RJButton();
        pnMeio = new Panel();
        pnTopo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        pnLateral.SuspendLayout();
        SuspendLayout();
        // 
        // pnTopo
        // 
        pnTopo.BackColor = Color.White;
        pnTopo.Controls.Add(pageSizeControl1);
        pnTopo.Controls.Add(pictureBox1);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(0, 0);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(1008, 74);
        pnTopo.TabIndex = 0;
        // 
        // pageSizeControl1
        // 
        pageSizeControl1.Location = new Point(598, 71);
        pageSizeControl1.Margin = new Padding(4, 3, 4, 3);
        pageSizeControl1.Name = "pageSizeControl1";
        pageSizeControl1.Size = new Size(258, 308);
        pageSizeControl1.TabIndex = 1;
        // 
        // pictureBox1
        // 
        pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
        pictureBox1.Location = new Point(3, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(209, 68);
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // pnLateral
        // 
        pnLateral.Controls.Add(btnUsuarios);
        pnLateral.Controls.Add(btnConsultaVendas);
        pnLateral.Controls.Add(btnEstoque);
        pnLateral.Controls.Add(btnVender);
        pnLateral.Controls.Add(btnClientes);
        pnLateral.Controls.Add(btnProdutos);
        pnLateral.Controls.Add(btnInicio);
        pnLateral.Dock = DockStyle.Left;
        pnLateral.Location = new Point(0, 74);
        pnLateral.Name = "pnLateral";
        pnLateral.Size = new Size(212, 655);
        pnLateral.TabIndex = 1;
        // 
        // btnUsuarios
        // 
        btnUsuarios.BackColor = Color.LightGray;
        btnUsuarios.BackgroundColor = Color.LightGray;
        btnUsuarios.BorderColor = Color.Empty;
        btnUsuarios.BorderRadius = 20;
        btnUsuarios.BorderSize = 0;
        btnUsuarios.FlatAppearance.BorderSize = 0;
        btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnUsuarios.FlatStyle = FlatStyle.Flat;
        btnUsuarios.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnUsuarios.ForeColor = Color.Black;
        btnUsuarios.Location = new Point(12, 490);
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Size = new Size(187, 41);
        btnUsuarios.TabIndex = 25;
        btnUsuarios.Text = "Usuários";
        btnUsuarios.TextColor = Color.Black;
        btnUsuarios.UseVisualStyleBackColor = false;
        btnUsuarios.Click += btnUsuarios_Click;
        // 
        // btnConsultaVendas
        // 
        btnConsultaVendas.BackColor = Color.LightGray;
        btnConsultaVendas.BackgroundColor = Color.LightGray;
        btnConsultaVendas.BorderColor = Color.Empty;
        btnConsultaVendas.BorderRadius = 20;
        btnConsultaVendas.BorderSize = 0;
        btnConsultaVendas.FlatAppearance.BorderSize = 0;
        btnConsultaVendas.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnConsultaVendas.FlatStyle = FlatStyle.Flat;
        btnConsultaVendas.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnConsultaVendas.ForeColor = Color.Black;
        btnConsultaVendas.Location = new Point(12, 342);
        btnConsultaVendas.Name = "btnConsultaVendas";
        btnConsultaVendas.Size = new Size(187, 41);
        btnConsultaVendas.TabIndex = 24;
        btnConsultaVendas.Text = "Consultar Vendas";
        btnConsultaVendas.TextColor = Color.Black;
        btnConsultaVendas.UseVisualStyleBackColor = false;
        // 
        // btnEstoque
        // 
        btnEstoque.BackColor = Color.LightGray;
        btnEstoque.BackgroundColor = Color.LightGray;
        btnEstoque.BorderColor = Color.Empty;
        btnEstoque.BorderRadius = 20;
        btnEstoque.BorderSize = 0;
        btnEstoque.FlatAppearance.BorderSize = 0;
        btnEstoque.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnEstoque.FlatStyle = FlatStyle.Flat;
        btnEstoque.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEstoque.ForeColor = Color.Black;
        btnEstoque.Location = new Point(12, 417);
        btnEstoque.Name = "btnEstoque";
        btnEstoque.Size = new Size(187, 41);
        btnEstoque.TabIndex = 23;
        btnEstoque.Text = "Estoque";
        btnEstoque.TextColor = Color.Black;
        btnEstoque.UseVisualStyleBackColor = false;
        // 
        // btnVender
        // 
        btnVender.BackColor = Color.LightGray;
        btnVender.BackgroundColor = Color.LightGray;
        btnVender.BorderColor = Color.Empty;
        btnVender.BorderRadius = 20;
        btnVender.BorderSize = 0;
        btnVender.FlatAppearance.BorderSize = 0;
        btnVender.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnVender.FlatStyle = FlatStyle.Flat;
        btnVender.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnVender.ForeColor = Color.Black;
        btnVender.Location = new Point(12, 265);
        btnVender.Name = "btnVender";
        btnVender.Size = new Size(187, 41);
        btnVender.TabIndex = 22;
        btnVender.Text = "Vender";
        btnVender.TextColor = Color.Black;
        btnVender.UseVisualStyleBackColor = false;
        // 
        // btnClientes
        // 
        btnClientes.BackColor = Color.LightGray;
        btnClientes.BackgroundColor = Color.LightGray;
        btnClientes.BorderColor = Color.Empty;
        btnClientes.BorderRadius = 20;
        btnClientes.BorderSize = 0;
        btnClientes.FlatAppearance.BorderSize = 0;
        btnClientes.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnClientes.FlatStyle = FlatStyle.Flat;
        btnClientes.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnClientes.ForeColor = Color.Black;
        btnClientes.Location = new Point(12, 189);
        btnClientes.Name = "btnClientes";
        btnClientes.Size = new Size(187, 41);
        btnClientes.TabIndex = 21;
        btnClientes.Text = "Clientes";
        btnClientes.TextColor = Color.Black;
        btnClientes.UseVisualStyleBackColor = false;
        // 
        // btnProdutos
        // 
        btnProdutos.BackColor = Color.LightGray;
        btnProdutos.BackgroundColor = Color.LightGray;
        btnProdutos.BorderColor = Color.Empty;
        btnProdutos.BorderRadius = 20;
        btnProdutos.BorderSize = 0;
        btnProdutos.FlatAppearance.BorderSize = 0;
        btnProdutos.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnProdutos.FlatStyle = FlatStyle.Flat;
        btnProdutos.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnProdutos.ForeColor = Color.Black;
        btnProdutos.Location = new Point(12, 114);
        btnProdutos.Name = "btnProdutos";
        btnProdutos.Size = new Size(187, 41);
        btnProdutos.TabIndex = 20;
        btnProdutos.Text = "Produtos";
        btnProdutos.TextColor = Color.Black;
        btnProdutos.UseVisualStyleBackColor = false;
        // 
        // btnInicio
        // 
        btnInicio.BackColor = Color.LightGray;
        btnInicio.BackgroundColor = Color.LightGray;
        btnInicio.BorderColor = Color.Empty;
        btnInicio.BorderRadius = 20;
        btnInicio.BorderSize = 0;
        btnInicio.FlatAppearance.BorderSize = 0;
        btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 117, 125);
        btnInicio.FlatStyle = FlatStyle.Flat;
        btnInicio.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnInicio.ForeColor = Color.Black;
        btnInicio.Location = new Point(12, 37);
        btnInicio.Name = "btnInicio";
        btnInicio.Size = new Size(187, 41);
        btnInicio.TabIndex = 19;
        btnInicio.Text = "Inicio";
        btnInicio.TextColor = Color.Black;
        btnInicio.UseVisualStyleBackColor = false;
        // 
        // pnMeio
        // 
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(212, 74);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(796, 655);
        pnMeio.TabIndex = 2;
        // 
        // FormPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1008, 729);
        Controls.Add(pnMeio);
        Controls.Add(pnLateral);
        Controls.Add(pnTopo);
        MinimumSize = new Size(1024, 768);
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FormPrincipal";
        WindowState = FormWindowState.Maximized;
        pnTopo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        pnLateral.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnTopo;
    private Panel pnLateral;
    private Panel pnMeio;
    private RJControls.RJButton btnVender;
    private RJControls.RJButton btnClientes;
    private RJControls.RJButton btnProdutos;
    private RJControls.RJButton btnInicio;
    private RJControls.RJButton btnEstoque;
    private PictureBox pictureBox1;
    private RJControls.RJButton btnConsultaVendas;
    private Syncfusion.Windows.Forms.Diagram.PageSizeControl pageSizeControl1;
    private RJControls.RJButton btnUsuarios;
}