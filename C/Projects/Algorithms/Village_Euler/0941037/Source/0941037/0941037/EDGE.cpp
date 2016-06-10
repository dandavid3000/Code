#include "StdAfx.h"
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

int CEDGE::LayDoCao()
{
	return _doCao;
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

void CEDGE::GanDoCao(int n)
{
	_doCao = n;
}