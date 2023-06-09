﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pvz
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();

            Form1.CheckProgress();
            highscoreLabel.Text = $"Endless mode highscore: {Convert.ToString(LevelScreen.highscore)}";
        }

        private void endlessButton_Click(object sender, EventArgs e)
        {
            GameScreen.level = 0;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void storyButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new LevelScreen());
        }
    }
}
