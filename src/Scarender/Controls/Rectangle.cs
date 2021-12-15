using Scarender.Layouting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class Rectangle: ControlBase
{
    public Color Fill { get; set; }

    public override Image Render(Size outer)
    {
        (ActualSize,ActualPosition) = Measure(outer);

        var image = new Image<Argb32>(ActualSize.Width, ActualSize.Height, Fill);
        return image;
    }
}