using CandyStore.Contracts.Infrastructure.Utilities;
using System;
using System.Drawing;
using System.IO;

namespace CandyStore.Infrastructure.Utilities
{
    public class ImageUtil : IImageUtil
    {
        public byte[] ConvertImageToByteArray(string imageFileName)
        {
            Image.GetThumbnailImageAbort myCallback =
                               new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Bitmap myBitmap = new Bitmap(imageFileName);
            Image myThumbnail = myBitmap.GetThumbnailImage(250, 250,
                myCallback, IntPtr.Zero);

            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(myThumbnail, typeof(byte[]));
            return xByte;
        }

        public Image GetImageFromByteArray(byte[] byteImage)
        {
            using (MemoryStream ms = new MemoryStream(byteImage))
            {
                return Image.FromStream(ms);
            }
        }

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}
