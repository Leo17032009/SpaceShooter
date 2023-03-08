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
        private Random _random;
        private PictureBox[] _stars;
        private int _backgroundSpeed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _backgroundSpeed = 4;
            _stars = new PictureBox[20];
            _random = new Random();

            AddStars(_stars, _random);
        }

        private void MoveBackgroundTimer_Tick(object sender, EventArgs e)
        {
            SortStars(0, _stars, _backgroundSpeed);
            SortStars(_stars.Length / 2, _stars, _backgroundSpeed);
        }

        void AddStars(PictureBox[] stars, Random random)
        {
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

        void SortStars (int minItem, PictureBox[] stars, int backgroundSpeed)
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
