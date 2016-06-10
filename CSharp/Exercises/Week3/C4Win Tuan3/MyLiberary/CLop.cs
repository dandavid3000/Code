using System;
using System.Collections;
using System.Text;
using System.IO;

namespace MyLiberary
{
    public class CLop
    {
        private string _tenLop;
        public string TenLop
        {
            get { return _tenLop; }
            set { _tenLop = value; }
        }

        ArrayList _danhSachLop = new ArrayList();
        public ArrayList DanhSachLop
        {
            get { return _danhSachLop; }
            set { _danhSachLop = value; }
        }

        public CSinhVien LaySinhVien(int index)
        {
            CSinhVien sinhVien = (CSinhVien)_danhSachLop[index];
            return sinhVien;
        }

        public bool ThemSinhVien(CSinhVien sinhVien)
        {
            // Kiem tra co trung MSSV
            foreach (CSinhVien sv in DanhSachLop)
            {
                if (sinhVien.MSSV == sv.MSSV) return false;
            }
            // Them vao arraylist
            _danhSachLop.Add(sinhVien);
            return true;
        }
        public bool XoaSinhVien(CSinhVien sinhVien)
        {
            // Tim sinh vien co MSSV can xoa
            foreach (CSinhVien sv in _danhSachLop)
            {
                if (sinhVien.MSSV == sv.MSSV)
                {
                    _danhSachLop.Remove(sv);
                    return true;
                }
            }
            return false;
        }

        //Ham ghi danh sach lop
        public void GhiDanhSachLop(string filePath)
        {
            FileStream theFile = File.Open(filePath, FileMode.OpenOrCreate,
            FileAccess.Write);
            StreamWriter writer = new StreamWriter(theFile);
            writer.WriteLine(_tenLop);
            writer.WriteLine(_danhSachLop.Count.ToString());
            foreach (CSinhVien sinhVien in _danhSachLop)
            {
                writer.WriteLine(sinhVien.MSSV + "~" + sinhVien.HoTen);
            }
            writer.Close();
            theFile.Close();
        }

        public void DocDanhSachLop(string filePath)
        {
         
            StreamReader reader = new StreamReader(filePath);
            _tenLop = reader.ReadLine();
            int SiSo = Convert.ToInt32(reader.ReadLine());
            for (int i = 0; i < SiSo; i++)
            {
                string chuoi = reader.ReadLine();
                string[] array = chuoi.Split('~');
                CSinhVien sv = new CSinhVien();
                sv.MSSV = array[0];
                sv.HoTen = array[1];
                _danhSachLop.Add(sv);
             }

             reader.Close();
            

         }
    }
}
