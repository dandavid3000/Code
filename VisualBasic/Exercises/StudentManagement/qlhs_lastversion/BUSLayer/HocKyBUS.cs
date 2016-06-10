using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;

namespace BUSLayer
{
    public class HocKyBUS
    {
        public TList<HocKy> LayBang()
        {
            TList<HocKy> ds = new TList<HocKy>();
            HocKyService hkService = new HocKyService();
            ds = hkService.GetAll();
            return ds;
        }
    }
}
