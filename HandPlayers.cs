using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class HandPlayers
    {
        public double IDHand { get; set; }
        public int IDPlayer { get; set; }
        public double NetWon { get; set; }
        public double VPIP { get; set; }
        public double PFR { get; set; }
        public double BB { get; set; }
        public int Seat { get; set; }
        public double InitialStack { get; set; }

        public string Nickname { get; set; }
        public double PreviousBet { get; set; }

        private SQL sql = new SQL();

        internal List<HandPlayers> GetPlayersInHand(double idHand)
        {
            SQLiteDataReader dr = sql.Select("SELECT * FROM HANDPLAYERS HP INNER JOIN PLAYERS P ON HP.IDPLAYER = P.IDPLAYER WHERE HP.IDHAND=" + idHand.ToString());
            List<HandPlayers> listHandPlayers = new List<HandPlayers>();

            HandPlayers handPlayer = null;

            while (dr.Read())
            {
                handPlayer = new HandPlayers();
                handPlayer.IDHand = idHand;
                handPlayer.IDPlayer = Convert.ToInt32(dr["IDPlayer"]);
                handPlayer.NetWon = Convert.ToDouble(dr["NetWon"]);
                handPlayer.VPIP = Convert.ToDouble(dr["VPIP"]);
                handPlayer.PFR = Convert.ToDouble(dr["PFR"]);
                handPlayer.BB = Convert.ToDouble(dr["BB"]);
                handPlayer.Seat = Convert.ToInt32(dr["Seat"]);
                handPlayer.InitialStack = Convert.ToDouble(dr["InitialStack"]);
                handPlayer.Nickname = dr["Nickname"].ToString();
                
                listHandPlayers.Add(handPlayer);
            }
            
            return listHandPlayers;
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO HANDPLAYERS (IDHand, IDPlayer, NetWon, VPIP, PFR, BB, Seat, InitialStack) values (" + this.IDHand + "," + this.IDPlayer + "," + this.NetWon + "," + this.VPIP + "," + this.PFR + "," + this.BB + "," + this.Seat + "," + this.InitialStack + ")");
        }
    }
}
