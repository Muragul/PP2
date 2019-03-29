using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TraficLight
{
    class Program
    {
        static int cursor = 0;
        static int[] a = new int[3] { 0, 0, 0};

        //static int colorNum = 0;
        //static void Color()
        //{
        //    Console.Clear();
        //    if (colorNum == 0)
        //    {
        //        for (int i = 0; i < 23; i++)
        //        {
        //            for (int j = 0; j < 30; j++)
        //            {
        //                if (i < 8 && i >= 0)
        //                {
        //                    Console.BackgroundColor = ConsoleColor.Green;
        //                }
        //                else
        //                {
        //                    Console.BackgroundColor = ConsoleColor.Black;
        //                }
        //                Console.SetCursorPosition(j, i);
        //                Console.WriteLine(" ");
        //            }
        //        }
        //        colorNum = 1;
        //    }
        //    else if (colorNum == 1)
        //    {
        //        for (int i = 8; i < 16; i++)
        //        {
        //            for (int j = 0; j < 30; j++)
        //            {
        //                if (i >= 8 && i < 16)
        //                {
        //                    Console.BackgroundColor = ConsoleColor.Red;
        //                }
        //                Console.SetCursorPosition(j, i);
        //                Console.WriteLine(" ");
        //            }
        //        }
        //        colorNum = 2;
        //    }
        //    else
        //    {
        //        for (int i = 16; i < 23; i++)
        //        {
        //            for (int j = 0; j < 30; j++)
        //            {
        //                if (i < 24 && i >= 16)
        //                {
        //                    Console.BackgroundColor = ConsoleColor.Yellow;
        //                }
        //                Console.SetCursorPosition(j, i);
        //                Console.WriteLine(" ");
        //            }
        //        }
        //        colorNum = 0;
        //    }
        //    Console.BackgroundColor = ConsoleColor.Black;
        //}
        public static void Color(int i)
        {
            if (i == 0 && i == cursor) Console.ForegroundColor = ConsoleColor.Red;
            else
            if (i == 1 && i == cursor) Console.ForegroundColor = ConsoleColor.Yellow;
            else
            if (i == 2 && i == cursor) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Draw()
        {
            for (int i = 0; i < 3; i++)
            {
                Color(i);
                Console.WriteLine(a[i]);
            }
        }
        public static void Curs()
        {
            if (cursor == 2) cursor = 0; else cursor++;
        }
        static void Main(string[] args)
        {
            Console.SetCursorPosition(50, 50);
            //Console.SetWindowSize(30, 24);
            //Console.SetBufferSize(30, 24);
            //Console.CursorVisible = false;
            //while (true)
            //{
            //    Color();
            //    Thread.Sleep(1000);
            //}
            
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Draw();
                Thread.Sleep(1000);
                Curs();
            }
        }
    }
}