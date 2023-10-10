saldo = 2000
lisataanEurot = float(input("How many euros will be added to the balance?: "))
lisataanSentit = float(input("How many cents will be added to the balance?: "))
saldo = saldo + lisataanEurot
saldo = saldo + (lisataanSentit / 100)
print("Bank account balance: ", saldo, "€")
