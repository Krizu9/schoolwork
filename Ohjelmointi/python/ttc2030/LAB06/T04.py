pistetaulukko = []
pisteet = 0
i = 4
y = 0
while i >= 0:
    pisteet = input("Hypyn pisteet: ")
    pistetaulukko.append(pisteet)
    i = i - 1

pistetaulukko.sort()
pistetaulukko.pop(0)
pistetaulukko.pop(3)

pistetaulukko_numeroina = [
    eval(i) for i in pistetaulukko
]  # viittaus 4. eval-funktion käyttö
for x in pistetaulukko_numeroina:
    y = y + x
print("Pisteet yhteensä :", y)
