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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!TaiKhoan_BUS.Instance.ValidatePassWord(txtOldPass.Text))
            {
                lbl1.Visible = true;
            } else if (!KiemTra.hasDigit(txtNewPass.Text) || !KiemTra.hasSpecChar(txtNewPass.Text) || !KiemTra.hasLetterUpper(txtNewPass.Text) || !KiemTra.hasLetter(txtNewPass.Text) || txtNewPass.Text.Length < 8)
            {
                lbl1.Visible = false;
                lbl2.Visible = true;
            } else if (txtNewPass2.Text != txtNewPass.Text)
            {
                lbl2.Visible = false;
                lbl3.Visible = true;
            } else
            {
                TaiKhoan_BUS.Instance.DoiMatKhau(txtNewPass.Text);
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
