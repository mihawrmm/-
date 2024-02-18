using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int num, int den)
        {
            numerator = num;
            denominator = den != 0 ? den : 1; 
        }

        public Fraction(int num)
        {
            numerator = num;
            denominator = 1;
        }

        private void Simplify()
        {
            int gcd = GCD(numerator, denominator);
            numerator /= gcd;
            denominator /= gcd;
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.denominator + frac2.numerator * frac1.denominator;
            int den = frac1.denominator * frac2.denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator -(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.denominator - frac2.numerator * frac1.denominator;
            int den = frac1.denominator * frac2.denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator *(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.numerator;
            int den = frac1.denominator * frac2.denominator;
            return new Fraction(num, den);
        }

        public static Fraction operator /(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.denominator;
            int den = frac1.denominator * frac2.numerator;
            return new Fraction(num, den);
        }

        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = int.Parse(textBox1.Text);
            int den1 = int.Parse(textBox2.Text);
            int num2 = int.Parse(textBox3.Text);
            int den2 = int.Parse(textBox4.Text);

            Fraction frac1 = new Fraction(num1, den1);
            Fraction frac2 = new Fraction(num2, den2);
            Fraction sum = frac1 + frac2;
            Fraction difference = frac1 - frac2;
            Fraction product = frac1 * frac2;
            Fraction quotient = frac1 / frac2;

            label5.Text = $"Сума: {sum}\nРізниця: {difference}\nДобуток: {product}\nЧастка: {quotient}";
        }
    }
}
