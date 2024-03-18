#include <iostream>
#include <thread>
#include <mutex>
#include <condition_variable>

using namespace std;

mutex m;
condition_variable cv;
bool dataReady = false;

void producer() {

    this_thread::sleep_for(chrono::seconds(2));
    lock_guard<std::mutex> lock(m);
    dataReady = true;
    
    cv.notify_one();
}

void consumer() {
    {
        unique_lock<mutex> lock(m);
        cv.wait(lock, []
        {
            return dataReady;
        });
    }
    
    cout << "Data is ready!\n";
}

int main() {
    thread producerThread(producer);
    thread consumerThread(consumer);

    producerThread.join();
    consumerThread.join();
}
