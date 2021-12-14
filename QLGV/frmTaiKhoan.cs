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
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            QuyenHan_BUS.Instance.LoadCombo(cbbQuyenHan);
            TaiKhoan_BUS.Instance.LoadData(dgvTaiKhoan);
            txtKhoa.Text = "CNTT";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan_BUS.Instance.ThemTaiKhoan(txtTenTK.Text, txtMatKhau.Text, cbbQuyenHan.SelectedValue.ToString(), txtKhoa.Text);
                TaiKhoan_BUS.Instance.LoadData(dgvTaiKhoan);
            } catch (SqlException)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan_BUS.Instance.SuaTaiKhoan(txtTenTK.Text, txtMatKhau.Text, cbbQuyenHan.SelectedValue.ToString(), txtKhoa.Text);
            TaiKhoan_BUS.Instance.LoadData(dgvTaiKhoan);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dlr == DialogResult.Yes)
            {
                TaiKhoan_BUS.Instance.XoaTaiKhoan(txtTenTK.Text);
                TaiKhoan_BUS.Instance.LoadData(dgvTaiKhoan);
            }
        }

        private void dgvTaiKhoan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtTenTK.Text = dgvTaiKhoan.Rows[index].Cells[0].Value.ToString();
            txtMatKhau.Text = dgvTaiKhoan.Rows[index].Cells[1].Value.ToString();
            cbbQuyenHan.SelectedValue = dgvTaiKhoan.Rows[index].Cells[2].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
