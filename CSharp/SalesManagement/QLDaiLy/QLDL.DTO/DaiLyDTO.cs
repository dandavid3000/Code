using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
    public class DaiLyDTO
    {
        #region "Attributes"

        private int _madaily;
        private string _tendaily;       
        private int _maloaidaily;       
        private string _dienthoai;        
        private string _diachi;      
        private int _maquan;        
        private DateTime _ngaytiepnhan;
        private string _email; 
        private int _nocuadaily;
        #endregion


        #region "Properties"
        public int Madaily
        {
            get { return _madaily; }
            set { _madaily = value; }
        }

        public string Tendaily
        {
            get { return _tendaily; }
            set { _tendaily = value; }
        }

        public int Maloaidaily
        {
            get { return _maloaidaily; }
            set { _maloaidaily = value; }
        }

        public string Dienthoai
        {
            get { return _dienthoai; }
            set { _dienthoai = value; }
        }

        public string Diachi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }

        public int Maquan
        {
            get { return _maquan; }
            set { _maquan = value; }
        }

        public DateTime Ngaytiepnhan
        {
            get { return _ngaytiepnhan; }
            set { _ngaytiepnhan = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Nocuadaily
        {
            get { return _nocuadaily; }
            set { _nocuadaily = value; }
        }
        #endregion
        public DaiLyDTO()
        {
        }

        //public DaiLyDTO( string tendaily, int maloaidaily, string dienthoai, string diachi, int maquan, DateTime ngaytiepnhan, string email, int nocuadaily)
        //{
        //  //  _madaily = madaily;
        //    _tendaily = tendaily;
        //    _maloaidaily = maloaidaily;
        //    _dienthoai = dienthoai;
        //    _diachi = diachi;
        //    _maquan = maquan;
        //    _ngaytiepnhan = ngaytiepnhan;
        //    _email = email;
        //    _nocuadaily = nocuadaily;

        //}
        public DaiLyDTO(string tendaily, int maloaidaily, string dienthoai, string diachi, int maquan, DateTime ngaytiepnhan, string email)
        {
            //  _madaily = madaily;
            _tendaily = tendaily;
            _maloaidaily = maloaidaily;
            _dienthoai = dienthoai;
            _diachi = diachi;
            _maquan = maquan;
            _ngaytiepnhan =ngaytiepnhan;
            _email = email;
            //_nocuadaily = nocuadaily;

        }
        public DaiLyDTO(int madaily, string tendaily, int maloaidaily, string dienthoai, string diachi, int maquan, DateTime ngaytiepnhan, string email)
        {
            _madaily = madaily;
            _tendaily = tendaily;
            _maloaidaily = maloaidaily;
            _dienthoai = dienthoai;
            _diachi = diachi;
            _maquan = maquan;
            _ngaytiepnhan = ngaytiepnhan;
            _email = email;
            //_nocuadaily = nocuadaily;

        }
        //ngay cho Add("NgayXuat", px.NgayXuat.ToShortDateString())
        // insert ngày tháng

    }
}
