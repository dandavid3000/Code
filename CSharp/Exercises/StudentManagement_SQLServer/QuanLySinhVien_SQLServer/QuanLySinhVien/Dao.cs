using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace QuanLySinhVien
{
    class Dao
    {
        string strCnn = "Provider=SQLOLEDB;Data Source=TVQUY;Integrated Security=SSPI;Initial Catalog=QLSV";

        public DataTable LayDanhSachLop()
        {
            DataTable kq = new DataTable();
            OleDbConnection ket_noi = new OleDbConnection(strCnn);
            string sql = "Select * from Lop";
            OleDbDataAdapter bo_thich_ung = new OleDbDataAdapter(sql, ket_noi);

            bo_thich_ung.Fill(kq);

            return kq;
        }

        public DataTable LayDanhSachSinhVienTheoLop(int MaLop)
        {
            DataTable kq = new DataTable();
            OleDbConnection ket_noi = new OleDbConnection(strCnn);
            string sql = "Select * from SinhVien Where MaLop=" + MaLop.ToString();
            OleDbDataAdapter bo_thich_ung = new OleDbDataAdapter(sql, ket_noi);

            bo_thich_ung.Fill(kq);

            return kq;
        }
    }
}
