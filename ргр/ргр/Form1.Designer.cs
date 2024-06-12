namespace ргр
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lstTeams = new System.Windows.Forms.ListBox();
            this.txtNewTeam = new System.Windows.Forms.TextBox();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.btnRemoveTeam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstTeams
            // 
            this.lstTeams.FormattingEnabled = true;
            this.lstTeams.Location = new System.Drawing.Point(306, 24);
            this.lstTeams.Name = "lstTeams";
            this.lstTeams.Size = new System.Drawing.Size(120, 147);
            this.lstTeams.TabIndex = 0;
            // 
            // txtNewTeam
            // 
            this.txtNewTeam.Location = new System.Drawing.Point(447, 81);
            this.txtNewTeam.Name = "txtNewTeam";
            this.txtNewTeam.Size = new System.Drawing.Size(120, 20);
            this.txtNewTeam.TabIndex = 1;
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.Location = new System.Drawing.Point(447, 125);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(120, 23);
            this.btnAddTeam.TabIndex = 2;
            this.btnAddTeam.Text = "Add";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(382, 320);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(161, 76);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtSchedule
            // 
            this.txtSchedule.Location = new System.Drawing.Point(12, 12);
            this.txtSchedule.Multiline = true;
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSchedule.Size = new System.Drawing.Size(270, 417);
            this.txtSchedule.TabIndex = 4;
            // 
            // btnRemoveTeam
            // 
            this.btnRemoveTeam.Location = new System.Drawing.Point(306, 188);
            this.btnRemoveTeam.Name = "btnRemoveTeam";
            this.btnRemoveTeam.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveTeam.TabIndex = 5;
            this.btnRemoveTeam.Text = "Remove";
            this.btnRemoveTeam.UseVisualStyleBackColor = true;
            this.btnRemoveTeam.Click += new System.EventHandler(this.btnRemoveTeam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введіть команди";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveTeam);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnAddTeam);
            this.Controls.Add(this.txtNewTeam);
            this.Controls.Add(this.lstTeams);
            this.Name = "Form1";
            this.Text = "Round Robin Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTeams;
        private System.Windows.Forms.TextBox txtNewTeam;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtSchedule;
        private System.Windows.Forms.Button btnRemoveTeam; // Додано кнопку видалення
        private System.Windows.Forms.Label label1;
    }
}
