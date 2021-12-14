using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class GiaoVien_BUS
    {
        private static GiaoVien_BUS instance;

        public static GiaoVien_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoVien_BUS();
                return instance;
            }
        }

        private GiaoVien_BUS()
        {
        }

        public void LoadCombo(ComboBox box)
        {
            box.DataSource = GiaoVien_DAL.Instance.GetGiaoViens();
            box.ValueMember = "ID";
        }

        public void LoadData(DataGridView data)
        {
            data.DataSource = GiaoVien_DAL.Instance.GetGiaoVien();
        }

        private string autoGenerateMaGV(string maKhoa, string dVCT)
        {
            int count = 1;
            foreach(var i in GiaoVien_DAL.Instance.GetGiaoViens())
            {
                if (i.ID_Khoa == maKhoa && i.ID_DonViCongTac == dVCT)
                {
                    count++;
                }
            }
            return "GV" + maKhoa + dVCT +"00"+ count;
        }

        private string ChuanHoa(string st)
        {
            st = st.Trim().ToLower();
            st = st.Replace("\\s+", " ");
            string[] a = st.Split(' ');
            st = "";
            for(int i = 0; i < a.Length; i++)
            {
                st += Char.ToUpper(a[i][0]) + a[i].Substring(1);
                if (i < a.Length - 1)
                {
                    st += " ";
                }
            }
            return st;
        }

        public void ThemGiaoVien(string hoDem, string ten, string gioiTinh, DateTime ngaySinh, string soDienThoai, string diaChi, string hocVi, string dVCT, string khoa)
        {
            GiaoVien s = new GiaoVien();
            s.ID = autoGenerateMaGV(khoa, dVCT);
            s.HoDem = ChuanHoa(hoDem);
            s.Ten = ChuanHoa(ten);
            s.GioiTinh = gioiTinh;
            s.NgaySinh = ngaySinh;
            s.SoDienThoai = soDienThoai;
            s.ID_DiaChi = diaChi;
            s.ID_HocVi = hocVi;
            s.ID_DonViCongTac = dVCT;
            s.ID_Khoa = khoa;
            GiaoVien_DAL.Instance.ThemGiaoVien(s);
        }

        public void SuaGiaoVien(string maGV,string hoDem, string ten, string gioiTinh, DateTime ngaySinh, string soDienThoai, string diaChi, string hocVi, string dVCT, string khoa)
        {
            GiaoVien s = new GiaoVien();
            s.ID = maGV;
            s.HoDem = ChuanHoa(hoDem);
            s.Ten = ChuanHoa(ten);
            s.GioiTinh = gioiTinh;
            s.NgaySinh = ngaySinh;
            s.SoDienThoai = soDienThoai;
            s.ID_DiaChi = diaChi;
            s.ID_HocVi = hocVi;
            s.ID_DonViCongTac = dVCT;
            s.ID_Khoa = khoa;
            GiaoVien_DAL.Instance.SuaGiaoVien(s);
        }

        public void XoaGiaoVien(string maGV)
        {
            GiaoVien_DAL.Instance.XoaGiaoVien(maGV);
        }

        public void TimKiemGiaoVien(string hocVi, string diaChi, string dVCT, string khoa, string gioiTinh, DataGridView data)
        {
            if (gioiTinh == "[Tất Cả]")
            {
                gioiTinh = "";
            }
            data.DataSource = GiaoVien_DAL.Instance.TimKiemGiaoVien(hocVi, diaChi, dVCT, khoa, gioiTinh);
        }

        public void TimKiemGiaoVienDPC(DataGridView data)
        {

            data.DataSource = GiaoVien_DAL.Instance.TimKiemGiaoVienDPC();
        }

        public void TimKiemGiaoVienCPC(DataGridView data)
        {

            data.DataSource = GiaoVien_DAL.Instance.TimKiemGiaoVienCPC();
        }
    }
}
