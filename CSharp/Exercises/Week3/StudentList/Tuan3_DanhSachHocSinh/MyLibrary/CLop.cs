using System;
using System.Collections;
using System.Text;
using MyLibrary;
using System.IO;

namespace MyLibrary
{
    public class CLop
    {
        private string _tenLop;
        public string TenLop
        {
            get { return _tenLop; }
            set { _tenLop = value; }
        }
        private ArrayList _danhSachLop = new ArrayList();
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

        public bool CapNhatSinhVien(CSinhVien sinhvien)
        {
            foreach (CSinhVien sv in _danhSachLop)
            {
                if (sinhvien.MSSV == sv.MSSV)
                {                    
                    sv.HoTen = sinhvien.HoTen;                 
                    sv.DiaChi = sinhvien.DiaChi;
                    sv.DienThoai = sinhvien.DienThoai;
                    sv.Email = sinhvien.Email;                    
                }
                else
                    return false;
            }
            return true; ;
        }

        public void GhiDanhSachLop(string filePath)
        {
            FileStream theFile = File.Open(filePath, FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter writer = new StreamWriter(theFile);
            writer.WriteLine(_tenLop);
            writer.WriteLine(_danhSachLop.Count.ToString());
            foreach (CSinhVien sinhVien in _danhSachLop)
            {
                writer.WriteLine(sinhVien.MSSV + "~" + sinhVien.HoTen + "~" + sinhVien.DiaChi + "~" + sinhVien.DienThoai + "~" + sinhVien.Email );
            }
            writer.Close();
            theFile.Close();
        }
        public void DocDanhSachLop(string filePath)
        {
            FileStream theFile = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(theFile);
            _tenLop = reader.ReadLine ();
            string n = reader.ReadLine();
            int siso = int.Parse(n);
            for (int i = 0 ; i<siso; i++)
            {
                CSinhVien sinhVien = new CSinhVien();
                string[] arr = reader.ReadLine().Split('~');
                sinhVien.MSSV = arr[0];
                sinhVien.HoTen = arr[1];
                sinhVien.DiaChi = arr[2];
                sinhVien.DienThoai = arr[3];
                sinhVien.Email = arr[4];
                DanhSachLop.Add(sinhVien);
            }
            reader .Close();
            theFile.Close();
        }
       
        public void Sort()
        {            
            ArrayList arrHoTen = new ArrayList();
            foreach (CSinhVien sv in _danhSachLop)
            {
                arrHoTen.Add(sv.HoTen);
            }
            arrHoTen.Sort();
            for (int t = 0; t < _danhSachLop.Count - 1; t++)
            {
                for (int i = 0; i < _danhSachLop.Count; i++)
                {
                    CSinhVien sinhvien = new CSinhVien();
                    sinhvien = LaySinhVien(i);
                    for (int j = 0; j < arrHoTen.Count; j++)
                    {
                        if (sinhvien.HoTen == (string)arrHoTen[j])
                        {
                            if (i != j)
                            {
                                _danhSachLop[i] = _danhSachLop[j];
                                _danhSachLop[j] = sinhvien;
                            }                            
                        }
                    }
                }
            }           
        }
    }
}
