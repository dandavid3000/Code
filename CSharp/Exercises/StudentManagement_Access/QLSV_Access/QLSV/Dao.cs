using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace QLSV
{
    class Dao
    {
        string strCnn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=QLHS.mdb";

        public DataTable LayDanhSachLop()
        {
            string sql = "Select * from LopHoc";
            OleDbConnection ket_noi = new OleDbConnection(strCnn);
            OleDbDataAdapter bo_thich_ung = new OleDbDataAdapter(sql, ket_noi);

            DataTable kq = new DataTable();
            bo_thich_ung.Fill(kq);

            return kq;
        }

        public DataTable LayDanhSachHocSinhTheoLop(int MaLop)
        {
            string sql = "Select * from SinhVien where MaLop=" + MaLop.ToString();
            OleDbConnection ket_noi = new OleDbConnection(strCnn);
            OleDbDataAdapter bo_thich_ung = new OleDbDataAdapter(sql, ket_noi);

            DataTable kq = new DataTable();
            bo_thich_ung.Fill(kq);

            return kq;
        }
    }
}
