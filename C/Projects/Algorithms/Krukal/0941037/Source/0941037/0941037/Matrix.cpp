#include "Matrix.h"
#include <iostream>
#include <fstream>

CMatrix::CMatrix(void)
{
}

CMatrix::~CMatrix(void)
{
}

void CMatrix::matrixInit(int n)
{
	array2D.resize(n);
	for(int i=0; i< (int)array2D.size(); i++)
			array2D[i].resize(n);
}

istream& operator >>( istream& is, CMatrix &a)
{
	int n,temp;
	is >> n;
	a.matrixInit(n);
	for (int i=0; i<(int)a.array2D.size(); i++)
		for(int j=0; j<(int)a.array2D[i].size(); j++)
		{
			a.array2D[i][j]=0;
			if(is)
			{
				is >>temp;
				a.array2D[i][j]= temp;
			}
		}
	return is;
}

ostream& operator << (ostream& os, CMatrix &a)
{
	for (int i=0; i<(int)a.array2D.size(); i++)
	{
		for (int j=0; j<(int)a.array2D[i].size(); j++)
		{
			os<<(int)a.array2D[i][j]<<" ";
		}
		os<<endl;
	}
	return os;
}


int CMatrix::GetSize()
{
	return (int)array2D.size();
}
