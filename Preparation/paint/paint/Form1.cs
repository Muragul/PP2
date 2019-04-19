using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        enum Tools
        {
            pen,
            rectangle,
            ellipse,
            star,
            eraser,
            fill
        }
        Graphics gBitmap;
        Bitmap bitmap;
        Point prev, cur;
        bool mouseclicked = false;
        Pen pen = new Pen(Color.Black, 3);
        Tools tool = Tools.pen;
        Queue<Point> q = new Queue<Point>();
        Color initColor; //на который нажали

        public Form1()
        {
            //Color color = bitmap.GetPixel(100, 100); возвращает цвет пикселя
            //bitmap.SetPixel(100, 100, Color.Blue); закрашивает пиксель в определенный цвет

            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gBitmap = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        public bool Check(int x, int y)
        {
            if (x < 0 || x >= bitmap.Width) return false;
            if (y < 0 || y >= bitmap.Height) return false;
            if (bitmap.GetPixel(x, y) != initColor) return false;
            return true;
        }
        int [] dx = new int[] {1,-1, 0, 0};
        int [] dy = new int[] {0, 0, 1, -1};


        public void Fill(int x, int y)
        {
            q = new Queue<Point>();
            q.Enqueue(new Point(x, y));//добавили в очередь
            bitmap.SetPixel(x, y, pen.Color);

            while (q.Count > 0)
            {
                Point p = q.Dequeue(); //удалили элемент с очереди
                for (int i = 0; i < 4; i++)
                {
                    if (Check(p.X + dx[i], p.Y+dy[i]))
                    {
                        bitmap.SetPixel(p.X + dx[i], p.Y+dy[i], pen.Color);
                        //9pictureBox1.Refresh(); //чтобы увидеть как идет заполнение
                        q.Enqueue(new Point(p.X + dx[i], p.Y+dy[i]));
                    }
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseclicked = true;
            prev = e.Location;
            if (tool == Tools.fill)
            {
                initColor = bitmap.GetPixel(e.Location.X, e.Location.Y);
                Fill(e.Location.X, e.Location.Y);
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseclicked = false;
            if (tool == Tools.rectangle)
            {
                gBitmap.DrawRectangle(pen, GetRectangle(prev, cur));
            } else
            if (tool == Tools.ellipse)
            {
                gBitmap.DrawEllipse(pen, GetRectangle(prev, cur));
            } else
            if (tool == Tools.star)
            {
                gBitmap.DrawPolygon(pen, GetPolygon(prev, cur));
            }
        }
        Rectangle GetRectangle(Point prev, Point cur)
        {
            int minx = Math.Min(prev.X, cur.X);
            int miny = Math.Min(prev.Y, cur.Y);
            int width = Math.Abs(prev.X - cur.X);
            int height = Math.Abs(prev.Y - cur.Y);
            return new Rectangle(minx, miny, width, height);
        }
        Point[] GetPolygon(Point prev, Point cur)
        {
            int x1 = Math.Min(prev.X, cur.X);
            int y1 = Math.Min(prev.Y, cur.Y);
            int x2 = Math.Max(prev.X, cur.X);
            int y2 = Math.Max(prev.Y, cur.Y);

            return new Point[]
            {
                new Point(x1,y2),
                new Point((x1+x2)/2,y1),
                new Point(x2,y2),
                new Point(x1,(y1+y2)/2),
                new Point(x2,(y1+y2)/2)
            };
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left) { } //нажата левая кнопка мыши
            if (mouseclicked)
            {
                cur = e.Location;
                if (tool == Tools.pen)
                {
                    gBitmap.DrawLine(pen, prev, cur);
                    prev = cur;
                } //else
                //if (tool == Tools.rectangle)
                //{
                //    gBitmap.DrawRectangle(pen, GetRectangle(prev, cur));
                //}
            }
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tools.pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tools.rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tools.ellipse;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = Tools.star;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (tool == Tools.rectangle)
            {
                e.Graphics.DrawRectangle(pen, GetRectangle(prev, cur));
            } else
            if (tool == Tools.ellipse)
            {
                e.Graphics.DrawEllipse(pen, GetRectangle(prev, cur));
            } else
            if (tool == Tools.star)
            {
                e.Graphics.DrawPolygon(pen, GetPolygon(prev, cur));
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap = Bitmap.FromFile(openFileDialog1.FileName) as Bitmap;
                pictureBox1.Image = bitmap;
                gBitmap = Graphics.FromImage(bitmap);
                pictureBox1.Refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tool = Tools.fill;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
