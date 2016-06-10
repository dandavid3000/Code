using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLDL.DTO
{
   public class ThamSoDTO
    {
         #region "Attributes"

        private int _soluongdailytoidamoiquan;
        private int _soluongloaidaily; 
        private int _soluongmathang;
        private int _soluongDVT;   
       
        #endregion


        #region "Properties"

       public int Soluongdailytoidamoiquan
       {
           get { return _soluongdailytoidamoiquan; }
           set { _soluongdailytoidamoiquan = value; }
       }

       public int Soluongloaidaily
       {
           get { return _soluongloaidaily; }
           set { _soluongloaidaily = value; }
       }

       public int Soluongmathang
       {
           get { return _soluongmathang; }
           set { _soluongmathang = value; }
       }

       public int SoluongDvt
       {
           get { return _soluongDVT; }
           set { _soluongDVT = value; }
       }

       #endregion
       public ThamSoDTO()
       {
           

       }
        public ThamSoDTO(int soluongdailytoimoiquan, int soluongloaidaily, int soluongmathang, int soluongDVT,int dongiaban)
        {
            _soluongdailytoidamoiquan = soluongdailytoimoiquan;
            _soluongloaidaily = soluongloaidaily;
            _soluongmathang = soluongmathang;
            _soluongDVT = soluongDVT;

        }
    }
}
