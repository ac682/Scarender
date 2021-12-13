using Scarender.Layouting;
using SixLabors.ImageSharp;

namespace Scarender.Controls;

public abstract class ControlBase: IRenderable
{
    public virtual Size ActualSize { get; internal set; }
    public virtual Point ActualPosition { get; internal set; }

    public Size Size { get; set; } = new(-1, -1); // Auto
    public Point Position { get; set; }
    
    public StretchMode VerticalStretch { get; set; }
    public StretchMode HorionalStretch { get; set; }
    
    public Point Margin { get; set; }

    public virtual Size Measure(Size outer)
    {
        int h = VerticalStretch switch
        {
            StretchMode.Fill => outer.Height,
            _ => Size.Height == -1 ? 0: Size.Height
        };

        int w = HorionalStretch switch
        {
            StretchMode.Fill => outer.Width,
            _ => Size.Width == -1 ? 0 : Size.Width
        };
        return new Size(w,h);
    }

    public abstract Image Render(Size outer);
}