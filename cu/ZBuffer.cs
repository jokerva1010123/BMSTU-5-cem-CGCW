using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace cu
{
    internal class ZBuffer
    {
        private Bitmap img;
        private Bitmap imgFromSun;
        private Color[][] imgColor;
        private int[][] zbuf;
        private int[][] zbufFromSun;
        Size size;
        double tettax, tettay, tettaz;
        LightSource sun;
        
        public ZBuffer(screen s, Size size, LightSource sun)
        {
            img = new Bitmap(size.Width, size.Height);
            imgFromSun = new Bitmap(size.Width, size.Height);
            this.size = size;
            this.sun = sun;
            imgColor = new Color[size.Width][];
            InitBuff(ref zbuf, size.Width, size.Height, -10000);
            InitBuff(ref zbufFromSun, size.Width, size.Height, -10000);
            InitTetta();
            for (int i = 0; i < size.Width; i++)
            {
                imgColor[i] = new Color[size.Height];
            }
            foreach (Model m in s.GetModel())
            {
                ProcessModel(zbuf, img, m);
                ProcessModelFromSun(zbufFromSun, imgFromSun, m);
            }
        }

        private void InitBuff(ref int[][] buf, int w, int h, int value)
        {
            buf = new int[h][];
            for (int i = 0; i < h; ++i)
            {
                buf[i] = new int[w];
                for (int j = 0; j < w; j++)
                {
                    buf[i][j] = value;
                }
            }
        }

        private void InitTetta()
        {
            tettax = sun.tettax;
            tettay = sun.tettay;
            tettaz = sun.tettaz;
        }

        private void ProcessModel(int[][] zbuf, Bitmap img, Model m)
        {
            Color draw;
            foreach(Polygon polygon in m.polygon)
            {
                polygon.FindPointsInside(img.Width, img.Height);
                draw = polygon.color;
                foreach (Point3D point in polygon.pointsInside)
                {
                    ProcessPoint(zbuf, img, point, polygon.color);
                }
            }
        }

        private void ProcessPoint(int[][] zbuf, Bitmap img, Point3D point, Color color, int w = 850, int h = 1200)
        {
            if (!(point.x < 0|| point.x >= w || point.y < 0 || point.y >= h))
            {
                if (point.z > zbuf[point.x][point.y])
                {
                    zbuf[point.x][point.y] = point.z;
                    img.SetPixel(point.x, point.y, color);
                    imgColor[point.y][point.x] = color;
                }
            }
        }

        private void ProcessModelFromSun(int[][] buffer, Bitmap image, Model m)
        {
            Color draw;
            foreach(Polygon polygon in m.polygon)
            {
                if (polygon.sun_ignore)
                    continue;
                polygon.FindPointsInside(image.Width, image.Height);
                draw = polygon.color;
                foreach(Point3D point in polygon.pointsInside)
                {
                    ProcessPoint(buffer, image, point, draw);
                }
                
            }
        }

        public int GetZ(int x, int y)
        {
            return zbuf[y][x];
        }

        public Bitmap AddShadow()
        {
            Bitmap hm = new Bitmap(size.Width, size.Height);
            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    int z = GetZ(i, j);
                    if (z != -10000)
                    {
                        Point3D newCoord = Transformation.Transform(i, j, z, tettax, tettay, tettaz);
                        Color curPixColor = img.GetPixel(j, i);
                        if (newCoord.x < 0 || newCoord.y < 0 || newCoord.x >= size.Width || newCoord.y >= size.Height)
                        {
                            hm.SetPixel(j, i, curPixColor); //тени не считаются, чтобы увидеть эти места -> убрать эту строку;
                            continue;
                        }

                        if (zbufFromSun[newCoord.y][newCoord.x] > newCoord.z + 5) // текущая точка невидима из источника света
                        {
                            hm.SetPixel(j, i, Color.Black);
                        }
                        else
                        {
                            hm.SetPixel(j, i, curPixColor);
                        }
                    }
                }
            }

            return hm;
        }
    }
}
