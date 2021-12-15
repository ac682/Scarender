using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class Grid: ItemContainer
{
    //public RowDefinition
    
    public override Image Render(Size container)
    {
        (ActualSize,ActualPosition) = Measure(container);
        
        var image = new Image<Argb32>(ActualSize.Width, ActualSize.Height);
        image.Mutate(context =>
        {
            foreach (var item in Items)
            {
                context.DrawImage(item.Render(ActualSize), item.ActualPosition,1f);
            }
        });
        return image;
    }
}