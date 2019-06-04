namespace OpenTracker
{
    partial class FormMainTournaments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainTournaments));
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProfit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAvgBuyIn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtITM = new System.Windows.Forms.TextBox();
            this.txtROI = new System.Windows.Forms.TextBox();
            this.txtTotalPrizeWon = new System.Windows.Forms.TextBox();
            this.txtTotalBuyIn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridTournaments = new System.Windows.Forms.DataGridView();
            this.IDTournament = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrizeWon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hands = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnClearDB = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridTournaments)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(196, 569);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Clear DB";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 569);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "Configurations";
            // 
            // txtProfit
            // 
            this.txtProfit.Enabled = false;
            this.txtProfit.Location = new System.Drawing.Point(1197, 135);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.Size = new System.Drawing.Size(100, 20);
            this.txtProfit.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1110, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 24);
            this.label7.TabIndex = 43;
            this.label7.Text = "Profit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1208, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Exit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1063, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "Load";
            // 
            // txtAvgBuyIn
            // 
            this.txtAvgBuyIn.Enabled = false;
            this.txtAvgBuyIn.Location = new System.Drawing.Point(1119, 243);
            this.txtAvgBuyIn.Name = "txtAvgBuyIn";
            this.txtAvgBuyIn.Size = new System.Drawing.Size(78, 20);
            this.txtAvgBuyIn.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1019, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 37;
            this.label5.Text = "AvBuyIn:";
            // 
            // txtITM
            // 
            this.txtITM.Enabled = false;
            this.txtITM.Location = new System.Drawing.Point(1240, 198);
            this.txtITM.Name = "txtITM";
            this.txtITM.Size = new System.Drawing.Size(52, 20);
            this.txtITM.TabIndex = 36;
            // 
            // txtROI
            // 
            this.txtROI.Enabled = false;
            this.txtROI.Location = new System.Drawing.Point(1091, 198);
            this.txtROI.Name = "txtROI";
            this.txtROI.Size = new System.Drawing.Size(52, 20);
            this.txtROI.TabIndex = 35;
            // 
            // txtTotalPrizeWon
            // 
            this.txtTotalPrizeWon.Enabled = false;
            this.txtTotalPrizeWon.Location = new System.Drawing.Point(1197, 90);
            this.txtTotalPrizeWon.Name = "txtTotalPrizeWon";
            this.txtTotalPrizeWon.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPrizeWon.TabIndex = 34;
            // 
            // txtTotalBuyIn
            // 
            this.txtTotalBuyIn.Enabled = false;
            this.txtTotalBuyIn.Location = new System.Drawing.Point(1197, 43);
            this.txtTotalBuyIn.Name = "txtTotalBuyIn";
            this.txtTotalBuyIn.Size = new System.Drawing.Size(100, 20);
            this.txtTotalBuyIn.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1168, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "ITM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1019, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 31;
            this.label3.Text = "ROI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1019, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Total PrizeWon:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1055, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Total BuyIn:";
            // 
            // gridTournaments
            // 
            this.gridTournaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTournaments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDTournament,
            this.BuyIn,
            this.Rake,
            this.NumPlayers,
            this.DateStart,
            this.TimeStart,
            this.Position,
            this.PrizeWon,
            this.Hands});
            this.gridTournaments.Location = new System.Drawing.Point(-21, 32);
            this.gridTournaments.Name = "gridTournaments";
            this.gridTournaments.Size = new System.Drawing.Size(991, 471);
            this.gridTournaments.TabIndex = 28;
            this.gridTournaments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTournaments_CellContentClick);
            // 
            // IDTournament
            // 
            this.IDTournament.HeaderText = "Tournament";
            this.IDTournament.Name = "IDTournament";
            this.IDTournament.ReadOnly = true;
            // 
            // BuyIn
            // 
            this.BuyIn.HeaderText = "BuyIn";
            this.BuyIn.Name = "BuyIn";
            this.BuyIn.ReadOnly = true;
            // 
            // Rake
            // 
            this.Rake.HeaderText = "Rake";
            this.Rake.Name = "Rake";
            this.Rake.ReadOnly = true;
            // 
            // NumPlayers
            // 
            this.NumPlayers.HeaderText = "NumPlayers";
            this.NumPlayers.Name = "NumPlayers";
            this.NumPlayers.ReadOnly = true;
            // 
            // DateStart
            // 
            this.DateStart.HeaderText = "Date Start";
            this.DateStart.Name = "DateStart";
            this.DateStart.ReadOnly = true;
            // 
            // TimeStart
            // 
            this.TimeStart.HeaderText = "Time Start";
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            // 
            // PrizeWon
            // 
            this.PrizeWon.HeaderText = "Prize Won";
            this.PrizeWon.Name = "PrizeWon";
            this.PrizeWon.ReadOnly = true;
            // 
            // Hands
            // 
            this.Hands.HeaderText = "";
            this.Hands.Name = "Hands";
            this.Hands.Text = "Hands";
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfig.Image = global::OpenTracker.Properties.Resources.config2;
            this.btnConfig.Location = new System.Drawing.Point(12, 594);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(126, 126);
            this.btnConfig.TabIndex = 46;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnClearDB
            // 
            this.btnClearDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearDB.Image = global::OpenTracker.Properties.Resources.cleardb;
            this.btnClearDB.Location = new System.Drawing.Point(168, 594);
            this.btnClearDB.Name = "btnClearDB";
            this.btnClearDB.Size = new System.Drawing.Size(126, 126);
            this.btnClearDB.TabIndex = 45;
            this.btnClearDB.UseVisualStyleBackColor = true;
            this.btnClearDB.Click += new System.EventHandler(this.btnClearDB_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::OpenTracker.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(1171, 321);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(126, 126);
            this.btnExit.TabIndex = 42;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::OpenTracker.Properties.Resources.loading;
            this.btnLoad.Location = new System.Drawing.Point(1023, 321);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(126, 126);
            this.btnLoad.TabIndex = 39;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(405, 363);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(499, 23);
            this.prgBar.TabIndex = 49;
            this.prgBar.Visible = false;
            // 
            // FormMainTournaments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 749);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnClearDB);
            this.Controls.Add(this.txtProfit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtAvgBuyIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtITM);
            this.Controls.Add(this.txtROI);
            this.Controls.Add(this.txtTotalPrizeWon);
            this.Controls.Add(this.txtTotalBuyIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridTournaments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainTournaments";
            this.Text = "Tournaments Manager!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridTournaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnClearDB;
        private System.Windows.Forms.TextBox txtProfit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtAvgBuyIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtITM;
        private System.Windows.Forms.TextBox txtROI;
        private System.Windows.Forms.TextBox txtTotalPrizeWon;
        private System.Windows.Forms.TextBox txtTotalBuyIn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridTournaments;
        public System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTournament;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rake;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrizeWon;
        private System.Windows.Forms.DataGridViewButtonColumn Hands;
    }
}