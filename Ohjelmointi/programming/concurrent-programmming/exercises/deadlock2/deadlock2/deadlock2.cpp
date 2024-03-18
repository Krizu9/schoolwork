// deadlock2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <thread>
#include <mutex>

using namespace std;

void print()
{
    cout << "Critical data \n";
}

int main()
{
    mutex m1, m2;
    thread t1([&m1, &m2]
        {
            cout << "Aqcuiring first mutex... \n";
            m1.lock();
            print();

            cout << "Aqcuiring second mutex... \n";
            m2.lock();
            print();
            
            m1.unlock();
            m2.unlock();

        });

    thread t2([&m1, &m2]
        {
            cout << "Aqcuiring first mutex... \n";
            m2.lock();
            print();

            cout << "Aqcuiring second mutex... \n";
            m1.lock();
            print();

            m2.unlock();
            m1.unlock();

        });


    cout << "Hello World!\n";
}

