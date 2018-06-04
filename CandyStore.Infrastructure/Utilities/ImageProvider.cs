using CandyStore.Contracts.Infrastructure.Utilities;
using System.Drawing;
using System.IO;

namespace CandyStore.Infrastructure.Utilities
{
    public class ImageProvider : IImageProvider
    {
        public Image GetImageFromByteArray(byte[] byteImage)
        {
            using (MemoryStream ms = new MemoryStream(byteImage))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
