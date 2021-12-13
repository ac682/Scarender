using System.Collections.ObjectModel;
using SixLabors.ImageSharp;

namespace Scarender.Controls;

public abstract class ItemContainer: ControlBase
{
    public Collection<ControlBase> Items { get; set; } = new();
}