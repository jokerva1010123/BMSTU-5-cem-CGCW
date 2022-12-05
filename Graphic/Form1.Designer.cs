namespace Graphic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.Up = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.sun_1 = new System.Windows.Forms.Button();
            this.sun_2 = new System.Windows.Forms.Button();
            this.sun_3 = new System.Windows.Forms.Button();
            this.sun_4 = new System.Windows.Forms.Button();
            this.sun_5 = new System.Windows.Forms.Button();
            this.rotate = new System.Windows.Forms.GroupBox();
            this.sun_place = new System.Windows.Forms.GroupBox();
            this.addHouse = new System.Windows.Forms.GroupBox();
            this.colorInput = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.roof = new System.Windows.Forms.CheckBox();
            this.addBuilding = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.heightInput = new System.Windows.Forms.TextBox();
            this.dzInput = new System.Windows.Forms.TextBox();
            this.zCenterInput = new System.Windows.Forms.TextBox();
            this.dxInput = new System.Windows.Forms.TextBox();
            this.xCenterInput = new System.Windows.Forms.TextBox();
            this.fog = new System.Windows.Forms.GroupBox();
            this.addFog = new System.Windows.Forms.Button();
            this.chearFog = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.zfarInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.rotate.SuspendLayout();
            this.sun_place.SuspendLayout();
            this.addHouse.SuspendLayout();
            this.fog.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1200, 800);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // Up
            // 
            this.Up.Location = new System.Drawing.Point(85, 20);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(82, 41);
            this.Up.TabIndex = 1;
            this.Up.Text = "Вверх";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.Up_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 41);
            this.button2.TabIndex = 2;
            this.button2.Text = "Влево";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Left_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(167, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 41);
            this.button3.TabIndex = 3;
            this.button3.Text = "Вправо";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Right_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(85, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 41);
            this.button4.TabIndex = 4;
            this.button4.Text = "Вниз";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Down_Click);
            // 
            // sun_1
            // 
            this.sun_1.Location = new System.Drawing.Point(12, 23);
            this.sun_1.Name = "sun_1";
            this.sun_1.Size = new System.Drawing.Size(105, 33);
            this.sun_1.TabIndex = 5;
            this.sun_1.Text = "Положение 1";
            this.sun_1.UseVisualStyleBackColor = true;
            this.sun_1.Click += new System.EventHandler(this.sun_1_Click);
            // 
            // sun_2
            // 
            this.sun_2.Location = new System.Drawing.Point(143, 23);
            this.sun_2.Name = "sun_2";
            this.sun_2.Size = new System.Drawing.Size(108, 32);
            this.sun_2.TabIndex = 6;
            this.sun_2.Text = "Положение 2";
            this.sun_2.UseVisualStyleBackColor = true;
            this.sun_2.Click += new System.EventHandler(this.sun_2_Click);
            // 
            // sun_3
            // 
            this.sun_3.Location = new System.Drawing.Point(12, 77);
            this.sun_3.Name = "sun_3";
            this.sun_3.Size = new System.Drawing.Size(105, 28);
            this.sun_3.TabIndex = 7;
            this.sun_3.Text = "Положение 3";
            this.sun_3.UseVisualStyleBackColor = true;
            this.sun_3.Click += new System.EventHandler(this.sun_3_Click);
            // 
            // sun_4
            // 
            this.sun_4.Location = new System.Drawing.Point(143, 78);
            this.sun_4.Name = "sun_4";
            this.sun_4.Size = new System.Drawing.Size(105, 27);
            this.sun_4.TabIndex = 8;
            this.sun_4.Text = "Положение 4";
            this.sun_4.UseVisualStyleBackColor = true;
            this.sun_4.Click += new System.EventHandler(this.sun_4_Click);
            // 
            // sun_5
            // 
            this.sun_5.Location = new System.Drawing.Point(78, 121);
            this.sun_5.Name = "sun_5";
            this.sun_5.Size = new System.Drawing.Size(110, 31);
            this.sun_5.TabIndex = 9;
            this.sun_5.Text = "Положение 5";
            this.sun_5.UseVisualStyleBackColor = true;
            this.sun_5.Click += new System.EventHandler(this.sun_5_Click);
            // 
            // rotate
            // 
            this.rotate.Controls.Add(this.button4);
            this.rotate.Controls.Add(this.button3);
            this.rotate.Controls.Add(this.Up);
            this.rotate.Controls.Add(this.button2);
            this.rotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotate.Location = new System.Drawing.Point(1277, 26);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(254, 165);
            this.rotate.TabIndex = 10;
            this.rotate.TabStop = false;
            this.rotate.Text = "Поворот экрана";
            // 
            // sun_place
            // 
            this.sun_place.Controls.Add(this.sun_5);
            this.sun_place.Controls.Add(this.sun_4);
            this.sun_place.Controls.Add(this.sun_3);
            this.sun_place.Controls.Add(this.sun_2);
            this.sun_place.Controls.Add(this.sun_1);
            this.sun_place.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sun_place.Location = new System.Drawing.Point(1277, 206);
            this.sun_place.Name = "sun_place";
            this.sun_place.Size = new System.Drawing.Size(254, 169);
            this.sun_place.TabIndex = 11;
            this.sun_place.TabStop = false;
            this.sun_place.Text = "Положения сонлца";
            // 
            // addHouse
            // 
            this.addHouse.Controls.Add(this.colorInput);
            this.addHouse.Controls.Add(this.label6);
            this.addHouse.Controls.Add(this.roof);
            this.addHouse.Controls.Add(this.addBuilding);
            this.addHouse.Controls.Add(this.label5);
            this.addHouse.Controls.Add(this.label4);
            this.addHouse.Controls.Add(this.label3);
            this.addHouse.Controls.Add(this.label2);
            this.addHouse.Controls.Add(this.label1);
            this.addHouse.Controls.Add(this.heightInput);
            this.addHouse.Controls.Add(this.dzInput);
            this.addHouse.Controls.Add(this.zCenterInput);
            this.addHouse.Controls.Add(this.dxInput);
            this.addHouse.Controls.Add(this.xCenterInput);
            this.addHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addHouse.Location = new System.Drawing.Point(1277, 381);
            this.addHouse.Name = "addHouse";
            this.addHouse.Size = new System.Drawing.Size(277, 231);
            this.addHouse.TabIndex = 12;
            this.addHouse.TabStop = false;
            this.addHouse.Text = "Добавить здание";
            // 
            // colorInput
            // 
            this.colorInput.FormattingEnabled = true;
            this.colorInput.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue",
            "Black",
            "Brown",
            "Yellow"});
            this.colorInput.Location = new System.Drawing.Point(64, 191);
            this.colorInput.Name = "colorInput";
            this.colorInput.Size = new System.Drawing.Size(80, 24);
            this.colorInput.TabIndex = 13;
            this.colorInput.Text = "Blue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Цвет";
            // 
            // roof
            // 
            this.roof.AutoSize = true;
            this.roof.Location = new System.Drawing.Point(167, 142);
            this.roof.Name = "roof";
            this.roof.Size = new System.Drawing.Size(73, 21);
            this.roof.TabIndex = 11;
            this.roof.Text = "Крыша";
            this.roof.UseVisualStyleBackColor = true;
            // 
            // addBuilding
            // 
            this.addBuilding.Location = new System.Drawing.Point(166, 185);
            this.addBuilding.Name = "addBuilding";
            this.addBuilding.Size = new System.Drawing.Size(82, 35);
            this.addBuilding.TabIndex = 10;
            this.addBuilding.Text = "Добавить";
            this.addBuilding.UseVisualStyleBackColor = true;
            this.addBuilding.Click += new System.EventHandler(this.addBuilding_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Высота";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "dz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Центр z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "dx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Центр х";
            // 
            // heightInput
            // 
            this.heightInput.Location = new System.Drawing.Point(78, 142);
            this.heightInput.Name = "heightInput";
            this.heightInput.Size = new System.Drawing.Size(59, 23);
            this.heightInput.TabIndex = 4;
            // 
            // dzInput
            // 
            this.dzInput.Location = new System.Drawing.Point(196, 92);
            this.dzInput.Name = "dzInput";
            this.dzInput.Size = new System.Drawing.Size(37, 23);
            this.dzInput.TabIndex = 3;
            // 
            // zCenterInput
            // 
            this.zCenterInput.Location = new System.Drawing.Point(78, 91);
            this.zCenterInput.Name = "zCenterInput";
            this.zCenterInput.Size = new System.Drawing.Size(60, 23);
            this.zCenterInput.TabIndex = 2;
            // 
            // dxInput
            // 
            this.dxInput.Location = new System.Drawing.Point(194, 45);
            this.dxInput.Name = "dxInput";
            this.dxInput.Size = new System.Drawing.Size(40, 23);
            this.dxInput.TabIndex = 1;
            // 
            // xCenterInput
            // 
            this.xCenterInput.Location = new System.Drawing.Point(78, 42);
            this.xCenterInput.Name = "xCenterInput";
            this.xCenterInput.Size = new System.Drawing.Size(61, 23);
            this.xCenterInput.TabIndex = 0;
            // 
            // fog
            // 
            this.fog.Controls.Add(this.zfarInput);
            this.fog.Controls.Add(this.label7);
            this.fog.Controls.Add(this.chearFog);
            this.fog.Controls.Add(this.addFog);
            this.fog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fog.Location = new System.Drawing.Point(1280, 639);
            this.fog.Name = "fog";
            this.fog.Size = new System.Drawing.Size(273, 173);
            this.fog.TabIndex = 13;
            this.fog.TabStop = false;
            this.fog.Text = "Туман";
            // 
            // addFog
            // 
            this.addFog.Location = new System.Drawing.Point(128, 99);
            this.addFog.Name = "addFog";
            this.addFog.Size = new System.Drawing.Size(139, 28);
            this.addFog.TabIndex = 0;
            this.addFog.Text = "Добавить туман";
            this.addFog.UseVisualStyleBackColor = true;
            this.addFog.Click += new System.EventHandler(this.addFog_Click);
            // 
            // chearFog
            // 
            this.chearFog.Location = new System.Drawing.Point(128, 133);
            this.chearFog.Name = "chearFog";
            this.chearFog.Size = new System.Drawing.Size(138, 28);
            this.chearFog.TabIndex = 1;
            this.chearFog.Text = "Очистить";
            this.chearFog.UseVisualStyleBackColor = true;
            this.chearFog.Click += new System.EventHandler(this.chearFog_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Дальность";
            // 
            // zfarInput
            // 
            this.zfarInput.Location = new System.Drawing.Point(96, 58);
            this.zfarInput.Name = "zfarInput";
            this.zfarInput.Size = new System.Drawing.Size(80, 23);
            this.zfarInput.TabIndex = 3;
            this.zfarInput.Text = "-300";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1684, 861);
            this.Controls.Add(this.fog);
            this.Controls.Add(this.addHouse);
            this.Controls.Add(this.sun_place);
            this.Controls.Add(this.rotate);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.rotate.ResumeLayout(false);
            this.sun_place.ResumeLayout(false);
            this.addHouse.ResumeLayout(false);
            this.addHouse.PerformLayout();
            this.fog.ResumeLayout(false);
            this.fog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button sun_1;
        private System.Windows.Forms.Button sun_2;
        private System.Windows.Forms.Button sun_3;
        private System.Windows.Forms.Button sun_4;
        private System.Windows.Forms.Button sun_5;
        private System.Windows.Forms.GroupBox rotate;
        private System.Windows.Forms.GroupBox sun_place;
        private System.Windows.Forms.GroupBox addHouse;
        private System.Windows.Forms.Button addBuilding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox heightInput;
        private System.Windows.Forms.TextBox dzInput;
        private System.Windows.Forms.TextBox zCenterInput;
        private System.Windows.Forms.TextBox dxInput;
        private System.Windows.Forms.TextBox xCenterInput;
        private System.Windows.Forms.CheckBox roof;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox colorInput;
        private System.Windows.Forms.GroupBox fog;
        private System.Windows.Forms.Button chearFog;
        private System.Windows.Forms.Button addFog;
        private System.Windows.Forms.TextBox zfarInput;
        private System.Windows.Forms.Label label7;
    }
}

