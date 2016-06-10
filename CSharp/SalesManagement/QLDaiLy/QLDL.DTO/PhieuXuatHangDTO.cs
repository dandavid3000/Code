using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
   public class PhieuXuatHangDTO
    {
       #region "Attributes"

        private int _maphieuxuat;
        private int _madaily; 
        private DateTime _ngaylapphieu;
        private int _tonggiatri;
        #endregion


        #region "Properties"

       public int Maphieuxuat
       {
           get { return _maphieuxuat; }
           set { _maphieuxuat = value; }
       }

       public int Madaily
       {
           get { return _madaily; }
           set { _madaily = value; }
       }

       public DateTime Ngaylapphieu
       {
           get { return _ngaylapphieu; }
           set { _ngaylapphieu = value; }
       }

       public int Tonggiatri
       {
           get { return _tonggiatri; }
           set { _tonggiatri = value; }
       }

       #endregion

        public PhieuXuatHangDTO(int maphieuxuat, int madaily, DateTime ngaylapphieu, int tonggiatri)
        {
            _maphieuxuat = maphieuxuat;
            _madaily = madaily;
            _ngaylapphieu = ngaylapphieu;
            _tonggiatri = tonggiatri;

        }
    }
}
