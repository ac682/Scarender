// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using Scarender;
using Scarender.Controls;
using Scarender.Layouting;
using SixLabors.ImageSharp;
using Rectangle = Scarender.Controls.Rectangle;

Console.WriteLine("Hello, World!");

var template = new Template()
{
    Size = new Size(800,600),
    Frame = new Grid()
    {
        Items = new Collection<ControlBase>()
        {
            new Rectangle()
            {
                Fill = Color.Aqua
            },
            new Border()
            {
                Margin = new(100,100),
                Content = new Rectangle()
                {
                    Fill = Color.Maroon
                }
            },
            new TextBlock()
            {
                HorionalStretch = StretchMode.Center,
                VerticalStretch = StretchMode.Center,
                Text = "Hello, World"
            }
        }
    }
};

var image = template.Frame.Render(template.Size);
image.Save("img.png");

Console.WriteLine("Done to exit");