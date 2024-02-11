using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Число N : ";
            label2.Text = " ";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBox1.Text);
            bool isIncreasing = CheckIncreasingSequence(number);

            label2.Text = isIncreasing ? "true" : "false";
        }

        private bool CheckIncreasingSequence(int number)
        {
            int lastDigit = number % 10;
            number /= 10;

            while (number > 0)
            {
                int currentDigit = number % 10;
                if (currentDigit >= lastDigit)
                {
                    return false;
                }
                lastDigit = currentDigit;
                number /= 10;
            }
            return true;
        }
    }
}
