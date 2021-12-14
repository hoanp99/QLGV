using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HocVi_DAL
    {
        private static HocVi_DAL instance;

        public static HocVi_DAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocVi_DAL();
                return instance;
            }
        }

        private HocVi_DAL()
        {
        }

        public List<HocVi> GetHocVis()
        {
            List<HocVi> li = new List<HocVi>();
            using (dbDataContext db = new dbDataContext())
            {
                li = db.HocVis.Select(p => p).ToList();
            }
            return li;
        }
    }
}
