namespace Lab10
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonStart1;
        private System.Windows.Forms.Button buttonStart2;
        private System.Windows.Forms.Button buttonStart3;
        private System.Windows.Forms.Button buttonStop1;
        private System.Windows.Forms.Button buttonStop2;
        private System.Windows.Forms.Button buttonStop3;
        private System.Windows.Forms.Button buttonStartAll;
        private System.Windows.Forms.Button buttonStopAll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonStart1 = new System.Windows.Forms.Button();
            this.buttonStart2 = new System.Windows.Forms.Button();
            this.buttonStart3 = new System.Windows.Forms.Button();
            this.buttonStop1 = new System.Windows.Forms.Button();
            this.buttonStop2 = new System.Windows.Forms.Button();
            this.buttonStop3 = new System.Windows.Forms.Button();
            this.buttonStartAll = new System.Windows.Forms.Button();
            this.buttonStopAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(218, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 200);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(424, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(200, 200);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // buttonStart1
            // 
            this.buttonStart1.Location = new System.Drawing.Point(12, 218);
            this.buttonStart1.Name = "buttonStart1";
            this.buttonStart1.Size = new System.Drawing.Size(75, 23);
            this.buttonStart1.TabIndex = 3;
            this.buttonStart1.Text = "Запустити 1 Поток";
            this.buttonStart1.UseVisualStyleBackColor = true;
            this.buttonStart1.Click += new System.EventHandler(this.buttonStart1_Click);
            // 
            // buttonStart2
            // 
            this.buttonStart2.Location = new System.Drawing.Point(218, 218);
            this.buttonStart2.Name = "buttonStart2";
            this.buttonStart2.Size = new System.Drawing.Size(75, 23);
            this.buttonStart2.TabIndex = 4;
            this.buttonStart2.Text = "Запустити 2 Поток";
            this.buttonStart2.UseVisualStyleBackColor = true;
            this.buttonStart2.Click += new System.EventHandler(this.buttonStart2_Click);
            // 
            // buttonStart3
            // 
            this.buttonStart3.Location = new System.Drawing.Point(424, 218);
            this.buttonStart3.Name = "buttonStart3";
            this.buttonStart3.Size = new System.Drawing.Size(75, 23);
            this.buttonStart3.TabIndex = 5;
            this.buttonStart3.Text = "Запустити 3 Поток";
            this.buttonStart3.UseVisualStyleBackColor = true;
            this.buttonStart3.Click += new System.EventHandler(this.buttonStart3_Click);
            // 
            // buttonStop1
            // 
            this.buttonStop1.ForeColor = System.Drawing.Color.Red;
            this.buttonStop1.Location = new System.Drawing.Point(93, 218);
            this.buttonStop1.Name = "buttonStop1";
            this.buttonStop1.Size = new System.Drawing.Size(119, 23);
            this.buttonStop1.TabIndex = 6;
            this.buttonStop1.Text = "Остановить 1 Поток";
            this.buttonStop1.UseVisualStyleBackColor = true;
            this.buttonStop1.Click += new System.EventHandler(this.buttonStop1_Click);
            // 
            // buttonStop2
            // 
            this.buttonStop2.ForeColor = System.Drawing.Color.Red;
            this.buttonStop2.Location = new System.Drawing.Point(299, 218);
            this.buttonStop2.Name = "buttonStop2";
            this.buttonStop2.Size = new System.Drawing.Size(119, 23);
            this.buttonStop2.TabIndex = 7;
            this.buttonStop2.Text = "Остановить 2 Поток";
            this.buttonStop2.UseVisualStyleBackColor = true;
            this.buttonStop2.Click += new System.EventHandler(this.buttonStop2_Click);
            // 
            // buttonStop3
            // 
            this.buttonStop3.ForeColor = System.Drawing.Color.Red;
            this.buttonStop3.Location = new System.Drawing.Point(505, 218);
            this.buttonStop3.Name = "buttonStop3";
            this.buttonStop3.Size = new System.Drawing.Size(119, 23);
            this.buttonStop3.TabIndex = 8;
            this.buttonStop3.Text = "Остановить 3 Поток";
            this.buttonStop3.UseVisualStyleBackColor = true;
            this.buttonStop3.Click += new System.EventHandler(this.buttonStop3_Click);
            // 
            // buttonStartAll
            // 
            this.buttonStartAll.Location = new System.Drawing.Point(12, 247);
            this.buttonStartAll.Name = "buttonStartAll";
            this.buttonStartAll.Size = new System.Drawing.Size(612, 23);
            this.buttonStartAll.TabIndex = 9;
            this.buttonStartAll.Text = "Запустить все потоки";
            this.buttonStartAll.UseVisualStyleBackColor = true;
            this.buttonStartAll.Click += new System.EventHandler(this.buttonStartAll_Click);
            // 
            // buttonStopAll
            // 
            this.buttonStopAll.ForeColor = System.Drawing.Color.Red;
            this.buttonStopAll.Location = new System.Drawing.Point(12, 276);
            this.buttonStopAll.Name = "buttonStopAll";
            this.buttonStopAll.Size = new System.Drawing.Size(612, 23);
            this.buttonStopAll.TabIndex = 10;
            this.buttonStopAll.Text = "Остановить все потоки";
            this.buttonStopAll.UseVisualStyleBackColor = true;
            this.buttonStopAll.Click += new System.EventHandler(this.buttonStopAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 311);
            this.Controls.Add(this.buttonStopAll);
            this.Controls.Add(this.buttonStartAll);
            this.Controls.Add(this.buttonStop3);
            this.Controls.Add(this.buttonStop2);
            this.Controls.Add(this.buttonStop1);
            this.Controls.Add(this.buttonStart3);
            this.Controls.Add(this.buttonStart2);
            this.Controls.Add(this.buttonStart1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "3 потоковая программа";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }
    }
}

