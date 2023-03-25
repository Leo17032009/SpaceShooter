using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer _backgroundSound; //Создаём приватное поле со звуком игры
        private WindowsMediaPlayer _shootSound; //Создаём приватное поле со звуком выстрела
        private WindowsMediaPlayer _explosionSound; //Создаём приватное поле со звуком разрыва снаряда
        private Random _random; //Создаём приватное поле Рандом
        private PictureBox[] _stars; //Создаём приватное поле со звёздами
        private PictureBox[] _munitions; //Создаём приватное поле с изображениями боеприпасов
        private PictureBox[] _enemies; //Создаём приватное поле с врагами
        private int _enemySpeed; //Создаём приватное поле со скоростью врагов
        private int _backgroundSpeed; //Создаём приватное поле со скоростью звёзд 
        private int _playerSpeed; //Создаём приватное поле со скоростью  игрока
        private int _munitionSpeed; //Создаём приватное поле со скоростью боеприпаса
        private int _enemiesMunitionSpeed; //Создаём приватное поле со скоростью снарядов врага

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
            _enemySpeed = 5;

            BackgroundImage = Image.FromFile("assets\\BackgroundImage.jpg"); //Фон = изображению космоса

            Image munition = Image.FromFile("assets\\munition.png"); //Изображение боеприса = изображению munition.png

            _munitions = new PictureBox[3]; //Три вида изображений боеприпасов
            _enemies = new PictureBox[10]; //Десять врагов

            _backgroundSound = new WindowsMediaPlayer(); //Иницилизируем звук игры
            _shootSound = new WindowsMediaPlayer(); //Иницилизируем звук выстрела 
            _explosionSound = new WindowsMediaPlayer(); //Иницилизируем звук разрыва снаряда

            _backgroundSound.URL = "songs\\GameSong.mp3"; //Музыка будет браться из файла
            _shootSound.URL = "songs\\shoot.mp3"; //Берём музыку из файла и присваиваем её звуку выстрела
            _explosionSound.URL = "songs\\boom.mp3"; //Указываем путь до файла, из которого будет браться музыка

            _backgroundSound.settings.setMode("loop", true); //Звук игры будет играть постоянно
            _backgroundSound.settings.volume = 7; //Звук игры = 5 сила громкости
            _shootSound.settings.volume = 1; //Звук выстрела = 1 сила громкости
            _explosionSound.settings.volume = 6; //Звук разрыва снаряда = 6 сила громкости

            for (int i = 0; i < _enemies.Length; i++) //Пока i меньше количество противников
            {
                _enemies[i] = new PictureBox(); //Враг = изображение
                _enemies[i].BackColor = Color.Transparent; //Цвет врага = цвет фона
                _enemies[i].Size = new Size(25, 25); //Размер врага = 25X25
                _enemies[i].SizeMode = PictureBoxSizeMode.Zoom; //Изображение подстраивается под размер
                _enemies[i].Visible = false; //Враг невидим
                Controls.Add(_enemies[i]); //Добавляем врага
                _enemies[i].Location = new Point((i + 1) * 47, -150); //Задаём расположение игроку
            }

            ImageEnemy enemy1 = new ImageEnemy("Enemy4.png", _enemies[0]); //У первого врага будет изображение 4
            ImageEnemy enemy2 = new ImageEnemy("Enemy1.png", _enemies[1]); //У второго врага будет изображение 1
            ImageEnemy enemy3 = new ImageEnemy("Enemy2.png", _enemies[2]); //У третьего врага будет изображение 2
            ImageEnemy enemy4 = new ImageEnemy("Enemy3.png", _enemies[3]); //У четвёртого врага будет изображение 3
            ImageEnemy enemy5 = new ImageEnemy("Enemy1.png", _enemies[4]); //У пятого врага будет изображение 1
            ImageEnemy enemy6 = new ImageEnemy("Enemy3.png", _enemies[5]); //У шестого врага будет изображение 3
            ImageEnemy enemy7 = new ImageEnemy("Enemy2.png", _enemies[6]); //У седьмого врага будет изображение 2
            ImageEnemy enemy8 = new ImageEnemy("Enemy3.png", _enemies[7]); //У восьмого врага будет изображение 3
            ImageEnemy enemy9 = new ImageEnemy("Enemy1.png", _enemies[8]); //У девятого врага будет изображение 1
            ImageEnemy enemy10 = new ImageEnemy("Enemy5.png", _enemies[9]); //У десятого врага будет изображение 5

            AddStars(_stars, _random); //Запускаем функцию с принимаемыми значениями звёзды и Рандом

            for (int i = 0; i < _munitions.Length; i++) //Пока i меньше боеприпасов
            {
                _munitions[i] = new PictureBox(); //Боеприпас - изображение
                _munitions[i].Size = new Size(6, 6); //Устанавливаем размер боеприпаса
                _munitions[i].Image = munition; //Устанавливаем изображение боеприпасу
                _munitions[i].SizeMode = PictureBoxSizeMode.Zoom; //Изображение боеприпаса будет подстраиваться под размер
                _munitions[i].BorderStyle = BorderStyle.None; //У границ не будет стиля
                _munitions[i].BackColor = Color.White; //Цфет фона пули - бк=елый
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

        private void MoveMunitionsTimer_Tick(object sender, EventArgs e) //Таймер для снарядов
        {
            _shootSound.controls.play(); //Воспроизводим звук выстрела

            for (int i = 0; i < _munitions.Length; i++) //Пока i меньше количества снарядов
            {
                if (_munitions[i].Top > 0) //Если снаряд находится в зоне видимости
                {
                    _munitions[i].Visible = true; //Делаем его видимым
                    _munitions[i].Top -= _munitionSpeed; //Приближаем к верху экрана
                }
                else //Иначе
                {
                    _munitions[i].Visible = false; //Снаряд невидимый
                    _munitions[i].Location = new Point(Player.Location.X + 10, Player.Location.Y - 1); //Меняем расположение игрока
                }
            }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e) //Таймер показа врагов
        {
            MoveEnemies(); //Запускаем метод
        }

        private void MoveEnemies() //Метод показа врагов
        {
            for (int i = 0; i < _enemies.Length; i++) //Пока i меньше количества врагов
            {
                if (_enemies[i].Location.Y >= 0) //Если враг в зоне видимости
                {
                    BackgroundImage = null; //У фона нет изображения
                }

                _enemies[i].Visible = true; //Делаем врага видимым
                _enemies[i].Top += _enemySpeed; //Отдаляем врага от верха экрана

                if (_enemies[i].Top > Height) //Если враг находится дальше длины экрана
                {
                    BackgroundImage = Image.FromFile("assets\\BackgroundImage.jpg"); //Добавляем фон
                    _enemies[i].Location = new Point((i + 1) * 47, -100); //Меняем его положение
                }
            }
        }
    }

    class ImageEnemy //Создаём класс с изображением игрока
    {
        public ImageEnemy(string imageName, PictureBox enemy) //Создаём метод, принимающий врага и его изображение
        {
            enemy.Image = Image.FromFile("assets\\" + imageName); //Изображение игрока = путь до файла
        }
    }
}
