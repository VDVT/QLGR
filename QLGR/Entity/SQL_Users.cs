using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SQL_Users
    {
        #region Fields

        //Some Fields
        private string sMaNV;
        private string sMatKhau;
        private string sQuyen;
        private string sHoTen;
        private bool sGT;
        private DateTime sNgaySinh;
        private string sDienThoai;
        private string sDiaChi;

        #endregion

        #region Properties
        //Some properties

        public string SMaNV
        {
            get { return sMaNV; }
            set { sMaNV = value; }
        }
        public string SMatKhau
        {
            get { return sMatKhau; }
            set { sMatKhau = value; }
        }
        public string SQuyen
        {
            get { return sQuyen; }
            set { sQuyen = value; }
        }
        public string SHoTen
        {
            get { return sHoTen; }
            set { sHoTen = value; }
        }
        public bool SGT
        {
            get { return sGT; }
            set { sGT = value; }
        }
        public DateTime SNgaySinh
        {
            get { return sNgaySinh; }
            set { sNgaySinh = value; }
        }
        public string SSdt
        {
            get { return sDienThoai; }
            set { sDienThoai = value; }
        }
        public string SDiaChi
        {
            get { return sDiaChi; }
            set { sDiaChi = value; }
        }
        #endregion
    }
}
