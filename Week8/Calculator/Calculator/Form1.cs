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
        public int b, k;
        public double res;

        public Form1()
        {
            InitializeComponent();
        }
        public int ReadN(TextBox t)
        {
            int a = int.Parse(t.Text);
            return a;
        }
        public double Result(double a, int b, int k)
        {
            if (k == 1) return a + b;
            else
            if (k == 2) return a - b;
            else
            if (k == 3) return a * b;
            else
            if (k == 4) return a / b;
            else
                return 000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += button1.Text;
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += button3.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += button6.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += button5.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += button4.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += button9.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            b = ReadN(textBox1);
            res = Result(res, b, k);
            label1.Text = res.ToString();
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            res = ReadN(textBox1);
            textBox1.Text = "";
            k = 2;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            res = ReadN(textBox1);
            textBox1.Text = "";
            k = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            res = ReadN(textBox1);
            textBox1.Text = "";
            k = 4;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            res = ReadN(textBox1);
            textBox1.Text = "";
            k = 1;
        }
    }
}
