using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class QuyenHan_BUS
    {
        private static QuyenHan_BUS instance;

        public static QuyenHan_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuyenHan_BUS();
                return instance;
            }
        }

        private QuyenHan_BUS()
        {
        }

        public void LoadCombo(ComboBox combo)
        {
            combo.DataSource = QuyenHan_DAL.Instance.GetQuyenHans();
            combo.ValueMember = "ID";
        }
    }
}
