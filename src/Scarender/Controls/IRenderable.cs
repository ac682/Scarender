using SixLabors.ImageSharp;

namespace Scarender.Controls;

public interface IRenderable
{
    Image Render(Size container);
}