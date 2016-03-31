using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DAL_Users
    {
        Ketnoi con = new Ketnoi();
        public DataTable SelectAll()
        {
            string strSQL = "GetData";
            //string sx = "@MaNV";
            string pNames = "@tableName";
            string pValues = "Users";
            return con.GetData(strSQL, pNames, pValues);
        }

    }
}
