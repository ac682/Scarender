using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class ImageBox: ControlBase
{
    public string Url { get; set; }

    public float ScaleFactor { get; set; } = 1f;
    public override Image Render(Size container)
    {
        (ActualSize, ActualPosition) = Measure(container);
        

        var image = Image.Load(Url);
        
        
        ActualSize = image.Size();
        
        //TODO: calculated according to Size
        
        if (Math.Abs(ScaleFactor - 1f) > 0.01f)
        {
            image.Mutate(context => context.Resize(new Size((int)(ActualSize.Width * ScaleFactor), (int)(ActualSize.Height * ScaleFactor))));
        }

        return image;
    }
}