using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class DVCongTac_BUS
    {
        private static DVCongTac_BUS instance;

        public static DVCongTac_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DVCongTac_BUS();
                return instance;
            }
        }

        private DVCongTac_BUS()
        {
        }

        public void LoadCombo(ComboBox box, int chk)
        {
            List<DonViCongTac> li;
            if (chk == 1)
            {
                li = DVCongTac_DAL.Instance.GetDonViCongTacs();
            } else
            {
                li = DVCongTac_DAL.Instance.GetDonViCongTacs();
                li.RemoveAt(0);
            }
            box.DataSource = li;
            box.DisplayMember = "TenDV";
            box.ValueMember = "ID";
        }
    }
}
