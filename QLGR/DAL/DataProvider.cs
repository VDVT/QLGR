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
            try
            {
                if (Ketnoi.connect == null)
                    // Ketnoi.connect = new SqlConnection("Data Source=(local);Initial Catalog=QLGR;Integrated Security=SSPI;");
                    Ketnoi.connect = new SqlConnection(@"Data Source=(local);Initial Catalog=QLGR;Integrated Security=SSPI;");
                if (Ketnoi.connect.State != ConnectionState.Open)
                    Ketnoi.connect.Open();
            }
            catch (System.Data.SqlClient.SqlException sqlException) {
                Console.WriteLine(sqlException.Message);
            }
            
        }
        public void Close()
        {
            if (Ketnoi.connect != null)
            {
                if (Ketnoi.connect.State == ConnectionState.Open)
                    Ketnoi.connect.Close();
            }
        }

        public DataTable GetData(string strSQL, string[] pNames, object[] pValues)
        {
            try
            {
                Open();
                cmd = new SqlCommand(strSQL, connect);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(sx);
                SqlDataAdapter da = new SqlDataAdapter();
                for (int i = 0; i < pNames.Length; i++)
                {
                    cmd.Parameters.Add(pNames[i], SqlDbType.VarChar).Value = pValues[i];
                    da = new SqlDataAdapter(cmd);
                }
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
