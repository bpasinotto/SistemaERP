namespace SistemaERP.RJControls;

partial class RjTextBoxEdit
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
        textBox2 = new TextBox();
        SuspendLayout();
        // 
        // textBox2
        // 
        textBox2.BorderStyle = BorderStyle.None;
        textBox2.Dock = DockStyle.Fill;
        textBox2.Location = new Point(10, 7);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(230, 15);
        textBox2.TabIndex = 0;
        textBox2.Click += textBox2_Click;
        textBox2.TextChanged += textBox2_TextChanged;
        textBox2.Enter += textBox2_Enter;
        textBox2.KeyDown += textBox2_KeyDown;
        textBox2.KeyPress += textBox2_KeyPress;
        textBox2.Leave += textBox2_Leave;
        textBox2.MouseEnter += textBox2_MouseEnter;
        textBox2.MouseLeave += textBox2_MouseLeave;
        // 
        // RJTextBoxRC
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = SystemColors.Window;
        Controls.Add(textBox2);
        Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = Color.DimGray;
        Name = "RJTextBoxRC";
        Padding = new Padding(10, 7, 10, 7);
        Size = new Size(250, 30);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox textBox2;
}
