using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task2
{
    class MyThread
    {
        public Thread ThreadField;
        
        public MyThread (string s)
        {
            this.ThreadField = Thread.CurrentThread;
            for (int i = 1; i <= 4; i++)
                Console.WriteLine(i);
        }

        public void StartThread()
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyThread th1 = new MyThread("Thread 1");
            MyThread th2 = new MyThread("Thread 2");
            MyThread th3 = new MyThread("Thread 3");

            th1.StartThread();
            th2.StartThread();
            th3.StartThread();

            Console.ReadKey();
        }
    }
}
