using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTracker
{
    public partial class FormSessions : Form
    {
        public FormSessions()
        {
            InitializeComponent();
            LoadSessions();
        }

        private void LoadSessions()
        {
            Sessions sessionGetter = new Sessions();
            List<Sessions> listSessions = new List<Sessions>();

            listSessions = sessionGetter.GetSessions();

            foreach (Sessions session in listSessions)
            {
                this.dgSessions.Rows.Add(session.IDSession,
                                         session.DateSession,
                                         session.TimeStart,
                                         session.TimeEnd,
                                         session.TotalHands,
                                         session.NetWon);
            }
        }

        private void dgSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView senderGrid = (DataGridView)sender;
                FormHands formHands = new FormHands(Convert.ToInt32(senderGrid[0, e.RowIndex].Value));
                formHands.ShowDialog();
                formHands.Dispose();
            }

        }
    }
}
