using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class DonViTinhDTO
    {
        #region "Attributes"
        private int _madonvitinh;
        private string _tendonvitinh;
        #endregion

        #region "Properties"

        public int Madonvitinh
        {
            get { return _madonvitinh; }
            set { _madonvitinh = value; }
        }

        public string Tendonvitinh
        {
            get { return _tendonvitinh; }
            set { _tendonvitinh = value; }
        }

        #endregion


        public DonViTinhDTO()
        {
        }

        public DonViTinhDTO(int madonvitinh, string tendonvitinh)
        {
            _madonvitinh = madonvitinh;
            _tendonvitinh = tendonvitinh;
        }
        public DonViTinhDTO( string tendonvitinh)
        {
            _tendonvitinh = tendonvitinh;
        }
    }
}
