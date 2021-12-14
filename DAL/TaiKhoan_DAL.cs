using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoan_DAL
    {
        private static TaiKhoan_DAL instance;

        public static TaiKhoan_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoan_DAL();
                return instance;
            }
        }

        private TaiKhoan_DAL()
        {
        }

        public List<TaiKhoan> GetTaiKhoan(string taiKhoan)
        {
            List<TaiKhoan> li = new List<TaiKhoan>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.TaiKhoans.Where(p => p.ID == taiKhoan).Select(p => p).ToList();
            }
            return li;
        }

        public List<dynamic> GetTaiKhoans()
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.GetAllTaiKhoan();
                foreach(var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }

        public void UpdateTaiKhoan(TaiKhoan s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.DoiMatKhau(s.ID, s.MatKhau);
            }
        }

        public void ThemTaiKhoan(TaiKhoan s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.ThemTaiKhoan(s.ID, s.MatKhau, s.ID_QuyenHan, s.ID_Khoa);
            }
        }

        public void SuaTaiKhoan(TaiKhoan s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.SuaTaiKhoan(s.ID, s.MatKhau, s.ID_QuyenHan, s.ID_Khoa);
            }
        }

        public void XoaTaiKhoan(string taiKhoan)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.XoaTaiKhoan(taiKhoan);
            }
        }
    }
}