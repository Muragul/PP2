using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDelegateConsole
{
    class Program
    {
        public static  Calculator Calculator;
        static void Main(string[] args)
        {
            ChangeTextDelegate CTD = new ChangeTextDelegate(Result);
            Calculator = new Calculator(CTD);
            Calculator.a = int.Parse(Console.ReadLine());
            Calculator.b = int.Parse(Console.ReadLine());
            Calculator.Calc();
            Console.ReadKey();
        }
        public static void Result(string text)
        {
            Console.Write(text);
        }
    }
}

    public delegate void ChangeTextDelegate(string msg);
    class Calculator
    {
        public int a, b;
        public ChangeTextDelegate ChangeText;

        public Calculator(ChangeTextDelegate changeText)
        {
            this.ChangeText = changeText;
        }
        public void Calc()
        {
            ChangeText.Invoke(a + b + "");
        }
    }
