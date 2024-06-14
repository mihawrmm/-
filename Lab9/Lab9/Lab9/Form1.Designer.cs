namespace Lab9
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            rTextBox = new TextBox();
            hTextBox = new TextBox();
            graphPictureBox = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(557, 317);
            button1.Name = "button1";
            button1.Size = new Size(231, 121);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 66);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 1;
            label1.Text = "Введіть r";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 120);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 2;
            label2.Text = "Введіть h";
            // 
            // rTextBox
            // 
            rTextBox.Location = new Point(124, 66);
            rTextBox.Name = "rTextBox";
            rTextBox.Size = new Size(156, 23);
            rTextBox.TabIndex = 3;
            // 
            // hTextBox
            // 
            hTextBox.Location = new Point(124, 120);
            hTextBox.Name = "hTextBox";
            hTextBox.Size = new Size(156, 23);
            hTextBox.TabIndex = 4;
            // 
            // graphPictureBox
            // 
            graphPictureBox.Location = new Point(395, 65);
            graphPictureBox.Name = "graphPictureBox";
            graphPictureBox.Size = new Size(359, 177);
            graphPictureBox.TabIndex = 5;
            graphPictureBox.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(50, 298);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(203, 36);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(graphPictureBox);
            Controls.Add(hTextBox);
            Controls.Add(rTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)graphPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox rTextBox;
        private TextBox hTextBox;
        private PictureBox graphPictureBox;
        private PictureBox pictureBox2;
    }
}
