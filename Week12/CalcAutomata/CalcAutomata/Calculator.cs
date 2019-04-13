using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcAutomata
{
    enum CalcState
    {
        Zero,
        AccumulateDigit,
        Operation,
        Result
    }

    public delegate void ChangeTextDelegate(string text);

    class Calculator
    {
        public CalcState state;
        public string tempN;
        public string result;
        public string operation;
        public ChangeTextDelegate CTD;

        public Calculator (ChangeTextDelegate changeText)
        {
            this.CTD = changeText;
            this.tempN = "";
            this.result = "";
            this.operation = "";
            this.state = CalcState.Zero;
        }

        public void Process (string input)
        {
            switch (state)
            {
                case CalcState.Zero:
                    Zero(input,false);
                    break;

                case CalcState.AccumulateDigit:
                    AccumulateDigit(input, false);
                    break;

                case CalcState.Operation:
                    Operation(input, false);
                    break;

                case CalcState.Result:
                    Result(input, false);
                    break;

                default:
                    break;
            }
        }

        public void Zero(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Zero;
            }
            else
                if (Rules.IsNoneZeroDigit(msg))
                AccumulateDigit(msg, true);
        }
        public void AccumulateDigit(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.AccumulateDigit;
                tempN += msg;
                CTD.Invoke(tempN);
            }
            else
            {
                if (Rules.IsDigit(msg)) AccumulateDigit(msg, true);
                if (Rules.IsOperation(msg)) Operation(msg, true);
                if (Rules.IsEqual(msg)) Result(msg, true);
            }
        }

        public void Operation(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Operation;
                if (operation.Length > 0)
                {
                    Calculate();
                    CTD.Invoke(result);
                }
                else
                {
                    result = tempN;
                    tempN = "";
                    operation = msg;
                }
            }
        }
        public void Result(string msg, bool input)
        {
            if (input)
            {
                state = CalcState.Result;
                Calculate();
                CTD.Invoke(result);
            } else
            {
                if (Rules.IsDigit(msg)) AccumulateDigit(msg, true);
            }
        }

        public void Calculate()
        {
            if (operation == "=") result = int.Parse(result) + int.Parse(tempN) + "";
        }
    }
}
