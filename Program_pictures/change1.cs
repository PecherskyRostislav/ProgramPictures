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
    public partial class change1 : Form
    {
        public change1(Image img, Rectangle z)
        {
            InitializeComponent();
            image = new Bitmap(img);
            param = z;
        }

        Rectangle param;
        bool proverca;
        public static UInt32[,] pixel;
        public static Bitmap image;

        private void change1_Load(object sender, EventArgs e)
        {
            proverca = false;
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
            proverca = true;
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
            Harshness1 BrightnessForm = new Harshness1(this);
            BrightnessForm.ShowDialog(); //just 'Show' for the control Form1
           
        }

        private void балансКольоруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color_balance1 ColorBalanceForm = new color_balance1(this);
            ColorBalanceForm.ShowDialog();
        }

        private void change1_FormClosing(object sender, FormClosingEventArgs e)
        {
            picture.schet--;
            picture.prov[1] = true;
            if (proverca)
            {
                if (MessageBox.Show("Ви впевнені що хочете вийти без збереження?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void підтвердитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.q_saving = true;
            proverca = false;
            picture main = this.Owner as picture;
            picture.stat_rec = picture.zed[1];
            Bitmap bm = new Bitmap(main.pictureBox1.Image);//ваша нвоая картинка
            Bitmap bm1 = new Bitmap(image);//ваша маленькая картинка
            Graphics g1 = Graphics.FromImage(bm);
            g1.DrawImage(bm1, picture.zed[1]);
            main.pictureBox1.Image = bm;
            g1.Dispose();
        }

        private void змінитиПоложенняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            picture.nom_form = 1;
            List<Form> openForms = new List<Form>();
            foreach (Form form in Application.OpenForms)
                openForms.Add(form);
            foreach (Form form in openForms)
            {
                if (form.Name != "picture" && form.Name != "main")
                    form.Hide();
                else
                    form.Activate();
            }
        }
    }
}
