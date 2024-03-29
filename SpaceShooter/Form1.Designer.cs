﻿namespace SpaceShooter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBackgroundTimer = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveMunitionsTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemiesMunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.Label = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ScoreCount = new System.Windows.Forms.Label();
            this.LevelCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBackgroundTimer
            // 
            this.MoveBackgroundTimer.Enabled = true;
            this.MoveBackgroundTimer.Interval = 30;
            this.MoveBackgroundTimer.Tick += new System.EventHandler(this.MoveBackgroundTimer_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::SpaceShooter.Properties.Resources.player;
            this.Player.Location = new System.Drawing.Point(344, 149);
            this.Player.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(38, 38);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Interval = 5;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Interval = 5;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Interval = 5;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Interval = 5;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // MoveMunitionsTimer
            // 
            this.MoveMunitionsTimer.Enabled = true;
            this.MoveMunitionsTimer.Interval = 20;
            this.MoveMunitionsTimer.Tick += new System.EventHandler(this.MoveMunitionsTimer_Tick);
            // 
            // MoveEnemiesTimer
            // 
            this.MoveEnemiesTimer.Enabled = true;
            this.MoveEnemiesTimer.Tick += new System.EventHandler(this.MoveEnemiesTimer_Tick);
            // 
            // EnemiesMunitionTimer
            // 
            this.EnemiesMunitionTimer.Enabled = true;
            this.EnemiesMunitionTimer.Interval = 20;
            this.EnemiesMunitionTimer.Tick += new System.EventHandler(this.EnemiesMunitionTimer_Tick);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.Label.ForeColor = System.Drawing.Color.White;
            this.Label.Location = new System.Drawing.Point(230, 207);
            this.Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(229, 82);
            this.Label.TabIndex = 1;
            this.Label.Text = "label1";
            this.Label.Visible = false;
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.RestartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RestartButton.Location = new System.Drawing.Point(226, 332);
            this.RestartButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(290, 94);
            this.RestartButton.TabIndex = 2;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.Visible = false;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.ExitButton.Location = new System.Drawing.Point(226, 466);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(290, 94);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ScoreCount
            // 
            this.ScoreCount.AutoSize = true;
            this.ScoreCount.BackColor = System.Drawing.Color.Transparent;
            this.ScoreCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ScoreCount.ForeColor = System.Drawing.Color.White;
            this.ScoreCount.Location = new System.Drawing.Point(12, 0);
            this.ScoreCount.Name = "ScoreCount";
            this.ScoreCount.Size = new System.Drawing.Size(122, 36);
            this.ScoreCount.TabIndex = 4;
            this.ScoreCount.Text = "0 очков";
            // 
            // LevelCount
            // 
            this.LevelCount.AutoSize = true;
            this.LevelCount.BackColor = System.Drawing.Color.Transparent;
            this.LevelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LevelCount.ForeColor = System.Drawing.Color.White;
            this.LevelCount.Location = new System.Drawing.Point(590, 0);
            this.LevelCount.Name = "LevelCount";
            this.LevelCount.Size = new System.Drawing.Size(185, 36);
            this.LevelCount.TabIndex = 5;
            this.LevelCount.Text = "1-й уровень";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(768, 702);
            this.Controls.Add(this.LevelCount);
            this.Controls.Add(this.ScoreCount);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.Player);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(790, 758);
            this.MinimumSize = new System.Drawing.Size(790, 758);
            this.Name = "Form1";
            this.Text = "Space Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label ScoreCount;
        private System.Windows.Forms.Label LevelCount;
        public System.Windows.Forms.Timer MoveBackgroundTimer;
        public System.Windows.Forms.Timer UpMoveTimer;
        public System.Windows.Forms.Timer DownMoveTimer;
        public System.Windows.Forms.Timer LeftMoveTimer;
        public System.Windows.Forms.Timer RightMoveTimer;
        public System.Windows.Forms.Timer MoveMunitionsTimer;
        public System.Windows.Forms.Timer MoveEnemiesTimer;
        public System.Windows.Forms.Timer EnemiesMunitionTimer;
    }
}

