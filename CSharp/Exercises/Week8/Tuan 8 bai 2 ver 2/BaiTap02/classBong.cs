using System;
using System.Drawing;
namespace BaiTap02
{
    public class Bong
    {
        private float _tren, _duoi, _trai, _phai;
        private float _vectorDiChuyenX, _vectorDiChuyenY;

        public float VectorDiChuyenX
        {
            get { return _vectorDiChuyenX; }
            set { _vectorDiChuyenX = value; }
        }

        public float VectorDiChuyenY
        {
            get { return _vectorDiChuyenY; }
            set { _vectorDiChuyenY = value; }
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
        public void VeBong(Graphics g)
        {
            g.FillEllipse(Brushes.Red, Trai, Tren, Phai - Trai, Duoi - Tren);
        }
        public void GanVectorDiChuyen(float vectorX, float vectorY)
        {
            VectorDiChuyenX = vectorX;
            VectorDiChuyenY = vectorY;
        }
        public void DiChuyen()
        {
            Tren += VectorDiChuyenY;
            Duoi += VectorDiChuyenY;
            Trai += VectorDiChuyenX;
            Phai += VectorDiChuyenX;
        }

    }
}
