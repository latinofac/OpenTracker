using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace OpenTracker
{
    class Players
    {
        SQL sql = new SQL();

        public int IDPlayer { get; set; }
        public string Nickname { get; set; }
        public int TotalHands { get; set; }
        public double NetWon { get; set; }

        internal List<CashGamePlayersView> GetCashGamePlayersView()
        {
            List<CashGamePlayersView> listCashGamePlayersView = new List<CashGamePlayersView>();
            SQLiteDataReader dr = sql.Select("SELECT P.NICKNAME, P.TOTALHANDS, SUM(HP.NETWON) NETWON, SUM(HP.VPIP)/P.TOTALHANDS VPIP, SUM(HP.PFR)/P.TOTALHANDS PFR, ROUND(SUM(BB)*100/P.TOTALHANDS,2) BB FROM PLAYERS P INNER JOIN HANDPLAYERS HP ON P.IDPLAYER = HP.IDPLAYER INNER JOIN HANDS H ON HP.IDHAND = H.IDHAND WHERE H.TYPE = 'C' GROUP BY P.IDPLAYER ORDER BY P.TOTALHANDS DESC");

            while (dr.Read())
            {
                CashGamePlayersView cashGamePlayersView = new CashGamePlayersView();

                cashGamePlayersView.Nickname = dr["Nickname"].ToString();
                cashGamePlayersView.TotalHands = Convert.ToInt32(dr["TotalHands"]);
                cashGamePlayersView.NetWon = Math.Round(Convert.ToDouble(dr["NetWon"]), 2);
                cashGamePlayersView.VPIP = Math.Round(Convert.ToDouble(dr["VPIP"]), 2);
                cashGamePlayersView.PFR = Math.Round(Convert.ToDouble(dr["PFR"]), 2);
                cashGamePlayersView.BB100 = Convert.ToDouble(dr["BB"]);

                listCashGamePlayersView.Add(cashGamePlayersView);
            }

            return listCashGamePlayersView;
        }

        internal List<Players> GetAllPlayers(int idSession)
        {
            List<Players> listPlayers = new List<Players>();
            SQLiteDataReader dr = null;

            if (idSession == 0)
                dr = sql.Select("SELECT DISTINCT P.IDPLAYER, P.NICKNAME FROM PLAYERS P INNER JOIN HANDPLAYERS HP ON P.IDPLAYER = HP.IDPLAYER INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND INNER JOIN CARDS C ON HS.IDHAND=C.IDHAND AND P.IDPLAYER=C.IDPLAYER");
            else
                dr = sql.Select("SELECT DISTINCT P.IDPLAYER, P.NICKNAME FROM PLAYERS P INNER JOIN HANDPLAYERS HP ON P.IDPLAYER = HP.IDPLAYER INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND INNER JOIN CARDS C ON HS.IDHAND=C.IDHAND AND P.IDPLAYER=C.IDPLAYER WHERE HS.IDSESSION = " + idSession);

            while (dr.Read())
            {
                Players player = new Players();
                player.IDPlayer = Convert.ToInt32(dr["IDPlayer"]);
                player.Nickname = dr["Nickname"].ToString();
                listPlayers.Add(player);
            }

            return listPlayers;
        }

        internal int GetHeroID()
        {
            int idHero = 0;
            
            SQLiteDataReader dr = sql.Select("SELECT IDPLAYER, COUNT(*) TOT FROM HANDPLAYERS HP INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND GROUP BY IDPLAYER ORDER BY TOT DESC LIMIT 1");

            while (dr.Read())
            {
                idHero = Convert.ToInt32(dr["IDPlayer"]);
            }

            return idHero;
        }

        internal List<ResultsView> GetResultsView(int idPlayer, string handFilter)
        {
            List<ResultsView> listResultsView = new List<ResultsView>();
            string subquery = "";

            if (handFilter != "")
            {
                string[] hands = handFilter.Split(',');

                subquery = " AND HG.IDHAND IN (";

                string suited = "";

                foreach (string hand in hands)
                {
                    if (hand != "")
                    {
                        if (hand.Length > 2 && hand.Substring(2, 1) == "o")
                            suited = "SUBSTR(C1.CARD,2,1) <> SUBSTR(C2.CARD,2,1) AND ";
                        if (hand.Length > 2 && hand.Substring(2, 1) == "s")
                            suited = "SUBSTR(C1.CARD,2,1) = SUBSTR(C2.CARD,2,1) AND ";
                        if (hand.Length == 2)
                            suited = "";

                        if (subquery != " AND HG.IDHAND IN (")
                            subquery = subquery + " UNION ";
                        subquery = subquery +
                                    "SELECT C.IDHAND " +
                                   "FROM CARDS C " +
                                   "INNER JOIN HANDPLAYERS HP ON HP.IDPLAYER = C.IDPLAYER AND HP.IDHAND = C.IDHAND " +
                                   "INNER JOIN CARDS C1 ON C.IDHAND = C1.IDHAND AND C.IDPLAYER = C1.IDPLAYER AND C1.CARDORDER = 1 AND C1.CARD IN ('" + hand.Substring(0, 1) + "h', '" + hand.Substring(0, 1) + "d', '" + hand.Substring(0, 1) + "s', '" + hand.Substring(0, 1) + "c') " +
                                   "INNER JOIN CARDS C2 ON C.IDHAND = C2.IDHAND AND C.IDPLAYER = C2.IDPLAYER AND C2.CARDORDER = 2 AND C2.CARD IN ('" + hand.Substring(1, 1) + "h', '" + hand.Substring(1, 1) + "d', '" + hand.Substring(1, 1) + "s', '" + hand.Substring(1, 1) + "c') " +
                                   "WHERE " + suited + " C.IDPLAYER = " + idPlayer.ToString() + " " +
                                   "UNION " +
                                   "SELECT C.IDHAND " +
                                   "FROM CARDS C " +
                                   "INNER JOIN HANDPLAYERS HP ON HP.IDPLAYER = C.IDPLAYER AND HP.IDHAND = C.IDHAND " +
                                   "INNER JOIN CARDS C1 ON C.IDHAND = C1.IDHAND AND C.IDPLAYER = C1.IDPLAYER AND C1.CARDORDER = 1 AND C1.CARD IN ('" + hand.Substring(1, 1) + "h', '" + hand.Substring(1, 1) + "d', '" + hand.Substring(1, 1) + "s', '" + hand.Substring(1, 1) + "c') " +
                                   "INNER JOIN CARDS C2 ON C.IDHAND = C2.IDHAND AND C.IDPLAYER = C2.IDPLAYER AND C2.CARDORDER = 2 AND C2.CARD IN ('" + hand.Substring(0, 1) + "h', '" + hand.Substring(0, 1) + "d', '" + hand.Substring(0, 1) + "s', '" + hand.Substring(0, 1) + "c')" +
                                   "WHERE " + suited + " C.IDPLAYER = " + idPlayer + " ";
                    }
                }

                subquery = subquery + ")";
            }
            
            SQLiteDataReader dr = sql.Select("SELECT G.NAME, COUNT(*) TOTHANDS, SUM(HP.NETWON) NETWON, SUM(BB)*100/COUNT(*) BB100 " +
                                             "FROM GAMES G " +
                                             "INNER JOIN HANDGAMES HG ON G.IDGAME = HG.IDGAME " +
                                             "INNER JOIN HANDPLAYERS HP ON HG.IDHAND = HP.IDHAND " +
                                             "INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND " +
                                             "WHERE H.TYPE='C' AND HP.IDPLAYER = " + idPlayer.ToString() +
                                             subquery +
                                             " GROUP BY G.NAME");

            while (dr.Read())
            {
                ResultsView resultView = new ResultsView();

                resultView.NAME = dr["NAME"].ToString();
                resultView.TOTHANDS = Convert.ToInt32(dr["TOTHANDS"]);
                resultView.NETWON = Math.Round(Convert.ToDouble(dr["NETWON"]), 2);
                resultView.BB100 = Math.Round(Convert.ToDouble(dr["BB100"]), 2);

                listResultsView.Add(resultView);
            }

            return listResultsView;
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO PLAYERS (Nickname, TotalHands, NetWon) values ('" + this.Nickname.Replace("'", "''") + "',1,0)");

            SQLiteDataReader dr = sql.Select("SELECT * FROM PLAYERS WHERE NICKNAME='" + this.Nickname.Replace("'", "''") + "'");

            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {
                    this.IDPlayer = Convert.ToInt32(dr["IDPlayer"]);
                }
            }
        }

        public void UpdateTotalHands()
        {
            sql.ExecuteNonQuery("UPDATE PLAYERS SET TotalHands = TotalHands + 1 WHERE IDPlayer = " + this.IDPlayer);
        }

        internal void FindByNick()
        {
            SQLiteDataReader dr = sql.Select("SELECT * FROM PLAYERS WHERE NICKNAME='" + this.Nickname.Replace("'", "''") + "'");

            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {
                    this.IDPlayer = Convert.ToInt32(dr["IDPlayer"]);
                    this.TotalHands = Convert.ToInt32(dr["TotalHands"]);
                    this.NetWon = Convert.ToDouble(dr["NetWon"]);
                }
            }
        }
    }
}
