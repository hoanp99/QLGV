using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class DiaChi_BUS
    {
        private static DiaChi_BUS instance;

        public static DiaChi_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DiaChi_BUS();
                return instance;
            }
        }

        private DiaChi_BUS()
        {
        }

        public void LoadCombo(ComboBox box, int chk)
        {
            List<DiaChi> li;
            if (chk == 1)
            {
                li = DiaChi_DAL.Instance.GetDiaChis();
            } else
            {
                li = DiaChi_DAL.Instance.GetDiaChis();
                li.RemoveAt(0);
            }
            box.DataSource = li;
            box.DisplayMember = "TenTP";
            box.ValueMember = "ID";
        }
    }
}
