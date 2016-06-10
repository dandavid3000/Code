#include "StdAfx.h"
#include "Graph.h"

CGraph::CGraph(void)
{
}

CGraph::~CGraph(void)
{
}

//=============================== GET - SET ======================================

void CGraph::GanDoCaoNgapNuoc(int n)
{
	_doCaoNgapNuoc = n;
}

void CGraph::GanDoDaiNangCap(int n)
{
	_doDaiNangCap = n;
}

void CGraph::GanSoDinh(int n)
{
	_soDinh = n;
}

void CGraph::GanLabel(int n)
{
	_label = n;
}
int CGraph::LayDoCaoNgapNuoc()
{
	return _doCaoNgapNuoc;
}

int CGraph::LayDoDaiNangCap()
{
	return _doDaiNangCap;
}

int CGraph::LaySoDinh()
{
	return _soDinh;
}

int CGraph::LayLabel()
{
	return _label;
}



//=============================== GET - SET ======================================
//////////////////////////////////////////////////////////////////////////////////
//========================== NHAP XUAT RESIZE MA TRAN ============================

void CGraph::MatrixInit(int n)
{
	_matrix1st.resize(n);
	_matrix2nd.resize(n);

	for( int i=0; i<(int)_matrix1st.size();i++)
		_matrix1st[i].resize(n);

	for( int i=0; i<(int)_matrix2nd.size();i++)
		_matrix2nd[i].resize(n);
}

istream& operator>>(istream& inDevice, CGraph &C)
{
	int temp;
	inDevice>>C._soDinh;
	inDevice>>C._doCaoNgapNuoc;

	C.MatrixInit(C._soDinh);

	for(int i=0;i<(int)C._matrix1st.size();i++)
		for(int j=0;j<(int)C._matrix1st[i].size();j++)
		{
			C._matrix1st[i][j]=0;
			if(inDevice)
			{
				inDevice>>temp;
				C._matrix1st[i][j] = temp;
			}
		}

	for(int i=0;i<(int)C._matrix2nd.size();i++)
	{
		for(int j=0;j<(int)C._matrix2nd[i].size();j++)
		{
			C._matrix2nd[i][j]=0;
			if(inDevice)
			{
				inDevice>>temp;
				C._matrix2nd[i][j] = temp;
			}
		}
	}

	return inDevice;
}

ostream& operator<<(ostream& outDevice, CGraph &C)
{
	//cout<<C._soDinh<<" " <<C._doCaoNgapNuoc<<endl;
	for(int i=0; i<(int)C._matrix1st.size();i++)
	{
		for(int j=0; j<(int)C._matrix1st[i].size();j++)
			outDevice<<C._matrix1st[i][j]<<" ";
		outDevice<<endl;
	}

	outDevice<<endl;

	for(int i=0; i<(int)C._matrix2nd.size();i++)
	{
		for(int j=0; j<(int)C._matrix2nd[i].size();j++)
			outDevice<<C._matrix2nd[i][j]<<" ";
		outDevice<<endl;
	}

	return outDevice;
}




//========================== NHAP XUAT RESIZE MA TRAN ============================
//////////////////////////////////////////////////////////////////////////////////
//============================= HAM LIEN QUAN TPLT ===============================

void CGraph::SortGraph()
{
	_soPTLT.resize(_label+1);
	_nhanDinh.resize(_label+1);

	for (int i=1; i<=_label; i++)
	{
		int dem=0;
		for (int j=0; j< (int)_nhan.size(); j++)
			if (_nhan[j]==i)
				dem++;

		_soPTLT[i]= dem;
		_nhanDinh[i] = i;
	}

	for (int i=1; i<_label; i++)
		for (int j=i+1; j<=_label; j++)
			if (_soPTLT[i] > _soPTLT[j])
			{
				int temp1 =0;
				temp1 = _nhanDinh[i];
				_nhanDinh[i] = _nhanDinh[j];
				_nhanDinh[j] = temp1;

				int temp2 =0;
				temp2 = _soPTLT[i];
				_soPTLT[i] = _soPTLT[j];
				_soPTLT[j] = temp2;
			}
}

void CGraph::Visit(int n)
{
	_nhan[n] = _label;
	for(int i=0; i<(int)_nhan.size(); i++)
		if ((_matrix1st[n][i]!=0 || _matrix1st[i][n]!=0)&& _nhan[i] ==0)
			Visit(i);
}

void CGraph::ThanhPhanLienThong()
{
	_label=0; //Gan nhan label =0

	_nhan.resize(_matrix1st.size());


	for(int i=0; i<(int)_matrix1st.size(); i++)
		_nhan[i]=_label;
	for(int j=0;j< (int)_matrix1st.size();j++)
	{
		if(_nhan[j]==0)
		{
			_label=_label+1;
			Visit(j);
		}
	}
}

void CGraph::XuatTPLT(char *DuongDan, CGraph C2)
{

	//Xuat TPLT thu nhat chua ngap nuoc
	ofstream fVar(DuongDan); 
	fVar<<_label<<endl;
	cout<<_label<<endl;
	for(int i=1; i<=_label; i++) 
	{ 
		for(int j=0; j<(int)_nhan.size(); j++)
		{ 
			if(_nhan[j]==_nhanDinh[i]) 
			{ 
				fVar<<j<<" ";
				cout<<j<<" ";
			} 
		}
		fVar<<endl;
		cout<<endl;
	} 

	// Xuat TPLT sau khi bi ngap nuoc
	fVar<<C2._label<<endl;
	cout<<C2._label<<endl;
	for(int i=1; i<=C2._label; i++) 
	{ 
		for(int j=0; j<(int)C2._nhan.size(); j++)
		{ 
			if(C2._nhan[j]==C2._nhanDinh[i]) 
			{ 
				fVar<<j<<" ";
				cout<<j<<" ";
			} 
		}
		fVar<<endl;
		cout<<endl;
	} 

	//Xuat do dai ngap nuoc can nang cap
	cout<<_doDaiNangCap<<endl;
	fVar<<_doDaiNangCap<<endl;
}




//============================= HAM LIEN QUAN TPLT ===============================
//////////////////////////////////////////////////////////////////////////////////
//========================== HAM LIEN QUAN XU LY CANH ============================

void CGraph::HoanViCanh(int i, int j)
{
	CEDGE temp;

	temp.GanV(lstEdge[i].LayV());
	temp.GanW(lstEdge[i].LayW());
	temp.GanTrongSo(lstEdge[i].LayTrongSo());
	temp.GanDoCao(lstEdge[i].LayDoCao());

	lstEdge[i].GanV(lstEdge[j].LayV());
	lstEdge[i].GanW(lstEdge[j].LayW());
	lstEdge[i].GanTrongSo(lstEdge[j].LayTrongSo());
	lstEdge[i].GanDoCao(lstEdge[j].LayDoCao());

	lstEdge[j].GanV(temp.LayV());
	lstEdge[j].GanW(temp.LayW());
	lstEdge[j].GanTrongSo(temp.LayTrongSo());
	lstEdge[j].GanDoCao(temp.LayDoCao());
}
void CGraph::TapCanhKoNgapNuoc(CGraph C2)
{
	for( int i=0; i<(int)_matrix1st.size();i++)
		for(int j=i; j<(int)_matrix1st.size();j++)
			if(_matrix2nd[i][j]>=_doCaoNgapNuoc)
			{
				CEDGE canh;
				canh.GanV(i);
				canh.GanW(j);
				canh.GanTrongSo(_matrix1st[i][j]);
				canh.GanDoCao(C2._matrix2nd[i][j]);
				lstEdgeKoNgap.push_back(canh);
			}

}

void CGraph::TapCanhNgapNuoc(CGraph C2)
{
	for( int i=0; i<(int)C2._matrix2nd.size();i++)
		for(int j=i; j<(int)C2._matrix2nd.size();j++)
			if(C2._matrix2nd[i][j] < 0)
			{
				CEDGE canh;
				canh.GanV(i);
				canh.GanW(j);
				canh.GanTrongSo(_matrix1st[i][j]);
				canh.GanDoCao(C2._matrix2nd[i][j]);
				lstEdge.push_back(canh);
			}

}


//========================== HAM LIEN QUAN XU LY CANH ============================
//////////////////////////////////////////////////////////////////////////////////
//======================= HAM LIEN QUAN XU LY NGAP NUOC =========================

void CGraph::SortEdgeNgapNuoc()
{
	for(int i=0;i<(int)lstEdge.size();i++)
		for(int j=i;j<(int)lstEdge.size();j++)
		{
			if(lstEdge[i].LayTrongSo()>lstEdge[j].LayTrongSo())
				HoanViCanh(i,j);
			if(lstEdge[i].LayTrongSo()==lstEdge[j].LayTrongSo())
			{
				if(lstEdge[i].LayV()>lstEdge[j].LayV())
					HoanViCanh(i,j);
				if(lstEdge[i].LayV()==lstEdge[j].LayV())
					if(lstEdge[i].LayW()>lstEdge[j].LayW())
						HoanViCanh(i,j);
			}
		}
}
void CGraph::XuLyNgapNuoc()
{
	//Dau tien ta tru ngap nuoc vao do cao cua ma tran do cao
	for( int i=0; i<(int)_matrix2nd.size();i++)
		for(int j=0; j<(int)_matrix2nd[i].size();j++)
			if(_matrix2nd[i][j] != 0) // Neu do cao khac 0 ( tuc la co noi lien )
			{
				int temp = _matrix2nd[i][j];
				temp = temp -_doCaoNgapNuoc;

				_matrix2nd[i][j]=temp;
			}

	//Neu ma tran do cao co phan tu nao < 0 thi sua canh noi o ma tran 1 ve 0
	for( int i=0; i<(int)_matrix1st.size();i++)
		for(int j=0; j<(int)_matrix1st[i].size();j++)
			if(_matrix2nd[i][j]<0)
				_matrix1st[i][j]=0;
		
}


//========================== HAM LIEN QUAN XU LY CANH ============================
//////////////////////////////////////////////////////////////////////////////////
//========================== HAM TIM CHI PHI THAP NHAT============================

void CGraph::ChiPhiDoDaiThapNhat(CGraph C3, int op)
{
	for(int k=0; k<(int)lstEdge.size();k++)
	{
		lstEdgeKoNgap.push_back(lstEdge[k]);
		int v1,w1;
		v1=lstEdge[k].LayV();
		w1=lstEdge[k].LayW();

		C3._matrix1st[v1][w1] = _matrix1st[v1][w1];

		C3.ThanhPhanLienThong();
		_doDaiNangCap += lstEdge[k].LayTrongSo();
		if(C3._label>=op) // Neu so TPLT ko giam ta xu ly lai ma tran, xoa canh vua push vao, bo trong so cua canh vua push
		{
			C3._matrix1st[v1][w1] = 0;
			lstEdgeKoNgap.pop_back();
			_doDaiNangCap -=lstEdge[k].LayTrongSo();
		}

		op = C3._label;
		if(C3._label==_label)
			break;
	}
}


//========================== HAM TIM CHI PHI THAP NHAT============================