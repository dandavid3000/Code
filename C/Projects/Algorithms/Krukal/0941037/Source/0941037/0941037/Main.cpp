#include "Graph.h"
#include "Matrix.h"
#include "SpanningTree.h"
#include "Euler.h"

//int main(int argc, char* argv[])
//
//{
//	if(argc ==4)
//	{
//		CMatrix B,Bn;
//		CGraph C,sT;
//
//		ifstream fVar(argv[2]);
//		fVar>>B;
//		ifstream fVar2(argv[2]);
//		fVar2>>Bn;
//
//		int n=B.GetSize();
//
//		C.InitListEdge(B);
//		C.SortListEdge();
//	
//		sT.KruskalAlg(C,n);
//		sT.SortListEdgeEx();
//		sT.XuatCayKhungKruskal(argv[3],B,Bn);
//		
//		return 0;
//	}
//	else
//		cout<<"Nhap dong lenh sai"<<endl;
//}

void main()
{
	CMatrix B;
	CEuler E;

	ifstream fVar("input.txt");
	fVar>>B;

	if(E.KTChuTrinhEuler(B)==true)
		E.ChuTrinhEuler(B);
}