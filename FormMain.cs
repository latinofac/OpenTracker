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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCashGame_Click(object sender, EventArgs e)
        {
            FormMainCashGame formMainCashGame = new FormMainCashGame();
            formMainCashGame.ShowDialog();
            formMainCashGame.Dispose();
        }

        private void btnTournaments_Click(object sender, EventArgs e)
        {
            FormMainTournaments formMainTournaments = new FormMainTournaments();
            formMainTournaments.ShowDialog();
            formMainTournaments.Dispose();
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            FormSupport formSupport = new FormSupport();
            formSupport.ShowDialog();
            formSupport.Dispose();
        }
    }
}
