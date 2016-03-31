using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entity;

namespace BUS
{
    public class Bus_DichVu
    {
        DAL_DichVu dv = new DAL_DichVu();

        public DataTable GetData()
        {
            return dv.SelectAll();
        }
        public bool InsertDV(SQL_DichVu _dv)
        {
            return dv.InsertDV(_dv);
        }
        public bool DelDV(SQL_DichVu _dv)
        {
            return dv.DelDV(_dv);
        }
        public bool UpdateDV(SQL_DichVu _dv)
        {
            return dv.UpdateDV(_dv);
        }
    }
}
