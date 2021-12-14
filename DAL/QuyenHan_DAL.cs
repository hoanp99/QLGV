using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuyenHan_DAL
    {
        private static QuyenHan_DAL instance;

        public static QuyenHan_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyenHan_DAL();
                return instance;
            }
        }

        private QuyenHan_DAL()
        {
        }

        public List<QuyenHan> GetQuyenHans()
        {
            List<QuyenHan> li = new List<QuyenHan>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.QuyenHans.Select(p => p).ToList();
            }
            return li;
        }

    }
}
