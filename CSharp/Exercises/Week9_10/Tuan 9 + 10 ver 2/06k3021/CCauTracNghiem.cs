using System;
using System.Collections.Generic;
using System.Text;

namespace _6k3021
{
    class CCauTracNghiem
    {

        private string _noiDungCauHoi;

        public string NoiDungCauHoi
        {
            get { return _noiDungCauHoi; }
            set { _noiDungCauHoi = value; }
        }
        private string _dapAnChon;

        public string DapAnChon
        {
            get { return _dapAnChon; }
            set { _dapAnChon = value; }
        }

        private string _dapAnDung;

        public string DapAnDung
        {
            get { return _dapAnDung; }
            set { _dapAnDung = value; }
        }
        private string _dapAnA;

        public string DapAnA
        {
            get { return _dapAnA; }
            set { _dapAnA = value; }
        }
        private string _dapAnB;

        public string DapAnB
        {
            get { return _dapAnB; }
            set { _dapAnB = value; }
        }
        private string _dapAnC;

        public string DapAnC
        {
            get { return _dapAnC; }
            set { _dapAnC = value; }
        }
        private string _dapAnD;

        public string DapAnD
        {
            get { return _dapAnD; }
            set { _dapAnD = value; }
        }

        //Contructor
        public CCauTracNghiem()
        {
            _noiDungCauHoi = string.Empty;
            _dapAnA = string.Empty;
            _dapAnB = string.Empty;
            _dapAnC = string.Empty;
            _dapAnD = string.Empty;
            _dapAnDung = string.Empty;
        }

        //Ham kiem tra chon dau hoi dung hay sai
        public bool KiemTraDapAn(string ChonDung)
        {
            if (ChonDung == _dapAnDung)
                return true;
            else return false;
        }
    }

}
