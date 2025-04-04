using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using PixelQRGeneratorApp.Services;
using PixelQRGeneratorApp.Utils;
using QRCoder;

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
            string shape = ((ComboBoxItem)PixelShapeSelector.SelectedItem).Content.ToString();
            string selectedColor = ((ComboBoxItem)ColorSelector.SelectedItem).Content.ToString();

            var bitmap = _qrService.GenerateQRCode(text);
            PixelHelper.RenderToCanvasAnimated(bitmap, MyCanvas, pixelSize, shape, selectedColor);
        }

        private void SaveSvgButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputText.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Please enter text to generate a QR code.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedColor = ((ComboBoxItem)ColorSelector.SelectedItem).Content.ToString().ToLower();

            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var svgQrCode = new SvgQRCode(qrCodeData);

            // foregroundColor, backgroundColor, drawQuietZones
            string svgContent = svgQrCode.GetGraphic(10, selectedColor, "#FFFFFF", true);

            var dialog = new SaveFileDialog
            {
                Filter = "SVG Files (*.svg)|*.svg",
                DefaultExt = "svg",
                FileName = "qr-code.svg"
            };

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, svgContent);
                MessageBox.Show("QR code was successfully saved as an SVG file!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
