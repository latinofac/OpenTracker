using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class HandGames
    {
        private SQL sql = new SQL();

        public int idGame { get; set; }
        public double idHand { get; set; }

        internal void GetGame(double idHand)
        {
            SQLiteDataReader dr = sql.Select("SELECT IDGame FROM HANDGAMES WHERE IDHAND=" + idHand);

            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {
                    this.idGame = Convert.ToInt32(dr["IDGame"]);
                    this.idHand = idHand;
                }
            }            
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO HANDGAMES (IDGAME, IDHAND) VALUES (" + this.idGame + "," + idHand + ")");
        }
    }
}
