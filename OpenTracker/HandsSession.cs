using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class HandsSession
    {
        SQL sql = new SQL();

        public int IDSession { get; set; }
        public double IDHand { get; set; }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO HANDSESSIONS (IDSession, IDHand) values (" + this.IDSession + "," + this.IDHand + ")");
        }
    }
}
