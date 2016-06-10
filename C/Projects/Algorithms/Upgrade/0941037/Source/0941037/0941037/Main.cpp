#include "Graph.h"
#include "Matrix.h"

int main(int argc, char* argv[])
{
	if(argc ==4)
	{
		CMatrix B;
		
		fstream fVar1(argv[2]);
		fVar1>>B;
		CGraph C;

		C.ThanhPhanLienThong(B);
		C.SapDoThi();
		C.XuatThanhPhanLT(argv[3]);
	
		return 0;
	}
	else
		cout<<"Nhap dong lenh sai"<<endl;
}