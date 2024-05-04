using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Text_Editor
{
    public partial class frmEditor : Form
    {
        List<string> colorList = new List<string>(); // містить імена кольорів System.Drawing.Color
        string filenamee; // файл, відкритий в RTB
        const int MIDDLE = 382; // середина суми RGB - максимальна сума 765
        int sumRGB; // сума RGB вибраних кольорів
        int pos, line, column; // для визначення номерів рядків та стовпців

        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            richTextBox1.AllowDrop = true;     // дозвіл на перетягування до RichTextBox
            richTextBox1.AcceptsTab = true;    // дозвіл на табуляцію
            richTextBox1.WordWrap = false;    // вимкнути перенесення слів на початку
            richTextBox1.ShortcutsEnabled = true;    // дозвіл на ярлики
            richTextBox1.DetectUrls = true;    // дозвіл на виявлення URL
            fontDialog1.ShowColor = true;
            fontDialog1.ShowApply = true;
            fontDialog1.ShowHelp = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.AnyColor = true;
            colorDialog1.SolidColorOnly = false;
            colorDialog1.ShowHelp = true;
            colorDialog1.AnyColor = true;
            leftAlignStripButton.Checked = true;
            centerAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            boldStripButton3.Checked = false;
            italicStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            bulletListStripButton.Checked = false;
            wordWrapToolStripMenuItem.Image = null;
            MinimizeBox = false;
            MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // заповнюємо список елементів zoomDropDownButton
            zoomDropDownButton.DropDown.Items.Add("20%");
            zoomDropDownButton.DropDown.Items.Add("50%");
            zoomDropDownButton.DropDown.Items.Add("70%");
            zoomDropDownButton.DropDown.Items.Add("100%");
            zoomDropDownButton.DropDown.Items.Add("150%");
            zoomDropDownButton.DropDown.Items.Add("200%");
            zoomDropDownButton.DropDown.Items.Add("300%");
            zoomDropDownButton.DropDown.Items.Add("400%");
            zoomDropDownButton.DropDown.Items.Add("500%");

            // заповнюємо розміри шрифту в комбінованому списку
            for (int i = 8; i < 80; i += 2)
            {
                fontSizeComboBox.Items.Add(i);
            }

            // заповнюємо кольори в списку випадаючих кольорів
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    colorList.Add(prop.Name);
                }
            }

            // заповнюємо список DropDownItems
            foreach (string color in colorList)
            {
                colorStripDropDownButton.DropDownItems.Add(color);
            }

            // Заповнює BackColor для кожного кольору у списку DropDownItems
            for (int i = 0; i < colorStripDropDownButton.DropDownItems.Count; i++)
            {
                // Створює KnownColor об'єкт
                KnownColor selectedColor;
                selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), colorList[i]); // перетворює в KnownColor
                colorStripDropDownButton.DropDownItems[i].BackColor = Color.FromKnownColor(selectedColor); // встановлює BackColor для відповідного елемента списку

                // Set the text color depending on if the barkground is darker or lighter
                // create Color object
                Color col = Color.FromName(colorList[i]);

                // Встановлює колір тексту в залежності від того, чи темніший або світліший фон
                // Створює об'єкт Color
                Color col = Color.FromName(colorList[i]);

                // 255,255,255 = Білий, 0,0,0 = Чорний
                // Максимальна сума значень RGB = 765 -> (255 + 255 + 255)
                // Середня сума значень RGB = 382 -> (765/2)
                // Колір вважається темнішим, якщо його значення RGB <= 382
                // Колір вважається світлішим, якщо його значення RGB > 382
                sumRGB = ConvertToRGB(col);    // отримує суму значень RGB для об'єкту кольору
                if (sumRGB <= MIDDLE)    // Темніший фон
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.White;    // встановлює білий текст
                }
                else if (sumRGB > MIDDLE)    // Світліший фон
                {
                    colorStripDropDownButton.DropDownItems[i].ForeColor = Color.Black;    // встановлює чорний текст
                }
            }

            // Заповнює шрифти у комбо-боксі шрифтів
            InstalledFontCollection fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                fontStripComboBox.Items.Add(family.Name);
            }

            // Визначає номери рядка та стовпця за позицією миші на richTextBox
            int pos = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(pos);
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);
            lineColumnStatusLabel.Text = "Рядок " + (line + 1) + ", Стовпець " + (column + 1);
        }

        private int ConvertToRGB(System.Drawing.Color c)
        {
            int r = c.R, // Значення компоненту RED
            g = c.G, // Значення компоненту GREEN
            b = c.B; // Значення компоненту BLUE
            int sum = 0;

            // Обчислюємо суму RGB
            sum = r + g + b;

            return sum;
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();     // обрати весь текст
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // очистит
            richTextBox1.Clear();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();     // вставити текст
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();      // сопіювати
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();     // вирізати
        }

        private void boldStripButton3_Click(object sender, EventArgs e)
        {
           
            if (boldStripButton3.Checked == false)
            {
                boldStripButton3.Checked = true; 
            }
            else if (boldStripButton3.Checked == true)
            {
                boldStripButton3.Checked = false;    
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            
            FontStyle style = richTextBox1.SelectionFont.Style;

            if (richTextBox1.SelectionFont.Bold)
            {
                style &= ~FontStyle.Bold; 
            }
            else
            {
                style |= FontStyle.Bold;

            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);     // sets the font style
        }

        private void underlineStripButton_Click(object sender, EventArgs e)
        {
            if (underlineStripButton.Checked == false)
            {
                underlineStripButton.Checked = true;     
            }
            else if (underlineStripButton.Checked == true)
            {
                underlineStripButton.Checked = false;    
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }

            
            FontStyle style = richTextBox1.SelectionFont.Style;

            
            if (richTextBox1.SelectionFont.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);    
        }

        private void italicStripButton_Click(object sender, EventArgs e)
        {
            if (italicStripButton.Checked == false)
            {
                italicStripButton.Checked = true;    
            }
            else if (italicStripButton.Checked == true)
            {
                italicStripButton.Checked = false;   
            }

            if (richTextBox1.SelectionFont == null)
            {
                return;
            }
            
            FontStyle style = richTextBox1.SelectionFont.Style;

            
            if (richTextBox1.SelectionFont.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;
            }
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);   
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                return;
            }
            
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily,Convert.ToInt32(fontSizeComboBox.Text),richTextBox1.SelectionFont.Style);
        }

        private void fontStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont == null)
            {
                
                richTextBox1.SelectionFont = new Font(fontStripComboBox.Text, richTextBox1.Font.Size);
            }
            
            richTextBox1.SelectionFont = new Font(fontStripComboBox.Text, richTextBox1.SelectionFont.Size);
        }

        private void saveStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog();    
                string file;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;
                    
                    richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    file = Path.GetFileName(filename);    
                    MessageBox.Show("Файл " + file + " було успішно збережено.", "Збереження успішне.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openFileStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();     
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filenamee = openFileDialog1.FileName;
                
                richTextBox1.LoadFile(filenamee, RichTextBoxStreamType.PlainText);    
                    
            }
        }

        private void colorStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            KnownColor selectedColor;
            selectedColor = (KnownColor)System.Enum.Parse(typeof(KnownColor), e.ClickedItem.Text);    
            richTextBox1.SelectionColor = Color.FromKnownColor(selectedColor);   
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (richTextBox1.SelectionFont != null)
            {
                boldStripButton3.Checked = richTextBox1.SelectionFont.Bold;
                italicStripButton.Checked = richTextBox1.SelectionFont.Italic;
                underlineStripButton.Checked = richTextBox1.SelectionFont.Underline;
            }
        }

        private void leftAlignStripButton_Click(object sender, EventArgs e)
        {
            
            centerAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            if(leftAlignStripButton.Checked == false)
            {
                leftAlignStripButton.Checked = true;    
            }
            else if(leftAlignStripButton.Checked == true)
            {
                leftAlignStripButton.Checked = false;    
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;    
        }

        private void centerAlignStripButton_Click(object sender, EventArgs e)
        {
            
            leftAlignStripButton.Checked = false;
            rightAlignStripButton.Checked = false;
            if (centerAlignStripButton.Checked == false)
            {
                centerAlignStripButton.Checked = true;    
            }
            else if (centerAlignStripButton.Checked == true)
            {
                centerAlignStripButton.Checked = false;    
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;     
        }

        private void rightAlignStripButton_Click(object sender, EventArgs e)
        {
            
            leftAlignStripButton.Checked = false;
            centerAlignStripButton.Checked = false;

            if (rightAlignStripButton.Checked == false)
            {
                rightAlignStripButton.Checked = true;    
            }
            else if (rightAlignStripButton.Checked == true)
            {
                rightAlignStripButton.Checked = false;    
            }
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;    
        }

        private void bulletListStripButton_Click(object sender, EventArgs e)
        {
            if (bulletListStripButton.Checked == false)
            {
                bulletListStripButton.Checked = true;
                richTextBox1.SelectionBullet = true;    
            }
            else if (bulletListStripButton.Checked == true)
            {
                bulletListStripButton.Checked = false;
                richTextBox1.SelectionBullet = false;    
            }
        }

        private void increaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSizeComboBox.Text;           
            try
            {
                int size = Convert.ToInt32(fontSizeNum) + 1;    
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily,size,richTextBox1.SelectionFont.Style);
                fontSizeComboBox.Text = size.ToString();    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void decreaseStripButton_Click(object sender, EventArgs e)
        {
            string fontSizeNum = fontSizeComboBox.Text;           
            try
            {
                int size = Convert.ToInt32(fontSizeNum) - 1;    
                if (richTextBox1.SelectionFont == null)
                {
                    return;
                }
                // sets the updated font size
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily,size,richTextBox1.SelectionFont.Style);
                fontSizeComboBox.Text = size.ToString();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void richTextBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;    
            else
                e.Effect = DragDropEffects.None;    
        }

        private void richTextBox1_DragDrop(object sender,System.Windows.Forms.DragEventArgs e)
        {
            
            int i;
            String s;


            i = richTextBox1.SelectionStart;
            s = richTextBox1.Text.Substring(i);
            richTextBox1.Text = richTextBox1.Text.Substring(0, i);

            
            richTextBox1.Text += e.Data.GetData(DataFormats.Text).ToString();
            richTextBox1.Text += s;
        }

        private void undoStripButton_Click(object sender, EventArgs e)
        {           
            richTextBox1.Undo();     
        }

        private void redoStripButton_Click(object sender, EventArgs e)
        {            
            richTextBox1.Redo();    
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            this.Close();     
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            richTextBox1.Undo();     
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            richTextBox1.Redo();     
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            richTextBox1.Cut();     
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Copy();     
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {           
            richTextBox1.Paste();    
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
            richTextBox1.SelectAll();    
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            richTextBox1.SelectedText = "";
            richTextBox1.Focus();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                
            }
        }

        private void newMenuItem_Click(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text != string.Empty)    
            {
               
               DialogResult result =  MessageBox.Show("Would you like to save your changes? Editor is not empty.", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if(result == DialogResult.Yes)
                {
                   
                    saveFileDialog1.ShowDialog();    
                    string file;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string filename = saveFileDialog1.FileName;
                        
                        richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
                        file = Path.GetFileName(filename); 
                        MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    
                    richTextBox1.ResetText();
                    richTextBox1.Focus();
                }
                else if(result == DialogResult.No)
                {
                    
                    richTextBox1.ResetText();
                    richTextBox1.Focus();
                }               
            }
            else 
            {
                
                richTextBox1.ResetText();
                richTextBox1.Focus();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();    
            string file; 

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                
                richTextBox1.SaveFile(filename, RichTextBoxStreamType.PlainText);
            }
            file = Path.GetFileName(filenamee);    
            MessageBox.Show("File " + file + " was saved successfully.", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void zoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            float zoomPercent = Convert.ToSingle(e.ClickedItem.Text.Trim('%')); 
            richTextBox1.ZoomFactor = zoomPercent / 100;    

            if(e.ClickedItem.Image == null)
            {
                
                for (int i = 0; i < zoomDropDownButton.DropDownItems.Count; i++)
                {
                    zoomDropDownButton.DropDownItems[i].Image = null;
                }

                
                Bitmap bmp = new Bitmap(5, 5);
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
                }
                e.ClickedItem.Image = bmp;    
            }
            else
            {
                e.ClickedItem.Image = null;
                richTextBox1.ZoomFactor = 1.0f;    
            }
        }

        private void uppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();    
        }

        private void lowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();    
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Bitmap bmp = new Bitmap(5, 5);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.FillEllipse(Brushes.Black, 1, 1, 3, 3);
            }

            if (richTextBox1.WordWrap == false)
            {
                richTextBox1.WordWrap = true;    
                wordWrapToolStripMenuItem.Image = bmp;    
            }
            else if(richTextBox1.WordWrap == true)
            {
                richTextBox1.WordWrap = false;    
                wordWrapToolStripMenuItem.Image = null;    
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog1.ShowDialog();  
                System.Drawing.Font oldFont = this.Font;   

                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    fontDialog1_Apply(richTextBox1, new System.EventArgs());
                }
                
                else if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    
                    this.Font = oldFont;

                    
                    foreach (Control containedControl in richTextBox1.Controls)
                    {
                        containedControl.Font = oldFont;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
        }

        private void fontDialog1_HelpRequest(object sender, EventArgs e)
        {
           
            MessageBox.Show("Будь ласка, оберіть шрифт та будь-які інші характеристики, потім натиснітьApply and OK.", "Font Dialog Help Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            fontDialog1.FontMustExist = true;    
            
            richTextBox1.Font = fontDialog1.Font;   
            richTextBox1.ForeColor = fontDialog1.Color;    
            
            
            foreach (Control containedControl in richTextBox1.Controls)
            {
                containedControl.Font = fontDialog1.Font;
            }
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = ""; 
        }

        private void clearFormattingStripButton_Click(object sender, EventArgs e)
        {
            fontStripComboBox.Text = "Шрифти";
            fontSizeComboBox.Text = "Розмыр шрифтів";
            string pureText = richTextBox1.Text;     
            richTextBox1.Clear();    
            richTextBox1.ForeColor = Color.Black;   
            richTextBox1.Font = default(Font);    
            richTextBox1.Text = pureText;    
            rightAlignStripButton.Checked = false;
            centerAlignStripButton.Checked = false;
            leftAlignStripButton.Checked = true;           
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 100, 20);
            e.Graphics.PageUnit = GraphicsUnit.Inch; 
        }

        private void printStripButton_Click(object sender, EventArgs e)
        {
            
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print(); 
            }
        }

        private void printPreviewStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument; 
            
            printPreviewDialog.ShowDialog();
        }

        private void printStripMenuItem_Click(object sender, EventArgs e)
        {
            
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printPreviewStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            
            printPreviewDialog.ShowDialog();
        }

        private void colorDialog1_HelpRequest(object sender, EventArgs e)
        {
            
            MessageBox.Show("Будь ласка, виберіть колір, натиснувши на нього. Це змінить колір тексту.", "Діалогове вікно кольорів, запит на допомогу", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void colorOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    pos = richTextBox1.SelectionStart;    
                    line = richTextBox1.GetLineFromCharIndex(pos);    
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Right:
                    pos = richTextBox1.SelectionStart; 
                    line = richTextBox1.GetLineFromCharIndex(pos); 
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Up:
                    pos = richTextBox1.SelectionStart; 
                    line = richTextBox1.GetLineFromCharIndex(pos); 
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;
                case Keys.Left:
                    pos = richTextBox1.SelectionStart; 
                    line = richTextBox1.GetLineFromCharIndex(pos); 
                    column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    
                    lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
                    break;                
            }
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int pos = richTextBox1.SelectionStart;    
            int line = richTextBox1.GetLineFromCharIndex(pos);    
            int column = richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(line);    
            lineColumnStatusLabel.Text = "Line " + (line + 1) + ", Column " + (column + 1);
        }
        
    }
}
