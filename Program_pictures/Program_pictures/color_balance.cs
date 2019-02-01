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
    public partial class color_balance : Form
    {
        change OwnerForm;
        public color_balance(change ownerForm)
        {
            this.OwnerForm = ownerForm;
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button_Click);
            this.FormClosing += new FormClosingEventHandler(color_balance_FormClosing);
        }

        //цветовой баланс R
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change.image.Height; i++)
                for (int j = 0; j < change.image.Width; j++)
                {
                    p = ColorBalance.ColorBalance_R(change.pixel[i, j], trackBar1.Value, trackBar1.Maximum);
                    change.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        //цветовой баланс G
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change.image.Height; i++)
                for (int j = 0; j < change.image.Width; j++)
                {
                    p = ColorBalance.ColorBalance_G(change.pixel[i, j], trackBar2.Value, trackBar2.Maximum);
                    change.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        //цветовой баланс B
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            UInt32 p;
            for (int i = 0; i < change.image.Height; i++)
                for (int j = 0; j < change.image.Width; j++)
                {
                    p = ColorBalance.ColorBalance_B(change.pixel[i, j], trackBar3.Value, trackBar3.Maximum);
                    change.FromOnePixelToBitmap(i, j, p);
                }

            FromBitmapToScreen();
        }

        //сохранение изменений яркости или контрастности
        private void button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < change.image.Height; i++)
                    for (int j = 0; j < change.image.Width; j++)
                        change.pixel[i, j] = (UInt32)(change.image.GetPixel(j, i).ToArgb());
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

        private void color_balance_FormClosing(object sender, FormClosingEventArgs e)
        {
            change.FromPixelToBitmap();
            FromBitmapToScreen();
        }        
    }
}
