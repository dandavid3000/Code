// 0941037.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include "Graph.h"
#include <iostream>
#include <fstream>

int main(int argc, char* argv[])
{
	if(argc==4)
	{
		CGraph C,C2,C3;//(C2 la sau khi ngap nuoc)
		ofstream fVar(argv[3]);
		
		//C2 la Graph da qua xu ly ngap nuoc
		//matrix1st da fix sau khi ngap nuoc, va 2nd da fix sau khi bi ngap
		ifstream fVar2(argv[2]);
		fVar2>>C2;
		C2.XuLyNgapNuoc();
		C2.ThanhPhanLienThong();
		C2.SortGraph();

		//C3 la ma tran phu dung de xu ly, tim duoc chi phi do dai thap nhat
		ifstream fVar3(argv[2]);
		fVar3>>C3;
		C3.XuLyNgapNuoc();

		//C la Graph voi ma tran 1 va 2 chua bi ngap nuoc
		//matrix1st la matran do dai, matrix2nd la matran do cao
		ifstream fVar1(argv[2]);
		fVar1>>C;

		int C2label = C2.LayLabel(); //Lay so TPLT cua do thi C2 ( do thi ngap nuoc )

		C.ThanhPhanLienThong();
		C.SortGraph();

		//Lay danh sach canh bi ngap nuoc lstEdge và sap xep lai
		C.TapCanhNgapNuoc(C2);
		C.SortEdgeNgapNuoc();

		//Lay danh sach canh ko bi ngap nuoc lstEdgeKoNgap
		C.TapCanhKoNgapNuoc(C2);

		C.GanDoDaiNangCap(0); //Dau tien gan do dai nang cap  = 0
		C.ChiPhiDoDaiThapNhat(C3,C2label);//Truyen do thi phu C3 vao va nhan cua do thi ngap nuoc C2(tuc la so TPLT do thi C2)
		
		C.XuatTPLT(argv[3],C2);
		
		//Test 2 tap canh ngap nuoc va ko ngap nuoc co dung ko
		
		/*for(int i=0;i<(int)lstEdge.size();i++)
			cout<<lstEdge[i].LayV()<<","<<lstEdge[i].LayW()<<" ";
		cout<<endl;
		for(int i=0;i<(int)lstEdgeKoNgap.size();i++)
			cout<<lstEdgeKoNgap[i].LayV()<<","<<lstEdgeKoNgap[i].LayW()<<" ";*/
	}
	else
		cout<<"Nhap du lieu sai!!!";


	return 0;

}
