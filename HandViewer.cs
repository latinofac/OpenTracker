using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTracker
{
    class HandViewer
    {
        public double idHand;
        private HandGames handGames = new HandGames();        

        internal void OpenHand()
        {
            handGames.GetGame(idHand);

            if (handGames.idGame == 1 || handGames.idGame == 3)
            {
                FormHoldem6Max formHandViewer = new FormHoldem6Max();
                formHandViewer.idHand = idHand;
                formHandViewer.InitialSetup();
                formHandViewer.ShowDialog();
                formHandViewer.Dispose();
            }
            else
            {
                FormHoldem9Max formHandViewer = new FormHoldem9Max();
                formHandViewer.idHand = idHand;
                formHandViewer.InitialSetup();
                formHandViewer.ShowDialog();
                formHandViewer.Dispose();
            }
        }

        internal void OpenTournament(string idTournament)
        {
            Tournaments tournament = new Tournaments();
            tournament.GetTournamentById(Convert.ToDouble(idTournament));

            List<Double> listHands = new List<Double>();
            listHands = tournament.GetAllHands();

            if (tournament.IdGame == 1 || tournament.IdGame == 3)
            {
                FormHoldem6Max formHandViewer = new FormHoldem6Max();
                formHandViewer.listTournamentHands = listHands;
                formHandViewer.idHand = listHands.First();
                formHandViewer.btnNextHand.Visible = listHands.Count() > 0;
                formHandViewer.btnPreviousHand.Visible = listHands.Count() > 0;
                formHandViewer.btnPreviousHand.Enabled = false;
                formHandViewer.InitialSetup();
                formHandViewer.ShowDialog();
                formHandViewer.Dispose();
            }
            else
            {
                FormHoldem9Max formHandViewer = new FormHoldem9Max();
                formHandViewer.listTournamentHands = listHands;
                formHandViewer.idHand = listHands.First();
                formHandViewer.btnNextHand.Visible = listHands.Count() > 0;
                formHandViewer.btnPreviousHand.Visible = listHands.Count() > 0;
                formHandViewer.btnPreviousHand.Enabled = false;
                formHandViewer.InitialSetup();
                formHandViewer.ShowDialog();
                formHandViewer.Dispose();
            }
        }        
    }
}
