using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SQL_DichVu
    {
        #region Fields

        // Fields
        private string sMaTC;
        private string sTenTC;
        private int sGiaTien;

        #endregion

        #region Properties
        public string SMaTC
        {
            get { return sMaTC; }
            set { sMaTC = value; }
        }
        public string STenTC
        {
            get { return sTenTC; }
            set { sTenTC = value; }
        }
        public int SGiaTien
        {
            get { return sGiaTien; }
            set { sGiaTien = value; }
        }
        #endregion
    }
}
