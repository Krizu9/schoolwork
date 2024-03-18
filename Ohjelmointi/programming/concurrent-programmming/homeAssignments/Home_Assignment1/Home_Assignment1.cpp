#include <iostream>
#include <thread>
#include <vector>
#include <mutex>

using namespace std;
std::mutex m;

void function(int threadId) {
    m.lock();
    for (int i = 0; i < 1000; ++i) {
        std::cout << "Thread: " << threadId << " loop: " << i << "\n";
    }
    m.unlock();
}

int main() {
    const auto processor_count = std::thread::hardware_concurrency();
    std::vector<std::thread> threads;

    for (int i = 0; i < processor_count; ++i) {
        threads.emplace_back(function, i);
    }

    for (auto& thread : threads) {
        thread.join();
    }
}