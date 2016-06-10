#pragma once
#include "EDGE.h"
#include <vector>
#include <iostream>
#include <fstream>

using namespace std;

class CSpanningTree
{
public:
	vector <CEDGE> Tree;
	void AddEdge(CEDGE );
	CSpanningTree(void);
public:
	~CSpanningTree(void);
};
