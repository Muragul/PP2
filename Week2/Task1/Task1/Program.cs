using System;
using System.IO;

namespace Task1
{
    class Program
    {
        //напишем функцию, проверяющую строку на палиндром
        public static bool Palindrome(string s)//функция проверяет на истинность
            //входной параметр строкового типа
        {
            for (int i = 0; i < s.Length/ 2; i++)//первая половина символов должны совпадать
            {
                if (s[i] != s[s.Length - i - 1])//со второй половиной, считывая с конца
                {//если какой либо символ не совпадет - строка сразу не палиндром
                    return false;//вернет отрицательное значение и выйдет из функции
                }
            }return true;//если так и не найдутся различные символы,  значит выражение истинно
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:/Users/Асер/Desktop/PP2/Week2/Task1/input.txt");
            string s = sr.ReadToEnd();//считываем содержимое файла полностью
            sr.Close();//закрываем, чтобы сохранить в переменной
            StreamWriter wr = new StreamWriter("C:/Users/Асер/Desktop/PP2/Week2/Task1/output.txt");
            //если нет выходного файла, он создается автоматически
            if (Palindrome(s))//если строка палиндром
            {
                wr.Write("Yes");//в выходной файл выводим ДА
            } else
            {
                wr.Write("No");//в противном случае НЕТ
            }
            wr.Close();//закрываем выходной файл, чтобы сохранились изменения
        }
    }
}
