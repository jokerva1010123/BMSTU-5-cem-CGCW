using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cu
{
    internal class LightSource
    {
        public Color color;
        public double tettax = 90, tettay = 0, tettaz = 0;
        public Vector direction;

        public LightSource(Color color, double tettay, Vector direction)
        {
            this.color = color;
            this.tettay = tettay;
            this.direction = direction;
        }
    }
}
