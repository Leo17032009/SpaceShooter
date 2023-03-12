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
        private PictureBox[] _munitions;
        private int _backgroundSpeed;
        private int _playerSpeed;
        private int _munitionSpeed;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _backgroundSpeed = 4;
            _stars = new PictureBox[20];
            _random = new Random();
            _playerSpeed = 5;
            _munitionSpeed = 20;

            Image munition = Image.FromFile("assets\\munition.png");

            _munitions = new PictureBox[3];

            AddStars(_stars, _random);

            for (int i = 0; i < _munitions.Length; i++)
            {
                _munitions[i] = new PictureBox();
                _munitions[i].Size = new Size(6, 6);
                _munitions[i].Image = munition;
                _munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                _munitions[i].BorderStyle = BorderStyle.None;
                Controls.Add(_munitions[i]);
            }
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

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= _playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 450)
            {
                Player.Top += _playerSpeed;
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= _playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 500)
            {
                Player.Left += _playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                RightMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Left)
            {
                LeftMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Down)
            {
                DownMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Up)
            {
                UpMoveTimer.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
        }
    }
}
