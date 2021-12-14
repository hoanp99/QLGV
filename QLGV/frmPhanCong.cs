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
    public partial class frmPhanCong : Form
    {
        private string MaGV, MaHP;
        public frmPhanCong()
        {
            InitializeComponent();
        }

        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            HocPhan_BUS.Instance.LoadCombo(cbbMaHP);
            GiaoVien_BUS.Instance.LoadCombo(cbbMaGV);
            CTDT_BUS.Instance.LoadCombo(cbbCTDT);
            PhanCong_BUS.Instance.LoadData(dgvPhanCong);
            cbbNamHoc.SelectedIndex = 0;
            cbbHocKy.SelectedIndex = 0;
            lblSKQ.Text = dgvPhanCong.RowCount + "";
        }

        private void ThemPC_UpdateEventHandler(object sender, frmThemPC.UpdateEventArgs args)
        {
            PhanCong_BUS.Instance.LoadData(dgvPhanCong);
            lblSKQ.Text = dgvPhanCong.RowCount + "";
        }

        private void btnPC_Click(object sender, EventArgs e)
        {
            frmThemPC frmThem = new frmThemPC(this);
            frmThem.UpdateEventHandler += ThemPC_UpdateEventHandler;
            frmThem.ShowDialog();
        }

        private void dgvPhanCong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            MaGV = dgvPhanCong.Rows[index].Cells[0].Value.ToString();
            MaHP = dgvPhanCong.Rows[index].Cells[2].Value.ToString();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            PhanCong_BUS.Instance.LoadData(dgvPhanCong);
            lblSKQ.Text = dgvPhanCong.RowCount + "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            PhanCong_BUS.Instance.TimKiemPC(cbbNamHoc.SelectedItem.ToString(), cbbHocKy.SelectedItem.ToString(), cbbMaHP.SelectedValue.ToString(), cbbMaGV.SelectedValue.ToString(), cbbCTDT.SelectedValue.ToString(), dgvPhanCong);
            lblSKQ.Text = dgvPhanCong.RowCount + "";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            frmPhanCong_Load(sender, e);
            XuatFileExcel.export2Excel("filePhanCong", dgvPhanCong);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn Chắc Chắn Muốn Xóa?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                PhanCong_BUS.Instance.XoaPC(MaGV, MaHP);
                PhanCong_BUS.Instance.LoadData(dgvPhanCong);
                lblSKQ.Text = dgvPhanCong.RowCount + "";
            }
        }
    }
}
