using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Draw1
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Pen pen = new Pen(Color.Yellow, 4);
            Pen pen1 = new Pen(Color.Aqua, 4);
            g.DrawLine(pen, 10, 10, 200, 200);
            g.DrawRectangle(pen1, 0, 0, Width, Height);
            HatchBrush brush = new HatchBrush(HatchStyle.Cross, Color.Violet, Color.Beige);
            //g.FillRectangle(brush, 0, 0, Width, Height);
            g.FillEllipse(brush, 300, 50, 50, 50);
        }
    }
}
