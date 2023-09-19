lista = [10, 20, 30, 40]
print("Listassa nyt:", lista)
mita = int(
    input(
        "Monettako listan elementtiä haluat muuttaa (ensimmäinen = 0, ja viimeinen 3)?: "
    )
)
arvo = int(input("Mikä vaihdetaan elementin arvoksi (numero)?: "))

try:
    lista[mita] = arvo
    print("Elementti", mita, "muutettiin arvoksi:", arvo)
    print("Lista nyt:", lista)
except:
    print("listassa on 4 elementtiä (0-3), eli elementtiä", mita, "ei ole.")


# Erroriksi tuli: IndexError: list assignment index out of range, nyt ohjelma ei kaadu,
# ja antaa asian mukaisen ilmoituksen.
