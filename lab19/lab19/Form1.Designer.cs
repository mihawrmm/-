
namespace lab19
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxHWInfo = new System.Windows.Forms.ListBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxHWInfo
            // 
            this.listBoxHWInfo.FormattingEnabled = true;
            this.listBoxHWInfo.Location = new System.Drawing.Point(11, 11);
            this.listBoxHWInfo.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxHWInfo.Name = "listBoxHWInfo";
            this.listBoxHWInfo.Size = new System.Drawing.Size(477, 329);
            this.listBoxHWInfo.TabIndex = 3;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(11, 344);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(477, 27);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 381);
            this.Controls.Add(this.listBoxHWInfo);
            this.Controls.Add(this.LoadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxHWInfo;
        private System.Windows.Forms.Button LoadButton;
    }
}

