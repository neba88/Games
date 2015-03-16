using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zmijica
{
    public class Fud
    {
        private int x, y;
        private int width, height;
        private SolidBrush cetkica;
        public Rectangle fudRec;

        public Fud(Random randFud)
        {
            x = randFud.Next(0, 29) * 10;
            y = randFud.Next(0, 29) * 10;

            cetkica = new SolidBrush(Color.LawnGreen);

            width = 10;
            height = 10;

            fudRec = new Rectangle(x, y, width, height);
        }
        
        public void fudLokacija(Random randFud)
        {
            x = randFud.Next(0, 29) * 10;
            y = randFud.Next(0, 29) * 10;
        }

        public void drawFud(Graphics paper)
        {
            fudRec.X = x;
            fudRec.Y = y;

            paper.FillRectangle(cetkica, fudRec);
        }
    }
}
