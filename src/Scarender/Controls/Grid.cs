using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class Grid: ItemContainer
{
    public override Image Render(Size outer)
    {
        ActualSize = Measure(outer);
        
        var image = new Image<Argb32>(ActualSize.Width, ActualSize.Height);
        image.Mutate(context =>
        {
            foreach (var item in Items)
            {
                context.DrawImage(item.Render(ActualSize), 1f);
            }
        });
        return image;
    }
}