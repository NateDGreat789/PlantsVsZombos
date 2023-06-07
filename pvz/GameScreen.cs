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
        #region variables
        SoundPlayer plantSound = new SoundPlayer(Properties.Resources.plant);
        SoundPlayer deadagainSound = new SoundPlayer(Properties.Resources.deadagain);
        SoundPlayer peaSound = new SoundPlayer(Properties.Resources.pea);
        SoundPlayer sunSound = new SoundPlayer(Properties.Resources.sun);

        List<Peatey> peateys = new List<Peatey>();
        List<Pea> peas = new List<Pea>();
        List<Sunny> sunnys = new List<Sunny>();
        List<Cherry> cherrys = new List<Cherry>();
        List<Zombo> zombos = new List<Zombo>();
        List<Button> buttons = new List<Button>();

        Pen blackPen = new Pen(Color.Black, 7);
        SolidBrush greenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush peaBrush = new SolidBrush(Color.ForestGreen);
        SolidBrush sunBrush = new SolidBrush(Color.Gold);
        SolidBrush cherryBrush = new SolidBrush(Color.Red);
        SolidBrush flashBrush = new SolidBrush(Color.Yellow);
        SolidBrush zomBrush = new SolidBrush(Color.SeaGreen);
        SolidBrush zomFlashBrush = new SolidBrush(Color.MediumAquamarine);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        int zomboLane, zomboHeight;
        int zomboCounter;
        int zomboTimer;
        public static int sun;
        int sunCounter;
        int peateyCounter;
        int sunnyCounter;
        int cherryCounter;
        public static double time;
        public static int score;
        string plant;

        bool peateyEnabled = true;
        bool sunnyEnabled = true;
        bool cherryEnabled = true;
        public static bool win;

        Random rnd = new Random ();

        public static Rectangle house = new Rectangle(182, 99, 70, 561);
        #endregion

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

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);


            foreach (Button b in buttons)
            {
                b.Visible = true;
            }
        }

        public void PlacePeatey(int x, int y)
        {
            Peatey newPeatey = new Peatey(x + 15, y + 5);
            peateys.Add(newPeatey);
            sun -= 100;
            peateyCounter++;
            plantSound.Play();
            peateyEnabled = false;
        }

        public void PlaceSunny(int x, int y)
        {
            Sunny newSunny = new Sunny(x + 5, y + 25);
            sunnys.Add(newSunny);
            sun -= 50;
            sunnyCounter++;
            plantSound.Play();
            sunnyEnabled = false;
        }

        public void PlaceCherry(int x, int y)
        {
            Cherry newCherry = new Cherry(x + 5, y + 5);
            cherrys.Add(newCherry);
            sun -= 150;
            cherryCounter++;
            plantSound.Play();
            cherryEnabled = false;
        }

        public void SpawnZombo()
        {
            zomboLane = rnd.Next(0, 5);
            if (zomboLane == 0)
            {
                zomboHeight = 101;
            }
            else if (zomboLane == 1)
            {
                zomboHeight = 217;
            }
            else if (zomboLane == 2)
            {
                zomboHeight = 333;
            }
            else if (zomboLane == 3)
            {
                zomboHeight = 449;
            }
            else if (zomboLane == 4)
            {
                zomboHeight = 565;
            }
            Zombo newZombo = new Zombo(1300, zomboHeight);
            zombos.Add(newZombo);
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)          
        {
            for (int i = 0; i < peateys.Count; i++)
            {
                e.Graphics.DrawRectangle(blackPen, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
                e.Graphics.FillRectangle(greenBrush, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
            }

            for (int i = 0; i < peas.Count; i++)
            {
                e.Graphics.DrawRectangle(blackPen, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
                e.Graphics.FillRectangle(peaBrush, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
            }

            for (int i = 0; i < sunnys.Count; i++)
            {
                if (sunnys[i].flash == true)
                {
                    e.Graphics.DrawRectangle(blackPen, sunnys[i].x, sunnys[i].y, sunnys[i].width, sunnys[i].height);
                    e.Graphics.FillRectangle(flashBrush, sunnys[i].x, sunnys[i].y, sunnys[i].width, sunnys[i].height);
                }
                else
                {
                    e.Graphics.DrawRectangle(blackPen, sunnys[i].x, sunnys[i].y, sunnys[i].width, sunnys[i].height);
                    e.Graphics.FillRectangle(sunBrush, sunnys[i].x, sunnys[i].y, sunnys[i].width, sunnys[i].height);
                }
            }

            for (int i = 0; i < zombos.Count; i++)
            {
                if (zombos[i].flash == true)
                {
                    e.Graphics.DrawRectangle(blackPen, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                    e.Graphics.FillRectangle(zomFlashBrush, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                }
                else
                {
                    e.Graphics.DrawRectangle(blackPen, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                    e.Graphics.FillRectangle(zomBrush, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                }
            }

            e.Graphics.FillRectangle(redBrush, house);
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            #region counters
            time++;

            sunCounter++;
            if (sunCounter == 125)
            {
                sun += 25;
                sunCounter = 0;
            }
            sunLabel.Text = $"Sun: {sun}";

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

            if (cherryCounter > 0)
            {
                cherryCounter++;
                if (cherryCounter == 100)
                {
                    cherryEnabled = true;
                    cherryCounter = 0;
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

            for (int i = 0; i < cherrys.Count; i++)
            {
                cherrys[i].counter++;

                if (cherrys[i].counter > 50)
                {
                    cherrys.RemoveAt(i);
                }
            }

            foreach (Zombo z in zombos)
            {
                if (z.flash == true)
                {
                    z.flashCounter++;
                }

                if (z.flashCounter >= 5)
                {
                    z.flash = false;
                    z.flashCounter = 0;
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
#endregion

            foreach (Zombo z in zombos)
            {
                z.Move();
            }

            #region collision
            for (int i = 0; i < peas.Count; i++)
            {
                peas[i].Move();

                foreach (Zombo z in zombos)
                {
                    if (peas[i].Collision(z) == true)
                    {
                        peas.Remove(peas[i]);
                        z.health--;
                        z.flash = true;
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

            for (int i = 0; i < peateys.Count; i++)
            {
                foreach (Zombo z in zombos)
                {
                    try
                    {
                        if (z.PlantCollision(peateys[i]))
                        {
                            z.speed = 0;
                            peateys[i].hp--;
                            if (peateys[i].hp < 1)
                            {
                                peateys.Remove(peateys[i]);
                                z.speed = 1;
                            }
                        }
                        else
                        {
                            z.speed = 1;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            for (int i = 0; i < sunnys.Count; i++)
            {
                foreach (Zombo z in zombos)
                {
                    try
                    {
                        if (z.PlantCollision(sunnys[i]))
                        {
                            z.speed = 0;
                            sunnys[i].hp--;
                            if (sunnys[i].hp < 1)
                            {
                                sunnys.Remove(sunnys[i]);
                                z.speed = 1;
                            }
                        }
                        else
                        {
                            z.speed = 1;
                        }
                    }
                    catch 
                    { 

                    }
                }
            }

            for (int i = 0; i < cherrys.Count; i++)
            {
                foreach (Zombo z in zombos)
                {
                    if (z.PlantCollision(cherrys[i]))
                    {
                        z.speed = 0;
                        sunnys[i].hp--;
                        if (sunnys[i].hp < 1)
                        {
                            sunnys.Remove(sunnys[i]);
                            z.speed = 1;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            foreach (Zombo z in zombos)
            {
                if (z.HouseCollision() == true)
                {
                    GameOver("lose");
                }
            }
            #endregion

            #region plantButtons
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
            #endregion

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

        #region lawnButtons
        private void button1_Click(object sender, EventArgs e)
        {
            plantPlant(button1, 280, 101);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            plantPlant(button2, 280, 217);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plantPlant(button3, 280, 333);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            plantPlant(button4, 280, 449);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            plantPlant(button5, 280, 565);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            plantPlant(button6, 376, 101);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            plantPlant(button7, 376, 217);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            plantPlant(button8, 376, 333);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            plantPlant(button9, 376, 449);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            plantPlant(button10, 376, 565);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            plantPlant(button11, 472, 101);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            plantPlant(button12, 472, 217);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            plantPlant(button13, 472, 333);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            plantPlant(button14, 472, 449);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            plantPlant(button15, 472, 565);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            plantPlant(button16, 569, 101);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            plantPlant(button17, 569, 217);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            plantPlant(button18, 569, 333);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            plantPlant(button19, 569, 449);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            plantPlant(button20, 569, 565);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            plantPlant(button21, 665, 101);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            plantPlant(button22, 665, 217);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            plantPlant(button23, 665, 333);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            plantPlant(button24, 665, 449);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            plantPlant(button25, 665, 565);
        }
        #endregion

        private void plantPlant(Button b, int x, int y)
        {
            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y);
                b.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                b.Visible = false;
            }
        }
        
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
