using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public struct Line
        {
            public double A;
            public double B;
            public double C;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Line line1, line2;
                line1.A = double.Parse(textBox1.Text);
                line1.B = double.Parse(textBox2.Text);
                line1.C = double.Parse(textBox3.Text);

                line2.A = double.Parse(textBox4.Text);
                line2.B = double.Parse(textBox5.Text);
                line2.C = double.Parse(textBox6.Text);

                int result = CompareLines(line1, line2);

                switch (result)
                {
                    case 0:
                        richTextBox1.Text = "Прямі перетинаються.";
                        break;
                    case 1:
                        richTextBox1.Text = "Прямі паралельні і не збігаються.";
                        break;
                    case 2:
                        richTextBox1.Text = "Прямі збігаються.";
                        break;
                    case 3:
                        richTextBox1.Text = "Прямі співпадають.";
                        break;
                    default:
                        richTextBox1.Text = "Невідомий результат.";
                        break;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Помилка формату числа. Переконайтеся, що всі введені значення є числами.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Виникла помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CompareLines(Line line1, Line line2)
        {
            double d = line1.A * line2.B - line2.A * line1.B;
            if (d != 0)
                return 0; // Прямі перетинаються
            else if (line1.A / line2.A == line1.B / line2.B && line1.A / line2.A == line1.C / line2.C)
                return 3; // Прямі співпадають
            else if (line1.A / line2.A == line1.B / line2.B)
                return 1; // Прямі паралельні і не збігаються
            else
                return 2; // Прямі збігаються
        }
    }
}
