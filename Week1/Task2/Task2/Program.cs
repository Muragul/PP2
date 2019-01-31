using System;

namespace Task2
{
    class Student
    {
        public string name;
        public string id;
        public int year;
     
        public Student(string Name, string ID, int Year)
        {
            this.name = Name;
            this.id = ID;
            this.year = Year;
            year++;
            Console.Write(name + " " + id + " " + year);
        }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            string ID = Console.ReadLine();
            int Year = int.Parse(Console.ReadLine());
            Student S = new Student(Name,ID,Year);


            Console.ReadKey();
        }

    }
}
