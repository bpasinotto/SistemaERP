namespace SistemaERP.Apresentacao;

partial class FormClientes
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
        cbInativos = new CheckBox();
        pnMeio = new Panel();
        dgClientes = new Syncfusion.WinForms.DataGrid.SfDataGrid();
        pnTopo.SuspendLayout();
        pnMeio.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgClientes).BeginInit();
        SuspendLayout();
        // 
        // pnTopo
        // 
        pnTopo.Controls.Add(btnNovo);
        pnTopo.Controls.Add(btnEditar);
        pnTopo.Controls.Add(cbInativos);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(0, 0);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(1004, 68);
        pnTopo.TabIndex = 28;
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
        btnNovo.Location = new Point(920, 12);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(72, 41);
        btnNovo.TabIndex = 35;
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
        btnEditar.Location = new Point(841, 12);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(73, 41);
        btnEditar.TabIndex = 36;
        btnEditar.Text = "Editar";
        btnEditar.TextColor = Color.White;
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += btnEditar_Click;
        // 
        // cbInativos
        // 
        cbInativos.AutoSize = true;
        cbInativos.Font = new Font("Segoe UI Variable Display", 11.25F);
        cbInativos.Location = new Point(21, 22);
        cbInativos.Name = "cbInativos";
        cbInativos.Size = new Size(156, 24);
        cbInativos.TabIndex = 34;
        cbInativos.Text = "Ver clientes inativos";
        cbInativos.UseVisualStyleBackColor = true;
        cbInativos.CheckedChanged += cbInativos_CheckedChanged;
        // 
        // pnMeio
        // 
        pnMeio.Controls.Add(dgClientes);
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(0, 68);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(1004, 555);
        pnMeio.TabIndex = 29;
        // 
        // dgClientes
        // 
        dgClientes.AccessibleName = "Table";
        dgClientes.AllowEditing = false;
        dgClientes.AllowFiltering = true;
        dgClientes.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
        dgClientes.BackColor = Color.White;
        dgClientes.Dock = DockStyle.Fill;
        dgClientes.ForeColor = Color.Black;
        dgClientes.Location = new Point(0, 0);
        dgClientes.Name = "dgClientes";
        dgClientes.Size = new Size(1004, 555);
        dgClientes.Style.BorderColor = Color.FromArgb(100, 100, 100);
        dgClientes.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
        dgClientes.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
        dgClientes.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
        dgClientes.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
        dgClientes.TabIndex = 0;
        dgClientes.Text = "dgUsuarios";
        // 
        // FormClientes
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1004, 623);
        ControlBox = false;
        Controls.Add(pnMeio);
        Controls.Add(pnTopo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormClientes";
        StartPosition = FormStartPosition.CenterParent;
        WindowState = FormWindowState.Maximized;
        Load += FormClientes_Load;
        pnTopo.ResumeLayout(false);
        pnTopo.PerformLayout();
        pnMeio.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgClientes).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnTopo;
    private CheckBox cbInativos;
    private RJControls.RJButton btnNovo;
    private RJControls.RJButton btnEditar;
    private Panel pnMeio;
    private Syncfusion.WinForms.DataGrid.SfDataGrid dgClientes;
}