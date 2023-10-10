def celToFah(a):
    vastaus =  (a * 9)/5 + 32
    return round(vastaus,1)

def fahToCel(a):
    vastaus = (a - 32) * 5 / 9
    return round(vastaus,1)

print(celToFah(10.0))
print(fahToCel(38.0))

#viittaus 2. round()-pyöristystapa w33schools.com