using Scarender.Layouting;
using SixLabors.ImageSharp;

namespace Scarender.Controls;

public abstract class ControlBase : IRenderable
{
    public virtual Size ActualSize { get; internal set; }
    public virtual Point ActualPosition { get; internal set; }

    public Size Size { get; set; } = new(-1, -1); // Auto
    public Point Position { get; set; }

    public StretchMode VerticalStretch { get; set; }
    public StretchMode HorionalStretch { get; set; }

    public Point Margin { get; set; }

    public virtual (Size, Point) Measure(Size container)
    {
        int h = VerticalStretch switch
        {
            StretchMode.Fill => container.Height - Margin.Y * 2,
            _ => Size.Height == -1 ? 0 : Size.Height
        };

        int w = HorionalStretch switch
        {
            StretchMode.Fill => container.Width - Margin.X * 2,
            _ => Size.Width == -1 ? 0 : Size.Width
        };

        int x = HorionalStretch switch
        {
            StretchMode.Fill => Margin.X,
            StretchMode.Head => Margin.X,
            StretchMode.Center => container.Width / 2 - w / 2,
            StretchMode.Tail => container.Width - w
        };

        int y = VerticalStretch switch
        {
            StretchMode.Fill => Margin.Y,
            StretchMode.Head => Margin.Y,
            StretchMode.Center => container.Height / 2 - w / 2,
            StretchMode.Tail => container.Height - w
        };

        return (new Size(w, h), new Point(x, y));
    }

    public abstract Image Render(Size container);
}