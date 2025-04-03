using System.Windows;
using PixelQRGeneratorApp.Services;
using PixelQRGeneratorApp.Utils;

namespace PixelQRGeneratorApp
{
    public partial class MainWindow : Window
    {
        private readonly QRService _qrService = new QRService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputText.Text;
            int pixelSize = (int)PixelSlider.Value;

            var bitmap = _qrService.GenerateQRCode(text);
            PixelHelper.RenderToCanvas(bitmap, MyCanvas, pixelSize);
        }
    }
}   