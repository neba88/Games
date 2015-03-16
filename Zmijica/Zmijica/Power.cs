using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zmijica
{
    public class Power
    {
        private int x, y;
        private int width, height;
        private SolidBrush cetkica;
        public Rectangle powerRec;

        public Power(Random randPower)
        {
            x = randPower.Next(0, 29) * 10;
            y = randPower.Next(0, 29) * 10;

            cetkica = new SolidBrush(Color.DarkOrchid);

            width = 10;
            height = 10;
            powerRec = new Rectangle(x, y, width, height);
        }
        public void powerLokacija(Random randPower)
        {
            x = randPower.Next(0, 29) * 10;
            y = randPower.Next(0, 29) * 10;
        }
        public void drawPower(Graphics paper1)
        {
            powerRec.X = x;
            powerRec.Y = y;

            paper1.FillRectangle(cetkica, powerRec);
        }

    }
}
