namespace SistemaERP.RJControls;

partial class BNMaskedTextBox
{
    /// <summary> 
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Código gerado pelo Designer de Componentes

    /// <summary> 
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
        maskedTextBox1 = new MaskedTextBox();
        SuspendLayout();
        // 
        // maskedTextBox1
        // 
        maskedTextBox1.BorderStyle = BorderStyle.None;
        maskedTextBox1.Dock = DockStyle.Fill;
        maskedTextBox1.Location = new Point(10, 7);
        maskedTextBox1.Name = "maskedTextBox1";
        maskedTextBox1.Size = new Size(230, 15);
        maskedTextBox1.TabIndex = 0;
        maskedTextBox1.Click += maskedTextBox1_Click;
        maskedTextBox1.TextChanged += maskedTextBox1_TextChanged;
        maskedTextBox1.Enter += maskedTextBox1_Enter;
        maskedTextBox1.KeyDown += maskedTextBox1_KeyDown;
        maskedTextBox1.KeyPress += maskedTextBox1_KeyPress;
        maskedTextBox1.Leave += maskedTextBox1_Leave;
        maskedTextBox1.MouseEnter += maskedTextBox1_MouseEnter;
        maskedTextBox1.MouseLeave += maskedTextBox1_MouseLeave;
        // 
        // BNMaskedTextBox
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = SystemColors.Window;
        Controls.Add(maskedTextBox1);
        Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.DimGray;
        Name = "BNMaskedTextBox";
        Padding = new Padding(10, 7, 10, 7);
        Size = new Size(250, 30);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MaskedTextBox maskedTextBox1;
}
