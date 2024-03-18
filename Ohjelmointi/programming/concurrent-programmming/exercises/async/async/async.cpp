#include <iostream>
#include <string>
#include <chrono>
#include <thread>
#include <future>

using namespace std;
using namespace std::chrono;

string fetchDataFromDB(string recvdData)
{
    this_thread::sleep_for(seconds(5));
    return "DB:" + recvdData;
}

string fetchDataFromFile(string recvdData)
{
    this_thread::sleep_for(seconds(5));
    return "FILE: " + recvdData;
}

int main()
{
    //get start time
    auto start = system_clock::now();
    cout << "Start fetching data...\n";

    //string dbdata = fetchDataFromDB("Data123");
    future<string> resultFromDB = async(launch::async, fetchDataFromDB, "Data123");
    string filedata = fetchDataFromFile("Data456");

    string data = resultFromDB.get() + " :: " + filedata;

    cout << "Data = " << data << "\n";

    //get duration
    auto end = system_clock::now();
    cout << "Total time = " << duration_cast<seconds>(end - start).count() << " seconds\n";
}

