namespace SistemaERP.Apresentacao;

partial class FormProdutos
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
        btnNovo = new SistemaERP.RJControls.RJButton();
        btnEditar = new SistemaERP.RJControls.RJButton();
        txtPesquisa = new SistemaERP.RJControls.RJTextBox();
        txtCNPJ = new SistemaERP.RJControls.RJTextBox();
        cbInativos = new CheckBox();
        pnMeio = new Panel();
        dgProdutos = new Syncfusion.WinForms.DataGrid.SfDataGrid();
        pnTopo.SuspendLayout();
        pnMeio.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgProdutos).BeginInit();
        SuspendLayout();
        // 
        // pnTopo
        // 
        pnTopo.Controls.Add(btnNovo);
        pnTopo.Controls.Add(btnEditar);
        pnTopo.Controls.Add(txtPesquisa);
        pnTopo.Controls.Add(txtCNPJ);
        pnTopo.Controls.Add(cbInativos);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(0, 0);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(1024, 68);
        pnTopo.TabIndex = 29;
        // 
        // btnNovo
        // 
        btnNovo.Anchor = AnchorStyles.Right;
        btnNovo.BackColor = Color.FromArgb(2, 89, 89);
        btnNovo.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnNovo.BorderColor = Color.Empty;
        btnNovo.BorderRadius = 20;
        btnNovo.BorderSize = 0;
        btnNovo.FlatAppearance.BorderColor = Color.DarkBlue;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnNovo.ForeColor = Color.White;
        btnNovo.Location = new Point(940, 12);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(72, 41);
        btnNovo.TabIndex = 38;
        btnNovo.Text = "Novo";
        btnNovo.TextColor = Color.White;
        btnNovo.UseVisualStyleBackColor = false;
        // 
        // btnEditar
        // 
        btnEditar.Anchor = AnchorStyles.Right;
        btnEditar.BackColor = Color.FromArgb(2, 89, 89);
        btnEditar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnEditar.BorderColor = Color.Empty;
        btnEditar.BorderRadius = 20;
        btnEditar.BorderSize = 0;
        btnEditar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnEditar.FlatStyle = FlatStyle.Flat;
        btnEditar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEditar.ForeColor = Color.White;
        btnEditar.Location = new Point(861, 12);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(73, 41);
        btnEditar.TabIndex = 39;
        btnEditar.Text = "Editar";
        btnEditar.TextColor = Color.White;
        btnEditar.UseVisualStyleBackColor = false;
        // 
        // txtPesquisa
        // 
        txtPesquisa.BackColor = Color.FromArgb(2, 89, 89);
        txtPesquisa.BorderColor = Color.Empty;
        txtPesquisa.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtPesquisa.BorderRadius = 20;
        txtPesquisa.BorderSize = 2;
        txtPesquisa.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtPesquisa.ForeColor = Color.White;
        txtPesquisa.Location = new Point(194, 12);
        txtPesquisa.MaxLength = 32767;
        txtPesquisa.Multiline = false;
        txtPesquisa.Name = "txtPesquisa";
        txtPesquisa.Padding = new Padding(10, 7, 10, 7);
        txtPesquisa.PasswordChar = false;
        txtPesquisa.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtPesquisa.PlaceholderText = "Pesquisar";
        txtPesquisa.SelectionStart = 0;
        txtPesquisa.Size = new Size(250, 41);
        txtPesquisa.TabIndex = 33;
        txtPesquisa.Texts = "";
        txtPesquisa.UnderlinedStyle = false;
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
        txtCNPJ.Location = new Point(466, -469);
        txtCNPJ.MaxLength = 32767;
        txtCNPJ.Multiline = false;
        txtCNPJ.Name = "txtCNPJ";
        txtCNPJ.Padding = new Padding(10, 7, 10, 7);
        txtCNPJ.PasswordChar = false;
        txtCNPJ.PlaceholderColor = Color.FromArgb(191, 189, 180);
        txtCNPJ.PlaceholderText = "";
        txtCNPJ.SelectionStart = 0;
        txtCNPJ.Size = new Size(250, 41);
        txtCNPJ.TabIndex = 37;
        txtCNPJ.Texts = "";
        txtCNPJ.UnderlinedStyle = false;
        // 
        // cbInativos
        // 
        cbInativos.AutoSize = true;
        cbInativos.Font = new Font("Segoe UI Variable Display", 11.25F);
        cbInativos.Location = new Point(21, 22);
        cbInativos.Name = "cbInativos";
        cbInativos.Size = new Size(167, 24);
        cbInativos.TabIndex = 34;
        cbInativos.Text = "Ver produtos inativos";
        cbInativos.UseVisualStyleBackColor = true;
        // 
        // pnMeio
        // 
        pnMeio.Controls.Add(dgProdutos);
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(0, 68);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(1024, 700);
        pnMeio.TabIndex = 30;
        // 
        // dgProdutos
        // 
        dgProdutos.AccessibleName = "Table";
        dgProdutos.AllowEditing = false;
        dgProdutos.AllowFiltering = true;
        dgProdutos.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
        dgProdutos.BackColor = Color.White;
        dgProdutos.Dock = DockStyle.Fill;
        dgProdutos.ForeColor = Color.Black;
        dgProdutos.Location = new Point(0, 0);
        dgProdutos.Name = "dgProdutos";
        dgProdutos.Size = new Size(1024, 700);
        dgProdutos.Style.BorderColor = Color.FromArgb(100, 100, 100);
        dgProdutos.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
        dgProdutos.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
        dgProdutos.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
        dgProdutos.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
        dgProdutos.TabIndex = 0;
        dgProdutos.Text = "dgUsuarios";
        // 
        // FormProdutos
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1024, 768);
        ControlBox = false;
        Controls.Add(pnMeio);
        Controls.Add(pnTopo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormProdutos";
        StartPosition = FormStartPosition.CenterParent;
        WindowState = FormWindowState.Maximized;
        Load += FormProdutos_Load;
        pnTopo.ResumeLayout(false);
        pnTopo.PerformLayout();
        pnMeio.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgProdutos).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnTopo;
    private RJControls.RJTextBox txtPesquisa;
    private RJControls.RJTextBox txtCNPJ;   
    private CheckBox cbInativos;
    private RJControls.RJButton btnNovo;
    private RJControls.RJButton btnEditar;
    private Panel pnMeio;
    private Syncfusion.WinForms.DataGrid.SfDataGrid dgProdutos;
}