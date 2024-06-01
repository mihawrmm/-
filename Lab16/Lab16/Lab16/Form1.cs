using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Lab16
{
    public partial class Form1 : Form
    {
        bool alive = false; // чи буде працювати потік для приймання
        UdpClient client;
        private const int LOCALPORT = 8001; // порт для приймання повідомлень
        private int remotePort = 8001; // порт для передавання повідомлень
        const int TTL = 20;
        private string host = "235.5.5.1"; // хост для групового розсилання
        IPAddress groupAddress; // адреса для групового розсилання
        string userName; // ім’я користувача в чаті
        private string chatLogFilePath;
        private int previousServerPort = 8001;
        private string previousServerAddress = "235.5.5.1";
        public Form1()
        {
            InitializeComponent();

            loginButton.Enabled = true; // кнопка входу
            logoutButton.Enabled = false; // кнопка виходу
            sendButton.Enabled = false; // кнопка отправки
            chatTextBox.ReadOnly = true; // поле для повідомлень
            groupAddress = IPAddress.Parse(host);

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(LOCALPORT);
                //підєднання до групового розсилання
                client.JoinMulticastGroup(groupAddress, TTL);

                // задача на приймання повідомлень
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // перше повідомлення про вхід нового користувача
                string message = userName + " вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, host, remotePort);
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // метод приймання повідомлення
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // добавляем полученное сообщение в текстовое поле
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n"
                        + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName,
               messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, host, remotePort);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }
        // вихід з чату
        private void ExitChat()
        {
            string message = userName + " покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, host, remotePort);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }

        private void chatSettingsButton_Click(object sender, EventArgs e)
        {
            // Отримати значення з текстових полів
            string serverAddress = serverAddressTextBox.Text;
            int serverPort;
            if (int.TryParse(serverPortTextBox.Text, out serverPort))
            {
                // Порівняти значення з попередніми значеннями
                if (serverPort != previousServerPort || serverAddress != previousServerAddress)
                {
                    // Значення змінилися, виконати необхідні дії

                    // Оновити адресу сервера та порт
                    previousServerPort = serverPort;
                    previousServerAddress = serverAddress;

                    // Виконати інші необхідні дії, пов'язані зі зміною налаштувань чату
                }
                else
                {
                    // Значення не змінилися, не потрібно виконувати жодних дій
                }
            }
            else
            {
                MessageBox.Show("Невірний номер порту сервера.");
            }

            // Закрити діалогове вікно налаштувань чату або відповідно оновити користувацький інтерфейс
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    chatLogFilePath = saveFileDialog.FileName;

                    // Зберегти журнал чату у вибраний файл
                    SaveChatLogToFile(chatLogFilePath);

                    MessageBox.Show("Журнал чату успішно збережено.");
                }
            }
        }

        // Метод для збереження журналу чату у файл
        private void SaveChatLogToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(chatTextBox.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час збереження журналу чату: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    chatLogFilePath = saveFileDialog.FileName;

                    // Зберегти журнал чату у вибраний файл
                    SaveChatLogToFile(chatLogFilePath);

                    MessageBox.Show("Журнал чату успішно збережено.");
                }
            }
        }


    }
}
