using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvz
{
    public class Cherry
    {
        public int x, y;
        public int width = 50;
        public int height = 50;
        public int counter = 0;
        public bool boom = false;

        public Cherry(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Boom()
        {
            boom = true;

        }
    }
}
