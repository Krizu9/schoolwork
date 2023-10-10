class Cat:
    name = ""
    color = ""

    def __str__(self):
        return "Nimi: " + self.name + ", väri: " + self.color

    def Mau(self):
        return "Meoooooow!"


Kit = Cat()
Kit.name = "Kit"
Kit.color = "black"

Kat = Cat()
Kat.name = "Kat"
Kat.color = "white"

print(Kit)
print(Kat)
print(Kit.Mau())
print(Kat.Mau())
