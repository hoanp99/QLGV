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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void quảnLýGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == "frmGiaoVien")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if(TaiKhoan_BUS.temp == "ADMIN" || TaiKhoan_BUS.temp == "QLGV")
            {
                if (isOpen == false)
                {
                    frmGiaoVien frmGV = new frmGiaoVien();
                    frmGV.MdiParent = this;
                    frmGV.Show();
                }
            } else
            {
                MessageBox.Show("Bạn ko có quyền truy cập mục này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void phânCôngGiảngDạyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmPhanCong")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (TaiKhoan_BUS.temp == "ADMIN" || TaiKhoan_BUS.temp == "PCGD")
            {
                if(isOpen == false)
                {
                    frmPhanCong frmPC = new frmPhanCong();
                    frmPC.MdiParent = this;
                    frmPC.Show();
                }

            } else
            {
                MessageBox.Show("Bạn ko có quyền truy cập mục này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "DoiMatKhau")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
                if (isOpen == false)
                {
                    DoiMatKhau doiMatKhau = new DoiMatKhau();
                    doiMatKhau.MdiParent = this;
                    doiMatKhau.Show();
                }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmTaiKhoan")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if(TaiKhoan_BUS.temp == "ADMIN")
            {
                if (isOpen == false)
                {
                    frmTaiKhoan frmTaiKhoan = new frmTaiKhoan();
                    frmTaiKhoan.MdiParent = this;
                    frmTaiKhoan.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn ko có quyền truy cập mục này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void quảnLýHọcPhầnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "frmHocPhan")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (TaiKhoan_BUS.temp == "ADMIN")
            {
                if (isOpen == false)
                {
                    frmHocPhan frmHocPhan = new frmHocPhan();
                    frmHocPhan.MdiParent = this;
                    frmHocPhan.Show();
                }
            }
            else
            {
                MessageBox.Show("Bạn ko có quyền truy cập mục này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nếu bạn không chạy được chương trình.\nHãy kiểm tra kết nối tới csdl. Sau đó xóa tất cả bảng trong file linq rồi hãy kéo thả các bảng từ csdl bạn vừa kết nối lại", "Trợ giúp", MessageBoxButtons.OK);
        }
    }
}
