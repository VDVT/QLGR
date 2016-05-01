using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace DAL
{
    public class DAL_DichVu
    {
        Ketnoi con = new Ketnoi();
        public DataTable SelectAll()
        {
            string strSQL = "GetData";
            //string sx = "@MaTC";
            string[] pNames = {"@tableName"};
            string[] pValues = {"TienCong"};
            return con.GetData(strSQL, pNames, pValues);

        }
        public bool InsertDV(SQL_DichVu dv)
        {
            try
            {
                string strSQL = "SP_InsertTC";
                string[] pNames = { "@maTc", "@tenTc", "@giaTien" };
                object[] pValues = { dv.SMaTC, dv.STenTC, dv.SGiaTien };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool DelDV(SQL_DichVu dv)
        {
            try
            {
                string strSQL = "SP_DelTC";
                string[] pNames = { "@maTc" };
                object[] pValues = { dv.SMaTC };
                int count = con.ExecuteStoredProcedure(strSQL, pNames, pValues);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateDV(SQL_DichVu dv)
        {
            try
            {
                string strSQL = "SP_UpdateTC";
                string[] pNames = { "@maTc", "@tenTc", "@giaTien" };
                object[] pValues = { dv.SMaTC, dv.STenTC, dv.SGiaTien };
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
