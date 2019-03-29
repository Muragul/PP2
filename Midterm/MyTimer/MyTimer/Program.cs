using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = n; i >=1; i--)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("TIME IS UP!!!");
            Console.ReadKey();
        }
    }
}