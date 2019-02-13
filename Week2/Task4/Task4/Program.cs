using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Create()
        {
            string Folder = "C:/Users/Асер/Desktop/PP2/Week2/Task4"; //путь: основная папка в которой работаем
            string pathString1 = Path.Combine(Folder, "path"); //путь1: первая папка находится в основной
            string pathString2 = Path.Combine(Folder, "path1"); //путь2: вторая папка находится в основной
            string FileName = "1.txt"; //имя файла с которым будем работать
            string sourcefile = Path.Combine(pathString1, FileName); //путь к файлу в первой папке
            File.Create(sourcefile);//создаем файл по заданному пути
        }

        static void Copy()
        {
            //каждая функция работает отдельно, поэтому заново инициализируем пути
            string Folder = "C:/Users/Асер/Desktop/PP2/Week2/Task4"; 
            string pathString1 = Path.Combine(Folder, "path"); 
            string pathString2 = Path.Combine(Folder, "path1");
            string FileName = "1.txt";
            string sourcefile = Path.Combine(pathString1, FileName);
            string destfile = Path.Combine(pathString2, FileName);//путь к файлу во второй папке
            //if (!File.Exists(pathString1))
                File.Copy(sourcefile, destfile, true);
            //если файл1 существует в первой папке, он скопируется во вторую
        }

        static void Delete()
        {
            string Folder = "C:/Users/Асер/Desktop/PP2/Week2/Task4"; 
            string pathString1 = Path.Combine(Folder, "path"); 
            string pathString2 = Path.Combine(Folder, "path1");
            string FileName = "1.txt";
            string sourcefile = Path.Combine(pathString1, FileName);
            string destfile = Path.Combine(pathString2, FileName);
            File.Delete(sourcefile);
            //если файл1 существует в папке1, он удалится
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose function:");
            Console.WriteLine("create");
            Console.WriteLine("copy");
            Console.WriteLine("delete");

            string CK = Console.ReadLine();//считываем команду с консоли
            //и вызываем необходимую функцию:
            if (CK == "create") Create();//создание
            if (CK == "copy") Copy();//копирование
            if (CK == "delete") Delete();//удаление
        }
    }
}
