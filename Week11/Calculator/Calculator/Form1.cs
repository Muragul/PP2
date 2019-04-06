using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        CalcBase calc;
        public Form1()
        {
            InitializeComponent();
            calc = new CalcBase();
        }
        
        private void number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            display.Text += btn.Text;

        }
        private void operation_Click(object sender, EventArgs e)
        {
            calc.first_number = float.Parse(display.Text);
            Button btn = (Button)sender;
            calc.operation = btn.Text;
            display.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            calc.second_number = float.Parse(display.Text);
            calc.Calculate();
            display.Text = calc.result + "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            calc = new CalcBase();
            display.Text = "0";
        }
    }
}
