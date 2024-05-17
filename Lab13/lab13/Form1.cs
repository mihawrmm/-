using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using System.Security.Principal;

namespace lab13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            // Отримання списку доступних дисків
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Додавання дисків до ListBox
            foreach (DriveInfo drive in drives)
            {
                listBox1.Items.Add(drive.Name);
            }
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Перевіряємо, чи натиснута клавіша Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                string path = textBox1.Text;

                if (Directory.Exists(path))
                {
                    listBox2.Items.Clear();

                    string[] directories = Directory.GetDirectories(path);
                    foreach (string directory in directories)
                    {
                        listBox2.Items.Add(directory);
                    }

                    string[] files = Directory.GetFiles(path);
                    foreach (string file in files)
                    {
                        listBox2.Items.Add(file);
                    }
                }
                else
                {
                    MessageBox.Show("Шлях не існує");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPath = textBox1.Text;
            string parentPath = Path.GetDirectoryName(currentPath);

            if (!string.IsNullOrEmpty(parentPath))
            {
                textBox1.Text = parentPath;

                listBox2.Items.Clear();

                string[] directories = Directory.GetDirectories(parentPath);
                foreach (string directory in directories)
                {
                    listBox2.Items.Add(directory);
                }

                string[] files = Directory.GetFiles(parentPath);
                foreach (string file in files)
                {
                    listBox2.Items.Add(file);
                }
            }
            else
            {
                MessageBox.Show("Це кореневий каталог");
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox2.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string selectedItem = listBox2.Items[index].ToString();

                if (Directory.Exists(selectedItem))
                {
                    textBox1.Text = selectedItem;
                    listBox2.Items.Clear();

                    string[] directories = Directory.GetDirectories(selectedItem);
                    foreach (string directory in directories)
                    {
                        listBox2.Items.Add(directory);
                    }

                    string[] files = Directory.GetFiles(selectedItem);
                    foreach (string file in files)
                    {
                        listBox2.Items.Add(file);
                    }
                }
            }
        }

        private void listBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            int index = listBox1.IndexFromPoint(listBox1.PointToClient(MousePosition));
            if (index != ListBox.NoMatches)
            {
                // Очистити listBox3 перед виведенням властивостей нового вибраного диску
                listBox3.Items.Clear();

                // Отримати список доступних дисків
                DriveInfo[] drives = DriveInfo.GetDrives();

                // Отримати вибраний диск
                DriveInfo selectedDrive = drives[index];

                // Вивести властивості в listBox3
                listBox3.Items.Add($"Назва: {selectedDrive.Name}");
                listBox3.Items.Add($"Тип: {selectedDrive.DriveType}");

                if (selectedDrive.IsReady)
                {
                    double totalSize = selectedDrive.TotalSize;
                    double totalFreeSpace = selectedDrive.TotalFreeSpace;

                    listBox3.Items.Add($"Об’єм диску: {Math.Round(totalSize / (1024 * 1024 * 1024), 2)} Гб");
                    listBox3.Items.Add($"Вільний простір: {Math.Round(totalFreeSpace / (1024 * 1024 * 1024), 2)} Гб");
                    listBox3.Items.Add($"Мітка диску: {selectedDrive.VolumeLabel}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                // Очистити listBox3 перед виведенням властивостей нового вибраного каталогу
                listBox4.Items.Clear();

                // Отримати вибраний каталог
                string selectedDirectory = listBox2.SelectedItem.ToString();

                // Отримати інформацію про каталог
                DirectoryInfo directoryInfo = new DirectoryInfo(selectedDirectory);

                // Вивести властивості в listBox3
                listBox4.Items.Add($"Назва каталогу: {directoryInfo.Name}");
                listBox4.Items.Add($"Повний шлях: {directoryInfo.FullName}");
                listBox4.Items.Add($"Дата створення: {directoryInfo.CreationTime}");
                listBox4.Items.Add($"Остання модифікація: {directoryInfo.LastWriteTime}");

                // Отримати список файлів у каталозі
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    listBox4.Items.Add($"Файл: {file.Name}");
                }

                // Отримати список підкаталогів у каталозі
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo subdirectory in directories)
                {
                    listBox4.Items.Add($"Підкаталог: {subdirectory.Name}");
                }
            }
            else
            {
                MessageBox.Show("Виберіть каталог зі списку.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                listBox4.Items.Clear();

                string selectedFile = listBox2.SelectedItem.ToString();

                FileInfo fileInfo = new FileInfo(selectedFile);

                listBox4.Items.Clear();
                listBox4.Items.Add($"Назва файлу: {fileInfo.Name}");
                listBox4.Items.Add($"Повний шлях: {fileInfo.FullName}");
                listBox4.Items.Add($"Розмір: {fileInfo.Length} байт");
                listBox4.Items.Add($"Дата створення: {fileInfo.CreationTime}");
                listBox4.Items.Add($"Остання модифікація: {fileInfo.LastWriteTime}");
            }
            else
            {
                MessageBox.Show("Виберіть файл зі списку.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                // Очистити listBox3 перед виведенням властивостей нового вибраного каталогу
                listBox5.Items.Clear();

                string selectedDirectory = listBox2.Items[selectedIndex].ToString();

                // Отримати інформацію про каталог
                DirectoryInfo directoryInfo = new DirectoryInfo(selectedDirectory);

                string pattern = textBox2.Text; // Отримуємо шаблон рядка з TextBox

                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();

                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    if (Regex.IsMatch(subDirectory.Name, pattern))
                    {
                        listBox5.Items.Add(subDirectory.FullName); // Додаємо елементи в ListBox
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                // Очистити listBox3 перед виведенням властивостей нового вибраного каталогу
                listBox5.Items.Clear();

                string selectedDirectory = listBox2.Items[selectedIndex].ToString();

                // Отримати інформацію про каталог
                DirectoryInfo directoryInfo = new DirectoryInfo(selectedDirectory);

                string pattern = textBox2.Text; // Отримуємо шаблон рядка з TextBox

                FileInfo[] files = directoryInfo.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (Regex.IsMatch(file.Name, pattern))
                    {
                        listBox5.Items.Add(file.FullName); // Додаємо елементи в ListBox
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;

            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                string selectedFile = listBox2.Items[selectedIndex].ToString();

                // Перевіряємо, чи вибраний файл є графічним файлом
                if (IsImageFile(selectedFile))
                {
                    // Завантажуємо зображення з файлу і відображаємо його в pictureBox
                    Image image = Image.FromFile(selectedFile);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("Даний файл не є зображенням");
                }
            }
        }

        private bool IsImageFile(string fileName)
        {
            // Перевіряємо розширення файлу, щоб визначити, чи є він графічним файлом
            string extension = System.IO.Path.GetExtension(fileName).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif" || extension == ".bmp";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();

            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                string selectedFile = listBox2.Items[selectedIndex].ToString();

                // Перевіряємо, чи вибраний файл є графічним файлом
                if (IsTextFile(selectedFile))
                {
                    string fileContent = File.ReadAllText(selectedFile);
                    listBox6.Items.Add(fileContent);
                }
                else
                {
                    MessageBox.Show("Даний файл не є зображенням");
                }
            }
        }

        private bool IsTextFile(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return extension == ".txt" || extension == ".log" || extension == ".csv" || extension == ".xml" || extension == ".json";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                string selectedPath = listBox2.SelectedItem.ToString();

                // Отримуємо атрибути безпеки для вказаного шляху
                FileSecurity fileSecurity = File.GetAccessControl(selectedPath);
                AuthorizationRuleCollection accessRules = fileSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

                // Очищаємо список і додаємо кожен результат окремим елементом
                foreach (var rule in accessRules)
                {
                    listBox7.Items.Add(rule.ToString());
                }
            }
        }
    }
}