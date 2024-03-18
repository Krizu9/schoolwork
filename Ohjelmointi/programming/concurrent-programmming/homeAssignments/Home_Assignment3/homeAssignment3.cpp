#include <iostream>
#include <thread>
#include <vector>
#include <mutex>

using namespace std;

std::vector<int> numbers;
std::vector<int> deletedNumbers;
std::mutex m;
int num = 1;

void firstFunction() {
    while (num < 16) {
        m.lock();
        numbers.push_back(num);
        num += 1;
        for (int num : numbers) {
            cout << num << "\n";
        }
        m.unlock();
        this_thread::sleep_for(chrono::milliseconds(100));
    }
    cout << "deleted numbers:" << "\n";
    for (int num : deletedNumbers) {
        cout << num << " ";
    }
}

void secondFunction() {
    while (true) {
        m.lock();
        if (!numbers.empty()) {
            int deletedNum = numbers.front();
            deletedNumbers.push_back(deletedNum);
            numbers.erase(numbers.begin());
        }
        m.unlock();
        this_thread::sleep_for(chrono::milliseconds(50));
    }
}

int main() {
    thread t1(firstFunction);
    thread t2(secondFunction);
    t1.join();
    t2.join();
}
