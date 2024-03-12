luku = input("Anna kokonaisluku: ")
tarkistus = int(luku)

if tarkistus == 10 or tarkistus == 20:
    print("Luku on 10 tai 20")

elif tarkistus == 100 or tarkistus == 200:
    print("Luku on 100 tai 200")
else:
    print("Luku on "+ luku)
