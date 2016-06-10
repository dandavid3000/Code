using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Services;
using QuanLyHocSinhPTNK.Data;

namespace BUSLayer
{
    public class KhoiBUS
    {
        public TList<Khoi> LayBang()
        {
            TList<Khoi> ds = new TList<Khoi>();
            KhoiService kService = new KhoiService();
            ds = kService.GetAll();
            return ds;
        }
    }
}
