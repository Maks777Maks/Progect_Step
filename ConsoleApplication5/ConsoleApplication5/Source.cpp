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
	P_example ob, *p; // ���������� ������� � ��������� �� ����
	ob.set_num(1); // ������ ������ � ob
	ob.show_num();
	� = &ob; // ���������� � ������ ob
	p->show_num(); // ������ � ob � ������� ���������
	return 0;
}