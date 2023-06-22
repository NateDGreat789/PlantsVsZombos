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
        List<int> x = new List<int>();
        List<int> y = new List<int>();

        Pen blackPen = new Pen(Color.Black, 7);
        SolidBrush greenBrush = new SolidBrush(Color.LimeGreen);
        SolidBrush peaBrush = new SolidBrush(Color.ForestGreen);
        SolidBrush sunBrush = new SolidBrush(Color.Gold);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush snowBrush = new SolidBrush(Color.Aqua);
        SolidBrush seaBrush = new SolidBrush(Color.DeepSkyBlue);
        SolidBrush boomBrush = new SolidBrush(Color.PeachPuff);
        SolidBrush flashBrush = new SolidBrush(Color.Yellow);
        SolidBrush zomBrush = new SolidBrush(Color.SeaGreen);
        SolidBrush zomFlashBrush = new SolidBrush(Color.MediumAquamarine);
        SolidBrush zomSloBrush = new SolidBrush(Color.SteelBlue);
        SolidBrush coneBrush = new SolidBrush(Color.Orange);
        SolidBrush bucketBrush = new SolidBrush(Color.Silver);

        public static int level;

        int zomboLane, zomboHeight;
        int zomboCounter;
        int zomboCount;
        int zomboTimer;
        public static int sun;
        int sunCounter;
        int peateyCounter;
        int sunnyCounter;
        int cherryCounter;
        int snowCounter;
        int goal;
        public static int score;
        string plant;

        bool peateyEnabled = true;
        bool sunnyEnabled = true;
        bool cherryEnabled = true;
        bool snowEnabled = true;
        public static bool win;

        Random rnd = new Random ();

        public static Rectangle house = new Rectangle(182, 99, 70, 561);
        Rectangle buttonRec = new Rectangle(0, 0, 80, 80);
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
            score = 0;
            peateyEnabled = true;
            sunnyEnabled = true;

            peateys.Clear();
            peas.Clear();
            sunnys.Clear();
            zombos.Clear();

            level1t.Visible = false;
            level1b.Visible = false;
            level1x.Visible = false;
            peateyButton.Visible = false;
            sunnyButton.Visible = false;
            cherryButton.Visible = false;
            snowButton.Visible = false;

            #region buttonXY
            buttons.Add(button1);
            y.Add(101);
            x.Add(280);
            buttons.Add(button2);
            y.Add(217);
            x.Add(280);
            buttons.Add(button3);
            y.Add(333);
            x.Add(280);
            buttons.Add(button4);
            y.Add(449);
            x.Add(280);
            buttons.Add(button5);
            y.Add(565);
            x.Add(280);
            buttons.Add(button6);
            y.Add(101);
            x.Add(376);
            buttons.Add(button7);
            y.Add(217);
            x.Add(376);
            buttons.Add(button8);
            y.Add(333);
            x.Add(376);
            buttons.Add(button9);
            y.Add(449);
            x.Add(376);
            buttons.Add(button10);
            y.Add(565);
            x.Add(376);
            buttons.Add(button11);
            y.Add(101);
            x.Add(472);
            buttons.Add(button12);
            y.Add(217);
            x.Add(472);
            buttons.Add(button13);
            y.Add(333);
            x.Add(472);
            buttons.Add(button14);
            y.Add(449);
            x.Add(472);
            buttons.Add(button15);
            y.Add(565);
            x.Add(472);
            buttons.Add(button16);
            y.Add(101);
            x.Add(569);
            buttons.Add(button17);
            y.Add(217);
            x.Add(569);
            buttons.Add(button18);
            y.Add(333);
            x.Add(569);
            buttons.Add(button19);
            y.Add(449);
            x.Add(569);
            buttons.Add(button20);
            y.Add(565);
            x.Add(569);
            buttons.Add(button21);
            y.Add(101);
            x.Add(665);
            buttons.Add(button22);
            y.Add(217);
            x.Add(665);
            buttons.Add(button23);
            y.Add(333);
            x.Add(665);
            buttons.Add(button24);
            y.Add(449);
            x.Add(665);
            buttons.Add(button25);
            y.Add(565);
            x.Add(665);
            #endregion

            foreach (Button b in buttons)
            {
                b.Visible = true;
            }

            #region level
            if (level == 0)
            {
                goal = 1000;
                zomboTimer = 270;
                peateyButton.Visible = true;
                sunnyButton.Visible = true;
                cherryButton.Visible = true;
                snowButton.Visible = true;
            }
            else if (level == 1)
            {
                goal = 5;
                zomboTimer = 230;
                peateyButton.Visible = true;
                level1t.Visible = true;
                level1b.Visible = true;
                level1x.Visible = true;
                button1.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button15.Visible = false;
                button16.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button25.Visible = false;
            }
            else if (level == 2)
            {
                goal = 10;
                peateyButton.Visible = true;
                sunnyButton.Visible = true;
            }
            else if (level == 3)
            {
                goal = 15;
                peateyButton.Visible = true;
                sunnyButton.Visible = true;
            }
            else if (level == 4)
            {
                goal = 20;
                peateyButton.Visible = true;
                sunnyButton.Visible = true;
                cherryButton.Visible = true;
            }
            else if (level == 5)
            {
                goal = 25;
                peateyButton.Visible = true;
                sunnyButton.Visible = true;
                cherryButton.Visible = true;
            }
            else if (level == 6)
            {
                goal = 30;
                peateyButton.Visible = true;
                sunnyButton.Visible = true;
                cherryButton.Visible = true;
                snowButton.Visible = true;
            }

            #endregion

            gameEngine.Enabled = true;
        }

        public void PlacePeatey(int x, int y, string type)
        {
            Peatey newPeatey;
            if (type == "snow")
            {
                newPeatey = new Peatey(x + 15, y + 5, "snow");
                sun -= 175;
                snowCounter++;
                snowEnabled = false;
            }
            else
            {
                newPeatey = new Peatey(x + 15, y + 5, "normal");
                sun -= 100;
                peateyCounter++;
                peateyEnabled = false;
            }
            peateys.Add(newPeatey);
            plantSound.Play();
            
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
            Cherry newCherry = new Cherry(x + 5, y + 35);
            cherrys.Add(newCherry);
            sun -= 150;
            cherryCounter++;
            plantSound.Play();
            cherryEnabled = false;
        }

        public void SpawnZombo()
        {
            if (level == 1)
            {
                zomboLane = rnd.Next(1, 4);
            }
            else
            {
                zomboLane = rnd.Next(0, 5);
            }

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

            Zombo newZombo;

            if (zomboCount < 15)
            {
                if (rnd.Next(0, 10) > 7 && level != 1 && zomboCount > 5)
                {
                    newZombo = new Zombo(1300, zomboHeight, "cone");
                }
                else if (rnd.Next(0, 10) == 7 && level != 1 && zomboCount > 5)
                {
                    newZombo = new Zombo(1300, zomboHeight, "bucket");
                }
                else
                {
                    newZombo = new Zombo(1300, zomboHeight, "normal");
                }
            }
            else
            {
                if (rnd.Next(0, 5) > 2 && zomboCount > 5)
                {
                    newZombo = new Zombo(1300, zomboHeight, "cone");
                }
                else if (rnd.Next(0, 5) == 2 && zomboCount > 5)
                {
                    newZombo = new Zombo(1300, zomboHeight, "bucket");
                }
                else
                {
                    newZombo = new Zombo(1300, zomboHeight, "normal");
                }
            }

            zombos.Add(newZombo);

            zomboCount++;
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)          
        {
            for (int i = 0; i < peateys.Count; i++)
            {
                if (peateys[i].type == "snow")
                {
                    e.Graphics.DrawRectangle(blackPen, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
                    e.Graphics.FillRectangle(snowBrush, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
                }
                else
                {
                    e.Graphics.DrawRectangle(blackPen, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
                    e.Graphics.FillRectangle(greenBrush, peateys[i].x, peateys[i].y, peateys[i].width, peateys[i].height);
                }
            }

            for (int i = 0; i < peas.Count; i++)
            {
                if (peas[i].type == "snow")
                {
                    e.Graphics.DrawRectangle(blackPen, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
                    e.Graphics.FillRectangle(seaBrush, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
                }
                else
                {
                    e.Graphics.DrawRectangle(blackPen, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
                    e.Graphics.FillRectangle(peaBrush, peas[i].x, peas[i].y, peas[i].size, peas[i].size);
                }
                
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
                else if (zombos[i].slow == true)
                {
                    e.Graphics.DrawRectangle(blackPen, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                    e.Graphics.FillRectangle(zomSloBrush, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                }
                else
                {
                    e.Graphics.DrawRectangle(blackPen, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                    e.Graphics.FillRectangle(zomBrush, zombos[i].x, zombos[i].y, zombos[i].width, zombos[i].height);
                }

                if (zombos[i].type == "cone" && zombos[i].hp > 5)
                {
                    e.Graphics.DrawRectangle(blackPen, zombos[i].x, zombos[i].y - 20, zombos[i].width, 30);
                    e.Graphics.FillRectangle(coneBrush, zombos[i].x, zombos[i].y - 20, zombos[i].width, 30);
                }
                else if (zombos[i].type == "bucket" && zombos[i].hp > 5)
                {
                    e.Graphics.DrawRectangle(blackPen, zombos[i].x, zombos[i].y - 15, zombos[i].width, 25);
                    e.Graphics.FillRectangle(bucketBrush, zombos[i].x, zombos[i].y - 15, zombos[i].width, 25);
                }
            }

            for (int i = 0; i < cherrys.Count; i++)
            {
                if (cherrys[i].boom == true)
                {
                    e.Graphics.DrawRectangle(blackPen, cherrys[i].x, cherrys[i].y, cherrys[i].width, cherrys[i].height);
                    e.Graphics.FillRectangle(boomBrush, cherrys[i].x, cherrys[i].y, cherrys[i].width, cherrys[i].height);
                }
                else
                {
                    e.Graphics.DrawRectangle(blackPen, cherrys[i].x + 30, cherrys[i].y - 30, cherrys[i].width, cherrys[i].height);
                    e.Graphics.FillRectangle(redBrush, cherrys[i].x + 30, cherrys[i].y - 30, cherrys[i].width, cherrys[i].height);
                    e.Graphics.DrawRectangle(blackPen, cherrys[i].x, cherrys[i].y, cherrys[i].width, cherrys[i].height);
                    e.Graphics.FillRectangle(redBrush, cherrys[i].x, cherrys[i].y, cherrys[i].width, cherrys[i].height);
                }
            }

            e.Graphics.FillRectangle(redBrush, house);
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            #region counters
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
                if (cherryCounter == 200)
                {
                    cherryEnabled = true;
                    cherryCounter = 0;
                }
            }

            if (snowCounter > 0)
            {
                snowCounter++;
                if (snowCounter == 150)
                {
                    snowEnabled = true;
                    snowCounter = 0;
                }
            }

            for (int i = 0; i < peateys.Count; i++)
            {
                peateys[i].counter++;

                if (peateys[i].counter > 85)
                {
                    if (peateys[i].type == "snow")
                    {
                        Shoot(peateys[i].x, peateys[i].y, "snow");
                    }
                    else
                    {
                        Shoot(peateys[i].x, peateys[i].y, "normal");
                    }
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

                if (cherrys[i].counter == 50)
                {
                    cherrys[i].Boom();
                }

                if (cherrys[i].boom == true)
                {
                    cherrys[i].boomCounter++;
                    if (cherrys[i].boomCounter == 10)
                    {
                        for (int j = 0; j < x.Count; j++)
                        {
                            if (x[j] == (cherrys[i].x + 65) && y[j] == (cherrys[i].y + 75))
                            {
                                buttons[j].Visible = true;
                            }
                        }
                        cherrys.RemoveAt(i);
                    }
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
            if (zomboCounter == zomboTimer && zomboCount < goal)
            {
                SpawnZombo();
                zomboCounter = 0;
                if (level != 0)
                {
                    if (zomboTimer >= 100)
                    {
                        zomboTimer -= 20;
                    }
                }
                else
                {
                    if (zomboTimer >= 60)
                    {
                        zomboTimer -= 20;
                    }
                }
            }
#endregion

            #region collision
            for (int i = 0; i < peas.Count; i++)
            {
                peas[i].Move();

                foreach (Zombo z in zombos)
                {
                    if (peas[i].Collision(z) == true)
                    {
                        if (peas[i].type == "snow")
                        {
                            z.slow = true;
                            z.slowCounter = 0;
                        }
                        peas.Remove(peas[i]);
                        z.hp--;
                        z.flash = true;
                        peaSound.Play();
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
                                for (int j = 0; j < x.Count; j++)
                                {
                                    if (x[j] == (peateys[i].x - 15) && y[j] == (peateys[i].y - 5))
                                    {
                                        buttons[j].Visible = true;
                                    }
                                }
                                peateys.Remove(peateys[i]);
                                z.speed = 1;
                            }
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
                                for (int j = 0; j < x.Count; j++)
                                {
                                    if (x[j] == (sunnys[i].x - 5) && y[j] == (sunnys[i].y - 25))
                                    {
                                        buttons[j].Visible = true;
                                    }
                                }
                                sunnys.Remove(sunnys[i]);
                                z.speed = 1;
                            }
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
                    try
                    {
                        if (z.PlantCollision(cherrys[i]))
                        {
                            z.speed = 0;
                            if (cherrys[i].boom == true)
                            {
                                z.hp = 0;
                            }
                        }
                    }
                    catch
                    {

                    }
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
                peateyButton.BackColor = Color.LightGreen;
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
                sunnyButton.BackColor = Color.PaleGoldenrod;
            }

            if (plant == "cherry" && cherryEnabled == true)
            {
                cherryButton.BackColor = Color.Red;
            }
            else if (cherryEnabled == false)
            {
                cherryButton.BackColor = Color.Gray;
            }
            else
            {
                cherryButton.BackColor = Color.LightSalmon;
            }

            if (plant == "snow" && snowEnabled == true)
            {
                snowButton.BackColor = Color.Aqua;
            }
            else if (snowEnabled == false)
            {
                snowButton.BackColor = Color.Gray;
            }
            else
            {
                snowButton.BackColor = Color.LightBlue;
            }
            #endregion

            #region gameChecks
            foreach (Zombo z in zombos)
            {
                z.Move();
            }

            for (int i = 0; i < zombos.Count; i++)
            {
                if (zombos[i].hp < 1)
                {
                    deadagainSound.Play();
                    zombos.Remove(zombos[i]);
                    score++;
                }
            }

            foreach (Zombo z in zombos)
            {
                if (z.HouseCollision() == true)
                {
                    GameOver("lose");
                }
            }

            if (score >= goal)
            {
                GameOver("win");
            }

            #region buttonChecks
            //for (int i = 0; i < buttons.Count; i++)
            //{
            //    if (buttons[i].Visible == false)
            //    {
            //        Rectangle tempRec;
            //        buttonRec.X = x[i];
            //        buttonRec.Y = y[i];
            //        foreach (Peatey p in peateys)
            //        {
            //            tempRec = new Rectangle(p.x, p.y, p.width, p.height);
            //            if (buttonRec.IntersectsWith(tempRec))
            //            {
            //                buttons[i].Visible = false;
            //            }
            //            else
            //            {
            //                buttons[i].Visible = true;
            //            }
            //        }
            //        foreach (Sunny s in sunnys)
            //        {
            //            tempRec = new Rectangle(s.x, s.y, s.width, s.height);
            //            if (buttonRec.IntersectsWith(tempRec))
            //            {
            //                buttons[i].Visible = false;
            //            }
            //            else
            //            {
            //                buttons[i].Visible = true;
            //            }
            //        }
            //        foreach (Cherry c in cherrys)
            //        {
            //            tempRec = new Rectangle(c.x, c.y, c.width, c.height);
            //            if (buttonRec.IntersectsWith(tempRec))
            //            {
            //                buttons[i].Visible = false;
            //            }
            //            else
            //            {
            //                buttons[i].Visible = true;
            //            }
            //        }
            //    }
            //}
            #endregion

            #endregion

            Refresh();
        }

        private void Shoot(int x, int y, string type)
        {
            Pea newPea;
            if (type == "snow")
            {
                newPea = new Pea(x + 60, y + 30, "snow");
            }
            else
            {
                newPea = new Pea(x + 60, y + 30, "normal");
            }
            peas.Add(newPea);
        }

        #region lawnButtons
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            plantPlant(buttons[i], x[i], y[i]);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 1;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 2;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 3;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int i = 4;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 5;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = 6;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = 7;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = 8;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = 9;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int i = 10;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i = 11;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int i = 12;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int i = 13;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int i = 14;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int i = 15;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int i = 16;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int i = 17;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int i = 18;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int i = 19;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int i = 20;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int i = 21;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int i = 22;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int i = 23;
            plantPlant(buttons[i], x[i], y[i]);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int i = 24;
            plantPlant(buttons[i], x[i], y[i]);
        }
        #endregion

        private void plantPlant(Button b, int x, int y)
        {
            if (peateyEnabled == true && plant == "peatey" && sun >= 100)
            {
                PlacePeatey(x, y, "normal");
                b.Visible = false;
            }
            else if (sunnyEnabled == true && plant == "sunny" && sun >= 50)
            {
                PlaceSunny(x, y);
                b.Visible = false;
            }
            else if (cherryEnabled == true && plant == "cherry" && sun >= 150)
            {
                PlaceCherry(x, y);
                b.Visible = false;
            }
            else if (snowEnabled == true && plant == "snow" && sun >= 175)
            {
                PlacePeatey(x, y, "snow");
                b.Visible = false;
            }
        }

        #region plantButtons
        private void peateyButton_Click(object sender, EventArgs e)
        {
            plant = "peatey";
        }

        private void sunnyButton_Click(object sender, EventArgs e)
        {
            plant = "sunny";
        }

        private void cherryButton_Click(object sender, EventArgs e)
        {
            plant = "cherry";
        }
        #endregion

        private void snowButton_Click(object sender, EventArgs e)
        {
            plant = "snow";
        }

        public void GameOver(string outcome)
        {
            if (outcome == "lose")
            {
                win = false;
                gameEngine.Enabled = false;
                Form1.ChangeScreen(this, new GameOverScreen());
            }

            if (outcome == "win")
            {
                win = true;
                gameEngine.Enabled = false;
                Form1.ChangeScreen(this, new GameOverScreen());
            }
        }
    }
}
