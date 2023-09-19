def get_cost(a,b,c):
    efficiency = a / 100
    fuelUsed = efficiency * b
    fuelCost = fuelUsed * c
    roundedCost = str("%.2f" % fuelCost)
    return roundedCost + " €"


print(get_cost(100,7.5,1.88))
print(get_cost(220,6.9,1.88))

#viittaus 1. stackoverflowsta opiskeltu tapa, jolla saa pyöristettyä viimeiset kaksi arvoa samalla, kun ei poisteta viimeistä nollaa.