using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class CTDT_BUS
    {
        private static CTDT_BUS instance;

        public static CTDT_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new CTDT_BUS();
                return instance;
            }
        }

        private CTDT_BUS()
        {
        }

        public void LoadCombo(ComboBox data)
        {
            data.DataSource = CTDT_DAL.Instance.GetChuongTrinhDaoTaos();
            data.ValueMember = "ID";
            data.DisplayMember = "TenKeHoachDT";
        }
    }
}
