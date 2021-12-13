using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class Border: ContentContainer
{
    public Color Stroke { get; set; }
    public Point StrokeThickness { get; set; } = new(1);

    public override Image Render(Size outer)
    {
        ActualSize = Measure(outer);

        var image = new Image<Argb32>(ActualSize.Width, ActualSize.Height);
        //TODO: draw border
        return image;
    }
}