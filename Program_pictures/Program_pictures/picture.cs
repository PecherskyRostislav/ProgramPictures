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
    public partial class picture : Form
    {
        public picture(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
            image = new Bitmap(img);
        }

        public static Bitmap image;
        public static string full_name_of_image = "\0"; 
        // для того что бы при выделении был прямоугольник
        Rectangle selRect;
        Point orig;
        Pen pen = new Pen(Brushes.Green, 1f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        bool perem = false;
        int x, y;
        private void Selection_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, selRect);
        }
        //---------------
        bool obl = false;
        Rectangle stat_rec;


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            perem = true;
            obl = false;
            x = e.X;
            y = e.Y;
            //Назначаем процедуру рисования при выделении
            pictureBox1.Paint -= pictureBox1_Paint;
            pictureBox1.Paint += Selection_Paint;
            orig = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //при движении мышкой считаем прямоугольник и обновляем picturebox
            selRect = Filter.GetSelRectangle(orig, e.Location);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                (sender as PictureBox).Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //рисование
            pictureBox1.Paint -= Selection_Paint;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.Invalidate();
            perem = false;
            obl = true;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.Refresh();
            if (x != e.X)
            {
                //открытие формы изменений   
                stat_rec = Filter.coord_pict(x, y, e.X, e.Y);
                Form f = new change(Filter.copy_pict(pictureBox1.Image, stat_rec), stat_rec);
                f.Owner = this;
                f.ShowDialog();               
            }
            else
                MessageBox.Show("Занадто малий малюнок!");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (perem == true)
                e.Graphics.DrawRectangle(Pens.Black, selRect);
            if (obl == true)
                e.Graphics.DrawRectangle(pen, stat_rec);
        }

        private void picture_Load(object sender, EventArgs e)
        {
            Width = image.Width + 35;
            Height = image.Height + 80;
            pictureBox1.Size = image.Size;
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            perem = false;
            obl = false;
            pictureBox1.Paint -= pictureBox1_Paint;
            if (pictureBox1.Image != null)
            {
                //string format = full_name_of_image.Substring(full_name_of_image.Length - 4, 4);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Bitmap bmpSave = (Bitmap)pictureBox1.Image;
                        pictureBox1.DrawToBitmap(bmpSave, pictureBox1.ClientRectangle);
                        bmpSave.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        //image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //открытие картинки
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    full_name_of_image = open_dialog.FileName;
                    image = new Bitmap(open_dialog.FileName);
                    //this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Width = image.Width + 35;
                    Height = image.Height + 80;
                    pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    full_name_of_image = "\0";
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void повернутисьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
