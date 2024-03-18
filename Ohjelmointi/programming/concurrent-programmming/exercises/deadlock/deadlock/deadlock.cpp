// deadlock.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <thread>
#include <mutex>
#include <vector>

using namespace std;

mutex ml;

void processData(vector<int>& data)
{
    if (ml.try_lock())
    {
        data.push_back(rand());
        if (data.size() > 500)
        {
            data.erase(data.begin());
        }
        ml.unlock();
    }
}

void threadFunc(vector<int>& data)
{
    while (1)
    {
        processData(data);
    }
}

int main()
{
    vector<int> data;
    thread t1(threadFunc, ref(data));

    while (1)
    {
        ml.lock();
        for (auto value : data)
        {
            cout << value << ",";
        }

        processData(data);
        ml.unlock();

        cout << "\n";
    }

    std::cout << "Hello World!\n";
}

