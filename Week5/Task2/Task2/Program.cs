using System;
using System.IO;//provides access to files and directories
using System.Xml.Serialization;//possibility of (de)serialization
using System.Collections.Generic;//opportunity of using list

namespace Task2
{
    public class Mark //create new class with two equivalent parameters
    {
        public string points;//number of points (data type is string in order to easily use it later in methods)
        public string s; //letter equivalent of this points

        public Mark(){}//empty constructor

        public static string GetLetter(string points)//method convertes points to their letter equivalent
        {
            string s;
            int point = int.Parse(points);//turn it to integer for comparison
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
            else s = "F"; //using criteria for evaluation
            return s;//return letter grade
        }

        public Mark(string points)//constructor attaches parameters of instance with its values
        {
            this.points = points;
            this.s = GetLetter(points);//determine letter grade
        }

        public override string ToString()//redefine base class functions
        {
            return points + " "+ s;//return two linked equivalent marks
        }
    }

    class Program
    {
        public static void Ser()//method of serialization
        {
            List<Mark> Marks = new List<Mark>(); //create list of marks
            Mark mark1 = new Mark(Console.ReadLine());//user enters values
            Mark mark2 = new Mark(Console.ReadLine());
            Mark mark3 = new Mark(Console.ReadLine());
            //we previously determined points as 'string', and thereby now we do not need to turn it from 'integer'
            //simply read from console
            Marks.Add(mark1);//we add them to list
            Marks.Add(mark2);
            Marks.Add(mark3);

            XmlSerializer XS = new XmlSerializer(typeof(List<Mark>));//create serializer of list type
            FileStream FS = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task2/seria.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //create stream to write/rewrite data into file
            XS.Serialize(FS, Marks);//serialize
            FS.Close();//close stream in order to save changes
        }

        public static void Des()//method of deserialization
        {
            XmlSerializer XS = new XmlSerializer(typeof(List<Mark>));//create
            FileStream FS = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task2/seria.xml", FileMode.Open, FileAccess.Read);
            //open stream which read data from file
            List<Mark> Marks = XS.Deserialize(FS) as List<Mark>;//deserialize as required
            FS.Close();//finally close stream to save changes
            foreach (Mark m in Marks)
            {
                Console.Write(m.ToString());
                Console.WriteLine();
            }//we display each mark which we readed in order to check validity of code
            Console.ReadKey();//waiting for keypress
        }

        static void Main(string[] args)
        {
            //call necessary methods
            Ser();
            Des();
        }
    }
}
