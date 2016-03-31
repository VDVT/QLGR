using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace DAL
{
    public class DAL_VatTu
    {
        Ketnoi con = new Ketnoi();
        public DataTable SelectAll()
        {
            string strSQL = "GetData";
            //string sx = "@MaVT";
            string pNames = "@tableName";
            string pValues = "VatTu";
            return con.GetData(strSQL, pNames, pValues);
        }
        public bool InsertVT(SQL_VatTu vt)
        {
            try
            {
                string strSQL = "SP_InsertVT";
                string[] pNames = { "@maVt", "@tenVt", "@donGia", "@sl" };
                object[] pValues = {vt.SMaVT, vt.STenVT, vt.SDonGia, vt.SSL };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            }            
        }
        public bool DelVT(SQL_VatTu vt)
        {
            try
            {
                string strSQL = "SP_DelVT";
                string[] pNames = { "@maVt" };
                object[] pValues = { vt.SMaVT };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            } 
        }
        public bool UpdateVT(SQL_VatTu vt)
        {
            try
            {
                string strSQL = "SP_UpdateVT";
                string[] pNames = { "@maVt", "@tenVt", "@donGia", "@sl" };
                object[] pValues = { vt.SMaVT, vt.STenVT, vt.SDonGia, vt.SSL };
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
