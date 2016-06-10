#include <iostream>
#include <stdio.h>
#include <conio.h>
#include <process.h>


using namespace std;


struct NODE {
	int key;
	NODE *pNext;
};

struct LIST {
	NODE *pHead;
	NODE *pTail;
};

NODE* CreateNode(int Data)
{
	NODE *pNode;
	pNode = new NODE;

	if (pNode == NULL)
		return NULL;
	pNode->key = Data;
	pNode->pNext = NULL;
	return pNode;
}

bool AddHead(LIST &L, int Data)
{
	NODE *pNode;
	pNode = CreateNode(Data);
	//cout << pNode->key;
	if (pNode == NULL)
		return false;
	//Xet xem phai la not dau tien hay khong
	if (L.pHead == NULL)
	{
		L.pHead = pNode;
		L.pTail = pNode;
	}
	//Neu khong phai la not dau tien
	else 
	{
		pNode->pNext = L.pHead;
		L.pHead=pNode;
	}

	return true;
}

void PrintList(LIST L)
{
	NODE *pNode;
	pNode = L.pHead;
	while (pNode != NULL)
	{
		cout << pNode->key <<" ";
		pNode = pNode->pNext; //Tro cho toi dich khi nao no la null tuc la het
		//Lam gi lam khong duoc mat pHead va pTail

	}

}

void PrintListInverse(LIST L)
{
	while (L.pHead != L.pTail)
	{
		NODE *pNode, *pPrev;

		pNode = L.pHead;
		pPrev = L.pHead;
		while (pNode != L.pTail)
		{
			pNode = pNode->pNext;
			//Lay gia tri truoc pNode luu vai pPrev
			while (pPrev->pNext!=pNode)
			{
				pPrev = pPrev->pNext;
			}
		}
		cout << pNode->key;
		L.pTail = pPrev;
	}
	cout << L.pHead->key;
}

void RemoveAll(LIST &L)
{
	NODE *pNode;
	

	while (L.pHead != NULL)
	{
		pNode = L.pHead;
		L.pHead=L.pHead->pNext;
		delete pNode;
	}
	L.pHead = NULL;
	L.pTail = NULL;
}

int main()
{
	LIST L;
	L.pHead = NULL;
	L.pTail = NULL;

	int Data;
	do
	{
		cout << "Nhap vao du lieu, -1 de ket thuc: ";
		cin >> Data;

		if (Data == -1)
			break;
		AddHead(L, Data);
	} while (Data != -1);

	//PrintList(L);
	//PrintListInverse(L);
	RemoveAll(L);

	system("pause");
	return 0;
}