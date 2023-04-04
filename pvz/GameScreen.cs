using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace pvz
{
    public partial class GameScreen : UserControl
    {
        SoundPlayer plantSound = new SoundPlayer(Properties.Resources.plant);
        SoundPlayer deadagainSound = new SoundPlayer(Properties.Resources.deadagain);
        SoundPlayer peaSound = new SoundPlayer(Properties.Resources.pea);
        SoundPlayer sunSound = new SoundPlayer(Properties.Resources.sun);

        List<Peatey> peateys = new List<Peatey>();
        List<Pea> peas = new List<Pea>();
        List<Sunny> sunnys = new List<Sunny>();
        List<Zombo> zombos = new List<Zombo>();

        SolidBrush greenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush peaBrush = new SolidBrush(Color.ForestGreen);
        SolidBrush sunBrush = new SolidBrush(Color.Gold);
        SolidBrush flashBrush = new SolidBrush(Color.Yellow);
        SolidBrush zomBrush = new SolidBrush(Color.SeaGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        int zomboLane, zomboHeight;
        int zomboCounter;
        int zomboTimer;
        public static int sun;
        int sunCounter;
        int peateyCounter;
        int sunnyCounter;
        public static double time;
        public static int score;
        string plant;

        bool peateyEnabled = true;
        bool sunnyEnabled = true;
        public static bool win;

        Random rnd = new Random ();

        public static Rectangle house = new Rectangle(159, 123, 80, 561);

        public GameScreen()
        {
            InitializeComponent();

            zomboCounter = 0;
            zomboTimer = 250;
            sun = 50;
            sunCounter = 0;
            peateyCounter = 0;
            sunnyCounter = 0;
            time = 0;
            score = 0;
            peateyEnabled = true;
            sunnyEnabled = true;

            peateys.Clear();
            peas.Clear();
            sunnys.Clear();
            zombos.Clear();

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
        }

        public void PlacePeatey(int x, int y)
        {
            Peatey newPeatey = new Peatey(x + 15, y + 10);
            peateys.Add(newPeatey);
            sun -= 100;
            peateyCounter++;
            plantSound.Play();
            peateyEnabled = false;
        }

        public void PlaceSunny(int x, int y)
        {
            Sunny newSunny = new Sunny(x + 5, y + 35);
            sunnys.Add(newSunny);
            sun -= 50;
            sunnyCounter++;
            plantSound.Play();
            sunnyEnabled = false;
        }

        public void SpawnZombo()
        {
            zomboLane = rnd.Next(0, 5);
            if (zomboLane == 0)
            {
                zomboHeight = 123;
            }
            else if (zomboLane == 1)
            {
                zomboHeight = 239;
            }
            else if (zomboLane == 2)
            {
                zomboHeight = 355;
            }
            else if (zomboLane == 3)
            {
                zomboHeight = 471;
            }
            else if (zomboLane == 4)
            {
                zomboHeight = 587;
            }
            Zombo newZombo = new Zombo(1300, zomboHeight);
            zombos.Add(newZombo);
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)          
        {
            for (int i = 0; i < peateys.Count; i++)
            {
                e.Graphics.FillRectangle(greenBrush, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
            }

            for (int i = 0; i < peas.Count; i++)
            {
                e.Graphics.FillRectangle(peaBrush, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
            }

            for (int i = 0; i < sunnys.Count; i++)
            {
                if (sunnys[i].flash == true)
                {
                    e.Graphics.FillRectangle(flashBrush, sunnys[i].x, sunnys[i].y, sunnys[i].width, sunnys[i].height);
                }
                else
                {
                    e.Graphics.FillRectangle(sunBrush, sunnys[i].x, sunnys[i].y, sunnys[i].width, sunnys[i].height);
                }
            }

            for (int i = 0; i < zombos.Count; i++)
            {
                e.Graphics.FillRectangle(zomBrush, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
            }

            e.Graphics.FillRectangle(redBrush, house);
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            time++;
            if (peateyCounter > 0)
            {
                peateyCounter++;
                if (peateyCounter == 100)
                {
                    peateyEnabled = true;
                    peateyCounter = 0;
                }
            }

            if (sunnyCounter > 0)
            {
                sunnyCounter++;
                if (sunnyCounter == 100)
                {
                    sunnyEnabled = true;
                    sunnyCounter = 0;
                }
            }

            zomboCounter++;
            if (zomboCounter == zomboTimer)
            {
                SpawnZombo();
                zomboCounter = 0;
                if (zomboTimer >= 100)
                {
                    zomboTimer -= 20;
                }
            }

            foreach (Zombo z in zombos)
            {
                z.Move();
            }

            foreach (Sunny s in sunnys)
            {
                s.counter++;

                if (s.flash == true)
                {
                    s.flashCounter++;
                }

                if (s.flashCounter >= 10)
                {
                    s.flash = false;
                    s.flashCounter = 0;
                }

                if (s.counter > 250)
                {
                    s.SpawnSun();
                    sunSound.Play();
                    s.counter = 0;
                    s.flash = true;
                }
            }

            for (int i = 0; i < peateys.Count; i++)
            {
                peateys[i].counter++;

                if (peateys[i].counter > 85)
                {
                    Shoot(peateys[i].x, peateys[i].y);
                    peateys[i].counter = 0;
                }
            }

            for (int i = 0; i < peas.Count; i++)
            {
                peas[i].Move();

                foreach (Zombo z in zombos)
                {
                    if (peas[i].Collision(z) == true)
                    {
                        peas.Remove(peas[i]);
                        z.health--;
                        peaSound.Play();

                        if (z.health < 1)
                        {
                            deadagainSound.Play();
                            zombos.Remove(z);
                            score++;
                            break;
                        }
                        break;
                    }
                }
            }

            foreach (Zombo z in zombos)
            {
                if (z.Collision() == true)
                {
                    GameOver("lose");
                }
            }

            sunCounter++;
            if (sunCounter == 125)
            {
                sun += 25;
                sunCounter = 0;
            }
            sunLabel.Text = $"Sun: {sun}";

            if (plant == "peatey" && peateyEnabled == true)
            {
                peateyButton.BackColor = Color.LimeGreen;
            }
            else if (peateyEnabled == false)
            {
                peateyButton.BackColor = Color.Gray;
            }
            else
            {
                peateyButton.BackColor = Color.Gainsboro;
            }

            if (plant == "sunny" && sunnyEnabled == true)
            {
                sunnyButton.BackColor = Color.Gold;
            }
            else if (sunnyEnabled == false)
            {
                sunnyButton.BackColor = Color.Gray;
            }
            else
            {
                sunnyButton.BackColor = Color.Gainsboro;
            }

            if (score >= 20)
            {
                GameOver("win");
            }

            timeLabel.Text = $"Time: {time / 32}";

            Refresh();
        }

        private void Shoot(int x, int y)
        {
            Pea newPea = new Pea(x + 60, y + 30);
            peas.Add(newPea);
        }

        #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 262;
            int y = 123;
            
            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button1.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button1.Visible = false;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 262;
            int y = 239;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button2.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = 262;
            int y = 355;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button3.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button3.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = 262;
            int y = 471;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button4.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button4.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = 262;
            int y = 587;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button5.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button5.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = 410;
            int y = 123;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button6.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button6.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x = 410;
            int y = 239;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button7.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button7.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = 410;
            int y = 355;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button8.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button8.Visible = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x = 410;
            int y = 471;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button9.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button9.Visible = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x = 410;
            int y = 587;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button10.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button10.Visible = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int x = 554;
            int y = 123;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button11.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button11.Visible = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int x = 554;
            int y = 239;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button12.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button12.Visible = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int x = 554;
            int y = 355;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button13.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button13.Visible = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int x = 554;
            int y = 471;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button14.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button14.Visible = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int x = 554;
            int y = 587;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button15.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button15.Visible = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int x = 697;
            int y = 123;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button16.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button16.Visible = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int x = 697;
            int y = 239;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button17.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button17.Visible = false;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int x = 697;
            int y = 355;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button18.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button18.Visible = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int x = 697;
            int y = 471;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button19.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button19.Visible = false;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int x = 697;
            int y = 587;

            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                button20.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                button20.Visible = false;
            }
        }
        #endregion
        
        private void peateyButton_Click(object sender, EventArgs e)
        {
            plant = "peatey";
        }

        private void sunnyButton_Click(object sender, EventArgs e)
        {
            plant = "sunny";
        }

        public void GameOver(string outcome)
        {
            if (outcome == "lose")
            {
                win = false;
                gameEngine.Enabled = false;
                time /= 20;
                Form1.ChangeScreen(this, new GameOverScreen());
            }

            if (outcome == "win")
            {
                win = true;
                gameEngine.Enabled = false;
                time /= 20;
                Form1.ChangeScreen(this, new GameOverScreen());
            }
        }
    }
}
