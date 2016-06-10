#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <vector>
#include <string>

using namespace std;


class CaSy
{
public:
	char _hoTen[31];
	int _soNamLamViec;
	int _soDiaBanDuoc;
	int _soBuoiBieuDien;

	virtual void Nhap()=0;
	virtual void Xuat()=0;
	virtual int Luong() = 0;
};

class CaSyThuong :public CaSy
{
public:
	void Nhap();
	void Xuat();
	int Luong();
};

void CaSyThuong::Nhap()
{
	cout << "Ten ca sy : ";
	cin >> _hoTen;
	cout << "So nam lam viec : ";
	cin >> _soNamLamViec;
	cout << "So dia ban duoc : ";
	cin >> _soDiaBanDuoc;
	cout << "So buoi bieu dien : ";
	cin >> _soBuoiBieuDien;
}

int CaSyThuong::Luong()
{
	int luong = 0;
	luong = 3000000 + 500000 * _soNamLamViec + 1000 * _soDiaBanDuoc;
	if (_soDiaBanDuoc > 3000)
		luong += 1000000;
	return luong;

}
void CaSyThuong::Xuat()
{
	cout << "Ten ca sy : " << _hoTen << endl;
	cout << "Luong : " << Luong() << endl;
	if (_soDiaBanDuoc > 3000)
		cout << "Tien thuong : 1000000" << endl;

}

class CaSyNoiTieng:public CaSy
{
	protected:
		int _soGameShow;
	public:
		void Nhap();
		void Xuat();
		int Luong();
};

void CaSyNoiTieng::Nhap()
{
	cout << "Ten ca sy : ";
	cin >> _hoTen;
	cout << "So nam lam viec : ";
	cin >> _soNamLamViec;
	cout << "So dia ban duoc : ";
	cin >> _soDiaBanDuoc;
	cout << "So buoi bieu dien : ";
	cin >> _soBuoiBieuDien;
	cout << "So game show : ";
	cin >> _soGameShow;
}

int CaSyNoiTieng::Luong()
{
	int luong = 0;
	luong = 5000000 + 500000 * _soNamLamViec + 1200 * _soDiaBanDuoc + 300000 * _soBuoiBieuDien + 500000 * _soGameShow;
	return luong;
}

void CaSyNoiTieng::Xuat()
{
	cout << "Ten ca sy : " << _hoTen << endl;
	cout << "Luong : " << Luong() << endl;
}

//-------- QUAN LY CA SY----------	

class QuanLyCaSy
{
public:
	int _loaiCaSy;
	vector <CaSy*> _danhSachCaSy;
	void NhapDanhSachCaSy();
	void XuatDanhSachCaSy();
	int TongLuong();
	vector <CaSy*> CaSyCoLuongCaoNhat();

};

void QuanLyCaSy::NhapDanhSachCaSy()
{
	char A='Y';
	do
	{
		cout << "\n----- NHAP CA SY  ---- " << endl;
		cout << "\n1. Ca sy \"chua\" noi tieng " << endl;
		cout << "2. Ca sy noi tieng" << endl;
		cout << "3. Xuat thong tin" << endl;
		cout << "4. Tong Luong phai tra" << endl;
		cout << "5. Ca sy co luong cao nhat" << endl;

		cout << "\nChon so : ";
		cin >> _loaiCaSy;

		switch (_loaiCaSy)
		{
			case 1 :
			{
				CaSyThuong* cst = new CaSyThuong();
				cst->Nhap();
				_danhSachCaSy.push_back(cst);
				break;
			}
			case 2 :
			{
				CaSyNoiTieng* csnt = new CaSyNoiTieng();
				csnt->Nhap();
				_danhSachCaSy.push_back(csnt);
				break;
			}
			case 3 : 
			{
				this->XuatDanhSachCaSy();
				break;
			}
			case 4 :
			{
				int tl = this->TongLuong();
				cout << "Tong luong phai tra cho cac ca sy: " << tl << endl;
				break;
			}
			case 5:
			{
				vector <CaSy*> dsCaSyLuongCaoNhat = CaSyCoLuongCaoNhat();
				for (int i = 0; i < (int)dsCaSyLuongCaoNhat.size(); i++)
					dsCaSyLuongCaoNhat[i]->Xuat();
				break;
			}
		}

	} while (A == 'Y' || A == 'y');
}

int QuanLyCaSy::TongLuong()
{
	int tongluong = 0;
	int size;
	int temp;

	size = (int)_danhSachCaSy.size();
	for (int i = 0; i <size; i++)
	{
		temp = _danhSachCaSy[i]->Luong();
		tongluong += temp;
	}

	return tongluong;
}

void QuanLyCaSy::XuatDanhSachCaSy()
{
	int size;
	size = (int)_danhSachCaSy.size();
	for (int i = 0; i <size; i++)
	{
		cout << "\nCa sy thu " << i << endl;
		_danhSachCaSy[i]->Xuat();
	}
}


vector <CaSy*> QuanLyCaSy::CaSyCoLuongCaoNhat()
{
	int temp = 0;
	int size;
	size = (int)_danhSachCaSy.size();

	vector <CaSy *> dsCaSyLuongCao;

	for (int i = 0; i<size; i++)
	{
		if (temp < _danhSachCaSy[i]->Luong())
			temp = _danhSachCaSy[i]->Luong();
	}
	//Tim ra duoc danh sach ca sy co luong cao nhat;

	for (int i = 0; i<size; i++)
	{
		if (temp == _danhSachCaSy[i]->Luong())
			dsCaSyLuongCao.push_back(_danhSachCaSy[i]);
			//Add ca sy co luong cao nhat vao danh sach
	}
	//Co the co nhieu ca sy boi vi, co the co hai ca sy trung voi nhau

	return dsCaSyLuongCao;
}

void main()
{
	QuanLyCaSy* cs = new QuanLyCaSy();
	cs->NhapDanhSachCaSy();
}