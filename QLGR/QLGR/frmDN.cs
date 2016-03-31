using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void logInBut_Click(object sender, EventArgs e)
        {
            frmMain.Instance.Show();
            this.Hide();
        }

        private void frmDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
