#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <process.h>

using namespace std;

class PHANSO {
protected:
	int iTu;
	int iMau;
public:
	PHANSO();
	PHANSO(int, int);
	~PHANSO();
	friend istream& operator>>(istream  &is, PHANSO &x);
	friend ostream& operator << (ostream  &os, PHANSO &x);
	PHANSO operator=(PHANSO &x);
};

class HONSO:public PHANSO {
private:
	int iHonSo;
public:
	HONSO(int, int ,int);
	HONSO();

	friend ostream& operator<<(ostream &os, HONSO &x);
};

HONSO::HONSO()
{

}

HONSO::HONSO(int x, int y, int h)
{
	this->iHonSo = h;
	this->iTu = x;
	this->iMau = y;
}


PHANSO PHANSO::operator=(PHANSO &x)
{
	this->iTu = x.iTu;
	this->iMau = x.iMau;
	return *this;
}


PHANSO::PHANSO()
{
	this->iTu = 0;
	this->iMau = 0;
}

PHANSO::PHANSO(int x, int y)
{
	this->iTu = x;
	this->iMau = y;

}

PHANSO::~PHANSO()
{
	return;
}

istream& operator >> (istream &is, PHANSO &x)
{
	cout <<"Nhap tu: ";
	is >> x.iTu;
	cout << "Nhap mau: ";
	is >> x.iMau;
	return is;
}

ostream& operator << (ostream &os, PHANSO &x)
{
	os << x.iTu << "/" << x.iMau;
	return os;
}

ostream& operator<<(ostream &os, HONSO &x)
{
	os << x.iHonSo << "-" << x.iTu << "/" << x.iMau;

	return os;
}


void main()
{
	PHANSO A, B;
	cin >> A;
	cin >> B;

	PHANSO C, D;

	C = B;
	D = A;

	cout << A << endl << B << endl;
	cout << C << endl << D<<endl;

	HONSO H(1,2,3);

	A = H;

	HONSO *H1;
	PHANSO *A1;
	H1 = &H;
	A1 = H1;

	cout << H << endl << A << endl;
	cout << *A1 << endl << *H1 << endl;

	system("pause");
}