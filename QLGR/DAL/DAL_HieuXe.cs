using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace DAL
{
    public class DAL_HieuXe
    {
        Ketnoi con = new Ketnoi();
        public DataTable SelectAll()
        {
            string strSQL = "GetData";
            string pNames = "@tableName";
            //string sx = "@MaHX";
            string pValues = "HieuXe";
            return con.GetData(strSQL, pNames, pValues);
        }
        public bool InsertHX(SQL_HieuXe hx)
        {
            try
            {
                string strSQL = "SP_InsertHX";
                string[] pNames = { "@MaHX", "@TenHX" };
                object[] pValues = { hx.SMaHX, hx.STenHX };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool DelHX(SQL_HieuXe hx)
        {
            try
            {
                string strSQL = "SP_DelHX";
                string[] pNames = { "@maHX" };
                object[] pValues = { hx.SMaHX };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateHX(SQL_HieuXe hx)
        {
            try
            {
                string strSQL = "SP_UpdateHX";
                string[] pNames = { "@maHX", "@tenHX" };
                object[] pValues = { hx.SMaHX, hx.STenHX };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
