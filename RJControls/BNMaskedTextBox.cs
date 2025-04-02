using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SistemaERP.RJControls;

[DefaultEvent("_TextChanged")]
public partial class BNMaskedTextBox : UserControl
{
    #region -> Fields
    // Fields
    private Color borderColor = Color.MediumSlateBlue;
    private Color borderFocusColor = Color.HotPink;
    private int borderSize = 2;
    private bool underlinedStyle = false;
    private bool isFocused = false;

    private int borderRadius = 0;
    private Color placeholderColor = Color.DarkGray;
    private string placeholderText = "";
    private bool isPlaceholder = false;
    private bool isPasswordChar = false;

    private string mask = ""; // Novo campo para armazenar a máscara

    // Events
    public event EventHandler? _TextChanged;

    #endregion

    // Constructor
    public BNMaskedTextBox()
    {
        InitializeComponent();
    }

    #region -> Properties
    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            this.Invalidate();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color BorderFocusColor
    {
        get => borderFocusColor;
        set => borderFocusColor = value;
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int BorderSize
    {
        get => borderSize;
        set
        {
            if (value >= 1)
            {
                borderSize = value;
                this.Invalidate();
            }
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool UnderlinedStyle
    {
        get => underlinedStyle;
        set
        {
            underlinedStyle = value;
            this.Invalidate();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool PasswordChar
    {
        get => isPasswordChar;
        set
        {
            isPasswordChar = value;
            if (!isPlaceholder)
                maskedTextBox1.UseSystemPasswordChar = value;
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool Multiline
    {
        get => maskedTextBox1.Multiline;
        set => maskedTextBox1.Multiline = value;
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override Color BackColor
    {
        get => base.BackColor;
        set
        {
            base.BackColor = value;
            maskedTextBox1.BackColor = value;
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override Color ForeColor
    {
        get => base.ForeColor;
        set
        {
            base.ForeColor = value;
            maskedTextBox1.ForeColor = value;
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override Font? Font
    {
        get => base.Font;
        set
        {
            base.Font = value;
            maskedTextBox1.Font = value ?? SystemFonts.DefaultFont;
            if (this.DesignMode)
                UpdateControlHeight();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Texts
    {
        get
        {
            if (isPlaceholder) return "";
            else return maskedTextBox1.Text;
        }
        set
        {
            maskedTextBox1.Text = value;
            SetPlaceholder();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int BorderRadius
    {
        get => borderRadius;
        set
        {
            if (value >= 0)
            {
                borderRadius = value;
                this.Invalidate();
            }
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color PlaceholderColor
    {
        get => placeholderColor;
        set
        {
            placeholderColor = value;
            if (isPlaceholder)
                maskedTextBox1.ForeColor = value;
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string PlaceholderText
    {
        get => placeholderText;
        set
        {
            placeholderText = value;
            maskedTextBox1.Text = "";
            SetPlaceholder();
        }
    }
     
    
    // Propriedade Mask adicionada
    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Mask
    {
        get => mask;
        set
        {
            mask = value;
            maskedTextBox1.Mask = mask; // Aplica a máscara ao MaskedTextBox
        }
    }

    #endregion

    #region -> Overridden methods
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (this.DesignMode)
            UpdateControlHeight();
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        UpdateControlHeight();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var graph = e.Graphics;

        if (borderRadius > 1) // Rounded TextBox
        {
            var rectBorderSmooth = this.ClientRectangle;
            var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
            var smoothSize = borderSize > 0 ? borderSize : 1;

            using var pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius);
            using var pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize);
            using var penBorderSmooth = new Pen(Parent.BackColor, smoothSize);
            using var penBorder = new Pen(borderColor, borderSize);

            this.Region = new Region(pathBorderSmooth);
            if (borderRadius > 15) SetTextBoxRoundedRegion();
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            if (isFocused) penBorder.Color = borderFocusColor;

            if (underlinedStyle) // Line Style
            {
                graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                graph.SmoothingMode = SmoothingMode.None;
                graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
            }
            else // Normal Style
            {
                graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                graph.DrawPath(penBorder, pathBorder);
            }
        }
        else // Square/Normal TextBox
        {
            using var penBorder = new Pen(borderColor, borderSize);
            this.Region = new Region(this.ClientRectangle);
            penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            if (isFocused) penBorder.Color = borderFocusColor;

            if (underlinedStyle) // Line Style
                graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
            else // Normal Style
                graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
        }
    }
    #endregion

    #region -> Private methods
    private void SetPlaceholder()
    {
        if (string.IsNullOrWhiteSpace(maskedTextBox1.Text) && placeholderText != "")
        {            
            isPlaceholder = true;
            maskedTextBox1.Text = placeholderText;            
            maskedTextBox1.ForeColor = placeholderColor;
            if (isPasswordChar)
                maskedTextBox1.UseSystemPasswordChar = false;
        }
    }

    private void RemovePlaceholder()
    {
        if (isPlaceholder && placeholderText != "")
        {
            isPlaceholder = false;
            maskedTextBox1.Text = "";            
            maskedTextBox1.ForeColor = this.ForeColor;
            if (isPasswordChar)
                maskedTextBox1.UseSystemPasswordChar = true;
        }
    }

    private GraphicsPath GetFigurePath(Rectangle rect, int radius)
    {
        var path = new GraphicsPath();
        var curveSize = radius * 2F;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
        path.CloseFigure();
        return path;
    }
    private void SetTextBoxRoundedRegion()
    {
        GraphicsPath pathTxt;
        if (Multiline)
        {
            pathTxt = GetFigurePath(maskedTextBox1.ClientRectangle, borderRadius - borderSize);
            maskedTextBox1.Region = new Region(pathTxt);
        }
        else
        {
            pathTxt = GetFigurePath(maskedTextBox1.ClientRectangle, borderSize * 2);
            maskedTextBox1.Region = new Region(pathTxt);
        }
        pathTxt.Dispose();
    }
    private void UpdateControlHeight()
    {
        if (maskedTextBox1.Multiline == false)
        {
            var txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
            maskedTextBox1.Multiline = true;
            maskedTextBox1.MinimumSize = new Size(0, txtHeight);
            maskedTextBox1.Multiline = false;

            this.Height = maskedTextBox1.Height + this.Padding.Top + this.Padding.Bottom;
        }
    }
    #endregion

    #region -> TextBox events
    private void maskedTextBox1_TextChanged(object sender, EventArgs e)
    {
        if (_TextChanged != null)
            _TextChanged.Invoke(sender, e);
    }
    private void maskedTextBox1_Click(object sender, EventArgs e)
    {
        this.OnClick(e);
    }
    private void maskedTextBox1_MouseEnter(object sender, EventArgs e)
    {
        this.OnMouseEnter(e);
    }
    private void maskedTextBox1_MouseLeave(object sender, EventArgs e)
    {
        this.OnMouseLeave(e);
    }
    private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        this.OnKeyPress(e);
    }

    private void maskedTextBox1_Enter(object sender, EventArgs e)
    {
        isFocused = true;
        this.Invalidate();
        RemovePlaceholder();
    }
    private void maskedTextBox1_Leave(object sender, EventArgs e)
    {
        isFocused = false;
        this.Invalidate();
        SetPlaceholder();
    }
    #endregion

    private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        this.OnKeyDown(e);
    }
}
