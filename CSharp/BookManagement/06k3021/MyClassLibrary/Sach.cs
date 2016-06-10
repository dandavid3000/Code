using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class Sach
    {
        private string _maSach;

        public string MaSach
        {
            get { return _maSach; }
            set { _maSach = value; }
        }

        private string _tenSach;

        public string TenSach
        {
            get { return _tenSach; }
            set { _tenSach = value; }
        }

        private string _nguon;

        public string Nguon
        {
            get { return _nguon; }
            set { _nguon = value; }
        }

        private string _tacGia;

        public string TacGia
        {
            get { return _tacGia; }
            set { _tacGia = value; }
        }

        static public bool KiemTraMaSach(string ms)
        {
            // Kiem tra mssv chi co 6 ky tu
            if (ms.Length != 6) return false;
            if (ms[0]=='A' || ms[0]=='B') return false;
            for(int i=1;i<5;i++)
                 if(char.IsDigit(ms[i]) ==false) return false;
              
            if (char.IsLetter(ms[5])==false) return false;

            else return true;
        }

        static public bool KiemTraTenSach(string tenSach)
        {
            // Kiem tra giua 2 chu chi co 1 khoang trang
            if (tenSach.IndexOf("  ") > -1) return false;
            // Kiem tra cac ky tu dau phai viet hoa
            if (tenSach.Length < 1) return false;
            string[] arr = tenSach.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLower(arr[i][0]) == true) return false;
            }
            return true;
        }

        static public bool KiemTraTenTacGia(string tenTG)
        {
            // Kiem tra giua 2 chu chi co 1 khoang trang
            if (tenTG.IndexOf("  ") > -1) return false;
            // Kiem tra cac ky tu dau phai viet hoa
            if (tenTG.Length < 1) return false;
            string[] arr = tenTG.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsLower(arr[i][0]) == true) return false;
            }
            return true;
        }
    }
}
