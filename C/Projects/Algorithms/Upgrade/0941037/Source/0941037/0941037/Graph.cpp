#include "Graph.h"


CGraph::CGraph(void)
{
}

CGraph::~CGraph(void)
{
}

void CGraph::arrayInit(intArray &a, int n)
{
	a.resize(n);

}

bool CGraph::KTDoThiDon(CMatrix m)
{
	for(int i=0; i<(int)m.GetSize(); i++)
	{
		for(int j=0; j<(int)m.GetSize(); j++)
		{
			if((m.array2D[i][i]!=0)||(m.array2D [i][j]!= m.array2D[j][i]))
				return false;
		}
	}
	return true;
}

void CGraph::SapDoThi()
{
	arrayInit(SoPTLienThong, label+1);
	arrayInit(NhanDinh, label+1);

	for (int i=1; i<=label; i++)
	{
		int dem=0;
		for (int j=0; j< (int)Nhan.size(); j++)
		{
			if (Nhan[j]==i)
				dem++;
		}

		SoPTLienThong[i]= dem;
		NhanDinh[i] = i;
	}

	for (int i=1; i<label; i++)
	{
		for (int j=i+1; j<=label; j++)
			if (SoPTLienThong[i] > SoPTLienThong[j])
			{
				int temp1 =0;
				temp1 = NhanDinh[i];
				NhanDinh[i] = NhanDinh[j];
				NhanDinh[j] = temp1;

				int temp2 =0;
				temp2 = SoPTLienThong[i];
				SoPTLienThong[i] = SoPTLienThong[j];
				SoPTLienThong[j] = temp2;
			}
	}
}

void CGraph::Visit(CMatrix m, int n)
{
	Nhan[n] = label;
	for(int i=0; i<(int)Nhan.size(); i++)
	{
		if ((m.array2D[n][i]==1 || m.array2D[i][n]==1)&& Nhan[i] ==0)
			Visit(m,i);

	}
	
}

void CGraph::ThanhPhanLienThong(CMatrix m)
{
	label=0; //Gan nhan label =0

	arrayInit(Nhan,m.GetSize());

	for(int i=0; i<(int)m.array2D.size(); i++)
		Nhan[i]=label;
	for(int j=0;j< (int)Nhan.size();j++)
	{
		if(Nhan[j]==0)
		{
			label=label+1;
			Visit(m,j);
		}
	}
}

void CGraph::XuatThanhPhanLT(char * DuongDan)
{
	ofstream fVar(DuongDan); 
	fVar<<label<<endl;
	cout<<label<<endl;
	for(int i=1; i<=label; i++) 
	{ 
		for(int j=0; j<(int)Nhan.size(); j++)
		{ 
			if(Nhan[j]==NhanDinh[i]) 
			{ 
				fVar<<j<<" ";
				cout<<j<<" ";
			} 
		}
		fVar<<endl;
		cout<<endl;
	} 
}

bool CGraph::IsAdjacentMatValid(CMatrix m)
{
	for(int i=0; i<(int)m.array2D[i].size(); i++)
	{
		for(int j=0; j<(int)m.array2D[i].size(); j++)
		{
			if(m.array2D[i][j]!=0 || m.array2D[i][j]!=1)
				return false;
		}
	}
	return true;
}