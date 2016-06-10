#pragma once
#include "Matrix.h"
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

typedef vector<int> intArray;
typedef vector<char> charArray;

class CGraph
{
private:
	intArray Nhan; // 0=>size(), thu tu cung la cac dinh, mang dc gan nhan
	int label;
	intArray SoPTLienThong;
	intArray NhanDinh;

public:
	CGraph(void);
	void arrayInit(intArray &,int); // Doi kich co mang
	bool KTDoThiDon(CMatrix);
	void SapDoThi();
	void Visit(CMatrix, int);
	void ThanhPhanLienThong(CMatrix);
	void XuatThanhPhanLT(char *);
	bool IsAdjacentMatValid(CMatrix); //Kiem tra tinh hop le cua ma tran ke
public:
	~CGraph(void);
};
