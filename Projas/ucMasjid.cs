using System;
using System.Windows.Forms;
using Projas.Service.Entity;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas
{
    public partial class ucMasjid : UserControl
    {
        public ucMasjid()
        {
            InitializeComponent();
        }

   
        private void viewMasjid()
        {
            using (IDapperContext dapperContext = new DapperContext())
            {
                IUnitOfWork uow = new UnitOfWork(dapperContext);
                uow.BeginTransaction();
                var city = uow.cityService.GetAll();
                cbKota.DataSource = city;
                cbKota.DisplayMember = "nama";
                cbKota.ValueMember = "id";

                var masjid = uow.settingService.GetTop1();
                if (masjid != null)
                {
                    cbKota.Text = masjid.NamaKota;
                    txtMasjid.Text = masjid.NamaMasjid;
                    txtAlamat.Text = masjid.Alamat;
                    txtText.Text = masjid.Keterangan;
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

        private void ucMasjid_Load(object sender, EventArgs e)
        {
            try
            {
                viewMasjid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    settings.NamaKota = cbKota.Text;
                    settings.NamaMasjid = txtMasjid.Text;
                    settings.Alamat = txtAlamat.Text;
                    settings.Keterangan = txtText.Text;
                    uow.settingService.Update(settings);


                    uow.Commit();
                    MessageBox.Show("Data Berhasil Disimpan.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
