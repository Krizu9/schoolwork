pistetaulukko = []
arvosanaMaara = 0
monesko = 0
i = 4
y = 0

while True:
    arvosana = input("Syötä arvosana väliltä 0-5: ")
    if arvosana == "":
        pistetaulukko_numeroina = [eval(i) for i in pistetaulukko]
        summa = sum(pistetaulukko_numeroina)
        keskiarvo = summa / monesko
        print("Syötit", monesko, "arvosanaa")
        print("Arvosanojen keskiarvo on: ", keskiarvo)
        break
    else:
        pistetaulukko.append(arvosana)
        monesko = monesko + 1
