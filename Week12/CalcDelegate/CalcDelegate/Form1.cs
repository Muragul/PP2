using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Calculator Calculator; 
        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeTextDelegate CTD = new ChangeTextDelegate(ChangeTextBoxText);
            Calculator = new Calculator(CTD);
        }
        public void ChangeTextBoxText(string text)
        {
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator.a = int.Parse(textBox1.Text);
            Calculator.b = int.Parse(textBox2.Text);
            Calculator.Calc();
        }
    }
}
