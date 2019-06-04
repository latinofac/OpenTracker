namespace OpenTracker
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSupport = new System.Windows.Forms.Button();
            this.btnTournaments = new System.Windows.Forms.Button();
            this.btnCashGame = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tournaments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Cash Game";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(362, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Exit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(505, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Support";
            // 
            // btnSupport
            // 
            this.btnSupport.Image = global::OpenTracker.Properties.Resources.support2;
            this.btnSupport.Location = new System.Drawing.Point(472, 41);
            this.btnSupport.Name = "btnSupport";
            this.btnSupport.Size = new System.Drawing.Size(126, 126);
            this.btnSupport.TabIndex = 31;
            this.btnSupport.UseVisualStyleBackColor = true;
            this.btnSupport.Click += new System.EventHandler(this.btnSupport_Click);
            // 
            // btnTournaments
            // 
            this.btnTournaments.Image = global::OpenTracker.Properties.Resources.tourney;
            this.btnTournaments.Location = new System.Drawing.Point(167, 41);
            this.btnTournaments.Name = "btnTournaments";
            this.btnTournaments.Size = new System.Drawing.Size(126, 126);
            this.btnTournaments.TabIndex = 30;
            this.btnTournaments.UseVisualStyleBackColor = true;
            this.btnTournaments.Click += new System.EventHandler(this.btnTournaments_Click);
            // 
            // btnCashGame
            // 
            this.btnCashGame.Image = global::OpenTracker.Properties.Resources.cashGame;
            this.btnCashGame.Location = new System.Drawing.Point(22, 41);
            this.btnCashGame.Name = "btnCashGame";
            this.btnCashGame.Size = new System.Drawing.Size(126, 126);
            this.btnCashGame.TabIndex = 28;
            this.btnCashGame.UseVisualStyleBackColor = true;
            this.btnCashGame.Click += new System.EventHandler(this.btnCashGame_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OpenTracker.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(318, 41);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(126, 126);
            this.btnExit.TabIndex = 25;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 259);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSupport);
            this.Controls.Add(this.btnTournaments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCashGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Welcome to Open Tracker! - Version 1.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTournaments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCashGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSupport;
        private System.Windows.Forms.Label label4;
    }
}