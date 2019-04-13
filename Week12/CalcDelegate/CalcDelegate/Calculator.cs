using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcDelegate
{
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
            ChangeText.Invoke(a+b+"");
        }
    }
}
