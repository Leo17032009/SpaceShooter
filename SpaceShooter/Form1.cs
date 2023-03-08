using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        private Random random;
        private PictureBox[] stars;
        private int backgroundSpeed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundSpeed = 4;
            stars = new PictureBox[20];
            random = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.FixedSingle;
                stars[i].Location = new Point(random.Next(20, 540), random.Next(10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(4, 4);
                    stars[i].BackColor = Color.DarkGray;
                }

                Controls.Add(stars[i]);
            }
        }

        private void MoveBackgroundTimer_Tick(object sender, EventArgs e)
        {
            SortStars(0);
            SortStars(stars.Length / 2);
        }

        void SortStars (int minItem)
        {
            for (int i = 0;  minItem < stars.Length; minItem++)
            {
                stars[minItem].Top += backgroundSpeed;

                if (stars[minItem].Top >= Height)
                {
                    stars[minItem].Top = -stars[minItem].Height;
                }
            }
        }
    }
}
