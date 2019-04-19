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

namespace animation
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x=50, y=50;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 50;
            timer1.Enabled = true;
        }
        int a = 100, b = 50;

        public void Car(PaintEventArgs e)
        {
            Pen pencil = new Pen(Color.Azure);
            e.Graphics.FillPolygon(pencil.Brush, new Point[]
            {
                new Point(a,b),
                new Point(a+10,b),
                new Point(a+20,b-10),
                new Point(a+30,b-10),
                new Point(a+40,b),
                new Point(a+50,b),
                new Point(a+40,b+20),
                new Point(a+10,b+20)
            });
            pencil.Color = Color.Brown;
            e.Graphics.FillEllipse(pencil.Brush, new Rectangle(a + 7, b+15, 10, 10));
            e.Graphics.FillEllipse(pencil.Brush, new Rectangle(a + 32, b+15, 10, 10));
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            SolidBrush brush1 = new SolidBrush(Color.Blue);
            g.FillRectangle(brush1, 10, 10, Width - 35, Height - 60);

            Circle star1 = new Circle(40, 60, e);
            Circle star2 = new Circle(60, 300, e);
            Circle star3 = new Circle(250, 40, e);
            Circle star4 = new Circle(230, 270, e);
            Circle star5 = new Circle(410, 80, e);
            Circle star6 = new Circle(530, 200, e);
            Circle star7 = new Circle(600, 120, e);
            Circle star8 = new Circle(600, 300, e);
            
            SolidBrush brush = new SolidBrush(Color.Red);
            Point[] points =
                {
                new Point(x,y),
                new Point(x+40,y),
                new Point(x+20,y+30)
            };
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLines(points);
            path.CloseFigure();
            g.FillPath(brush, path);
            Point[] points1 =
            {
                new Point(x+20,y-10),
                new Point(x+40,y+20),
                new Point(x,y+20)
            };
            GraphicsPath path1 = new GraphicsPath();
            path1.StartFigure();
            path1.AddLines(points1);
            path1.CloseFigure();
            g.FillPath(brush, path1);

            Car(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            x++; y++;
            a++;
        }
    }
    public class Circle
    {
        Graphics g;
        int x;
        int y;
        SolidBrush brush = new SolidBrush(Color.White);

        public Circle(int x, int y, PaintEventArgs e)
        {
            this.x = x;
            this.y = y;
            g = e.Graphics;
            g.FillEllipse(brush, x, y, 20, 20);
        }
    }
}
