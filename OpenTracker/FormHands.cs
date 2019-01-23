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
    public partial class FormHands : Form
    {
        private Players playersGettter = new Players();
        private Hands handsGetter = new Hands();
        private int heroIdPlayer = 0;
        public int idSession = 0;

        public FormHands()
        {
            LoadForm();
        }

        public FormHands(int idSession)
        {
            this.idSession = idSession;
            LoadForm();
        }

        private void LoadForm()
        {
            InitializeComponent();
            heroIdPlayer = playersGettter.GetHeroID();
            LoadHandsIntoGrid(1, heroIdPlayer);
            LoadPlayersIntoComboBox();
            RefreshNavigationButtons(1);
        }

        private void RefreshNavigationButtons(int page)
        {
            if (page == 1)
                this.txtMaxPages.Text = handsGetter.GetMaxPages(Convert.ToInt32(this.cboPlayer.SelectedValue), this.txtFilteredHands.Text, this.idSession).ToString();
            this.txtPage.Text = page.ToString();
            this.btnFirst.Enabled = page > 1;
            this.btnPrevious.Enabled = page > 1;
            this.btnNext.Enabled = (Convert.ToInt32(this.txtMaxPages.Text) > page);
            this.btnLast.Enabled = this.btnNext.Enabled;
        }

        private void LoadPlayersIntoComboBox()
        {
            List<Players> listPlayers = new List<Players>();
            listPlayers = playersGettter.GetAllPlayers(this.idSession);

            this.cboPlayer.DataSource = listPlayers;
            this.cboPlayer.ValueMember = "IDPlayer";
            this.cboPlayer.DisplayMember = "Nickname";
            this.cboPlayer.SelectedValue = heroIdPlayer;
        }

        private void LoadHandsIntoGrid(int page, int idPlayer)
        {
            List<HandView> listHandView = new List<HandView>();            
            Images imageGetter = new Images();

            listHandView = handsGetter.GetAllHands(page, idPlayer, this.txtFilteredHands.Text, this.idSession);
            
            int counter = 0;
            foreach (HandView handView in listHandView)
            {
                this.dgvHands.Rows.Add(handView.IDHand.ToString(),                                       
                                       new Bitmap(imageGetter.GetImageResource(handView.CardOne), 60, 80),
                                       new Bitmap(imageGetter.GetImageResource(handView.CardTwo), 60, 80),
                                       handView.NetWon);
                this.dgvHands.Rows[counter].Height = 80;
                counter++;
            }

        }

        private void FilterResults(int page)
        {
            this.dgvHands.Rows.Clear();
            LoadHandsIntoGrid(page, Convert.ToInt32(cboPlayer.SelectedValue));
            RefreshNavigationButtons(page);
        }

        private void btnFilterHands_Click(object sender, EventArgs e)
        {            
            FormFilterHands formFilterHands = new FormFilterHands();

            formFilterHands.txtFilterHands.Text = this.txtFilteredHands.Text;
            formFilterHands.FillButtons();
            formFilterHands.ShowDialog();
            bool changedFilter = this.txtFilteredHands.Text != formFilterHands.txtFilterHands.Text;
            this.txtFilteredHands.Text = formFilterHands.txtFilterHands.Text;
            formFilterHands.Dispose();

            if (changedFilter)
                FilterResults(1);
        }

        private void cboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPlayer.SelectedValue is Int32)
                FilterResults(1);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            FilterResults(1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            FilterResults(Convert.ToInt32(this.txtPage.Text) - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FilterResults(Convert.ToInt32(this.txtPage.Text) + 1);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            FilterResults(Convert.ToInt32(this.txtMaxPages.Text));
        }

        private void dgvHands_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (e.RowIndex < senderGrid.Rows.Count - 1)
                {
                    HandViewer handViewer = new HandViewer();
                    handViewer.idHand = Convert.ToDouble(senderGrid[0, e.RowIndex].Value);
                    handViewer.OpenHand();
                }
            }
        }
    }
}
