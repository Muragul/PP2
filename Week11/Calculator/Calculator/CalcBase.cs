using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalcBase
    {
        public double first_number;
        public double second_number;
        public double result;
        public string operation;
        public double memory;
        
        public void Memory()
        {
            switch (operation)
            {
                case "M+":
                    memory += first_number;
                    break;
                case "M-":
                    memory -= first_number;
                    break;
            }
        }
        public void MathFunc()
        {
            switch (operation)
            {
                case "x^2":
                    result = first_number * first_number;
                    break;
                case "root":
                    result = Math.Sqrt(first_number);
                    break;
                case "sin":
                    double rad = first_number * Math.PI / 180;
                    result = Math.Sin(rad);
                    break;
                case "cos":
                    double RAD = first_number * Math.PI / 180;
                    result = Math.Cos(RAD);
                    break;
            }
        }
        public void Calculate()
        {
            switch (operation)
            {
                case "+":
                    result = first_number + second_number;
                    break;
                case "-":
                    result = first_number - second_number;
                    break;
                case "*":
                    result = first_number * second_number;
                    break;
                case "/":
                    result = first_number / second_number;
                    break;
            }
        }
    }

}
