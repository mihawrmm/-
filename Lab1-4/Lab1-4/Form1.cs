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

namespace Lab1_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "a = ";
            label2.Text = "b = ";
            label3.Text = "c = ";
            label4.Text = "Площа = ";
            btnOK.Text = "Розрахувати";
            label5.Text = " ";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);

            bool isTriangle = IsTriangle(a, b, c);
            if (isTriangle)
            {
                double area = CalculateTriangleArea(a, b, c);
                MessageBox.Show($"Це трикутник. Його площа: {area}", "Результат");
            }
            else
            {
                MessageBox.Show("Це не трикутник.", "Результат");
            }
        }
        private bool IsTriangle(double a, double b, double c)
        {
                return a + b > c && a + c > b && b + c > a;
            }

            private double CalculateTriangleArea(double a, double b, double c)
            {
                double s = (a + b + c) / 2;
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                return area;
            }
        }
    } 