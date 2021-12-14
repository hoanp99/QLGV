using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CTDT_DAL
    {
        private static CTDT_DAL instance;

        public static CTDT_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CTDT_DAL();
                return instance;
            }
        }

        private CTDT_DAL()
        {
        }

        public List<ChuongTrinhDaoTao> GetChuongTrinhDaoTaos()
        {
            List<ChuongTrinhDaoTao> li = new List<ChuongTrinhDaoTao>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.ChuongTrinhDaoTaos.Select(p => p).ToList();
            }
            return li;
        }
    }
}
