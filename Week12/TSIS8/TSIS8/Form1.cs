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
            //черный задний фон
            this.BackColor = Color.Black;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            //создадим синий фон
            SolidBrush brush = new SolidBrush(Color.Blue);
            g.FillRectangle(brush, 10, 10, Width - 35, Height - 60);

            //рисуем звезды
            SolidBrush solidBrush = new SolidBrush(Color.White);
            Circle star1 = new Circle(40, 60, e);
            Circle star2 = new Circle(60, 300, e);
            Circle star3 = new Circle(250, 40, e);
            Circle star4 = new Circle(230, 270, e);
            Circle star5 = new Circle(410, 80, e);
            Circle star6 = new Circle(530, 200, e);
            Circle star7 = new Circle(600, 120, e);
            Circle star8 = new Circle(600, 300, e);

            //info table
            Pen pen = new Pen(Color.Yellow, 3);
            g.DrawRectangle(pen, 450, 15, 200, 30);
            g.FillRectangle(solidBrush, 452, 17, 197, 27);
            g.DrawString("Level: 1 Score: 300 Live: ***", new Font("Calibri", 12F), new SolidBrush(Color.Black), 450, 20);

        }
    }
    public class Circle
    {//класс для создания звезд
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
