using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    internal class ZBuffer
    {
        Size size;
        private int zBackground = -100 * 100 * 100;
        int[][] zbuf;
        Sun sun;
        public Bitmap img, imgFromSun;
        double tettax, tettay, tettaz;
        int[][] zbufFromSun;

        void InitTetta()
        {
            tettax = this.sun.tettax;
            tettay = this.sun.tettay;
            tettaz = this.sun.tettaz;
        }

        void ProcessPoint(int[][] zbuff, Bitmap image, Point3D p, Color color, int w = 1200, int h = 800)
        {
            if (!(p.x < 0 || p.x >= w || p.y < 0 || p.y >= h))
            {
                if (p.z > zbuff[p.y][p.x])
                {
                    zbuff[p.y][p.x] = p.z;
                    image.SetPixel(p.x, p.y, color);
                }
            }
        }

        void ProcessModel(int[][] zbuff, Bitmap image, Model m)
        {
            Color draw;
            foreach(Side s in m.sides)
            {
                s.FindPointInSide(this.img.Width, this.img.Height);
                draw = s.GetColorFromSun(sun);
                foreach(Point3D p in s.pointInSide)
                {
                    ProcessPoint(zbuff, image, p, draw);
                }
            }
        }

        void ProcessModelFromSun(int[][] zbuffFromSun, Bitmap imageFromSun, Model m)
        {
            Color draw;
            foreach(Side side in m.sides)
            {
                if (side.ignoreFromSun)
                    continue;
                side.FindPointInSide(this.img.Width, this.img.Height);
                draw = side.GetColorFromSun(sun);
                foreach(Point3D p in side.pointInSide)
                {
                    ProcessPoint(zbuffFromSun, imageFromSun, p, draw);
                }
            }
        }
        public ZBuffer(Screen screen, Sun sun, Size size)
        {
            this.size = size;
            this.sun = sun;
            InitTetta();
            img = new Bitmap(size.Width, size.Height);
            imgFromSun = new Bitmap(size.Width, size.Height);

            zbuf = new int[size.Height][];
            zbufFromSun = new int[size.Height][];
            for (int i = 0; i < size.Height; i++)
            {
                zbuf[i] = new int[size.Width];
                zbufFromSun[i] = new int[size.Width];
                for (int j = 0; j < size.Width; j++)
                { 
                    zbuf[i][j] = zBackground;
                    zbufFromSun[i][j] = zBackground;    
                }
            }
            foreach(Model m in screen.model)
            {
                ProcessModel(zbuf, img, m);
                ProcessModelFromSun(zbufFromSun, imgFromSun, m.GetChangeModel(tettax, tettay, tettaz));
            }
        }

        public Bitmap GetImg()
        {
            return img;
        }
        public int GetZ(int x, int y)
        {
            return zbuf[y][x];
        }

        public Bitmap AddShadow()
        {
            Bitmap newImg = new Bitmap(size.Width, size.Height);
            for (int i = 0; i < size.Width; i++)
            {
                for(int j = 0; j < size.Height; j++)
                {
                    int z = GetZ(i, j);
                    if (z != zBackground)
                    {
                        Point3D newPoint = Transformation.Transform(i, j, z, tettax, tettay, tettaz);
                        Color currentColor = img.GetPixel(i, j);
                        if (newPoint.x < 0 || newPoint.y < 0 || newPoint.x >= size.Width || newPoint.y >= size.Height)
                        {
                            newImg.SetPixel(i, j, currentColor); //тени не считаются, чтобы увидеть эти места -> убрать эту строку;
                            continue;
                        }

                        if (zbufFromSun[newPoint.y][newPoint.x] > newPoint.z+1) // текущая точка невидима из источника света
                        {
                            float bPers = 1 - 0.4f;
                            int red = (int)(Color.Black.R * 0.4f + currentColor.R * bPers);
                            int green = (int)(Color.Black.G * 0.4f + currentColor.G * bPers);
                            int blue = (int)(Color.Black.B * 0.4f + currentColor.B * bPers);
                            newImg.SetPixel(i, j, Color.FromArgb(red, green, blue));
                        }
                        else
                        {
                            newImg.SetPixel(i, j, currentColor);
                        }
                    }
                }
            }
            return newImg;
        }

        public Bitmap NewAddShadow()
        {
            Color[][] result = new Color[size.Width][], imgage = new Color[size.Width][];
            for (int i = 0; i < size.Width; ++i)
            {
                result[i] = new Color[size.Height];
                imgage[i] = new Color[size.Height];
                for (int j = 0; j < size.Height; ++j)
                    imgage[i][j] = img.GetPixel(i, j);
            }
            
            Parallel.For(0, size.Width, i =>
            {
                Color[] newColor = result[i];
                for (int j = 0; j < size.Height; j++)
                {
                    int z = GetZ(i, j);
                    if (z != zBackground)
                    {
                        Point3D newPoint = Transformation.Transform(i, j, z, tettax, tettay, tettaz);
                        Color currentColor = imgage[i][j];
                        if (newPoint.x < 0 || newPoint.y < 0 || newPoint.x >= size.Width || newPoint.y >= size.Height)
                        {
                            newColor[j] = currentColor; //тени не считаются, чтобы увидеть эти места -> убрать эту строку;
                            continue;
                        }

                        if (zbufFromSun[newPoint.y][newPoint.x] > newPoint.z + 5) // текущая точка невидима из источника света
                        {
                            float bPers = 1 - 0.4f;
                            int red = (int)(Color.Black.R * 0.4f + currentColor.R * bPers);
                            int green = (int)(Color.Black.G * 0.4f + currentColor.G * bPers);
                            int blue = (int)(Color.Black.B * 0.4f + currentColor.B * bPers);
                            newColor[j] = Color.FromArgb(red, green, blue);
                        }
                        else
                        {
                            newColor[j] = currentColor;
                        }
                    }
                }
            });
            Bitmap newimg = new Bitmap(size.Width, size.Height);
            for (int i = 0; i < size.Width; ++i)
                for (int j = 0; j < size.Height; j++)
                    newimg.SetPixel(i, j, result[i][j]);
            return newimg;
        }
    }
}
