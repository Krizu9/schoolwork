luku = int(input("Montako lukua: "))
lista = []
for x in range(luku):
    a = int(x)
    b = a * 10
    lista.append(b)
   
for x in range(luku):
    print("luku:" , lista[x])