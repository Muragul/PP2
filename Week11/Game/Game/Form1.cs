using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public int Score = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 200;
            timer1.Enabled = true;
        }
        
        public bool Collision()
        {
            Point location = button1.Location;
            Point loc = label1.Location;
            if (loc.X>=location.X && loc.X <= location.X + button1.Width)
            {
                if (loc.Y >= location.Y) return true;
            }
            return false;
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            Point location = button1.Location;
            string pressed_btn = e.KeyCode + "";
            if (pressed_btn == "A")
            {
                if (location.X <= 0) { } else
                location.X -= 10;
            }
            if (pressed_btn == "D")
            {
                if (location.X + button1.Width + 10 >= Width) { } else
                location.X += 10;
            }
            button1.Location = location;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Collision())
            {
                Point loc = label1.Location;
                loc.Y += 10;
                if (loc.Y + 40 >= Height)
                {
                    timer1.Enabled = false;
                    loc.X = 200;
                    loc.Y = 100;
                    label1.Location = loc;
                    label1.Text = "Score: " + Score + "";
                }
                label1.Location = loc;
            }
            else
            {
                Point location = new Point();
                Random random = new Random();
                location.X = random.Next(0,500);
                location.Y = 0;
                label1.Location = location;
                Score += 100;
            }
        }
    }
}
