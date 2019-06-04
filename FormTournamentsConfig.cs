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
    public partial class FormTournamentsConfig : Form
    {
        public FormTournamentsConfig()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenHandPath_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
                this.txtHandPath.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void btnTournamentSummary_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
                this.txtTournamentSummaryPath.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
                this.txtBackupPath.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtBackupPath.Text != "" && this.txtHandPath.Text != "" && this.txtTournamentSummaryPath.Text != "")
            {
                Config config = new Config();

                config.IDConfig = 1;
                config.Value = this.txtHandPath.Text;
                config.Name = "Hands Path";
                config.Update();

                config.IDConfig = 2;
                config.Value = this.txtBackupPath.Text;
                config.Name = "Backup Path";
                config.Update();

                config.IDConfig = 3;
                config.Value = this.txtTournamentSummaryPath.Text;
                config.Name = "Tournaments Summary Path";
                config.Update();

                MessageBox.Show("Saved successfully!");
            }
            else
            {
                MessageBox.Show("Please select a hand path, a backup path, and a tournament summary path!");
            }
        }
    }
}
