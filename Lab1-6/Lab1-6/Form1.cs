using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_6
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

            string[] words = input.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            string result = "Слова, які починаються і закінчуються однаковою буквою:" + Environment.NewLine;
            foreach (string word in words)
            {
                if (word.Length > 1 && Char.ToLower(word[0]) == Char.ToLower(word[word.Length - 1]))
                {
                    result += word + Environment.NewLine;
                }
            }

            MessageBox.Show(result, "Результат");
        }
    }
}
