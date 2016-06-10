#include "EDGE.h"

CEDGE::CEDGE(void)
{
}

CEDGE::~CEDGE(void)
{
}

int CEDGE::LayV()
{
	return v;
}

int CEDGE::LayW()
{
	return w;
}

int CEDGE::LayTrongSo()
{
	return _trongSo;
}


void CEDGE::GanV(int n)
{
	v = n;
}

void CEDGE::GanW(int n)
{
	w = n;
}

void CEDGE::GanTrongSo(int n)
{
	_trongSo = n;
}