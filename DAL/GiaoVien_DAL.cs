using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GiaoVien_DAL
    {
        private static GiaoVien_DAL instance;

        public static GiaoVien_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoVien_DAL();
                return instance;
            }
        }

        private GiaoVien_DAL()
        {
        }

        public List<GiaoVien> GetGiaoViens()
        {
            List<GiaoVien> li = new List<GiaoVien>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.GiaoViens.Select(p => p).ToList();
            }
            return li;
        }

        public void ThemGiaoVien(GiaoVien s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.AddGV(s.ID, s.HoDem, s.Ten, s.GioiTinh, s.NgaySinh, s.SoDienThoai, s.ID_DiaChi, s.ID_HocVi, s.ID_DonViCongTac, s.ID_Khoa);
            }
        }

        public void SuaGiaoVien(GiaoVien s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.UpdateGV(s.ID, s.HoDem, s.Ten, s.GioiTinh, s.NgaySinh, s.SoDienThoai, s.ID_DiaChi, s.ID_HocVi, s.ID_DonViCongTac, s.ID_Khoa);
            }
        }

        public void XoaGiaoVien(string MaGV)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.DeleteGV(MaGV);
            }
        }

        public List<dynamic> TimKiemGiaoVien(string hocVi, string diaChi, string dVCT, string khoa, string gioiTinh)
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.TimKiemGV(hocVi, diaChi, dVCT, khoa, gioiTinh);
                foreach(var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }

        public List<dynamic> GetGiaoVien()
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.GetAllGiaoVien();
                foreach(var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }

        public List<dynamic> TimKiemGiaoVienDPC()
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.TimKiemGVDPC();
                foreach (var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }

        public List<dynamic> TimKiemGiaoVienCPC()
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.TimKiemGVCPC();
                foreach (var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }
    }
}
