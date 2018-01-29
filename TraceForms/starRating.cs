using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
namespace TraceForms
{
    
    public partial class starRating : DevExpress.XtraEditors.XtraUserControl
    {
        public int stars { get; set; }
        public double rating { get; set; }
        public starRating()
        {
            InitializeComponent();
        }

        private void XtraUserControl1_Load(object sender, EventArgs e)
        {
            if (stars != 0)
                makeStars();
        }

        private void light(double target)
        {
            target = target * 2;
            int i;
            for (i = 0; i < stars * 2; i++)
            {
                if (i % 2 == 0)
                {
                    if (target > i)
                        starArry[i].Image = Properties.Resources.Llit;
                    else
                        starArry[i].Image = Properties.Resources.Lblank;
                }
                else
                {
                    if (target > i)
                        starArry[i].Image = Properties.Resources.Rlit;
                    else
                        starArry[i].Image = Properties.Resources.Rblank;
                }
            }
        }

        private void star_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            string name = "";
            int i;
            for (i = 0; name != pic.Name; i++)
                name = "star" + i;
            if (i == rating * 2)
            {
                rating = rating - 0.5;
                light(rating);
            }
            else
            {
                rating = i / 2.0;
                light(rating);
            }
        }


        private void star_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            string name = "";
            int i;
            for (i = 0; name != pic.Name; i++)
                name = "star" + i;
            light(i / 2.0);
        }

        private void star_MouseLeave(object sender, EventArgs e)
        {
            light(rating);
        }

        //Allows user to set rating
        public void changeRating(double rate)
        {
            rating = rate;
            light(rating);
        }

        PictureBox[] starArry;
        //Allows user to set number of stars if the stars property was set to zero
        public void createStars(int newstars)
        {
            //if (stars == 0)
            //{
                stars = newstars;
                makeStars();
            //}
        }
        private void makeStars()
        {
            starArry = new PictureBox[stars * 2];
            for (int i = 0; i < stars * 2; i++)
            {
                starArry[i] = new PictureBox();
                if (i % 2 == 0)
                    starArry[i].Image = Properties.Resources.Lblank;
                else
                    starArry[i].Image = Properties.Resources.Rblank;
                starArry[i].Location = new System.Drawing.Point(13 * i, 1);
                starArry[i].Margin = new System.Windows.Forms.Padding(0);
                starArry[i].Name = "star" + i;
                starArry[i].Size = new System.Drawing.Size(13, 25);
                starArry[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                starArry[i].Click += new System.EventHandler(this.star_Click);
                starArry[i].MouseEnter += new System.EventHandler(this.star_MouseEnter);
                starArry[i].MouseLeave += new System.EventHandler(this.star_MouseLeave);
                this.Controls.Add(starArry[i]);
            }
            light(rating);
        }
    }
}