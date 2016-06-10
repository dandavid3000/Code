using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;

namespace BUSLayer
{
    public class MonBUS
    {
        public TList<MonHoc> LayBang()
        {
            MonHocService MHService = new MonHocService();
            TList<MonHoc> ds = new TList<MonHoc>();
            ds = MHService.GetAll();
            return ds;
        }
    }
}
