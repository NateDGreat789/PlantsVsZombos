using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvz
{
    public class Peatey
    {
        public int x, y;
        public int width = 60;
        public int height = 80;
        public int counter = 25;
        public int hp = 100;
        public string type;

        public Peatey(int _x, int _y, string _type)
        {
            x = _x;
            y = _y;
            type = _type;
        }
    }
}
