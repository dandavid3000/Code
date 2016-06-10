using System;
using System.Collections.Generic;
using System.Text;

namespace MyLiberary
{
    public class CSinhVien
    {
        private string _mssv;
        public string MSSV
        {
            get { return _mssv; }
            set { _mssv = value; }
        }

        private string _hoTen;
        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        private string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _soDienThoai;

        public string SoDienThoai
        {
            get { return _soDienThoai; }
            set { _soDienThoai = value; }
        }



        // ... cac thuoc tinh khac
        static public bool KiemTraMSSV(string mssv)
        {
            // Kiem tra mssv chi co 7 ky tu
            if (mssv.Length != 7) return false;
            // Kiem tra cac ky tu phai la chu so
            for (int i = 0; i < mssv.Length; i++)
            {
                if (char.IsDigit(mssv[i]) == false) return false;
            }
            return true;
        }
        static public bool KiemTraHoTen(string hoTen)
        {
            // Kiem tra giua 2 chu chi co 1 khoang trang
            if (hoTen.IndexOf(" ") == -1) return false;
            // Kiem tra cac ky tu dau phai viet hoa
            string[] arr = hoTen.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLower(arr[i][0]) == true) return false;
            }
            return true;
        }
        // ... cac ham kiem tra khac

    }
}
