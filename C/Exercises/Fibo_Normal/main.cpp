// you can use includes, for example:
// #include <algorithm>

// you can write to stdout for debugging purposes, e.g.
// cout << "this is a debug message" << endl;

#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <process.h>
#include <algorithm>
#include <vector>

using namespace std;

void Fibo(int n)
{
	int f0 = 0;
	int f1 = 1;
	int res = 0;
	
	if (n == 1)
		cout << f0;
	if (n == 2)
		cout << f1;
	for (int i = 3; i <= n; i++)
	{
		res =  f0 + f1;
		f0 = f1;
		f1 = res;
	}
	cout << res;
}



/*
void ConvertToBinary(int n)
{
	if (n / 2 != 0) {
		ConvertToBinary(n / 2);
	}
	printf("%d", n % 2);
}

*//*
vector<int> solution(vector<int> &A, int K) {


	vector<int> res;
	int n = A.size();

	int lastNo = A[n - 1];

	res.push_back(lastNo);

	int i;
	for (i = 0; i < n - 1; i++)
		res.push_back(A[i]);

	return res;




	int n = A.size();
	if (n == 0)
		return A;
	for (int j = 0; j < K; j++)
	{
		int lastNo = A[n - 1];
		int temp1 = A[0];
		int temp2;

		for (int i = 0; i < n - 1; i++)
		{
			temp2 = A[i + 1];
			A[i + 1] = temp1;
			temp1 = temp2;
		}

		A[0] = lastNo;
	}
	return A;
}
*/



void main()
{
	
	int n;
	cout << "Nhap n: ";
	cin >> n;

	/*
	vector<int> listNo;
	listNo.push_back(3);
	listNo.push_back(8);
	listNo.push_back(9);
	listNo.push_back(7);
	listNo.push_back(6);
	solution(listNo, 3);
	//ConvertToBinary(n);
	//Fibo(n);*/
	Fibo(n);
	system("pause");
}
