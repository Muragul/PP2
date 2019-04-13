using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcAutomata
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
            ChangeTextDelegate CTD = new ChangeTextDelegate(CT);
            Calculator = new Calculator(CTD);
            Point location = textBox1.Location;
            int x = location.X;
            int y = location.Y;
            int sz = 65, d = 10, k = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Font = new Font("Microsoft Tai Le", 20F);
                    btn.Size = new Size(sz, sz);
                    btn.Location = new Point(j * sz + x + d, i * sz + y + d);
                    btn.Click += Btn_Clicked;
                    if (k < 10) btn.Text = k + ""; else
                    {
                        if (k == 10) btn.Text = "+";
                        if (k == 11) btn.Text = "-";
                        if (k == 12) btn.Text = "=";
                    }
                    k++;
                    Controls.Add(btn);
                }
            }
        }
                
        public void CT(string t)
        {
            textBox1.Text = t;
        }
        public void Btn_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Calculator.Process(btn.Text);
        }
    }
}
