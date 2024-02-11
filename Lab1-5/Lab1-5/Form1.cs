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

namespace Lab1_5
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n = Convert.ToInt32(textBox1.Text);
            int count = CountNumbers(n);
            MessageBox.Show($"Кількість чисел, що задовольняють умову: {count}", "Результат");
        }
       

        private int CountNumbers(double n)
        {
    int count = 0;

    for (int i = 1; i <= n; i++)
        {
        if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
        {
            count++;
        }
        }   

    return count;
    }
   }
  }
