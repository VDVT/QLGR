using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BUS
{
    public class Bus_PTN
    {
        DAL_PTN ptn = new DAL_PTN();
        public DataTable GetData()
        {
            return ptn.SelectAll();
        }

    }
}
