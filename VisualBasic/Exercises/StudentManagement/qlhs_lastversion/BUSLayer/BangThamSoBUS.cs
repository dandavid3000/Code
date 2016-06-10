using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Entities;

namespace BUSLayer
{
    public class BangThamSoBUS
    {
        public void CapNhat(BangThamSo bts)
        {       
            BangThamSoService btsService = new BangThamSoService();
            btsService.CapNhat(bts);
        }

        public BangThamSo LayBangTheoMa(string mabangthamso)
        {
            BangThamSoService btsService = new BangThamSoService();
            return btsService.GetByMaBangThamSo(mabangthamso);
        }
    }
}
