using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmijica
{
    public partial class Zmijica : Form
    {
        Random randFud = new Random();
        
        Graphics paper;
        Graphics paper1;
        Zmija zmija = new Zmija();
        Fud fud;
        Power power;

        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
    

        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;

        int score = 0;
        int x, y;
        public Zmijica()
        {
            Random randPower = new Random();
            wplayer.URL = "C:\\DST-Aronara.mp3";
            wplayer.controls.play();
            InitializeComponent();
            fud = new Fud(randFud);
            power = new Power(randPower);
            
        }

        private void Zmijica_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            paper1 = e.Graphics;
            fud.drawFud(paper);
            power.drawPower(paper1);
            zmija.drawZmija(paper);
        }

        private void Zmijica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                down = false;
                up = false;
                left = false;
                right = true;
                pictureBox1.Visible = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snakeScoreLabel.Text = Convert.ToString(score);

            if (down)
            {
                zmija.moveDown();
            }
            if (up)
            {
                zmija.moveUp();
            }
            if (right)
            {
                zmija.moveRight();
            }
            if (left)
            {
                zmija.moveLeft();
            }
            
            for (int i = 0; i < zmija.ZmijaRec.Length; i++)
            {
                
                

                if (zmija.ZmijaRec[i].IntersectsWith(fud.fudRec))
                {
                    timer1.Interval = 50;
                    score += 10;
                    zmija.rastZmije();
                    fud.fudLokacija(randFud);
                    
                    
                }
                Random randPower = new Random();
                
                if (zmija.ZmijaRec[i].IntersectsWith(power.powerRec))
                {
                    timer1.Interval = 100;
                    score += 100;
                    zmija.rastZmije();
                    power.powerLokacija(randPower);
                }
            }

            
            collision();

            this.Invalidate();
        }

        public void collision()
        {
            for (int i = 1; i < zmija.ZmijaRec.Length; i++)
            {
                if (zmija.ZmijaRec[0].IntersectsWith(zmija.ZmijaRec[i]))
                {
                    restart();
                }
            }
            if (zmija.ZmijaRec[0].X < 0 || zmija.ZmijaRec[0].X > 430)
            {
                restart();
            }
            if (zmija.ZmijaRec[0].Y < 0 || zmija.ZmijaRec[0].Y > 360)
            {
                restart();
            }
        }
        public void restart()
        {
            timer1.Interval = 50;
            timer1.Enabled = false;
            MessageBox.Show("Zmija je mrtva.\nYour score is: " + score);
            snakeScoreLabel.Text = "0";
            score = 0;
            
            zmija = new Zmija();
            pictureBox1.Visible = true;
        }
    }
}
