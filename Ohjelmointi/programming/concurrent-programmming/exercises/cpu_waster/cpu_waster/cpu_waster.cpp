#include <iostream>
#include <thread>
#include <chrono>
#include <vector>

using namespace std;

void cpu_waster()
{
    cout << "cpu_waster prosess id: " << _getpid() << "\n";
    cout << "cpu_waster thread id: " << this_thread::get_id() << "\n";

    while (true)
    {
        //wasting loops
    }
}

int main()
{
    cout << "cpu_waster prosess id: " << _getpid() << "\n";
    cout << "cpu_waster thread id: " << this_thread::get_id() << "\n";

    vector<thread> threads;

    for (size_t i = 0; i < 10000; i++)
    {
        threads.push_back(thread(cpu_waster));
    }

    while (true)
    {
        this_thread::sleep_for(chrono::seconds(1));
        cout << ("Running...\n");
    }

}


