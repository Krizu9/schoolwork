import os

filename = "/python.txt"
nimet = []
polku = (
    os.path.expanduser("~/Desktop") + filename
)  # viittaus 6. löytää työpöydän linuxissa ja windowsissa

while True:
    nimi = str(input("Anna sukunimi: "))
    if nimi == "":
        try:
            file = open(polku, "w")
            nimet_string = " ".join(nimet)
            file.write(nimet_string)
        except:
            print("Failed to read file: " + filename)

        finally:
            file.close()
            break

    else:
        nimet.append(nimi)
