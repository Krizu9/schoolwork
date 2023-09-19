ika = int(input("Kerro ikäsi: "))


def kerro3(a):
    if a < 13:
        print("child")
    if a > 12 and a < 20:
        print("teen")
    if a > 19 and a < 66:
        print("adult")
    if a > 65:
        print("senior")


kerro3(ika)
