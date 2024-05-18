
namespace lab15
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
            this.tbWay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.treeView = new System.Windows.Forms.TreeView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSet = new System.Windows.Forms.TabPage();
            this.tabOps = new System.Windows.Forms.TabPage();
            this.btnSize = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelFolder = new System.Windows.Forms.Button();
            this.btnDelFile = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.tbNewDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDelFolder = new System.Windows.Forms.TextBox();
            this.tbDelFile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbUpload = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOps.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbWay
            // 
            this.tbWay.Location = new System.Drawing.Point(53, 389);
            this.tbWay.Name = "tbWay";
            this.tbWay.Size = new System.Drawing.Size(330, 20);
            this.tbWay.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Шлях:";
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(449, 15);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(326, 397);
            this.treeView.TabIndex = 18;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(326, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(102, 74);
            this.btnConnect.TabIndex = 17;
            this.btnConnect.Text = "Підключитися";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(112, 84);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(145, 20);
            this.tbPass.TabIndex = 16;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(112, 47);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(145, 20);
            this.tbUser.TabIndex = 15;
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(112, 15);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(145, 20);
            this.tbHost.TabIndex = 14;
            this.tbHost.Text = "ftp://";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ім\'я користувача ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ip хост:";
            // 
            // tabSet
            // 
            this.tabSet.Location = new System.Drawing.Point(4, 22);
            this.tabSet.Name = "tabSet";
            this.tabSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabSet.Size = new System.Drawing.Size(406, 247);
            this.tabSet.TabIndex = 1;
            this.tabSet.Text = "Налаштування";
            this.tabSet.UseVisualStyleBackColor = true;
            // 
            // tabOps
            // 
            this.tabOps.Controls.Add(this.tbSize);
            this.tabOps.Controls.Add(this.tbUpload);
            this.tabOps.Controls.Add(this.tbDelFile);
            this.tabOps.Controls.Add(this.tbDelFolder);
            this.tabOps.Controls.Add(this.tbNewDir);
            this.tabOps.Controls.Add(this.label9);
            this.tabOps.Controls.Add(this.label8);
            this.tabOps.Controls.Add(this.label7);
            this.tabOps.Controls.Add(this.label6);
            this.tabOps.Controls.Add(this.label5);
            this.tabOps.Controls.Add(this.btnUpload);
            this.tabOps.Controls.Add(this.btnDelFile);
            this.tabOps.Controls.Add(this.btnDelFolder);
            this.tabOps.Controls.Add(this.btnCreate);
            this.tabOps.Controls.Add(this.btnSize);
            this.tabOps.Location = new System.Drawing.Point(4, 22);
            this.tabOps.Name = "tabOps";
            this.tabOps.Padding = new System.Windows.Forms.Padding(3);
            this.tabOps.Size = new System.Drawing.Size(406, 247);
            this.tabOps.TabIndex = 0;
            this.tabOps.Text = "Операції з FTP";
            this.tabOps.UseVisualStyleBackColor = true;
            // 
            // btnSize
            // 
            this.btnSize.Location = new System.Drawing.Point(13, 18);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(125, 23);
            this.btnSize.TabIndex = 0;
            this.btnSize.Text = "Розмір файлу";
            this.btnSize.UseVisualStyleBackColor = true;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(13, 59);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Створити каталог";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelFolder
            // 
            this.btnDelFolder.Location = new System.Drawing.Point(13, 107);
            this.btnDelFolder.Name = "btnDelFolder";
            this.btnDelFolder.Size = new System.Drawing.Size(125, 23);
            this.btnDelFolder.TabIndex = 2;
            this.btnDelFolder.Text = "Видалити каталог";
            this.btnDelFolder.UseVisualStyleBackColor = true;
            this.btnDelFolder.Click += new System.EventHandler(this.btnDelFolder_Click);
            // 
            // btnDelFile
            // 
            this.btnDelFile.Location = new System.Drawing.Point(13, 153);
            this.btnDelFile.Name = "btnDelFile";
            this.btnDelFile.Size = new System.Drawing.Size(125, 23);
            this.btnDelFile.TabIndex = 3;
            this.btnDelFile.Text = "Видалити файл";
            this.btnDelFile.UseVisualStyleBackColor = true;
            this.btnDelFile.Click += new System.EventHandler(this.btnDelFile_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(13, 198);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(125, 24);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Завантажити на FTP";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tbNewDir
            // 
            this.tbNewDir.Location = new System.Drawing.Point(203, 61);
            this.tbNewDir.Name = "tbNewDir";
            this.tbNewDir.Size = new System.Drawing.Size(167, 20);
            this.tbNewDir.TabIndex = 5;
            this.tbNewDir.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Каталог:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Каталог:";
            // 
            // tbDelFolder
            // 
            this.tbDelFolder.Location = new System.Drawing.Point(203, 109);
            this.tbDelFolder.Name = "tbDelFolder";
            this.tbDelFolder.Size = new System.Drawing.Size(167, 20);
            this.tbDelFolder.TabIndex = 8;
            this.tbDelFolder.Text = "/";
            // 
            // tbDelFile
            // 
            this.tbDelFile.Location = new System.Drawing.Point(203, 156);
            this.tbDelFile.Name = "tbDelFile";
            this.tbDelFile.Size = new System.Drawing.Size(167, 20);
            this.tbDelFile.TabIndex = 9;
            this.tbDelFile.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Файл:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Каталог:";
            // 
            // tbUpload
            // 
            this.tbUpload.Location = new System.Drawing.Point(203, 198);
            this.tbUpload.Name = "tbUpload";
            this.tbUpload.Size = new System.Drawing.Size(167, 20);
            this.tbUpload.TabIndex = 12;
            this.tbUpload.Text = "/";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Файл:";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(203, 21);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(167, 20);
            this.tbSize.TabIndex = 14;
            this.tbSize.Text = "/";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOps);
            this.tabControl.Controls.Add(this.tabSet);
            this.tabControl.Location = new System.Drawing.Point(14, 110);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(414, 273);
            this.tabControl.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 425);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tbWay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabOps.ResumeLayout(false);
            this.tabOps.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbWay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabSet;
        private System.Windows.Forms.TabPage tabOps;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.TextBox tbUpload;
        private System.Windows.Forms.TextBox tbDelFile;
        private System.Windows.Forms.TextBox tbDelFolder;
        private System.Windows.Forms.TextBox tbNewDir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDelFile;
        private System.Windows.Forms.Button btnDelFolder;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSize;
        private System.Windows.Forms.TabControl tabControl;
    }
}

