filename = "C:/ayho.txt"

try:
    file = open(filename, "w")
    file.write("testi")
    file.close()
except:
    print("ei onnistu!")

# PermissionError: [Errno 13] Permission denied: 'C:/ayho.txt' antoi virheeksi.
