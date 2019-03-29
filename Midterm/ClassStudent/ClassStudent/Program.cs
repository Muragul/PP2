using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ClassStudent
{
    [Serializable]
    public class Student
    {
        public string name;
        public string age;
        public Marks mark;

        public Student() { }
        public Student(string name, string age, Marks mark)
        {
            this.name = name;
            this.age = age;
            this.mark = mark;
        }
        public override string ToString()
        {
            return name + ' ' + age + ' ' + MARK();
        }
        public string MARK()
        {
            return mark.ToString();
        }
    }
    [Serializable]
    public class Marks
    {
        public string Points;
        public string Letters;
        public Marks() { }
        public Marks (string Points)
        {
            this.Points = Points;
        }
        public void ToLetter()
        {
            if (int.Parse(Points) <= 100 && int.Parse(Points) >= 95) this.Letters = "A";
            else if (int.Parse(Points) < 95 && int.Parse(Points) >= 90) this.Letters = "A-";
            else if (int.Parse(Points) < 90 && int.Parse(Points) >= 85) this.Letters = "B";
            else if (int.Parse(Points) < 85 && int.Parse(Points) >= 80) this.Letters = "B-";
            else if (int.Parse(Points) < 80 && int.Parse(Points) >= 75) this.Letters = "C";
            else if (int.Parse(Points) < 75 && int.Parse(Points) >= 70) this.Letters = "C-";
            else if (int.Parse(Points) < 70 && int.Parse(Points) >= 65) this.Letters = "D";
            else if (int.Parse(Points) < 65 && int.Parse(Points) >= 60) this.Letters = "D-";
            else if (int.Parse(Points) < 60 && int.Parse(Points) >= 55) this.Letters = "E";
            else if (int.Parse(Points) < 55 && int.Parse(Points) >= 50) this.Letters = "E-";
            else this.Letters = "F";
        }
        public override string ToString()
        {
            return Points + " " + Letters;
        }
    }
    class Program
    {
        public static void Ser()
        {
            List<Student> Journal = new List<Student>();
            Marks m1 = new Marks("100");
            Marks m2 = new Marks("70");
            Marks m3 = new Marks("50");
            m1.ToLetter();
            m2.ToLetter();
            m3.ToLetter();
            Student s1 = new Student("ABC", "10", m1);
            Student s2 = new Student("DEF", "20", m2);
            Student s3 = new Student("HIG", "30", m3);

            Journal.Add(s1);
            Journal.Add(s2);
            Journal.Add(s3);

            XmlSerializer XS = new XmlSerializer(typeof(List<Student>));
            FileStream FS = new FileStream("C:/Users/Асер/Desktop/PP2/Midterm/1.xml", FileMode.Create, FileAccess.Write);
            XS.Serialize(FS, Journal);
            FS.Close();
        }

        public static void Des()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream("C:/Users/Асер/Desktop/PP2/Midterm/1.xml", FileMode.Open, FileAccess.Read);
            List<Student> Journal = xs.Deserialize(fs) as List<Student>;
            fs.Close();
            foreach (Student s in Journal)
            {
                Console.Write(s.ToString());
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //Ser();
            Des();
            //List<Student> Journal = new List<Student>();
            //Marks m1 = new Marks("100");
            //Marks m2 = new Marks("70");
            //Marks m3 = new Marks("50");
            //m1.ToLetter();
            //m2.ToLetter();
            //m3.ToLetter();
            //Student s1 = new Student("ABC", "10", m1);
            //Student s2 = new Student("DEF", "20", m2);
            //Student s3 = new Student("HIG", "30", m3);

            //Journal.Add(s1);
            //Journal.Add(s2);
            //Journal.Add(s3);

            //Console.Write(s1.ToString());
            Console.ReadKey();

            
        }
    }
}