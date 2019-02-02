 using System;
using System.IO;

namespace Task3
{
    class Program
    {
        public static void PrintSpaces(int level)
        {
            for (int i = 0; i < level; i++)
                Console.Write("     ");
        }

        public static void Ex5(DirectoryInfo dir, int level)
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                PrintSpaces(level);
                Console.WriteLine(f.Name);
            }
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                PrintSpaces(level);
                Console.WriteLine(d.Name);
                Ex5(d, level + 1);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/Асер/Desktop/PP2/Week1");
            Ex5(dir, 0);
            Console.ReadKey();
        }
    }
}
