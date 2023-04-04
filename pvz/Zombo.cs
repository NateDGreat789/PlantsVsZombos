using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pvz
{
    internal class Zombo
    {
        public int x, y;
        public int width = 70;
        public int height = 100;
        public int speed = 1;
        public int health = 5;

        public Zombo (int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move()
        {
            x -= speed;
        }

        public bool Collision()
        {
            Rectangle zombRec = new Rectangle(x, y, width, height);

            if (zombRec.IntersectsWith(GameScreen.house))
            {
                return true;
            }
            return false;
        }
    }
}
