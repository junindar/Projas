using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            lblTime.Width = panel6.Width;


            lblTime.Top = Screen.PrimaryScreen.Bounds.Height / 2;


        }

        private void frmIqomah_Load(object sender, EventArgs e)
        {

           
        }

        private void tmrAzan_Tick(object sender, EventArgs e)
        {
            if (iCountDown >= 0)
            {
                lblText.Text = "Menuju Waktu Adzan";
                lblSholat.Text = $"Sholat {NamaSholat}";
                lblTime.Text = iCountDown.ToString();
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
                lblTime.ForeColor = Color.Yellow;
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
                tmrBlink.Enabled = true;
                lblTime.ForeColor = Color.Yellow;
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
                lblTime.ForeColor = Color.Yellow;
                IsBlink = false;
            }
            else
            {
                lblTime.ForeColor = Color.Red;
                IsBlink = true;
            }
        }
    }
}
