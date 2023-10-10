monesko = 0
yhteen = 0

while True: 
    numero = input("Anna luku: ")
    if numero == '':
        print("Lukuja annettu: ",monesko)
        print("Lukujen summa: ",yhteen)
        break
    else:
        laske = int(numero)
        monesko = monesko + 1
        yhteen = yhteen + laske
    