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
    public partial class frmGiaoVien : Form
    {
        public static string maGV, hoDem, ten, gioiTinh, ngaySinh, soDienThoai, diaChi, hocVi, dVCT, khoa;

        private void btnXuat_Click(object sender, EventArgs e)
        {
            frmGiaoVien_Load(sender, e);
            XuatFileExcel.export2Excel("fileGiaoVien", dgvGiaoVien);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdoTatCa.Checked)
            {
                GiaoVien_BUS.Instance.TimKiemGiaoVien(cbbHocVi.SelectedValue.ToString(), cbbDiaChi.SelectedValue.ToString(), cbbDVCT.SelectedValue.ToString(), cbbKhoa.SelectedValue.ToString(), cbbGioiTinh.SelectedItem.ToString(), dgvGiaoVien);
            } else if (rdoDPC.Checked)
            {
                GiaoVien_BUS.Instance.TimKiemGiaoVienDPC(dgvGiaoVien);
            } else
            {
                GiaoVien_BUS.Instance.TimKiemGiaoVienCPC(dgvGiaoVien);
            }          
            lblSGV.Text = dgvGiaoVien.RowCount + "";
        }

        private void dgvGiaoVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            maGV = dgvGiaoVien.Rows[index].Cells[0].Value.ToString();
            try
            {
                string hoTen = dgvGiaoVien.Rows[index].Cells[1].Value.ToString();
                int i = hoTen.LastIndexOf(' ');
                ten = hoTen.Substring(i + 1);
                hoDem = hoTen.Substring(0, i);
            }
            catch (Exception)
            {

            }        
            gioiTinh = dgvGiaoVien.Rows[index].Cells[2].Value.ToString();
            ngaySinh = dgvGiaoVien.Rows[index].Cells[3].Value.ToString();
            soDienThoai = dgvGiaoVien.Rows[index].Cells[4].Value.ToString();
            diaChi = dgvGiaoVien.Rows[index].Cells[5].Value.ToString();
            hocVi = dgvGiaoVien.Rows[index].Cells[6].Value.ToString();
            dVCT = dgvGiaoVien.Rows[index].Cells[7].Value.ToString();
            khoa = dgvGiaoVien.Rows[index].Cells[8].Value.ToString();
        }

        public frmGiaoVien()
        {
            InitializeComponent();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {

                GiaoVien_BUS.Instance.LoadData(dgvGiaoVien);
                dgvGiaoVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                HocVi_BUS.Instance.LoadCombo(cbbHocVi, 1);
                DiaChi_BUS.Instance.LoadCombo(cbbDiaChi, 1);
                DVCongTac_BUS.Instance.LoadCombo(cbbDVCT, 1);
                Khoa_BUS.Instance.LoadCombo(cbbKhoa, 1);
                cbbGioiTinh.SelectedIndex = 0;
                lblSGV.Text = dgvGiaoVien.RowCount + "";
                rdoTatCa.Checked = true;
        }

        private void ThemGV_UpdateEventHandler(object sender, frmThemGV.UpdateEventArgs args)
        {
            GiaoVien_BUS.Instance.LoadData(dgvGiaoVien);
            lblSGV.Text = dgvGiaoVien.RowCount + "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemGV frm = new frmThemGV(this);
            frm.UpdateEventHandler += ThemGV_UpdateEventHandler;
            frm.ShowDialog();
        }

        private void SuaGV_UpdateEventHandler(object sender, frmSuaGV.UpdateEventArgs args)
        {
            GiaoVien_BUS.Instance.LoadData(dgvGiaoVien);
            lblSGV.Text = dgvGiaoVien.RowCount + "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgvGiaoVien.Rows.Count+"");
            frmSuaGV frm = new frmSuaGV(this);
            frm.UpdateEventHandler += SuaGV_UpdateEventHandler;
            frm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                GiaoVien_BUS.Instance.XoaGiaoVien(maGV);
                GiaoVien_BUS.Instance.LoadData(dgvGiaoVien);
                lblSGV.Text = dgvGiaoVien.RowCount + "";
            }
        }
    }
}
