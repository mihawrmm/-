namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            bool isValid = IsIntegerWithSign(input);
            ShowValidationResult(isValid);
        }

        private bool IsIntegerWithSign(string input)
        {
            // Перевіряємо чи є вхідний рядок пустим
            if (string.IsNullOrEmpty(input))
                return false;

            int startIndex = 0;

            // Перевіряємо перший символ на наявність знака
            if (input[0] == '+' || input[0] == '-')
            {
                // Якщо знак присутній, зсуваємо індекс початку на 1
                startIndex = 1;

                // Якщо рядок складається тільки зі знака, це не є правильним числом
                if (input.Length == 1)
                    return false;
            }

            // Перевіряємо решту символів на наявність цифр
            for (int i = startIndex; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                    return false;
            }

            return true;
        }
        private void ShowValidationResult(bool isValid)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(isValid ? "Правильне зображення цілого числа зі знаком." : "Неправильне зображення цілого числа зі знаком.");
        }
    }
}
