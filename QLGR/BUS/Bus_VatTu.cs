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
    public class Bus_VatTu
    {
        DAL_VatTu vt = new DAL_VatTu();
        public DataTable GetData()
        {
            return vt.SelectAll();
        }
        public bool InsertVT(SQL_VatTu _vt)
        {
            return vt.InsertVT(_vt);
        }
        public bool DelVT(SQL_VatTu _vt)
        {
            return vt.DelVT(_vt);
        }
        public bool UpdateVT(SQL_VatTu _vt)
        {
            return vt.UpdateVT(_vt);
        }
    }
}
