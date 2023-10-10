import os

filename = "luvut.txt"
luvut = []
polku = os.path.expanduser("~/Desktop") + "/" + filename
annetutLuvut = 0

while True:
    luku = str(input("Anna luku: "))
    if luku == "":
        try:
            file = open(polku, "w")
            luvut_string = " ".join(luvut)
            file.write(luvut_string)
            print("Syötetty", annetutLuvut, "lukua.")
        finally:
            file.close()
            break

    else:
        luvut.append(luku)
        annetutLuvut = annetutLuvut + 1
