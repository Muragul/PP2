using System;
using System.IO;

namespace Task3
{
    class Program
    {
        //напишем функцию, определяющую уровень
        public static void PrintSpaces(int level)//входной параметр - уровень файла/папки
        {
            for (int i = 0; i < level; i++)//столько раз введется пробел
                Console.Write("     ");
        }
        //создадим функцию для ступенчатого вывода папок и файлов
        public static void Ex5(DirectoryInfo dir, int level)//входные параметры это папка и ее уровень
        {
            //функция GetFiles() создает массив от FileInfo
            foreach (FileInfo f in dir.GetFiles())//для каждого FileInfo в этом массиве
            {
                PrintSpaces(level);//выводим необходимое количество пробелов
                Console.WriteLine(f.Name);//и название файла
            }
            //функция GetDirectories() создаст массив папок из DirectoryInfo
            foreach (DirectoryInfo d in dir.GetDirectories())//для каждой папки в этом массиве
            {
                PrintSpaces(level);//выводим соответствующее количество пробелов
                Console.WriteLine(d.Name);//название папки
                Ex5(d, level + 1);//и снова вызываем функцию от этой папки, увеличивая уровень на 1
                //рекурсия продолжается, пока не закончатся вложенные папки
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo("C:/Users/Асер/Desktop/PP2/Week1");
            //открываем директорий
            Ex5(dir, 0);//берем от него функцию; 0 это начальный уровень папки
            Console.ReadKey();//ждем ввода клавиши пользователем
        }
    }
}
