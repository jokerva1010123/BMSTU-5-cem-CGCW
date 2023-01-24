using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Graphic
{
    class Point3D
    {
        public int x, y, z;
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    class Side
    {
        List<Point3D> pointOfSide;
        public List<Point3D> pointInSide;
        Color colorofSide = Color.Gray;
        public bool ignoreFromSun = false;
        Vector normal;
        public Vector GetNormal()
        {
            int len = pointOfSide.Count();
            int a = 0, b = 0, c = 0;
            for (int i = 0; i < len - 1; i++)
            {
                a += (pointOfSide[i].y - pointOfSide[i + 1].y) * (pointOfSide[i].z + pointOfSide[i + 1].z);
                b += (pointOfSide[i].x - pointOfSide[i + 1].x) * (pointOfSide[i].z + pointOfSide[i + 1].z);
                c += (pointOfSide[i].x - pointOfSide[i + 1].x) * (pointOfSide[i].y + pointOfSide[i + 1].y);
            }
            a += (pointOfSide[len - 1].y - pointOfSide[0].y) * (pointOfSide[len - 1].z + pointOfSide[0].z);
            b += (pointOfSide[len - 1].x - pointOfSide[0].x) * (pointOfSide[len - 1].z + pointOfSide[0].z);
            c += (pointOfSide[len - 1].x - pointOfSide[0].x) * (pointOfSide[len - 1].y + pointOfSide[0].y);

            return new Vector(a, b, c);
        }
        public Side()
        {
            pointOfSide = new List<Point3D>();
            pointInSide = new List<Point3D>();
        }
        public Side(List<Point3D> pointOfSide, Color color, Boolean ignoreFromSun)
        {
            this.colorofSide = color;
            this.pointOfSide = pointOfSide;
            this.ignoreFromSun = ignoreFromSun;
            normal = GetNormal();
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        void FindPointsInsideTriangle(List<Point3D> p, int xEnd, int yEnd)
        {
            int xStart = 0, yStart = 0;
            int yMax, yMin;
            int[] x = new int[3], y = new int[3];

            for (int i = 0; i < 3; ++i)
            {
                x[i] = p[i].x;
                y[i] = p[i].y;
            }

            yMax = y.Max();
            yMin = y.Min();

            yMin = (yMin < yStart) ? yStart : yMin;
            yMax = (yMax < yEnd) ? yMax : yEnd;

            int x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;

            for (int yDot = yMin; yDot <= yMax; yDot++)
            {
                int fFirst = 1;
                for (int n = 0; n < 3; ++n)
                {
                    int n1 = (n == 2) ? 0 : n + 1;

                    if (yDot >= Math.Max(y[n], y[n1]) || yDot < Math.Min(y[n], y[n1]))
                        continue; // точка вне

                    double m = (double)(y[n] - yDot) / (y[n] - y[n1]);
                    if (fFirst == 0)
                    {
                        x2 = x[n] + (int)(m * (x[n1] - x[n]));
                        z2 = p[n].z + m * (p[n1].z - p[n].z);
                    }
                    else
                    {
                        x1 = x[n] + (int)(m * (x[n1] - x[n]));
                        z1 = p[n].z + m * (p[n1].z - p[n].z);
                    }
                    fFirst = 0;
                }

                if (x2 < x1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref z1, ref z2);
                }

                int xMin = (x1 < xStart) ? xStart : x1;
                int xMax = (x2 < xEnd) ? x2 : xEnd;
                for (int xDot = xMin; xDot < xMax; xDot++)
                {
                    double m = (double)(x1 - xDot) / (x1 - x2);
                    double zDot = z1 + m * (z2 - z1);

                    this.pointInSide.Add(new Point3D(xDot, yDot, (int)zDot));
                }
            }
        }
        public void FindPointInSide(int maxX, int maxY)
        {
            pointInSide = new List<Point3D>();

            if (pointOfSide.Count == 4)
            {
                List<Point3D> triangle = new List<Point3D>();
                triangle.Add(pointOfSide[0]);
                triangle.Add(pointOfSide[2]);
                triangle.Add(pointOfSide[1]);
                FindPointsInsideTriangle(triangle, maxX, maxY);
                triangle = new List<Point3D>();
                triangle.Add(pointOfSide[0]);
                triangle.Add(pointOfSide[2]);
                triangle.Add(pointOfSide[3]);
                FindPointsInsideTriangle(triangle, maxX, maxY);
            }
            else
            {
                FindPointsInsideTriangle(pointOfSide, maxX, maxY);
            }
        }
        public Color GetColorFromSun(Sun sun)
        {
            double cos = Math.Min(Vector.ScalarMultiplication(sun.direction, normal) /
                (sun.direction.length * normal.length), 1.0);
            if (cos <= 0)
            {
                float bPers = 1 - (float)0.2f;
                int red = (int)(colorofSide.R * 0.2f + Color.Black.R * bPers);
                int green = (int)(colorofSide.G * 0.2f + Color.Black.G * bPers);
                int blue = (int)(colorofSide.B * 0.2f + Color.Black.B * bPers);
                return Color.FromArgb(red, green, blue);
            }
            else
            {
                float bPers = 1 - (float)cos;
                int red = (int)(colorofSide.R * cos + Color.Black.R * bPers);
                int green = (int)(colorofSide.G * cos + Color.Black.G * bPers);
                int blue = (int)(colorofSide.B * cos + Color.Black.B * bPers);
                return Color.FromArgb(red, green, blue);
            }
        }
    }
    class Model
    {
        public Color colorOfModel = Color.Black;
        List<Point3D> pointOfModel;
        public List<Side> sides;
        List<int[]> indexOfPoints;
        public Model(Color color)
        {
            this.colorOfModel = color;
            pointOfModel = new List<Point3D>();
            sides = new List<Side>();
            indexOfPoints = new List<int[]>();
        }
        public void AddPointOfModel(Point3D point)
        {
            pointOfModel.Add(point);
        }
        public void AddPointOfModel(int x, int y, int z)
        {
            pointOfModel.Add(new Point3D(x, y, z));
        }
        public void CreateSide(bool ignoreFromSun, params int[] indexOfPoints)
        {

            this.indexOfPoints.Add(indexOfPoints);
            List<Point3D> side = new List<Point3D>();
            foreach (int i in indexOfPoints)
            {
                side.Add(pointOfModel[i]);
            }
            sides.Add(new Side(side, colorOfModel, ignoreFromSun));
        }
        public void ChangePoint(double anglex, double angley, double anglez, int dz)
        {
            double tetax = anglex * Math.PI / 180;
            double tetay = angley * Math.PI / 180;
            double tetaz = anglez * Math.PI / 180;
            double cosTetX = Math.Cos(tetax), sinTetX = Math.Sin(tetax);
            double cosTetY = Math.Cos(tetay), sinTetY = Math.Sin(tetay);
            double cosTetZ = Math.Cos(tetaz), sinTetZ = Math.Sin(tetaz);
            foreach (Point3D v in this.pointOfModel)
            {
                Transformation.Transform(ref v.x, ref v.y, ref v.z, cosTetX, sinTetX, cosTetY, sinTetY, cosTetZ, sinTetZ);
            }
        }
        public void ChangePoint(double anglex, double angley, double anglez)
        {
            double tetax = anglex * Math.PI / 180;
            double tetay = angley * Math.PI / 180;
            double tetaz = anglez * Math.PI / 180;
            double cosTetX = Math.Cos(tetax), sinTetX = Math.Sin(tetax);
            double cosTetY = Math.Cos(tetay), sinTetY = Math.Sin(tetay);
            double cosTetZ = Math.Cos(tetaz), sinTetZ = Math.Sin(tetaz);
            foreach (Point3D v in this.pointOfModel)
            {
                Transformation.Transform(ref v.x, ref v.y, ref v.z, cosTetX, sinTetX, cosTetY, sinTetY, cosTetZ, sinTetZ);
            }
        }
        public Model GetChangeModel(double anglex, double angley, double anglez)
        {
            Model newModel = new Model(this.colorOfModel);
            foreach(Point3D p in pointOfModel)
            {
                newModel.AddPointOfModel(p.x, p.y, p.z);
            }
            newModel.ChangePoint(anglex, angley, anglez);

            for (int i = 0; i < indexOfPoints.Count; i++)
            {
                newModel.CreateSide(this.sides[i].ignoreFromSun, indexOfPoints[i]);
            }
            return newModel;
        }
    }
}
