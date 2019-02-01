namespace Program_pictures
{
    partial class change
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.фільтриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.яскравістьКонтрастToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.балансКольоруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розмитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.збільшитиРізкістьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.підтвердитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фільтриToolStripMenuItem,
            this.підтвердитиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(211, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // фільтриToolStripMenuItem
            // 
            this.фільтриToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.яскравістьКонтрастToolStripMenuItem,
            this.балансКольоруToolStripMenuItem,
            this.розмитиToolStripMenuItem,
            this.збільшитиРізкістьToolStripMenuItem});
            this.фільтриToolStripMenuItem.Name = "фільтриToolStripMenuItem";
            this.фільтриToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.фільтриToolStripMenuItem.Text = "Фільтри";
            // 
            // яскравістьКонтрастToolStripMenuItem
            // 
            this.яскравістьКонтрастToolStripMenuItem.Name = "яскравістьКонтрастToolStripMenuItem";
            this.яскравістьКонтрастToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.яскравістьКонтрастToolStripMenuItem.Text = "Яскравість/Контраст";
            this.яскравістьКонтрастToolStripMenuItem.Click += new System.EventHandler(this.яскравістьКонтрастToolStripMenuItem_Click);
            // 
            // балансКольоруToolStripMenuItem
            // 
            this.балансКольоруToolStripMenuItem.Name = "балансКольоруToolStripMenuItem";
            this.балансКольоруToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.балансКольоруToolStripMenuItem.Text = "Баланс кольору";
            this.балансКольоруToolStripMenuItem.Click += new System.EventHandler(this.балансКольоруToolStripMenuItem_Click);
            // 
            // розмитиToolStripMenuItem
            // 
            this.розмитиToolStripMenuItem.Name = "розмитиToolStripMenuItem";
            this.розмитиToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.розмитиToolStripMenuItem.Text = "Розмити";
            this.розмитиToolStripMenuItem.Click += new System.EventHandler(this.розмитиToolStripMenuItem_Click);
            // 
            // збільшитиРізкістьToolStripMenuItem
            // 
            this.збільшитиРізкістьToolStripMenuItem.Name = "збільшитиРізкістьToolStripMenuItem";
            this.збільшитиРізкістьToolStripMenuItem.Size = new System.Drawing.Size(241, 24);
            this.збільшитиРізкістьToolStripMenuItem.Text = "Збільшити різкість";
            this.збільшитиРізкістьToolStripMenuItem.Click += new System.EventHandler(this.збільшитиРізкістьToolStripMenuItem_Click);
            // 
            // підтвердитиToolStripMenuItem
            // 
            this.підтвердитиToolStripMenuItem.Name = "підтвердитиToolStripMenuItem";
            this.підтвердитиToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.підтвердитиToolStripMenuItem.Text = "Підтвердити";
            this.підтвердитиToolStripMenuItem.Click += new System.EventHandler(this.підтвердитиToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 202);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Program_pictures.Properties.Resources.фон;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(211, 247);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(227, 0);
            this.Name = "change";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Корегування";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.change_FormClosing);
            this.Load += new System.EventHandler(this.change_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem фільтриToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem яскравістьКонтрастToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem балансКольоруToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розмитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem збільшитиРізкістьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem підтвердитиToolStripMenuItem;
    }
}