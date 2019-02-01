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
    public partial class color_balance1 : Form
    {
        change1 OwnerForm;
        public color_balance1(change1 ownerForm)
        {
            this.OwnerForm = ownerForm;
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button_Click);
            this.FormClosing += new FormClosingEventHandler(color_balance1_FormClosing);
        }

        //цветовой баланс R
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change1.image.Height; i++)
                for (int j = 0; j < change1.image.Width; j++)
                {
                    p = ColorBalance.ColorBalance_R(change1.pixel[i, j], trackBar1.Value, trackBar1.Maximum);
                    change1.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        //цветовой баланс G
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change1.image.Height; i++)
                for (int j = 0; j < change1.image.Width; j++)
                {
                    p = ColorBalance.ColorBalance_G(change1.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
                    change1.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        //цветовой баланс B
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change1.image.Height; i++)
                for (int j = 0; j < change1.image.Width; j++)
                {
                    p = ColorBalance.ColorBalance_B(change1.pixel[i, j], trackBar3.Value, trackBar3.Maximum);
                    change1.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        //сохранение изменений яркости или контрастности
        private void button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < change1.image.Height; i++)
                    for (int j = 0; j < change1.image.Width; j++)
                        change1.pixel[i, j] = (UInt32)(change1.image.GetPixel(j, i).ToArgb());
                trackBar1.Value = 0;
                trackBar2.Value = 0;
                trackBar3.Value = 0;
        }

        //вывод изображения на экран
        void FromBitmapToScreen()
        {
            OwnerForm.FromBitmapToScreen();
        }

        //обновление изображения в Bitmap и pictureBox при закрытии окна

        private void color_balance1_FormClosing(object sender, FormClosingEventArgs e)
        {
            change1.FromPixelToBitmap();
            FromBitmapToScreen();
        }        
    }
}
