#include <iostream>
#include <string>
using namespace std;

class P_example
{
	int num;
public:
	void set_num(int val) { num = val; }
	void show_num();
};
void P_example::show_num()
{
	cout << num << " \n";
}
int main()
{
	P_example ob, *p; // объявление объекта и указателя на него
	ob.set_num(1); // прямой доступ к ob
	ob.show_num();
	р = &ob; // присвоение р адреса ob
	p->show_num(); // доступ к ob с помощью указателя
	return 0;
}