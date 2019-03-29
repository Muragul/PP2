using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task2
{
    class Snake
    {
        public int x, y;
        public int k=0;
        enum Direction
        {
            up,
            down,
            left,
            right,
            none
        }
        Direction direction = Direction.none;
        public Snake(int x, int y)
        {
            this.x = x;
            this.y = y;
            direction = Direction.right;
        }

        public void Move()
        {
            if (k == 8)
            {
                if (direction == Direction.right) direction=Direction.down; else
                if (direction == Direction.left) direction=Direction.up; else
                if (direction == Direction.down) direction = Direction.left; else
                if (direction == Direction.up) direction=Direction.right;
                k = 0;
            }
            k++;
        }

        public void Draw()
        {
            if (direction == Direction.right) x++; else
            if (direction == Direction.left) x--; else
            if (direction == Direction.down) y++; else
            if (direction == Direction.up) y--;
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
                Thread.Sleep(200);
            }
        }
    }
}
