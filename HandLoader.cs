using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class HandLoader
    {
        private SQL sql = new SQL();

        public void Backup(FileInfo file)
        {
            Config configGetter = new Config();
            string backupPath = configGetter.GetBackupPath();
            if (!File.Exists(backupPath + file.Name))
                file.MoveTo(backupPath + "\\" + file.Name);
        }

        private bool IsAValidGame(string line)
        {
            return line.IndexOf("Hold'em No Limit") > 0;
        }

        private bool IsForRealMoney(string line)
        {
            return line.IndexOf("($") > 0;
        }

        private bool IsRealMoneyTourney(string line)
        {
            return line.IndexOf(", $") > 0;
        }

        public bool LoadCashSession(FileInfo file)
        {
            bool wasItALoadableFile = false;
            string[] lines = System.IO.File.ReadAllLines(file.FullName);

            Sessions session = new Sessions();
            Hands hand = null;
            HandsSession handsSession = null;
            HandGames handGames = null;
            Players player = null;
            List<Players> listPlayers = null;
            HandPlayers handPlayer = null;
            List<HandPlayers> listHandPlayers = null;
            Cards cards = null;
            Actions action = null;
            List<Actions> listActions = null;

            bool canILoadThisHand = false;
            bool isZoom = false;
            bool arePlayersSeated = false;
            int idPlayerHero = 0;
            int orderHand = 0;
            int handMoment = 0;
            double BigBlind = 0;
            double NetWon = 0;

            int PreFlop = 0;
            int Flop = 1;
            int Turn = 2;
            int River = 3;
            int Blinds = -1;
            int Fold = 1;
            int Call = 2;
            int Raise = 3;
            int Check = 4;

            sql.BeginTransaction();

            foreach (string line in lines)
            {
                //******** HEADER *********
                if (line.Length > 10 && line.Substring(0, 11).ToUpper() == "POKERSTARS ")
                {
                    hand = new Hands();
                    hand.IDHand = Convert.ToDouble(line.Substring(line.IndexOf("#") + 1, line.Length - (line.Length - line.IndexOf(":") - 1) - line.IndexOf("#") - 2));

                    canILoadThisHand = IsAValidGame(line) && IsForRealMoney(line) && hand.AmIANewHand() && !IsTournamentHistory(line);

                    if (canILoadThisHand)
                    {
                        wasItALoadableFile = true;

                        if (session.DateSession == null || session.DateSession == "")
                            session.SetSessionInitialParameters(line);
                        session.TotalHands++;

                        handsSession = new HandsSession();
                        handsSession.IDHand = hand.IDHand;
                        handsSession.IDSession = session.IDSession;
                        handsSession.Insert();

                        hand.Stakes = line.Substring(line.IndexOf("(") + 1, 11);
                        hand.DateHand = line.Substring(line.IndexOf(")") + 12, 2) + line.Substring(line.IndexOf(")") + 9, 2) + line.Substring(line.IndexOf(")") + 4, 4);
                        hand.TimeHand = line.Substring(line.IndexOf(")") + 15, 2) + line.Substring(line.IndexOf(")") + 18, 2) + line.Substring(line.IndexOf(")") + 21, 2);
                        hand.NumPlayers = 0;
                        if (hand.TimeHand[1] == ':')
                            hand.TimeHand = line.Substring(line.IndexOf(")") + 15, 1) + line.Substring(line.IndexOf(")") + 17, 2) + line.Substring(line.IndexOf(")") + 20, 2);
                        hand.Type = "C";

                        arePlayersSeated = false;
                        listPlayers = new List<Players>();
                        orderHand = 0;
                        listActions = new List<Actions>();
                        listHandPlayers = new List<HandPlayers>();

                        isZoom = false;
                        if (line.Substring(11, 4) == "Zoom")
                            isZoom = true;
                    }
                }

                if (canILoadThisHand)
                {
                    //******** SELECTING GAME ***
                    if (line.Length > 6 && line.Substring(0, 7).ToUpper() == "TABLE '")
                    {
                        handGames = new HandGames();
                        handGames.idHand = hand.IDHand;

                        if (line.IndexOf("6-max") > -1 && isZoom)
                            handGames.idGame = 3;
                        if (line.IndexOf("6-max") > -1 && !isZoom)
                            handGames.idGame = 1;
                        if (line.IndexOf("9-max") > -1 && isZoom)
                            handGames.idGame = 4;
                        if (line.IndexOf("9-max") > -1 && !isZoom)
                            handGames.idGame = 2;

                        handGames.Insert();
                    }

                    //******** SEATINGS *********
                    if (line.Length > 4 && line.Substring(0, 5).ToUpper() == "SEAT " && arePlayersSeated == false)
                    {
                        hand.NumPlayers++;

                        player = new Players();
                        player.Nickname = line.Substring(line.IndexOf(": ") + 2, line.IndexOf("($") - line.IndexOf(": ") - 3);
                        player.FindByNick();

                        if (player.IDPlayer == 0) player.Insert();
                        else player.UpdateTotalHands();

                        listPlayers.Add(player);

                        handPlayer = new HandPlayers();
                        handPlayer.IDHand = hand.IDHand;
                        handPlayer.IDPlayer = player.IDPlayer;
                        handPlayer.Seat = hand.NumPlayers;
                        handPlayer.InitialStack = Convert.ToDouble(line.Substring(line.IndexOf(" ($") + 3, line.Length - line.IndexOf(" ($") - 3 - 11));
                        handPlayer.PreviousBet = 0;
                        handPlayer.BB = 0;
                        handPlayer.VPIP = 0;
                        handPlayer.PFR = 0;
                        
                        listHandPlayers.Add(handPlayer);
                    }

                    //******** HOLE CARDS *********
                    if (line.Length > 8 && line.Substring(0, 9) == "Dealt to ")
                    {
                        arePlayersSeated = true;
                        idPlayerHero = listPlayers.Find(x => x.Nickname == line.Substring(line.IndexOf("Dealt to ") + 9, line.Length - 17)).IDPlayer;

                        cards = new Cards();
                        cards.IDHand = hand.IDHand;
                        cards.AddCard(idPlayerHero, line.Substring(line.IndexOf("[") + 1, 2), 1);
                        cards.AddCard(idPlayerHero, line.Substring(line.IndexOf("[") + 4, 2), 2);
                    }

                    //******** BLINDS AND ANTES *********
                    if (line.Length > 7 && line.IndexOf(": posts ") > 0)
                    {
                        handMoment = PreFlop;

                        orderHand++;
                        action = new Actions();
                        action.IDHand = hand.IDHand;
                        action.OrderHand = orderHand;
                        action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": posts"))).IDPlayer;
                        action.HandMoment = PreFlop;
                        action.Action = Blinds;

                        if (line.IndexOf("posts small & big blinds") > 0)
                        {
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" blinds $") + 9, line.Length - line.IndexOf(" blinds $") - 9));
                        }
                        else if (line.IndexOf("posts the ante") > -1)
                        {
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" the ante $") + 11, line.Length - line.IndexOf(" the ante $") - 11));
                            action.Action = -2;
                        }
                        else
                        {
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" blind $") + 8, line.Length - line.IndexOf(" blind $") - 8));
                        }

                        listActions.Add(action);

                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;

                        if (orderHand == 2)
                        {
                            BigBlind = action.Value;
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB = -1;
                        }
                        if (orderHand == 1)
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB = -0.5;

                        if (line.IndexOf("posts the ante") == -1)
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet = action.Value;
                    }

                    //******** FOLD *********
                    if (line.Length > 6 && line.IndexOf(": folds") > 0)
                    {
                        orderHand++;

                        action = new Actions();
                        action.IDHand = hand.IDHand;
                        action.OrderHand = orderHand;
                        action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": folds"))).IDPlayer;
                        action.HandMoment = handMoment;
                        action.Action = Fold;
                        action.Value = 0;

                        listActions.Add(action);
                    }

                    //******** CALL *********
                    if (line.Length > 7 && line.IndexOf(": calls ") > 0)
                    {
                        orderHand++;

                        action = new Actions();
                        action.IDHand = hand.IDHand;
                        action.OrderHand = orderHand;
                        action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": calls"))).IDPlayer;
                        action.HandMoment = handMoment;
                        action.Action = Call;
                        if (line.IndexOf(" and is all-in") != -1)
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": calls") + 9, line.Length - line.IndexOf(": calls") - 9 - 14));
                        else
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": calls") + 9, line.Length - line.IndexOf(": calls") - 9));

                        listActions.Add(action);

                        if (handMoment == PreFlop)
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer && x.IDHand == action.IDHand).VPIP = 1;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB - (action.Value / BigBlind);
                    }

                    //******** BET *********
                    if (line.Length > 6 && line.IndexOf(": bets ") > 0)
                    {
                        orderHand++;

                        action = new Actions();
                        action.IDHand = hand.IDHand;
                        action.OrderHand = orderHand;
                        action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": bets"))).IDPlayer;
                        action.HandMoment = handMoment;
                        action.Action = Raise;
                        if (handMoment == 0)
                        {
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer && x.IDHand == action.IDHand).VPIP = 1;
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer && x.IDHand == action.IDHand).PFR = 1;
                        }
                        if (line.IndexOf(" and is all-in") != -1)
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": bets") + 8, line.IndexOf(" and is all-in") - line.IndexOf(": bets") - 8));
                        else
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": bets") + 8, line.Length - line.IndexOf(": bets") - 8));

                        listActions.Add(action);

                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB - (action.Value / BigBlind);
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet = action.Value;
                    }

                    //******** RAISE *********
                    if (line.Length > 8 && line.IndexOf(": raises ") > 0)
                    {
                        orderHand++;

                        action = new Actions();
                        action.IDHand = hand.IDHand;
                        action.OrderHand = orderHand;
                        action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": raises"))).IDPlayer;
                        action.HandMoment = handMoment;
                        action.Action = Raise;
                        if (handMoment == 0)
                        {
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).VPIP = 1;
                            listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PFR = 1;
                        }
                        if (line.IndexOf(" and is all-in") != -1)
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" to $") + 5, line.Length - line.IndexOf(" to $") - 19));
                        else
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" to $") + 5, line.Length - line.IndexOf(" to $") - 5));

                        action.Value = action.Value - listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet;

                        listActions.Add(action);

                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet + action.Value;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).BB - (action.Value / BigBlind);
                    }

                    //******** CHECKS *********
                    if (line.Length > 7 && line.IndexOf(": checks") > 0)
                    {
                        orderHand++;

                        action = new Actions();
                        action.IDHand = hand.IDHand;
                        action.OrderHand = orderHand;
                        action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": checks"))).IDPlayer;
                        action.HandMoment = handMoment;
                        action.Action = Check;
                        action.Value = 0;

                        listActions.Add(action);
                    }

                    //******** FLOP *********
                    if (line.Length > 11 && line.Substring(0, 12).ToUpper() == "*** FLOP ***")
                    {
                        handMoment = Flop;

                        cards.IDHand = hand.IDHand;
                        cards.AddCard(-1, line.Substring(14, 2), 0);
                        cards.AddCard(-2, line.Substring(17, 2), 0);
                        cards.AddCard(-3, line.Substring(20, 2), 0);

                        ResetPreviousBets(listHandPlayers);                        
                    }

                    //******** TURN *********
                    if (line.Length > 11 && line.Substring(0, 12).ToUpper() == "*** TURN ***")
                    {
                        handMoment = Turn;

                        cards.AddCard(-4, line.Substring(25, 2), 0);

                        ResetPreviousBets(listHandPlayers);
                    }

                    //******** RIVER *********
                    if (line.Length > 12 && line.Substring(0, 13).ToUpper() == "*** RIVER ***")
                    {
                        handMoment = River;

                        cards.AddCard(-5, line.Substring(29, 2), 0);

                        ResetPreviousBets(listHandPlayers);
                    }

                    //******** COLECTING MONEY *********
                    if (line.Length > 13 && line.IndexOf(") returned to ") > 0)
                    {
                        Players playerWhoWon = listPlayers.Find(y => y.Nickname == line.Substring(line.IndexOf(") returned to ") + 14, line.Length - line.IndexOf(") returned to ") - 14));
                        NetWon = Convert.ToDouble(line.Substring(line.IndexOf("($") + 2, line.IndexOf(") returned to ") - line.IndexOf("($") - 2));
                        listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon + NetWon;
                        listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).BB = listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).BB + (NetWon / BigBlind);
                    }
                    else if (line.Length > 11 && line.IndexOf(" collected $") > 0)
                    {
                        Players playerWhoWon = listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(" collected $")));
                        if (line.IndexOf(" from side pot") > 0 || line.IndexOf(" from main pot") > 0)
                            NetWon = Convert.ToDouble(line.Substring(line.IndexOf(" collected $") + 12, line.Length - line.IndexOf(" collected $") - 26));
                        else
                            NetWon = Convert.ToDouble(line.Substring(line.IndexOf(" collected $") + 12, line.Length - line.IndexOf(" collected $") - 21));

                        listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon + NetWon;
                        listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).BB = listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).BB + (NetWon / BigBlind);
                    }

                    //******** SHOW DOWN *********
                    if (line.Length > 8 && line.IndexOf(": shows [") > 0)
                    {
                        if (listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(": shows ["))).IDPlayer != idPlayerHero)
                        {
                            cards.AddCard(listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(": shows ["))).IDPlayer, line.Substring(line.IndexOf(": shows [") + 9, 2), 1);
                            if (line.Substring(line.IndexOf(": shows [") + 9, 2) != line.Substring(line.IndexOf("] (") - 2, 2))
                            {
                                cards.AddCard(listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(": shows ["))).IDPlayer, line.Substring(line.IndexOf("] (") - 2, 2), 2);
                            }
                        }
                    }

                    //******** MUCKED HANDS *********
                    if (line.Length > 6 && line.IndexOf(" mucked [") > 0)
                    {
                        Players playerWhoMucked = new Players();
                        if (line.IndexOf(" (") > -1)
                        {
                            playerWhoMucked.Nickname = line.Substring(8, line.IndexOf(" (") - 8);
                            playerWhoMucked.FindByNick();
                        }
                        else
                        {
                            playerWhoMucked.Nickname = line.Substring(8, line.Length - 23);
                            playerWhoMucked.FindByNick();
                        }

                        if (!cards.AlreadyRecorded(playerWhoMucked.IDPlayer))
                        {
                            cards.AddCard(playerWhoMucked.IDPlayer, line.Substring(line.IndexOf(" mucked [") + 9, 2), 1);
                            cards.AddCard(playerWhoMucked.IDPlayer, line.Substring(line.IndexOf(" mucked [") + 12, 2), 2);
                        }
                    }

                    //******** SUMMARY *********
                    if (line.Length > 14 && line.Substring(0, 15).ToUpper() == "*** SUMMARY ***")
                    {
                        hand.Insert();

                        foreach (HandPlayers handPlayerToInsert in listHandPlayers)
                        {
                            handPlayerToInsert.Insert();
                            if (handPlayerToInsert.IDPlayer == idPlayerHero)
                                session.NetWon = session.NetWon + handPlayerToInsert.NetWon;
                        }

                        foreach (Actions actionToInsert in listActions)
                        {
                            actionToInsert.Insert();
                        }
                    }
                }                
            }

            if (session.IDSession > 0)
            {
                session.TimeEnd = hand.TimeHand;
                session.Insert();
            }

            sql.Commit();

            return wasItALoadableFile;
        }

        internal bool LoadTournamentHandHistory(FileInfo file)
        {
            bool wasItALoadableFile = false;
            bool arePlayersSeated = false;
            int orderHand = 0;
            int idPlayerHero = 0;
            int handMoment = 0;
            double NetWon = 0;

            int PreFlop = 0;
            int Flop = 1;
            int Turn = 2;
            int River = 3;
            int Blinds = -1;
            int Fold = 1;
            int Call = 2;
            int Raise = 3;
            int Check = 4;

            string[] lines = System.IO.File.ReadAllLines(file.FullName);

            Hands hand = null;
            HandsTournaments handTournament = null;
            List<Players> listPlayers = null;
            List<Actions> listActions = null;
            List<HandPlayers> listHandPlayers = null;
            Players player = null;
            HandPlayers handPlayer = null;
            Cards cards = null;
            Actions action = null;
            Tournaments tournament = new Tournaments();

            sql.BeginTransaction();

            foreach (string line in lines)
            {
                //******** HEADER *********
                if (line.Length > 10 && line.Substring(0, 11).ToUpper() == "POKERSTARS ")
                {
                    hand = new Hands();
                    hand.IDHand = Convert.ToDouble(line.Substring(line.IndexOf("#") + 1, line.IndexOf(":") - line.IndexOf("#") - 1));
                    hand.Type = "T";

                    if (!wasItALoadableFile)
                        wasItALoadableFile = IsAValidGame(line) && IsRealMoneyTourney(line) && hand.AmIANewHand() && IsTournamentHistory(line);

                    if (!wasItALoadableFile)
                        break;

                    handTournament = new HandsTournaments();
                    handTournament.IDHand = hand.IDHand;
                    handTournament.IDTournament = Convert.ToDouble(line.Substring(line.IndexOf("Tournament #") + 12, line.IndexOf(",") - line.IndexOf("Tournament #") - 12));
                    handTournament.Insert();

                    if (tournament.IDTournament == 0)
                        tournament.GetTournamentById(handTournament.IDTournament); 

                    arePlayersSeated = false;
                    listPlayers = new List<Players>();
                    orderHand = 0;
                    listActions = new List<Actions>();
                    listHandPlayers = new List<HandPlayers>();                                        
                }

                //******** IDGAME ***********
                if (tournament.IdGame == 0 && line.Length > 5 && line.Substring(0, 6).ToUpper() == "TABLE ")
                {
                    if (line.IndexOf("6-max") > 0)
                        tournament.IdGame = 1;
                    else
                        tournament.IdGame = 2;

                    tournament.UpdateIdGame();
                }

                //******** SEATINGS *********
                if (line.Length > 4 && line.Substring(0, 5).ToUpper() == "SEAT " && arePlayersSeated == false)
                {
                    hand.NumPlayers++;

                    player = new Players();
                    player.Nickname = line.Substring(line.IndexOf(": ") + 2, line.IndexOf(" (") - line.IndexOf(": ") - 2);
                    player.FindByNick();

                    if (player.IDPlayer == 0) player.Insert();
                    
                    listPlayers.Add(player);

                    handPlayer = new HandPlayers();
                    handPlayer.IDHand = hand.IDHand;
                    handPlayer.IDPlayer = player.IDPlayer;
                    handPlayer.Seat = hand.NumPlayers;
                    handPlayer.InitialStack = Convert.ToDouble(line.Substring(line.IndexOf(" (") + 2, line.IndexOf(" in chip") - line.IndexOf(" (") - 2));
                    handPlayer.PreviousBet = 0;
                    handPlayer.BB = 0;
                    handPlayer.VPIP = 0;
                    handPlayer.PFR = 0;

                    listHandPlayers.Add(handPlayer);
                }

                //******** HOLE CARDS *********
                if (line.Length > 8 && line.Substring(0, 9) == "Dealt to ")
                {
                    arePlayersSeated = true;
                    idPlayerHero = listPlayers.Find(x => x.Nickname == line.Substring(line.IndexOf("Dealt to ") + 9, line.Length - 17)).IDPlayer;

                    cards = new Cards();
                    cards.IDHand = hand.IDHand;
                    cards.AddCard(idPlayerHero, line.Substring(line.IndexOf("[") + 1, 2), 1);
                    cards.AddCard(idPlayerHero, line.Substring(line.IndexOf("[") + 4, 2), 2);
                }

                //******** BLINDS AND ANTES *********
                if (line.Length > 7 && line.IndexOf(": posts ") > 0)
                {
                    handMoment = PreFlop;

                    orderHand++;
                    action = new Actions();
                    action.IDHand = hand.IDHand;
                    action.OrderHand = orderHand;
                    action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": posts"))).IDPlayer;
                    action.HandMoment = PreFlop;
                    action.Action = Blinds;

                    if (line.IndexOf("posts the ante") > -1)
                    {
                        action.Action = -2;
                        if (line.IndexOf("and is all-in") > 0)
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" the ante ") + 10, line.Length - line.IndexOf(" the ante ") - 24));
                        else
                            action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" the ante ") + 10, line.Length - line.IndexOf(" the ante ") - 10));
                    }
                    else if (line.IndexOf("and is all-in") > -1)
                    {
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" blind ") + 7, line.Length - line.IndexOf(" blind ") - 21));
                    }
                    else
                    {
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" blind ") + 7, line.Length - line.IndexOf(" blind ") - 7));
                    }

                    listActions.Add(action);

                    listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;

                    if (line.IndexOf("posts the ante") == -1)
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet = action.Value;
                }

                //******** FOLD *********
                if (line.Length > 6 && line.IndexOf(": folds") > 0)
                {
                    orderHand++;

                    action = new Actions();
                    action.IDHand = hand.IDHand;
                    action.OrderHand = orderHand;
                    action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": folds"))).IDPlayer;
                    action.HandMoment = handMoment;
                    action.Action = Fold;
                    action.Value = 0;

                    listActions.Add(action);
                }

                //******** CALL *********
                if (line.Length > 7 && line.IndexOf(": calls ") > 0)
                {
                    orderHand++;

                    action = new Actions();
                    action.IDHand = hand.IDHand;
                    action.OrderHand = orderHand;
                    action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": calls"))).IDPlayer;
                    action.HandMoment = handMoment;
                    action.Action = Call;
                    if (line.IndexOf(" and is all-in") != -1)
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": calls") + 8, line.Length - line.IndexOf(": calls") - 8 - 14));
                    else
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": calls") + 8, line.Length - line.IndexOf(": calls") - 8));

                    listActions.Add(action);

                    listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;                    
                }

                //******** BET *********
                if (line.Length > 6 && line.IndexOf(": bets ") > 0)
                {
                    orderHand++;

                    action = new Actions();
                    action.IDHand = hand.IDHand;
                    action.OrderHand = orderHand;
                    action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": bets"))).IDPlayer;
                    action.HandMoment = handMoment;
                    action.Action = Raise;
                    if (handMoment == 0)
                    {
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer && x.IDHand == action.IDHand).VPIP = 1;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer && x.IDHand == action.IDHand).PFR = 1;
                    }
                    if (line.IndexOf(" and is all-in") != -1)
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": bets") + 7, line.IndexOf(" and is all-in") - line.IndexOf(": bets") - 7));
                    else
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(": bets") + 7, line.Length - line.IndexOf(": bets") - 7));

                    listActions.Add(action);

                    listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;
                    listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet = action.Value;
                }

                //******** RAISE *********
                if (line.Length > 8 && line.IndexOf(": raises ") > 0)
                {
                    orderHand++;

                    action = new Actions();
                    action.IDHand = hand.IDHand;
                    action.OrderHand = orderHand;
                    action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": raises"))).IDPlayer;
                    action.HandMoment = handMoment;
                    action.Action = Raise;
                    if (handMoment == 0)
                    {
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).VPIP = 1;
                        listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PFR = 1;
                    }
                    if (line.IndexOf(" and is all-in") != -1)
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" to ") + 4, line.Length - line.IndexOf(" to ") - 18));
                    else
                        action.Value = Convert.ToDouble(line.Substring(line.IndexOf(" to ") + 4, line.Length - line.IndexOf(" to ") - 4));

                    action.Value = action.Value - listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet;

                    listActions.Add(action);

                    listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).PreviousBet + action.Value;
                    listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == action.IDPlayer).NetWon - action.Value;                    
                }

                //******** CHECKS *********
                if (line.Length > 7 && line.IndexOf(": checks") > 0)
                {
                    orderHand++;

                    action = new Actions();
                    action.IDHand = hand.IDHand;
                    action.OrderHand = orderHand;
                    action.IDPlayer = listPlayers.FirstOrDefault(x => x.Nickname == line.Substring(0, line.IndexOf(": checks"))).IDPlayer;
                    action.HandMoment = handMoment;
                    action.Action = Check;
                    action.Value = 0;

                    listActions.Add(action);
                }

                //******** FLOP *********
                if (line.Length > 11 && line.Substring(0, 12).ToUpper() == "*** FLOP ***")
                {
                    handMoment = Flop;

                    cards.IDHand = hand.IDHand;
                    cards.AddCard(-1, line.Substring(14, 2), 0);
                    cards.AddCard(-2, line.Substring(17, 2), 0);
                    cards.AddCard(-3, line.Substring(20, 2), 0);

                    ResetPreviousBets(listHandPlayers);
                }

                //******** TURN *********
                if (line.Length > 11 && line.Substring(0, 12).ToUpper() == "*** TURN ***")
                {
                    handMoment = Turn;

                    cards.AddCard(-4, line.Substring(25, 2), 0);

                    ResetPreviousBets(listHandPlayers);
                }

                //******** RIVER *********
                if (line.Length > 12 && line.Substring(0, 13).ToUpper() == "*** RIVER ***")
                {
                    handMoment = River;

                    cards.AddCard(-5, line.Substring(29, 2), 0);

                    ResetPreviousBets(listHandPlayers);
                }

                //******** COLECTING MONEY *********
                if (line.Length > 13 && line.IndexOf(") returned to ") > 0 && line.StartsWith("Seat") == false)
                {
                    Players playerWhoWon = listPlayers.Find(y => y.Nickname == line.Substring(line.IndexOf(") returned to ") + 14, line.Length - line.IndexOf(") returned to ") - 14));
                    NetWon = Convert.ToDouble(line.Substring(line.IndexOf(" (") + 2, line.IndexOf(") returned to ") - line.IndexOf(" (") - 2));
                    listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon + NetWon;                    
                }
                else if (line.Length > 10 && line.IndexOf(" collected ") > 0 && line.StartsWith("Seat") == false)
                {
                    Players playerWhoWon = listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(" collected ")));
                    if (line.IndexOf(" from side pot-") > 0)
                        NetWon = Convert.ToDouble(line.Substring(line.IndexOf(" collected ") + 11, line.Length - line.IndexOf(" collected ") - 27));
                    else if (line.IndexOf(" from side pot") > 0 || line.IndexOf(" from main pot") > 0)
                        NetWon = Convert.ToDouble(line.Substring(line.IndexOf(" collected ") + 11, line.Length - line.IndexOf(" collected ") - 25));
                    else
                        NetWon = Convert.ToDouble(line.Substring(line.IndexOf(" collected ") + 11, line.Length - line.IndexOf(" collected ") - 20));

                    listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon = listHandPlayers.Find(x => x.IDPlayer == playerWhoWon.IDPlayer).NetWon + NetWon;                    
                }

                //******** SHOW DOWN *********
                if (line.Length > 8 && line.IndexOf(": shows [") > 0)
                {
                    if (listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(": shows ["))).IDPlayer != idPlayerHero)
                    {
                        cards.AddCard(listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(": shows ["))).IDPlayer, line.Substring(line.IndexOf(": shows [") + 9, 2), 1);
                        if (line.Substring(line.IndexOf(": shows [") + 9, 2) != line.Substring(line.IndexOf("] (") - 2, 2))
                        {
                            cards.AddCard(listPlayers.Find(y => y.Nickname == line.Substring(0, line.IndexOf(": shows ["))).IDPlayer, line.Substring(line.IndexOf("] (") - 2, 2), 2);
                        }
                    }
                }

                //******** MUCKED HANDS *********
                if (line.Length > 6 && line.IndexOf(" mucked [") > 0)
                {
                    Players playerWhoMucked = new Players();
                    if (line.IndexOf(" (") > -1)
                    {
                        playerWhoMucked.Nickname = line.Substring(8, line.IndexOf(" (") - 8);
                        playerWhoMucked.FindByNick();
                    }
                    else
                    {
                        playerWhoMucked.Nickname = line.Substring(8, line.Length - 23);
                        playerWhoMucked.FindByNick();
                    }

                    if (!cards.AlreadyRecorded(playerWhoMucked.IDPlayer))
                    {
                        cards.AddCard(playerWhoMucked.IDPlayer, line.Substring(line.IndexOf(" mucked [") + 9, 2), 1);
                        cards.AddCard(playerWhoMucked.IDPlayer, line.Substring(line.IndexOf(" mucked [") + 12, 2), 2);
                    }
                }

                //******** SUMMARY *********
                if (line.Length > 14 && line.Substring(0, 15).ToUpper() == "*** SUMMARY ***")
                {
                    hand.Insert();

                    foreach (HandPlayers handPlayerToInsert in listHandPlayers)
                    {
                        handPlayerToInsert.Insert();                        
                    }

                    foreach (Actions actionToInsert in listActions)
                    {
                        actionToInsert.Insert();
                    }
                }
            }

            sql.Commit();

            return wasItALoadableFile;
        }        

        internal bool LoadTournamentSummary(FileInfo file)
        {
            bool IcanLoadThisTourney = false;
            bool playersStarted = false;

            string[] lines = System.IO.File.ReadAllLines(file.FullName);
            Tournaments tournament = new Tournaments();
            Dictionary<int, double> results = new Dictionary<int, double>();

            sql.BeginTransaction();

            //I wont load satelites
            //I wont load no NoLimit Holden games
            foreach (string line in lines)
            {
                if (line.Length > 22 && line.IndexOf("PokerStars Tournament #") > -1)
                {
                    tournament.IDTournament = Convert.ToDouble(line.Substring(line.IndexOf("Tournament #") + 12, line.IndexOf(", ") - line.IndexOf("#") - 1));
                    IcanLoadThisTourney = tournament.AmINew();
                    if (!IcanLoadThisTourney)
                        break;
                }

                if (line.Length > 6 && line.Substring(0, 7) == "Buy-In:")
                {
                    if (line.IndexOf(" USD") == -1)
                    {
                        IcanLoadThisTourney = false;
                        break;
                    }

                    if (line.IndexOf("/$") > -1)
                    {
                        tournament.Rake = Convert.ToDouble(line.Substring(line.IndexOf("/$") + 2, line.Length - line.IndexOf("/$") - 6));
                        tournament.BuyIn = Convert.ToDouble(line.Substring(line.IndexOf("$") + 1, line.IndexOf("/") - line.IndexOf("$") - 1)) + tournament.Rake;
                    }
                    else
                    {
                        tournament.Rake = 0;
                        tournament.BuyIn = Convert.ToDouble(line.Substring(line.IndexOf("$") + 1,line.Length - 13));
                    }
                }

                if (!playersStarted && line.Length > 8 && line.IndexOf("Satellite") > -1)
                {
                    IcanLoadThisTourney = false;
                    break;
                }

                if (line.Length > 7 && line.EndsWith(" players"))
                {
                    tournament.NumPlayers = Convert.ToInt32(line.Substring(0, line.IndexOf(" players")));
                }

                if (line.Length > 18 && line.Substring(0, 19) == "Total Prize Pool: $")
                {
                    tournament.TotalPrizePool = Convert.ToDouble(line.Substring(19, line.Length - 24));
                }

                if (playersStarted)
                {
                    if (line.Length > 2 && line.Substring(0, 3) != "You")
                    {
                        if (line.IndexOf(", still playing") > -1 || line.EndsWith(", "))
                        {
                            results[Convert.ToInt32(line.Substring(2, line.IndexOf(":") - 2))] = 0;
                        }
                        else
                        {
                            results[Convert.ToInt32(line.Substring(2, line.IndexOf(":") - 2))] = Convert.ToDouble(line.Substring(line.IndexOf("), $") + 4, line.Length - line.IndexOf("), $") - 4).Substring(0, line.Substring(line.IndexOf("), $") + 4, line.Length - line.IndexOf("), $") - 4).IndexOf(" ")));
                        }
                    }

                    if (line.Length > 2 && line.Substring(0, 3) == "You")
                    {
                        if (line.IndexOf(" place") > -1)
                        {
                            tournament.Position = Convert.ToInt32(line.Substring(16, line.IndexOf(" place") - 18));
                            tournament.PrizeWon = results[tournament.Position];
                        }
                        else
                        {
                            tournament.Position = 0;
                            tournament.PrizeWon = 0;
                        }
                    }
                }

                if (line.Length > 18 && line.Substring(0, 19) == "Tournament started ")
                {
                    tournament.DateStart = line.Substring(line.IndexOf("Tournament started ") + 27, 2) +
                                            line.Substring(line.IndexOf("Tournament started ") + 24, 2) +
                                            line.Substring(line.IndexOf("Tournament started ") + 19, 4);
                    if (line.Substring(line.IndexOf("/") + 9, 1) == ":")
                        tournament.TimeStart = line.Substring(line.IndexOf("/") + 7, 8);
                    else
                        tournament.TimeStart = line.Substring(line.IndexOf("/") + 7, 7);

                    playersStarted = true;
                }
            }            

            if (IcanLoadThisTourney)
                tournament.Insert();

            sql.Commit();

            return IcanLoadThisTourney;
        }

        private bool IsTournamentHistory(string line)
        {
            return line.IndexOf(": Tournament #") > 0;
        }

        private void ResetPreviousBets(List<HandPlayers> listHandPlayers)
        {
            foreach (HandPlayers handPlayersToResetBet in listHandPlayers)
            {
                handPlayersToResetBet.PreviousBet = 0;
            }
        }
    }
}
