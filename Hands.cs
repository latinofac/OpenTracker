using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class Hands
    {
        SQL sql = new SQL();

        public double IDHand { get; set; }
        public string Stakes { get; set; }
        public string DateHand { get; set; }
        public string TimeHand { get; set; }
        public int NumPlayers { get; set; }
        public string Type { get; set; }

        internal List<HandView> GetAllHands(int page, int idPlayer, string handFilter, int idSession)
        {
            List<HandView> listHandView = new List<HandView>();
            string subquery = "";

            if (handFilter != "")
            {
                string[] hands = handFilter.Split(',');
                string suited = "";

                foreach (string hand in hands)
                {
                    if (hand == "")
                        continue;

                    if (hand.Length > 2 && hand.Substring(2, 1) == "o")
                        suited = "SUBSTR(C1.CARD,2,1) <> SUBSTR(C2.CARD,2,1) AND ";
                    if (hand.Length > 2 && hand.Substring(2, 1) == "s")
                        suited = "SUBSTR(C1.CARD,2,1) = SUBSTR(C2.CARD,2,1) AND ";
                    if (hand.Length == 2)
                        suited = "";

                    if (subquery != "")
                        subquery = subquery + " UNION ";
                    subquery = subquery +
                                "SELECT HP.IDHAND " +
                               "FROM HANDPLAYERS HP " +
                               "INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND " +
                               "INNER JOIN CARDS C1 ON HP.IDHAND = C1.IDHAND AND C1.CARDORDER = 1 AND C1.CARD IN ('" + hand.Substring(0, 1) + "h', '" + hand.Substring(0, 1) + "d', '" + hand.Substring(0, 1) + "s', '" + hand.Substring(0, 1) + "c') " +
                               "INNER JOIN CARDS C2 ON HP.IDHAND = C2.IDHAND AND C2.CARDORDER = 2 AND C2.CARD IN ('" + hand.Substring(1, 1) + "h', '" + hand.Substring(1, 1) + "d', '" + hand.Substring(1, 1) + "s', '" + hand.Substring(1, 1) + "c') " +
                               "WHERE " + suited + " HP.IDPLAYER = " + idPlayer.ToString() + " AND C1.IDPLAYER = " + idPlayer.ToString() + " AND C2.IDPLAYER = " + idPlayer.ToString() + " " +
                               "UNION " +
                               "SELECT HP.IDHAND " +
                               "FROM HANDPLAYERS HP " +
                               "INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND " +
                               "INNER JOIN CARDS C1 ON HP.IDHAND = C1.IDHAND AND C1.CARDORDER = 1 AND C1.CARD IN ('" + hand.Substring(1, 1) + "h', '" + hand.Substring(1, 1) + "d', '" + hand.Substring(1, 1) + "s', '" + hand.Substring(1, 1) + "c') " +
                               "INNER JOIN CARDS C2 ON HP.IDHAND = C2.IDHAND AND C2.CARDORDER = 2 AND C2.CARD IN ('" + hand.Substring(0, 1) + "h', '" + hand.Substring(0, 1) + "d', '" + hand.Substring(0, 1) + "s', '" + hand.Substring(0, 1) + "c')" +
                               "WHERE " + suited + " HP.IDPLAYER = " + idPlayer + " AND C1.IDPLAYER = " + idPlayer.ToString() + " AND C2.IDPLAYER = " + idPlayer.ToString() + " ";
                }
            }

            SQLiteDataReader dr = null;

            if (idSession > 0)
            {
                if (handFilter == "")
                    dr = sql.Select("SELECT C.IDHAND, C.CARD, HP.NETWON FROM CARDS C INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER INNER JOIN HANDPLAYERS HP ON HP.IDPLAYER=P.IDPLAYER AND HP.IDHAND=C.IDHAND INNER JOIN HANDSESSIONS HS ON HP.IDHAND=HS.IDHAND INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " AND HS.IDSESSION = " + idSession + " ORDER BY C.IDHAND LIMIT 200 OFFSET " + ((page - 1) * 200).ToString());
                else
                    dr = sql.Select("SELECT C.IDHAND, C.CARD, HP.NETWON " +
                                    "FROM (" + subquery + ") QU " +
                                    "INNER JOIN CARDS C ON QU.IDHAND = C.IDHAND " +
                                    "INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER " +
                                    "INNER JOIN HANDPLAYERS HP ON HP.IDPLAYER=P.IDPLAYER AND HP.IDHAND=C.IDHAND " +
                                    "INNER JOIN HANDSESSIONS HS ON HP.IDHAND=HS.IDHAND " +
                                    "INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND " + 
                                    "WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " AND HS.IDSESSION = " + idSession + " " +
                                    "ORDER BY C.IDHAND LIMIT 200 OFFSET " + ((page - 1) * 200).ToString());
            }
            else
            {
                if (handFilter == "")
                    dr = sql.Select("SELECT C.IDHAND, C.CARD, HP.NETWON FROM CARDS C INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER INNER JOIN HANDPLAYERS HP ON HP.IDPLAYER=P.IDPLAYER AND HP.IDHAND=C.IDHAND INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " ORDER BY C.IDHAND LIMIT 200 OFFSET " + ((page - 1) * 200).ToString());
                else
                    dr = sql.Select("SELECT C.IDHAND, C.CARD, HP.NETWON " +
                                    "FROM (" + subquery + ") QU " +
                                    "INNER JOIN CARDS C ON QU.IDHAND = C.IDHAND " +
                                    "INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER " +
                                    "INNER JOIN HANDPLAYERS HP ON HP.IDPLAYER=P.IDPLAYER AND HP.IDHAND=C.IDHAND " +
                                    "INNER JOIN HANDSESSIONS HS ON HP.IDHAND=HS.IDHAND " +
                                    "INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND " +
                                    "WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " " +
                                    "ORDER BY C.IDHAND LIMIT 200 OFFSET " + ((page - 1) * 200).ToString());
            }

            HandView handView = new HandView();
            while (dr.Read())
            {
                if (handView.CardOne == "" || handView.CardOne == null)
                {
                    handView.IDHand = Convert.ToDouble(dr["IDHAND"]);
                    handView.NetWon = Convert.ToDouble(dr["NETWON"]);
                    handView.CardOne = dr["CARD"].ToString();
                }
                else
                {
                    handView.CardTwo = dr["CARD"].ToString();
                    listHandView.Add(handView);
                    handView = new HandView();
                }
            }

            return listHandView;
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO HANDS (IDHand, Stakes,DateHand,TimeHand,NumPlayers,Type) values (" + this.IDHand + ",'" + this.Stakes + "','" + this.DateHand + "','" + this.TimeHand + "'," + this.NumPlayers + ",'" + this.Type + "')");
        }

        internal bool AmIANewHand()
        {
            bool IAmANewHand = false;

            SQLiteDataReader dr = sql.Select("SELECT COUNT(*) TOT FROM HANDS WHERE IDHAND=" + this.IDHand);

            while (dr.Read())
            {
                if (Convert.ToInt32(dr["TOT"]) == 0)
                    IAmANewHand = true;
            }

            return IAmANewHand;
        }

        internal int GetMaxPages(int idPlayer, string handFilter, int idSession)
        {
            string subquery = "";

            if (handFilter != "")
            {
                string[] hands = handFilter.Split(',');
                string suited = "";

                foreach (string hand in hands)
                {
                    if (hand == "")
                        continue;

                    if (hand.Length > 2 && hand.Substring(2, 1) == "o")
                        suited = "SUBSTR(C1.CARD,2,1) <> SUBSTR(C2.CARD,2,1) AND ";
                    if (hand.Length > 2 && hand.Substring(2, 1) == "s")
                        suited = "SUBSTR(C1.CARD,2,1) = SUBSTR(C2.CARD,2,1) AND ";
                    if (hand.Length == 2)
                        suited = "";

                    if (subquery != "")
                        subquery = subquery + " UNION ";
                    subquery = subquery +
                                "SELECT HP.IDHAND " +
                               "FROM HANDPLAYERS HP " +
                               "INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND " +
                               "INNER JOIN CARDS C1 ON HP.IDHAND = C1.IDHAND AND C1.CARDORDER = 1 AND C1.CARD IN ('" + hand.Substring(0, 1) + "h', '" + hand.Substring(0, 1) + "d', '" + hand.Substring(0, 1) + "s', '" + hand.Substring(0, 1) + "c') " +
                               "INNER JOIN CARDS C2 ON HP.IDHAND = C2.IDHAND AND C2.CARDORDER = 2 AND C2.CARD IN ('" + hand.Substring(1, 1) + "h', '" + hand.Substring(1, 1) + "d', '" + hand.Substring(1, 1) + "s', '" + hand.Substring(1, 1) + "c') " +
                               "WHERE " + suited + " HP.IDPLAYER = " + idPlayer.ToString() + " AND C1.IDPLAYER = " + idPlayer.ToString() + " AND C2.IDPLAYER = " + idPlayer.ToString() + " " +
                               "UNION " +
                               "SELECT HP.IDHAND " +
                               "FROM HANDPLAYERS HP " +
                               "INNER JOIN HANDSESSIONS HS ON HP.IDHAND = HS.IDHAND " +
                               "INNER JOIN CARDS C1 ON HP.IDHAND = C1.IDHAND AND C1.CARDORDER = 1 AND C1.CARD IN ('" + hand.Substring(1, 1) + "h', '" + hand.Substring(1, 1) + "d', '" + hand.Substring(1, 1) + "s', '" + hand.Substring(1, 1) + "c') " +
                               "INNER JOIN CARDS C2 ON HP.IDHAND = C2.IDHAND AND C2.CARDORDER = 2 AND C2.CARD IN ('" + hand.Substring(0, 1) + "h', '" + hand.Substring(0, 1) + "d', '" + hand.Substring(0, 1) + "s', '" + hand.Substring(0, 1) + "c') " +
                               "WHERE " + suited + " HP.IDPLAYER = " + idPlayer.ToString() + " AND C1.IDPLAYER = " + idPlayer.ToString() + " AND C2.IDPLAYER = " + idPlayer.ToString() + " ";
                }
            }

            SQLiteDataReader dr = null;

            if (idSession > 0)
            {
                if (handFilter == "")
                    dr = sql.Select("SELECT COUNT(*) / 200 TOT, COUNT(*) % 200 REST FROM CARDS C INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER INNER JOIN HANDPLAYERS HP ON HP.IDHAND=C.IDHAND INNER JOIN HANDSESSIONS HS ON HP.IDHAND=HS.IDHAND INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " AND HP.IDPLAYER = " + idPlayer + " AND HS.IDSESSION = " + idSession);
                else
                    dr = sql.Select("SELECT  COUNT(*) / 200 TOT, COUNT(*) % 200 REST  " +
                                    "FROM (" + subquery + ") QU " +
                                    "INNER JOIN CARDS C ON QU.IDHAND = C.IDHAND " +
                                    "INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER " +
                                    "INNER JOIN HANDPLAYERS HP ON HP.IDHAND=C.IDHAND " +
                                    "INNER JOIN HANDSESSIONS HS ON HP.IDHAND=HS.IDHAND " +
                                    "INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND " +
                                    "WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " AND HP.IDPLAYER = " + idPlayer + " AND HS.IDSESSION = " + idSession + " ");
            }
            else
            {
                if (handFilter == "")
                    dr = sql.Select("SELECT  COUNT(*) / 200 TOT, COUNT(*) % 200 REST FROM CARDS C INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER INNER JOIN HANDPLAYERS HP ON HP.IDHAND=C.IDHAND INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " AND HP.IDPLAYER = " + idPlayer);
                else
                    dr = sql.Select("SELECT  COUNT(*) / 200 TOT, COUNT(*) % 200 REST " +
                                    "FROM (" + subquery + ") QU " +
                                    "INNER JOIN CARDS C ON QU.IDHAND = C.IDHAND " +
                                    "INNER JOIN PLAYERS P ON C.IDPLAYER = P.IDPLAYER " +
                                    "INNER JOIN HANDPLAYERS HP ON HP.IDHAND=C.IDHAND " +
                                    "INNER JOIN HANDSESSIONS HS ON HP.IDHAND=HS.IDHAND " +
                                    "INNER JOIN HANDS H ON HP.IDHAND=H.IDHAND " +
                                    "WHERE H.TYPE='C' AND P.IDPLAYER = " + idPlayer + " AND HP.IDPLAYER = " + idPlayer + " ");
            }

            int maxHands = 0;
            while (dr.Read())
            {
                maxHands = Convert.ToInt32(dr["TOT"]);
                if (Convert.ToInt32(dr["REST"]) > 0)
                    maxHands++;
            }

            return maxHands;
        }
    }
}
