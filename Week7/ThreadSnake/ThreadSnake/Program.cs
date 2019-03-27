using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSnake
{
    class Snake
    {
        public int x, y;
        public enum Direction
        {
            up,
            down,
            left,
            right,
            none
        }
        public Direction direction = Direction.none;

        public Snake() { }
        public Snake(int x,int y)
        {
            this.x = x;
            this.y = y;
            this.direction = Direction.up;
        }

        public void Move(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.UpArrow && direction != Direction.down)
                direction = Direction.up;
            if (keyInfo.Key == ConsoleKey.DownArrow && direction != Direction.up)
                direction = Direction.down;
            if (keyInfo.Key == ConsoleKey.LeftArrow && direction != Direction.right)
                direction = Direction.left;
            if (keyInfo.Key == ConsoleKey.RightArrow && direction != Direction.left)
                direction = Direction.right;
        }

        public void Draw()
        {
            if (direction == Direction.up)
                y--;
            if (direction == Direction.down)
                y++;
            if (direction == Direction.left)
                x--;
            if (direction == Direction.right)
                x++;
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.Write("*");
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
            while (true)
            {
                snake.Draw();
                Thread.Sleep(200);
            }
        }

        public static void Move()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                snake.Move(consoleKey);
            }
        }
    }
}
