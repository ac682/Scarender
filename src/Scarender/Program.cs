// See https://aka.ms/new-console-template for more information

using System.Collections.ObjectModel;
using Scarender;
using Scarender.Controls;
using Scarender.Layouting;
using SixLabors.ImageSharp;

Console.WriteLine("Hello, World!");

var template = new Template()
{
    Size = new Size(800,600),
    Frame = new Grid()
    {
        Items = new Collection<ControlBase>()
        {
            new Border()
            {
                Content = new Scarender.Controls.Rectangle()
                {
                    Fill = Color.Aqua
                }
            }
        }
    }
};

// measure template's all controls


// void Render(Size outer, ControlBase control)
// {
//     // -1 meant it should be calculated from the deepest
//     
//     int height = control.VerticalStretch switch
//     {
//         StretchMode.Fill => outer.Height - control.Margin.Y,
//         _ => -1
//     };
//     int width = control.HorionalStretch switch
//     {
//         StretchMode.Fill => outer.Width - control.Margin.X,
//         _ => -1
//     };
//
//     int x = control.HorionalStretch switch
//     {
//         StretchMode.Fill => 0,
//         StretchMode.Center => outer.Width / 2 - width / 2,
//         StretchMode.Head => 0,
//         StretchMode.Tail => outer.Width - width
//     };
//     int y = control.HorionalStretch switch
//     {
//         StretchMode.Fill => 0,
//         StretchMode.Center => outer.Height / 2 - height / 2,
//         StretchMode.Head => 0,
//         StretchMode.Tail => outer.Height - height
//     };
//     control.ActualSize = new(height, width);
//     control.ActualPosition = new(x, y);
//     if (control is ContentContainer content)
//     {
//         Render(control.ActualSize, content.Content);
//
//         if (height == -1)
//         {
//             height = content.Content.ActualSize.Height;
//         }
//
//         if (width == -1)
//         {
//             width = content.Content.ActualSize.Width;
//         }
//
//         control.ActualSize = new(height, width);
//     }else if (control is ItemContainer items)
//     {
//         foreach (var item in items.Items)
//         {
//             Render(control.ActualSize, item);
//             
//             //TODO: 
//         }
//     }
//     else if (control is IRenderable renderable)
//     {
//         var frame = renderable.Render();
//         if (height == -1)
//         {
//             height = frame.Height;
//         }
//
//         if (width == -1)
//         {
//             width = frame.Width;
//         }
//
//         control.ActualSize = new(height, width);
//     }
// }
//
//Render(template.Size, template.Frame);

var image = template.Frame.Render(template.Size);
image.Save("~/img.png");

Console.ReadKey();