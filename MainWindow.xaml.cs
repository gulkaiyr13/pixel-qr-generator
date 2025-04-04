using System.Windows;
using PixelQRGeneratorApp.Services;
using PixelQRGeneratorApp.Utils;
using QRCoder;
using Microsoft.Win32;
using System.IO;

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

        private void SaveSvgButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputText.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Write a text for QR.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var svgQrCode = new SvgQRCode(qrCodeData);
            string svgContent = svgQrCode.GetGraphic(10);

            var dialog = new SaveFileDialog
            {
                Filter = "SVG Files (*.svg)|*.svg",
                DefaultExt = "svg",
                FileName = "qr-code.svg"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, svgContent);
                MessageBox.Show("SVG file saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}