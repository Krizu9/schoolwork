# ssh avaintunnuksen luominen
<br
>
Aloitamme ensin komennolla:

> ssh-keygen -t rsa

<img src="./src/dokumentaatio/screenshot1.png">

<br>

Olen kumminkin jo aikaisemmin luonut ssh-avaimen, joten en luo uutta.
<br>

<img src="./src/dokumentaatio/screenshot2.png">

<br>

<img src="./src/dokumentaatio/screenshot3.png">

Tiedosto löytyy polusta:

>c:/users/%username%/.ssh

-kansiosta.

tiedostossa *id_rsa.pub* on juuri luomasi julkinen avain

# ssh avaimen vieminen gitlabiin:

<br>

<img src="./src/dokumentaatio/screenshot4.png">

<br>

Käyttäjän asetuksien alapuolella on "ssh avaimet", kun syötät tiedoston sisällön avain kohtaan ja painat "lisää avain, avain lisätään käyttäjällesi.
<br>
<br>
Kun avaimen lisääminen onnistuu, se näkyy näin:
<img src="./src/dokumentaatio/screenshot5.png">

