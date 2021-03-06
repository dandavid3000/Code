#pragma once
#include <vector>
#include <iostream>
#include <fstream>
#include "EDGE.h"

using namespace std;

class CGraph
{
private:
	int _soDinh;
	int _doCaoNgapNuoc;
	int _doDaiNangCap;

	int _label; // So nhan cung chinh la so TPLT

	vector<int> _soPTLT;
	vector<int> _nhan;
	vector<int> _nhanDinh;

	vector<vector<int>> _matrix1st; //Matran the hien do dai
	vector<vector<int>> _matrix2nd; //Matran the hien do cao

	vector<CEDGE> lstEdge; //Danh sach canh bi ngap
	vector<CEDGE> lstEdgeKoNgap; // Danh sach canh ko ngap

public:
	//Cac ham Get-Set
	void GanSoDinh(int );
	void GanDoCaoNgapNuoc(int );
	void GanDoDaiNangCap(int );
	void GanLabel(int );
	
	int LaySoDinh();
	int LayDoCaoNgapNuoc();
	int LayDoDaiNangCap();
	int LayLabel();

	//Nhap xuat resize ma tran
	friend istream& operator >> (istream& , CGraph &);
	friend ostream& operator << (ostream& , CGraph &);
	void MatrixInit(int);
	
	//Cac ham lien quan den TPLT, sap xep va Xuat
	void SortGraph();
	void Visit(int );
	void ThanhPhanLienThong();
	void XuatTPLT(char *, CGraph);
	
	//Cac ham xu ly lien quan toi canh
	void HoanViCanh(int,int);
	void TapCanhKoNgapNuoc(CGraph);
	void TapCanhNgapNuoc(CGraph);

	//Cac ham lien quan toi xu ly ngap nuoc
	void XuLyNgapNuoc();
	void SortEdgeNgapNuoc();

	//Ham tim chi phi thap nhat ( dua vao so TPLT )
	void ChiPhiDoDaiThapNhat(CGraph, int);

	CGraph(void);
public:
	~CGraph(void);
};
