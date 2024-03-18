#include <iostream>
#include <thread>
#include <mutex>
#include <chrono>
#include <random>

using namespace std;

mutex m;

class bankAccount {
private:
    int balance;

public:
    bankAccount(int initialBalance) : balance(initialBalance) {}

    void deposit(int amount) {
        m.lock();
        balance += amount;
        cout << "Deposited " << amount << " units. Current balance: " << balance << "\n";
        m.unlock();
    }

    void withdraw(int amount) {
        m.lock();
        if (balance >= amount) {
            balance -= amount;
            cout << "Withdrawn " << amount << " units. Current balance: " << balance << "\n";
        }
        else {
            cout << "Insufficient funds. Cannot withdraw." << "\n";
        }
        m.unlock();
    }

    void checkBalance() {
        m.lock();
        cout << "Current balance: " << balance << "\n";
        m.unlock();
    }

    int getBalance() {
        m.lock();
        int currentBalance = balance;
        m.unlock();
        return currentBalance;
    }
};

void performTransactions(bankAccount& from, bankAccount& to) {
    default_random_engine generator(chrono::system_clock::now().time_since_epoch().count());
    uniform_int_distribution<int> amountDist(1000, 2000);
    int times = 1;
    while (times < 5) {
        times += 1;
        int amount = amountDist(generator);
        if (from.getBalance() >= amount) {
            from.withdraw(amount);
            to.deposit(amount);
        }
        else {
            cout << "Insufficient funds.\n";
        }
        this_thread::sleep_for(chrono::milliseconds(500));
    }
}

int getTotalMoney(bankAccount& account1, bankAccount& account2, bankAccount& account3, bankAccount& account4) {
    return account1.getBalance() + account2.getBalance() + account3.getBalance() + account4.getBalance();
}

int main() {
    bankAccount account1(1750);
    bankAccount account2(1500);
    bankAccount account3(2000);
    bankAccount account4(1750);

    cout << "Total money in all accounts before transactions: " << getTotalMoney(account1, account2, account3, account4) << "\n";

    thread t1(performTransactions, ref(account1), ref(account2));
    thread t2(performTransactions, ref(account2), ref(account3));
    thread t3(performTransactions, ref(account3), ref(account4));
    thread t4(performTransactions, ref(account4), ref(account1));

    t1.join();
    t2.join();
    t3.join();
    t4.join();

    cout << "\nTotal money in all accounts after transactions: " << getTotalMoney(account1, account2, account3, account4) << "\n";

    return 0;
}
