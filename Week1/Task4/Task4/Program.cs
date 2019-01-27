using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] arr = new string[n,n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= j) arr[i, j] = "[*]";
                }
            }
                
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
