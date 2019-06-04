using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTracker
{
    public partial class FormCashResults : Form
    {
        private Players playersGettter = new Players();
        private int heroIdPlayer = 0;

        public FormCashResults()
        {
            InitializeComponent();
            CreateGridColumns();
            heroIdPlayer = playersGettter.GetHeroID();
            LoadResultsIntoGrid(heroIdPlayer);
            LoadPlayersIntoComboBox();
        }

        private void LoadPlayersIntoComboBox()
        {
            List<Players> listPlayers = new List<Players>();
            listPlayers = playersGettter.GetAllPlayers(0);

            this.cboPlayer.DataSource = listPlayers;
            this.cboPlayer.ValueMember = "IDPlayer";
            this.cboPlayer.DisplayMember = "Nickname";
            this.cboPlayer.SelectedValue = heroIdPlayer;            
        }

        private void CreateGridColumns()
        {
            this.dgvResults.Columns.Add("NAME", "Name");
            this.dgvResults.Columns.Add("TOTHANDS", "Total Hands");
            this.dgvResults.Columns.Add("NETWON", "NetWon");
            this.dgvResults.Columns.Add("BB100", "BB/100");

            this.dgvResults.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void LoadResultsIntoGrid(int idPlayer)
        {
            int TotHands = 0;
            double NetWon = 0;
            List<ResultsView> listResultsView = new List<ResultsView>();
            
            listResultsView = playersGettter.GetResultsView(idPlayer, this.txtFilteredHands.Text);

            foreach (ResultsView resultView in listResultsView)
            {
                this.dgvResults.Rows.Add(
                        resultView.NAME,
                        resultView.TOTHANDS,
                        resultView.NETWON,
                        resultView.BB100
                        );

                TotHands = TotHands + resultView.TOTHANDS;
                NetWon = NetWon + resultView.NETWON;            
            }

            this.dgvResults.Rows.Add("TOTAL", TotHands, Math.Round(NetWon, 2));

            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font(this.dgvResults.Font, FontStyle.Bold);
            this.dgvResults.Rows[this.dgvResults.Rows.Count - 2].DefaultCellStyle = style;            
        }

        private void cboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlayer.SelectedValue is Int32)
                FilterResults();
        }

        private void FilterResults()
        {
            this.dgvResults.Rows.Clear();
            LoadResultsIntoGrid(Convert.ToInt32(cboPlayer.SelectedValue));
        }

        private void btnFilterHands_Click(object sender, EventArgs e)
        {
            FormFilterHands formFilterHands = new FormFilterHands();

            formFilterHands.txtFilterHands.Text = this.txtFilteredHands.Text;
            formFilterHands.FillButtons();
            formFilterHands.ShowDialog();
            this.txtFilteredHands.Text = formFilterHands.txtFilterHands.Text;
            formFilterHands.Dispose();

            FilterResults();            
        }
    }
}
