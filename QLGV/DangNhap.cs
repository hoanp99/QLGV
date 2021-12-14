using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QLGV
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(TaiKhoan_BUS.Instance.ValidateLogin(txtTenTK.Text, txtMatKhau.Text))
            {
                Menu mainMenu = new Menu();
                mainMenu.Show();
                lblDN.Visible = false;
                this.Hide();
            } else
            {
                lblDN.Visible = true;
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            lblDN.Visible = false;
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
