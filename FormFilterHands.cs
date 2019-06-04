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
    public partial class FormFilterHands : Form
    {
        public FormFilterHands()
        {
            InitializeComponent();
        }

        private void PushHandButton(Button btn)
        {
            if (btn.BackColor == Color.Gray)
            {
                btn.BackColor = Color.White;
                this.txtFilterHands.Text = this.txtFilterHands.Text.Replace("," + btn.Text, "");
                this.txtFilterHands.Text = this.txtFilterHands.Text.Replace(btn.Text, "");
            }
            else
            {
                btn.BackColor = Color.Gray;
                if (this.txtFilterHands.Text == "")
                    this.txtFilterHands.Text = btn.Text;
                else
                    this.txtFilterHands.Text = this.txtFilterHands.Text + "," + btn.Text;
            }
        }

        private void btnAA_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAA);
        }

        private void btnKK_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKK);
        }

        private void btnQQ_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQQ);
        }

        private void btnJJ_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJJ);
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            PushHandButton(btnTT);
        }

        private void btn99_Click(object sender, EventArgs e)
        {
            PushHandButton(btn99);
        }

        private void btn88_Click(object sender, EventArgs e)
        {
            PushHandButton(btn88);
        }

        private void btn77_Click(object sender, EventArgs e)
        {
            PushHandButton(btn77);
        }

        private void btn66_Click(object sender, EventArgs e)
        {
            PushHandButton(btn66);
        }

        private void btn55_Click(object sender, EventArgs e)
        {
            PushHandButton(btn55);
        }

        private void btn44_Click(object sender, EventArgs e)
        {
            PushHandButton(btn44);
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            PushHandButton(btn33);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            PushHandButton(btn22);
        }

        private void btnAKs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAKs);
        }

        private void btnAQs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAQs);
        }

        private void btnAJs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAJs);
        }

        private void btnATs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnATs);
        }

        private void btnA9s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA9s);
        }

        private void btnA8s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA8s);
        }

        private void btnA7s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA7s);
        }

        private void btnA6s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA6s);
        }

        private void btnA5s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA5s);
        }

        private void btnA4s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA4s);
        }

        private void btnA3s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA3s);
        }

        private void btnA2s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA2s);
        }

        private void btnAKo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAKo);
        }

        private void btnAQo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAQo);
        }

        private void btnAJo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAJo);
        }

        private void btnATo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnATo);
        }

        private void btnA9o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA9o);
        }

        private void btnA8o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA8o);
        }

        private void btnA7o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA7o);
        }

        private void btnA6o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA6o);
        }

        private void btnA5o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA5o);
        }

        private void btnA4o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA4o);
        }

        private void btnA3o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA3o);
        }

        private void btnA2o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnA2o);
        }

        private void btnKQs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKQs);
        }

        private void btnKJs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKJs);
        }

        private void btnKTs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKTs);
        }

        private void btnK9s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK9s);
        }

        private void btnK8s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK8s);
        }

        private void btnK7s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK7s);
        }

        private void btnK6s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK6s);
        }

        private void btnK5s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK5s);
        }

        private void btnK4s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK4s);
        }

        private void btnK3s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK3s);
        }

        private void btnK2s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK2s);
        }

        private void btnQJs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQJs);
        }

        private void btnQTs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQTs);
        }

        private void btnQ9s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ9s);
        }

        private void btnQ8s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ8s);
        }

        private void btnQ7s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ7s);
        }

        private void btnQ6s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ6s);
        }

        private void btnQ5s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ5s);
        }

        private void btnQ4s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ4s);
        }

        private void btnQ3s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ3s);
        }

        private void btnQ2s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ2s);
        }

        private void btnJTs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJTs);
        }

        private void btnJ9s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ9s);
        }

        private void btnJ8s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ8s);
        }

        private void btnJ7s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ7s);
        }

        private void btnJ6s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ6s);
        }

        private void btnJ5s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ5s);
        }

        private void btnJ4s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ4s);
        }

        private void btnJ3s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ3s);
        }

        private void btnJ2s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ2s);
        }

        private void btnT9s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT9s);
        }

        private void btnT8s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT8s);
        }

        private void btnT7s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT7s);
        }

        private void btnT6s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT6s);
        }

        private void btnT5s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT5s);
        }

        private void btnT4s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT4s);
        }

        private void btnT3s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT3s);
        }

        private void btnT2s_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT2s);
        }

        private void btn98s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn98s);
        }

        private void btn97s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn97s);
        }

        private void btn96s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn96s);
        }

        private void btn95s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn95s);
        }

        private void btn94s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn94s);
        }

        private void btn93s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn93s);
        }

        private void btn92s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn92s);
        }

        private void btn87s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn87s);
        }

        private void btn86s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn86s);
        }

        private void btn85s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn85s);
        }

        private void btn84s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn84s);
        }

        private void btn83s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn83s);
        }

        private void btn82s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn82s);
        }

        private void btn76s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn76s);
        }

        private void btn75s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn75s);
        }

        private void btn74s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn74s);
        }

        private void btn73s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn73s);
        }

        private void btn72s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn72s);
        }

        private void btn65s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn65s);
        }

        private void btn64s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn64s);
        }

        private void btn63s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn63s);
        }

        private void btn62s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn62s);
        }

        private void btn54s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn54s);
        }

        private void btn53s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn53s);
        }

        private void btn52s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn52s);
        }

        private void btn43s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn43s);
        }

        private void btn42s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn42s);
        }

        private void btn32s_Click(object sender, EventArgs e)
        {
            PushHandButton(btn32s);
        }

        private void btnKQo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKQo);
        }

        private void btnKJo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKJo);
        }

        private void btnKTo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnKTo);
        }

        private void btnK9o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK9o);
        }

        private void btnK8o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK8o);
        }

        private void btnK7o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK7o);
        }

        private void btnK6o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK6o);
        }

        private void btnK5o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK5o);
        }

        private void btnK4o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK4o);
        }

        private void btnK3o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK3o);
        }

        private void btnK2o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnK2o);
        }

        private void btnQJo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQJo);
        }

        private void btnQTo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQTo);
        }

        private void btnQ9o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ9o);
        }

        private void btnQ8o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ8o);
        }

        private void btnQ7o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ7o);
        }

        private void btnQ6o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ6o);
        }

        private void btnQ5o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ5o);
        }

        private void btnQ4o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ4o);
        }

        private void btnQ3o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ3o);
        }

        private void btnQ2o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnQ2o);
        }

        private void btnJTo_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJTo);
        }

        private void btnJ9o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ9o);
        }

        private void btnJ8o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ8o);
        }

        private void btnJ7o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ7o);
        }

        private void btnJ6o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ6o);
        }

        private void btnJ5o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ5o);
        }

        private void btnJ4o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ4o);
        }

        private void btnJ3o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ3o);
        }

        private void btnJ2o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnJ2o);
        }

        private void btnT9o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT9o);
        }

        private void btnT8o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT8o);
        }

        private void btnT7o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT7o);
        }

        private void btnT6o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT6o);
        }

        private void btnT5o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT5o);
        }

        private void btnT4o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT4o);
        }

        private void btnT3o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT3o);
        }

        private void btnT2o_Click(object sender, EventArgs e)
        {
            PushHandButton(btnT2o);
        }

        private void btn98o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn98o);
        }

        private void btn97o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn97o);
        }

        private void btn96o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn96o);
        }

        private void btn95o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn95o);
        }

        private void btn94o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn94o);
        }

        private void btn93o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn93o);
        }

        private void btn92o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn92o);
        }

        private void btn87o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn87o);
        }

        private void btn86o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn86o);
        }

        private void btn85o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn85o);
        }

        private void btn84o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn84o);
        }

        private void btn83o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn83o);
        }

        private void btn82o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn82o);
        }

        private void btn76o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn76o);
        }

        private void btn75o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn75o);
        }

        private void btn74o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn74o);
        }

        private void btn73o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn73o);
        }

        private void btn72o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn72o);
        }

        private void btn65o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn65o);
        }

        private void btn64o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn64o);
        }

        private void btn63o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn63o);
        }

        private void btn62o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn62o);
        }

        private void btn54o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn54o);
        }

        private void btn53o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn53o);
        }

        private void btn52o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn52o);
        }

        private void btn43o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn43o);
        }

        private void btn42o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn42o);
        }

        private void btn32o_Click(object sender, EventArgs e)
        {
            PushHandButton(btn32o);
        }

        private void btnPoketPairs_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAA);
            PushHandButton(btnKK);
            PushHandButton(btnQQ);
            PushHandButton(btnJJ);
            PushHandButton(btnTT);
            PushHandButton(btn99);
            PushHandButton(btn88);
            PushHandButton(btn77);
            PushHandButton(btn66);
            PushHandButton(btn55);
            PushHandButton(btn44);
            PushHandButton(btn33);
            PushHandButton(btn22);
        }

        private void btnSuitedConnectors_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAKs);
            PushHandButton(btnKQs);
            PushHandButton(btnQJs);
            PushHandButton(btnJTs);
            PushHandButton(btnT9s);
            PushHandButton(btn98s);
            PushHandButton(btn87s);
            PushHandButton(btn76s);
            PushHandButton(btn65s);
            PushHandButton(btn54s);
            PushHandButton(btn43s);
            PushHandButton(btn32s);
        }

        private void btnSuitedAces_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAKs);
            PushHandButton(btnAQs);
            PushHandButton(btnAJs);
            PushHandButton(btnATs);
            PushHandButton(btnA9s);
            PushHandButton(btnA8s);
            PushHandButton(btnA7s);
            PushHandButton(btnA6s);
            PushHandButton(btnA5s);
            PushHandButton(btnA4s);
            PushHandButton(btnA3s);
            PushHandButton(btnA2s);
        }

        private void btnBrodways_Click(object sender, EventArgs e)
        {
            PushHandButton(btnAA);
            PushHandButton(btnKK);
            PushHandButton(btnQQ);
            PushHandButton(btnJJ);
            PushHandButton(btnTT);
            PushHandButton(btnAKs);
            PushHandButton(btnAKo);
            PushHandButton(btnAQs);
            PushHandButton(btnAQo);
            PushHandButton(btnAJs);
            PushHandButton(btnAJo);
            PushHandButton(btnATs);
            PushHandButton(btnATo);
            PushHandButton(btnKQs);
            PushHandButton(btnKQo);
            PushHandButton(btnKJs);
            PushHandButton(btnKJo);
            PushHandButton(btnKTs);
            PushHandButton(btnKTo);
            PushHandButton(btnQJs);
            PushHandButton(btnQJo);
            PushHandButton(btnQTs);
            PushHandButton(btnQTo);
            PushHandButton(btnJTs);
            PushHandButton(btnJTo);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void FillButtons()
        {
            string[] hands = this.txtFilterHands.Text.Split(',');

            foreach (string hand in hands)
            {
                switch (hand)
                {
                    case "AA":
                        this.btnAA.BackColor = Color.Gray;
                        break;
                    case "KK":
                        this.btnKK.BackColor = Color.Gray;
                        break;
                    case "QQ":
                        this.btnQQ.BackColor = Color.Gray;
                        break;
                    case "JJ":
                        this.btnJJ.BackColor = Color.Gray;
                        break;
                    case "TT":
                        this.btnTT.BackColor = Color.Gray;
                        break;
                    case "99":
                        this.btn99.BackColor = Color.Gray;
                        break;
                    case "88":
                        this.btn88.BackColor = Color.Gray;
                        break;
                    case "77":
                        this.btn77.BackColor = Color.Gray;
                        break;
                    case "66":
                        this.btn66.BackColor = Color.Gray;
                        break;
                    case "55":
                        this.btn55.BackColor = Color.Gray;
                        break;
                    case "44":
                        this.btn44.BackColor = Color.Gray;
                        break;
                    case "33":
                        this.btn33.BackColor = Color.Gray;
                        break;
                    case "22":
                        this.btn22.BackColor = Color.Gray;
                        break;
                    case "AKs":
                        this.btnAKs.BackColor = Color.Gray;
                        break;
                    case "AQs":
                        this.btnAQs.BackColor = Color.Gray;
                        break;
                    case "AJs":
                        this.btnAJs.BackColor = Color.Gray;
                        break;
                    case "ATs":
                        this.btnATs.BackColor = Color.Gray;
                        break;
                    case "A9s":
                        this.btnA9s.BackColor = Color.Gray;
                        break;
                    case "A8s":
                        this.btnA8s.BackColor = Color.Gray;
                        break;
                    case "A7s":
                        this.btnA7s.BackColor = Color.Gray;
                        break;
                    case "A6s":
                        this.btnA6s.BackColor = Color.Gray;
                        break;
                    case "A5ss":
                        this.btnA5s.BackColor = Color.Gray;
                        break;
                    case "A4s":
                        this.btnA4s.BackColor = Color.Gray;
                        break;
                    case "A3s":
                        this.btnA3s.BackColor = Color.Gray;
                        break;
                    case "A2s":
                        this.btnA2s.BackColor = Color.Gray;
                        break;
                    case "AKo":
                        this.btnAKo.BackColor = Color.Gray;
                        break;
                    case "AQo":
                        this.btnAQo.BackColor = Color.Gray;
                        break;
                    case "AJo":
                        this.btnAJo.BackColor = Color.Gray;
                        break;
                    case "ATo":
                        this.btnATo.BackColor = Color.Gray;
                        break;
                    case "A9o":
                        this.btnA9o.BackColor = Color.Gray;
                        break;
                    case "A8o":
                        this.btnA8o.BackColor = Color.Gray;
                        break;
                    case "A7o":
                        this.btnA7o.BackColor = Color.Gray;
                        break;
                    case "A6o":
                        this.btnA6o.BackColor = Color.Gray;
                        break;
                    case "A5o":
                        this.btnA5o.BackColor = Color.Gray;
                        break;
                    case "A4o":
                        this.btnA4o.BackColor = Color.Gray;
                        break;
                    case "A3o":
                        this.btnA3o.BackColor = Color.Gray;
                        break;
                    case "A2o":
                        this.btnA2o.BackColor = Color.Gray;
                        break;
                    case "KQs":
                        this.btnKQs.BackColor = Color.Gray;
                        break;
                    case "KJs":
                        this.btnKJs.BackColor = Color.Gray;
                        break;
                    case "KTs":
                        this.btnKTs.BackColor = Color.Gray;
                        break;
                    case "K9s":
                        this.btnK9s.BackColor = Color.Gray;
                        break;
                    case "K8s":
                        this.btnK8s.BackColor = Color.Gray;
                        break;
                    case "K7s":
                        this.btnK7s.BackColor = Color.Gray;
                        break;
                    case "K6s":
                        this.btnK6s.BackColor = Color.Gray;
                        break;
                    case "K5s":
                        this.btnK5s.BackColor = Color.Gray;
                        break;
                    case "K4s":
                        this.btnK4s.BackColor = Color.Gray;
                        break;
                    case "K3s":
                        this.btnK3s.BackColor = Color.Gray;
                        break;
                    case "K2s":
                        this.btnK2s.BackColor = Color.Gray;
                        break;
                    case "KQo":
                        this.btnKQo.BackColor = Color.Gray;
                        break;
                    case "KJo":
                        this.btnKJo.BackColor = Color.Gray;
                        break;
                    case "KTo":
                        this.btnKTo.BackColor = Color.Gray;
                        break;
                    case "K9o":
                        this.btnK9o.BackColor = Color.Gray;
                        break;
                    case "K8o":
                        this.btnK8o.BackColor = Color.Gray;
                        break;
                    case "K7o":
                        this.btnK7o.BackColor = Color.Gray;
                        break;
                    case "K6o":
                        this.btnK6o.BackColor = Color.Gray;
                        break;
                    case "K5o":
                        this.btnK5o.BackColor = Color.Gray;
                        break;
                    case "K4o":
                        this.btnK4o.BackColor = Color.Gray;
                        break;
                    case "K3o":
                        this.btnK3o.BackColor = Color.Gray;
                        break;
                    case "K2o":
                        this.btnK2o.BackColor = Color.Gray;
                        break;
                    case "QJs":
                        this.btnQJs.BackColor = Color.Gray;
                        break;
                    case "QTs":
                        this.btnQTs.BackColor = Color.Gray;
                        break;
                    case "Q9s":
                        this.btnQ9s.BackColor = Color.Gray;
                        break;
                    case "Q8s":
                        this.btnQ8s.BackColor = Color.Gray;
                        break;
                    case "Q7s":
                        this.btnQ7s.BackColor = Color.Gray;
                        break;
                    case "Q6s":
                        this.btnQ6s.BackColor = Color.Gray;
                        break;
                    case "Q5s":
                        this.btnQ5s.BackColor = Color.Gray;
                        break;
                    case "Q4s":
                        this.btnQ4s.BackColor = Color.Gray;
                        break;
                    case "Q3s":
                        this.btnQ3s.BackColor = Color.Gray;
                        break;
                    case "Q2s":
                        this.btnQ2s.BackColor = Color.Gray;
                        break;
                    case "QJo":
                        this.btnQJo.BackColor = Color.Gray;
                        break;
                    case "QTo":
                        this.btnQTo.BackColor = Color.Gray;
                        break;
                    case "Q9o":
                        this.btnQ9o.BackColor = Color.Gray;
                        break;
                    case "Q8o":
                        this.btnQ8o.BackColor = Color.Gray;
                        break;
                    case "Q7o":
                        this.btnQ7o.BackColor = Color.Gray;
                        break;
                    case "Q6o":
                        this.btnQ6o.BackColor = Color.Gray;
                        break;
                    case "Q5o":
                        this.btnQ5o.BackColor = Color.Gray;
                        break;
                    case "Q4o":
                        this.btnQ4o.BackColor = Color.Gray;
                        break;
                    case "Q3o":
                        this.btnQ3o.BackColor = Color.Gray;
                        break;
                    case "Q2o":
                        this.btnQ2o.BackColor = Color.Gray;
                        break;
                    case "JTs":
                        this.btnJTs.BackColor = Color.Gray;
                        break;
                    case "J9s":
                        this.btnJ9s.BackColor = Color.Gray;
                        break;
                    case "J8s":
                        this.btnJ8s.BackColor = Color.Gray;
                        break;
                    case "J7s":
                        this.btnJ7s.BackColor = Color.Gray;
                        break;
                    case "J6s":
                        this.btnJ6s.BackColor = Color.Gray;
                        break;
                    case "J5s":
                        this.btnJ5s.BackColor = Color.Gray;
                        break;
                    case "J4s":
                        this.btnJ4s.BackColor = Color.Gray;
                        break;
                    case "J3s":
                        this.btnJ3s.BackColor = Color.Gray;
                        break;
                    case "J2s":
                        this.btnJ2s.BackColor = Color.Gray;
                        break;
                    case "JTo":
                        this.btnJTo.BackColor = Color.Gray;
                        break;
                    case "J9o":
                        this.btnJ9o.BackColor = Color.Gray;
                        break;
                    case "J8o":
                        this.btnJ8o.BackColor = Color.Gray;
                        break;
                    case "J7o":
                        this.btnJ7o.BackColor = Color.Gray;
                        break;
                    case "J6o":
                        this.btnJ6o.BackColor = Color.Gray;
                        break;
                    case "J5o":
                        this.btnJ5o.BackColor = Color.Gray;
                        break;
                    case "J4o":
                        this.btnJ4o.BackColor = Color.Gray;
                        break;
                    case "J3o":
                        this.btnJ3o.BackColor = Color.Gray;
                        break;
                    case "J2o":
                        this.btnJ2o.BackColor = Color.Gray;
                        break;
                    case "T9s":
                        this.btnT9s.BackColor = Color.Gray;
                        break;
                    case "T8s":
                        this.btnT8s.BackColor = Color.Gray;
                        break;
                    case "T7s":
                        this.btnT7s.BackColor = Color.Gray;
                        break;
                    case "T6s":
                        this.btnT6s.BackColor = Color.Gray;
                        break;
                    case "T5s":
                        this.btnT5s.BackColor = Color.Gray;
                        break;
                    case "T4s":
                        this.btnT4s.BackColor = Color.Gray;
                        break;
                    case "T3s":
                        this.btnT3s.BackColor = Color.Gray;
                        break;
                    case "T2s":
                        this.btnT2s.BackColor = Color.Gray;
                        break;
                    case "T9o":
                        this.btnT9o.BackColor = Color.Gray;
                        break;
                    case "T8o":
                        this.btnT8o.BackColor = Color.Gray;
                        break;
                    case "T7o":
                        this.btnT7o.BackColor = Color.Gray;
                        break;
                    case "T6o":
                        this.btnT6o.BackColor = Color.Gray;
                        break;
                    case "T5o":
                        this.btnT5o.BackColor = Color.Gray;
                        break;
                    case "T4o":
                        this.btnT4o.BackColor = Color.Gray;
                        break;
                    case "T3o":
                        this.btnT3o.BackColor = Color.Gray;
                        break;
                    case "T2o":
                        this.btnT2o.BackColor = Color.Gray;
                        break;
                    case "98s":
                        this.btn98s.BackColor = Color.Gray;
                        break;
                    case "97s":
                        this.btn97s.BackColor = Color.Gray;
                        break;
                    case "96s":
                        this.btn96s.BackColor = Color.Gray;
                        break;
                    case "95s":
                        this.btn95s.BackColor = Color.Gray;
                        break;
                    case "94s":
                        this.btn94s.BackColor = Color.Gray;
                        break;
                    case "93s":
                        this.btn93s.BackColor = Color.Gray;
                        break;
                    case "92s":
                        this.btn92s.BackColor = Color.Gray;
                        break;
                    case "98o":
                        this.btn98o.BackColor = Color.Gray;
                        break;
                    case "97o":
                        this.btn97o.BackColor = Color.Gray;
                        break;
                    case "96o":
                        this.btn96o.BackColor = Color.Gray;
                        break;
                    case "95o":
                        this.btn95o.BackColor = Color.Gray;
                        break;
                    case "94o":
                        this.btn94o.BackColor = Color.Gray;
                        break;
                    case "93o":
                        this.btn93o.BackColor = Color.Gray;
                        break;
                    case "92o":
                        this.btn92o.BackColor = Color.Gray;
                        break;
                    case "87s":
                        this.btn87s.BackColor = Color.Gray;
                        break;
                    case "86s":
                        this.btn86s.BackColor = Color.Gray;
                        break;
                    case "85s":
                        this.btn85s.BackColor = Color.Gray;
                        break;
                    case "84s":
                        this.btn84s.BackColor = Color.Gray;
                        break;
                    case "83s":
                        this.btn83s.BackColor = Color.Gray;
                        break;
                    case "82s":
                        this.btn82s.BackColor = Color.Gray;
                        break;
                    case "87o":
                        this.btn87o.BackColor = Color.Gray;
                        break;
                    case "86o":
                        this.btn86o.BackColor = Color.Gray;
                        break;
                    case "85o":
                        this.btn85o.BackColor = Color.Gray;
                        break;
                    case "84o":
                        this.btn84o.BackColor = Color.Gray;
                        break;
                    case "83o":
                        this.btn83o.BackColor = Color.Gray;
                        break;
                    case "82o":
                        this.btn82o.BackColor = Color.Gray;
                        break;
                    case "76s":
                        this.btn76s.BackColor = Color.Gray;
                        break;
                    case "75s":
                        this.btn75s.BackColor = Color.Gray;
                        break;
                    case "74s":
                        this.btn74s.BackColor = Color.Gray;
                        break;
                    case "73s":
                        this.btn73s.BackColor = Color.Gray;
                        break;
                    case "72s":
                        this.btn72s.BackColor = Color.Gray;
                        break;
                    case "76o":
                        this.btn76o.BackColor = Color.Gray;
                        break;
                    case "75o":
                        this.btn75o.BackColor = Color.Gray;
                        break;
                    case "74o":
                        this.btn74o.BackColor = Color.Gray;
                        break;
                    case "73o":
                        this.btn73o.BackColor = Color.Gray;
                        break;
                    case "72o":
                        this.btn72o.BackColor = Color.Gray;
                        break;
                    case "65s":
                        this.btn65s.BackColor = Color.Gray;
                        break;
                    case "64s":
                        this.btn64s.BackColor = Color.Gray;
                        break;
                    case "63s":
                        this.btn63s.BackColor = Color.Gray;
                        break;
                    case "62s":
                        this.btn62s.BackColor = Color.Gray;
                        break;
                    case "65o":
                        this.btn65o.BackColor = Color.Gray;
                        break;
                    case "64o":
                        this.btn64o.BackColor = Color.Gray;
                        break;
                    case "63o":
                        this.btn63o.BackColor = Color.Gray;
                        break;
                    case "62o":
                        this.btn62o.BackColor = Color.Gray;
                        break;
                    case "54s":
                        this.btn54s.BackColor = Color.Gray;
                        break;
                    case "53s":
                        this.btn53s.BackColor = Color.Gray;
                        break;
                    case "52s":
                        this.btn52s.BackColor = Color.Gray;
                        break;
                    case "54o":
                        this.btn54o.BackColor = Color.Gray;
                        break;
                    case "53o":
                        this.btn53o.BackColor = Color.Gray;
                        break;
                    case "52o":
                        this.btn52o.BackColor = Color.Gray;
                        break;
                    case "43s":
                        this.btn43s.BackColor = Color.Gray;
                        break;
                    case "42s":
                        this.btn42s.BackColor = Color.Gray;
                        break;
                    case "43o":
                        this.btn43o.BackColor = Color.Gray;
                        break;
                    case "42o":
                        this.btn42o.BackColor = Color.Gray;
                        break;
                    case "32s":
                        this.btn32s.BackColor = Color.Gray;
                        break;
                    case "32o":
                        this.btn32o.BackColor = Color.Gray;
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}
