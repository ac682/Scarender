using SixLabors.ImageSharp;

namespace Scarender.Controls;

public class TextBlock: ControlBase
{
    public string Text { get; set; } = string.Empty;

    public override Image Render(Size outer)
    {
        throw new NotImplementedException();
    }
}