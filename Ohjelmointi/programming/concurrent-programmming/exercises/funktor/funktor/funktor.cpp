// funktor.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <thread>

using namespace std;

class MyData
{
public: 

    void operator()()
    {
        int count = 10;
        while (--count)
        {
            cout << "Thread executing on MyData object. number=" << ++number << "\n";
        }
    }

    int getNumber() const { return number; }

private:
    int number = 0;
};

int main()
{
    MyData data;
    thread t1(ref(data));
    t1.join();

    cout << "All done, data.number=" << data.getNumber() << "\n";

}
