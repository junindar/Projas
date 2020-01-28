using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projas.Service.Entity;
using Projas.Service.IService;
using Projas.Service.Service;

namespace Projas
{
    public partial class frmLogin : Form
    {
      
        public frmLogin()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUsername.Text) )
                {
                    throw new Exception("Masukkan username dan password");
                }
                User user;
                using (IDapperContext dapperContext = new DapperContext())
                {
                    IUnitOfWork uow = new UnitOfWork(dapperContext);
                    uow.BeginTransaction();
                    user = uow.userService.GetUser();
                    uow.Commit();
                }

                if (user.Username.ToLower() != txtUsername.Text.ToLower())
                {
                    throw new Exception("Username tidak ditemukan.");
                }
                if (user.Password != txtPassword.Text)
                {
                    throw new Exception("Password salah.");
                }

                Opacity = 0;
                var frm = new frmSetting();
                frm.Password = user.Password;
                frm.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            txtPassword.Select();
        }
    }
}
