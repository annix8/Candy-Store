using System.Drawing;

namespace CandyStore.Contracts.Infrastructure.Utilities
{
    public interface IImageUtil
    {
        Image GetImageFromByteArray(byte[] byteImage);
        byte[] ConvertImageToByteArray(string imageFileName);
    }
}
