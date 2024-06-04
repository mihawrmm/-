using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Management;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            GetAndDisplayHardwareInformation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAndDisplayHardwareInformation();
        }

        private List<string> GetHardwareInfo(string win32Class, string classItemField)
        {
            List<string> result = new List<string>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + win32Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (obj[classItemField] != null)
                    {
                        result.Add(obj[classItemField].ToString().Trim());
                    }
                    else
                    {
                        result.Add("Немає даних");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні інформації: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;

        }

        private void GetAndDisplayHardwareInformation()
        {

            ClearInformation();

            DisplayHardwareInfo("Процесор:", GetHardwareInfo("Win32_Processor", "Name"));
            DisplayHardwareInfo("Виробник:", GetHardwareInfo("Win32_Processor", "Manufacturer"));
            DisplayHardwareInfo("Опис:", GetHardwareInfo("Win32_Processor", "Description"));

            DisplayHardwareInfo("Відеокарта:", GetHardwareInfo("Win32_VideoController", "Name"));
            DisplayHardwareInfo("Видеопроцесор:", GetHardwareInfo("Win32_VideoController", "VideoProcessor"));
            DisplayHardwareInfo("Версія драйверу:", GetHardwareInfo("Win32_VideoController", "DriverVersion"));
            DisplayHardwareInfo("Об’єм пам’яти (в байтах):", GetHardwareInfo("Win32_VideoController", "AdapterRAM"));

            DisplayHardwareInfo("Назва DVD:", GetHardwareInfo("Win32_CDROMDrive", "Name"));
            DisplayHardwareInfo("Буква DVD:", GetHardwareInfo("Win32_CDROMDrive", "Drive"));

            DisplayHardwareInfo("Жорстикий диск:", GetHardwareInfo("Win32_DiskDrive", "Caption"));
            DisplayHardwareInfo("Об’єм (в байтах):", GetHardwareInfo("Win32_DiskDrive", "Size"));

            DisplayHardwareInfo("Материнська плата:", GetHardwareInfo("Win32_BaseBoard", "Product"));
            DisplayHardwareInfo("Виробник материнської плати:", GetHardwareInfo("Win32_BaseBoard", "Manufacturer"));
            DisplayHardwareInfo("Серійний номер материнської плати:", GetHardwareInfo("Win32_BaseBoard", "SerialNumber"));

            DisplayHardwareInfo("Мережева карта:", GetHardwareInfo("Win32_NetworkAdapter", "Name"));

            DisplayHardwareInfo("BIOS:", GetHardwareInfo("Win32_BIOS", "Caption"));
            DisplayHardwareInfo("Версія BIOS:", GetHardwareInfo("Win32_BIOS", "Version"));
            DisplayHardwareInfo("Виробник BIOS:", GetHardwareInfo("Win32_BIOS", "Manufacturer"));
        }

        private void DisplayHardwareInfo(string info, List<string> result)
        {

            if (!string.IsNullOrEmpty(info))
            {
                listBoxHWInfo.Items.Add(info);
            }

            if (result.Count > 0)
            {
                foreach (string item in result)
                {
                    listBoxHWInfo.Items.Add(item);
                }
            }

            listBoxHWInfo.Items.Add(Environment.NewLine);
        }

        private void ClearInformation()
        {
            listBoxHWInfo.Items.Clear();
        }
    }
}
