using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanCong_DAL
    {
        private static PhanCong_DAL instance;

        public static PhanCong_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhanCong_DAL();
                return instance;
            }
        }

        private PhanCong_DAL()
        {
        }

        public List<dynamic> GetPhanCongs()
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.GetAllHocPhan();
                foreach(var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }

        public void ThemPhanCong(PhanCong s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.ThemPC(s.ID_GiaoVien, s.ID_HocPhan, s.HocKi, s.NamHoc);
            }
        }

        public void XoaPhanCong(string maGV, string maHP)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.XoaPc(maGV, maHP);
            }
        }

        public List<dynamic> TimKiemPhanCong(string namHoc, string hocKi, string hocPhan, string giaoVien, string cTDT)
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.TimKiemPC(namHoc, hocKi, hocPhan, giaoVien, cTDT);
                foreach(var i in list)
                {
                    li.Add(i);
                }
            }
            return li;
        }
    }
}
