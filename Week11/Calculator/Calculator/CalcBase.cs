﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalcBase
    {
        public float first_number;
        public float second_number;
        public float result;
        public string operation;

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