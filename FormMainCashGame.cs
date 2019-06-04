using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTracker
{
    public partial class FormMainCashGame : Form
    {
        private DataTable dataTable = new DataTable();

        public FormMainCashGame()
        {
            InitializeComponent();
            CreateGridColumns();
            LoadPlayersIntoGrid();
        }

        private void CreateGridColumns()
        {
            dataTable.Columns.Add("Nickname", typeof(string));
            dataTable.Columns.Add("TotalHands", typeof(int));
            dataTable.Columns.Add("NetWon", typeof(double));
            dataTable.Columns.Add("VPIP", typeof(double));
            dataTable.Columns.Add("PFR", typeof(double));
            dataTable.Columns.Add("BB/100", typeof(double));            
        }

        private void LoadPlayersIntoGrid()
        {
            Players playersGetter = new Players();
            List<CashGamePlayersView> listCashGamePlayersView = new List<CashGamePlayersView>();

            listCashGamePlayersView = playersGetter.GetCashGamePlayersView();            
            dataTable.Clear();

            foreach (CashGamePlayersView cashGamePlayersView in listCashGamePlayersView)
            {
                dataTable.Rows.Add(
                    cashGamePlayersView.Nickname,
                    cashGamePlayersView.TotalHands, 
                    cashGamePlayersView.NetWon, 
                    cashGamePlayersView.VPIP, 
                    cashGamePlayersView.PFR, 
                    cashGamePlayersView.BB100
                    );
            }
            
            this.gridPlayers.DataSource = dataTable;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = string.Format("Nickname like '{0}%'", this.txtPlayerName.Text);
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            FormCashResults formCashResults = new FormCashResults();
            formCashResults.ShowDialog();
            formCashResults.Dispose();
        }

        private void btnHands_Click(object sender, EventArgs e)
        {
            FormHands formHands = new FormHands();
            formHands.ShowDialog();
            formHands.Dispose();
        }

        private void btnSessions_Click(object sender, EventArgs e)
        {
            FormSessions formSessions = new FormSessions();
            formSessions.ShowDialog();
            formSessions.Dispose();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            CashGameConfig cashGameConfig = new CashGameConfig();
            HandLoader handLoader = new HandLoader();
                 
            if (!cashGameConfig.ReadConfiguration())
            {
                MessageBox.Show("Please set firt the hand's files configuration.");
                return;
            }

            DirectoryInfo handsToLoadPath = new DirectoryInfo(cashGameConfig.handsToLoadPath);

            if (handsToLoadPath.GetFiles().Count() > 0)
            {
                this.prgBar.Maximum = handsToLoadPath.GetFiles().Count();
                this.prgBar.Value = 0;
                this.prgBar.Visible = true;
            }

            foreach (FileInfo file in handsToLoadPath.GetFiles())
            {
                this.prgBar.Value++;
                if (handLoader.LoadCashSession(file))
                    handLoader.Backup(file);
            }

            this.prgBar.Visible = false;

            LoadPlayersIntoGrid();
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to clear your database?", "Warning", MessageBoxButtons.YesNoCancel);
            SQL sql = new SQL();

            if (dialog == DialogResult.Yes)
            {
                sql.ClearDB();
                LoadPlayersIntoGrid();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Config configGetter = new Config();
            FormCashConfig formCashConfig = new FormCashConfig();

            formCashConfig.txtHandPath.Text = configGetter.GetHandPath();
            formCashConfig.txtBackupPath.Text = configGetter.GetBackupPath();
            formCashConfig.ShowDialog();
            formCashConfig.Dispose();
        }
    }
}
