using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace pvz
{
    public class Zombo
    {
        public int x, y;
        public int width = 70;
        public int height = 90;
        public int speed = 1;
        public int hp;
        public int flashCounter = 0;
        public bool slow = false;
        public int slowCounter = 0;
        public bool flash = false;
        public string type;

        public Zombo (int _x, int _y, string _type)
        {
            x = _x;
            y = _y;
            type = _type;
            if (type == "normal")
            {
                hp = 5;
            }
            else if (type == "cone")
            {
                hp = 10;
            }
            else if (type == "bucket")
            {
                hp = 15;
            }
        }

        public void Move()
        {
            if (slow == true)
            {
                slowCounter++;
                if (slowCounter %2 == 0)
                {
                    x -= speed;
                }
                if (slowCounter > 100)
                {
                    slow = false;
                }
            }
            else
            {
                x -= speed;
            }
        }

        public bool HouseCollision()
        {
            Rectangle zombRec = new Rectangle(x, y, width, height);

            if (zombRec.IntersectsWith(GameScreen.house))
            {
                return true;
            }
            return false;
        }

        public bool PlantCollision(object o)
        {
            Rectangle objRec = new Rectangle();

            if (o is Cherry)
            {
                Cherry c = (Cherry)o;
                objRec = new Rectangle(c.x, c.y, c.width, c.height);
            }
            else if (o is Sunny)
            {
                Sunny s = (Sunny)o;
                objRec = new Rectangle(s.x, s.y, s.width, s.height);

            }
            else if (o is Peatey)
            {
                Peatey p = (Peatey)o;
                objRec = new Rectangle(p.x, p.y, p.width, p.height);
            }

            Rectangle zombRec = new Rectangle(x, y, width, height);

            if (zombRec.IntersectsWith(objRec))
            {
                return true;
            }
            return false;
        }

        //public bool PlantCollision(Peatey p)
        //{
        //    Rectangle zombRec = new Rectangle(x, y, width, height);
        //    Rectangle peateyRec = new Rectangle(p.x, p.y, p.width, p.height);

        //    if (zombRec.IntersectsWith(peateyRec))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool PlantCollision(Sunny s)
        //{
        //    Rectangle zombRec = new Rectangle(x, y, width, height);
        //    Rectangle sunnyRec = new Rectangle(s.x, s.y, s.width, s.height);

        //    if (zombRec.IntersectsWith(sunnyRec))
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
