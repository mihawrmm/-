namespace Lab9
{
    public partial class Form1 : Form
    {
        private double r, h;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(rTextBox.Text, out r) || !double.TryParse(hTextBox.Text, out h))
    {
        MessageBox.Show("Введіть коректні значення для параметрів r і h.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }

    graphPictureBox.Image = new Bitmap(graphPictureBox.Width, graphPictureBox.Height);

    using (Graphics g = Graphics.FromImage(graphPictureBox.Image))
    {
        double tMin = -10;
        double tMax = 10;
        double dt = 0.01;

        Pen pen = new Pen(Color.Blue);
        for (double t = tMin; t <= tMax; t += dt)
        {
            double x = r * t - h * Math.Sin(t);
            double y = r - h * Math.Cos(t);
            float screenX = (float)(graphPictureBox.Width / 2 + x * 10);
            float screenY = (float)(graphPictureBox.Height / 2 - y * 10);
            g.DrawRectangle(pen, screenX, screenY, 1, 1);
        }
    }

    graphPictureBox.Invalidate();
        }
    }
}
