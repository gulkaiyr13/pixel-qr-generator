using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing; 

namespace PixelQRGeneratorApp.Utils
{
    public static class PixelHelper
    {
        public static void RenderToCanvas(Bitmap bitmap, Canvas canvas, int pixelSize)
        {
            canvas.Children.Clear();
            canvas.Width = bitmap.Width * pixelSize;
            canvas.Height = bitmap.Height * pixelSize;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    if (pixel.ToArgb() == System.Drawing.Color.Black.ToArgb())
                    {
                        var rect = new System.Windows.Shapes.Rectangle
                        {
                            Width = pixelSize,
                            Height = pixelSize,
                            Fill = System.Windows.Media.Brushes.Black
                        };

                        Canvas.SetLeft(rect, x * pixelSize);
                        Canvas.SetTop(rect, y * pixelSize);
                        canvas.Children.Add(rect);
                    }
                }
            }
        }
    }
}