using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Projas.Service.Entity;
using Projas.Service.Helper;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas
{
    public partial class frmSetting : Form
    {
        

        private bool dragging = false;
       
        Point startPoint =new Point(0,0);
        public frmSetting()
        {
            InitializeComponent();
            SidePanel.Visible = false;
            // SidePanel.Height = btnMasjid.Height;
            //  SidePanel.Top = btnMasjid.Top;
            //  ucMasjid1.BringToFront();
        }

      
      
        private async void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
               // var watch = Stopwatch.StartNew();
               //var cities=new List<City>();
               //var jadwals = new List<Jadwal>();


              


                //using (IDapperContext dapperContext = new DapperContext())
                //{
                //    IUnitOfWork uow = new UnitOfWork(dapperContext);
                //    uow.BeginTransaction();
                //    uow.cityService.InsertAll(cities);
                //    uow.Commit();
                //}

                //foreach (var itm in cities)
                //{
                //    using (IDapperContext dapperContext = new DapperContext())
                //    {
                //        IUnitOfWork uow = new UnitOfWork(dapperContext);
                //        uow.BeginTransaction();

                //        var jadwalKota = jadwals.Where(c => c.kota == itm.nama).ToList();
                //        uow.jadwalService.InsertAll(jadwalKota);


                //        uow.Commit();
                //    }
                //}

                //ReadWriteTextFile.ExportJadwalKotaToDB();
                //MessageBox.Show("Selesai");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
          
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void frmSetting_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint=new Point(e.X,e.Y);
        }

        private void frmSetting_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void frmSetting_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location=new Point(p.X-this.startPoint.X,p.Y-this.startPoint.Y);
            }
        }

        private void btnMasjid_Click(object sender, EventArgs e)
        {
            foreach (Control itm in this.pnlUC.Controls)
            {
                this.pnlUC.Controls.Remove(itm);
            }
            ucMasjid uc1 = new ucMasjid();
            this.pnlUC.Controls.Add(uc1);
            SidePanel.Visible = true;
            SidePanel.Height = btnMasjid.Height;
            SidePanel.Top = btnMasjid.Top;
            uc1.Dock = DockStyle.Fill;
            uc1.BringToFront();
        }

        private void btnDurasi_Click(object sender, EventArgs e)
        {
            foreach (Control itm in this.pnlUC.Controls)
            {
                this.pnlUC.Controls.Remove(itm);
            }
            ucDurasi uc1 = new ucDurasi();
            this.pnlUC.Controls.Add(uc1);
            SidePanel.Visible = true;
            SidePanel.Height = btnDurasi.Height;
            SidePanel.Top = btnDurasi.Top;
            uc1.Dock = DockStyle.Fill;
            uc1.BringToFront();
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            foreach (Control itm in this.pnlUC.Controls)
            {
                this.pnlUC.Controls.Remove(itm);
            }
            ucUser uc1 = new ucUser();
            this.pnlUC.Controls.Add(uc1);
            SidePanel.Visible = true;
            SidePanel.Height = btnPassword.Height;
            SidePanel.Top = btnPassword.Top;
            uc1.Dock = DockStyle.Fill;
            uc1.BringToFront();
        }
    }
}
