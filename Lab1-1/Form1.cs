using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "x = ";
            label2.Text = "y = ";
            label3.Text = "Результат";
            btnOK.Text = "Розрахувати";
            label4.Text = " ";
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(textBox2.Text);
            double result = x * Math.Log(x) + y / (Math.Cos(x) - x / 3);
            label4.Text = result.ToString();
        }
    }
}
