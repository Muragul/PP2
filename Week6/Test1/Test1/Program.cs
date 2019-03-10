using System;
using System.Collections.Generic;

namespace Test1
{
    class Program
    {
        public static void Draw(int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write('*');
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int x = 10, y = 10;
            bool isAlive = true;
            while (isAlive)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow) { y--; }
                if (consoleKey.Key == ConsoleKey.DownArrow) { y++; }
                if (consoleKey.Key == ConsoleKey.LeftArrow) { x--; x--; }
                if (consoleKey.Key == ConsoleKey.RightArrow) { x++; x++; }
                if (consoleKey.Key == ConsoleKey.Escape) { break; }
                Draw(x, y);
            }
        }
    }
}

