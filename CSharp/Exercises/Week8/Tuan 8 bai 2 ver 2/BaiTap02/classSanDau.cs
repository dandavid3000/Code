using System;
using System.Drawing;
namespace BaiTap02
{
    public class SanDau
    {
        private float _tren, _duoi, _trai, _phai;

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
        public void VeSanDau(Graphics g)
        {
            Pen p = new Pen(Brushes.White, 2);
            g.DrawRectangle(p, Trai, Tren, Phai - Trai, Duoi - Tren);
        }

        public void DiChuyenLen()
        {
            Tren -= 2;
            Duoi -= 2;
        }
    }
}
