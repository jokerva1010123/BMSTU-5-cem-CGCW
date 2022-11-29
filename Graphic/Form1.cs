using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic
{
    public partial class Form1 : Form
    {
        Screen screen;
        Sun currentSun, sun1, sun2, sun3, sun4, sun5;
        double anglex = -10, angley = 0, anglez = 0;

        ZBuffer zbuf;

        private void Down_Click(object sender, EventArgs e)
        {
            anglex -= 10;
            Action();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            anglex += 10;
            Action();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            angley -= 10;
            Action();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            angley += 10;
            Action();
        }

        private void SetSun()
        {
            sun1 = new Sun( -90, new Vector(1, 0, 0));
            sun2 = new Sun(-110, new Vector(0.4, -0.5, 0));
            sun3 = new Sun(180, new Vector(0, -1, 0));
            sun4 = new Sun(110, new Vector(-0.4, -0.5, 0));
            sun5 = new Sun(90, new Vector(-1, 0, 0));
            currentSun = sun4;
        }
        public Form1()
        {
            InitializeComponent();
            Transformation.SetSize(canvas.Width, canvas.Height);
            screen = new Screen(canvas.Size);
            screen.CreateScreen();
            SetSun();
            Action();
        }

        private void Action()
        {
            Screen newScreen = screen.GetChangeScreen(anglex, angley, anglez);
            zbuf = new ZBuffer(newScreen, currentSun, canvas.Size);
            canvas.Image = zbuf.AddShadow();
        }
    }
}
