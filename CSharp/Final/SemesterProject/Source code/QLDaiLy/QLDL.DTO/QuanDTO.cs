using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class QuanDTO
    {
        #region "Attributes"
        private int _maquan;
        private string _tenquan;
        #endregion

        #region "Properties"
        public int Maquan
        {
            get { return _maquan; }
            set { _maquan = value; }
        }

        public string Tenquan
        {
            get { return _tenquan; }
            set { _tenquan = value; }
        }
        #endregion
        public QuanDTO()
        {
          
        }
        public QuanDTO(int maquan, string tenquan)
        {
            _maquan = maquan;
            _tenquan = tenquan;
        }
    }
}
