using System;
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
    public partial class Harshness1 : Form
    {
        change1 OwnerForm;
        public Harshness1(change1 ownerForm)
        {
            this.OwnerForm = ownerForm;
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button_Click);
            this.FormClosing += new FormClosingEventHandler(Harshness1_FormClosing);
        }

        private void button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < change1.image.Height; i++)
                for (int j = 0; j < change1.image.Width; j++)
                    change1.pixel[i, j] = (UInt32)(change1.image.GetPixel(j, i).ToArgb());
                trackBar1.Value = 0;
                trackBar2.Value = 0;
        }


        private void Harshness1_FormClosing(object sender, FormClosingEventArgs e)
        {
            change1.FromPixelToBitmap();
            FromBitmapToScreen();
        }
        void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change1.image.Height; i++)
                for (int j = 0; j < change1.image.Width; j++)
                {
                    p = BrightnessContrast.Brightness(change1.pixel[i, j], trackBar1.Value, trackBar1.Maximum);
                    change1.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change1.image.Height; i++)
                for (int j = 0; j < change1.image.Width; j++)
                {
                    p = BrightnessContrast.Contrast(change1.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
                    change1.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }
    }
}
