using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Khoa_DAL
    {
        private static Khoa_DAL instance;

        public static Khoa_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new Khoa_DAL();
                return instance;
            }
        }

        private Khoa_DAL()
        {
        }

        public List<Khoa> GetKhoas()
        {
            List<Khoa> li = new List<Khoa>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.Khoas.Select(p => p).ToList();
            }
            return li;
        }
    }
}
