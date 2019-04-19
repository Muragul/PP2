using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bounce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkBlue;
            timer1.Interval = 50;
            timer1.Enabled = true;
        }

        int dx = 5, dy = 5;
        int x = 50, y = 50, r = 20;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        Pen pen = new Pen(Color.AliceBlue);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(pen.Brush, x - r, y - r, 2 * r, 2 * r);
            x += dx;
            y += dy;
            if (y+r+r >= this.Height || y <= 0) dy *= -1;
            if (x+r+r >= this.Width || x <= 0) dx *= -1;
        }
    }
}
