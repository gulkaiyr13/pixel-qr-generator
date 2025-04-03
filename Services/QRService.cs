using QRCoder;
using System.Drawing;

namespace PixelQRGeneratorApp.Services
{
    public class QRService
    {
        public Bitmap GenerateQRCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            return qrCode.GetGraphic(1);
        }
    }
}