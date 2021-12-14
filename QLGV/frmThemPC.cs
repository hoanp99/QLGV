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
    public partial class frmThemPC : Form
    {
        public frmThemPC(frmPhanCong frm)
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

        private void frmThemPC_Load(object sender, EventArgs e)
        {
            HocPhan_BUS.Instance.LoadCombo(cbbHocPhan);
            GiaoVien_BUS.Instance.LoadCombo(cbbGiaoVien);
            cbbHocKy.SelectedIndex = 0;
            cbbNamHoc.SelectedIndex = 0;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                PhanCong_BUS.Instance.ThemPC(cbbGiaoVien.SelectedValue.ToString(), cbbHocPhan.SelectedValue.ToString(), cbbHocKy.SelectedItem.ToString(), cbbNamHoc.SelectedItem.ToString());
                Update();
                this.Close();

            } catch (SqlException)
            {
                MessageBox.Show("Giáo viên đã được phân vào học phần này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }        
        }
    }
}
