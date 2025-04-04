using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using DrawingBitmap = System.Drawing.Bitmap;
using DrawingColor = System.Drawing.Color;

namespace PixelQRGeneratorApp.Utils
{
    public static class PixelHelper
    {
        private class Pixel
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private static List<Pixel> _pixels = new();
        private static DispatcherTimer _timer = null!;
        private static Canvas _canvas = null!;
        private static int _pixelSize;
        private static int _currentIndex;
        private static string _shape = null!;
        private static string _color = null!;

        private static Brush GetBrushFromName(string name)
        {
            return name switch
            {
                "Red" => Brushes.Red,
                "Green" => Brushes.Green,
                "Blue" => Brushes.Blue,
                "Orange" => Brushes.Orange,
                "Purple" => Brushes.Purple,
                _ => Brushes.Black,
            };
        }

        public static void RenderToCanvasAnimated(DrawingBitmap bitmap, Canvas canvas, int pixelSize, string shape,
            string color)
        {
            canvas.Children.Clear();
            _pixels.Clear();

            _canvas = canvas;
            _pixelSize = pixelSize;
            _shape = shape;
            _color = color;
            _currentIndex = 0;

            canvas.Width = bitmap.Width * pixelSize;
            canvas.Height = bitmap.Height * pixelSize;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    if (pixel.ToArgb() == DrawingColor.Black.ToArgb())
                    {
                        _pixels.Add(new Pixel { X = x, Y = y });
                    }
                }
            }

            _timer = new DispatcherTimer { Interval = System.TimeSpan.FromMilliseconds(2) };
            _timer.Tick += DrawNextPixel;
            _timer.Start();
        }

        private static void DrawNextPixel(object? sender, System.EventArgs e)
        {
            if (_currentIndex >= _pixels.Count)
            {
                _timer.Stop();
                return;
            }

            var p = _pixels[_currentIndex++];
            Shape shapeElement;

            shapeElement = _shape switch
            {
                "Circle" => new Ellipse(),
                _ => new Rectangle()
            };

            shapeElement.Width = _pixelSize;
            shapeElement.Height = _pixelSize;
            shapeElement.Fill = GetBrushFromName(_color);
            shapeElement.Opacity = 0;

            Canvas.SetLeft(shapeElement, p.X * _pixelSize);
            Canvas.SetTop(shapeElement, p.Y * _pixelSize);

            _canvas.Children.Add(shapeElement);

            var scaleTransform = new ScaleTransform(0.0, 0.0);
            shapeElement.RenderTransform = scaleTransform;
            shapeElement.RenderTransformOrigin = new Point(0.5, 0.5);

            var scaleAnim = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(300))
            {
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };

            var opacityAnim = new DoubleAnimation(0.0, 1.0, TimeSpan.FromMilliseconds(300));

            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnim);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
            shapeElement.BeginAnimation(UIElement.OpacityProperty, opacityAnim);
        }
    }
}
