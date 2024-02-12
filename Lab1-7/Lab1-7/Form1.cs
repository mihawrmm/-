using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Введіть рядок : ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            string output = input.Replace(":", ";");

            int replacementsCount = CountReplacements(input, output);

            MessageBox.Show($"Замінений рядок: {output}\nКількість замін: {replacementsCount}", "Результат");
        }

        private int CountReplacements(string original, string modified)
        {
            int count = 0;
            for (int i = 0; i < original.Length; i++)
            {
                if (original[i] != modified[i])
                {
                    count++;
                }
            }
            return count;
        }
    }
 }

