etunimi = input("Anna etunimi: ")
sukunimi = input("Anna sukunimi: ")

ensimmainenKirjain = etunimi[0]
nimenpituus = len(etunimi)
print()

sukunimenPituus = len(sukunimi) 
sukunimivaarinpain = ''
x = sukunimenPituus 

while x > 0:
    sukunimivaarinpain = sukunimivaarinpain + sukunimi[x-1]
    x = x - 1
    

print(ensimmainenKirjain * nimenpituus, sukunimivaarinpain )