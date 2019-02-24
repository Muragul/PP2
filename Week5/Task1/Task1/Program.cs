using System;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public class ComplexNumber
    {
        public double a;
        public double b;
        public string s;

        public ComplexNumber()
        {
        }

        public ComplexNumber(double a, double b)
        {
            this.a = a;
            this.b = b;
            this.s = a.ToString() + '+' + b.ToString() + 'i';
        }

        public void PrintInfo()
        {
            Console.Write(s);
        }

    }

    class Program
    {
        public static void Ser()
        {
            ComplexNumber CN = new ComplexNumber(3.5 , 4.5);
            FileStream myFS = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task1/seria.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer XS = new XmlSerializer(typeof(ComplexNumber));
            XS.Serialize(myFS, CN);
            myFS.Close();
        }

        public static void Des()
        {
            FileStream fs = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task1/seria.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer XS = new XmlSerializer(typeof(ComplexNumber));
            ComplexNumber CN = XS.Deserialize(fs) as ComplexNumber;
            fs.Close();
            CN.PrintInfo();

        }
        static void Main(string[] args)
        {
            Ser();
            Des();
            Console.ReadKey();
        }
    }
}
