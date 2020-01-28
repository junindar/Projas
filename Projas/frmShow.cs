using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projas.Service.Entity;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas
{
    public partial class frmShow : Form
    {
        // private int timeLeft;
        string strTime ;
        private string _strSholat;
        private string _namaKota;
        private int _xpos, _ypos;
        private int iIqomah;
        private int iSubuh;
        private int iDzuhur;
        private int iAshar;
        private int iMaghrib;
        private int iIsya;
        private string strCurrentDate;
        public frmShow()
        {
            InitializeComponent();
           
        }

        private int imageNumber = 1;

        private void loadAllData()
        {
            Settings settingResult;
            Jadwal jadwalResult=null;
            using (IDapperContext dapperContext = new DapperContext())
            {
                IUnitOfWork uow = new UnitOfWork(dapperContext);
                uow.BeginTransaction();
                settingResult = uow.settingService.GetTop1();
                if (settingResult != null)
                {
                    jadwalResult = uow.jadwalService.GetTodayJadwal(settingResult.NamaKota,
                        DateTime.Now.ToString("dddd, dd MMM yyyy"));
                }
                uow.Commit();
            }

            ViewMasjidData(settingResult);
            ViewJadwal(jadwalResult);
            countDownSholat();

        }

        private void countDownSholat()
        {
           
            DateTime dtSubuh = Convert.ToDateTime(DateTime.Today.Date.ToString("dd/MM/yyyy") + " " + lblSubuhTime.Text.Replace(":","."));
            DateTime dtDzuhur = Convert.ToDateTime(DateTime.Today.Date.ToString("dd/MM/yyyy") + " " + lblZuhurTime.Text.Replace(":", "."));
            DateTime dtAshar = Convert.ToDateTime(DateTime.Today.Date.ToString("dd/MM/yyyy") + " " + lblAshartime.Text.Replace(":", "."));
            DateTime dtMagrib = Convert.ToDateTime(DateTime.Today.Date.ToString("dd/MM/yyyy") + " " + lblMagribtime.Text.Replace(":", "."));
            DateTime dtIsya = Convert.ToDateTime(DateTime.Today.Date.ToString("dd/MM/yyyy") + " " + lblIsyaTime.Text.Replace(":", "."));

            if (dtSubuh > DateTime.Now)
            {
                strTime = dtSubuh.ToString("dd/MM/yyyy hh.mm");
                _strSholat = "Subuh";
                iIqomah = iSubuh;
            }
            else if (dtDzuhur > DateTime.Now)
            {
                strTime = dtDzuhur.ToString("dd/MM/yyyy HH.mm");
                _strSholat = "Dzuhur";
                iIqomah = iDzuhur;
            }
            else if (dtAshar > DateTime.Now)
            {
                strTime = dtAshar.ToString("dd/MM/yyyy HH.mm");
                _strSholat = "Ashar";
                iIqomah = iAshar;
            }
            else if (dtMagrib > DateTime.Now)
            {
                strTime = dtMagrib.ToString("dd/MM/yyyy HH.mm");
                _strSholat = "Maghrib";
                iIqomah = iMaghrib;
            }
            else if (dtIsya > DateTime.Now)
            {
                strTime = dtIsya.ToString("dd/MM/yyyy HH.mm");
                _strSholat = "Isya";
                iIqomah = iIsya;
            }

        }
        private void ViewMasjidData(Settings setting)
        {

            if (setting != null)
            {
                _namaKota = setting.NamaKota;
                lblNamaMasjid.Text = setting.NamaMasjid;
                lblalamat.Text = setting.Alamat;
                lblRunningText.Text = setting.Keterangan;
                iSubuh = setting.DurasiSubuh;
                iDzuhur = setting.DurasiDzuhur;
                iAshar = setting.DurasiAshar;
                iMaghrib = setting.DurasiMaghrib;
                iIsya = setting.DurasiIsya;
            }
        }

        private void ViewJadwal(Jadwal jadwal)
        {

            if (jadwal != null)
            {
                lblImsakTime.Text = jadwal.imsak;
                lblSubuhTime.Text = jadwal.subuh;
                lblZuhurTime.Text = jadwal.dzuhur;
                lblAshartime.Text = jadwal.ashar;
                lblMagribtime.Text = jadwal.maghrib;
                lblIsyaTime.Text = jadwal.isya;
            }
        }


        private void LoadImage()
        {
            if (imageNumber == 8)
            {
                imageNumber = 1;
            }

            pictureBox1.ImageLocation = $"images\\masjid{imageNumber}.jpg";
            imageNumber++;
        }

        private string ConvertIntToArabMonthName(int imonth)
        {
            string strName = "";
            if (imonth == 1)
            {
                strName = "Muharam";
            }
            else if (imonth == 2)
            {
                strName = "Safar";
            }
            else if (imonth == 3)
            {
                strName = "Rabi'ul Awal";
            }
            else if (imonth == 4)
            {
                strName = "Rabi'ul Akhir";
            }
            else if (imonth == 5)
            {
                strName = "Jumadil Awal";
            }
            else if (imonth == 6)
            {
                strName = "Jumadil Akhir";
            }
            else if (imonth == 7)
            {
                strName = "Rajab";
            }
            else if (imonth == 8)
            {
                strName = "Sya'ban";
            }
            else if (imonth == 9)
            {
                strName = "Ramadhan";
            }
            else if (imonth == 10)
            {
                strName = "	Syawal";
            }
            else if (imonth == 11)
            {
                strName = "Dzulqaidah";
            }
            else if (imonth == 12)
            {
                strName = "Dzulhijjah";
            }
            return strName;
        }

        private void LoadFormSettings()
        {
            loadAllData();

            strCurrentDate = DateTime.Today.ToString("dd/MM/yyyy");
            pnlJadwal.Width = Screen.PrimaryScreen.Bounds.Width;

            var intWidth = pnlJadwal.Width / 6;
            var xLoc = intWidth;
            var xSpace = 3;
            pnlImsak.Height = pnlJadwal.Height;
            pnlImsak.Width = intWidth;
            pnlSubuh.Height = pnlJadwal.Height;
            pnlSubuh.Width = intWidth;
            pnlDzuhur.Height = pnlJadwal.Height;
            pnlDzuhur.Width = intWidth;
            pnlAshar.Height = pnlJadwal.Height;
            pnlAshar.Width = intWidth;
            pnlMagrib.Height = pnlJadwal.Height;
            pnlMagrib.Width = intWidth;
            pnlIsya.Height = pnlJadwal.Height;
            pnlIsya.Width = intWidth;

            pnlSubuh.Location = new Point(intWidth + xSpace + 2, 0);
            intWidth += xLoc + xSpace;

            pnlDzuhur.Location = new Point(intWidth + xSpace + 2, 0);
            intWidth += xLoc + xSpace; ;

            pnlAshar.Location = new Point(intWidth + xSpace + 2, 0);
            intWidth += xLoc + xSpace; ;

            pnlMagrib.Location = new Point(intWidth + xSpace + 2, 0);
            intWidth += xLoc + xSpace; ;

            pnlIsya.Location = new Point(intWidth + xSpace + 2, 0);
            pnlIsya.Width = Screen.PrimaryScreen.Bounds.Width - (intWidth + xSpace + 5);


            lblImsyak.Left = (pnlImsak.Width - lblImsyak.Size.Width) / 2;
            lblSubuh.Left = (pnlSubuh.Width - lblSubuh.Size.Width) / 2;
            lblDzuhur.Left = (pnlDzuhur.Width - lblDzuhur.Size.Width) / 2;
            lblAshar.Left = (pnlAshar.Width - lblAshar.Size.Width) / 2;
            lblMagrib.Left = (pnlMagrib.Width - lblMagrib.Size.Width) / 2;
            lblIsya.Left = (pnlIsya.Width - lblIsya.Size.Width) / 2;

            lblImsakTime.Left = (pnlImsak.Width - lblImsakTime.Size.Width) / 2;
            lblSubuhTime.Left = (pnlSubuh.Width - lblSubuhTime.Size.Width) / 2;
            lblZuhurTime.Left = (pnlSubuh.Width - lblZuhurTime.Size.Width) / 2;
            lblAshartime.Left = (pnlAshar.Width - lblAshartime.Size.Width) / 2;
            lblMagribtime.Left = (pnlMagrib.Width - lblMagribtime.Size.Width) / 2;
            lblIsyaTime.Left = (pnlIsya.Width - lblIsyaTime.Size.Width) / 2;
            lblJam.Location = new Point(pnlJadwal.Width - 210, 9);
            lblTanggalArab.Location = new Point(pnlJadwal.Width - 230, 60);
            lblalamat.Width = pnlJadwal.Width;

            lblNamaMasjid.Left = (Screen.PrimaryScreen.Bounds.Width - lblNamaMasjid.Size.Width) / 2;
            lblalamat.Left = (Screen.PrimaryScreen.Bounds.Width - lblalamat.Size.Width) / 2;

            pnlCountDown.Location = new Point(0, Screen.PrimaryScreen.Bounds.Height - 250);

            lblHari.Text = DateTime.Now.ToString("dddd");
            lblTanggal.Text = DateTime.Now.ToString("dd MMMM yyyy");
            HijriCalendar myCal = new HijriCalendar();
            lblTanggalArab.Text = $"{myCal.GetDayOfMonth(DateTime.Today)} {ConvertIntToArabMonthName(myCal.GetMonth(DateTime.Today))} {myCal.GetYear(DateTime.Today)}";
            tmrImage.Enabled = true;
            tmrJam.Enabled = true;
            _xpos = lblRunningText.Location.X;
            _ypos = lblRunningText.Location.Y;

          

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFormSettings();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tmrImage_Tick(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void tmrRunningText_Tick(object sender, EventArgs e)
        {
            if (_xpos <= -(lblRunningText.Width + 10))
            {
                lblRunningText.Location = new Point(Width, _ypos);
                _xpos = Width;
            }
            else
            {
                lblRunningText.Location = new Point(_xpos, _ypos);
                _xpos -= 2;
            }
        }

        private void tmrCountDown_Tick(object sender, EventArgs e)
        {


            TimeSpan ts = Convert.ToDateTime(strTime).Subtract(DateTime.Now);
            lblCountDown.Text = _strSholat + " - " + ts.ToString("hh':'mm':'ss");
            if (lblCountDown.Text == _strSholat + " - 00:01:40")
            {
                TopMost = false;
                var frm = new frmIqomah
                {
                    iCountDown = 100, DurasiIqomah = iIqomah, NamaSholat = _strSholat, TopMost = true
                };
                frm.ShowDialog();
                countDownSholat();
            }

        }

      

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormSettings();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pengaturanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TopMost = false;
                var frm = new frmLogin();
                frm.ShowDialog();
                LoadFormSettings();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TopMost = false;
                var frm = new frmIqomah();
                frm.iCountDown = 5;
                frm.DurasiIqomah = iIqomah;
                frm.NamaSholat = _strSholat;
               // frm.TopMost = true;
                frm.ShowDialog();
                countDownSholat();

                TopMost = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tmrJam_Tick(object sender, EventArgs e)
        {
            lblJam.Text = DateTime.Now.ToString("HH:mm:ss");
            lblJam.Text = lblJam.Text.Replace(".", ":");
            if (strCurrentDate != DateTime.Today.ToString("dd/MM/yyyy"))
            {
                LoadFormSettings();
            }
        }
    }
}
