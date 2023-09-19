from datetime import date

etunimi = input("Anna etunimesi: ")
syntymavuosi = int(input("Syntymävuotesi: "))

tamavuosi = date.today().year
ika = tamavuosi - syntymavuosi

print("Hei" , etunimi , "olet" , ika , "vuotta.")