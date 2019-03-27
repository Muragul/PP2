using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task1
{
    class Program
    {
        public static void Method()
        {
            for (int i = 0; i < 3; i++)
            Console.WriteLine(Thread.CurrentThread.Name);
        }

        static void Main(string[] args)
        {
            int k = 1;
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(Method);
                threads[i].Name = "THREAD" + k.ToString();
                threads[i].Start();
                k++;
            }
            Console.ReadKey();
        }
    }
}
