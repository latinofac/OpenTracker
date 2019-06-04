namespace OpenTracker
{
    partial class FormSessions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSessions));
            this.dgSessions = new System.Windows.Forms.DataGridView();
            this.IDSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalHands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHands = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSessions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSessions
            // 
            this.dgSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSessions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDSession,
            this.DateSession,
            this.TimeStart,
            this.TimeEnd,
            this.TotalHands,
            this.NetWon,
            this.btnHands});
            this.dgSessions.Location = new System.Drawing.Point(9, 18);
            this.dgSessions.Name = "dgSessions";
            this.dgSessions.Size = new System.Drawing.Size(688, 252);
            this.dgSessions.TabIndex = 1;
            this.dgSessions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSessions_CellContentClick);
            // 
            // IDSession
            // 
            this.IDSession.HeaderText = "";
            this.IDSession.Name = "IDSession";
            this.IDSession.Visible = false;
            // 
            // DateSession
            // 
            this.DateSession.HeaderText = "Date Session";
            this.DateSession.Name = "DateSession";
            this.DateSession.ReadOnly = true;
            // 
            // TimeStart
            // 
            this.TimeStart.HeaderText = "Time Start";
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.ReadOnly = true;
            // 
            // TimeEnd
            // 
            this.TimeEnd.HeaderText = "Time End";
            this.TimeEnd.Name = "TimeEnd";
            this.TimeEnd.ReadOnly = true;
            // 
            // TotalHands
            // 
            this.TotalHands.HeaderText = "Total Hands";
            this.TotalHands.Name = "TotalHands";
            this.TotalHands.ReadOnly = true;
            // 
            // NetWon
            // 
            this.NetWon.HeaderText = "Net Won";
            this.NetWon.Name = "NetWon";
            this.NetWon.ReadOnly = true;
            // 
            // btnHands
            // 
            this.btnHands.HeaderText = "";
            this.btnHands.Name = "btnHands";
            this.btnHands.ReadOnly = true;
            this.btnHands.Text = "Hands";
            this.btnHands.UseColumnTextForButtonValue = true;
            // 
            // FormSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 288);
            this.Controls.Add(this.dgSessions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSessions";
            this.Text = "Sessions!";
            ((System.ComponentModel.ISupportInitialize)(this.dgSessions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgSessions;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSession;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalHands;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWon;
        private System.Windows.Forms.DataGridViewButtonColumn btnHands;
    }
}