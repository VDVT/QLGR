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
    public class Bus_HieuXe
    {
        DAL_HieuXe hx = new DAL_HieuXe();

        public DataTable GetData()
        {
            return hx.SelectAll();
        }
        public DataTable GetHieuxe(SQL_HieuXe _hx)
        {
            return hx.SelectHieuXE(_hx);
        }
        public bool InsertHX(SQL_HieuXe _hx)
        {
            return hx.InsertHX(_hx);
        }
        public bool DelHX(SQL_HieuXe _hx)
        {
            return hx.DelHX(_hx);
        }
        public bool UpdateHX(SQL_HieuXe _hx)
        {
            return hx.UpdateHX(_hx);
        }
    }
}
