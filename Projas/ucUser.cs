using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projas.Service.Entity;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas
{
    public partial class ucUser : UserControl
    {
        public ucUser()
        {
            InitializeComponent();
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
                if (txtBaru.Text != txtReBaru.Text)
                {
                    throw new Exception("Password Baru dan Re-Password Baru tidak sama.");
                }
                using (IDapperContext dapperContext = new DapperContext())
                {
                    IUnitOfWork uow = new UnitOfWork(dapperContext);
                    uow.BeginTransaction();
                    var user=new User();
                    user.Password = txtBaru.Text;



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
