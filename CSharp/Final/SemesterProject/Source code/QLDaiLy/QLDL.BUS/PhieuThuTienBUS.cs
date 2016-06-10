using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;

namespace QLDL.BUS
{
    public static class PhieuThuTienBUS
    {
        public static void InsertPhieuThu(PhieuThuTienDTO dl)
        {
           PhieuThuDAO.InsertPhieuThu(dl);
        }
        public static System.Data.DataTable tongGiaTriPTTrongThang(int thang, int nam)
        {
           System.Data.DataTable dt = PhieuThuDAO.TongGiaTriPTTrongThang(thang, nam);
            return dt;
        }
    }
}
