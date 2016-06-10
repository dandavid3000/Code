#include "Graph.h"
#include "Matrix.h"
#include "SpanningTree.h"

int main(int argc, char* argv[])
{
	if(argc ==4)
	{
		CMatrix B,Bn;
		CGraph C;
		
		fstream fVar1(argv[2]);
		fVar1>>B;

		fstream fVar2(argv[2]);
		fVar2>>Bn;
		
		C.XuatCayKhung(argv[3],B,Bn);
		cout<<endl;
		return 0;
	}
	else
		cout<<"Nhap dong lenh sai"<<endl;
		
}