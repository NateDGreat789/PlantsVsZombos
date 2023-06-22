using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace pvz
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();

            if (GameScreen.win == false)
            {
                gameOverLabel.Text = $"THE ZOMBOS ATE YOUR BRAINS!!";

                if (GameScreen.level == 0)
                {
                    if (GameScreen.score > LevelScreen.highscore)
                    {
                        LevelScreen.highscore = GameScreen.score;
                        resultsLabel.Text = $"Your score: {GameScreen.score}\nNew highscore!";
                    }
                    else
                    {
                        resultsLabel.Text = $"Your score: {GameScreen.score}\nHighscore: {LevelScreen.highscore}";
                    }
                    

                }
                else
                {
                    resultsLabel.Text = "Try again?";
                }
            }

            if (GameScreen.win == true)
            {
                restartButton.Text = "NEXT LEVEL";
                if (GameScreen.level == 1)
                {
                    gameOverLabel.Text = $"LEVEL CLEARED";
                    resultsLabel.Text = $"You've unlocked the SUNNY plant!\nIt'll spawn sun for you to plant more plants.";
                }
                else if (GameScreen.level == 2)
                {
                    gameOverLabel.Text = $"LEVEL CLEARED";
                    resultsLabel.Text = $"On to the next one!";
                }
                else if (GameScreen.level == 3)
                {
                    gameOverLabel.Text = $"LEVEL CLEARED";
                    resultsLabel.Text = $"You've unlocked the CHERRY BOOM plant!\nIt'll go boom and roast any zomboes it touches.";
                }
                else if (GameScreen.level == 4)
                {
                    gameOverLabel.Text = $"LEVEL CLEARED";
                    resultsLabel.Text = $"On to the next one!";
                }
                else if (GameScreen.level == 5)
                {
                    gameOverLabel.Text = $"LEVEL CLEARED";
                    resultsLabel.Text = $"You've unlocked the SNOW PEATEY plant!\nIt'll shoot peas that can freeze the zombos to a crawl.";
                }
                else if (GameScreen.level == 6)
                {
                    gameOverLabel.Text = $"LEVEL CLEARED";
                    resultsLabel.Text = $"YOU HAVE VANQUISHED THE ZOMBOS! Congratulations, your brains are saved!";
                }
            }
            SaveProgress();
        }

        public static void SaveProgress()
        {
            XmlWriter writer = XmlWriter.Create("Resources/progression.xml", null);

            writer.WriteStartElement("Game");

            writer.WriteElementString("levelscleared", Convert.ToString(GameScreen.level));
            writer.WriteElementString("highscore", Convert.ToString(LevelScreen.highscore));

            writer.WriteEndElement();

            writer.Close();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (GameScreen.win == true)
            {
                Form1.ChangeScreen(this, new LevelScreen());
            }
            else
            {
                Form1.ChangeScreen(this, new GameScreen());
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
