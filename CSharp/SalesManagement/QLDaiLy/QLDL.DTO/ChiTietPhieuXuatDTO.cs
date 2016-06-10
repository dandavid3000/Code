using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class ChiTietPhieuXuatDTO
    {
         #region "Attributes"

        private int _machitietphieuxuat;
        private int _maphieuxuat; 
        private int _mamathang;
        private int _madonvitinh;    
        private int _dongiaxuat;
        private int _soluongxuat;    
        private int _thanhtien;
        #endregion


        #region "Properties"

        public int Machitietphieuxuat
        {
            get { return _machitietphieuxuat; }
            set { _machitietphieuxuat = value; }
        }

        public int Maphieuxuat
        {
            get { return _maphieuxuat; }
            set { _maphieuxuat = value; }
        }

        public int Mamathang
        {
            get { return _mamathang; }
            set { _mamathang = value; }
        }

        public int Madonvitinh
        {
            get { return _madonvitinh; }
            set { _madonvitinh = value; }
        }

        public int Dongiaxuat
        {
            get { return _dongiaxuat; }
            set { _dongiaxuat = value; }
        }

        public int Soluongxuat
        {
            get { return _soluongxuat; }
            set { _soluongxuat = value; }
        }

        public int Thanhtien
        {
            get { return _thanhtien; }
            set { _thanhtien = value; }
        }

        #endregion

        public ChiTietPhieuXuatDTO(int machitietphieuxuat, int maphieuxuat, int mamathang, int madonvitinh,int dongiaxuat, int soluongxuat,int thanhtien)
        {
            _machitietphieuxuat = machitietphieuxuat;
            _maphieuxuat = maphieuxuat;
            _mamathang = mamathang;
            _madonvitinh = madonvitinh;
            _dongiaxuat = dongiaxuat;
            _soluongxuat = soluongxuat;
            _thanhtien = thanhtien;

        }
    }
}
