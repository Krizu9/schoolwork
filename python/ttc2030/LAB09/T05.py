import os
import random
import re


filename = "luvut.txt"
luvut = []
polku = os.path.expanduser("~/Desktop") + "/" + filename
annetutLuvut = 0

montako = int(input("Anna luku: "))
file = open(polku, "w")
while montako >= 1:
    luvut.clear()
    numero = random.sample(range(41), 7)  # viittaus 8. random ilman duplicateja
    numero.sort()
    luvut.append(numero)
    montako -= 1
    luvut_string = str(luvut)
    tulostus = re.sub(
        r"[\([{})\]]", "", luvut_string
    )  # viittaus 9. turhien merkkien poistaminen re-funktiota käyttäen
    file.write(tulostus)
    file.write("\n")


file.close()
