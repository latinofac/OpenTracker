using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class Sessions
    {
        SQL sql = new SQL();

        public int IDSession { get; set; }
        public string DateSession { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public int TotalHands { get; set; }
        public double NetWon { get; set; }
        
        public List<Sessions> GetSessions()
        {
            SQLiteDataReader dr = sql.Select("SELECT IDSession, DateSession, TimeStart, TimeEnd, TotalHands, NetWon FROM SESSIONS ORDER BY IDSESSION DESC");
            List<Sessions> listSessions = new List<Sessions>();
            Sessions session = null;

            while (dr.Read())
            {
                session = new Sessions();
                session.IDSession = Convert.ToInt32(dr["IDSession"]);
                session.DateSession = DateTime.ParseExact(dr["DateSession"].ToString().Substring(2, 2) + "/" + dr["DateSession"].ToString().Substring(0, 2) + "/" + dr["DateSession"].ToString().Substring(4, 4), "MM/dd/yyyy", CultureInfo.InvariantCulture).ToShortDateString();
                session.TimeStart = dr["TimeStart"].ToString().Substring(0, dr["TimeStart"].ToString().Length - 4) + ":" + dr["TimeStart"].ToString().Substring(dr["TimeStart"].ToString().Length - 4, 2) + ":" + dr["TimeStart"].ToString().Substring(dr["TimeStart"].ToString().Length - 2, 2);
                session.TimeEnd = dr["TimeEnd"].ToString().Substring(0, dr["TimeEnd"].ToString().Length - 4) + ":" + dr["TimeEnd"].ToString().Substring(dr["TimeEnd"].ToString().Length - 4, 2) + ":" + dr["TimeEnd"].ToString().Substring(dr["TimeEnd"].ToString().Length - 2, 2);
                session.TotalHands = Convert.ToInt32(dr["TotalHands"]);
                session.NetWon = Math.Round(Convert.ToDouble(dr["NetWon"]), 2);

                listSessions.Add(session);
            }

            return listSessions;
        }

        private void GetNextId()
        {
            SQLiteDataReader dr2 = sql.Select("SELECT MAX(IDSession) IDSession FROM SESSIONS");

            if (dr2.FieldCount > 0)
            {
                while (dr2.Read())
                {
                    if (dr2["IDSession"].ToString() != String.Empty)
                        this.IDSession = Convert.ToInt32(dr2["IDSession"]) + 1;
                    else
                        this.IDSession = 1;
                }
            }
            else
                this.IDSession = 1;
        }

        internal void SetSessionInitialParameters(string line)
        {
            GetNextId();
            this.DateSession = line.Substring(line.IndexOf(")") + 12, 2) + line.Substring(line.IndexOf(")") + 9, 2) + line.Substring(line.IndexOf(")") + 4, 4);
            this.TimeStart = line.Substring(line.IndexOf(")") + 15, 2) + line.Substring(line.IndexOf(")") + 18, 2) + line.Substring(line.IndexOf(")") + 21, 2);
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO SESSIONS (IDSession, DateSession, TimeStart, TimeEnd, TotalHands, NetWon) values (" + this.IDSession + ",'" + this.DateSession + "','" + this.TimeStart + "','" + this.TimeEnd + "'," + this.TotalHands + "," + this.NetWon + ")");
        }
    }
}
