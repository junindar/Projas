using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BunifuAnimatorNS;

namespace Projas
{
    public partial class frmIqomah : Form
    {
        public string NamaSholat { get; set; }
        public string Text { get; set; }
        public int DurasiIqomah { get; set; }
        public int iCountDown { get; set; }
        private const int iAdzanWait = 60;
        private const int iIqomahWait = 30;
        private DateTime _dtIqomah;
        private bool IsIqomah ;
        private bool IsBlink ;

        public frmIqomah()
        {
            InitializeComponent();

            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;

            lblTime.Width = pnlTemplate.Width;


            lblTime.Top = Screen.PrimaryScreen.Bounds.Height / 2;
            cpProgress.Top = (Screen.PrimaryScreen.Bounds.Height / 2)-100;
            cpProgress.Left =(Width / 2)-260 ; 
        }

        private void frmIqomah_Load(object sender, EventArgs e)
        {
            lblTime.Visible = false;
         
        }

        private void tmrAzan_Tick(object sender, EventArgs e)
        {
            if (iCountDown >= 0)
            {

                cpProgress.Text = iCountDown.ToString();
                cpProgress.Value = iCountDown;
                lblText.Text = "Menuju Waktu Adzan";
                lblSholat.Text = $"Sholat {NamaSholat}";
                lblTime.Text = iCountDown.ToString();
                cpProgress.Visible = true;
                iCountDown--;
            }

            if (iCountDown<0 && iCountDown>=-iAdzanWait)
            {
                lblText.Text = "WAKTU ADZAN";
                lblSholat.Text = NamaSholat;
                lblTime.Text = "00:00";
                tmrBlink.Enabled = true;
                iCountDown--;

            }

            if (iCountDown <= -iAdzanWait-1)
            {
                tmrAzan.Enabled = false;
                tmrIqomah.Enabled = true;
                tmrBlink.Enabled = false;
                cpProgress.Visible = false;
                lblTime.Visible = true;

                iCountDown = (DurasiIqomah*60)+iCountDown;
                _dtIqomah= DateTime.Now.AddSeconds(iCountDown);
                lblText.Text = "Menuju IQOMAH";
                lblSholat.Text = $"Sholat {NamaSholat}";
                iCountDown = 0;
            }

        }

        private void tmrIqomah_Tick(object sender, EventArgs e)
        {
            if (_dtIqomah>=DateTime.Now  )
            {
                lblTime.Text = _dtIqomah.Subtract(DateTime.Now).ToString("mm':'ss");
               
                return;
            }
           
            if (lblTime.Text == "00:00" && IsIqomah==false)
            {
                iCountDown = iIqomahWait;
                IsIqomah = true;


            }

            if (iCountDown > 0)
            {
                lblText.Text = "WAKTU IQOMAH";
                lblSholat.Text = $"Sholat {NamaSholat}";
                lblTime.Visible = false;
                tmrBlink.Enabled = true;
                iCountDown--;
            }
            else if (iCountDown == 0 && lblTime.Text=="00:00")
            {
                Close();
            }
        }

        private void tmrBlink_Tick(object sender, EventArgs e)
        {
            if (IsBlink )
            {
                IsBlink = false;
                lblText.ForeColor = Color.Yellow;
                lblSholat.ForeColor = Color.Yellow;
                BunifuTransition transition = new BunifuTransition();
                transition.ShowSync(cpProgress, false, Animation.Particles);
            }
            else
            {
                IsBlink = true;
                lblText.ForeColor = Color.White;
                lblSholat.ForeColor = Color.White;
                BunifuTransition transition = new BunifuTransition();
                transition.HideSync(cpProgress, false, Animation.Particles);

            }
        }
    }
}
