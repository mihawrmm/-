using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var lab = new Lab12("docddd.docx");

            var items = new Dictionary<string, string>
            {
                { "<ORG>", textBox1.Text},
                { "<FIO>", textBox2.Text},
                { "<GR>", textBox3.Text},
                { "<N1>", textBox4.Text},
                { "<N2>", textBox5.Text},
                { "<DATE>", dateTimePicker1.Value.ToString("dd.MM.yyyy")},
            };
            lab.Process(items);
        }
    }
}

