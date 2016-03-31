using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Ketnoi
    {
        public static SqlConnection connect;
        public static SqlCommand cmd;
        DataTable dt;
        public static void Open()
        {
            if (Ketnoi.connect == null)
                Ketnoi.connect = new SqlConnection("Data Source=(local);Initial Catalog=QLGR;Integrated Security=SSPI;");
            if (Ketnoi.connect.State != ConnectionState.Open)
                Ketnoi.connect.Open();
        }
        public void Close()
        {
            if (Ketnoi.connect != null)
            {
                if (Ketnoi.connect.State == ConnectionState.Open)
                    Ketnoi.connect.Close();
            }
        }

        public DataTable GetData(string strSQL, string pNames, object pValues)
        {
            try
            {
                Open();
                cmd = new SqlCommand(strSQL, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(sx);
                cmd.Parameters.Add(pNames, SqlDbType.VarChar).Value = pValues;
                var da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                Close();
                return dt;
            }
            catch
            {
                return null;
            }

        }
        public int ExecuteStoredProcedure(string spName, string[] pNames, object[] pValues)
        {
            Open();
            cmd = new SqlCommand(spName, connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p;
            for (int i = 0; i < pNames.Length; i++)
            {
                p = new SqlParameter(pNames[i], pValues[i]);
                cmd.Parameters.Add(p);
            }
            int query = cmd.ExecuteNonQuery();
            Close();
            return query;
        }

    }
}
