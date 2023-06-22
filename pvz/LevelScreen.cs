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
    public partial class LevelScreen : UserControl
    {
        public static string progress = "0";
        public static int highscore = 0;

        public LevelScreen()
        {
            InitializeComponent();

            Form1.CheckProgress();

            LoadButtons();
        }

        public void LoadButtons()
        {
            level1.Enabled = true;
            level2.Enabled = true;
            level3.Enabled = true;
            level4.Enabled = true;
            level5.Enabled = true;
            level6.Enabled = true;

            level1.BackColor = Color.MediumAquamarine;
            level2.BackColor = Color.MediumAquamarine;
            level3.BackColor = Color.MediumAquamarine;
            level4.BackColor = Color.MediumAquamarine;
            level5.BackColor = Color.MediumAquamarine;
            level6.ForeColor = Color.White;
            level6.BackColor = Color.Black;

            if (progress == "0")
            {
                level2.BackColor = Color.Gray;
                level3.BackColor = Color.Gray;
                level4.BackColor = Color.Gray;
                level5.BackColor = Color.Gray;
                level6.ForeColor = Color.Black;
                level6.BackColor = Color.DimGray;
                level2.Enabled = false;
                level3.Enabled = false;
                level4.Enabled = false;
                level5.Enabled = false;
                level6.Enabled = false;
            }
            else if (progress == "1")
            {
                level3.BackColor = Color.Gray;
                level4.BackColor = Color.Gray;
                level5.BackColor = Color.Gray;
                level6.ForeColor = Color.Black;
                level6.BackColor = Color.DimGray;
                level3.Enabled = false;
                level4.Enabled = false;
                level5.Enabled = false;
                level6.Enabled = false;
            }
            else if (progress == "2")
            {
                level4.BackColor = Color.Gray;
                level5.BackColor = Color.Gray;
                level6.ForeColor = Color.Black;
                level6.BackColor = Color.DimGray;
                level4.Enabled = false;
                level5.Enabled = false;
                level6.Enabled = false;
            }
            else if (progress == "3")
            {
                level5.BackColor = Color.Gray;
                level6.ForeColor = Color.Black;
                level6.BackColor = Color.DimGray;
                level5.Enabled = false;
                level6.Enabled = false;
            }
            else if (progress == "4")
            {
                level6.ForeColor = Color.Black;
                level6.BackColor = Color.DimGray;
                level6.Enabled = false;
            }
        }

        private void level1_Click(object sender, EventArgs e)
        {
            GameScreen.level = 1;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level2_Click(object sender, EventArgs e)
        {
            GameScreen.level = 2;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level3_Click(object sender, EventArgs e)
        {
            GameScreen.level = 3;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level4_Click(object sender, EventArgs e)
        {
            GameScreen.level = 4;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level5_Click(object sender, EventArgs e)
        {
            GameScreen.level = 5;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void level6_Click(object sender, EventArgs e)
        {
            GameScreen.level = 6;
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progress = "0";

            GameOverScreen.SaveProgress();
            LoadButtons();
        }
    }
}
