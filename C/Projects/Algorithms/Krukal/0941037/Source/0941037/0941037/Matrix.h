#pragma once

#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

typedef vector<char> charArray;
typedef vector<charArray> charArray2D;

class CMatrix
{
public:
	charArray2D array2D;
	CMatrix(void);
	void matrixInit(int);
	friend istream& operator >> (istream& , CMatrix &);
	friend ostream& operator << (ostream& , CMatrix &);

	int GetSize();
public:
	~CMatrix(void);
};
