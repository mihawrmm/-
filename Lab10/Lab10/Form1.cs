using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            thread1 = new Thread(new ThreadStart(draw_rect));
            thread2 = new Thread(new ThreadStart(draw_eclips));
            thread3 = new Thread(new ThreadStart(Rnd_num));
        }

        Thread thread1;
        Thread thread2;
        Thread thread3;

        private void draw_rect()
        {
            try
            {
                Random rnd = new Random();
                Graphics g = panel1.CreateGraphics();
                while (true)
                {
                    Thread.Sleep(40);
                    g.DrawRectangle(Pens.Pink, 0, 0, rnd.Next(panel1.Width), rnd.Next(panel1.Height));
                }
            }
            catch (Exception ex) { }
        }

        private void draw_eclips()
        {
            try
            {
                Random rnd = new Random();
                Graphics g = panel2.CreateGraphics();
                while (true)
                {
                    Thread.Sleep(40);
                    g.DrawEllipse(Pens.Pink, 0, 0, rnd.Next(panel2.Width), rnd.Next(panel2.Height));
                }
            }
            catch (Exception ex) { }
        }

        private void Rnd_num()
        {
            try
            {
                Random rnd = new Random();
                Parallel.For(0, 500, i => {
                    richTextBox1.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox1.Text += rnd.Next().ToString() + " ";
                    });
                });
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonStartAll_Click(object sender, EventArgs e)
        {
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private void buttonStart1_Click(object sender, EventArgs e)
        {
            thread1.Start();
        }

        private void buttonStart2_Click(object sender, EventArgs e)
        {
            thread2.Start();
        }

        private void buttonStart3_Click(object sender, EventArgs e)
        {
            thread3.Start();
        }

        private void buttonStop1_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
        }

        private void buttonStop2_Click(object sender, EventArgs e)
        {
            thread2.Suspend();
        }

        private void buttonStop3_Click(object sender, EventArgs e)
        {
            thread3.Suspend();
        }

        private void buttonStopAll_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
            thread2.Suspend();
            thread3.Suspend();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();
        }
    }
}
