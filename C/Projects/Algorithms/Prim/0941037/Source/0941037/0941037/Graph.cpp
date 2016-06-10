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
bool CGraph::PrimAlg(CMatrix m,CSpanningTree &A, int &TreeSize )
{
	int inTree[100]; // Thuoc cay khung neu 1, ko thuoc la 0
	int nLbl = (int)m.GetSize(); //So dinh cua do thi
	
	for (int i=0; i<nLbl; i++)
		inTree[i]=0;
	//Gan nhan cho dinh dau tien là 1;
	inTree[0] = 1;
	//So canh da duoc chon la 0
	while(TreeSize < nLbl-1)//so canh cua cay khung chua du 
	{
		CEDGE edgeMin;

		//Tim canh co trong so nho nhat
		int mMinWeight =-1;
		for (int i=0; i<nLbl; i++)
			for (int j=0; j<nLbl; j++)
				if ( inTree[i]==1 && inTree[j] ==0 && m.array2D[i][j]!=0)
					if (mMinWeight == -1 || edgeMin.LayTrongSo() > m.array2D[i][j])
					{
						edgeMin.GanV(i);
						edgeMin.GanW(j);
						edgeMin.GanTrongSo(m.array2D[i][j]);
						mMinWeight = edgeMin.LayTrongSo();
					}
				
		if (mMinWeight == -1 ) return false;
		else A.AddEdge(edgeMin);
		int k = edgeMin.LayW();
		inTree[k] =1;
		TreeSize ++;
	}
	return true;
}

bool CGraph::PrimAlgEx(CMatrix m, CSpanningTree &A, int & TreeSize, int DinhBatDau)
{
	int inTree[100]; // Thuoc cay khung neu 1, ko thuoc la 0
	int nLbl = (int)m.GetSize(); //So dinh cua do thi
	
	for (int i=0; i<nLbl; i++)
		inTree[i]=0;
	//Gan nhan cho dinh dau tien là 1;
	DinhBatDau --;
	inTree[DinhBatDau] = 1;
	//So canh da duoc chon la 0
	while(TreeSize < nLbl-1)//so canh cua cay khung chua du 
	{
		CEDGE edgeMin;
		
		//Tim canh co trong so nho nhat
		int mMinWeight = -1;
		for (int i=0; i<nLbl; i++)
			for (int j=0; j<nLbl; j++)
				if ( inTree[i]==1 && inTree[j] ==0 && m.array2D[i][j]!=0)
					if (mMinWeight == -1 || edgeMin.LayTrongSo() > m.array2D[i][j])
					{
						edgeMin.GanV(i);
						edgeMin.GanW(j);
						edgeMin.GanTrongSo(m.array2D[i][j]);
						mMinWeight = edgeMin.LayTrongSo();
					}
				
		if (mMinWeight == -1 ) return false;
		else A.AddEdge(edgeMin);
		int chon = edgeMin.LayW();
		inTree[chon] =1;
		TreeSize ++;
	}
	return true;
}

void CGraph::XuatCayKhung(char *DuongDan, CMatrix B, CMatrix Bn)
{
	ofstream fVar(DuongDan); 
	CSpanningTree T;
	int TreeSize =0;
	int Total =0;
	
	if(PrimAlg(B,T,TreeSize) == true)
	{
		for (int i =0; i< TreeSize; i++)
			Total += T.Tree[i].LayTrongSo();
		cout<<Total<<endl;
		fVar<<Total<<endl;

		for (int i =0; i< TreeSize; i++)
			{
				cout<<"("<<T.Tree[i].LayV()<<","<<T.Tree[i].LayW()<<") ";
				fVar<<"("<<T.Tree[i].LayV()<<","<<T.Tree[i].LayW()<<") ";
			}
	}

	else 
	{
		CGraph C;

		//Bien do thi co trong so ve ko co trong so ta se tim dc 2 thanh phan LT

		for(int i=0; i<Bn.GetSize();i++)
			for (int j=0; j<Bn.GetSize(); j++)
				if (Bn.array2D[i][j] !=0)
					Bn.array2D[i][j]=1;

		C.ThanhPhanLienThong(Bn);
		C.SapDoThi();

		for(int i=1; i<=C.label; i++) 
		{ 
			CSpanningTree tT;
			int tTreeSize =0;
			int tTotal =0;
			int temp =0;

			for(int j=0; j<(int)C.Nhan.size(); j++)
			{ 
				if(C.Nhan[j]==C.NhanDinh[i]) 
					temp = j;
			}

			PrimAlgEx(B,tT,tTreeSize,temp);

			for (int i =0; i< tTreeSize; i++)
				tTotal += tT.Tree[i].LayTrongSo();
					
			cout<<tTotal<<endl;
			if(tTotal==0)
				fVar<<"NULL"<<endl;
			else
			{
				fVar<<tTotal<<endl;
				for (int i =0; i< tTreeSize; i++)
							{
								cout<<"("<<tT.Tree[i].LayV()<<","<<tT.Tree[i].LayW()<<") ";
								fVar<<"("<<tT.Tree[i].LayV()<<","<<tT.Tree[i].LayW()<<") ";
							}
			}
			cout<<endl;
		}
	}
}	