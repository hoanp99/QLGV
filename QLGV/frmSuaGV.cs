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
    public partial class frmSuaGV : Form
    {
        private static string GioiTinh;
        public frmSuaGV(frmGiaoVien frm)
        {
            InitializeComponent();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }
        protected void Update()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void frmSuaGV_Load(object sender, EventArgs e)
        {
            DiaChi_BUS.Instance.LoadCombo(cbbDiaChi, 0);
            HocVi_BUS.Instance.LoadCombo(cbbHocVi, 0);
            DVCongTac_BUS.Instance.LoadCombo(cbbDVCT, 0);
            Khoa_BUS.Instance.LoadCombo(cbbKhoa, 0);
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            txtHoDem.Text = frmGiaoVien.hoDem;
            txtTen.Text = frmGiaoVien.ten;
            if (frmGiaoVien.gioiTinh == "Nam")
            {
                rdoNam.Checked = true;
            } else
            {
                rdoNu.Checked = true;
            }
            dtpNgaySinh.Text = frmGiaoVien.ngaySinh;
            txtSoDienThoai.Text = frmGiaoVien.soDienThoai;
            cbbDiaChi.SelectedValue = frmGiaoVien.diaChi;
            cbbDVCT.SelectedValue = frmGiaoVien.dVCT;
            cbbHocVi.SelectedValue = frmGiaoVien.hocVi;
            cbbKhoa.SelectedValue = frmGiaoVien.khoa;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtHoDem.Text.Length < 4 || KiemTra.hasDigit(txtHoDem.Text) || KiemTra.hasSpecChar(txtHoDem.Text))
            {
                lbl1.Visible = true;
            } else if (txtTen.Text.Length < 1 || KiemTra.hasDigit(txtTen.Text) || KiemTra.hasSpecChar(txtTen.Text))
            {
                lbl1.Visible = false;
                lbl2.Visible = true;
            } else if (txtSoDienThoai.Text.Length < 10 || KiemTra.hasLetter(txtSoDienThoai.Text) || KiemTra.hasSpecChar(txtSoDienThoai.Text))
            {
                lbl2.Visible = false;
                lbl3.Visible = true;
            } else
            {
                GiaoVien_BUS.Instance.SuaGiaoVien(frmGiaoVien.maGV, txtHoDem.Text, txtTen.Text, GioiTinh, dtpNgaySinh.Value.Date, txtSoDienThoai.Text, cbbDiaChi.SelectedValue.ToString(), cbbHocVi.SelectedValue.ToString(), cbbDVCT.SelectedValue.ToString(), cbbKhoa.SelectedValue.ToString());
                Update();
                this.Close();
            }
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            GioiTinh = "Nam";
        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {
            GioiTinh = "Nữ";
        }
    }
}
