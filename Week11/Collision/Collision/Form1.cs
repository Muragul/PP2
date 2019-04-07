using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collision
{
    public partial class Form1 : Form
    {
        public int dx1 = 10, dy1 = 10, dx2 = 10, dy2 = 10, dx3 = 10, dy3 = 10;
        
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public bool Collision (Button btn1, Button btn2)
        {
            Point loc1 = btn1.Location;
            Point loc2 = btn2.Location;
            if (loc1.X == loc2.X + btn2.Width || loc2.X == loc1.X + btn1.Width)
                if (loc1.Y == loc2.Y + btn2.Height || loc2.Y == loc1.Y + btn1.Height) return true;
                    return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point location1 = button1.Location;
            if (location1.X + button1.Width + 20 > Width || location1.X < 0) dx1 *= -1;
            if (location1.Y + button1.Height + 40 > Height || location1.Y < 0) dy1 *= -1;
            location1.X += dx1;
            location1.Y += dy1;
            button1.Location = location1;
            Point location2 = button2.Location;
            if (location2.X + button1.Width + 20 > Width || location2.X < 0) dx2 *= -1;
            if (location2.Y + button1.Height + 40 > Height || location2.Y < 0) dy2 *= -1;
            location2.X += dx2;
            location2.Y += dy2;
            button2.Location = location2;
            Point location = button3.Location;
            if (location.X + button1.Width + 20 > Width || location.X < 0) dx3 *= -1;
            if (location.Y + button1.Height + 40 > Height || location.Y < 0) dy3 *= -1;
            location.X += dx3;
            location.Y += dy3;
            button3.Location = location;
        }
    }
}
