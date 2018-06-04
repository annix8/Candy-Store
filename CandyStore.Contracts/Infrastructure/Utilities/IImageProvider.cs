using System.Drawing;

namespace CandyStore.Contracts.Infrastructure.Utilities
{
    public interface IImageProvider
    {
        Image GetImageFromByteArray(byte[] byteImage);
    }
}
