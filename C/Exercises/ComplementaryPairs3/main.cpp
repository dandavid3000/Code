
#include <iostream>
#include <algorithm>
#include <process.h>

using namespace std;

void quickSort(int arr[], int left, int right) {
	int i = left, j = right;
	int tmp;
	int pivot = arr[(left + right) / 2];


	while (i <= j) {
		while (arr[i] < pivot)
			i++;
		while (arr[j] > pivot)
			j--;
		if (i <= j) {
			tmp = arr[i];
			arr[i] = arr[j];
			arr[j] = tmp;
			i++;
			j--;
		}
	};

	if (left < j)
		quickSort(arr, left, j);
	if (i < right)
		quickSort(arr, i, right);
}


int solution(int n, int arr[], int k)
{
	int count = 0;
	quickSort(arr, 0, n - 1);  // Sort array elements

	for (int i = 0; i < n; i++)
		cout << arr[i] << endl;

	int l = 0;
	int r = n-1;
	while (l<n && r>0)
	{
		int l_value = arr[l];
		int r_value = arr[r];
		int sum = l_value + r_value;

		if (sum < k)
			l++;
		if (sum > k)
			r--;
		if (sum == k)
		{
			count++;
			cout << "(" << arr[l] << "," << arr[r] << ")" << endl;
			if (arr[l] == arr[l + 1] && arr[r] == arr[r - 1] )
			{
				count=count+2;
				r--;
				l++;
			}
			else if (arr[l] == arr[l + 1])
				l++;
			else if (arr[r] == arr[r - 1])
				r--;
			else {
				r--;
				l++;
			}
		}
		

	}
	return count;
}

int main()
{
	int arr[] = { 1, 8, -3, 0, 1, 3, -2, 4, 5, 8,-2,-2,8};
	int n = sizeof(arr) / sizeof(arr[0]);
	int k = 6;
	cout << "Count of pairs with given diff is "
		<< solution(n, arr, k) << endl;
	system("pause");
	return 0;
}