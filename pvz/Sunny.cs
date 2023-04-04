using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvz
{
    internal class Sunny
    {
        public int x, y;
        public int width = 90;
        public int height = 65;
        public int counter = 50;
        public int flashCounter = 0;
        public bool flash = false;

        public Sunny(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void SpawnSun()
        {
            GameScreen.sun += 25;
        }
    }
}
