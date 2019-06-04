using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class Actions
    {
        SQL sql = new SQL();

        public double IDHand { get; set; }
        public int OrderHand { get; set; }
        public int IDPlayer { get; set; }
        public int HandMoment { get; set; }
        public int Action { get; set; }
        public double Value { get; set; }

        internal List<Actions> GetActions(double idHand)
        {
            SQLiteDataReader dr = sql.Select("SELECT * FROM ACTIONS WHERE IDHAND=" + idHand.ToString() + " ORDER BY ORDERHAND");
            List<Actions> listActions = new List<Actions>();
            Actions action = new Actions();

            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {
                    action = new Actions();
                    action.IDHand = idHand;
                    action.IDPlayer = Convert.ToInt32(dr["IDPlayer"]);
                    action.OrderHand = Convert.ToInt32(dr["OrderHand"]);
                    action.HandMoment = Convert.ToInt32(dr["HandMoment"]);
                    action.Action = Convert.ToInt32(dr["Action"]);
                    action.Value = Convert.ToDouble(dr["Value"]);

                    listActions.Add(action);
                }
            }

            return listActions;
        }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO ACTIONS (IDHand, OrderHand, IDPlayer, HandMoment, Action, Value) values (" + this.IDHand + "," + this.OrderHand + "," + this.IDPlayer + "," + this.HandMoment + "," + this.Action + "," + this.Value + ")");
        }
    }
}
