// race_condition.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <thread>
#include <mutex>


using namespace std;

class DataContainer
{
public:
    DataContainer() : number(0)
    {

    }
    void increment()
    {
        m.lock();
        ++number;
        m.unlock();
    }
    
    int number;

    mutex m;
};

void threadFunction(DataContainer& data)
{
    for (int i = 0; i < 10000; i++)
    {
        data.increment();
    }
}

int main()
{
    DataContainer data;
    thread t1(threadFunction, ref(data));
    thread t2(threadFunction, ref(data));

    t1.join();
    t2.join();
    cout << "Threads done, result= " << data.number << "\n";
}


