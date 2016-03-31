using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SQL_VatTu
    {
        #region Fields

        //Fields
        private string sMaVT;
        private string sTenVT;
        private int sDonGia;
        private int sSL;

        #endregion

        #region Properties
        public string SMaVT
        {
            get { return sMaVT; }
            set { sMaVT = value; }
        }

        public string STenVT
        {
            get { return sTenVT; }
            set { sTenVT = value; }
        }

        public int SDonGia
        {
            get { return sDonGia; }
            set { sDonGia = value; }
        }

        public int SSL
        {
            get { return sSL; }
            set { sSL = value; }
        }
        #endregion
    }
}
