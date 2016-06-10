#include "StdAfx.h"
#include "Hamilton.h"

CHamilton::CHamilton(void)
{
}

CHamilton::~CHamilton(void)
{
}

void CHamilton::MatrixInit(int n)
{
	array2D.resize(n);
	for(int i=0; i<(int)array2D.size();i++)
		array2D[i].resize(n);
}

istream& operator >>(istream& inDevice, CHamilton &h)
{
	int n,temp;
	inDevice>>n;

	h.MatrixInit(n);
	for(int i=0; i<(int)h.array2D.size();i++)
		for(int j=0; j<(int)h.array2D[i].size(); j++)
		{
			h.array2D[i][j]=0;
			if(inDevice)
			{
				inDevice>>temp;
				h.array2D[i][j] = temp;

			}
		}

	return inDevice;

}

ostream& operator <<(ostream& outDevice, CHamilton &h)
{
	for(int i=0; i<(int)h.array2D.size();i++)
	{
		for(int j=0; j<(int)h.array2D.size(); j++)
			outDevice<<h.array2D[i][j]<<" ";
		outDevice<<endl;
	}

	return outDevice;
}
bool CHamilton::FindHamiltonPath(int nCount, int x /*Bat dau tu dinh x*/, vector<int> & path)
{
	if(nCount==(int)array2D.size()-KTSoLoBiDuc())//So dinh cua do thi
		return true;
	
	for(int i=0; i<(int)array2D.size(); i++)
	{
		if(array2D[x][i] != 0 && nhanDinh[i]==0)
			{
				path[nCount] = i;
				//Gan nhan dinh da di qua
			
				//array2D[x][i] = 0; 
				//array2D[i][x] = 0;
				nhanDinh[x] = 1;

				if(FindHamiltonPath(nCount+1,i,path))//Tim thay chu trinh
					return true;

				//Bo dinh ge tham
				//array2D[x][i] = 1;
				//array2D[i][x] = 1;
				nhanDinh[x] =0;
		
			}
	}

	return false;
}

int CHamilton::HamiltonPath(char * duongDan)
{
	ofstream fVar(duongDan);

	int dinhDucLo = KTSoLoBiDuc(); // So lo bi duc cua do thi
	int dinhKoDucLo = (int)array2D.size()-dinhDucLo; // So dinh ko bi duc lo

	//Gan nhan tat ca cac dinh chua ghe tham la 0
	for(int i =0; i<(int)array2D.size();i++)
		nhanDinh.push_back(0);

	vector<int> path;

	for(int j =0; j<dinhKoDucLo;j++)
		path.push_back(0);

	for(int i=0; i<(int)array2D.size(); i++) //Xet tat ca cac dinh cua do thi
	{
		//Da di qua dinh nay
		nhanDinh[i]=1;

		path[0] = i;
		
		if(FindHamiltonPath(1,i,path))
		{
			
			for(int k=0; k<(int)path.size(); k++)
			{
				cout<<path[k]<<" ";
				fVar<<path[k]<<" ";
			}
			
			return 1; //Tim dc dg di thi dung luon
		}

		nhanDinh[i]=0; // neu ko dc thi xem nhu chua di qua
	}

	//sau khi duyet het cac dinh ko tim dc thi null
	cout<<"NULL"<<endl;
	fVar<<"NULL"<<endl;
	return 0;
}
	
int CHamilton::KTSoLoBiDuc()
{
	int soLo=0;
	for(int i=0; i<(int)array2D.size(); i++)
	{
		int dem =0;
		for(int j=0; j<(int)array2D.size(); j++)
			if(array2D[i][j] != 0)
				dem ++;
		if(dem == 0)
			soLo++;
	}

	return soLo;
}
