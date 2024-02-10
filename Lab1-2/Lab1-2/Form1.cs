using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Сторона рівностороннього трикутника : ";
            label2.Text = "Площа = ";
            label3.Text = "Висота = ";
            label4.Text = "Радіус вписаного кола = ";
            label5.Text = "Радіус описаного кола = ";
            btnOK.Text = "Розрахувати";
            label6.Text = " ";
            label7.Text = " ";
            label8.Text = " ";
            label9.Text = " ";

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);

            double square = (Math.Sqrt(3) / 4) * Math.Pow( a, 2);
            double height = (Math.Sqrt(3) / 2) * a;
            double inRadius = (a * Math.Sqrt(3)) / 6;
            double outRadius = a / Math.Sqrt(3);

            label6.Text = square.ToString();
            label7.Text = height.ToString();
            label8.Text = inRadius.ToString();
            label9.Text = outRadius.ToString();
        }
    }
}
