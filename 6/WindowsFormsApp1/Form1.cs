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
            Line line1, line2;
            line1.A = double.Parse(textBox1.Text);
            line1.B = double.Parse(textBox2.Text);
            line1.C = double.Parse(textBox3.Text);

            line2.A = double.Parse(textBox4.Text);
            line2.B = double.Parse(textBox5.Text);
            line2.C = double.Parse(textBox6.Text);

            bool intersect = IntersectingLines(line1, line2);

            if (intersect)
                richTextBox1.Text = "Прямі не паралельні та перетинаються.";
            else
                richTextBox1.Text = "Прямі паралельні або збігаються.";
        }
        private bool IntersectingLines(Line line1, Line line2)
        {
            double d = line1.A * line2.B - line2.A * line1.B;
            return d != 0;
        }
    }
}
