using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
   public class PhieuThuTienDTO
    {
        #region "Attributes"

        private int _maphieuthu;
        private int _madaily; 
        private DateTime _ngaythutien;
        private int _sotien;
        #endregion


        #region "Properties"

       public int Maphieuthu
       {
           get { return _maphieuthu; }
           set { _maphieuthu = value; }
       }

       public int Madaily
       {
           get { return _madaily; }
           set { _madaily = value; }
       }

       public DateTime Ngaythutien
       {
           get { return _ngaythutien; }
           set { _ngaythutien = value; }
       }

       public int Sotien
       {
           get { return _sotien; }
           set { _sotien = value; }
       }

       #endregion

        public PhieuThuTienDTO(int maphieuthu, int madaily, DateTime ngaythutien, int sotien)
        {
            _maphieuthu = maphieuthu;
            _madaily = madaily;
            _ngaythutien = ngaythutien;
            _sotien = sotien;

        }
        public PhieuThuTienDTO( int madaily, DateTime ngaythutien, int sotien)
        {
          
            _madaily = madaily;
            _ngaythutien = ngaythutien;
            _sotien = sotien;

        }
    }
}
