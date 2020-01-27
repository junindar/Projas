using System;
using Projas.Service.Entity;
using System.Windows.Forms;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas
{
    public partial class ucDurasi : UserControl
    {
        public ucDurasi()
        {
            InitializeComponent();
        }
        private void viewDurasi()
        {
            using (IDapperContext dapperContext = new DapperContext())
            {
                IUnitOfWork uow = new UnitOfWork(dapperContext);
                uow.BeginTransaction();
              

                var masjid = uow.settingService.GetTop1();
                if (masjid != null)
                {
                    txtSubuh.Text = masjid.DurasiSubuh.ToString();
                    txtDzuhur.Text = masjid.DurasiDzuhur.ToString();
                    txtAshar.Text = masjid.DurasiAshar.ToString();
                    txtMaghrib.Text = masjid.DurasiMaghrib.ToString();
                    txtIsya.Text = masjid.DurasiIsya.ToString();
                }

                uow.Commit();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            var form = (Form)TopLevelControl;

            if (form != null && form.Controls["pnlMenu"] is Panel panelMenu)
            {
                if (panelMenu.Controls["SidePanel"] is Panel sidePanel)
                {
                    sidePanel.Visible = false;
                }
            }

            if (form != null && form.Controls["pnlUC"] is Panel pnlUc)
            {
                foreach (Control itm in pnlUc.Controls)
                {
                    pnlUc.Controls.Remove(itm);
                }
            }
               
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDapperContext dapperContext = new DapperContext())
                {
                    IUnitOfWork uow = new UnitOfWork(dapperContext);
                    uow.BeginTransaction();
                    var settings = new Settings();
                    settings.DurasiSubuh = Convert.ToInt32(txtSubuh.Text);
                    settings.DurasiDzuhur = Convert.ToInt32(txtDzuhur.Text);
                    settings.DurasiAshar = Convert.ToInt32(txtAshar.Text);
                    settings.DurasiMaghrib = Convert.ToInt32(txtMaghrib.Text);
                    settings.DurasiIsya = Convert.ToInt32(txtIsya.Text);
                    uow.settingService.UpdateDurasi(settings);


                    uow.Commit();
                    MessageBox.Show("Data Berhasil Disimpan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ucDurasi_Load(object sender, EventArgs e)
        {
            try
            {
                viewDurasi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
