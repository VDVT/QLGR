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
    public class Bus_Users
    {
        DAL_Users us = new DAL_Users();

        public DataTable GetData()
        {
            return us.SelectAll();
        }
        public DataTable GetUSER(SQL_Users EUSER)
        {
            return us.SelectUser(EUSER);
        }

    }
}
