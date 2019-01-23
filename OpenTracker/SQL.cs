using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace OpenTracker
{
    class SQL
    {
        private static string connection = "Data Source=database.db";
        private static SQLiteConnection conn = new SQLiteConnection(connection);
        private static SQLiteTransaction transaction;

        public static void connect()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        internal void Commit()
        {
            transaction.Commit();
        }

        internal void BeginTransaction()
        {
            connect();
            transaction = conn.BeginTransaction();
        }

        public void ExecuteNonQuery(string command)
        {
            connect();
            SQLiteCommand cmd = new SQLiteCommand(command, conn);
            cmd.ExecuteNonQuery();
        }

        public SQLiteDataReader Select(string command)
        {
            connect();
            SQLiteCommand cmd = new SQLiteCommand(command, conn);
            SQLiteDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        internal void ClearDB()
        {
            ExecuteNonQuery("DELETE FROM CARDS WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='C')");
            ExecuteNonQuery("DELETE FROM HANDPLAYERS WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='C')");
            ExecuteNonQuery("DELETE FROM SESSIONS");
            ExecuteNonQuery("DELETE FROM ACTIONS WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='C')");
            ExecuteNonQuery("DELETE FROM HANDSESSIONS");
            ExecuteNonQuery("DELETE FROM HANDGAMES WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='C')");
            ExecuteNonQuery("DELETE FROM HANDS WHERE TYPE='C'");
            ExecuteNonQuery("DELETE FROM PLAYERS");
        }

        internal void ClearTournamentDB()
        {
            ExecuteNonQuery("DELETE FROM CARDS WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='T')");
            ExecuteNonQuery("DELETE FROM HANDPLAYERS WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='T')");
            ExecuteNonQuery("DELETE FROM ACTIONS WHERE IDHAND IN (SELECT IDHAND FROM HANDS WHERE TYPE='T')");
            ExecuteNonQuery("DELETE FROM HANDS WHERE TYPE='T'");
            ExecuteNonQuery("DELETE FROM TOURNAMENTS");
        }
    }
}
