using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUS
{
    public class Khoa_BUS
    {
        private static Khoa_BUS instance;

        public static Khoa_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new Khoa_BUS();
                return instance;
            }
        }

        private Khoa_BUS()
        {
        }

        public void LoadCombo(ComboBox box, int chk)
        {
            List<Khoa> li;
            if (chk == 1)
            {
                li = Khoa_DAL.Instance.GetKhoas();
            } else
            {
                li = Khoa_DAL.Instance.GetKhoas();
                li.RemoveAt(0);
            }
            box.DataSource = li;
            box.DisplayMember = "TenKhoa";
            box.ValueMember = "ID";
        }
    }
}
