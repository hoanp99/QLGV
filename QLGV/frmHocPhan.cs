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
using System.Data.SqlClient;

namespace QLGV
{
    public partial class frmHocPhan : Form
    {
        public frmHocPhan()
        {
            InitializeComponent();
        }

        private void frmHocPhan_Load(object sender, EventArgs e)
        {
            Khoa_BUS.Instance.LoadCombo(cbbKhoa, 1);
            CTDT_BUS.Instance.LoadCombo(cbbCTDT);
            CTDT_BUS.Instance.LoadCombo(cbbCTDTT);
            Khoa_BUS.Instance.LoadCombo(cbbKhoaa, 0);
            HocPhan_BUS.Instance.LoadData(dgvHocPhan);
            lblSKQ.Text = dgvHocPhan.RowCount + "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HocPhan_BUS.Instance.TimKiemHP(cbbCTDT.SelectedValue.ToString(), cbbKhoa.SelectedValue.ToString(), dgvHocPhan);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra.hasSpecChar(txtMaHP.Text))
                {
                    lbl1.Visible = true;
                } else if (KiemTra.hasSpecChar(txtTenHP.Text))
                {
                    lbl1.Visible = false;
                    lbl2.Visible = true;
                } else if (KiemTra.hasSpecChar(txtSoTCC.Text) || KiemTra.hasLetter(txtSoTCC.Text))
                {
                    lbl2.Visible = false;
                    lbl3.Visible = true;
                } else
                {
                    HocPhan_BUS.Instance.ThemHocPhan(txtMaHP.Text, txtTenHP.Text, txtSoTCC.Text, cbbCTDTT.SelectedValue.ToString(), cbbKhoaa.SelectedValue.ToString());
                    HocPhan_BUS.Instance.LoadData(dgvHocPhan);
                    lblSKQ.Text = dgvHocPhan.RowCount + "";
                }
            } catch (SqlException)
            {
                MessageBox.Show("Mã học phần đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                HocPhan_BUS.Instance.XoaHocPhan(txtMaHP.Text);
                HocPhan_BUS.Instance.LoadData(dgvHocPhan);
                lblSKQ.Text = dgvHocPhan.RowCount + "";
            }
        }

        private void dgvHocPhan_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtMaHP.Text = dgvHocPhan.Rows[index].Cells[0].Value.ToString();
            txtTenHP.Text = dgvHocPhan.Rows[index].Cells[1].Value.ToString();
            txtSoTCC.Text = dgvHocPhan.Rows[index].Cells[2].Value.ToString();
            cbbCTDTT.SelectedValue = dgvHocPhan.Rows[index].Cells[3].Value.ToString();
            cbbKhoaa.SelectedValue = dgvHocPhan.Rows[index].Cells[4].Value.ToString();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            frmHocPhan_Load(sender, e);
            XuatFileExcel.export2Excel("fileHocPhan", dgvHocPhan);
        }
    }
}
