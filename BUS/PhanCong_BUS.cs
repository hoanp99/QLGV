using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class PhanCong_BUS
    {
        private static PhanCong_BUS instance;

        public static PhanCong_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhanCong_BUS();
                return instance;
            }
        }

        private PhanCong_BUS()
        {
        }

        public void LoadData(DataGridView data)
        {
            data.DataSource = PhanCong_DAL.Instance.GetPhanCongs();
        }

        public void ThemPC(string maGV, string maHP, string hocKy, string namHoc)
        {
            PhanCong s = new PhanCong();
            s.ID_GiaoVien = maGV;
            s.ID_HocPhan = maHP;
            s.HocKi = hocKy;
            s.NamHoc = namHoc;
            PhanCong_DAL.Instance.ThemPhanCong(s);
        }

        public void XoaPC(string maGV, string maHP)
        {
            PhanCong_DAL.Instance.XoaPhanCong(maGV, maHP);
        }

        public void TimKiemPC(string namHoc, string hocKi, string hocPhan, string giaoVien, string cTDT, DataGridView data)
        {
            if (namHoc == "[Tất Cả]")
            {
                namHoc = "";
            }
            if (hocKi == "[Tất Cả]")
            {
                hocKi = "";
            }
            data.DataSource = PhanCong_DAL.Instance.TimKiemPhanCong(namHoc, hocKi, hocPhan, giaoVien, cTDT);
        }
    }
}
