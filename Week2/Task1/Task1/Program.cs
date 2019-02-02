using System;

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
            string s = Console.ReadLine();
            if (Palindrome(s))
            {
                Console.WriteLine("Yes");
            } else
            {
                Console.WriteLine("No");
            }
            Console.ReadKey();
        }
    }
}
