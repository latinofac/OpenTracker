using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class HandsTournaments
    {

        SQL sql = new SQL();

        public double IDHand { get; set; }
        public double IDTournament { get; set; }

        internal void Insert()
        {
            sql.ExecuteNonQuery("INSERT INTO HANDSTOURNAMENTS (IDHAND, IDTOURNAMENT) VALUES (" + this.IDHand + "," + this.IDTournament + ")");    
        }
    }
}
