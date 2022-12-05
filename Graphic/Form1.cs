using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        bool addedFog = false;
        int zfar;

        public Form1()
        {
            InitializeComponent();
            Transformation.SetSize(canvas.Width, canvas.Height);
            screen = new Screen(canvas.Size);
            screen.CreateScreen();
            SetSun();
            Action();
        }

        private void sun_1_Click(object sender, EventArgs e)
        {
            currentSun = sun1;
            Action();
        }

        private void sun_2_Click(object sender, EventArgs e)
        {
            currentSun = sun2;
            Action();
        }

        private void sun_3_Click(object sender, EventArgs e)
        {
            currentSun = sun3;
            Action();
        }

        private void sun_4_Click(object sender, EventArgs e)
        {
            currentSun = sun4;
            Action();
        }

        private void sun_5_Click(object sender, EventArgs e)
        {
            currentSun = sun5;
            Action();
        }

        private void addFog_Click(object sender, EventArgs e)
        {
            addedFog = true;
            Action();
        }

        private void chearFog_Click(object sender, EventArgs e)
        {
            addedFog = false;
            Action();
        }

        private void addBuilding_Click(object sender, EventArgs e)
        {
            int x, z, dx, dz, h;
            Color color;
            try
            {
                x = Convert.ToInt32(xCenterInput.Text);
                z = Convert.ToInt32(zCenterInput.Text);
                dx = Convert.ToInt32(dxInput.Text);
                dz = Convert.ToInt32(dzInput.Text);
                h = Convert.ToInt32(heightInput.Text);
                color = Color.FromName(colorInput.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Input error", "Error");
                return;
            }
            screen.CreateHouse(color, x, dx, z, dz, h, roof.Checked);
            Action();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if(anglex == -30)
            {
                MessageBox.Show("Min x", "Error");
                return;
            }
            anglex -= 10;
            Action();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (anglex == 30)
            {
                MessageBox.Show("Max x", "Error");
                return;
            }
            anglex += 10;
            Action();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            if (angley == 40)
            {
                MessageBox.Show("Max y", "Error");
                return;
            }
            angley += 10;
            Action();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (angley == -40)
            {
                MessageBox.Show("Min y", "Error");
                return;
            }
            angley -= 10;
            Action();
        }

        private void SetSun()
        {
            sun1 = new Sun( -90, new Vector(1, 0, 0));
            sun2 = new Sun(-110, new Vector(0.4, -0.5, 0));
            sun3 = new Sun(180, new Vector(0, -1, 0));
            sun4 = new Sun(110, new Vector(-0.4, -0.5, 0));
            sun5 = new Sun(90, new Vector(-1, 0, 0));
            currentSun = sun3;
        }

        private void Action()
        {
            Screen newScreen = screen.GetChangeScreen(anglex, angley, anglez);
            zbuf = new ZBuffer(newScreen, currentSun, canvas.Size);
            canvas.Image = zbuf.AddShadow();
            if (!addedFog)
            {
                return;
            }
            try
            {
                zfar = Convert.ToInt32(zfarInput.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Error Input", "Error");
                return;
            }
            canvas.Image = Fog.AddedFog(zbuf, zfar);
        }
    }
}
