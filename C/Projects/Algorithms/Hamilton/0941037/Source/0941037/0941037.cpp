// 0941037.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Hamilton.h"


int main(int argc, char* argv[])
{
	if(argc==4)
	{
		ifstream fVar1(argv[2]);
		ofstream fVar2(argv[3]);
		
		CHamilton H;
		fVar1 >> H;
	
		H.HamiltonPath(argv[3]);
	}
	else
		cout<<"Nhap lieu sai!!!";


	return 0;
}