using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Entity;

namespace DAL
{
    public class DAL_PTN
    {
        Ketnoi con = new Ketnoi();
        public DataTable SelectAll()
        {
            string strSQL = "GetData";
            //string sx = "@MaPTN";
            string[] pNames = {"@tableName"};
            string[] pValues = {"Xe"};
            return con.GetData(strSQL, pNames, pValues);
        }

    }
}
