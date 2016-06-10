using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;
using System.ComponentModel;

namespace QLDL.BUS
{
    public class ThamSoBUS
    {
        public static System.Data.DataTable SelectAllThamSo()
        {

            System.Data.DataTable dt = ThamSoDAO.SelectAllThamSo();
            return dt;

        }


        public void CapNhatThamSo(ThamSoDTO dv)
        {
            ThamSoDAO.UpdateThamSo(dv);
        }

        public List<ThamSoDTO> DanhSachThamSo()
        {
            return new ThamSoDAO().DanhSachThamSo();
        }

        public static int SoDLToiDa()
        {
            int sl = ThamSoDAO.SoDLToiDa();
            return sl;
        }
        public static int SLLoaiDL()
        {
            int sl = ThamSoDAO.SLloaiDL();
            return sl;
        }
        public static int SLMatHang()
        {
            int sl = ThamSoDAO.SLloaiDL();
            return sl;
        }
        public static int SL_DVT()
        {
            int sl = ThamSoDAO.SLloaiDL();
            return sl;
        }

    }
}
