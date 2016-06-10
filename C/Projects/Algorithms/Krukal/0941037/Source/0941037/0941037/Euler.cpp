#include "Euler.h"

CEuler::CEuler(void)
{
}

CEuler::~CEuler(void)
{
}

bool CEuler::KTChuTrinhEuler(CMatrix m)
{
	int tongBacDinh=0;
	int KT2DinhLe=0;

	for(int i=0; i<m.GetSize(); i++)
	{
		int temp =0;
		for(int j=0; j<m.GetSize(); j++)
		{
			if(m.array2D[i][j]==1)
				temp++;
		}

		intBacDinh.push_back(temp);
	}

	for(int i=0; i<(int)intBacDinh.size();i++)
	{
		tongBacDinh+=intBacDinh[i];
		if(intBacDinh[i]%2!=0)
			KT2DinhLe++;
	}

	if(tongBacDinh%2!=0 || KT2DinhLe>2)
		return false;

	return true;
}


void CEuler::InitListEdge(CMatrix m)
{
	int n = m.GetSize();
	CEDGE canh;
	for (int i=0; i<n; i++)
		for(int j=i; j<n; j++)
			if(m.array2D[i][j]!=0)
			{
				canh.GanV(i);
				canh.GanW(j);
				canh.GanTrongSo(m.array2D[i][j]);
				lstEdge.push_back(canh);
			}

}

void CEuler::HoanViCanh(int i, int j)
{
	
	CEDGE temp;

	temp.GanV(lstEdge[i].LayV());
	temp.GanW(lstEdge[i].LayW());
	temp.GanTrongSo(lstEdge[i].LayTrongSo());

	lstEdge[i].GanV(lstEdge[j].LayV());
	lstEdge[i].GanW(lstEdge[j].LayW());
	lstEdge[i].GanTrongSo(lstEdge[j].LayTrongSo());

	lstEdge[j].GanV(temp.LayV());
	lstEdge[j].GanW(temp.LayW());
	lstEdge[j].GanTrongSo(temp.LayTrongSo());
}
void CEuler::SortListEdge()
{
	int n = (int)lstEdge.size();

	for(int i=0; i<n; i++)
		for(int j=i; j<n; j++)
		{
			if(lstEdge[i].LayV()>lstEdge[j].LayV())
				HoanViCanh(i,j);
			if(lstEdge[i].LayV()==lstEdge[j].LayV())
				if(lstEdge[i].LayW()>lstEdge[j].LayW())
					HoanViCanh(i,j);
		}
}
void CEuler::FindTour(int n,CEDGE &temp, vector<int> &canhXet, vector<int> &DSDinh)
{
	int demCanhXuatPhat =0;

	for(int i=0; i<(int)lstEdge.size();i++)
		if(lstEdge[i].LayV()==n || lstEdge[i].LayW()==n && canhXet[i]==-1)
			demCanhXuatPhat++;


	for(int i=0; i<(int)lstEdge.size();i++)
		if(lstEdge[i].LayV()==n && canhXet[i]!=-1)
		{
			canhXet[i]=-1;
			temp.GanV(n);
			temp.GanW(lstEdge[i].LayW());
			FindTour(temp.LayW(),temp,canhXet,DSDinh);
		}

	if(demCanhXuatPhat==0)
		DSDinh.push_back(n);
}
void CEuler::ChuTrinhEuler(CMatrix m)
{
	InitListEdge(m);
	SortListEdge();

	/*for(int i=0; i<(int)lstEdge.size();i++)
		cout<<"("<<lstEdge[i].LayV()<<","<<lstEdge[i].LayW()<<")"<<" ";*/
	
	for(int i=0; i<m.GetSize();i++)
	{
		vector<int> canhXet;
		vector<int> DsDinhEuler;

		for(int k=0; k<(int)lstEdge.size();k++)
			canhXet.push_back(0);

		if (intBacDinh[i]!=0)
		{	
			int itemp =i;
			CEDGE temp;

			FindTour(i,temp,canhXet,DsDinhEuler);	


			
		}
		DsDinhEuler.push_back(i);
		XuatDSDinh(DsDinhEuler);
	}

}

void CEuler::XuatDSDinh(vector<int> DsDinh)
{
	for(int i=(int)DsDinh.size()-1; i>=0; i--)
		cout<<DsDinh[i];
	cout<<endl;
}