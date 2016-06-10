using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;
namespace QLDL.BUS
{
   public class LoaiDaiLyBUS
    {
        public static System.Data.DataTable SelectAllLoaiDaiLy()
        {
            System.Data.DataTable dttb = LoaiDaiLyDAO.SelectAllLoaiDaiLy();
            return dttb;
        }
        public static int SelectMaByTenLoai(string tenloai)
        {
            int ma = LoaiDaiLyDAO.SelectMaLoaiByTenloai(tenloai);
            return ma;
        }
        public static int NoToiDa(string tenloai)
        {
            int ma = LoaiDaiLyDAO.NoToiDa(tenloai);
            return ma;
        }
        public static int NoToiDaByMaLoaiDL(int ma)
        {
            int no = LoaiDaiLyDAO.NoToiDaByMaLoaiDL(ma);
            return no;
        }
        public static int DemSoLoaiDL()
        {
            int no = LoaiDaiLyDAO.DemLoaiDL();
            return no;
        }
       //public static int MaLoaiDLByMaDL(int ma);
       // {
       //     int maloai = LoaiDaiLyDAO.l;
       //     return maloai ;
       // }

        public static void InsertDaiLy(DaiLyDTO dl)
        {
            DaiLyDAO.Insertdaily(dl);
        }
        public static void DeleteDaiLy(int madaily)
        {
            DaiLyDAO.DeletedailyByMadaily(madaily);
        }
        public static void updateDaiLy(DaiLyDTO dl)
        {
            DaiLyDAO.Updatedaily(dl);
        }

        public void ThemLoaiDaiLy(LoaiDaiLyDTO mh)
        {
            LoaiDaiLyDAO.InsertLoaiDaiLy(mh);
        }
        public void XoaLoaiDaiLy(int mamh)
        {
            LoaiDaiLyDAO.DeleteLoaiDaiLyByMaLoaiDaiLy(mamh);
        }

        public void CapNhatLoaiDaiLy(LoaiDaiLyDTO mh)
        {
            LoaiDaiLyDAO.UpdateLoaiDaiLy(mh);
        }

        public List<LoaiDaiLyDTO> DanhSachLoaiDaiLy()
        {
            return new LoaiDaiLyDAO().DanhSachLoaiDaiLy();
        }
    }
}
