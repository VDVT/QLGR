using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BUS
{
    public class Bus_Users
    {
        DAL_Users us = new DAL_Users();

        public DataTable GetData()
        {
            return us.SelectAll();
        }

    }
}
