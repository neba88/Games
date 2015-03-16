using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zmijica
{
    public class Zmija
    {
        private Rectangle[] zmijaRec;
        private SolidBrush cetka;
        private int x, y, width, height;
        //Fud fud;
        //Zmija zmija;

        public Rectangle[] ZmijaRec
        {
            get { return zmijaRec; }
        }

        public Zmija()
        {
            zmijaRec = new Rectangle[3];
            cetka = new SolidBrush(Color.DodgerBlue);

            x = 20;
            y = 0;
            width = 10;
            height = 10;

            for (int i = 0; i < zmijaRec.Length; i++)
            {
                zmijaRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }

        }
        public void drawZmija(Graphics paper)
        {
            foreach (Rectangle rec in zmijaRec)
            {
                paper.FillRectangle(cetka, rec);
            }
        }

        public void drawZmija()
        {
            for (int i = zmijaRec.Length - 1; i > 0; i--)
            {
                zmijaRec[i] = zmijaRec[i - 1];
            }
        }

        public void moveDown()
        {
            drawZmija();
            zmijaRec[0].Y += 10;
        }
        public void moveUp()
        {
            drawZmija();
            zmijaRec[0].Y -= 10;
        }
        public void moveRight()
        {
            drawZmija();
            zmijaRec[0].X += 10;
        }
        public void moveLeft()
        {
            drawZmija();
            zmijaRec[0].X -= 10;
        }

        public void rastZmije()
        {
            
                List<Rectangle> rec = zmijaRec.ToList();
                rec.Add(new Rectangle(zmijaRec[zmijaRec.Length - 1].X, zmijaRec[zmijaRec.Length - 1].Y, width, height));
                zmijaRec = rec.ToArray();
            
        }
    }
}
