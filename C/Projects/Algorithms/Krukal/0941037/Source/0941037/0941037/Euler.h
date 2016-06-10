#pragma once
#include "Matrix.h"
#include "EDGE.h"


using namespace std;
class CEuler
{
public:
	vector<int> intBacDinh;
	vector<CEDGE> lstEdge;
	

	CEuler(void);
	bool KTChuTrinhEuler(CMatrix );
	void ChuTrinhEuler(CMatrix );
	void InitListEdge(CMatrix ); //Tao ra danh sach canh tu ma tran ke;
	void SortListEdge();
	void HoanViCanh(int, int);
	void FindTour(int,CEDGE &, vector<int> &, vector<int> &);
	void XuatDSDinh(vector<int> );


public:
	~CEuler(void);
};
