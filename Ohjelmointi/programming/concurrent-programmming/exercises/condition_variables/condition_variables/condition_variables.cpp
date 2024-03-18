#include <iostream>
#include <thread>
#include <vector>
#include <condition_variable>
#include <functional> //std::bind

using namespace std;

//fiasco

class Application
{
public:
    Application() : m_dataLoaded(false)
    {
    }

    bool isDataLoaded() const { return m_dataLoaded; }

    void waitForLoadData()
    {
        //accuire the lock
        unique_lock<mutex> mlock(m_mutex);

        m_condVar.wait(mlock, std::bind(&Application::isDataLoaded, this));
    }

    void loadData()
    {
        // set the random seed from the time
        // Note, that srand is thread specific on Windows platform
        srand((unsigned int)time(0));

        // simulate work
        for (int i = 0; i <= 100; i += 10)
        {
            for (int j = 0; j < 50; ++j)
            {
                m_data.push_back((char)(rand() % 64 + 33));
            }
            this_thread::sleep_for(chrono::milliseconds(100));
            cout << "Loading Data " << i << "%\n";
        }

        m_dataLoaded = true;

        m_condVar.notify_one();
    }

    void connectToServer()
    {
        // simulate connecting
        cout << "Connect to server...\n";
        for (int i = 0; i <= 100; i += 25)
        {
            this_thread::sleep_for(chrono::milliseconds(100));
            cout << "Handshaking with server " << i << "%\n";
        }

        cout << "connectToServer complete\n";

        unique_lock<mutex> mlock(m_mutex);
        m_condVar.wait(mlock, std::bind(&Application::isDataLoaded, this));

        waitForLoadData();
    }

    void uploadData()
    {
        cout << "Start uploading data\n";

        // simulate work
        for (auto data : m_data)
        {
            cout << data << ",";
            this_thread::sleep_for(chrono::milliseconds(10));
        }
        cout << "\nUpload complete\n";
    }

private:
    mutex                   m_mutex;
    condition_variable      m_condVar;
    bool                    m_dataLoaded;

    vector<char>            m_data;
};


int main()
{
    Application app;
    thread t1(&Application::connectToServer, &app);
    thread t2(&Application::loadData, &app);

    t1.join();
    t2.join();
    app.uploadData();
}
