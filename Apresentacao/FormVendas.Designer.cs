namespace SistemaERP.Apresentacao;

partial class FormVendas
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
        btnConsultar = new SistemaERP.RJControls.RJButton();
        sfDateTimeEdit2 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
        label1 = new Label();
        sfDateTimeEdit1 = new Syncfusion.WinForms.Input.SfDateTimeEdit();
        txtPesquisa = new SistemaERP.RJControls.RJTextBox();
        pnMeio = new Panel();
        dgVendas = new Syncfusion.WinForms.DataGrid.SfDataGrid();
        pnTopo.SuspendLayout();
        pnMeio.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgVendas).BeginInit();
        SuspendLayout();
        // 
        // pnTopo
        // 
        pnTopo.Controls.Add(btnNovo);
        pnTopo.Controls.Add(btnEditar);
        pnTopo.Controls.Add(btnConsultar);
        pnTopo.Controls.Add(sfDateTimeEdit2);
        pnTopo.Controls.Add(label1);
        pnTopo.Controls.Add(sfDateTimeEdit1);
        pnTopo.Controls.Add(txtPesquisa);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(0, 0);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(996, 68);
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
        btnNovo.Location = new Point(912, 12);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(72, 41);
        btnNovo.TabIndex = 30;
        btnNovo.Text = "Novo";
        btnNovo.TextColor = Color.White;
        btnNovo.UseVisualStyleBackColor = false;
        btnNovo.Click += btnNovo_Click;
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
        btnEditar.Location = new Point(833, 12);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(73, 41);
        btnEditar.TabIndex = 31;
        btnEditar.Text = "Editar";
        btnEditar.TextColor = Color.White;
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += btnEditar_Click;
        // 
        // btnConsultar
        // 
        btnConsultar.BackColor = Color.FromArgb(2, 89, 89);
        btnConsultar.BackgroundColor = Color.FromArgb(2, 89, 89);
        btnConsultar.BorderColor = Color.Empty;
        btnConsultar.BorderRadius = 20;
        btnConsultar.BorderSize = 0;
        btnConsultar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnConsultar.FlatStyle = FlatStyle.Flat;
        btnConsultar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnConsultar.ForeColor = Color.White;
        btnConsultar.Location = new Point(612, 12);
        btnConsultar.Name = "btnConsultar";
        btnConsultar.Size = new Size(127, 41);
        btnConsultar.TabIndex = 36;
        btnConsultar.Text = "Consultar";
        btnConsultar.TextColor = Color.White;
        btnConsultar.UseVisualStyleBackColor = false;
        btnConsultar.Click += btnConsultar_Click;
        // 
        // sfDateTimeEdit2
        // 
        sfDateTimeEdit2.DateTimeIcon = null;
        sfDateTimeEdit2.Font = new Font("Segoe UI Variable Display", 14.25F);
        sfDateTimeEdit2.Location = new Point(462, 17);
        sfDateTimeEdit2.Name = "sfDateTimeEdit2";
        sfDateTimeEdit2.Size = new Size(144, 34);
        sfDateTimeEdit2.Style.BackColor = Color.LightGray;
        sfDateTimeEdit2.Style.BorderColor = Color.FromArgb(224, 224, 224);
        sfDateTimeEdit2.Style.DropDown.BackColor = Color.LightGray;
        sfDateTimeEdit2.TabIndex = 35;
        sfDateTimeEdit2.ToolTipText = "";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI Variable Display", 14.25F);
        label1.Location = new Point(418, 21);
        label1.Name = "label1";
        label1.Size = new Size(38, 26);
        label1.TabIndex = 34;
        label1.Text = "até";
        // 
        // sfDateTimeEdit1
        // 
        sfDateTimeEdit1.BackColor = Color.LightGray;
        sfDateTimeEdit1.DateTimeIcon = null;
        sfDateTimeEdit1.Font = new Font("Segoe UI Variable Display", 14.25F);
        sfDateTimeEdit1.Location = new Point(268, 17);
        sfDateTimeEdit1.Name = "sfDateTimeEdit1";
        sfDateTimeEdit1.Size = new Size(144, 34);
        sfDateTimeEdit1.Style.BackColor = Color.LightGray;
        sfDateTimeEdit1.Style.BorderColor = Color.FromArgb(224, 224, 224);
        sfDateTimeEdit1.Style.DropDown.BackColor = Color.LightGray;
        sfDateTimeEdit1.Style.UpDownBackColor = Color.LightGray;
        sfDateTimeEdit1.TabIndex = 32;
        sfDateTimeEdit1.ToolTipText = "";
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
        txtPesquisa.Location = new Point(12, 12);
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
        // pnMeio
        // 
        pnMeio.Controls.Add(dgVendas);
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(0, 68);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(996, 550);
        pnMeio.TabIndex = 30;
        // 
        // dgVendas
        // 
        dgVendas.AccessibleName = "Table";
        dgVendas.AllowEditing = false;
        dgVendas.AllowFiltering = true;
        dgVendas.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
        dgVendas.BackColor = Color.White;
        dgVendas.Dock = DockStyle.Fill;
        dgVendas.ForeColor = Color.Black;
        dgVendas.Location = new Point(0, 0);
        dgVendas.Name = "dgVendas";
        dgVendas.Size = new Size(996, 550);
        dgVendas.Style.BorderColor = Color.FromArgb(100, 100, 100);
        dgVendas.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
        dgVendas.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
        dgVendas.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
        dgVendas.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
        dgVendas.TabIndex = 0;
        dgVendas.Text = "dgVendas";
        // 
        // FormVendas
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(996, 618);
        ControlBox = false;
        Controls.Add(pnMeio);
        Controls.Add(pnTopo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormVendas";
        Text = " ";
        Load += FormVendas_Load;
        pnTopo.ResumeLayout(false);
        pnTopo.PerformLayout();
        pnMeio.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgVendas).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnTopo;
    private RJControls.RJTextBox txtPesquisa;
    private Syncfusion.WinForms.Input.SfDateTimeEdit sfDateTimeEdit1;
    private Syncfusion.WinForms.Input.SfDateTimeEdit sfDateTimeEdit2;
    private Label label1;
    private RJControls.RJButton btnConsultar;
    private RJControls.RJButton btnNovo;
    private RJControls.RJButton btnEditar;
    private Panel pnMeio;
    private Syncfusion.WinForms.DataGrid.SfDataGrid dgVendas;
}