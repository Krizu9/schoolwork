import os

nimet = ""
filename = "python.txt"
polku = (
    os.path.expanduser("~/Desktop") + "/" + filename
)  # viittaus 6. löytää työpöydän linuxissa ja windowsissa

try:
    file = open(polku, "r")
    for rivi in file:
        print(rivi)
        nimet = nimet + rivi

    nimetListana = nimet.split(" ")
    nimetListana.sort()

    print("\nAakkosjärjestyksessä: \n")
    for rivi in nimetListana:
        print(rivi)


finally:
    file.close()
