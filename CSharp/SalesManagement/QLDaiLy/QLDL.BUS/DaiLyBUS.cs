using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLDL.DTO;
using QLDL.DAO;

namespace QLDL.BUS
{
    public class DaiLyBUS
    {
        public static System.Data.DataTable SelectAllDaiLy()
        {

            System.Data.DataTable dt = DaiLyDAO.SelectAllDaiLy();
            return dt;
           
        }

        public static void InsertDaiLy(DaiLyDTO dl)
        {
            DaiLyDAO.Insertdaily(dl);
        }
        public static void DeleteDaiLy(int madaily)
        {
            DaiLyDAO.DeletedailyByMadaily(madaily);
        }
        public static void updateDaiLy(DaiLyDTO dl)
        {
            DaiLyDAO.Updatedaily(dl);
        }

    }
}
