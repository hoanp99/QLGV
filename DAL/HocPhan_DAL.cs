using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HocPhan_DAL
    {
        private static HocPhan_DAL instance;

        public static HocPhan_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocPhan_DAL();
                return instance;
            }
        }

        private HocPhan_DAL()
        {
        }

        public List<dynamic> DisplayHocPhan()
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.DisplayHP();
                foreach(var i in list)
                {
                    li.Add(i);
                }
                return li;
            }
        }

        public List<dynamic> TimKiemHocPhan(string cTDT, string khoa)
        {
            var li = new List<dynamic>();
            using (dbDataContext db = new dbDataContext())
            {
                var list = db.TimKiemHP(cTDT, khoa);
                foreach (var i in list)
                {
                    li.Add(i);
                }
                return li;
            }
        }

        public void ThemHocPhan(HocPhan s)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.ThemHP(s.ID, s.TenHP, s.SoTC, s.ID_ChuongTrinhDaoTao, s.ID_Khoa);
            }
        }

        public void XoaHocPhan(string MaHP)
        {
            using (dbDataContext db = new dbDataContext())
            {
                db.XoaHP(MaHP);
            }
        }

        public List<HocPhan> GetHocPhans()
        {
            List<HocPhan> li = new List<HocPhan>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.HocPhans.Select(p => p).ToList();
            }
            return li;
        }
    }
}
