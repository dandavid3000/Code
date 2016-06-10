
#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <process.h>

using namespace std;

int solution(int A[], int N)
{
	if (N <= 0)
		return -1;
	int count = 0;
	int index = 0;

	while (index >= 0 && index < N)
	{
		int temp = A[index];
		if (temp == 0)
			return -1;
		
		A[index] = 0;
		index = index + temp;
		count++;
	}
	return count;
}

void main()
{
	int N = 5;
	int A[5] = { 2, 3, -1, 1, 3 };
	int B[4] = {1,1-1,1};
	int C[8] = {1,3,3,4,1,1,1,-4};
	int D[4] = {};
	cout << solution(D, 0)<<endl;
	system("pause");
}