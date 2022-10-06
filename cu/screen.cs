using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace cu
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

    class screen
    {
        List<Model> sence;
        Size size;
        int ground = 500;
        public screen(Size size)
        {
            sence = new List<Model>();
            this.size = size;
        }
        public void createScreen()
        {
            CreateGround(Color.Green, size.Width / 2, 400, 0, 500, 5);
        }
        private void CreateGround(Color color, int xCenter, int dx, int zCenter, int dz, int height)
        {
            Model m = new Model(color);
            //передняя
            m.AddVertice(new Point3D(xCenter - dx, ground + height, zCenter + dz)); // левая нижняя
            m.AddVertice(new Point3D(xCenter + dx, ground + height, zCenter + dz)); // правая нижняя
            m.AddVertice(new Point3D(xCenter + dx, ground, zCenter + dz)); // правая верхняя
            m.AddVertice(new Point3D(xCenter - dx, ground, zCenter + dz)); // левая верхняя
            // задняя
            m.AddVertice(new Point3D(xCenter - dx, ground + height, zCenter - dz)); // левая нижняя
            m.AddVertice(new Point3D(xCenter + dx, ground + height, zCenter - dz)); // правая нижняя
            m.AddVertice(new Point3D(xCenter + dx, ground, zCenter - dz)); // правая верхняя
            m.AddVertice(new Point3D(xCenter- dx, ground, zCenter - dz)); // левая верхняя

            m.CreatePolygonSpecial(3, 2, 6, 7); // верхняя
            m.CreatePolygonSpecial(0, 1, 2, 3); // передняя
            m.CreatePolygonSpecial(0, 3, 7, 4); // левая
            m.CreatePolygonSpecial(4, 7, 6, 5); // задняя
            m.CreatePolygonSpecial(1, 5, 6, 2); // правая
            m.CreatePolygonSpecial(0, 4, 5, 1); // нижняя

            sence.Add(m);
        }
        public List<Model> GetModel()
        {
            return this.sence;
        }
        public screen GetTurned(double tetax, double tetay, double tetaz)
        {
            screen s = new screen(size);

            foreach (Model m in sence)
            {
                s.sence.Add(m.GetTurnedModel(tetax, tetay, tetaz));
            }

            return s;
        }
    }
}