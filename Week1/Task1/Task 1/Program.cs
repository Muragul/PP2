﻿using System;

namespace Task_1
{
    class Program
    {
        static bool Prime(int a) //создаем функцию, проверяющую простое ли число
        {
            int cnt = 0; //добавляем счетчик делителей
            for (int i = 2; i <= a; i++) //проверяем все числа от 2 до данного числа
                if (a % i == 0) cnt++; //считаем кол-во делителей
            if (cnt == 1) return true; //помимо единицы должен быть только один делитель - само число
            return false; //если больше одного делителя - число не простое
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //считываем размерность массива
            string s1 = Console.ReadLine(); //элементы массива считаем как строку
            string[] arr = s1.Split(); //разделим строку на отдельные числа, только строкового типа
            int cntp = 0; //счетчик простых чисел
            for (int i = 0; i < n; i++) //проверяем каждое число массива
            {
                if (Prime(int.Parse(arr[i]))) //так как числа строкового типа, перед вызовом функции переводим в целочисленный тип
                 cntp++; //если условие истинно, счетчик увеличивается на единицу
            }
            //когда мы посчитали количество простых чисел, мы знаем размерность нового массива - массива простых чисел

            string[] b = new string[cntp]; //отдельный массив строк для простых чисел
            int j = 0; //номера элементов нового массива
            for (int i = 0; i < n; i++) //снова проверяем все числа данного массива                                 
            {
                if (Prime(int.Parse(arr[i]))) //теперь, если число простое, оно становится элементом нового массива
                {
                    b[j] = arr[i]; j++; //и j теперь - номер следующего элемента
                }
            }
            Console.WriteLine(b.Length);//выводим размерность нового массива - это и будет количество простых чисел (используем WriteLine
                                        //чтобы после перейти на новую строку)
            for(int i = 0; i <j; i++) //проходимся по массиву простых чисел
            {
                Console.Write(b[i]);//в строчку (поэтому Write) выводим элементы нового массива
                Console.Write(" "); //через пробел
            }
            Console.ReadKey();//функция, необходимая чтобы консоль ждала нажатия клавиши пользователем, а не сразу закрывалась
        }
    }
}
