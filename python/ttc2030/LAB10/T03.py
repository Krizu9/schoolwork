tarkista = int(input("Insert year: "))


def tarkistavuosi(a):
    if (a % 400 == 0) or (a % 100 != 0) and (a % 4 == 0):
        print(a, "on karkausvuosi")
    else:
        print(a, "ei ole karkausvuosi")


tarkistavuosi(tarkista)
