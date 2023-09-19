import os
import numpy as np
import pandas as pd

nimet = ""
puhtaatNimet = []
filename = "nimet.txt"
polku = os.path.expanduser("~/Desktop") + "/" + filename

try:
    file = open(polku, "r")
    for rivi in file:
        nimet = nimet + rivi

    puhtaatNimet = nimet.split("\n")
    tulostus = pd.value_counts(
        np.array(puhtaatNimet)
    )  # viittaus 6. Numpyn ja pandan käyttö
    print(tulostus.to_string())  # viittaus 7. tiedostotyypin poistaminen tulostuksesta


finally:
    file.close()
