#pragma once

class CEDGE
{
private:
	int v;//Dinh thu nhat
	int w;//Dinh thu hai
	int _trongSo;
public:
	CEDGE(void);
	int LayV();
	int LayW();
	int LayTrongSo();
	void GanV(int );
	void GanW(int );
	void GanTrongSo(int );

public:
	~CEDGE(void);
};
