using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pvz
{
    internal class Pea
    {
        public int x, y;
        public int size = 30;
        public int speed = 10;

        public Pea(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move()
        {
            x += speed;
        }

        public bool Collision(Zombo z)
        {
            Rectangle peaRec = new Rectangle(x, y, size, size);
            Rectangle zombRec = new Rectangle(z.x, z.y, z.width, z.height);

            if (peaRec.IntersectsWith(zombRec))
            {
                return true;
            }
            return false;
        }
    }
}
