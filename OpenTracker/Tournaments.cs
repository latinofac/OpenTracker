using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class Tournaments
    {
        private SQL sql = new SQL();

        public double IDTournament { get; set; }
        public double BuyIn { get; set; }
        public double Rake { get; set; }
        public int NumPlayers { get; set; }
        public double TotalPrizePool { get; set; }
        public string DateStart { get; set; }
        public string TimeStart { get; set; }
        public double PrizeWon { get; set; }
        public int Position { get; set; }
        public bool HasHands { get; set; }
        public int IdGame { get; set; }

        internal List<Tournaments> GetAllTournaments()
        {
            List<Tournaments> listTournaments = new List<Tournaments>();
            Tournaments tournament = null;

            SQLiteDataReader dr = sql.Select("SELECT DISTINCT T.IDTOURNAMENT, T.BUYIN, T.RAKE, T.NUMPLAYERS, T.DATESTART, T.TIMESTART, T.POSITION, T.PRIZEWON, HT.IDTOURNAMENT HANDT FROM TOURNAMENTS T LEFT JOIN HANDSTOURNAMENTS HT ON T.IDTOURNAMENT = HT.IDTOURNAMENT WHERE T.BUYIN > 0 ORDER BY T.DATESTART DESC");

            while (dr.Read())
            {
                tournament = new Tournaments();
                tournament.IDTournament = Convert.ToDouble(dr["IDTOURNAMENT"]);
                tournament.BuyIn = Convert.ToDouble(dr["BUYIN"]);
                tournament.Rake = Convert.ToInt32(dr["RAKE"]);
                tournament.NumPlayers = Convert.ToInt32(dr["NUMPLAYERS"]);
                tournament.DateStart = Convert.ToDateTime(dr["DATESTART"].ToString().Substring(2, 2) + "/" + dr["DATESTART"].ToString().Substring(0, 2) + "/" + dr["DATESTART"].ToString().Substring(4, 4)).ToShortDateString();
                tournament.TimeStart = dr["TIMESTART"].ToString();
                tournament.Position = Convert.ToInt32(dr["POSITION"]);
                tournament.PrizeWon = Convert.ToDouble(dr["PRIZEWON"]);
                tournament.HasHands = false;

                if (dr["HANDT"] != null && dr["HANDT"].ToString() != "")
                    tournament.HasHands = true;

                listTournaments.Add(tournament);
            }

            return listTournaments;
        }

        internal List<Double> GetAllHands()
        {
            List<Double> listHandTournaments = new List<Double>();

            SQLiteDataReader dr = sql.Select("SELECT * FROM HANDSTOURNAMENTS WHERE IDTOURNAMENT=" + this.IDTournament + " ORDER BY IDHAND");

            while (dr.Read())
            {
                listHandTournaments.Add(Convert.ToDouble(dr["IDHand"]));
            }

            return listHandTournaments;
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO TOURNAMENTS (IDTOURNAMENT, BUYIN, RAKE, NUMPLAYERS, TOTALPRIZEPOOL, DATESTART, TIMESTART, PRIZEWON, POSITION) " +
                       "VALUES (" +
                       this.IDTournament + "," + this.BuyIn + "," + this.Rake + "," + this.NumPlayers + "," + this.TotalPrizePool + ",'" + this.DateStart + "','" + this.TimeStart + "'," + this.PrizeWon + "," + this.Position + ")");
        }

        internal bool AmINew()
        {
            bool IAmANew = false;

            SQLiteDataReader dr = sql.Select("SELECT COUNT(*) TOT FROM TOURNAMENTS WHERE IDTOURNAMENT=" + this.IDTournament);

            while (dr.Read())
            {
                if (Convert.ToInt32(dr["TOT"]) == 0)
                    IAmANew = true;
            }

            return IAmANew;
        }

        internal void GetTournamentById(double idTournament)
        {
            SQLiteDataReader dr = sql.Select("SELECT * FROM TOURNAMENTS WHERE IDTOURNAMENT=" + idTournament);

            while (dr.Read())
            {
                if (dr["IDGame"].ToString() != "")
                    this.IdGame = Convert.ToInt32(dr["IDGame"]);

                this.IDTournament = idTournament;                
                this.BuyIn = Convert.ToDouble(dr["BuyIn"]);
                this.Rake = Convert.ToDouble(dr["Rake"]);
                this.NumPlayers = Convert.ToInt32(dr["NumPlayers"]);
                this.TotalPrizePool = Convert.ToDouble(dr["TotalPrizePool"]);
                this.DateStart = dr["DateStart"].ToString();
                this.TimeStart = dr["TimeStart"].ToString();
                this.PrizeWon = Convert.ToDouble(dr["PrizeWon"]);
                this.Position = Convert.ToInt32(dr["Position"]);
            }
            
        }

        internal void UpdateIdGame()
        {
            sql.ExecuteNonQuery("UPDATE TOURNAMENTS SET IDGAME = " + this.IdGame + " WHERE IDTOURNAMENT = " + this.IDTournament);
        }
    }
}
