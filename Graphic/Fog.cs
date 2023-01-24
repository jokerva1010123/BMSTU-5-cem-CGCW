using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic
{
    class Fog
    {
        public static Bitmap AddedFog(ZBuffer map, int zfar)
        {
            Bitmap img = map.GetImg().Clone(new Rectangle(0, 0, map.GetImg().Width, map.GetImg().Height), System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            Color fogColor = Color.Gray;
            float rangeZ = 700 - zfar;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    int z = map.GetZ(i, j);
                    if (z <= zfar) 
                    {
                        img.SetPixel(i, j, fogColor);// Дальше от нас; невидимо за туманом
                    }
                    else 
                    {
                        // Ближе к нам
                        float k = Math.Min((z - zfar) / rangeZ, 1);
                        Color currentColor = img.GetPixel(i, j);
                        float bPers = 1 - k;
                        int red = (int)(currentColor.R * k + fogColor.R * bPers);
                        int green = (int)(currentColor.G * k + fogColor.G * bPers);
                        int blue = (int)(currentColor.B * k + fogColor.B * bPers);
                        img.SetPixel(i, j, Color.FromArgb(red, green, blue));
                    }
                }
            }
            return img;
        }
    }
}
