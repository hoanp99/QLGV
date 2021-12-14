using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class HocVi_BUS
    {
        private static HocVi_BUS instance;

        public static HocVi_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocVi_BUS();
                return instance;
            }
        }

        private HocVi_BUS()
        {
        }

        public void LoadCombo(ComboBox box, int chk)
        {
            List<HocVi> li;
            if (chk == 1)
            {
                li = HocVi_DAL.Instance.GetHocVis();
            } else
            {
                li = HocVi_DAL.Instance.GetHocVis();
                li.RemoveAt(0);
            }
            box.DataSource = li;
            box.DisplayMember = "TenHV";
            box.ValueMember = "ID";
        }
    }
}
