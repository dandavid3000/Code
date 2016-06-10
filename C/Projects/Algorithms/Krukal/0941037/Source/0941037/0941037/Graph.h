#pragma once
#include "Matrix.h"
#include "SpanningTree.h"
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

typedef vector<int> intArray;
typedef vector<char> charArray;


class CGraph
{
private:
	intArray Nhan; // 0=>size(), thu tu cung la cac dinh, mang dc gan nhan
	int label;
	intArray SoPTLienThong;
	intArray NhanDinh;
	vector<CEDGE> lstEdge; //Danh sach canh
	int tongTrongSo;

public:
	CGraph(void);
	int LayTongTrongSo();
	int GetSizeList();
	void arrayInit(intArray &,int); // Doi kich co mang
	bool KTDoThiDon(CMatrix);
	void SapDoThi();
	void Visit(CMatrix, int);
	void ThanhPhanLienThong(CMatrix);
	void XuatThanhPhanLT(char *);
	bool IsAdjacentMatValid(CMatrix); //Kiem tra tinh hop le cua ma tran ke
	bool PrimAlg(CMatrix, CSpanningTree &, int &);// Ham tìm cây khung
	bool PrimAlgEx(CMatrix, CSpanningTree &, int &, int);
	void XuatCayKhungPrim(char *,CMatrix , CMatrix );

	void InitListEdge(CMatrix ); //Tao ra danh sach canh tu ma tran ke;
	void SortListEdge(); //Sap xep danh sach canh theo thu tu tang dan
	void KruskalAlg(CGraph C, int n); //Ham tim cay khung nho nhat bang thuat toan Kruskal
	void HoanViCanh(int, int);
	void XuatCayKhungKruskal(char *,CMatrix B, CMatrix Bn);
	void UpdateLabels(int ,int );
	int Min(int, int);
	int Max(int, int);
	void SortListEdgeEx();
	void TimTPLT(CMatrix,CMatrix,vector<CGraph> &);
	bool KiemTraDoThiLT(CMatrix, CMatrix );


public:
	~CGraph(void);
};
