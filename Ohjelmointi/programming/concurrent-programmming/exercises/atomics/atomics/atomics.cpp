#include <iostream>
#include <thread>
#include <chrono>
#include <atomic>

using namespace std;

class DataContainer {
public:
    DataContainer() : number(0)
    {

    }

    void increment() {
        
        ++number;
        
    }

    inline int getNumber() const { return number; }

private:
    atomic<int>         number;
};

void threadFunc(DataContainer& data, int count)
{
    for (int i = 0; i < count; ++i)
    {
        data.increment();
    }
    
}

int main()
{
    DataContainer data;
    constexpr int count = 10000000;

    //take start time
    const auto begin = chrono::steady_clock::now();

    thread t1(threadFunc, ref(data), count);
    thread t2(threadFunc, ref(data), count);
    t1.join();
    t2.join();

    //take the end time
    const auto end = chrono::steady_clock::now();

    cout << "threads done, result=" << data.getNumber() << "\n";

    cout << "Execution time: " << chrono::duration_cast<chrono::milliseconds>(end - begin).count() << "[ms]\n";
}
