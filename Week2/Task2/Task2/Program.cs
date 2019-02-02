using System;
using System.IO;

namespace Task2
{
    class Program
    {
        public static bool isPrime(int x)
        {
            int cnt = 0;
            for (int i = 2; i < x; i++)
            {
                if (x % i == 0) cnt++;
            }
            if (cnt == 0) return true;
            return false;
        }

        static void Main(string[] args)
        {
            string s1 = "";
            StreamReader SR = new StreamReader("C:/Users/Асер/Desktop/PP2/Week2/Task2/input.txt");
            string [] arr = SR.ReadToEnd().Split();
            SR.Close();
            foreach (string s in arr)
            {
                if (isPrime(int.Parse(s)))
                {
                    s1 += s;
                    s1 += " ";
                }

            }
            StreamWriter SW = new StreamWriter("C:/Users/Асер/Desktop/PP2/Week2/Task2/output.txt");
            SW.Write(s1);
            SW.Close();

        }
    }
}
