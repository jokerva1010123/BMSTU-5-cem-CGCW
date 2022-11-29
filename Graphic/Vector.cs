using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic
{
    class Vector
    {
        public double x, y, z;
        public double length;

        private double getLength()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.length = getLength();
        }

        public static double ScalarMultiplication(Vector a, Vector b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
