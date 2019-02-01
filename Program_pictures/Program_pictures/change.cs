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
    public partial class change : Form
    {
        public change(Image img, Rectangle z)
        {
            InitializeComponent();
            image = new Bitmap(img);
            param = z;
        }

        Rectangle param;
        public static UInt32[,] pixel;
        public static Bitmap image;

        private void change_Load(object sender, EventArgs e)
        {
            pixel = new UInt32[image.Height, image.Width];
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    pixel[y, x] = (UInt32)(image.GetPixel(x, y).ToArgb());
            //получение матрицы с пикселями
            Width = image.Width + 40;
            Height = image.Height + 75;
            pictureBox1.Size = image.Size;
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
        }

        
        private void розмитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pixel = Filter.matrix_filtration(image.Width, image.Height, pixel, Filter.N2, Filter.blur);
            FromPixelToBitmap();
            FromBitmapToScreen();
        }
        //преобразование из UINT32 to Bitmap
        public static void FromPixelToBitmap()
        {
            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                    image.SetPixel(x, y, Color.FromArgb((int)pixel[y, x]));
        }

        //преобразование из UINT32 to Bitmap по одному пикселю
        public static void FromOnePixelToBitmap(int x, int y, UInt32 pixel)
        {
            image.SetPixel(y, x, Color.FromArgb((int)pixel));
        }

        //вывод на экран
        public void FromBitmapToScreen()
        {
            pictureBox1.Image = image;
        }

        private void збільшитиРізкістьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pixel = Filter.matrix_filtration(image.Width, image.Height, pixel, Filter.N1, Filter.sharpness);
            //pixel = Filter.matrix_filtration(image.Width, image.Height, pixel, Filter.N5, Filter.sharpness_d);
            FromPixelToBitmap();
            FromBitmapToScreen();
        }

        private void яскравістьКонтрастToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Harshness BrightnessForm = new Harshness(this);
            BrightnessForm.ShowDialog(); //just 'Show' for the control Form1
           
        }

        private void балансКольоруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color_balance ColorBalanceForm = new color_balance(this);
            ColorBalanceForm.ShowDialog();
        }

        private void підтвердитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture main = this.Owner as picture;
            Bitmap bm = new Bitmap(main.pictureBox1.Image);//ваша нвоая картинка
            Bitmap bm1 = new Bitmap(pictureBox1.Image);//ваша маленькая картинка
            Graphics g1 = Graphics.FromImage(bm);
            g1.DrawImage(bm1, param);
            main.pictureBox1.Image = bm;
            g1.Dispose();
        }

        private void change_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
