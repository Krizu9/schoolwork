monesko = 0
yhteen = 0
nimet = []

while True:
    nimi = str(input("Anna oppilaan nimi: "))
    if nimi == "":
        print("Oppilaita:", monesko)
        nimet_string = ", ".join(nimet)  # viittaus 3. join-funktion käyttö
        print(nimet_string)
        break
    else:
        nimet.append(nimi)
        monesko = monesko + 1
