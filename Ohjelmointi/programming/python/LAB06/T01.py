def showtime(a):
    tunnit = a // 3600
    minuutit = (a % 3600) / 60
    sekunnit = a % 60
     
    return "%02d:%02d:%02d" % (tunnit, minuutit, sekunnit)

print(showtime(500))
print(showtime(10000))
print(showtime(121000))