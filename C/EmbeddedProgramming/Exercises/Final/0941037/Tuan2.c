#include <lpc23xx.h>
#include <ctime>
//using namespace std;

void KhoiTaoMang(int a[])
{
	int i;
	for( i=0;i<20;i++)
		a[i]=0;
}


void BatDen(int n)
{
	int i;
//	PINSEL4 =0;
	FIO2DIR=0xFF;
	//FIO2MASK=0x00;
	FIO2SET=1<<n;
	for(i=0;i<500000;i++) ;
	
		//FIO2CLR=1<<n;
			//for(i=0;i<500000;i++) ;
		
	
}

void TatDen(int n)
{
	int i;
//	PINSEL4 =0;
	FIO2DIR=0xFF;
	//FIO2MASK=0x00;
	FIO2CLR=1<<n;
	for(i=0;i<500000;i++) ;
	
		FIO2CLR=1<<n;
			for(i=0;i<500000;i++) ;
		
	
}

int TinhToanCong(int x, int y)
{

	int kq;
	kq = x	+ y;
	return kq;
}

int TinhToanTru(int x, int y)
{

	int kq;
	kq = x	- y;
	return kq;
}

int TinhToanNhan(int x, int y)
{

	int kq;
	kq = x	* y;
	return kq;
}

int TinhToanChia(int x, int y)
{

	int kq;
	kq = x	/ y;
	return kq;
}


void Init()
{
	PINSEL0=0x40000000;
	PINSEL1=0x01;
	U1LCR=0x83;
	U1DLM=0;
	U1DLL=78;
	U1LCR=0x03;
	U1IER=1;


	
}

 void XuatTTSV()
{
	sendchar('0');
	sendchar('9');
	sendchar('4');
	sendchar('1');
	sendchar('0');
	sendchar('3');
	sendchar('7');
//	sendchar(0xFF);
}
int sendchar(int ch)
{
	while(!(U1LSR&0x20));
	return (U1THR=ch);
}
int  getkey(void)
{
	while(!(U1LSR&0x01));
	return (U1RBR);
}
__irq void XLINT0()
{
//	int t;
	int q;
	int i;
	
	EXTINT=1; // xoa co ngat
	//t=getkey();// co xoa co ngat
	 
	for(i=0;i<50000;i++) ;
	
	XuatTTSV();
	//BatDen(q-'0');
		
	VICVectAddr=0; // bao hieu xu ly xong ngat

}

	/*int ChuyenSoSangChuoi(int kq)
	{
		int i=0;
		int j;
		int temp=kq;
	
		 for(j=0;j<20;j++)
		 {
		 	chuoi[j]=temp%10;
			temp=temp/10;
			i++;
		 	
		 }
		 return i;
	}
	 */

int ars[256];	//mang chuoi nhap vao
int kk = 0;
int tk = 0;
__irq void XLUART2()
{
	int c = getkey();

	while(c!=0xFF)
	{
		ars[kk++]=c;
		c=getkey();
	
	}
	sendchar(ars[0]);
	for(tk = 1; tk < kk; tk++)
	sendchar(ars[tk]);
	sendchar(0xff);
	VICVectAddr =0;
	return;
	

/*	if(kk == 0)
	{
		tk = c;
	}
	else
	{
		if (c == 0xFF)
		{
			//if (t == k)					
			{
				sendchar(tk);
				for(kk = 0; kk < tk; kk++)
					sendchar(ars[kk]);
				sendchar(0xff);
				tk = kk = 0;
			}
		}
		else
		{
			ars[kk++] = c;
		}
	}

	VICVectAddr = 0;  */
}
__irq void XLUART()
{
	//int q;
	int ar[20];	//mang chuoi nhap vao
	int i = 0;
	int k;
	int n;				   //
	int x;				  //gia tri x
	int y;
	int tt;		// toan tu
	int kq;
	int bin[20];
	int l;
	int temp;
	int j;
	int temp2;
	int m;
	int chuoi[20];//mang doi kq sang chuoi
	while(k!=13)			 // neu chua enter
	{
		k =getkey();
		temp2=sendchar(k);		/// lay key tu ban phim luu vao mang
		ar[i]=k;		
		i++;
	}
	if((ar[4]=='O') && (ar[5]=='N')) // neu nhap la led on n 
	{
		  temp2=sendchar('L');
		  temp2=sendchar('E');
		  temp2=sendchar('D');
		  temp2=sendchar(' ');
          temp2=sendchar('O');
		  temp2=sendchar('N');
		  temp2=sendchar(' ');
		         
		  n = ar[7];
		  sendchar(n);
		  if(((n-'0')<0)||((n-'0')>7))			 // n tu 0 den 7
		  {
		  	temp2=sendchar('e');
			temp2=sendchar('r');
			temp2=sendchar('r');
			temp2=sendchar('o');
			temp2=sendchar('r');
			return;
		  }
		  BatDen(n-'0');
	}
	if((ar[4]=='O') && (ar[5]=='F') && (ar[6]=='F')) // neu nhap led off n
	{
		  sendchar('L');
		  sendchar('E');
		  sendchar('D');
		  sendchar(' ');
          sendchar('O');
		  sendchar('F');
		  sendchar('F');
		  sendchar(' ');
		  n = ar[8];
		  sendchar(n);
		  if((n-'0'<0)||(n-'0'>7))
		  {
		  	sendchar('e');
			sendchar('r');
			sendchar('r');
			sendchar('o');
			sendchar('r');
			return;
		  }
		  TatDen(n-'0');
	}
	if((ar[0]=='B') && (ar[1]=='I') && (ar[2]=='N')) // neu nhap la bin n
	{
		  n=0;
		  for(j=4;j<i-1;j++)
		  {
		  	temp2=ar[j]-'0';
		  	n=n*10+temp2;
			}
		  l=0;
		  temp = n;
		  temp2=sendchar('B');
		  temp2=sendchar('I');
		  temp2=sendchar('N');
		  temp2=sendchar(' ');
		   for(j=4;j<i-1;j++)
		  {
		  	temp2=ar[j]-'0';
		  	sendchar(temp2+'0');
			}
          temp2=sendchar('=');

		  while(temp!=0)
		  {
		  	bin[l]=temp%2;
			temp = temp/2;
			l++;

		  }
		  for(j=l;j>=0;j--)	 // xuat nguoc mang
		  {
		  	sendchar(bin[j]+'0');
		  }
	}
	
	if((ar[0]=='C') && (ar[1]=='A') && (ar[2]=='L') && (ar[3]=='C')) // neu nhap la calc x <o> y
	{
		  x = ar[5];
		  y = ar[7];
		  tt = ar[6];

		  sendchar(x);
		  sendchar(tt);
		  sendchar(y);
		  sendchar('=');

		    
		  if((tt=='+') || (tt=='-') || (tt=='*') || (tt=='/')) // neu la toan tu 
		  {
		  	if(tt=='+')
			  {
			  		i=0;
					kq = TinhToanCong(x-'0',y-'0');
					while(kq>0)
					 {
					 	chuoi[j]=kq%10;
						//sendchar(chuoi[j]+'0');
						kq=kq/10;
						i++;
					 	
					 }
					
					for(j=i-1;j>=0;j--)
					sendchar(chuoi[j]+'0');  
					//sendchar(kq+'0');
			  }
			  if(tt=='-')
			  {
					kq = TinhToanTru(x-'0',y-'0');
					sendchar(kq+'0');
			  }
			  if(tt=='*')
			  {
					kq = TinhToanNhan(x-'0',y-'0');
					sendchar(kq+'0');
			  }
			  if(tt=='/')
			  {
					kq = TinhToanChia(x-'0',y-'0');
					sendchar(kq+'0');
			  }
		  	
		  }
		  else
		  {
			  	sendchar('e');
				sendchar('r');
				sendchar('r');
				sendchar('o');
				sendchar('r');
				return;
		  }
		  TatDen(n-'0');
	}
	 
	//q=sendchar(getkey());
	//BatDen(q-'0');	
	VICVectAddr=0; // bao hieu xu ly xong ngat
	KhoiTaoMang(ar);
	KhoiTaoMang(bin);
	KhoiTaoMang(chuoi);

}

void InitRTC()
{

	RTC_CCR=0x00;//	Disable RTC;

	RTC_HOUR=0x00;
	RTC_MIN = 0x00;
	RTC_SEC=0x00;

	RTC_CCR = 0x1;// enable RTC
	RTC_PREINT=0x16D;// set Presscaler;
	
}
 void Reset()
 {
 	WDMOD = 0x03;
	WDTC = 0xFF;
	WDFEED=0xAA;
	WDFEED = 0x55;
 }

__irq void XLNgatTimer()
{
//	sendchar('1');
	char c[10],t;
	int k=0;
	int gio=0;
	int phut=0;
	int giay =5;

	//if(k==0xFF)
	//{
		//c=get
	//}
	sendchar(10);
	sprintf(c,"%2d:%2d:%2d\r\n",RTC_HOUR,RTC_MIN,RTC_SEC);
	//while(t!=0xFF)
	//{
//	c[k]=getkey(t);
	//k++;		
	//}
	for(t=0;t<10;t++)
	sendchar(c[t]);
	sendchar(0xFF);
	if((RTC_HOUR==gio)&&(RTC_MIN==phut)&&(RTC_SEC==giay))
		Reset();
	T0IR = 1;
	VICVectAddr = 0;
}
void CaiDatNgatTimer()
{
	T0MR0 = 11999000;  // 1 giay
	T0MCR = 3;
	T0TCR = 1;
	VICVectAddr4 = (unsigned long) XLNgatTimer;
	VICVectPriority4=1;
	VICIntEnable = 1<<4;
	 
}

void main()				  
{																						
//	int t;
//	int q;
	
	Init();	
	FIO2DIR=0xFF;
	FIO2CLR=0xFF;  // tat het tat ca den

	VICVectAddr7=(unsigned long) XLUART2;
	VICVectPriority7 = 7;
	VICIntEnable = (1 <<7);

	PINSEL4=0x01 <<20;
	VICVectAddr14=(unsigned long) XLINT0;
	VICVectPriority14 =14;
	VICIntEnable = (1 <<14);

	
	InitRTC();
//	CaiDatNgatTimer();
	//Datetime d=Datetime


	while(1); 	  
}

