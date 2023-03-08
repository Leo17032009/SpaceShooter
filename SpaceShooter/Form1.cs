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
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(random.Next(20, 400), random.Next(10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                Controls.Add(stars[i]);
            }
        }

        private void MoveBackgroundTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Top += backgroundSpeed;

                if (stars[i].Top >= Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundSpeed - 2;

                if (stars[i].Top >= Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }
    }
}
