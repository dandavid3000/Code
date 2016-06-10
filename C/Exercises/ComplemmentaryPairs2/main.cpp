

#include <iostream>
#include <algorithm>
#include <iostream>
#include <process.h>
#include <vector>
#include <map>

using namespace std;

int countPairs(const vector<int> A, int K)
{
	int count = 0;
	map<int,int> dict;
	
	for (int i = 0; i < A.size(); ++i)
		dict[A[i]] += 1;

	
	for (int i = 0; i < A.size(); ++i)
		count += dict[K - A[i]];

	return count;
}

int main()
{
	vector<int> arr={ 0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
	for (int i = 0; i < arr.size(); i++)
	{
		cout << arr[i] <<endl;
	}
	
	int k = 0;
	cout << "Count of pairs with given diff is "
		<< countPairs(arr,k) << endl;
	system("pause");
	return 0;
}