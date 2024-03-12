import random


def lotto():
    numerot = []
    i = 6
    while i >= 0:
        numero = random.randint(1, 40)
        numerot.append(numero)
        i -= 1
    return numerot


print(", ".join(map(str, lotto())))  # viittaus 5. map funktion käyttö
