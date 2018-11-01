#include<iostream>

using namespace std;

class T
{
	int a;
	static int b;
public:
	int Get()
	{
		return a;
	}
	static void Print()
	{
		cout << T::Get << b << endl;
	}
};
int main()
{
	T::Print();
	return 0;
}
