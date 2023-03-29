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
        private PictureBox[] _enemiesMunitions;
        private int _enemySpeed; //Создаём приватное поле со скоростью врагов
        private int _backgroundSpeed; //Создаём приватное поле со скоростью звёзд 
        private int _playerSpeed; //Создаём приватное поле со скоростью  игрока
        private int _munitionSpeed; //Создаём приватное поле со скоростью боеприпаса
        private int _enemiesMunitionSpeed; //Создаём приватное поле со скоростью снарядов врага
        private int _score; //Создаём приватное поле со счётом
        private int _level; //Создаём приватное поле с уровнем
        private int _difficulty; //Создаём приватное поле с уровнем сложности
        private bool _isPause; //Создаём приватное поле с паузой
        private bool _isGameOver; //Создаём приватное поле с проигрышом

        public Form1()
        {
            InitializeComponent(); //Иницилизируем объекты из формы
        }

        private void Form1_Load(object sender, EventArgs e) //Выполняется при загрузке формы
        {
            _isPause = false; //Нет паузы
            _isGameOver = false; //Нет проигрыша
            _score = 0; //Счёт = 0
            _level = 1; //Первый уровень
            _difficulty = 9; //Девятый уровень сложности
            _backgroundSpeed = 4; //Иницилизируем скорость звёзд = 4
            _random = new Random(); //Иницилизируем Рандом
            _playerSpeed = 5; //Иницилизируем скорость игрока = 5
            _munitionSpeed = 20; //Иницилизируем скорость боеприпаса = 20
            _enemySpeed = 5; //Скорость врага = 5

            BackgroundImage = Image.FromFile("assets\\BackgroundImage.jpg"); //Фон = изображению космоса

            Image munition = Image.FromFile("assets\\munition.png"); //Изображение боеприса = изображению munition.png

            _stars = new PictureBox[20]; //Иницилизируем массив со звёздами = 20
            _munitions = new PictureBox[3]; //Три вида изображений боеприпасов
            _enemies = new PictureBox[10]; //Десять врагов
            _enemiesMunitions = new PictureBox[10]; //Десять снарядов врага

            _backgroundSound = new WindowsMediaPlayer(); //Иницилизируем звук игры
            _shootSound = new WindowsMediaPlayer(); //Иницилизируем звук выстрела 
            _explosionSound = new WindowsMediaPlayer(); //Иницилизируем звук разрыва снаряда

            _backgroundSound.URL = "songs\\GameSong.mp3"; //Музыка будет браться из файла
            _shootSound.URL = "songs\\shoot.mp3"; //Берём музыку из файла и присваиваем её звуку выстрела
            _explosionSound.URL = "songs\\boom.mp3"; //Указываем путь до файла, из которого будет браться музыка

            _backgroundSound.settings.setMode("loop", true); //Звук игры будет играть постоянно
            _backgroundSound.settings.volume = 7; //Звук игры = 7 сила громкости
            _shootSound.settings.volume = 1; //Звук выстрела = 1 сила громкости
            _explosionSound.settings.volume = 6; //Звук разрыва снаряда = 6 сила громкости

            Player.Location = new Point(240, 200);

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

            for (int i = 0; i < _enemiesMunitions.Length; i++) //Пока i меньше снарядов врага
            {
                int randomEnemy; //Переменная с рандомным врагом

                _enemiesMunitions[i] = new PictureBox(); //Снаряд врага = изображение
                _enemiesMunitions[i].Size = new Size(2, 25); //Размер снаряда врага 2X25
                _enemiesMunitions[i].Visible = false; //Снаряд невидим
                _enemiesMunitions[i].BackColor = Color.Yellow; //Цвет - жёлтый

                randomEnemy = _random.Next(0, _enemies.Length); //Рандомный враг равен сллучайному врагу
                _enemiesMunitions[i].Location = new Point(_enemies[randomEnemy].Location.X, _enemies[randomEnemy].Location.Y - 20); //Задаём расположение снаряду
                Controls.Add(_enemiesMunitions[i]); //Добавляем снаряд на экран
            }

            for (int i = 0; i < _munitions.Length; i++) //Пока i меньше боеприпасов
            {
                _munitions[i] = new PictureBox(); //Боеприпас - изображение
                _munitions[i].Size = new Size(6, 6); //Устанавливаем размер боеприпаса
                _munitions[i].Image = munition; //Устанавливаем изображение боеприпасу
                _munitions[i].SizeMode = PictureBoxSizeMode.Zoom; //Изображение боеприпаса будет подстраиваться под размер
                _munitions[i].BorderStyle = BorderStyle.None; //У границ не будет стиля
                _munitions[i].BackColor = Color.White; //Цвет фона пули - белый
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

        void SortStars(int minItem, PictureBox[] stars, int backgroundSpeed) //Сортировка звёзд
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
            if (_isPause == false) //Если пауза отключена
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
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) //Событие, происходящее при отпускании клавиши
        {
            bool cantStartFromPause = false; //Перезапуск с паузы возможен

            RightMoveTimer.Stop(); //Останавливаем таймер
            LeftMoveTimer.Stop(); //Останавливаем таймер
            DownMoveTimer.Stop(); //Останавливаем таймер
            UpMoveTimer.Stop(); //Останавливаем таймер

            while (e.KeyCode == Keys.Space) //Пока нажат пробел
            {
                if (_isGameOver == false) //Если игрок не проиграл
                {
                    if (_isPause == false) //Если нет паузы
                    {
                        StopTimers(); //Останавливаем таймеры
                        Label.Location = new Point(153, 150); //Указываем расположение
                        Label.Text = "Paused"; //Указываем текст
                        Label.Visible = true; //Делаем видимым надпись
                        ExitButton.Visible = true; //Кнопка выхода видима
                        RestartButton.Visible = true; //Кнопка перезапуска видима
                        _backgroundSound.controls.pause(); //Ставим музыку на паузу
                        _isPause = true; //Нельзя перезапуститься с паузы
                        cantStartFromPause = true; //Игра остановлена
                        return; //Возвращаем
                    }
                    else if (_isPause && cantStartFromPause == false) //Если на паузе и с паузы можно перезапуститься
                    {
                        StartTimers(); //Запускаем метод
                        Label.Visible = false; //Делаем текст невидимым
                        ExitButton.Visible = false; //Делаем кнопку выхода невидимой
                        RestartButton.Visible = false; //Делаем кнопку рестарта невидимой
                        _backgroundSound.controls.play(); //Запускаем музыку
                        _isPause = false; //Отключаем паузу
                    }
                }
            }
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

                    CollisionEnemy();
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
            CollisionEnemy(); //Запускаем метод
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
                    //BackgroundImage = Image.FromFile("assets\\BackgroundImage.jpg"); //Добавляем фон
                    _enemies[i].Location = new Point((i + 1) * 47, -100); //Меняем его положение
                }
            }
        }

        private void CollisionEnemy() //Коллизия врага
        {
            string inclinedScore; //Склонённый счёт

            for (int i = 0; i < _enemies.Length; i++) //Пока i меньше количества врагов
            {
                for (int j = 0; j < _munitions.Length; j++) //Пока j меньше количества снарядов
                {
                    if (_munitions[j].Bounds.IntersectsWith(_enemies[i].Bounds)) //Если снаряд соприкасается с врагом
                    {
                        _explosionSound.controls.play(); //Играет звук разрыва снаряда
                       ++_score; //Увеличиваем счёт
                        inclinedScore = InclineScore(_score); //Запускаем функцию склонения слова
                        ScoreCount.Text = _score.ToString() + " " + inclinedScore; //Выводим счёт на экран

                        if (_score % 30 == 0) //Если счёт поделить с остатком на 30 будет ноль
                        {
                            ++_level; //Новый уровень
                            LevelCount.Text = _level.ToString() + "-й уровень"; //Выводим номер уровня

                            if (_level < 10) //Если уовнея меньше 10
                            {
                                --_difficulty; //Усложняем
                                ++_enemySpeed; //Ускоряем врагов
                                ++_enemiesMunitionSpeed; //Ускоряем боеприпасы врага
                            }
                            else //Иначе
                            {

                                for (int x = 0; x < _enemies.Length; x++) //Пока x меньше длины массива с врагами
                                {
                                    _explosionSound.settings.volume = 30; //Звук взрыва = 30
                                    _explosionSound.controls.play(); //Звук взрыва запускается

                                    if (x < _munitions.Length) //Если x меньше количества снарядов
                                    {
                                        Controls.Remove(_munitions[x]); //Удаляем снаряд
                                    }

                                    Controls.Remove(_enemies[x]); //Удаляем врага
                                    Controls.Remove(_enemiesMunitions[x]); //Удаляем снаряд врага
                                }

                                GameOver("Nice Down!"); //Запускаем метод
                                BackgroundImage = Image.FromFile("assets\\BackgroundImage.jpg"); //Фон = изображению космоса

                            }
                        }
                        
                        _enemies[i].Location = new Point((i + 1) * 35, -100); //Задаём расположение врагу
                    }

                    if (Player.Bounds.IntersectsWith(_enemies[i].Bounds)) //Если игрок сопрекасается с врагом
                    {
                        _explosionSound.settings.volume = 30; //Звук взрыва = 30
                        _explosionSound.controls.play(); //Играет звук взрыва
                        Player.Visible = false; //Игрок становится невидимым
                        _enemies[i].Visible = false; //Враг становится невидимым
                        GameOver("Game Over!"); //Запускаем метод
                    }
                }
            }
        }

        private static string InclineScore(int score) //Функция склонения слова
        {
            string[] scoresForInclining = new string[] { "очков", "очко", "очка" }; //Варианты слова


            if (score % 100 == 11 || score % 100 == 12 || score % 100 == 13 || score % 100 == 14) //Если счёт поделить на сто с остатком будеи 11, 12, 13 или 14
            {
                return scoresForInclining[0]; //Возвращаем элемент с индексом ноль
            }
            
                switch (score % 10) //Если счёт поделить с остатком на десять
                {
                    case 0: //Будет 0
                    case 5: //Будет 5
                    case 6: //Будет 6
                    case 7: //Будет 7
                    case 8: //Будет 8
                    case 9: //Будет 9
                        return scoresForInclining[0]; //Возвращаем элемент с индексом ноль
                    case 1: //Будет 1
                        return scoresForInclining[1]; //Возвращаем элемент с индексом один
                    case 2: //Будет 2
                    case 3: //Будет 3
                    case 4: //Будет 4
                        return scoresForInclining[2]; //Возвращаем элемент с индексом 2
                }

            return null; //Иначе возвращаем null
        }

        private void CollisionWithEnemiesMunition() //Коллизия снаряда врага с игроком
        {
            for (int i = 0; i < _enemiesMunitions.Length; i++) //Пока i меньше снарядов врага
            {
                if (_enemiesMunitions[i].Bounds.IntersectsWith(Player.Bounds)) //Если снаряд врага соприкасается с игроком
                {
                    _enemiesMunitions[i].Visible = false; //Делаем снапяд невидимым
                    _explosionSound.settings.volume = 30; //Звук разрыва = 30
                    _explosionSound.controls.play(); //Проигрывается звук разрыва
                    Player.Visible = false; //Игрок становится невидимым
                    GameOver("Game Over!"); //Запускаем метод Проигрыша
                }
            }
        }

        private void GameOver(string word) //Метод Проигрыша принимает текст
        {
            Label.Text = word; //Надпись равняется тексту
            Label.Location = new Point(120, 150);
            Label.Visible = true; //Делаем надпись видимой
            RestartButton.Visible = true; //Кнопка перезапуска видима
            ExitButton.Visible = true; //Кнопка выхода видима
            _backgroundSound.controls.pause(); //Ставим музыку на паузу
            StopTimers(); //Останавливаем таймеры
        }

        private void StopTimers()
        {
            MoveBackgroundTimer.Stop(); //Останавливаем таймер
            MoveEnemiesTimer.Stop(); //Останавливаем таймер
            MoveMunitionsTimer.Stop(); //Останавливаем таймер
            EnemiesMunitionTimer.Stop(); //Останавливаем таймер
        }

        private void StartTimers()
        {
            MoveBackgroundTimer.Start(); //Запускаем таймер
            MoveEnemiesTimer.Start(); //Запускаем таймер
            MoveMunitionsTimer.Start(); //Запускаем таймер
            EnemiesMunitionTimer.Start(); //Запускаем таймер
        }

        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (_enemiesMunitions.Length - _difficulty); i++) //Пока i меньше разности снарядов врага и сложности
            {

                if (_enemiesMunitions[i].Top < Height) //Если снаряд врага в зоне видимости
                {
                   _enemiesMunitions[i].Visible = true; //Делаем его видимым
                   _enemiesMunitions[i].Top += _enemiesMunitionSpeed; //Отдаляем снаряд от верха экрана
                   CollisionWithEnemiesMunition(); //Запускаем метод
                }
                else //Иначе
                {
                    _enemiesMunitions[i].Visible = false; //Делаем снаряд невидимым
                    int randomEnemy = _random.Next(0, _enemies.Length); //Рандомный враг равен случайному врагу
                    _enemiesMunitions[i].Location = new Point(_enemies[randomEnemy].Location.X + 20, _enemies[randomEnemy].Location.Y + 20); //Задаём расположение снаряду
                    Controls.Add(_enemiesMunitions[i]); //Добавляем снаряд на экран
                }
            }
        }

        private void RestartButton_Click(object sender, EventArgs e) //Если нажата кнопка перезапуска
        {
            Controls.Clear(); //Отчищаем экран от добавленных объектов
            InitializeComponent(); //Иницилизируем объекты
            Form1_Load(sender, e); //Запускаем метод
        }
        private void ExitButton_Click(object sender, EventArgs e) //Если нажата кнопка выхода
        {
            Environment.Exit(0); //Выходим
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
