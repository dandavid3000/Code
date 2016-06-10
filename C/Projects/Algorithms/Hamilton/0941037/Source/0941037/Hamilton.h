#pragma once
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

class CHamilton
{
private:
	vector<vector<int>> array2D;//Ma tran
	vector<int> nhanDinh;//Bac dinh
	
public:
	CHamilton(void);
	void MatrixInit(int );
	friend istream& operator >> (istream& inDevice, CHamilton &h);
	friend ostream& operator << (ostream& outDevice, CHamilton &h);
	int HamiltonPath(char *);
	bool FindHamiltonPath(int, int, vector<int> &);
	int KTSoLoBiDuc();


public:
	~CHamilton(void);
};
