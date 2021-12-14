using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DVCongTac_DAL
    {
        private static DVCongTac_DAL instance;

        public static DVCongTac_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DVCongTac_DAL();
                return instance;
            }
        }

        private DVCongTac_DAL()
        {
        }

        public List<DonViCongTac> GetDonViCongTacs()
        {
            List<DonViCongTac> li = new List<DonViCongTac>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.DonViCongTacs.Select(p => p).ToList();
            }
            return li;
        }
    }
}
