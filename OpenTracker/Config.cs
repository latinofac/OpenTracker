using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTracker
{
    class Config
    {
        public int IDConfig { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        private SQL sql = new SQL();

        private string GetPath(int typePath)
        {
            string path = "";

            SQLiteDataReader dr = sql.Select("SELECT VALUE FROM CONFIG WHERE IDCONFIG = " + typePath);

            while (dr.Read())
            {
                path = dr["VALUE"].ToString();
            }

            return path;
        }

        internal string GetHandPath()
        {
            return GetPath(1);
        }

        internal string GetBackupPath()
        {
            return GetPath(2);
        }

        internal void Update()
        {
            SQLiteDataReader dr = sql.Select("SELECT COUNT(*) TOT FROM CONFIG WHERE IDCONFIG = " + this.IDConfig);

            while (dr.Read())
            {
                if (Convert.ToInt32(dr["TOT"]) == 1)
                    sql.ExecuteNonQuery("UPDATE CONFIG SET VALUE = '" + this.Value + "' WHERE IDCONFIG=" + this.IDConfig);
                else
                    sql.ExecuteNonQuery("INSERT INTO CONFIG (IDCONFIG, NAME, VALUE) VALUES (" + this.IDConfig + ", '" + this.Name + "','" + this.Value + "')");
            }
        }

        internal string GetTournamentsSummaryPath()
        {
            return GetPath(3);
        }
    }
}
