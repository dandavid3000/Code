using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class LoaiDaiLyDTO
    {
        #region "Attributes"
        private int _maloaidaily;
        private string _tenloaidaily; 
        private int _notoida;
        #endregion


        #region "Properties"
        public int Maloaidaily
        {
            get { return _maloaidaily; }
            set { _maloaidaily = value; }
        }

        public string Tenloaidaily
        {
            get { return _tenloaidaily; }
            set { _tenloaidaily = value; }
        }

        public int Notoida
        {
            get { return _notoida; }
            set { _notoida = value; }
        }
        #endregion
        public LoaiDaiLyDTO()
        {
        }

        public LoaiDaiLyDTO(int maloaidaily, string tenloaidaily, int notoida)
        {
            _maloaidaily = maloaidaily;
            _tenloaidaily = tenloaidaily;
            _notoida = notoida;

        }
    }
}
