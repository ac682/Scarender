using Scarender.Layouting;
using SixLabors.ImageSharp;

namespace Scarender.Controls;

public abstract class ContentContainer: ControlBase
{
    public ControlBase Content { get; set; }
}