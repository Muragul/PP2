using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Waves
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bitmap;
        public int x, y, r = 0;
        public Color[] colors = new Color[] { Color.Aqua, Color.Blue, Color.CadetBlue, Color.Cyan };
        Random random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 40;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 3;
            int index = random.Next(0, colors.Length - 1);
            Pen pen = new Pen(colors[index], 3);
            g.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            timer1.Start();
            r = 1;
        }
    }
}
