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
    public partial class FormCashConfig : Form
    {
        public FormCashConfig()
        {
            InitializeComponent();
        }

        private void btnOpenHandPath_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
                this.txtHandPath.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
                this.txtBackupPath.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtBackupPath.Text != "" && this.txtHandPath.Text != "")
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

                MessageBox.Show("Saved successfully!");
            }
            else
            {
                MessageBox.Show("Please select a hand path and a backup path!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
