using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Task2
{
    public class Mark
    {
        public string points;//count of points
        public string s; //letter of points

        public Mark(){}

        public static string GetLetter(string points)
        {
            string s;
            int point = int.Parse(points);
            if (point >= 95) s = "A"; else
            if (90 <= point && point < 95) s = "A-"; else
            if (85 <= point && point < 90) s = "B+"; else
            if (80 <= point && point < 85) s = "B"; else
            if (75 <= point && point < 80) s = "B-";else
            if (70 <= point && point < 75) s = "C+";else
            if (65 <= point && point < 70) s = "C";else
            if (60 <= point && point < 65) s = "C-";else
            if (55 <= point && point < 60) s = "D+";else
            if (50 <= point && point < 55) s = "D-";else
            if (25 <= point && point < 50) s = "FX";
            else s = "F";
            return s;
        }

        public Mark(string points)
        {
            this.points = points;
            this.s = GetLetter(points);
        }

        public override string ToString()
        {
            return points + " "+ s;
        }
    }

    class Program
    {
        public static void Ser()
        {
            List<Mark> Marks = new List<Mark>();
            Mark mark1 = new Mark(Console.ReadLine());
            Mark mark2 = new Mark(Console.ReadLine());
            Mark mark3 = new Mark(Console.ReadLine());
            Marks.Add(mark1);
            Marks.Add(mark2);
            Marks.Add(mark3);

            XmlSerializer XS = new XmlSerializer(typeof(List<Mark>));
            FileStream FS = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task2/seria.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XS.Serialize(FS, Marks);
            FS.Close();
        }

        public static void Des()
        {
            XmlSerializer XS = new XmlSerializer(typeof(List<Mark>));
            FileStream FS = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task2/seria.xml", FileMode.Open, FileAccess.Read);
            List<Mark> Marks = XS.Deserialize(FS) as List<Mark>;
            FS.Close();
            foreach (Mark m in Marks)
            {
                Console.Write(m.ToString());
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Ser();
            Des();
        }
    }
}
