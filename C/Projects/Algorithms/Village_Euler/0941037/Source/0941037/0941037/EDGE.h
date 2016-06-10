#pragma once

class CEDGE
{
private:

	int v;//Dinh thu nhat
	int w;//Dinh thu hai
	int _trongSo;
	int _doCao;

public:
	CEDGE(void);

	int LayV();
	int LayW();
	int LayTrongSo();
	int LayDoCao();

	void GanV(int );
	void GanW(int );
	void GanTrongSo(int );
	void GanDoCao(int );

public:
	~CEDGE(void);
};
