#include <iostream>
#include <future>

using namespace std;

void threadFunc(promise<int>& p)
{
    cout << "threadFunc...\n";

    int a = 10, b = 5;
    int result = a + b;
    this_thread::sleep_for(chrono::milliseconds(1000));

    p.set_value(result);
}

int main()
{
    promise<int> p;
    thread t1(threadFunc, ref(p));

    cout << "Thread started.\n";


    auto fut = p.get_future();
    
    while (true)
    {
        if (fut.wait_for(chrono::milliseconds(100)) != future_status::ready)
        {
            cout << "Doing Other stuff\n";
        }
        else
        {
            break;
        }
    }

    cout << "future::get " << fut.get() << "\n";
    cout << "future::get done.\n";

    cout << "all done.\n";

    t1.join();
}
