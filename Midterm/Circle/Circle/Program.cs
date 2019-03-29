using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Circle
{
    class Snake
    {
        public int x, y;
        public int k2 = 0;
        enum Direction1
        {
            up,
            down,
            none
        }
        enum Direction2
        {
            left,
            right,
            none
        }
        Direction1 d1 = Direction1.none;
        Direction2 d2 = Direction2.none;

        public Snake(int x, int y)
        {
            this.x = x;
            this.y = y;
            d1 = Direction1.up;
            d2 = Direction2.right;
        }

        public void Move()
        {
            if (k2 == 4 && d1 == Direction1.up) d1 = Direction1.down; else
            if (k2 == 4 && d1 == Direction1.down) d1 = Direction1.up; 

            if (k2 == 8)
            {
                if (d2 == Direction2.right) d2 = Direction2.left;
                else
                    d2 = Direction2.right;
                k2 = 0;
            }
            k2++;
        }

        public void Draw()
        {
            if (d2 == Direction2.right) x+=2;
            else x-=2;
            if (d1 == Direction1.down) y++;
            else y--;
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.Write('*');
        }
    }
    class Program
    {
        static Snake snake;
        static void Main(string[] args)
        {
            snake = new Snake(10, 10);
            Thread thread = new Thread(Move);
            thread.Start();
        }
        public static void Move()
        {
            while (true)
            {
                snake.Move();
                snake.Draw();
                Thread.Sleep(400);
            }
        }
    }
}
