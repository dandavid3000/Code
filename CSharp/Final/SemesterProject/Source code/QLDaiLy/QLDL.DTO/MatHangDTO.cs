using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class MatHangDTO
    {
        #region "Attributes"
        private int _mamathang;
        private string _tenmathang; 
        private int _soluongton;
        #endregion


        #region "Properties"

        public int Mamathang
        {
            get { return _mamathang; }
            set { _mamathang = value; }
        }

        public string Tenmathang
        {
            get { return _tenmathang; }
            set { _tenmathang = value; }
        }

        public int Soluongton
        {
            get { return _soluongton; }
            set { _soluongton = value; }
        }

        #endregion
        public MatHangDTO()
        {
           
        }
        public MatHangDTO(int mamathang, string tenmathang, int soluongton)
        {
            _mamathang = mamathang;
            _tenmathang = tenmathang;
            _soluongton = soluongton;
        }
    }
}
