kaverit = []

i = 9
while i >= 0:
    nimi = input("Syötä kaverin nimi: ")
    kaverit.append(nimi)
    i = i - 1

print("Ensin kaverit järjestyksessä: ")
for nimi in kaverit:
    print(nimi)

print("Sitten käänteisessä järjestyksessä: ")
i = 9
while i >= 0:
    print(kaverit[i])
    i = i - 1
