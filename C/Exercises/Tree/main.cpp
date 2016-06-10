#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <process.h>

using namespace std;

struct NODE {
	int Key;
	NODE *pLeft;
	NODE *pRight;
};

void Init(NODE *&TREE)
{
	TREE = NULL;
}

void Insert(NODE *&pRoot, int x)
{
	if (pRoot == NULL) //Neu cay rong
	{
		NODE *q;
		q = new NODE;
		q->Key = x;
		q->pLeft = q->pRight = NULL;
		pRoot = q;
	}
	else {
		if (x < pRoot->Key)
			Insert(pRoot->pLeft, x);
		else if (x > pRoot->Key)
			Insert(pRoot->pRight, x);
	}
}

void CreateTree(NODE *&pRoot)
{
	int Data;
	do {
		cout << "Nhap du lieu, -1 de ket thuc: ";
		cin >> Data;
		if (Data == -1)
			break;
		Insert(pRoot, Data);
		
	} while(1);
}

void PreOrder(NODE* pTree) // Giua trai phai
{
	if (pTree != NULL)
	{
		cout << pTree->Key << " ";
		PreOrder(pTree->pLeft);
		PreOrder(pTree->pRight);
	}
}

void InOrder(NODE *pTree)
{
	if (pTree != NULL)
	{
		InOrder(pTree->pLeft);
		cout << pTree->Key << " ";
		PreOrder(pTree->pRight);
	}
}

void PostOrder(NODE *pTree)
{
	if (pTree != NULL)
	{
		PostOrder(pTree->pLeft);
		PostOrder(pTree->pRight);
		cout << pTree->Key << " ";
	}
}


void main()
{
	NODE *pTree, *p;
	int x;

	Init(pTree);
	CreateTree(pTree);
	PreOrder(pTree);
	cout << endl;
	InOrder(pTree);
	cout << endl;
	PostOrder(pTree);
	system("pause");
}