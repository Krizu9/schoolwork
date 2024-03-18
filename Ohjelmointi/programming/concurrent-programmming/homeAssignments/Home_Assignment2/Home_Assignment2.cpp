#include <iostream>
#include <thread>

using namespace std;

void setRandomNumbers(int* arr, int size) {
    for (int i = 0; i < size; ++i) {
        arr[i] = rand() % 100;
    }
}

int main()
{
    int size;
    cout << "How many numbers to allocate: ";
    cin >> size;

    int* numbers = new int[size];
    thread randomThread(setRandomNumbers, numbers, size);

    randomThread.join();

    cout << "Numbers generated: ";
    for (int i = 0; i < size; ++i) {
        cout << numbers[i] << " ";
    }
}
