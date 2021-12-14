using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        private static TaiKhoan_BUS instance;

        public static TaiKhoan_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoan_BUS();
                return instance;
            }
        }

        private TaiKhoan_BUS()
        {
        }
        public static string temp;
        private string TaiKhoan, MatKhau;

        public bool ValidateLogin(string taiKhoan, string matKhau)
        {
            List<TaiKhoan> li = TaiKhoan_DAL.Instance.GetTaiKhoan(taiKhoan);
            try
            {
                if (li[0].MatKhau == matKhau)
                {
                    TaiKhoan = li[0].ID;
                    MatKhau = li[0].MatKhau;
                    temp = li[0].ID_QuyenHan;
                    return true;
                }
            } catch (ArgumentOutOfRangeException)
            {
  
            }

            return false;
        }

        public bool ValidatePassWord(string matKhau)
        {
            if (MatKhau == matKhau)
            {
                return true;
            }
            return false;
        }

        public void DoiMatKhau(string matKhauMoi)
        {
            TaiKhoan s = new TaiKhoan();
            s.ID = TaiKhoan;
            s.MatKhau = matKhauMoi;
            TaiKhoan_DAL.Instance.UpdateTaiKhoan(s);
        }

        public void LoadData(DataGridView dataGrid)
        {
            dataGrid.DataSource = TaiKhoan_DAL.Instance.GetTaiKhoans();
        }

        public void ThemTaiKhoan(string tenTK, string matKhau, string quyenHan, string khoa)
        {
            TaiKhoan s = new TaiKhoan();
            s.ID = tenTK;
            s.MatKhau = matKhau;
            s.ID_QuyenHan = quyenHan;
            s.ID_Khoa = khoa;
            TaiKhoan_DAL.Instance.ThemTaiKhoan(s);
        }

        public void SuaTaiKhoan(string tenTK, string matKhau, string quyenHan, string khoa)
        {
            TaiKhoan s = new TaiKhoan();
            s.ID = tenTK;
            s.MatKhau = matKhau;
            s.ID_QuyenHan = quyenHan;
            s.ID_Khoa = khoa;
            TaiKhoan_DAL.Instance.SuaTaiKhoan(s);
        }

        public void XoaTaiKhoan(string tenTK)
        {
            TaiKhoan_DAL.Instance.XoaTaiKhoan(tenTK);
        }
    }
}
