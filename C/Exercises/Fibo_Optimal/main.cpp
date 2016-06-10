#include <stdio.h>
#include <conio.h>
#include <iostream>

#include <process.h>

using namespace std;

//Multiply 2 matrices f0, and f1
void matrix_multiplication(unsigned long f0[2][2], unsigned long f1[2][2])
{
	//calculate matrix multiplication f0, and f1. Then we set back the new value to f0 as return value.
	
	unsigned long lefttop = f0[0][0] * f1[0][0] + f0[0][1] * f1[1][0];
	unsigned long leftbottom = f0[1][0] * f1[0][0] + f0[1][1] * f1[1][0];
	unsigned long righttop = f0[0][0] * f1[0][1] + f1[0][1] * f1[1][1];
	unsigned long rightbottom = f0[1][0] * f1[0][1] + f0[1][1] * f1[1][1];

	//Set the value to f0
	f0[0][0] = lefttop;
	f0[1][0] = leftbottom;
	f0[0][1] = righttop;
	f0[1][1] = rightbottom;

}

//A^3 = A*A^2 (matrix multiplication) - n = 3
void fibo_power(unsigned long f0[2][2], int n)
{
	
	if (n == 0 || n == 1)
		return;
	unsigned long f1[2][2] = { {1,1},{1,0} };

	fibo_power(f0, n / 2);
	matrix_multiplication(f0, f0);

	if (n % 2 != 0)
		matrix_multiplication(f0, f1);
}

//function to calculate the fibonacci
unsigned long fibonacci(int n)
{
	//Create the matrix (1,1,1,0);

	unsigned long f0[2][2] = { {1,1},{1,0} };
	//if n = 0 return 0
	if (n == 0)
		return 0;
	fibo_power(f0, n - 1);

	//Get the value leftop = f[0][0] because it is the value of Fn+1
	return f0[0][0];
}


void main()
{
	for (int i = 0; i < 50; i++)
		printf("%lu \n", fibonacci(i));

	system("pause");
}