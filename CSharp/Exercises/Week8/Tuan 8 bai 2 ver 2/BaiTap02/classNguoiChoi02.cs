using System;
using System.Drawing;
namespace BaiTap02
{
    public class NguoiChoi02
    {
        private float _tren, _duoi, _trai, _phai;
        private string _ten;
        private int _soTranThang = 0;

        public string Ten
        {
            get { return _ten; }
            set { _ten = value; }
        }
        public int SoTranThang
        {
            get { return _soTranThang; }
            set { _soTranThang = value; }
        }
        public float Tren
        {
            get { return _tren; }
            set { _tren = value; }
        }

        public float Duoi
        {
            get { return _duoi; }
            set { _duoi = value; }
        }

        public float Trai
        {
            get { return _trai; }
            set { _trai = value; }
        }

        public float Phai
        {
            get { return _phai; }
            set { _phai = value; }
        }
        public void GanToaDo(float tren, float duoi, float trai, float phai)
        {
            _tren = tren;
            _duoi = duoi;
            _trai = trai;
            _phai = phai;
        }
        public void VeNguoiChoi(Graphics g)
        {
            Pen p = new Pen(Brushes.Blue, 2);
            g.DrawRectangle(p, Trai, Tren, Phai - Trai, Duoi - Tren);
        }
        public void DiChuyenLen()
        {
            Tren -= 10;
            Duoi -= 10;
        }
        public void DiChuyenXuong()
        {
            Tren += 10;
            Duoi += 10;
        }
    }
}
