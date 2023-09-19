class human:
    name = ""
    age = ""

    def __str__(self):
        return "Nimi: " + self.name + ", ikä: " + str(self.age)


human1 = human()
human1.name = "Adam"
human1.age = "19"

human2 = human()
human2.name = "Eva"
human2.age = "18"

print(human1)
print(human2)
