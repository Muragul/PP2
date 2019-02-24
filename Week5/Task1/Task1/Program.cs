using System;
using System.IO; //provides working with files and directories
using System.Xml.Serialization; //provides serialization and deserialization

namespace Task1
{
    public class ComplexNumber //creating new data type
    {
        public double a; //real part
        public double b; //imaginary part
        public string s; //whole expression

        public ComplexNumber()//empty constructor
        {
        }

        public ComplexNumber(double a, double b)//constructor which turns separate parts into full expression
        {
            this.a = a;
            this.b = b;
            this.s = a.ToString() + '+' + b.ToString() + 'i';
            //first of all we turn them into 'string' type, after what represent it as a complex number 
        }

        public void PrintInfo()//method which displays complex number
        {
            Console.Write(s);
        }

    }

    class Program
    {
        public static void Ser()//method of serialization
        {
            ComplexNumber CN = new ComplexNumber(3.5 , 4.5);//we use nonempty constructor
            FileStream myFS = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task1/seria.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //opening stream which open or create file, at which data will be saved
            XmlSerializer XS = new XmlSerializer(typeof(ComplexNumber));//creating serializer of necessary type
            XS.Serialize(myFS, CN);//finally serialize
            myFS.Close();//close the stream in order to save changes
        }

        public static void Des()//method of deserialization
        {
            FileStream fs = new FileStream("C:/Users/Асер/Desktop/PP2/Week5/Task1/seria.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //open stream which will read data from shown file
            XmlSerializer XS = new XmlSerializer(typeof(ComplexNumber));//creating serializer of necessary type
            ComplexNumber CN = XS.Deserialize(fs) as ComplexNumber;//deserialize stream as necessary data type
            fs.Close();//close stream in order to save changes
            CN.PrintInfo();//show read information with an eye to check validity of the function

        }
        static void Main(string[] args)
        {
            //next we call the necessary methods
            Ser();
            Des();
            Console.ReadKey();//waiting for keypress
        }
    }
}
