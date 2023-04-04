using System;
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
    public partial class GameOverScreen : UserControl
    {
        double fastestTime = 0;

        public GameOverScreen()
        {
            InitializeComponent();

            if (GameScreen.time > fastestTime)
            {
                fastestTime = GameScreen.time;
            }

            if (GameScreen.win == false)
            {
                gameOverLabel.Text = $"THE ZOMBOS ATE YOUR BRAINS!!";
                resultsLabel.Text = $"Your score: {GameScreen.score}";
            }

            if (GameScreen.win == true)
            {
                gameOverLabel.Text = $"You vanquished the zombos!!\n(20 to be exact)";
                resultsLabel.Text = $"Congratulations!";
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
    }
}
