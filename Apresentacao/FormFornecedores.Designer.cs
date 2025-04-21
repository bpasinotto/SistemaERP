namespace SistemaERP.Apresentacao;

partial class FormFornecedores
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
        cbInativos = new CheckBox();
        txtCNPJ = new SistemaERP.RJControls.RJTextBox();
        txtPesquisa = new SistemaERP.RJControls.RJTextBox();
        btnEditar = new SistemaERP.RJControls.RJButton();
        btnNovo = new SistemaERP.RJControls.RJButton();
        pnTopo = new Panel();
        pnMeio = new Panel();
        dgFornecedores = new Syncfusion.WinForms.DataGrid.SfDataGrid();
        pnTopo.SuspendLayout();
        pnMeio.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgFornecedores).BeginInit();
        SuspendLayout();
        // 
        // cbInativos
        // 
        cbInativos.AutoSize = true;
        cbInativos.Font = new Font("Segoe UI Variable Display", 11.25F);
        cbInativos.Location = new Point(21, 22);
        cbInativos.Name = "cbInativos";
        cbInativos.Size = new Size(195, 24);
        cbInativos.TabIndex = 34;
        cbInativos.Text = "Ver fornecedores inativos";
        cbInativos.UseVisualStyleBackColor = true;
        cbInativos.CheckedChanged += cbInativos_CheckedChanged;
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
        // txtPesquisa
        // 
        txtPesquisa.BackColor = Color.FromArgb(2, 89, 89);
        txtPesquisa.BorderColor = Color.Empty;
        txtPesquisa.BorderFocusColor = Color.FromArgb(3, 140, 140);
        txtPesquisa.BorderRadius = 20;
        txtPesquisa.BorderSize = 2;
        txtPesquisa.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        txtPesquisa.ForeColor = Color.White;
        txtPesquisa.Location = new Point(222, 12);
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
        txtPesquisa._TextChanged += txtPesquisa__TextChanged;
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
        btnEditar.Click += btnEditar_Click;
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
        btnNovo.Click += btnNovo_Click;
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
        // pnMeio
        // 
        pnMeio.Controls.Add(dgFornecedores);
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(0, 68);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(1024, 700);
        pnMeio.TabIndex = 32;
        // 
        // dgFornecedores
        // 
        dgFornecedores.AccessibleName = "Table";
        dgFornecedores.AllowEditing = false;
        dgFornecedores.AllowFiltering = true;
        dgFornecedores.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
        dgFornecedores.BackColor = Color.White;
        dgFornecedores.Dock = DockStyle.Fill;
        dgFornecedores.ForeColor = Color.Black;
        dgFornecedores.Location = new Point(0, 0);
        dgFornecedores.Name = "dgFornecedores";
        dgFornecedores.Size = new Size(1024, 700);
        dgFornecedores.Style.BorderColor = Color.FromArgb(100, 100, 100);
        dgFornecedores.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
        dgFornecedores.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
        dgFornecedores.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
        dgFornecedores.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
        dgFornecedores.TabIndex = 0;
        // 
        // FormFornecedores
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1024, 768);
        ControlBox = false;
        Controls.Add(pnMeio);
        Controls.Add(pnTopo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormFornecedores";
        StartPosition = FormStartPosition.CenterParent;
        WindowState = FormWindowState.Maximized;
        Load += FormFornecedores_Load;
        pnTopo.ResumeLayout(false);
        pnTopo.PerformLayout();
        pnMeio.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgFornecedores).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private CheckBox cbInativos;
    private RJControls.RJTextBox txtCNPJ;
    private RJControls.RJTextBox txtPesquisa;
    private RJControls.RJButton btnEditar;
    private RJControls.RJButton btnNovo;
    private Panel pnTopo;
    private Panel pnMeio;
    private Syncfusion.WinForms.DataGrid.SfDataGrid dgFornecedores;
}