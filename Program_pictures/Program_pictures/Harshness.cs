﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_pictures
{
    public partial class Harshness : Form
    {
        change OwnerForm;
        public Harshness(change ownerForm)
        {
            this.OwnerForm = ownerForm;
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button_Click);
            this.FormClosing += new FormClosingEventHandler(Harshness_FormClosing);
        }

        private void button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < change.image.Height; i++)
                for (int j = 0; j < change.image.Width; j++)
                    change.pixel[i, j] = (UInt32)(change.image.GetPixel(j, i).ToArgb());
                trackBar1.Value = 0;
                trackBar2.Value = 0;
        }


        private void Harshness_FormClosing(object sender, FormClosingEventArgs e)
        {
            change.FromPixelToBitmap();
            FromBitmapToScreen();
        }
        void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change.image.Height; i++)
                for (int j = 0; j < change.image.Width; j++)
                {
                    p = BrightnessContrast.Brightness(change.pixel[i, j], trackBar1.Value, trackBar1.Maximum);
                    change.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change.image.Height; i++)
                for (int j = 0; j < change.image.Width; j++)
                {
                    p = BrightnessContrast.Contrast(change.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
                    change.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }
    }
}
