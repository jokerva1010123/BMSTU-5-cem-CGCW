using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Vector dir = new Vector(0, -1, 0);
        int anphasuny = 180, anphasunx = 90;

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
            dir = new Vector(1, 0, 0);
            anphasunx = 90;
            anphasuny = 270;
            SetSun();
            Action();
        }

        private void sun_2_Click(object sender, EventArgs e)
        {
            dir = new Vector(0.5, -0.5, 0);
            anphasunx = 90;
            anphasuny = 225;
            SetSun();
            Action();
        }

        private void sun_3_Click(object sender, EventArgs e)
        {
            dir = new Vector(0, -1, 0); 
            anphasunx = 90;
            anphasuny = 180;
            SetSun();
            Action();
        }

        private void sun_4_Click(object sender, EventArgs e)
        {
            dir = new Vector(-0.5, -0.5, 0);
            anphasunx = 90;
            anphasuny = 145;
            SetSun();
            Action();
        }

        private void sun_5_Click(object sender, EventArgs e)
        {
            dir = new Vector(-1, 0, 0);
            anphasunx = 90;
            anphasuny = 90;
            SetSun();
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

        private void sunleft_Click(object sender, EventArgs e)
        {
            if(anphasuny + 10 > 270)
            {
                MessageBox.Show("Максимальный сдвиг солнца влево", "Error");
                return;
            }
            anphasuny += 10;
            dir.x += 1.0/9;
            dir.y = -1.0 + 1.0 * Math.Abs(anphasuny - 180) / 90;
            currentSun = new Sun(anphasuny, anphasunx, dir);
            Action();
        }

        private void rightsun_Click(object sender, EventArgs e)
        {
            if(anphasuny -10 <   90)
            {
                MessageBox.Show("Максимальный сдвиг солнца вправо", "Error");
                return;
            }
            anphasuny -= 10;
            dir.x -= 1.0/ 9;
            dir.y = -1.0 + 1.0 * Math.Abs(anphasuny - 180) / 90;
            currentSun = new Sun(anphasuny, anphasunx, dir);
            Action();
        }

        private void backsun_Click(object sender, EventArgs e)
        {
            anphasunx -= 10;
            dir.z += 1.0/ 9;
            currentSun = new Sun(anphasuny, anphasunx, dir);
            Action();
        }

        private void frontsun_Click(object sender, EventArgs e)
        {
            anphasunx += 10;
            dir.z -= 1.0 / 9;
            currentSun = new Sun(anphasuny, anphasunx, dir);
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
                MessageBox.Show("Неконкретный ввод", "Error");
                return;
            }
            screen.CreateHouse(color, x, dx, z, dz, h, roof.Checked);
            Action();
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if(anglex == -30)
            {
                MessageBox.Show("Максимальный поворот вниз", "Error");
                return;
            }
            anglex -= 10;
            Action();
        }

        private void Up_Click(object sender, EventArgs e)
        {
            if (anglex == 30)
            {
                MessageBox.Show("Максимальный поворот вверх", "Error");
                return;
            }
            anglex += 10;
            Action();
        }

        private void Left_Click(object sender, EventArgs e)
        {
            if (angley == 40)
            {
                MessageBox.Show("Максимальный поворот влево", "Error");
                return;
            }
            angley += 10;
            Action();
        }

        private void Right_Click(object sender, EventArgs e)
        {
            if (angley == -40)
            {
                MessageBox.Show("Максимальный поворот вправо", "Error");
                return;
            }
            angley -= 10;
            Action();
        }

        private void SetSun()
        {
            currentSun = new Sun(anphasuny, anphasunx, dir);
        }

        private void Compare()
        {
            Screen newScreen = screen.GetChangeScreen(anglex, angley, anglez);
            Stopwatch swObj = new Stopwatch();
            zbuf = new ZBuffer(newScreen, currentSun, canvas.Size);
            swObj.Start();
            canvas.Image = zbuf.AddShadow();
            swObj.Stop();
            Console.WriteLine("Total:=" + swObj.ElapsedTicks);
            swObj.Restart();
            canvas.Image = zbuf.NewAddShadow();
            swObj.Stop();
            Console.WriteLine("Total:=" + swObj.ElapsedTicks);
        }

        private void Action()
        {
            Screen newScreen = screen.GetChangeScreen(anglex, angley, anglez);
            zbuf = new ZBuffer(newScreen, currentSun, canvas.Size);
            
            canvas.Image = zbuf.AddShadow();
            //Compare();
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
                MessageBox.Show("Неконкретный ввод", "Error");
                return;
            }
            canvas.Image = Fog.AddedFog(zbuf, zfar);
        }
    }
}
