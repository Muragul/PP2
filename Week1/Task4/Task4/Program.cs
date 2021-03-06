﻿using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());//считываем размерность массива
            string[,] arr = new string[n,n]; //это будет двумерный массив - квадратная матрица
            //элементы выше главной диагонали будут пустыми, ниже - "[*]"
            //по умолчанию все элементы пустые
            //нам осталось поменять только те, что на ГГ и ниже
            for (int i = 0; i < n; i++)//пробегаем по строкам
            {
                for (int j = 0; j < n; j++)//и столбцам
                {
                    //формула главной диагонали i=j (индексы равны)
                    if (i >= j) arr[i, j] = "[*]";//если индексы элемента равны или
                    //номер столбца меньше номера строки, присваиваем значение "[*]"
                }
            }
                
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j]);//теперь просто выводим массив
                }
                Console.WriteLine();//разделяет строки
            }
            Console.ReadKey();//ждет нажатия клавиши пользователем

        }
    }
}
