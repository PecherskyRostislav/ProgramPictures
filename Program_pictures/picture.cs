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

        public static bool q_saving = false;
        public static Bitmap image;
        public static string full_name_of_image = "\0"; 
        // для того что бы при выделении был прямоугольник
        Rectangle selRect;
        Point orig;
        Pen pen = new Pen(Brushes.Green, 2.0f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        bool perem = false;
        int x, y;

        public static int nom_form = -1;


        private void Selection_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, selRect);
        }

        //---------------
        bool obl = false;
        public static Rectangle stat_rec;


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (nom_form)
            {
                case -1:
                    {
                        perem = true;
                        obl = false;
                        x = e.X;
                        y = e.Y;
                        //Назначаем процедуру рисования при выделении
                        pictureBox1.Paint -= pictureBox1_Paint;
                        pictureBox1.Paint += Selection_Paint;
                        orig = e.Location;
                        break;
                    }
                case 0:
                    {
                        zed[0].X = e.X;
                        zed[0].Y = e.Y;
                        break;
                    }
                case 1:
                    {
                        zed[1].X = e.X;
                        zed[1].Y = e.Y;
                        break;
                    }
                case 2:
                    {
                        zed[2].X = e.X;
                        zed[2].Y = e.Y;
                        break;
                    }
            }
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (nom_form == -1)
            {
                //при движении мышкой считаем прямоугольник и обновляем picturebox
                selRect = Filter.GetSelRectangle(orig, e.Location);
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    (sender as PictureBox).Refresh();
            }            
        }

        public static int schet = 0;
        public static bool[] prov = new bool[3];
        public static Rectangle[] zed = new Rectangle[3];

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form form in Application.OpenForms)
                openForms.Add(form);
            

            switch (nom_form)
            {
                case -1:
                    {
                        //рисование
                        pictureBox1.Paint -= Selection_Paint;
                        pictureBox1.Paint += pictureBox1_Paint;
                        pictureBox1.Invalidate();
                        perem = false;
                        obl = true;
                        pictureBox1.Paint += pictureBox1_Paint;
                        pictureBox1.Refresh();
                        if (schet != 3)
                        {
                            if (x != e.X)
                            {
                                schet++;
                                //открытие формы изменений   
                                stat_rec = Filter.coord_pict(x, y, e.X, e.Y);
                                if (prov[0])
                                {
                                    Form f = new change(Filter.copy_pict(pictureBox1.Image, stat_rec));
                                    f.Owner = this;
                                    f.Show();
                                    prov[0] = false;
                                    zed[0] = stat_rec;
                                    return;
                                }
                                if (prov[1])
                                {
                                    Form f = new change1(Filter.copy_pict(pictureBox1.Image, stat_rec), stat_rec);
                                    f.Owner = this;
                                    f.Show();
                                    prov[1] = false;
                                    zed[1] = stat_rec;
                                    return;
                                }
                                if (prov[2])
                                {
                                    Form f = new change2(Filter.copy_pict(pictureBox1.Image, stat_rec), stat_rec);
                                    f.Owner = this;
                                    f.Show();
                                    prov[2] = false;
                                    zed[2] = stat_rec;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не більше 3х малюнків.");
                        }
                        break;
                    }
                case 0:
                    {
                        foreach (Form form in openForms)
                        {
                            form.Show();
                        }
                        nom_form = -1;
                        break;
                    }
                case 1:
                    {
                        foreach (Form form in openForms)
                        {
                            form.Show();
                        }
                        nom_form = -1;
                        break;
                    }
                case 2:
                    {
                        foreach (Form form in openForms)
                        {
                            form.Show();
                        }
                        nom_form = -1;
                        break;
                    }
            }
            
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
            timer1.Enabled = true;
            for (int i = 0; i < 3; i++)
            {
                prov[i] = true;
            }
            Width = image.Width + 35;
            Height = image.Height + 80;
            pictureBox1.Size = image.Size;
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            //Position 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            q_saving = false;
            perem = false;
            obl = false;
            pictureBox1.Paint -= pictureBox1_Paint;
            if (pictureBox1.Image != null)
            {
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
            for(int i = 0; i < 3; i++)
            {
                if(!prov[i])
                {
                    MessageBox.Show("Закрийте всі вікна форматування.");
                    return;
                }
            }
            if(q_saving)
            {
                if (MessageBox.Show("Ви впевнені що хочете змінити зображення без збереження?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
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
                            Width = image.Width + 35;
                            Height = image.Height + 80;
                            pictureBox1.Size = image.Size;
                            pictureBox1.Image = image;
                            pictureBox1.Invalidate();
                            q_saving = false;
                        }
                        catch
                        {
                            full_name_of_image = "\0";
                            DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    return;
                }  
            }            
        }

        private void повернутисьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            q_saving = false;
            perem = false;
            obl = false;
            pictureBox1.Paint -= pictureBox1_Paint;
            if (pictureBox1.Image != null)
            {
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
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            timer1.Enabled = false;
        }

        private void picture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (q_saving)
            {
                if (MessageBox.Show("Ви впевнені що хочете змінити зображення без збереження?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }

            }
        }
    }
}
