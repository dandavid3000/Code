using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;
namespace QLDL.BUS
{
    public class MatHangBUS
    {
        public static System.Data.DataTable SelectAllmatHang()
        {
            System.Data.DataTable dttb = MatHangDAO.SelectAllMatHang();
            return dttb;
        }
        public static int SelectMaByTenLoai(string tenmathang)
        {
            int ma = MatHangDAO.SelectMamatHangbyTenMatHang(tenmathang);
            return ma;
        }
        public static void ThemMatHang(MatHangDTO mh)
        {
            MatHangDAO.InsertMatHang(mh);
        }
        public static void XoaMatHang(int mamh)
        {
            MatHangDAO.DeleteMatHangByMaMatHang(mamh);
        }

        public static void CapNhatMatHang(MatHangDTO mh)
        {
            MatHangDAO.UpdateMatHang(mh);
        }
        public static void updateSLTon(int ma, int slton)
        {
            MatHangDAO.UpdateSLTon(ma,slton);
        }

        public static List<MatHangDTO> DanhSachMatHang()
        {
            return new MatHangDAO().DanhSachMatHang();
        }
        public  static int SLTon(int ma)
        {
            int slton = MatHangDAO.SSLTon(ma);
            return slton;
        }
    }
}
