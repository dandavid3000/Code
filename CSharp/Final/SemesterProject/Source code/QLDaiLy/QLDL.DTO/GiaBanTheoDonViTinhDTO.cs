using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class GiaBanTheoDonViTinhDTO
    {
         #region "Attributes"

        private int _magiabantheoDVT;
        private int _madonvitinh; 
        private int _mamathang;
        private int _soluongtheoDVT;    
        private int _dongiaban;
        #endregion


        #region "Properties"

        public int MagiabantheoDvt
        {
            get { return _magiabantheoDVT; }
            set { _magiabantheoDVT = value; }
        }

        public int Madonvitinh
        {
            get { return _madonvitinh; }
            set { _madonvitinh = value; }
        }

        public int Mamathang
        {
            get { return _mamathang; }
            set { _mamathang = value; }
        }

        public int SoluongtheoDvt
        {
            get { return _soluongtheoDVT; }
            set { _soluongtheoDVT = value; }
        }

        public int Dongiaban
        {
            get { return _dongiaban; }
            set { _dongiaban = value; }
        }

        #endregion

        public GiaBanTheoDonViTinhDTO(int magiabantheoDVT, int madonvitinh, int mamathang, int soluongtheoDVT,int dongiaban)
        {
            _magiabantheoDVT = magiabantheoDVT;
            _madonvitinh= madonvitinh;
            _mamathang = mamathang;
            _soluongtheoDVT = soluongtheoDVT;
            _dongiaban = dongiaban;

        }
        public GiaBanTheoDonViTinhDTO()
        {
        }
        public GiaBanTheoDonViTinhDTO( int madonvitinh, int mamathang, int soluongtheoDVT, int dongiaban)
        {
            _madonvitinh = madonvitinh;
            _mamathang = mamathang;
            _soluongtheoDVT = soluongtheoDVT;
            _dongiaban = dongiaban;

        }
    }
}
