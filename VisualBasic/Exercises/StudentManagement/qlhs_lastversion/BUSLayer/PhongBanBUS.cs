using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Services;

namespace BUSLayer
{
    public class PhongBanBUS
    {
        public TList<PhongBan> LayBang()
        {
            PhongBanService pbService = new PhongBanService();
            return pbService.GetAll();
        }
    }
}
