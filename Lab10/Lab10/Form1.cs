using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab10
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource1 = new CancellationTokenSource();
        private CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();
        private CancellationTokenSource cancellationTokenSource3 = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource1 = new CancellationTokenSource();
            cancellationTokenSource2 = new CancellationTokenSource();
            cancellationTokenSource3 = new CancellationTokenSource();

            await Task.Run(() => Method1(cancellationTokenSource1.Token));
            await Task.Run(() => Method2(cancellationTokenSource2.Token));
            await Task.Run(() => Method3(cancellationTokenSource3.Token));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancellationTokenSource1?.Cancel();
            cancellationTokenSource2?.Cancel();
            cancellationTokenSource3?.Cancel();
        }

        private void Method1(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Виконати блоковий алгоритм шифрування BLOWFISH
                    using (var algorithm = new Blowfish())
                    {
                        // Ваш код для використання BLOWFISH
                        // Наприклад, шифрування тексту "Hello, World!"
                        string plainText = "Hello, World!";
                        byte[] key = Encoding.UTF8.GetBytes("secretkey"); // Ключ для шифрування
                        byte[] iv = Encoding.UTF8.GetBytes("initialiv"); // Вектор ініціалізації
                        byte[] encryptedBytes = algorithm.Encrypt_CBC(Encoding.UTF8.GetBytes(plainText), key, iv);

                        // Розшифрування зашифрованих даних
                        byte[] decryptedBytes = algorithm.Decrypt_CBC(encryptedBytes, key, iv);
                        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

                        MessageBox.Show($"Encrypted text: {Convert.ToBase64String(encryptedBytes)}\nDecrypted text: {decryptedText}");
                    }
                    Thread.Sleep(1000); // Пауза для демонстрації
                }
            }
            catch (OperationCanceledException)
            {
                // Обробка скасування операції
            }
        }

        private void Method2(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Виконати алгоритм хешування MD-5
                    using (MD5 md5 = MD5.Create())
                    {
                        // Ваш код для використання MD5
                        // Наприклад, хешування тексту "Hello, World!"
                        string plainText = "Hello, World!";
                        byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(plainText));

                        // Перетворення байтів хешу в рядок шістнадцяткового формату
                        StringBuilder builder = new StringBuilder();
                        foreach (byte b in hashBytes)
                        {
                            builder.Append(b.ToString("x2"));
                        }
                        string hashString = builder.ToString();

                        MessageBox.Show($"MD5 hash of '{plainText}': {hashString}");
                    }
                    Thread.Sleep(1000); // Пауза для демонстрації
                }
            }
            catch (OperationCanceledException)
            {
                // Обробка скасування операції
            }
        }

        private void Method3(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Виконати інші алгоритми шифрування та генерації випадкових чисел (WAKE)
                    using (var algorithm = new Wake())
                    {
                        // Ваш код для використання WAKE
                        // Наприклад, генерація випадкового числа
                        Random random = new Random();
                        int randomNumber = random.Next();

                        MessageBox.Show($"Random number generated: {randomNumber}");
                    }
                    Thread.Sleep(1000); // Пауза для демонстрації
                }
            }
            catch (OperationCanceledException)
            {
                // Обробка скасування операції
            }
        }
    }
}