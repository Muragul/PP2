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

namespace TSIS8
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //sky
            SolidBrush brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, 10, 10, Width - 35, Height - 60);

            //stars
            Circle star1 = new Circle(40, 60, e);
            Circle star2 = new Circle(60, 300, e);
            Circle star3 = new Circle(250, 40, e);
            Circle star4 = new Circle(230, 270, e);
            Circle star5 = new Circle(410, 80, e);
            Circle star6 = new Circle(530, 200, e);
            Circle star7 = new Circle(600, 120, e);
            Circle star8 = new Circle(600, 300, e);

            //info table
            SolidBrush solidBrush = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Yellow, 3);
            g.DrawRectangle(pen, 450, 15, 200, 30);
            g.FillRectangle(solidBrush, 452, 17, 197, 27);
            g.DrawString("Level: 1 Score: 300 Live: ***", new Font("Calibri", 12F), new SolidBrush(Color.Black), 450, 20);

            //spaceship
            Point[] points =
            {
                new Point(300,160),
                new Point(350,140),
                new Point(400,160),
                new Point(400,200),
                new Point(350,220),
                new Point(300,200)
            };
            SolidBrush brush1 = new SolidBrush(Color.Yellow);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddLines(points);
            path.CloseFigure();
            g.FillPath(brush1, path);

            //gun
            SolidBrush brush2 = new SolidBrush(Color.Green);
            Point[] points1 =
            {
                new Point(330,180),
                new Point(350,160),
                new Point(370,180),
                new Point(360,180),
                new Point(360,200),
                new Point(340,200),
                new Point(340,180)
            };
            GraphicsPath path1 = new GraphicsPath();
            path1.StartFigure();
            path1.AddLines(points1);
            path1.CloseFigure();
            g.FillPath(brush2, path1);

            //asteroids
            Asteroid asteroid1 = new Asteroid(100, 130, e);
            Asteroid asteroid2 = new Asteroid(150, 240, e);
            Asteroid asteroid3 = new Asteroid(530, 90, e);
            Asteroid asteroid4 = new Asteroid(440, 250, e);

            //bullet
            Rectangle rectangle = new Rectangle(350, 115, 30, 10);
            Rectangle rect = new Rectangle(360, 105, 10, 30);
            GraphicsPath bullet = new GraphicsPath();
            bullet.AddArc(rectangle, 180, 180);
            bullet.AddArc(rectangle, 0, 180);
            g.FillPath(brush2, bullet);
            bullet.AddArc(rect, 180, 180);
            bullet.AddArc(rect, 0, 180);
            g.FillPath(brush2, bullet);

        }
    }
    public class Asteroid
    {
        Graphics g;
        int x, y;
        SolidBrush brush = new SolidBrush(Color.Red);
        public Asteroid(int x,int y,PaintEventArgs e)
        {
            this.x = x;
            this.y = y;
            g = e.Graphics;
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
        }
    }

    public class Circle
    {
        Graphics g;
        int x;
        int y;
        SolidBrush brush = new SolidBrush(Color.White);

        public Circle(int x,int y, PaintEventArgs e)
        {
            this.x = x;
            this.y = y;
            g = e.Graphics;
            g.FillEllipse(brush, x, y, 20, 20);
        }
    }
}
