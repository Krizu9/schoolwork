yhteensa = 0
for x in range(1, 6):
   numero = int(input(f'Anna {x}. luku: '))
   if numero > 0:
    yhteensa = yhteensa + numero
    
print("Lukujen summa on: " , yhteensa)
