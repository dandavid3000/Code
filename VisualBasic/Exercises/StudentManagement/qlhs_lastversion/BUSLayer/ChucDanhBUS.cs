using System;
using System.Collections.Generic;
using System.Text;
using QuanLyHocSinhPTNK.Entities;
using QuanLyHocSinhPTNK.Services;

namespace BUSLayer
{
    public class ChucDanhBUS
    {
        public ChucDanh LayChucDanh(string machucdanh)
        {
            ChucDanhService cdService = new ChucDanhService();
            return cdService.GetByMaChucDanh(machucdanh);
        }

        public TList<ChucDanh> LayDanhSachChucDanh(string mapb)
        {           
            QuanLyService qlService = new QuanLyService();
            TList<QuanLy> dsql = qlService.GetByMaPhongBan(mapb);
            TList<ChucDanh> dschucdanh = new TList<ChucDanh>();
            foreach (QuanLy ql in dsql)
            {
                dschucdanh.Add(LayChucDanh(ql.MaChucDanh));
            }
            
            for (int i = 0; i < dsql.Count; i++)
            {
                int dem = 0;
                for (int j = 0; j < dsql.Count; j++)
                {
                    if (dsql[i].MaChucDanh == dsql[j].MaChucDanh)
                        dem++;
                }
                if (dem == 2)
                {
                    dschucdanh.Remove(LayChucDanh(dsql[i].MaChucDanh));                  
                    break;
                }
            }       
            return dschucdanh;
        }
    }
}
