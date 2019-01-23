using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTracker
{
    class CashGamePlayersView
    {
        public string Nickname { get; set; }
        public int TotalHands { get; set; }
        public double NetWon { get; set; }
        public double VPIP { get; set; }
        public double PFR { get; set; }
        public double BB100 { get; set; }
    }
}
