using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;

namespace QLDL.BUS
{
    public class QuanBUS
    {
          public static System.Data.DataTable SelectAllQuan()
          {
            System.Data.DataTable dttb = QuanDAO.SelectAllQuan();
            return dttb;
         }
          public static int SelectMaByTenLoai(string tenquan)
          {
              int ma = QuanDAO.SelectMaQuanBytenQuan(tenquan);
              return ma;
          }
          public static int DemSoDLMoiQuan(int ma)
          {
              int sl = QuanDAO.DemSoDaiLyMoiQuan(ma);
              return sl;
          }
          public void ThemQuan(QuanDTO dv)
          {
              QuanDAO.InsertQuan(dv);
          }
          public void XoaQuan(int madonvi)
          {
              QuanDAO.DeleteQuanByMaQuan(madonvi);
          }

          public void CapNhatQuan(QuanDTO dv)
          {
              QuanDAO.UpdateQuan(dv);
          }

          public List<QuanDTO> DanhSachQuan()
          {
              return new QuanDAO().DanhSachQuan();
          }
    }
}
