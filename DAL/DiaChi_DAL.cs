using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DiaChi_DAL
    {
        private static DiaChi_DAL instance;

        public static DiaChi_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiaChi_DAL();
                return instance;
            }
        }

        private DiaChi_DAL()
        {
        }

        public List<DiaChi> GetDiaChis()
        {
            List<DiaChi> li = new List<DiaChi>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.DiaChis.Select(p => p).ToList();
            }
            return li;
        }
    }
}
