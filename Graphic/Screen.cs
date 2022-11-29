using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Linq;

namespace Graphic
{
    class Screen
    {
        Size size;
        static int ground = 700;
        public List<Model> model;

        public Screen(Size size)
        {
            this.size = size;
            model = new List<Model>();
        }

        private void CreateGround(Color color, int xCenter, int dx, int zCenter, int dz, int height)
        {
            Model m = new Model(color);

            m.AddPointOfModel(new Point3D(xCenter- dx, ground + height, zCenter + dz)); // левая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground + height, zCenter + dz)); // правая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground, zCenter + dz)); // правая верхняя
            m.AddPointOfModel(new Point3D(xCenter - dx, ground, zCenter + dz)); // левая верхняя

            // задняя
            m.AddPointOfModel(new Point3D(xCenter - dx, ground + height, zCenter - dz)); // левая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground + height, zCenter - dz)); // правая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground, zCenter - dz)); // правая верхняя
            m.AddPointOfModel(new Point3D(xCenter - dx, ground, zCenter - dz)); // левая верхняя

            m.CreateSide(true, 3, 2, 6, 7); // верхняя
            m.CreateSide(true, 0, 1, 2, 3); // передняя
            m.CreateSide(true, 0, 3, 7, 4); // левая
            m.CreateSide(true, 4, 7, 6, 5); // задняя
            m.CreateSide(true, 1, 5, 6, 2); // правая
            m.CreateSide(true, 0, 4, 5, 1); // нижняя

            model.Add(m);
        }

        private void CreateHouse(Color color, int xCenter, int dx, int zCenter, int dz, int height, Boolean roof = false)
        {
            Model m = new Model(color);

            m.AddPointOfModel(new Point3D(xCenter - dx, ground, zCenter + dz)); // левая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground, zCenter + dz)); // правая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground - height, zCenter + dz)); // правая верхняя
            m.AddPointOfModel(new Point3D(xCenter - dx, ground - height, zCenter + dz)); // левая верхняя

            // задняя
            m.AddPointOfModel(new Point3D(xCenter - dx, ground, zCenter - dz)); // левая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground, zCenter - dz)); // правая нижняя
            m.AddPointOfModel(new Point3D(xCenter + dx, ground - height, zCenter - dz)); // правая верхняя
            m.AddPointOfModel(new Point3D(xCenter - dx, ground - height, zCenter - dz)); // левая верхняя

            m.CreateSide(false, 3, 2, 6, 7); // верхняя
            m.CreateSide(false, 0, 1, 2, 3); // передняя
            m.CreateSide(false, 0, 3, 7, 4); // левая
            m.CreateSide(false, 4, 7, 6, 5); // задняя
            m.CreateSide(false, 1, 5, 6, 2); // правая
            m.CreateSide(false, 0, 4, 5, 1); // нижняя

            if (roof)
            {
                m.AddPointOfModel(new Point3D(xCenter, ground - height - 40, zCenter));
                m.CreateSide(false, 3, 2, 8);
                m.CreateSide(false, 7, 3, 8);
                m.CreateSide(false, 6, 7, 8);
                m.CreateSide(false, 2, 6, 8);
            }

            model.Add(m);
        }

        public void CreateScreen()
        {
            CreateGround(Color.Green, size.Width/2, 500, 0, 500, 5);
            CreateHouse(Color.Red, size.Width/2, 100, 0, 150, 300);
            CreateHouse(Color.Yellow, 300, 50, 0, 100, 300, true);
        }

        public Screen GetChangeScreen(double anglex, double angley, double anglez)
        {
            Screen newScreen = new Screen(this.size);
            foreach (Model m in this.model)
            {
                newScreen.model.Add(m.GetChangeModel(anglex, angley, anglez));
            }
            return newScreen;
        }
    }
}
