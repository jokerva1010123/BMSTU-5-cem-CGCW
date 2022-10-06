using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace cu
{
    class Polygon
    {
        List<Point3D> points;
        public Color color = Color.Gray;
        public bool sun_ignore = false;
        public List<Point3D> pointsInside;

        public Polygon(List<Point3D> point_polygon, Color color, bool sun_ignore = false)
        {
            
            this.points = point_polygon;
            this.color = color;
            this.sun_ignore = sun_ignore;
        }

        public void FindPointsInside(int maxX, int maxY)
        {
            pointsInside = new List<Point3D>();
            if (points.Count() == 3)
            {
                FindPointsInsideTriangle(points, maxX, maxY);
            }   
            else
            {
                List<Point3D>triangle = new List<Point3D>();
                triangle.Add(points[0]);
                triangle.Add(points[1]);
                triangle.Add(points[2]);
                FindPointsInsideTriangle(triangle, maxX, maxY);
                triangle = new List<Point3D>();
                triangle.Add(points[0]);
                triangle.Add(points[2]);
                triangle.Add(points[3]);
                FindPointsInsideTriangle(triangle, maxX, maxY);
            }
        }
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void FindPointsInsideTriangle(List<Point3D> v, int maxX, int maxY)
        {
            int[] x = new int[3], y = new int[3];
            for (int i = 0; i < 3; i++)
            {
                x[i] = v[i].x;
                y[i] = v[i].y;
            }

            int ymax = y.Max(), ymin = y.Min();
            int x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;
            
            for(int yDot = ymin; yDot <= ymax; ++yDot)
            {
                int first = 1;
                for(int n = 0; n < 3; ++n)
                {
                    int n1 = (n == 2) ? 0 : n + 1;
                    if (yDot >= Math.Max(y[n], y[n1]) || yDot < Math.Min(y[n], y[n1]))
                        continue;

                    double m = (double)(y[n] - yDot) / (y[n] - y[n1]);
                    if (first == 0)
                    {
                        x2 = x[n] + (int)(m * (x[n1] - x[n]));
                        z2 = v[n].z + m * (v[n1].z - v[n].z);
                    }
                    else
                    {
                        x1 = x[n] + (int)(m * (x[n1] - x[n]));
                        z1 = v[n].z + m * (v[n1].z - v[n].z);
                    }
                    first = 0;
                }
                if (x2 < x1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref z1, ref z2);
                }
                for (int xDot = x1; xDot < x2; ++xDot)
                {
                    double m = (double)(x1 - xDot) / (x1 - x2);
                    double zDot = z1 + m * (z2 - z1);
                    pointsInside.Add(new Point3D(xDot, yDot, (int)(zDot)));
                }
            }                    
        }
    }
    class Model
    {
        List<Point3D> vertices;
        public List<Polygon> polygon;
        private List<int[]> indexes;
        public Color color = Color.Black;

        public Model(Color color)
        {
            this.color = color;
            this.vertices = new List<Point3D>();
            this.indexes = new List<int[]>();
            this.polygon = new List<Polygon>();
        }

        public void AddVertice(Point3D vertice)
        {
            this.vertices.Add(vertice);
        }
        public void AddVertice(int x, int y, int z)
        {
            this.vertices.Add(new Point3D(x, y, z));
        }

        public void CreatePolygon(params int[] indexes)
        {
            this.indexes.Add(indexes);
            List<Point3D> pointPolygon = new List<Point3D>();
            foreach (int i in indexes)
            {
                pointPolygon.Add(this.vertices[i]);
            }
            this.polygon.Add(new Polygon(pointPolygon, this.color));
        }

        public void CreatePolygonSpecial(params int[] indexes)
        {
            this.indexes.Add(indexes);
            List<Point3D> pointPolygon = new List<Point3D>();
            foreach (int i in indexes)
            {
                pointPolygon.Add(this.vertices[i]);
            }
            this.polygon.Add(new Polygon(pointPolygon, this.color, true));
        }

        public void TransformModel(double tetax, double tetay, double tetaz)
        {
            tetax = tetax * Math.PI / 180;
            tetay = tetay * Math.PI / 180;
            tetaz = tetaz * Math.PI / 180;
            double cosTetX = Math.Cos(tetax), sinTetX = Math.Sin(tetax);
            double cosTetY = Math.Cos(tetay), sinTetY = Math.Sin(tetay);
            double cosTetZ = Math.Cos(tetaz), sinTetZ = Math.Sin(tetaz);
            foreach (Point3D v in vertices)
            {
                Transformation.Transform(ref v.x, ref v.y, ref v.z, cosTetX, sinTetX, cosTetY, sinTetY, cosTetZ, sinTetZ);
            }
        }

        public Model GetTurnedModel(double tetax, double tetay, double tetaz)
        {
            Model m = new Model(color);

            foreach (Point3D p in vertices)
            {
                m.AddVertice(p.x, p.y, p.z);
            }

            m.TransformModel(tetax, tetay, tetaz);

            for (int i = 0; i < indexes.Count; i++)
            {
                if (polygon[i].sun_ignore)
                    m.CreatePolygonSpecial(indexes[i]);
                else
                    m.CreatePolygon(indexes[i]);
            }

            return m;
        }
    }

    class Vector
    {
        public double x, y, z;
        public double length;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            FindLength();
        }

        public Vector(Point3D a, Point3D b)
        {
            x = b.x - a.x;
            y = b.y - a.y;
            z = b.z - a.z;
            FindLength();
        }

        public double GetLength()
        {
            return length;
        }

        private void FindLength()
        {
            this.length = Math.Sqrt(x * x + y * y + z * z);
        }
    }
}
