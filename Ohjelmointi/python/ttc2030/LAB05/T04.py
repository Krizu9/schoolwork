def get_fuel(a,b):
    efficiency = a / 100
    fuelUsed = efficiency * b
    fuelUsedRounded = str(round(fuelUsed, 1))
    answer = fuelUsedRounded + " ltr"
    return answer


print(get_fuel(100,7.5))
print(get_fuel(220,6.9))