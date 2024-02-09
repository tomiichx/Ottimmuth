#pragma warning disable IDE1006
using System.Drawing;

namespace Ottimmuth
{
    public class Ottimmuth
    {
        private readonly Bitmap newImage;

        public Ottimmuth(Bitmap newImage)
        {
            this.newImage = newImage;
        }

        public void startProcessing()
        {
            int width = newImage.Width;
            int height = newImage.Height;

            Color[,] pixelColors = new Color[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixelColors[x, y] = newImage.GetPixel(x, y);
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!isOttimmuth(x, y, pixelColors))
                        continue;

                    newImage.SetPixel(x, y, Color.White);
                }
            }
        }

        private bool isOttimmuth(int x, int y, Color[,] pixelColors)
        {
            Color currentPixel = pixelColors[x, y];

            if (x > 0 && pixelColors[x - 1, y] == currentPixel)
            {
                return true;
            }

            if (x < newImage.Width - 1 && pixelColors[x + 1, y] == currentPixel)
            {
                return true;
            }

            if (y > 0 && pixelColors[x, y - 1] == currentPixel)
            {
                return true;
            }

            if (y < newImage.Height - 1 && pixelColors[x, y + 1] == currentPixel)
            {
                return true;
            }

            return false;
        }
    }
}
