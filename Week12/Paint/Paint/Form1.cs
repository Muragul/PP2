using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        bool mouseclicked = false;
        Point prev;
        Point cur;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseclicked = true;
            prev = e.Location;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseclicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseclicked)
            {
                Pen pen = new Pen(Color.Black, 4);
                cur = e.Location;
                g.DrawLine(pen, prev, cur);
                prev = cur;
                pictureBox1.Refresh();
            }
        }
    }
}
