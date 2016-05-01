using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entity;
using BUS;
namespace QLGR
{
    public sealed partial class frmDN : Form
    {
        
        #region Singleton
        frmDN()
        {
            InitializeComponent();
        }

        public static frmDN Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        class Nested
        {
            // not to mark type as beforefieldinit
            // Explicit static constructor to tell C# compiler
            Nested() { }
            internal static readonly frmDN instance = new frmDN();
        }
        #endregion
        Bus_Users BUser = new Bus_Users();
        SQL_Users EUser = new SQL_Users();
        private void logInBut_Click(object sender, EventArgs e)
        {
            EUser.SMaNV = userName.Text;
            EUser.SMatKhau = passWord.Text;
            DataTable dt = new DataTable();
            dt = BUser.GetUSER(EUser);
            try
            {

                if (dt.Rows[0]["Temp"].ToString() == "1")
                {
                    MessageBox.Show("Đăng nhập thành công","Thông Báo");
                    frmMain.Instance.Show();
                    this.Hide();
                }
               
            }
            catch
            {
                MessageBox.Show("NHU CAC");
            }
        }

        private void frmDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
