def show_cm(a):
    tulos = a * 2.54
    asd = str(tulos)
    asdd = str(a)
    vastaus = asdd + " tuumaa on " + asd + " cm"
    return vastaus


print(show_cm(2))
print(show_cm(4.5))
print(show_cm(12))
