﻿using System;

namespace Task3
{
    class Program
    {
        static void Method(int[] arr) //входной параметр это массив элементов целочисленного типа
        {
            int[] array = new int[arr.Length * 2]; //нам нужно продублировать каждый элемент исходного массива,
            //поэтому у конечного массива будет размерность бОльшая в 2 раза
            int j = 0; //индексы элементов нового массива
            for (int i = 0; i < arr.Length; i++) //каждый элемент исходного массива
            {
                array[j] = arr[i]; //записываем дважды
                array[j + 1] = arr[i]; //в 2 соседних элемента
                j += 2; //индекс нового массива увеличивается в 2 раза быстрее, ведь и элементов больше
            }
            for ( int i = 0; i < array.Length; i++) //массив готов, поэтому каждый его элемент
            {
                Console.Write(array[i]); //выводим в строчку
                Console.Write(" "); //через пробел
            }

        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //пользователь вводит размерность массива
            string s = Console.ReadLine(); //считываем элементы массива как строку
            string[] b = s.Split(); //создаем массив из элементов строкового типа
            int[] arr = new int[n]; //создаем новый массив для элементов целочисленного типа, размерность 
            //совпадает с массивом b, так как мы просто ходим изменить тип данных, для дальнейшего использования метода
            for (int i = 0; i < n; i++) //каждый элемент первого массива
            {
                arr[i] = int.Parse(b[i]); //переводим в целочисленный тип и записываем во второй массив
            }
            Method(arr); //вызываем метод для массива ЧИСЕЛ
            Console.ReadKey(); //консоль будет ждать нажатия пользователем клавиши
        }
    }
}
