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
        private Random _random; //Создаём приватное поле Рандом
        private PictureBox[] _stars; //Создаём приватное поле со звёздами
        private PictureBox[] _munitions; //Создаём приватное поле с изображениями боеприпасов
        private int _backgroundSpeed; //Создаём приватное поле со скоростью звёзд 
        private int _playerSpeed; //Создаём приватное поле со скоростью  игрока
        private int _munitionSpeed; //Создаём приватное поле со скоростью боеприпаса

        public Form1()
        {
            InitializeComponent(); //Иницилизируем объекты из формы
        }

        private void Form1_Load(object sender, EventArgs e) //Выполняется при загрузке формы
        {
            _backgroundSpeed = 4; //Иницилизируем скорость звёзд = 4
            _stars = new PictureBox[20]; //Иницилизируем массив со звёздами = 20
            _random = new Random(); //Иницилизируем Рандом
            _playerSpeed = 5; //Иницилизируем скорость игрока = 5
            _munitionSpeed = 20; //Иницилизируем скорость боеприпаса = 20

            Image munition = Image.FromFile("assets\\munition.png"); //Изображение боеприса = изображению munition.png

            _munitions = new PictureBox[3]; //Три вида изображений боеприпасов

            AddStars(_stars, _random); //Запускаем функцию с принимаемыми значениями звёзды и Рандом

            for (int i = 0; i < _munitions.Length; i++) //Пока i меньше боеприпасов
            {
                _munitions[i] = new PictureBox(); //Боеприпас - изображение
                _munitions[i].Size = new Size(6, 6); //Устанавливаем размер боеприпаса
                _munitions[i].Image = munition; //Устанавливаем изображение боеприпасу
                _munitions[i].SizeMode = PictureBoxSizeMode.Zoom; //Изображение боеприпаса будет подстраиваться под размер
                _munitions[i].BorderStyle = BorderStyle.None; //У границ не будет стиля
                Controls.Add(_munitions[i]); //Добавляем боеприпас на экран
            }
        }

        private void MoveBackgroundTimer_Tick(object sender, EventArgs e) //Таймер для управления звёздами
        {
            SortStars(0, _stars, _backgroundSpeed); //Сортируем звёзды
            SortStars(_stars.Length / 2, _stars, _backgroundSpeed); //Сортируем звёзды
        }

        void AddStars(PictureBox[] stars, Random random) //Добавляем звёзды
        {
            for (int i = 0; i < stars.Length; i++) //Пока i меньше длины массивы звёзд
            {
                stars[i] = new PictureBox(); //Звезда - изображение
                stars[i].BorderStyle = BorderStyle.FixedSingle; //У звезды одинарная граница
                stars[i].Location = new Point(random.Next(20, 540), random.Next(10, 400)); //Рандомно присваеваем местоположение звезде

                if (i % 2 == 1) //Если индекс звёзды нечётный
                {
                    stars[i].Size = new Size(2, 2); //Задаём размер 2X2
                    stars[i].BackColor = Color.Wheat; //Делаем цвет светло-жёлтым
                }
                else //Иначе
                {
                    stars[i].Size = new Size(4, 4); //Размер звезды 4X4
                    stars[i].BackColor = Color.DarkGray; //Цвет - тёмно-серый
                }

                Controls.Add(stars[i]); //Добавляем звезду на экран
            }
        }

        void SortStars (int minItem, PictureBox[] stars, int backgroundSpeed) //Сортировка звёзд
        {
            for (int i = minItem;  i < stars.Length; i++) //Пока меньше длины массива со звёздами
            {
                stars[i].Top += backgroundSpeed; //Звёзда отдаляется от верхней части экрана

                if (stars[i].Top >= Height) //Если дальность звезды от верхней точки экрана больше или равно длине экрана
                {
                    stars[i].Top = -stars[i].Height; //Звезда поднимается над экраном
                }
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e) //Таймер, срабатывающий при вызове
        {
            if (Player.Top > 10) //Если растояние от верхней части экрана до самолёта больше 10
            {
                Player.Top -= _playerSpeed; //Приближаем игрока на _playerSpeed
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e) //Таймер, срабатывающий при вызове
        {
            if (Player.Top < 450) //Если растояние от верхней точки экрана меньше 450
            {
                Player.Top += _playerSpeed; //Отдаляем игрока на _playerSpeed
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e) //Таймер, срабатывающий при вызове
        {
            if (Player.Left > 10) //Если растояние от левой точки экрана до игрока больше 10
            {
                Player.Left -= _playerSpeed; //Приближаем игрока на _playerSpeed
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e) //Таймер, срабатывающий при вызове
        {
            if (Player.Right < 500) //Если растояние от правой точки экрана до игрока меньше 500
            {
                Player.Left += _playerSpeed; //Отдаляем игрока от левой точки на _playerSpeed
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //Событие, происходящее при нажатии на кнопку
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D) //Если нажата стрелка вправо или D
            {
                RightMoveTimer.Start(); //Запускаем таймер
            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A) //Если нажата стрелка влево или A
            {
                LeftMoveTimer.Start(); //Запускаем таймер
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S) //Если нажата стрелка вниз или S
            {
                DownMoveTimer.Start(); //Запускаем таймер
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W) //Если нажата стрелка вверх или W
            {
                UpMoveTimer.Start(); //Запускаем таймер
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) //Событие, происходящее при отпускании клавиши
        {
            RightMoveTimer.Stop(); //Останавливаем таймер
            LeftMoveTimer.Stop(); //Останавливаем таймер
            DownMoveTimer.Stop(); //Останавливаем таймер
            UpMoveTimer.Stop(); //Останавливаем таймер
        }
    }
}
