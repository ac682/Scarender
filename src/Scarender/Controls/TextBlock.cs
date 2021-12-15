using Scarender.Layouting;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Scarender.Controls;

public class TextBlock : ControlBase
{
    public string Text { get; set; } = string.Empty;

    public string Font { get; set; } = "Droid Sans";

    public float FontSize { get; set; } = 14;

    public Color ForegroundColor { get; set; } = Color.Black;

    public FontStyle FontStyle { get; set; } = FontStyle.Regular;

    public override Image Render(Size container)
    {
        (ActualSize, ActualPosition) = Measure(container);

        var font = SystemFonts.Find(Font).CreateFont(FontSize, FontStyle);
        if (ActualSize == Size.Empty)
        {
            var rect = TextMeasurer.Measure(Text, new RendererOptions(font));
            ActualSize = new Size((int)(rect.Width + 0.5) + Margin.X * 2, (int)(rect.Height + 0.5) + Margin.Y * 2);
            ActualPosition = new Point(HorionalStretch switch
            {
                StretchMode.Fill => Margin.X,
                StretchMode.Head => Margin.X,
                StretchMode.Center => container.Width / 2 - ActualSize.Width / 2,
                StretchMode.Tail => container.Width - ActualSize.Width
            }, VerticalStretch switch
            {
                StretchMode.Fill => Margin.Y,
                StretchMode.Head => Margin.Y,
                StretchMode.Center => container.Height / 2 - ActualSize.Height / 2,
                StretchMode.Tail => container.Height - ActualSize.Height
            });
        }

        var image = new Image<Argb32>(ActualSize.Width, ActualSize.Height);
        image.Mutate(context => context.DrawText(Text, font, ForegroundColor, new PointF(0, 0)));
        return image;
    }
}