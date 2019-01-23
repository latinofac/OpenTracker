using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class CashGameConfig
    {
        private SQL sql = new SQL();

        public string handsToLoadPath { get; set; }
        public string handsToBackupPath { get; set; }
        public string tournamentSummaryPath { get; set; }

        internal bool ReadConfiguration()
        {
            bool foundConfig = false;
            SQLiteDataReader dr = sql.Select("SELECT * FROM CONFIG");

            while (dr.Read())
            {
                if (Convert.ToInt32(dr["IDConfig"]) == 2)
                    this.handsToBackupPath = dr["Value"].ToString();
                else if (Convert.ToInt32(dr["IDConfig"]) == 3)
                    this.tournamentSummaryPath = dr["Value"].ToString();
                else
                    this.handsToLoadPath = dr["Value"].ToString();
            }

            foundConfig = handsToLoadPath != "" && handsToLoadPath != null;

            return foundConfig;
        }
    }
}
