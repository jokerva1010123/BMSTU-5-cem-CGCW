using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cu
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Graphics g;
        Screen scene;
        ZBuffer zbuf;
        LightSource currentSun;
        int tettax = 0, tettay = 0, tettaz = 0;
        public Form1()
        {
            InitializeComponent();
            Transformation.SetSize(canvas.Width, canvas.Height);
            img = new Bitmap(canvas.Width, canvas.Height);
            g = canvas.CreateGraphics();
            scene = new screen(canvas.Size);
            scene.createScreen();
            SetSun();
            HandleSceneChange();
        }

        private void SetSun()
        {
            currentSun = new LightSource(Color.White, 180, new Vector(0, -1, 0));
        }

        private void HandleSceneChange()
        {
            screen newsence = scene.GetTurned(tettax, tettay, tettaz);
            zbuf = new ZBuffer(newsence, canvas.Size, currentSun);
            canvas.Image = zbuf.AddShadow();   
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            tettay += 10;
            HandleSceneChange();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            tettay -= 10;
            HandleSceneChange();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            tettax -= 10;
            HandleSceneChange();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            tettax += 10;
            HandleSceneChange();
        }
    }
}
