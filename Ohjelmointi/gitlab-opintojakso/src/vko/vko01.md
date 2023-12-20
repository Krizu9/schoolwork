[Takaisin alkuun](README.md)

# Yleisesti Git, Markdown, Gitlab, Github

:movie_camera: [Opetusvideona](https://youtu.be/Ugxc8qzVxT4) :movie_camera:

## Git ja versionhallinta

Versionhallinta projektissa on hankalaa. 

Eri projekteja kutsutaan "Git -kielellä" repositorioiksi (eng. repository). IT-alalla slangissa projekti/repositorio sanat menevät usein sekaisin.

Git -työkalu on muodostunut Linux Kernel -yhteisön tarpeesta saada hajautettu versionhallintajärjestelmä lähdekoodin seurantaan. Tämän jälkeen se on kehittynyt moneen muuhun asiaan, mutta pohja on vahvasti läsnä ohjelmoinnin lähdekoodin seurannassa.

Muutama suositeltava lähde motivaatioista Git:n luomiseen:
- [Linus Torvaldsin haastattelu Git:stä](https://www.youtube.com/watch?v=o8NPllzkFhE&feature=youtu.be&t=433)
- [Linus Torvaldsin puheenvuoro Git:stä](https://www.youtube.com/watch?v=4XpnKHJAok8)

## Markdown

Opintojaksolla tulemme käyttämään Markdown -kirjoitusformaattia.

Markdown on todella kätevä tiedostoformaatti, koska:

1. Kirjoittaminen on yksinkertaista
2. Se on eri Git -pohjaisten tuotteiden 'peruskäyttöliittymä' visuaalisia verkkosivuja muodostaessa

Tämä koko opintojakso on kirjoitettu Markdown -formaatissa.

## Gitxyz -kehitysympäristö

Kehitysympäristöt tuovat versionhallinnan ympärille omia ominaisuuksia. Esim. Issue Tracker ja Continuous Integration -ketjut (huom! Kummastakaan ei tarvitse tässä vaiheessa välittää).

Peruskäyttäjille parasta antia on selaimen lävitse käytettävä graafinen käyttöliittymä repositorion hallintaan. Teoriassa komentolinjalla ei välttämättä tarvitse edes käydä, jos ei välttämättä halua. Opintojaksolla kuitenkin käytämme komentolinjaa hieman, että ymmärrämme versionhallinnan teknisen toiminnallisuuden.

### Gitlab

Gitlab on avoimen lähdekoodin Git repositorioiden hallintaohjelmisto. Se sisältää paljon myös paljon muita käteviä ominaisuuksia. 

Tällä opintojaksolla Gitlab on käytössä, koska sen voi (halutessaan) asentaa ilmaiseksi omalle virtuaalikoneelle ja itse hallinnoida koko Git -ympäristöä. Tällöin opiskelija ymmärtää myös teknisemmin Git:n toimintaa.

### Github

Github on Gitlabia suositumpi (ja vanhempi) hallintaohjelmisto. Githubia voisi jo kutsua 'koodauksen sosiaaliseksi mediaksi', jossa voi seurata lempikoodaajiensa projekteja. Käytännössä siitä on myös näin muodostunut ohjelmistokehittäjien "CV".

Githubin käyttö onnistuu tämän opintojakson opeilla, mutta Github:sta ei voi asentaa omaa ympäristöä. Tämän vuoksi käytämme Gitlabia harjoitustehtävissä. Opiskelijan päätettäväksi jää kumpaa ympäristöä haluaa jatkossa käyttää (ohjelmointi) projekteissaan.

Yleisesti repositorioiden vienti järjestelmästä toiseen on saumatonta. Ongelmaksi jäävät ympäristöjen "omien mausteiden" yhteensopivuus.

# Versionhallinta

Versionhallinta seuraa muutoksia tiedostossa tai tiedostoissa tietyn ajan ylitse. Tämä aika voi olla esim. projektin kesto.

## Paikallinen versionhallintajärjestelmä

Yksinkertaisin versionhallintajärjestelmä jota peruskäyttäjät ylläpitävät on paikalliset tiedostot. 

![Local](src/pics/local.png "local")

Saatamme esimerkiksi nimetä tietokannaksi kansion **C:/Harjoitustyö/**. Tämän kansion sisällä on sitten tiedostot:

- harjoitustyov01.docx
- harjoitustyov02.docx
- harjoitustyov03.docx

Tämä on kohtalaisen yksinkertainen rakenne, mutta toimiva. Ihminen on vain valitettavasti hyvin epäsäännöllinen ja saattaa tehdä virheitä. Myös kyseisen kansion jakaminen on työlästä. Sähköposti voi olla yksi tapa lähetellä versioita edestakaisin. Lisäksi tiedostoon tehdyt muutokset riippuvat tiedostoformaatista ja sen tuesta useamman käyttäjän muutoksille.

Alla videolla työskentelen kahdella eri virtuaalikoneella: Windows 10 ja Ubuntu. Huomattavaa on, että muutokset toisen koneen paikallisessa levytilassa eivät näy toiselle tietokoneelle.

![paikallinen.webm](http://student.labranet.jamk.fi/~sahka/taustamateriaali/paikallinen.webm)

Tiedostot pitää siis siirtää USB:lla tai vastaavalla siirrettävällä medialla.

## Keskitetty versionhallintajärjestelmä

Seuraava askel keskitettyyn versionhallintajärjestelmään (Version Control System - VCS) on esimerkiksi verkkolevyt ja pilvipalvelut. Ryhmälle annetaan tietyt kirjoitusoikeudet verkkolevylle tai pilvipalvelun kansioon. Silti tiedostojen muutosten tekeminen, nimeäminen ja vastaavat ovat hyvin hankalia asioita. Todennäköisesti henkilöt tekevät poikkeamia. 

Lisäksi keskitetty tietokanta saattaa aiheuttaa ongelmia yhtäaikaisessa työskentelyssä. Lisäksi se on "Single Point of Failure". Kyseisen palvelun kaatuessa kukaan ei pysty työskennellä tiedostosisällöillä.

![Centralized](src/pics/centralized.png "Centralized")

Seuraavalla videolla käytän Labranet:n levypalvelua //ghost.labranet.jamk.fi/temp/verkkolevy -kansiota. Huomattavaa on, että molemmat tietokoneet näkevät saman levytilan (palvelimelta) ja muutokset levytilassa näkyvät molemmille. Ristiriitaisia tilanteita tulee, jos molemmat muokkaisivat samaa tiedostoa. 

![verkkolevy.webm](http://student.labranet.jamk.fi/~sahka/taustamateriaali/verkkolevy.webm)

Levyjakojen logiikka tiedostojen kirjoituslukituksen suhteen on tämän opintojakson ulkopuolella. 

## Hajautettu versionhallintajärjestelmä

Hajautettu versionhallintajärjestelmä pitää kaikilla käyttäjillä oman kopion, mutta sisältää yhden keskitetyn palvelimen mihin molempien olisi hyvä ladata omat tiedostot aika-ajoin. Tämä hajautus aiheuttaa muutamia askelia työskentelyyn, mutta **Git** tekee nämä askeleet hallitusti.

![Distributed](src/pics/distributed.png "Distributed")

Hankala asia on saada ihmisiä opettelemaan **Git** -työkalun hallitut toimenpiteet. Kun opiskelija ymmärtää **Git**:n tuomat hyödyt esim. ohjelmoinnin lähdekoodin hallinnassa, alkaa hän vaatimaan sitä myös monessa vastaavassa tekstin tuottamisen projektissa (lue: koulutehtävät).

Alapuolisella videolla näytän git:n perustoiminteita.

![git.webm](http://student.labranet.jamk.fi/~sahka/taustamateriaali/git.webm)

Huom! Videossa menee hieman enemmän aikaa repositorioiden luomiseen, mutta muutosten seurannan lisäys per tiedosto alkaa vähitellen korvaamaan pienen käytetyn ajan komentojen parissa. Lopulta komennot tulevat osaksi arkista työskentelyä.

Lähde: [Chacon, S. & Straub, B. 2014. Pro Git.](https://git-scm.com/book/en/v2/Getting-Started-About-Version-Control)

# Issues & Milestones

Opintojakso aloitetaan tutustumalla Issues ja Milestones -termeihin. Näitä hyväksikäyttäen luodaan opintojaksolle (projektille/repositoriolle) tavoitteet loppujaksoksi.

## Issues

Issue -termille on hankala sanoa suoraa vastinetta suomenkielelle. Sen käsite myös repositoriossa on häilyvä.

Issue on asia, ongelma tai tehtävä. Sillä voi ilmaista ongelmaa lähdekoodissa, tai ilmoittaa idea projektille. Samalla myös dokumentoida tekemättömiä tehtäviä.

Tällä opintojaksolla Issueita käytetään kuvastamaan tekemättömiä harjoitustöitä.

### Luodaan issue

Mennään repositorioon selaimen käyttöliittymästä https://gitlab.labranet.jamk.fi -> Kirjautuminen -> Your Projects -> gitlab-opintojakso -> Oikealta Issues

![image](src/vko/vko01/issues1.png)

Uuden issuen tekemisen valikko tulee näkyviin. 

![image](src/vko/vko01/issues2.png)

Tässä kenttä kentältä läpikäytynä issuen sisältö

- **Otsikko**, Kuvaileva ongelma/vika/virhe/tehtävä/... ytimekkäänä lauseena esim. "Opintojakson viimeistely"
- **Description**, Sisältää otsikon asian pitempänä kuvailuna esimerkiksi
   - "Palauta työtilasi lisäten @sahka / Karo Saharinen projektiisi jäseneksi. Muista täyttää opintojaksopalaute!"
- **Assignee**, Henkilö jonka kyseinen pitää tehdä... Tämä tulee repositorion/projektin jäsenistä, todennäköisesti siis sinun käyttäjätunnuksesi on ainoa joka voi tehtävän viimeistellä
- **Due Date**, Olisi ihanteellista, että tämä Issue saataisiin tehtyä tiettyyn aikamääreeseen mennessä... Aseta itsellesi tavoite vaikka haaveilemasi opintojakson loppu!
- **Milestone**, Projektille ei ole vielä tehty virstapylväitä, joten tämä kenttä on tyhjä tässä vaiheessa... täytetään myöhemmin
- **Labels**, Projektilla voi olla monenlaisia Issueita ja niitä saa vapaasti leimata (eng. Label)
   - Leimataan Issue termillä "tehtävä" (Create Label -> Name new label: tehtävä -> Valitse Väri -> Paina Create -> Valitse alasvetovalikosta Tehtävä uudelleen)
- **Weight**, Issuen 'painoarvo' (1-9) projektissa voi päättää onko 1. painon issuet vai 9. painon issuet "tärkeimpiä"

Kentät täytettyä voi issuen tallentaa/lähettää projektille (Submit Issue). Alapuolella kuvio täytetystä Issuesta.

![image](src/vko/vko01/issues3.png)

Ja valmis Issue submit -nappulan jälkeen

![image](src/vko/vko01/issues4.png)

Issueen voi kommentoida halutessaan lisätietoa. Oikealla voi myös lisämääreitä antaa Issue:lle esim. 
- **Lock Issue**, vain tietyt käyttäjät voivat käsitellä Issueta
- **Confidentiality**, rajoitetaan issuen näkyvyyttä tietyille käyttäjille
- **Time Tracking**, jos halutaan antaa arvioita issuen tekemiseen menevästä ajasta tai raportoida kauan aiheeseen meni
   - Arvio kestosta kirjoittamalla kommenttiin rivi esim. "/estimate 3d 10h 5m"
   - Raportointi kauan oikeasti meni esim. "/spend 1h"
   - Nämä arviot ovat käteviä Milestone -kohdassa

Oikeassa yläkulmassa näkyy käyttäjätilini kaikkien repositorioiden/projektien kaikki Issuet, jotka on sidottuna (Assignee) minun käyttäjätunnukselle.

![image](src/vko/vko01/issues5.png)

### Issueiden visualisointi

Issuet voidaan visualisoida listaksi `Issues -> List`

![image](src/vko/vko01/issues6.png)

Tai tauluiksi (eng. Boards) valitsemalla `Issues -> Boards`.

![image](src/vko/vko01/issues7.png)

Yksittäinen taulu muodostuu leimasta eli leimat voisivat olla esim.

- Toiminnallisuuden mukaan (esim [Kanban -mallilla](https://www.atlassian.com/agile/kanban))
   - **To-do**
   - **In progress**
   - **Code review**
   - **Done**

Tai

- Tekemisen laadun perusteella
   - **Lue**
   - **Harjoittele**
   - **Palauta**

Leimat / Labelit riippuvat projektin aiheesta. Alapuolella vielä esimerkki, johon on lisätty (oletukset) **To do** ja **Doing**

![image](src/vko/vko01/issues8.png)
   
## Milestone

Issuet voi kategorisoida eri virstapylväisiin/merkkipaaluihin (eng. Milestone). 

Tällä saadaan hajautettia suurempi projekti pienemmiksi ["sprinteiksi"](https://www.youtube.com/watch?v=OyCdNNsxELM) (kuten Agile -maailmassa todetaan). Sprinteillä voidaan hajauttaa ohjelmistoprojektin pienemmiksi versioiksi, jotka on helpompi toimittaa asiakkaalle.

Milestonet sisältävät yleensä useita Issueita, jotka muodostavat johdonmukaisen kokonaisuuden.

Tällä opintojaksolla Milestonet kattavat vaadittavia harjoitteita opintopisteitä vastaan.

1. Milestone 1
   - Issue 1 - Harjoitustehtävä 1
   - Issue 2 - Harjoitustehtävä 2
   - Issue 3 - Harjoitustehtävä 3
2. Milestone 2
   - Issue 4 - Harjoitustehtävä 4
   - Issue 5 - Harjoitustehtävä 5

Luodaan yksi Milestone vielä yläpuolisen esimerkin lisäksi eli opintojakson viimeistely, johon sidotaan esimerkkinä luotu Issue.

![image](src/vko/vko01/milestones1.png)

Tälläisellä virstapylväällä on yleensä aloituspäivä ja lopetuspäivä. Lisäksi virstapylvästä voi kuvailla. 

Itse asetan virstapylvään tavoitteeksi opintojakson sulkeminen, eli viimeisen viikon 2018 kevätlukukaudesta.

![image](src/vko/vko01/milestones2.png)

Luotu virstapylväs näyttää seuraavalta.

![image](src/vko/vko01/milestones3.png)

Nyt virstapylvääseen tulisi sitoa issueita, joten siirrytään aiemmin tehtyyn Issueen ja laitetaan sille Milestone.

Issues -> List -> Opintojakson viimeistely -> Milestone -> Edit -> ja alasvetovalikosta Opintojakson päättäminen

Issue päivittyy valinnan jälkeen seuraavan näköiseksi.

![image](src/vko/vko01/milestones4.png)

Issues -> Milestones -näkymästä saa graafin virstapylvään "valmiusasteesta". Valitettavasti se on 0%, koska 0/1 issueta on virstapylväästä suljettu :smile:

![image](src/vko/vko01/milestones5.png)

Vielä klikatessa meidän virstapylvästämme saamme koosteen tapahtumista.

![image](src/vko/vko01/milestones6.png)

Virstapylväät ovat siis projektinhallinnallisesti kokonaisuuksia, jotka voi pilkkoa pienemmiksi osakokonaisuuksiksi. 

Ensimmäinen harjoitustehtävä on siis: :tada: pilkkoa opintojakso Milestoneihin ja Issueihin :tada:

# [Tee Harjoitustehtävä 1](src/vko/vko01_harj.md)
