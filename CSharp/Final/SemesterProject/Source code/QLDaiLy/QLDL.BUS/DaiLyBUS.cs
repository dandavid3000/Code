using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;

namespace QLDL.BUS
{
    public class DaiLyBUS
    {
        public static System.Data.DataTable SelectAllDaiLy()
        {
            System.Data.DataTable dt = DaiLyDAO.SelectAllDaiLy();
            return dt;
        }
        public static System.Data.DataTable SelectAllCongNoDaiLy()
        {
            System.Data.DataTable dt = DaiLyDAO.SelectAllCongNoDaiLy();
            return dt;
        }
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
        public static DaiLyDTO SelectDaiLyByMa(int madaily)
        {
            DaiLyDTO dl = DaiLyDAO.SelectdailyByMadaily(madaily);
            return dl;
        }
        //public static System.Data.DataTable SelectAllDaiLy()
        //{
        //    System.Data.DataTable dttb = DaiLyDAO.SelectAllDaiLy();
        //    return dttb;
        //}
        public static int selectNoByMaDL(int ma)
        {
            int no = DaiLyDAO.SelectNoByMaDL(ma);
            return  no;
        }
        public static int selectNoByMaDL_Moi(int ma)
        {
            int no = DaiLyDAO.SelectNoByMaDaiLy_Moi(ma);
            return no;
        }
        public static int layMaLoaiDLByTenDL(string ten)
        {
            int maloaiDL = DaiLyDAO.LayLoaiDLByTenDL(ten);
            return maloaiDL;
        }
        public static int layMaLoaiDLBymaDL(int ma)
        {
            int maloaiDL = DaiLyDAO.LaymaLoaiDLByMaDL(ma);
            return maloaiDL;
        }
        public static System.Data.DataTable SelectTTDLByMa(int ma)
        {
            System.Data.DataTable dt = DaiLyDAO.SelectTTDLByMa(ma);
            return dt;
        }
        public static System.Data.DataTable SelectAllMa_No_DaiLy()
        {
            System.Data.DataTable dt = DaiLyDAO.SelectAllMa_No_DaiLy();
            return dt;
        }
        public static System.Data.DataTable SelectAllMa_No_DaiLy_Moi()
        {
            System.Data.DataTable dt = DaiLyDAO.SelectAllMa_No_DaiLy_Moi();
            return dt;
        }
        public static System.Data.DataTable SelectDemSoPhieuXuat(int thang, int nam)
        {
            System.Data.DataTable dt = DaiLyDAO.SelectDemSoPhieuXuat(thang, nam);
            return dt;
        }
        public static System.Data.DataTable SelectTimKiem(string maDl, string tenDL, string malaoiDL, string dt, string dc, string quan, string ngaytiepnhan, string email, string no)
        {
            System.Data.DataTable da = DaiLyDAO.SelectTraCuu(maDl,tenDL,malaoiDL,dt,dc,quan,ngaytiepnhan,email,no);
            return da;
        }
        public static System.Data.DataTable SelectDaiLyByMaQuan(int maquan)
        {
            System.Data.DataTable da = DaiLyDAO.SelectDaiLyByMaQuan(maquan);
            return da;
        }


    }
}
