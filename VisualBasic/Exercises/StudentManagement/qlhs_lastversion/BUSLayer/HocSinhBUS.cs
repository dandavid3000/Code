using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Data;
using System.Collections;
using System.Data;

namespace BUSLayer
{
    public class HocSinhBUS
    {
        public bool KTTaiKhoan(string mahs, string password)
        {
            bool kq = false;
            HocSinh hs = new HocSinh();
            HocSinhService hsService = new HocSinhService();
            hs = hsService.GetByMaHocSinh(mahs);
            if (hs != null)            
                if ((hs.MaHocSinh != null) && (hs.Password == password))
                    kq = true;
            return kq;
        }

        public HocSinh LayHocSinh(string mahs)
        {
            HocSinh hs = new HocSinh();
            HocSinhService hsService = new HocSinhService();
            hs = hsService.GetByMaHocSinh(mahs);
            return hs;
        }

        public TList<HocSinh> LayBangTheoMaLop(string malop)
        {
            TList<HocSinh> ds = new TList<HocSinh>();
            HocSinhService hsService = new HocSinhService();
            ds = hsService.GetByMaLop(malop);
            return ds;
        }

        public bool CapNhat(HocSinh hs)
        {
            HocSinhService hsService = new HocSinhService();
            return hsService.Update(hs);
        }

        public bool Them(HocSinh hs)
        {
            HocSinhService hsService = new HocSinhService();
            return hsService.Insert(hs);
        }

        public bool Xoa(HocSinh hs)
        {
            HocSinhService hsService = new HocSinhService();
            return hsService.Delete(hs);
        }

        public bool KTTonTai(string MaHS)
        {
            bool kq = false;
            HocSinh hs = new HocSinh();
            HocSinhService hsService = new HocSinhService();
            hs = hsService.GetByMaHocSinh(MaHS);
            if (hs != null)               
                kq = true;
            return kq;
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

        static public bool KiemTraPassworđ(string password)
        {
            foreach (char c in password)
                if (char.IsLetterOrDigit(c) == false)
                    return false;
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

        public string LayMaHSLonNhatTheoLop(string malop)
        {
            int solonnhat = 0;
            TList<HocSinh> ds = new TList<HocSinh>();
            ds = LayBangTheoMaLop(malop);
            for (int i = 0; i < ds.Count; i++)
            {
                string chuoi = ds[i].MaHocSinh;
                string arr = chuoi.Substring(4);
                int SoTT = Convert.ToInt32(arr);
                solonnhat = SoTT;
                for (int j = 0; j < ds.Count; j++)
                {
                    string chuoi1 = ds[j].MaHocSinh;
                    string arr1 = chuoi1.Substring(4);
                    int SoTT1 = Convert.ToInt32(arr1);
                    if (SoTT < SoTT1)
                    {
                        solonnhat = SoTT1;
                    }
                }
            }
            solonnhat = solonnhat + 1;
            string mahocsinh = "";
            if (solonnhat < 10)
                mahocsinh = malop.Split(' ')[0] + "00" + solonnhat.ToString() + "   ";
            else if (solonnhat < 100)
                mahocsinh = malop.Split(' ')[0] + "0" + solonnhat.ToString() + "   ";
            else if (solonnhat < 1000)
                mahocsinh = malop.Split(' ')[0] + solonnhat.ToString() + "   ";
            return mahocsinh;
        }

        public ArrayList LayMaLop(string mamon, string mahk)
        {
            BangDiemBUS bdBUS = new BangDiemBUS();
            ArrayList dsMaHS = bdBUS.LayMaHS(mamon, mahk);
            HocSinhService hsService = new HocSinhService();
            ArrayList dsMaLop = new ArrayList();
            for (int i = 0; i < dsMaHS.Count; i++)
            {
                HocSinh hs = new HocSinh();
                hs = hsService.GetByMaHocSinh((string)dsMaHS[i]);
                dsMaLop.Add(hs.MaLop);
            }
            //int dem = 0;

            //for (int i = 0; i < dsMaLop.Count; i++)
            //{
            //    for (int j = 0; j < dsMaLop.Count; j++)
            //    {
            //        if ((string)dsMaLop[i] == (string)dsMaLop[j])
            //        {
            //            dem++;
            //            if (dem == 2)
            //            {
            //                dsMaLop.Remove(dsMaLop[i]);
            //                dem = 0;
            //                j = 0;
            //                i = 0;
            //            }
            //        }
            //    }
            //}

            return dsMaLop;
        }

        public ArrayList LayMaLopCuaHocSinhCoDiemDat(string mamon, string mahk)
        {
            BangDiemBUS bdBUS = new BangDiemBUS();
            DataTable dsMaHS = bdBUS.LayMaHSDat(mamon, mahk);
            //ArrayList dsMaHocSinh = dsMaHS.Tables[0];
            HocSinhService hsService = new HocSinhService();
            ArrayList dsMaLop = new ArrayList();
            for (int i = 0; i < dsMaHS.Rows.Count; i++)
            {
                HocSinh hs = new HocSinh();
                hs = hsService.GetByMaHocSinh((string)dsMaHS.Rows[i][0]);
                dsMaLop.Add(hs.MaLop);
            }
            return dsMaLop;
        }

        public ArrayList LayDSTenHS(string maHK, string tenlophoc)
        {
            ArrayList dstenhs = new ArrayList();
            DataSet ds = new DataSet();
            HocSinhService hsService = new HocSinhService();
            ds = hsService.LayDSTenHS(maHK,tenlophoc);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dstenhs.Add(dt.Rows[i][0]);
            }
            return dstenhs;
        }

        public ArrayList LayDSTenHS(string mamon, string maHK, string tenlophoc)
        {
            ArrayList dstenhs = new ArrayList();
            DataSet ds = new DataSet();
            HocSinhService hsService = new HocSinhService();
            ds = hsService.LayDSTenHS(mamon, maHK, tenlophoc);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dstenhs.Add(dt.Rows[i][0]);
            }
            return dstenhs;
        }

        public DataTable LayThongTinHocSinh(string maHS, string tenHS, string ngaysinh, string diachi, string toan, string ly, string hoa, string sinh, string su, string dia, string van, string daoduc, string theduc, string DTB, string lop)
        {
            DataSet ds = new DataSet();
            HocSinhService hsService = new HocSinhService();
            ds = hsService.LayThongTinHocSinh(maHS, tenHS, ngaysinh, diachi, toan, ly, hoa, sinh, su, dia, van, daoduc, theduc, DTB, lop);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }

        public void NhapDiemMacDinh(HocSinh hs)
        {
            BangDiem bd = new BangDiem();
            BangDiemBUS bdBUS = new BangDiemBUS();
            bd.MaBangDiem = bdBUS.LayMaLonNhat();
            bd.MaHocSinh = hs.MaHocSinh;
            bd.Dtb = 0;
            bdBUS.Them(bd);

            DiemBUS dBUS = new DiemBUS();
            Diem d = new Diem();
            d.MaBangDiem = bd.MaBangDiem;
            d.MaDiem = dBUS.LayMaDiemLonNhat();
            d.Diem15Phut = 0;
            d.Diem1Tiet = 0;
            d.DiemCuoiKy = 0;
            d.Dtb = 0;
            d.MaMon = "MH001";
            d.MaHocKy = "HK001";
            dBUS.Them(d);

            Diem d1 = new Diem();
            d1.MaBangDiem = bd.MaBangDiem;
            d1.MaDiem = dBUS.LayMaDiemLonNhat();
            d1.Diem15Phut = 0;
            d1.Diem1Tiet = 0;
            d1.DiemCuoiKy = 0;
            d1.Dtb = 0;
            d1.MaMon = "MH002";
            d1.MaHocKy = "HK001";
            dBUS.Them(d1);

            Diem d2 = new Diem();
            d2.MaBangDiem = bd.MaBangDiem;
            d2.MaDiem = dBUS.LayMaDiemLonNhat();
            d2.Diem15Phut = 0;
            d2.Diem1Tiet = 0;
            d2.DiemCuoiKy = 0;
            d2.Dtb = 0;
            d2.MaMon = "MH003";
            d2.MaHocKy = "HK001";
            dBUS.Them(d2);

            Diem d3 = new Diem();
            d3.MaBangDiem = bd.MaBangDiem;
            d3.MaDiem = dBUS.LayMaDiemLonNhat();
            d3.Diem15Phut = 0;
            d3.Diem1Tiet = 0;
            d3.DiemCuoiKy = 0;
            d3.Dtb = 0;
            d3.MaMon = "MH004";
            d3.MaHocKy = "HK001";
            dBUS.Them(d3);

            Diem d4 = new Diem();
            d4.MaBangDiem = bd.MaBangDiem;
            d4.MaDiem = dBUS.LayMaDiemLonNhat();
            d4.Diem15Phut = 0;
            d4.Diem1Tiet = 0;
            d4.DiemCuoiKy = 0;
            d4.Dtb = 0;
            d4.MaMon = "MH005";
            d4.MaHocKy = "HK001";
            dBUS.Them(d4);

            Diem d5 = new Diem();
            d5.MaBangDiem = bd.MaBangDiem;
            d5.MaDiem = dBUS.LayMaDiemLonNhat();
            d5.Diem15Phut = 0;
            d5.Diem1Tiet = 0;
            d5.DiemCuoiKy = 0;
            d5.Dtb = 0;
            d5.MaMon = "MH006";
            d5.MaHocKy = "HK001";
            dBUS.Them(d5);

            Diem d6 = new Diem();
            d6.MaBangDiem = bd.MaBangDiem;
            d6.MaDiem = dBUS.LayMaDiemLonNhat();
            d6.Diem15Phut = 0;
            d6.Diem1Tiet = 0;
            d6.DiemCuoiKy = 0;
            d6.Dtb = 0;
            d6.MaMon = "MH007";
            d6.MaHocKy = "HK001";
            dBUS.Them(d6);

            Diem d7 = new Diem();
            d7.MaBangDiem = bd.MaBangDiem;
            d7.MaDiem = dBUS.LayMaDiemLonNhat();
            d7.Diem15Phut = 0;
            d7.Diem1Tiet = 0;
            d7.DiemCuoiKy = 0;
            d7.Dtb = 0;
            d7.MaMon = "MH008";
            d7.MaHocKy = "HK001";
            dBUS.Them(d7);

            Diem d8 = new Diem();
            d8.MaBangDiem = bd.MaBangDiem;
            d8.MaDiem = dBUS.LayMaDiemLonNhat();
            d8.Diem15Phut = 0;
            d8.Diem1Tiet = 0;
            d8.DiemCuoiKy = 0;
            d8.Dtb = 0;
            d8.MaMon = "MH009";
            d8.MaHocKy = "HK001";
            dBUS.Them(d8);         
        }
    }
}
