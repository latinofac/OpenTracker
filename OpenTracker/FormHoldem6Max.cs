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
    public partial class FormHoldem6Max : Form
    {
        public double idHand;
        private List<HandPlayers> listHandPlayers = new List<HandPlayers>();
        private List<Actions> listActions = new List<Actions>();
        private HandPlayers handPlayersGetter = new HandPlayers();
        private Actions actionsGetter = new Actions();
        private Actions[] actions = null;
        private int orderHand = 0;
        private List<Cards> listCards = new List<Cards>();
        private Images imageGetter = new Images();
        private int handMoment = 0;
        private string[] potsPreFlop = new string[6];
        private string[] potsPreTurn = new string[6];
        private string[] potsPreRiver = new string[6];

        int indexTournamentHand = 0;
        public List<Double> listTournamentHands = new List<double>();

        public FormHoldem6Max()
        {
            InitializeComponent();
        }

        private void RefreshStacks()
        {
            foreach (HandPlayers handPlayers in listHandPlayers)
            {
                switch (handPlayers.Seat)
                {
                    case 1:
                        this.p1.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        break;
                    case 2:
                        this.p2.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        break;
                    case 3:
                        this.p3.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        break;
                    case 4:
                        this.p4.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        break;
                    case 5:
                        this.p5.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        break;
                    case 6:
                        this.p6.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        break;
                    default:
                        break;
                }
            }
        }

        private void PutMoneyInPot(Actions action)
        {
            double PreviousBet = 0;
            listHandPlayers.Where(x => x.IDPlayer == action.IDPlayer).FirstOrDefault().InitialStack = listHandPlayers.Where(x => x.IDPlayer == action.IDPlayer).FirstOrDefault().InitialStack - action.Value;

            if (this.idPlayer1.Text == action.IDPlayer.ToString())
            {
                if (this.bet1.Text != "")
                    PreviousBet = Convert.ToDouble(this.bet1.Text.Substring(2, this.bet1.Text.Length -2));
                this.bet1.Text = "$ " + (action.Value + PreviousBet).ToString();
            }
            if (this.idPlayer2.Text == action.IDPlayer.ToString())
            {
                if (this.bet2.Text != "")
                    PreviousBet = Convert.ToDouble(this.bet2.Text.Substring(2, this.bet2.Text.Length - 2));
                this.bet2.Text = "$ " + (action.Value + PreviousBet).ToString();
            }
            if (this.idPlayer3.Text == action.IDPlayer.ToString())
            {
                if (this.bet3.Text != "")
                    PreviousBet = Convert.ToDouble(this.bet3.Text.Substring(2, this.bet3.Text.Length - 2));
                this.bet3.Text = "$ " + (action.Value + PreviousBet).ToString();
            }
            if (this.idPlayer4.Text == action.IDPlayer.ToString())
            {
                if (this.bet4.Text != "")
                    PreviousBet = Convert.ToDouble(this.bet4.Text.Substring(2, this.bet4.Text.Length - 2));
                this.bet4.Text = "$ " + (action.Value + PreviousBet).ToString();
            }
            if (this.idPlayer5.Text == action.IDPlayer.ToString())
            {
                if (this.bet5.Text != "")
                    PreviousBet = Convert.ToDouble(this.bet5.Text.Substring(2, this.bet5.Text.Length - 2));
                this.bet5.Text = "$ " + (action.Value + PreviousBet).ToString();
            }
            if (this.idPlayer6.Text == action.IDPlayer.ToString())
            {
                if (this.bet6.Text != "")
                    PreviousBet = Convert.ToDouble(this.bet6.Text.Substring(2, this.bet6.Text.Length - 2));
                this.bet6.Text = "$ " + (action.Value + PreviousBet).ToString();
            }

            if (this.pot.Text != "")
                this.pot.Text = "$ " + (Convert.ToDouble(this.pot.Text.Substring(2, this.pot.Text.Length - 2)) + action.Value).ToString();
            else
                this.pot.Text = "$ " + action.Value.ToString();

            RefreshStacks();
        }

        private void FoldHand(Actions action)
        {
            if (this.idPlayer1.Text == action.IDPlayer.ToString())
            {
                this.p1c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
                this.p1c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            }
            if (this.idPlayer2.Text == action.IDPlayer.ToString())
            {
                this.p2c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
                this.p2c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            }
            if (this.idPlayer3.Text == action.IDPlayer.ToString())
            {
                this.p3c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
                this.p3c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            }
            if (this.idPlayer4.Text == action.IDPlayer.ToString())
            {
                this.p4c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
                this.p4c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            }
            if (this.idPlayer5.Text == action.IDPlayer.ToString())
            {
                this.p5c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
                this.p5c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            }
            if (this.idPlayer6.Text == action.IDPlayer.ToString())
            {
                this.p6c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
                this.p6c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            }
        }

        private void CheckHand(Actions action)
        {
            //TO IMPLEMENT BORDER
        }

        private void RunAction(Actions action)
        {
            switch (action.Action)
            {
                case -1:
                    PutMoneyInPot(action); //Blinds
                    break;
                case 1:
                    FoldHand(action); //Fold
                    break;
                case 2:
                    PutMoneyInPot(action); //Call
                    break;
                case 3:
                    PutMoneyInPot(action); //Bet or Raise
                    break;
                case 4:
                    CheckHand(action);
                    break;
                default:
                    break;
            }

            if (orderHand + 1 < actions.Count())
                SetBorder(orderHand + 1);
        }

        private void SetBorder(int nextToPlay)
        {
            this.border1.Visible = this.idPlayer1.Text == actions[nextToPlay].IDPlayer.ToString();
            this.border2.Visible = this.idPlayer2.Text == actions[nextToPlay].IDPlayer.ToString();
            this.border3.Visible = this.idPlayer3.Text == actions[nextToPlay].IDPlayer.ToString();
            this.border4.Visible = this.idPlayer4.Text == actions[nextToPlay].IDPlayer.ToString();
            this.border5.Visible = this.idPlayer5.Text == actions[nextToPlay].IDPlayer.ToString();
            this.border6.Visible = this.idPlayer6.Text == actions[nextToPlay].IDPlayer.ToString();
        }

        internal void RunBlindsAndAntes()
        {
            foreach (Actions action in listActions)
            {
                if (action.Action == -1)
                    RunAction(action);
            }
        }

        internal void PlaceCard(int seat, string card)
        {
            switch (seat)
            {
                case 1:
                    if (this.p1c1.Tag == null)
                    {
                        this.p1c1.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p1c1.Tag = card;
                    }
                    else
                    {
                        this.p1c2.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p1c2.Tag = card;
                    }
                    break;
                case 2:
                    if (this.p2c1.Tag == null)
                    {
                        this.p2c1.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p2c1.Tag = card;
                    }
                    else
                    {
                        this.p2c2.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p2c2.Tag = card;
                    }
                    break;
                case 3:
                    if (this.p3c1.Tag == null)
                    {
                        this.p3c1.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p3c1.Tag = card;
                    }
                    else
                    {
                        this.p3c2.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p3c2.Tag = card;
                    }
                    break;
                case 4:
                    if (this.p4c1.Tag == null)
                    {
                        this.p4c1.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p4c1.Tag = card;
                    }
                    else
                    {
                        this.p4c2.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p4c2.Tag = card;
                    }
                    break;
                case 5:
                    if (this.p5c1.Tag == null)
                    {
                        this.p5c1.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p5c1.Tag = card;
                    }
                    else
                    {
                        this.p5c2.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p5c2.Tag = card;
                    }
                    break;
                case 6:
                    if (this.p6c1.Tag == null)
                    {
                        this.p6c1.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p6c1.Tag = card;
                    }
                    else
                    {
                        this.p6c2.Image = new Bitmap(imageGetter.GetImageResource(card), 31, 44);
                        this.p6c2.Tag = card;
                    }
                    break;
                default:
                    break;
            }
        }

        internal void SetHoleCards()
        {
            Cards cardsGetter = new Cards();
            listCards = cardsGetter.GetCards(idHand);

            foreach (Cards card in listCards)
            {
                if (this.idPlayer1.Text != "" && card.IDPlayer == Convert.ToInt32(this.idPlayer1.Text))
                    PlaceCard(1, card.Card);
                if (this.idPlayer2.Text != "" && card.IDPlayer == Convert.ToInt32(this.idPlayer2.Text))
                    PlaceCard(2, card.Card);
                if (this.idPlayer3.Text != "" && card.IDPlayer == Convert.ToInt32(this.idPlayer3.Text))
                    PlaceCard(3, card.Card);
                if (this.idPlayer4.Text != "" && card.IDPlayer == Convert.ToInt32(this.idPlayer4.Text))
                    PlaceCard(4, card.Card);
                if (this.idPlayer5.Text != "" && card.IDPlayer == Convert.ToInt32(this.idPlayer5.Text))
                    PlaceCard(5, card.Card);
                if (this.idPlayer6.Text != "" && card.IDPlayer == Convert.ToInt32(this.idPlayer6.Text))
                    PlaceCard(6, card.Card);
            }
        }

        internal void SeatPlayers()
        {
            foreach (HandPlayers handPlayers in listHandPlayers)
            {
                switch (handPlayers.Seat)
                {
                    case 1:
                        this.p1.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        this.idPlayer1.Text = handPlayers.IDPlayer.ToString();
                        this.p1c1.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        this.p1c2.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        break;
                    case 2:
                        this.p2.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        this.idPlayer2.Text = handPlayers.IDPlayer.ToString();
                        this.p2c1.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        this.p2c2.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        break;
                    case 3:
                        this.p3.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        this.idPlayer3.Text = handPlayers.IDPlayer.ToString();
                        this.p3c1.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        this.p3c2.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        break;
                    case 4:
                        this.p4.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        this.idPlayer4.Text = handPlayers.IDPlayer.ToString();
                        this.p4c1.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        this.p4c2.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        break;
                    case 5:
                        this.p5.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        this.idPlayer5.Text = handPlayers.IDPlayer.ToString();
                        this.p5c1.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        this.p5c2.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        break;
                    case 6:
                        this.p6.Text = handPlayers.Nickname + " - $" + handPlayers.InitialStack;
                        this.idPlayer6.Text = handPlayers.IDPlayer.ToString();
                        this.p6c1.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        this.p6c2.Image = new Bitmap(OpenTracker.Properties.Resources.redCard, 31, 44);
                        break;
                    default:
                        break;
                }
            }
        }

        internal void LoadHand()
        {
            listHandPlayers = handPlayersGetter.GetPlayersInHand(idHand);
            listActions = actionsGetter.GetActions(idHand);

            actions = new Actions[listActions.Where(x => x.Action != -1).Count()];
            foreach (Actions action in listActions.Where(x => x.Action != -1))
            {
                actions[orderHand] = action;
                orderHand++;
            }
        }

        internal void ClearTable()
        {
            this.btnNext.Enabled = true;
            this.btnPrev.Enabled = false;

            this.btn1.Visible = false;
            this.btn2.Visible = false;
            this.btn3.Visible = false;
            this.btn4.Visible = false;
            this.btn5.Visible = false;
            this.btn6.Visible = false;

            this.p1c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p1c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p2c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p2c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p3c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p3c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p4c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p4c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p5c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p5c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p6c1.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);
            this.p6c2.Image = new Bitmap(OpenTracker.Properties.Resources.whiteCard, 31, 44);

            this.p1c1.Tag = null;
            this.p2c1.Tag = null;
            this.p3c1.Tag = null;
            this.p4c1.Tag = null;
            this.p5c1.Tag = null;
            this.p6c1.Tag = null;

            this.border1.Visible = false;
            this.border2.Visible = false;
            this.border3.Visible = false;
            this.border4.Visible = false;
            this.border5.Visible = false;
            this.border6.Visible = false;

            this.p1.Text = "";
            this.p2.Text = "";
            this.p3.Text = "";
            this.p4.Text = "";
            this.p5.Text = "";
            this.p6.Text = "";

            this.bet1.Text = "";
            this.bet2.Text = "";
            this.bet3.Text = "";
            this.bet4.Text = "";
            this.bet5.Text = "";
            this.bet6.Text = "";

            this.idPlayer1.Text = "";
            this.idPlayer2.Text = "";
            this.idPlayer3.Text = "";
            this.idPlayer4.Text = "";
            this.idPlayer5.Text = "";
            this.idPlayer6.Text = "";

            this.pot.Text = "";

            this.c1.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
            this.c2.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
            this.c3.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
            this.c4.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
            this.c5.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
        }

        internal void SetTheFirstToTalk()
        {
            SetBorder(0);
        }

        private void SetTheLastToTalk()
        {
            Dictionary<PictureBox, Label> listBorders = new Dictionary<PictureBox, Label>();
            int idPlayerUTG = listActions.Where(x => x.Action != -1).First().IDPlayer;

            if (idPlayerUTG.ToString() == this.idPlayer1.Text)
            {
                listBorders.Add(this.btn4, this.p4);
                listBorders.Add(this.btn3, this.p3);
                listBorders.Add(this.btn2, this.p2);
                listBorders.Add(this.btn1, this.p1);
                listBorders.Add(this.btn6, this.p6);
                listBorders.Add(this.btn5, this.p5);
            }

            if (idPlayerUTG.ToString() == this.idPlayer2.Text)
            {
                listBorders.Add(this.btn5, this.p5);
                listBorders.Add(this.btn4, this.p4);
                listBorders.Add(this.btn3, this.p3);
                listBorders.Add(this.btn2, this.p2);
                listBorders.Add(this.btn1, this.p1);
                listBorders.Add(this.btn6, this.p6);
            }

            if (idPlayerUTG.ToString() == this.idPlayer3.Text)
            {
                listBorders.Add(this.btn6, this.p6);
                listBorders.Add(this.btn5, this.p5);
                listBorders.Add(this.btn4, this.p4);
                listBorders.Add(this.btn3, this.p3);
                listBorders.Add(this.btn2, this.p2);
                listBorders.Add(this.btn1, this.p1);                
            }

            if (idPlayerUTG.ToString() == this.idPlayer4.Text)
            {
                listBorders.Add(this.btn1, this.p1);
                listBorders.Add(this.btn6, this.p6);
                listBorders.Add(this.btn5, this.p5);
                listBorders.Add(this.btn4, this.p4);
                listBorders.Add(this.btn3, this.p3);
                listBorders.Add(this.btn2, this.p2);                
            }

            if (idPlayerUTG.ToString() == this.idPlayer5.Text)
            {
                listBorders.Add(this.btn2, this.p2);
                listBorders.Add(this.btn1, this.p1);
                listBorders.Add(this.btn6, this.p6);
                listBorders.Add(this.btn5, this.p5);
                listBorders.Add(this.btn4, this.p4);
                listBorders.Add(this.btn3, this.p3);               
            }

            if (idPlayerUTG.ToString() == this.idPlayer6.Text)
            {
                listBorders.Add(this.btn3, this.p3);
                listBorders.Add(this.btn2, this.p2);
                listBorders.Add(this.btn1, this.p1);
                listBorders.Add(this.btn6, this.p6);
                listBorders.Add(this.btn5, this.p5);
                listBorders.Add(this.btn4, this.p4);                
            }

            foreach (KeyValuePair<PictureBox, Label> entry in listBorders)
            {
                if (entry.Value.Text != "")
                {
                    entry.Key.Visible = true;
                    break;
                }
            }
        }

        internal void ClearParameters()
        {
            listHandPlayers = new List<HandPlayers>();
            listActions = new List<Actions>();
            handPlayersGetter = new HandPlayers();
            actionsGetter = new Actions();
            actions = null;
            orderHand = 0;
            listCards = new List<Cards>();
            imageGetter = new Images();
            handMoment = 0;
            potsPreFlop = new string[6];
            potsPreTurn = new string[6];
            potsPreRiver = new string[6];
        }

        internal void InitialSetup()
        {
            ClearParameters();
            ClearTable();
            LoadHand();
            SeatPlayers();
            SetHoleCards();
            RunBlindsAndAntes();
            SetTheFirstToTalk();
            SetTheLastToTalk();
            orderHand = 0;
        }

        private void TurnFlop()
        {
            this.c1.Image = new Bitmap(imageGetter.GetImageResource(listCards.Where(y => y.IDPlayer == -1).FirstOrDefault().Card), 53, 76);
            this.c1.Image.Tag = "Flop";
            this.c2.Image = new Bitmap(imageGetter.GetImageResource(listCards.Where(y => y.IDPlayer == -2).FirstOrDefault().Card), 53, 76);
            this.c2.Image.Tag = "Flop";
            this.c3.Image = new Bitmap(imageGetter.GetImageResource(listCards.Where(y => y.IDPlayer == -3).FirstOrDefault().Card), 53, 76);
            this.c3.Image.Tag = "Flop";

            potsPreFlop[0] = this.bet1.Text;
            potsPreFlop[1] = this.bet2.Text;
            potsPreFlop[2] = this.bet3.Text;
            potsPreFlop[3] = this.bet4.Text;
            potsPreFlop[4] = this.bet5.Text;
            potsPreFlop[5] = this.bet6.Text;
            
            this.bet1.Text = "";
            this.bet2.Text = "";
            this.bet3.Text = "";
            this.bet4.Text = "";
            this.bet5.Text = "";
            this.bet6.Text = "";
        }

        private void TurnTurn()
        {
            this.c4.Image = new Bitmap(imageGetter.GetImageResource(listCards.Where(y => y.IDPlayer == -4).FirstOrDefault().Card), 53, 76);
            this.c4.Image.Tag = "Turn";

            potsPreTurn[0] = this.bet1.Text;
            potsPreTurn[1] = this.bet2.Text;
            potsPreTurn[2] = this.bet3.Text;
            potsPreTurn[3] = this.bet4.Text;
            potsPreTurn[4] = this.bet5.Text;
            potsPreTurn[5] = this.bet6.Text;
            
            this.bet1.Text = "";
            this.bet2.Text = "";
            this.bet3.Text = "";
            this.bet4.Text = "";
            this.bet5.Text = "";
            this.bet6.Text = "";
        }

        private void TurnRiver()
        {
            this.c5.Image = new Bitmap(imageGetter.GetImageResource(listCards.Where(y => y.IDPlayer == -5).FirstOrDefault().Card), 53, 76);
            this.c5.Image.Tag = "River";

            potsPreRiver[0] = this.bet1.Text;
            potsPreRiver[1] = this.bet2.Text;
            potsPreRiver[2] = this.bet3.Text;
            potsPreRiver[3] = this.bet4.Text;
            potsPreRiver[4] = this.bet5.Text;
            potsPreRiver[5] = this.bet6.Text;
            
            this.bet1.Text = "";
            this.bet2.Text = "";
            this.bet3.Text = "";
            this.bet4.Text = "";
            this.bet5.Text = "";
            this.bet6.Text = "";
        }

        private void TurnCards()
        {
            if (orderHand >= actions.Length)
            {
                if (this.c1.Image.Tag == null)
                    TurnFlop();
                else if (this.c4.Image.Tag == null)
                    TurnTurn();
                else if (this.c5.Image.Tag == null)
                    TurnRiver();

                orderHand++;
            }
            else
            {
                switch (actions[orderHand].HandMoment)
                {
                    case 1:
                        TurnFlop();
                        break;
                    case 2:
                        TurnTurn();
                        break;
                    case 3:
                        TurnRiver();
                        break;
                    default:
                        break;
                }

                handMoment = actions[orderHand].HandMoment;
            }
        }

        private bool doesItHasCardsToTurn()
        {
            bool thereAreCardsToTurn = false;

            foreach (Cards card in listCards)
            {
                if (card.IDPlayer == -1 && this.c1.Image.Tag == null)
                    thereAreCardsToTurn = true;
                if (card.IDPlayer == -4 && this.c4.Image.Tag == null)
                    thereAreCardsToTurn = true;
                if (card.IDPlayer == -5 && this.c5.Image.Tag == null)
                    thereAreCardsToTurn = true;
            }
            return thereAreCardsToTurn;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {            
            this.btnPrev.Enabled = true;            

            if (handMoment == -1)
                TurnCards();
            else
            {
                RunAction(actions[orderHand]);
                orderHand++;
            }

            if (orderHand >= actions.Length)
            {
                if (doesItHasCardsToTurn())
                    handMoment = -1;
                else
                {
                    this.btnNext.Enabled = false;                    
                }
            }
            else if (actions[orderHand].HandMoment != handMoment)
                handMoment = -1;           
        }

        private void UnCheckHand(Actions action)
        {
            //TO IMPLEMENT BORDER
        }

        private void UnFoldHand(Actions action)
        {
            List<Cards> playerCards = listCards.Where(x => x.IDPlayer == action.IDPlayer).ToList();
            string cardOne = "redCard";
            string cardTwo = "redCard";
           
            if (playerCards.Count() > 0)
            {
                foreach (Cards card in playerCards)
                {
                    if (cardOne == "redCard")
                        cardOne = card.Card;
                    else
                        cardTwo = card.Card;
                }
            }

            if (this.idPlayer1.Text == action.IDPlayer.ToString())
            {
                this.p1c1.Image = new Bitmap(imageGetter.GetImageResource(cardOne), 31, 44);
                this.p1c2.Image = new Bitmap(imageGetter.GetImageResource(cardTwo), 31, 44);

            }
            if (this.idPlayer2.Text == action.IDPlayer.ToString())
            {
                this.p2c1.Image = new Bitmap(imageGetter.GetImageResource(cardOne), 31, 44);
                this.p2c2.Image = new Bitmap(imageGetter.GetImageResource(cardTwo), 31, 44);
            }
            if (this.idPlayer3.Text == action.IDPlayer.ToString())
            {
                this.p3c1.Image = new Bitmap(imageGetter.GetImageResource(cardOne), 31, 44);
                this.p3c2.Image = new Bitmap(imageGetter.GetImageResource(cardTwo), 31, 44);
            }
            if (this.idPlayer4.Text == action.IDPlayer.ToString())
            {
                this.p4c1.Image = new Bitmap(imageGetter.GetImageResource(cardOne), 31, 44);
                this.p4c2.Image = new Bitmap(imageGetter.GetImageResource(cardTwo), 31, 44);
            }
            if (this.idPlayer5.Text == action.IDPlayer.ToString())
            {
                this.p5c1.Image = new Bitmap(imageGetter.GetImageResource(cardOne), 31, 44);
                this.p5c2.Image = new Bitmap(imageGetter.GetImageResource(cardTwo), 31, 44);
            }
            if (this.idPlayer6.Text == action.IDPlayer.ToString())
            {
                this.p6c1.Image = new Bitmap(imageGetter.GetImageResource(cardOne), 31, 44);
                this.p6c2.Image = new Bitmap(imageGetter.GetImageResource(cardTwo), 31, 44);
            }
        }

        private void RemoveMoneyFromPot(Actions action)
        {
            double whatIsLeft;
            listHandPlayers.Where(x => x.IDPlayer == action.IDPlayer).FirstOrDefault().InitialStack = listHandPlayers.Where(x => x.IDPlayer == action.IDPlayer).FirstOrDefault().InitialStack + action.Value;

            if (this.idPlayer1.Text == action.IDPlayer.ToString())
            {
                whatIsLeft = Convert.ToDouble(this.bet1.Text.Substring(2, this.bet1.Text.Length - 2)) - action.Value;
                if (whatIsLeft > 0)
                    this.bet1.Text = "$ " + whatIsLeft.ToString();
                else
                    this.bet1.Text = "";
            }
            if (this.idPlayer2.Text == action.IDPlayer.ToString())
            {
                whatIsLeft = Convert.ToDouble(this.bet2.Text.Substring(2, this.bet2.Text.Length - 2)) - action.Value;
                if (whatIsLeft > 0)
                    this.bet2.Text = "$ " + whatIsLeft.ToString();
                else
                    this.bet2.Text = "";
            }
            if (this.idPlayer3.Text == action.IDPlayer.ToString())
            {
                whatIsLeft = Convert.ToDouble(this.bet3.Text.Substring(2, this.bet3.Text.Length - 2)) - action.Value;
                if (whatIsLeft > 0)
                    this.bet3.Text = "$ " + whatIsLeft.ToString();
                else
                    this.bet3.Text = "";
            }
            if (this.idPlayer4.Text == action.IDPlayer.ToString())
            {
                whatIsLeft = Convert.ToDouble(this.bet4.Text.Substring(2, this.bet4.Text.Length - 2)) - action.Value;
                if (whatIsLeft > 0)
                    this.bet4.Text = "$ " + whatIsLeft.ToString();
                else
                    this.bet4.Text = "";
            }
            if (this.idPlayer5.Text == action.IDPlayer.ToString())
            {
                whatIsLeft = Convert.ToDouble(this.bet5.Text.Substring(2, this.bet5.Text.Length - 2)) - action.Value;
                if (whatIsLeft > 0)
                    this.bet5.Text = "$ " + whatIsLeft.ToString();
                else
                    this.bet5.Text = "";
            }
            if (this.idPlayer6.Text == action.IDPlayer.ToString())
            {
                whatIsLeft = Convert.ToDouble(this.bet6.Text.Substring(2, this.bet6.Text.Length - 2)) - action.Value;
                if (whatIsLeft > 0)
                    this.bet6.Text = "$ " + whatIsLeft.ToString();
                else
                    this.bet6.Text = "";
            }

            whatIsLeft = (Convert.ToDouble(this.pot.Text.Substring(2, this.pot.Text.Length - 2)) - action.Value);
            if (whatIsLeft > 0)
                this.pot.Text = "$ " + whatIsLeft.ToString();
            else
                this.pot.Text = "";

            RefreshStacks();
        }

        private void RevertAction(Actions action)
        {
            switch (action.Action)
            {
                case -1:
                    RemoveMoneyFromPot(action); //Blinds
                    break;
                case 1:
                    UnFoldHand(action); //Fold
                    break;
                case 2:
                    RemoveMoneyFromPot(action); //Call
                    break;
                case 3:
                    RemoveMoneyFromPot(action); //Bet or Raise
                    break;
                case 4:
                    UnCheckHand(action);
                    break;
                default:
                    break;
            }

            if (orderHand >= 0)
                SetBorder(orderHand);
        }

        private void ClearBorders()
        {
            this.border1.Visible = false;
            this.border2.Visible = false;
            this.border3.Visible = false;
            this.border4.Visible = false;
            this.border5.Visible = false;
            this.border6.Visible = false;
        }

        private void UnTurnFlop()
        {
            this.c1.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
            this.c2.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);
            this.c3.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);

            this.bet1.Text = potsPreFlop[0];
            this.bet2.Text = potsPreFlop[1];
            this.bet3.Text = potsPreFlop[2];
            this.bet4.Text = potsPreFlop[3];
            this.bet5.Text = potsPreFlop[4];
            this.bet6.Text = potsPreFlop[5];
        }

        private void UnTurnTurn()
        {
            this.c4.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);

            this.bet1.Text = potsPreTurn[0];
            this.bet2.Text = potsPreTurn[1];
            this.bet3.Text = potsPreTurn[2];
            this.bet4.Text = potsPreTurn[3];
            this.bet5.Text = potsPreTurn[4];
            this.bet6.Text = potsPreTurn[5];
        }

        private void UnTurnRiver()
        {
            this.c5.Image = new Bitmap(OpenTracker.Properties.Resources.greenCard, 53, 76);

            this.bet1.Text = potsPreRiver[0];
            this.bet2.Text = potsPreRiver[1];
            this.bet3.Text = potsPreRiver[2];
            this.bet4.Text = potsPreRiver[3];
            this.bet5.Text = potsPreRiver[4];
            this.bet6.Text = potsPreRiver[5];
        }

        private void UnTurnCards()
        {
            if (this.c5.Image.Tag != null && this.c5.Image.Tag.ToString() == "River")
            {
                UnTurnRiver();
                handMoment = 2;
            }
            else if (this.c4.Image.Tag != null && this.c4.Image.Tag.ToString() == "Turn")
            {
                UnTurnTurn();
                handMoment = 1;
            }
            else if (this.c1.Image.Tag != null && this.c1.Image.Tag.ToString() == "Flop")
            {
                UnTurnFlop();
                handMoment = 0;
            }

            ClearBorders();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.btnNext.Enabled = true;

            if (orderHand >= actions.Count() && handMoment == -1)
            {
                UnTurnCards();
                orderHand--;
            }
            else if (orderHand == actions.Count())
            {
                orderHand--;
                RevertAction(actions[orderHand]);
            }
            else if (actions[orderHand - 1].HandMoment < handMoment || handMoment == -1)                
                UnTurnCards();
            else
            {
                orderHand--;
                RevertAction(actions[orderHand]);
            }

            if (orderHand == 0)
                this.btnPrev.Enabled = false;
                        
        }

        private void btnNextHand_Click(object sender, EventArgs e)
        {
            this.indexTournamentHand++;
            this.idHand = listTournamentHands[indexTournamentHand];

            this.btnNextHand.Enabled = listTournamentHands.Count() > indexTournamentHand + 1;
            this.btnPreviousHand.Enabled = true;

            this.InitialSetup();
        }

        private void btnPreviousHand_Click(object sender, EventArgs e)
        {
            this.indexTournamentHand--;
            this.idHand = listTournamentHands[indexTournamentHand];

            this.btnNextHand.Enabled = true;
            this.btnPreviousHand.Enabled = indexTournamentHand > 0;

            this.InitialSetup();
        }
    }
}
