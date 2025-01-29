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
        btnNovo = new RJControls.RJButton();
        btnEditar = new RJControls.RJButton();
        pnTopo = new Panel();
        pnMeio = new Panel();
        dgUsuarios = new Syncfusion.WinForms.DataGrid.SfDataGrid();
        pnTopo.SuspendLayout();
        pnMeio.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgUsuarios).BeginInit();
        SuspendLayout();
        // 
        // btnNovo
        // 
        btnNovo.Anchor = AnchorStyles.Right;
        btnNovo.BackColor = Color.FromArgb(60, 117, 125);
        btnNovo.BackgroundColor = Color.FromArgb(60, 117, 125);
        btnNovo.BorderColor = Color.Empty;
        btnNovo.BorderRadius = 20;
        btnNovo.BorderSize = 0;
        btnNovo.FlatAppearance.BorderColor = Color.DarkBlue;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnNovo.ForeColor = Color.White;
        btnNovo.Location = new Point(924, 12);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(72, 41);
        btnNovo.TabIndex = 25;
        btnNovo.Text = "Novo";
        btnNovo.TextColor = Color.White;
        btnNovo.UseVisualStyleBackColor = false;
        btnNovo.Click += btnNovo_Click;
        // 
        // btnEditar
        // 
        btnEditar.Anchor = AnchorStyles.Right;
        btnEditar.BackColor = Color.FromArgb(60, 117, 125);
        btnEditar.BackgroundColor = Color.FromArgb(60, 117, 125);
        btnEditar.BorderColor = Color.Empty;
        btnEditar.BorderRadius = 20;
        btnEditar.BorderSize = 0;
        btnEditar.FlatAppearance.BorderColor = Color.DarkBlue;
        btnEditar.FlatStyle = FlatStyle.Flat;
        btnEditar.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEditar.ForeColor = Color.White;
        btnEditar.Location = new Point(845, 12);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(73, 41);
        btnEditar.TabIndex = 26;
        btnEditar.Text = "Editar";
        btnEditar.TextColor = Color.White;
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += btnEditar_Click;
        // 
        // pnTopo
        // 
        pnTopo.Controls.Add(btnNovo);
        pnTopo.Controls.Add(btnEditar);
        pnTopo.Dock = DockStyle.Top;
        pnTopo.Location = new Point(0, 0);
        pnTopo.Name = "pnTopo";
        pnTopo.Size = new Size(1008, 68);
        pnTopo.TabIndex = 27;
        // 
        // pnMeio
        // 
        pnMeio.Controls.Add(dgUsuarios);
        pnMeio.Dock = DockStyle.Fill;
        pnMeio.Location = new Point(0, 68);
        pnMeio.Name = "pnMeio";
        pnMeio.Size = new Size(1008, 587);
        pnMeio.TabIndex = 28;
        // 
        // dgUsuarios
        // 
        dgUsuarios.AccessibleName = "Table";
        dgUsuarios.AllowEditing = false;
        dgUsuarios.AllowFiltering = true;
        dgUsuarios.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
        dgUsuarios.Dock = DockStyle.Fill;
        dgUsuarios.Location = new Point(0, 0);
        dgUsuarios.Name = "dgUsuarios";
        dgUsuarios.Size = new Size(1008, 587);
        dgUsuarios.Style.BorderColor = Color.FromArgb(100, 100, 100);
        dgUsuarios.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
        dgUsuarios.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
        dgUsuarios.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
        dgUsuarios.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
        dgUsuarios.TabIndex = 0;
        dgUsuarios.Text = "dgUsuarios";
        // 
        // FormUsuarios
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1008, 655);
        Controls.Add(pnMeio);
        Controls.Add(pnTopo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FormUsuarios";
        Text = "FormUsuarios";
        pnTopo.ResumeLayout(false);
        pnMeio.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgUsuarios).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private RJControls.RJButton btnNovo;
    private RJControls.RJButton btnEditar;
    private Panel pnTopo;
    private Panel pnMeio;
    private Syncfusion.WinForms.DataGrid.SfDataGrid dgUsuarios;
}