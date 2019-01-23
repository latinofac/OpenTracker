namespace OpenTracker
{
    partial class FormHands
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHands));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHands = new System.Windows.Forms.DataGridView();
            this.txtFilteredHands = new System.Windows.Forms.TextBox();
            this.btnFilterHands = new System.Windows.Forms.Button();
            this.cboPlayer = new System.Windows.Forms.ComboBox();
            this.txtMaxPages = new System.Windows.Forms.TextBox();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.IDHand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Card1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Card2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.NetWon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Replay = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHands)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Select Player:";
            // 
            // dgvHands
            // 
            this.dgvHands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHands.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDHand,
            this.Card1,
            this.Card2,
            this.NetWon,
            this.Replay});
            this.dgvHands.Location = new System.Drawing.Point(7, 36);
            this.dgvHands.Name = "dgvHands";
            this.dgvHands.Size = new System.Drawing.Size(575, 359);
            this.dgvHands.TabIndex = 11;
            this.dgvHands.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHands_CellContentClick);
            // 
            // txtFilteredHands
            // 
            this.txtFilteredHands.Location = new System.Drawing.Point(512, 401);
            this.txtFilteredHands.Name = "txtFilteredHands";
            this.txtFilteredHands.ReadOnly = true;
            this.txtFilteredHands.Size = new System.Drawing.Size(31, 20);
            this.txtFilteredHands.TabIndex = 21;
            this.txtFilteredHands.Visible = false;
            // 
            // btnFilterHands
            // 
            this.btnFilterHands.Location = new System.Drawing.Point(495, 6);
            this.btnFilterHands.Name = "btnFilterHands";
            this.btnFilterHands.Size = new System.Drawing.Size(85, 23);
            this.btnFilterHands.TabIndex = 20;
            this.btnFilterHands.Text = "Filter Hands";
            this.btnFilterHands.UseVisualStyleBackColor = true;
            this.btnFilterHands.Click += new System.EventHandler(this.btnFilterHands_Click);
            // 
            // cboPlayer
            // 
            this.cboPlayer.FormattingEnabled = true;
            this.cboPlayer.Location = new System.Drawing.Point(93, 8);
            this.cboPlayer.Name = "cboPlayer";
            this.cboPlayer.Size = new System.Drawing.Size(235, 21);
            this.cboPlayer.TabIndex = 19;
            this.cboPlayer.SelectedIndexChanged += new System.EventHandler(this.cboPlayer_SelectedIndexChanged);
            // 
            // txtMaxPages
            // 
            this.txtMaxPages.Location = new System.Drawing.Point(549, 401);
            this.txtMaxPages.Name = "txtMaxPages";
            this.txtMaxPages.ReadOnly = true;
            this.txtMaxPages.Size = new System.Drawing.Size(31, 20);
            this.txtMaxPages.TabIndex = 17;
            this.txtMaxPages.Visible = false;
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(273, 403);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.Size = new System.Drawing.Size(31, 20);
            this.txtPage.TabIndex = 16;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(391, 401);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 15;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(110, 401);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 14;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(310, 401);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(191, 401);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // IDHand
            // 
            this.IDHand.HeaderText = "IDHand";
            this.IDHand.Name = "IDHand";
            this.IDHand.ReadOnly = true;
            this.IDHand.Visible = false;
            // 
            // Card1
            // 
            this.Card1.HeaderText = "";
            this.Card1.Name = "Card1";
            this.Card1.ReadOnly = true;
            this.Card1.Width = 60;
            // 
            // Card2
            // 
            this.Card2.HeaderText = "";
            this.Card2.Name = "Card2";
            this.Card2.ReadOnly = true;
            this.Card2.Width = 60;
            // 
            // NetWon
            // 
            this.NetWon.HeaderText = "Net Won";
            this.NetWon.Name = "NetWon";
            this.NetWon.ReadOnly = true;
            // 
            // Replay
            // 
            this.Replay.HeaderText = "";
            this.Replay.Name = "Replay";
            this.Replay.ReadOnly = true;
            this.Replay.Text = "Replay";
            this.Replay.UseColumnTextForButtonValue = true;
            // 
            // FormHands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHands);
            this.Controls.Add(this.txtFilteredHands);
            this.Controls.Add(this.btnFilterHands);
            this.Controls.Add(this.cboPlayer);
            this.Controls.Add(this.txtMaxPages);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHands";
            this.Text = "Hands!";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvHands;
        public System.Windows.Forms.TextBox txtFilteredHands;
        private System.Windows.Forms.Button btnFilterHands;
        public System.Windows.Forms.ComboBox cboPlayer;
        public System.Windows.Forms.TextBox txtMaxPages;
        public System.Windows.Forms.TextBox txtPage;
        public System.Windows.Forms.Button btnLast;
        public System.Windows.Forms.Button btnFirst;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDHand;
        private System.Windows.Forms.DataGridViewImageColumn Card1;
        private System.Windows.Forms.DataGridViewImageColumn Card2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWon;
        private System.Windows.Forms.DataGridViewButtonColumn Replay;
    }
}