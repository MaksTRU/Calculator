using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Calculator
{
    public partial class Form1 : Form
    {
        char decimalSeparator;
        double numOne = 0;
        double numTwo = 0;
        string operation = null;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            this.BackColor = Color.Gray;
            Display.Font = new Font("Roboto", 22f);
            Display.Text = "0";
            Display.TabStop = false;

            string buttonName = null;
            Button button = null;
            for(int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
                button.BackColor = Color.White;
                button.Font = new Font("Roboto", 22f);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(decimalSeparator))
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0" + decimalSeparator;
                }
                else
                {
                    Display.Text += decimalSeparator;
                }
            }
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1)
            {
                if ((s.Contains("-")) && (s.Length == 2) || s.Substring(s.Length - 1, 1) == decimalSeparator.ToString())
                {
                    s = "0";
                    Display.Text = s;
                    return;
                }
                s = s.Substring(0, (s.Length - 1));
            }
            else
            {
                s = "0";
            }
            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);
                number *= -1;
                Display.Text = Convert.ToString(number);
            }
            catch
            {

            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            numOne = Convert.ToDouble(Display.Text);
            Display.Text = string.Empty;
            operation = button.Text;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            numTwo = Convert.ToDouble(Display.Text);
            double result = 0;

            if(operation == "+")
            {
                result = numOne + numTwo;
            }
            if (operation == "-")
            {
                result = numOne - numTwo;
            }
            if (operation == "x")
            {
                result = numOne * numTwo;
            }
            if (operation == "/")
            {
                result = numOne / numTwo;
            }

            Display.Text = result.ToString();
        }
    }
}
