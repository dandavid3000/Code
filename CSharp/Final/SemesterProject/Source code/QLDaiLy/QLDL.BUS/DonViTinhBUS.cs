using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;


namespace QLDL.BUS
{
   public static class DonViTinhBUS
    {
        public static System.Data.DataTable SelectAllDonViTinh()
        {
            System.Data.DataTable dttb = DonViTinhDAO.SelectAllDonViTinh();
            return dttb;
        }
        public static int SelectMaByTen(string ten)
        {
            int ma = QuanDAO.SelectMaQuanBytenQuan(ten);
            return ma;
        }
        //public static System.Data.DataTable SelectAllDonViTinh()
        //{

        //    System.Data.DataTable dt = DonViTinhDAO.SelectAllDonViTinh();
        //    return dt;

        //}

        public static void InsertDonViTinh(DonViTinhDTO dv)
        {
            DonViTinhDAO.InsertDonViTinh(dv);
        }
        public static void XoaDonViTinh(int madonvi)
        {
            DonViTinhDAO.DeleteDonViTinhByMaDonViTinh(madonvi);
        }

        public static void CapNhatDonViTinh(DonViTinhDTO dv)
        {
            DonViTinhDAO.UpdateDonViTinh(dv);
        }

        //public static List<DonViTinhDTO> DanhSachDonViTinh()
        //{
        //    return new DonViTinhDAO().DanhSachDonViTinh();
        //}
        public static int Dem_DVT()
        {
            int no = DonViTinhDAO.Dem_DVT();
            return no;
        }

    }
}
