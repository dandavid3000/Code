using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class CSinhVien
    {
        private string _hoTen;
        private string _diaChi;
        private string _MSSV;
        private string _dienThoai;
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set { _hoTen = value; }
        }

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        public string MSSV
        {
            get { return _MSSV; }
            set { _MSSV = value; }
        }

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
            if (hoTen.IndexOf("  ") > -1) return false;
            // Kiem tra cac ky tu dau phai viet hoa
            if (hoTen.Length < 1) return false;
            string[] arr = hoTen.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLower(arr[i][0]) == true) return false;
            }
            return true;
        }

        static public bool KiemTraDienThoai(string dienthoai)
        {
            if (dienthoai.Length != 12) return false;
            if (dienthoai.IndexOf("-") != 3) return false;
            
            string[] arr = dienthoai.Split('-');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[1].Length != 4) return false;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (char.IsDigit(arr[i][j]) == false) return false;
                }
            }
            return true;
        }

        static public bool KiemTraEmail(string email)
        {
            string[] arr;
            string[] array;
            if ((email.IndexOf("@") == -1) || (email.IndexOf(".") == -1))
                return false;
            arr = email.Split('@');
            if (arr[0].Length > 0)
            {
                array = arr[1].Split('.');
                for (int i = 0; i < arr[0].Length; i++)
                {
                    if (char.IsLetterOrDigit(arr[0][i]) == false)
                    {
                        return false;
                    }
                }                
            }
            else
                return false;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > 0)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (char.IsLetter(array[i][j]) == false)
                        {
                            return false;
                        }
                    }
                }
                else
                    return false;
            }
            return true;
        }
    }
}
