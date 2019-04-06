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
            if (btn.Text == ",") button26.Enabled = false;

        }
        private void operation_Click(object sender, EventArgs e)
        {
            calc.first_number = double.Parse(display.Text);
            Button btn = (Button)sender;
            calc.operation = btn.Text;
            display.Text = "";
            button26.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (calc.operation == "x^2" || calc.operation =="root" || calc.operation =="sin" || calc.operation=="cos")
                calc.MathFunc();
            else
            {
                calc.second_number = double.Parse(display.Text);
                calc.Calculate();
            }
            display.Text = calc.result + "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //calc = new CalcBase();
            calc.first_number = 0;
            calc.second_number = 0;
            display.Text = "";
            button26.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            calc.memory = double.Parse(display.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            display.Text = calc.memory + "";
        }
        
        private void memory_Click(object sender, EventArgs e)
        {
            calc.first_number = double.Parse(display.Text);
            Button btn = (Button)sender;
            calc.operation = btn.Text;
            calc.Memory();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            double a = double.Parse(display.Text);
            a *= -1;
            display.Text = a + "";
        }
    }
}
