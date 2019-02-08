using System;
using System.IO;

namespace Task1
{
    class Program
    {
        public static bool Palindrome(string s)
        {
            for (int i = 0; i < s.Length/ 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }return true;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:/Users/Асер/Desktop/PP2/Week2/Task1/input.txt");
            string s = sr.ReadToEnd();
            sr.Close();
            StreamWriter wr = new StreamWriter("C:/Users/Асер/Desktop/PP2/Week2/Task1/output.txt");
            if (Palindrome(s))
            {
                wr.Write("Yes");
            } else
            {
                wr.Write("No");
            }
            wr.Close();
            Console.ReadKey();
        }
    }
}
