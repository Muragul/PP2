using System;

namespace Task2
{
    class Student //создадим новый тип данных
    {//добавляем параметры: имя, ID и год обучения
        public string name;
        public string id;
        public string year;

        public Student(string n, string i)//создаем конструктор
        {
            name = n;//приравнивает введенное пользователем имя экземпляру
            id = i;
            year = "1";//год обучение становится 1
        }

        public void PrintInfo()//функция вывода всех параметров
        {
            Console.WriteLine(name + " " + id + " " + year);
        }

        public void Increment()//функция увеличивает год обучения
        {//год обучения строковая переменная, поэтому сначала переводим в целочисленный тип, увеличивает
            //затем переводим обратно в строкковый тип
            year = (int.Parse(year) + 1).ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine(); //считываем имя с консоли
            string id = Console.ReadLine();//считываем ID
            Student s = new Student(name, id);//создаем экземпляр нового типа

            s.PrintInfo();//выводим информацию за 1 год
            s.Increment();//увеличится год обучения
            s.PrintInfo();//выводим информацию за следующий год
            Console.ReadKey();//ждем нажатия клавиши пользователем
        }
    }
}