using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int x = 200, y = 200, r = 50;
        GraphicsPath gp = new GraphicsPath();
        Pen pen = new Pen(Color.Red);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point current = e.Location;
            if (gp.IsVisible(current))
            {
                pen = new Pen(Color.Blue);
            }
            else
            {
                pen = new Pen(Color.Red);
            }
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle rectangle = new Rectangle(r, r, 2 * r, 2 * r);
            gp.AddEllipse(rectangle);
            gp.AddRectangle(new Rectangle(x, r, 3 * r, 3 * r));
        }
                
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPath(pen.Brush, gp);
            //e.Graphics.DrawPolygon(new Pen(Color.Yellow), new Point[]
            e.Graphics.FillPolygon(new Pen(Color.Yellow).Brush, new Point[]
            {
                new Point(100,100),
                new Point(100,200),
                new Point(200,100)
            });
        }
    }
}
