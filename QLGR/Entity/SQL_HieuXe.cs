using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SQL_HieuXe
    {
        #region Fields

        //   Fields
        private string sMaHX;
        private string sTenHX;

        #endregion

        #region Properties
        public string SMaHX
        {
            get { return sMaHX; }
            set { sMaHX = value; }
        }

        public string STenHX
        {
            get { return sTenHX; }
            set { sTenHX = value; }
        }
        #endregion
    }
}
