using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SistemaERP.RJControls;

public class RJButton : Button
{
    //Fields
    private int borderSize = 0;
    private int borderRadius = 0;
    private Color borderColor = Color.PaleVioletRed;

    //Properties
    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int BorderSize
    {
        get => borderSize;
        set
        {
            borderSize = value;
            Invalidate();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public int BorderRadius
    {
        get => borderRadius;
        set
        {
            borderRadius = value;
            Invalidate();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Invalidate();
        }
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color BackgroundColor
    {
        get => BackColor;
        set => BackColor = value;
    }

    [Category("RJ Code Advance")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color TextColor
    {
        get => ForeColor;
        set => ForeColor = value;
    }

    //Constructor
    public RJButton()
    {
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Size = new Size(150, 40);
        BackColor = Color.MediumSlateBlue;
        ForeColor = Color.White;
        Resize += new EventHandler(Button_Resize);
    }

    //Methods
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

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);


        var rectSurface = ClientRectangle;
        var rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
        var smoothSize = 2;
        if (borderSize > 0)
            smoothSize = borderSize;

        if (borderRadius > 2) //Rounded button
        {
            using var pathSurface = GetFigurePath(rectSurface, borderRadius);
            using var pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize);
            using var penSurface = new Pen(Parent.BackColor, smoothSize);
            using var penBorder = new Pen(borderColor, borderSize);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //Button surface
            Region = new Region(pathSurface);
            //Draw surface border for HD result
            pevent.Graphics.DrawPath(penSurface, pathSurface);

            //Button border                    
            if (borderSize >= 1)
                //Draw control border
                pevent.Graphics.DrawPath(penBorder, pathBorder);
        }
        else //Normal button
        {
            pevent.Graphics.SmoothingMode = SmoothingMode.None;
            //Button surface
            Region = new Region(rectSurface);
            //Button border
            if (borderSize >= 1)
            {
                using (var penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    pevent.Graphics.DrawRectangle(penBorder, 0, 0, Width - 1, Height - 1);
                }
            }
        }
    }
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
    }

    private void Container_BackColorChanged(object sender, EventArgs e)
    {
        Invalidate();
    }
    private void Button_Resize(object sender, EventArgs e)
    {
        if (borderRadius > Height)
            borderRadius = Height;
    }
}