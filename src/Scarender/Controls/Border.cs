using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class Border: ContentContainer
{
    public Color Stroke { get; set; }
    public Point StrokeThickness { get; set; } = new(1);

    public override Image Render(Size outer)
    {
        (ActualSize,ActualPosition) = Measure(outer);

        var image = new Image<Argb32>(ActualSize.Width, ActualSize.Height);
        image.Mutate(context => context.DrawImage(Content.Render(ActualSize), Content.ActualPosition,1f)); 
        //TODO: draw border by draw rectangle and apply image on it
        
        return image;
    }
}