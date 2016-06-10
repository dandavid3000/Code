#include <lpc23xx.h>
#include <string.h>
#include <stdlib.h>
int thoigian=0;
int GIAY=4;
//khai bao cac bien toan cuc 


int getkey(void)	  //Nhan du lieu
{
   while(!(U1LSR&0x01)); //cho biet thoi gian nay da co the nhan du lieu duoc chua?
   return (U1RBR); // tra ve du lieu nhan duoc
}
int sendchar(int ch)//gui du lieu
{
	while(!(U1LSR&0x20));	//	cho biet thoi gian nay da gui duoc du lieu duoc chua?
	return (U1THR=ch);	// tra ve du lieu se gui
}
void InitUART()
{
	FIO2DIR =0xFF;
	PINSEL0=0x40000000;// bat tinh nang TXD0 va RXTD	0
	PINSEL1=0x00000001;
//	PINSEL0 = 0x50;
	U1LCR=0x083;//8 bits , no parity,1 stop bit
	U1DLL=78;//9600 Baud rate & 12.0 MHZ 
	U1DLM=0; //high divisor lath=0
	U1LCR=0x03;// DLAB =0
//	U1IER = 1;
}

//Tuan 3
__irq void Interrup()	//dang ki su kien ngat
{
U1RBR;
   	//EXTINT=1;//xoa tat ca cac co ngat nam tren board
  	sendchar('a');
    VICVectAddr=0; //cho biet da xu li xong
} 

__irq void Interrup2()	//dang ki su kien ngat
{
	U1RBR;
  	sendchar(getkey());
    VICVectAddr=0; //cho biet da xu li xong
} 


/////Tuan4
void Send_String(char *str)
{
	unsigned int i;
	for(i=0;str[i]!=0;i++)
		sendchar(str[i]);//gui ki tu 
//	sendchar("\n");
	//free(str);
}
int NumberToChar(int number)//tra ve bang ma ascii
{										 
	int charNum;
	switch(number)
	{
		case 0:
			charNum=48;
			break;
		case 1:
			charNum=49;
			break;
		case 2:
			charNum=50;
			break;
		case 3:
			charNum=51;
			break;
		case 4:
			charNum=52;
			break;
		case 5:
			charNum=53;
			break;
		case 6:
			charNum=54;
			break;
		case 7:
			charNum=55;
			break;
		case 8:
			charNum=56;
			break;
		case 9:
			charNum=57;
			break;
	}
	return charNum;
}
int CharToNumber(char c)
{
	int number;
	switch(c)
	{
		   case '0':
				number=0;
				break;
			case '1':
				number = 1;
				break;
			case '2':
				number = 2;
				break;
			case '3':
				number = 3;
				break;
			case '4':
				number = 4;
				break;
			case '5':
				number = 5;
				break;
			case '6':
				number = 6;
				break;
			case '7':
				number = 7;
				break;
			case '8':
				number = 8;
				break;
			case '9':
				number = 9;
				break;
	}
	return number;
}
int StringToNumber(char str[],int n)  //chuyen 1 chuoi cac so thanh 1 so nguyen
{								//khi nhan 1 chuoi cac ki tu tu hyperterminal
	int number;
	int i;
	for(i=0;i<n;i++)
	{
		switch(str[i])
		{
			number*=10;//so sau = so truoc *10 +so sau
			number+=CharToNumber(str[i]);
		}
	}
	return number;
}
void NumberToString(char *str,int number)//chuyen 1 so thanh 1 chuoi cac ki tu de gui len hyperterminal
{
	 char str_temp[10];//chua cac ki tu sau khi chia cho 10
	 int number_temp,index_temp,index_str,i;//chua so chia
	// str_temp=(char*)calloc(10,sizeof(char));
	// str=(char*)calloc(10,sizeof(char));
	 index_temp=0;//kich thuoc cua chuoi str_temp 
	 index_str=0;//kich thuoc cua chuoi str
	 while (number>0)
	 {
		 number_temp=number%10;//chia lay du, lay so sau cung cua 1 so
		 switch(number_temp)
		 {
			case 0:
				str_temp[index_temp++] = '0';
				break;				
			case 1:
				str_temp[index_temp++] = '1';
				break;					
			case 2:
				str_temp[index_temp++] = '2';
				break;					
			case 3:
				str_temp[index_temp++] = '3';
				break;					
			case 4:
				str_temp[index_temp++] = '4';
				break;		
			case 5:
				str_temp[index_temp++] = '5';
				break;					
			case 6:
				str_temp[index_temp++] = '6';
				break;					
			case 7:
				str_temp[index_temp++] = '7';
				break;		
			case 8:
				str_temp[index_temp++] = '8';
				break;		
			case 9:
				str_temp[index_temp++] = '9';
				break;	
		 }
	 }
	 for(i=index_temp-1;i>=0;i--)//dao nguoc chuoi str_temp de lay ket qua
	 	str[index_str++]=str_temp[i];
	//free(str_temp);// giai phong cung nho str_temp
	 //return str;
}
__irq void MSSV()	//dang ki su kien ngat
{
	U1RBR;
   	EXTINT=1;//xoa tat ca cac co ngat nam tren board
  	Send_String("Lam Bao Vuong : 0942171");
    VICVectAddr=0; //cho biet da xu li xong
} 
 void Menu() //tao menu chuc nang
{
U1RBR;
Send_String("1. LED ON n \r\n");
Send_String("2. LED OFF \r\n");
Send_String("3. CALCULATE x+y \r\n");
Send_String("4. CALCULATE x-y \r\n");
Send_String("5. CALCULATE x*y \r\n");
Send_String("6. CALCULATE x-y \r\n");
Send_String("7. Convert To Binary \r\n");
Send_String("8. Thoat \r\n");
Send_String("Chon :");
VICVectAddr=0;
}
void NumberToBinary(char * str_temp,int number)
{
	  int result,count,i,n;
	  n=0;
	  while(number>0)
	  {
	  //	result=number%2;
		number/=2;
		n++;
	  }

	  for(i=0;i<n;i++)
	  {
	  	 result=number%2;
		 str_temp[i]=(char)result;
		 number/=2;
	  }
} 
void LED_ON(unsigned int n)	 //bat den thu n (0-7)
{
FIO2SET	=1<<n;
}
void LED_OFF(unsigned int n)//tat den thu n(0-7)
{
	FIO2CLR =1<<n;
}
unsigned int Cal_Plus(unsigned int x,unsigned int y)// thuc hien phep tinh cong
{
return x+y;
}
unsigned int Cal_Divison(unsigned int x,unsigned int y)// thuc hien phep tinh chia
{
return x/y;
}
unsigned int Cal_Multi(unsigned int x,unsigned int y)//thuc hien phep tinh nhan
{
return x*y;
}
int Cal_Subtracsion (unsigned int x,unsigned int y)// thuc hien phep tinh tru
{
	return x-y;
}
void WDTHandler()
{
	// reset
	WDMOD=0x03;
	WDTC=0XFF;
	WDFEED=0XAA;
	WDFEED=0X55;
}
//Tuan 5 Ngat Timer
__irq void XLNgatTimer0()
{
	char c[10], t;	
//	U1RBR;
	thoigian=thoigian+1;
	if(thoigian >= GIAY)	
		WDTHandler();		
	sprintf(c, "%2d:%2d:%2d\r\n", RTC_HOUR, RTC_MIN, RTC_SEC);//gan gio , phut - giay vao trong mang c
	for(t = 0; t < 10; t++)
		sendchar(c[t]);	
	T0IR=1;
	VICVectAddr=0;
}
void CaiDatNgatTimer()
{
	T0MR0=11999000;//12MHz->1 giay, (so -1 la bat buoc phai co)=>1 giay can la 12MHz-1  
	T0MCR=3;
	T0TCR=1;//tiep tuc cong them 1 giay
	VICVectAddr4=(unsigned long)XLNgatTimer0;
	VICVectPriority4=14;
	VICIntEnable=1<<4;
}
//Cai dat RTC
void InitRTC()
{
	 RTC_CCR=0x0000;//Enable RTC
	 RTC_PREINT=0x16D;//12000000/32768-1; (PCLK/3278)-1 365
	 RTC_PREFRAC=0x1B00;//0x61C0;//15000000-((RTC_PREINT+1)*32768); 
	 RTC_SEC=1;   //giay=0;
	 RTC_MIN=30;   //phut=30
	 RTC_HOUR=0; //gio =0	
     RTC_CCR=0x0001;	 //
}
int main()
{
 	InitUART();
	InitRTC();
	CaiDatNgatTimer();

	while(1);
} 