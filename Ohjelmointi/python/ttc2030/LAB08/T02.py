autot = []
while True:
    auto = input("Syötä rekisterinumero muodossa 'ABC-123': ")
    if auto == "":
        autot.sort()
        for tulosta in autot:
            print(tulosta)
        break
    else:
        autot.append(auto)


def kys():
    while True:
        auto = input("Syötä rekisterinumero muodossa 'ABC-123': ")
        if auto == "":
            autot.sort()
            for tulosta in autot:
                print(tulosta)
            break
        else:
            autot.append(auto)


print(kys())
