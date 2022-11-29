using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic
{
    class Sun
    {
        public Color color = Color.White;
        public Vector direction;
        public double tettax = 90, tettay, tettaz = 0;

        public Sun(double tettay, Vector direction)
        {
            this.direction = direction;
            this.tettay = tettay;
        }   
    }
}
