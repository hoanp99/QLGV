using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Windows.Forms;

namespace BUS
{
    public class HocPhan_BUS
    {
        private static HocPhan_BUS instance;

        public static HocPhan_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HocPhan_BUS();
                return instance;
            }
        }

        private HocPhan_BUS()
        {
        }

        public void LoadCombo(ComboBox box)
        {
            box.DataSource = HocPhan_DAL.Instance.GetHocPhans();
            box.ValueMember = "ID";
        }

        public void LoadData(DataGridView dataGrid)
        {
            dataGrid.DataSource = HocPhan_DAL.Instance.DisplayHocPhan();
        }

        public void TimKiemHP(string cTDT, string khoa, DataGridView dataGrid)
        {

            dataGrid.DataSource = HocPhan_DAL.Instance.TimKiemHocPhan(cTDT, khoa);
        }

        public void ThemHocPhan(string MaHP, string TenHP, string SoTC, string CTDT, string Khoa)
        {
            HocPhan s = new HocPhan();
            s.ID = MaHP;
            s.TenHP = TenHP;
            s.SoTC = Int32.Parse(SoTC);
            s.ID_ChuongTrinhDaoTao = CTDT;
            s.ID_Khoa = Khoa;
            HocPhan_DAL.Instance.ThemHocPhan(s);
        }

        public void XoaHocPhan(string MaHP)
        {
            HocPhan_DAL.Instance.XoaHocPhan(MaHP);
        }
    }
}
