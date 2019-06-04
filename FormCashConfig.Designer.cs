namespace OpenTracker
{
    partial class FormCashConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCashConfig));
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.txtHandPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.btnOpenHandPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(248, 58);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(292, 20);
            this.txtBackupPath.TabIndex = 14;
            // 
            // txtHandPath
            // 
            this.txtHandPath.Location = new System.Drawing.Point(248, 20);
            this.txtHandPath.Name = "txtHandPath";
            this.txtHandPath.ReadOnly = true;
            this.txtHandPath.Size = new System.Drawing.Size(292, 20);
            this.txtHandPath.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Path where your hands will be copied:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Path where your hands are:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(482, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(563, 106);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.Location = new System.Drawing.Point(546, 56);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(75, 23);
            this.btnBackupPath.TabIndex = 16;
            this.btnBackupPath.Text = "Browse";
            this.btnBackupPath.UseVisualStyleBackColor = true;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // btnOpenHandPath
            // 
            this.btnOpenHandPath.Location = new System.Drawing.Point(546, 18);
            this.btnOpenHandPath.Name = "btnOpenHandPath";
            this.btnOpenHandPath.Size = new System.Drawing.Size(75, 23);
            this.btnOpenHandPath.TabIndex = 15;
            this.btnOpenHandPath.Text = "Browse";
            this.btnOpenHandPath.UseVisualStyleBackColor = true;
            this.btnOpenHandPath.Click += new System.EventHandler(this.btnOpenHandPath_Click);
            // 
            // FormCashConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 148);
            this.Controls.Add(this.txtBackupPath);
            this.Controls.Add(this.txtHandPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBackupPath);
            this.Controls.Add(this.btnOpenHandPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCashConfig";
            this.Text = "Cash Game Configurations!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtBackupPath;
        public System.Windows.Forms.TextBox txtHandPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.Button btnOpenHandPath;
    }
}