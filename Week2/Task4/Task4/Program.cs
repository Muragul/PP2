using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamWriter textFile = new System.IO.StreamWriter("C:/Users/Асер/Desktop/PP2/Week2/Task4/path/1.txt");
            textFile.WriteLine("Hello!");
            textFile.Close();

            string m = Console.ReadLine(); 

            if (m == "copy")
            {
                string fileName = "1.txt";
                string sourcePath = "C:/Users/Асер/Desktop/PP2/Week2/Task4/path";
                string targetPath = "C:/Users/Асер/Desktop/PP2/Week2/Task4/path1";

                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (!System.IO.Directory.Exists(targetPath)) 
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }


                System.IO.File.Copy(sourceFile, destFile, true); 
            }

            string f = Console.ReadLine();

            if (f == "delete")
            {
                if (System.IO.File.Exists("C:/Users/Асер/Desktop/PP2/Week2/Task4/path/1.txt"))
                {
                    try
                    {
                        System.IO.File.Delete("C:/Users/Асер/Desktop/PP2/Week2/Task4/path/1.txt");
                    }
                    catch (System.IO.IOException e)


                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }


            }

        }
    }
}
