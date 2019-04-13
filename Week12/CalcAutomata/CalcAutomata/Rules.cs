using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcAutomata
{
    class Rules
    {
        public static bool IsDigit(string t)
        {
            string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (digits.Contains(t)) return true;
            return false;
        }

        public static bool IsNoneZeroDigit(string t)
        {
            string[] digits = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            if (digits.Contains(t)) return true;
            return false;
        }

        public static bool IsOperation(string t)
        {
            string[] operations = new string[] { "+", "-", "*", "/" };
            if (operations.Contains(t)) return true;
            return false;
        }

        public static bool IsEqual(string t)
        {
            if (t == "=") return true;
            return false;
        }
    }
}
