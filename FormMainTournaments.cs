using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenTracker
{
    public partial class FormMainTournaments : Form
    {
        private DataTable dataTable = new DataTable();

        public FormMainTournaments()
        {
            InitializeComponent();
            //CreateGridColumns();
            LoadTournamentsIntoGrid();
        }

        private void LoadTournamentsIntoGrid()
        {
            List<Tournaments> listTournaments = new List<Tournaments>();
            Tournaments tournamentGetter = new Tournaments();

            double totalBuyIn = 0;
            double totalPrizeWon = 0;
            double ITM = 0;
            int counter = 0;

            listTournaments = tournamentGetter.GetAllTournaments();
            
            //dataTable.Clear();
            this.gridTournaments.Rows.Clear();

            foreach (Tournaments tournament in listTournaments.OrderByDescending(x => x.DateStart).ThenByDescending(x => x.TimeStart))
            {                
                this.gridTournaments.Rows.Add(tournament.IDTournament,
                                   tournament.BuyIn,
                                   tournament.Rake,
                                   tournament.NumPlayers,
                                   tournament.DateStart,
                                   tournament.TimeStart,
                                   tournament.Position,
                                   tournament.PrizeWon,
                                   "Latino");

                
                DataGridViewButtonCell handButton = (DataGridViewButtonCell) this.gridTournaments.Rows[counter].Cells[8];
                if (tournament.HasHands)
                {
                    handButton.Value = "Hands";
                    handButton.Tag = tournament.IDTournament;
                }
                else
                {
                    handButton.Value = "-";
                    handButton.Tag = 0;
                }

                counter++;
                

                totalBuyIn = totalBuyIn + tournament.BuyIn;
                totalPrizeWon = totalPrizeWon + tournament.PrizeWon;

                if (tournament.PrizeWon > 0)
                    ITM++;
            }

            for (int coluna = 1; coluna < 7; coluna++)
            {
                this.gridTournaments.Columns[coluna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.gridTournaments.Columns[coluna].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            this.txtTotalBuyIn.Text = "U$ " + totalBuyIn.ToString();
            this.txtTotalPrizeWon.Text = "U$ " + totalPrizeWon.ToString();
            this.txtITM.Text = Math.Round(ITM * 100 / listTournaments.Count(), 2).ToString() + " %";
            this.txtROI.Text = Math.Round((totalPrizeWon - totalBuyIn) * 100 / totalBuyIn, 2).ToString() + " %";
            this.txtAvgBuyIn.Text = "U$ " + Math.Round(totalBuyIn / listTournaments.Count(), 2).ToString();
            this.txtProfit.Text = "U$ " + (totalPrizeWon - totalBuyIn).ToString();
        }

        private void CreateGridColumns()
        {
            dataTable.Columns.Add("IDTournament", typeof(double));
            dataTable.Columns.Add("BuyIn", typeof(double));
            dataTable.Columns.Add("Rake", typeof(double));
            dataTable.Columns.Add("NumPlayers", typeof(int));
            dataTable.Columns.Add("DateStart", typeof(DateTime));
            dataTable.Columns.Add("TimeStart", typeof(string));
            dataTable.Columns.Add("Position", typeof(int));
            dataTable.Columns.Add("PrizeWon", typeof(double));            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to clear your database?", "Warning", MessageBoxButtons.YesNoCancel);
            SQL sql = new SQL();

            if (dialog == DialogResult.Yes)
            {
                sql.ClearTournamentDB();
                LoadTournamentsIntoGrid();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Config configGetter = new Config();
            FormTournamentsConfig formTournamentsConfig = new FormTournamentsConfig();

            formTournamentsConfig.txtHandPath.Text = configGetter.GetHandPath();
            formTournamentsConfig.txtBackupPath.Text = configGetter.GetBackupPath();
            formTournamentsConfig.txtTournamentSummaryPath.Text = configGetter.GetTournamentsSummaryPath();
            formTournamentsConfig.ShowDialog();
            formTournamentsConfig.Dispose();
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
            
            DirectoryInfo tournamentsToLoadPath = new DirectoryInfo(cashGameConfig.tournamentSummaryPath);
           
            if (tournamentsToLoadPath.GetFiles().Count() > 0)
            {
                this.prgBar.Maximum = tournamentsToLoadPath.GetFiles().Count();
                this.prgBar.Value = 0;
                this.prgBar.Visible = true;
            }

            foreach (FileInfo file in tournamentsToLoadPath.GetFiles())
            {
                this.prgBar.Value++;
                if (handLoader.LoadTournamentSummary(file))
                    handLoader.Backup(file);
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
                if (handLoader.LoadTournamentHandHistory(file))
                    handLoader.Backup(file);
            }

            this.prgBar.Visible = false;

            LoadTournamentsIntoGrid();
        }

        private void gridTournaments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (e.RowIndex < senderGrid.Rows.Count - 1)
                {
                    if (senderGrid[8, e.RowIndex].Value.ToString() == "Hands")
                    {
                        HandViewer handViewer = new HandViewer();
                        handViewer.OpenTournament(senderGrid[0, e.RowIndex].Value.ToString());
                    }                        
                }
            }
        }        
    }
}
