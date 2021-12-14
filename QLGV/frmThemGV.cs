using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace QLGV
{
    public partial class frmThemGV : Form
    {
        private string GioiTinh;
        public frmThemGV(frmGiaoVien frm)
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

        private void frmThemGV_Load(object sender, EventArgs e)
        {
            DiaChi_BUS.Instance.LoadCombo(cbbDiaChi, 0);
            HocVi_BUS.Instance.LoadCombo(cbbHocVi, 0);
            DVCongTac_BUS.Instance.LoadCombo(cbbDVCT, 0);
            Khoa_BUS.Instance.LoadCombo(cbbKhoa, 0);
            rdoNam.Checked = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtHoDem.Text.Length < 1 || KiemTra.hasDigit(txtHoDem.Text) || KiemTra.hasSpecChar(txtHoDem.Text))
            {
                lbl1.Visible = true;
            } else if (txtTen.Text.Length < 1 || KiemTra.hasDigit(txtTen.Text) || KiemTra.hasSpecChar(txtTen.Text))
            {
                lbl1.Visible = false;
                lbl2.Visible = true;
            } else if (txtSoDienThoai.Text.Length < 10 || KiemTra.hasSpecChar(txtSoDienThoai.Text) || KiemTra.hasLetter(txtSoDienThoai.Text))
            {
                lbl2.Visible = false;
                lbl3.Visible = true;
            } else
            {
                try
                {
                    lbl3.Visible = false;
                    GiaoVien_BUS.Instance.ThemGiaoVien(txtHoDem.Text, txtTen.Text, GioiTinh, dtpNgaySinh.Value.Date, txtSoDienThoai.Text, cbbDiaChi.SelectedValue.ToString(), cbbHocVi.SelectedValue.ToString(), cbbDVCT.SelectedValue.ToString(), cbbKhoa.SelectedValue.ToString());
                    Update();
                    this.Close();
                } catch (SqlException)
                {
                    MessageBox.Show("Lỗi");
                }
                
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

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
