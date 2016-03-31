using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SQL_PTN
    {
        #region Fields
        
        //  Fields
        private string sBienSo;
        private string sTenChuXe;
        private string sDienThoai;
        private string sEmail;
        private string sDiaChi;
        private string sMaHX;
        private DateTime sNgayTN;
        private int sTienNo;

        #endregion

        #region Properties
        public string SBienSo
        {
            get { return sBienSo; }
            set { sBienSo = value; }
        }

        public string STenChuXe
        {
            get { return sTenChuXe; }
            set { sTenChuXe = value; }
        }

        public string SDienThoai
        {
            get { return sDienThoai; }
            set { sDienThoai = value; }
        }

        public string SEmail
        {
            get { return sEmail; }
            set { sEmail = value; }
        }

        public string SDiaChi
        {
            get { return sDiaChi; }
            set { sDiaChi = value; }
        }

        public string SMaHX
        {
            get { return sMaHX; }
            set { sMaHX = value; }
        }

        public DateTime SNgayTN
        {
            get { return sNgayTN; }
            set { sNgayTN = value; }
        }

        public int STienNo
        {
            get { return sTienNo; }
            set { sTienNo = value; }
        }
        #endregion
    }
}
