[Takaisin alkuun](README.md)

:movie_camera: [Opetusvideona](https://youtu.be/g38TjZ-7C-8) :movie_camera:

# Git SSH vai HTTPS?

## HTTPS

Git -versionhallinta lähtökohtaisesti perustuu HTTPS -suojattuun tiedonsiirtoon. Todennäköisesti toisen viikon harjoitustehtävässä naputtelit useita kertoja käyttäjätunnus & salasanaa työntäessäsi päivityksiä repositorioon.

Moni repositorio tarjoaa oletuksena HTTPS -tiedonsiirtoa esim.

`https://gitlab.com/softwa/very-hungry-penguins.git`

![image](src/vko/vko03/httpsvsssh1.png)

HTTPS on vallanmainio tapa siirtää repositorion dataa. Tarvittava tieto sinulla on:
- username (jotain mitä tiedät)
- password (jotain mitä tiedät)

Näillä peruskäyttäjä pääsee mainiosti liikkeelle.

## SSH

### Käyttöönotto

SSH on tietoturvallisempi tapa autentikoitua repositorioon. SSH:ssa autentikaatio perustuu:
- password (jotain mitä tiedät)
- ssh -avainpari (jotain mitä omistat)

Tässä tapauksessa ongelmana on, että käyttäjän pitää luoda omat SSH -avaimet.

Onneksi tämä onnistuu Git Bash -käyttöliittymästä komennolla **ssh-keygen -t rsa**.

```
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop
$ ssh-keygen -t rsa
Generating public/private rsa key pair.
Enter file in which to save the key (/c/Users/user/.ssh/id_rsa): <tyhjä enter>
Created directory '/c/Users/user/.ssh'.
Enter passphrase (empty for no passphrase): <salasana>
Enter same passphrase again: <salasana>

Your identification has been saved in /c/Users/user/.ssh/id_rsa.
Your public key has been saved in /c/Users/user/.ssh/id_rsa.pub.
The key fingerprint is:
SHA256:Yzmi6sXS2UKO6/pwrjmNaOk3/7x7UutZV0SLNY2kMug user@DESKTOP-9ONF5CP
The key's randomart image is:
+---[RSA 2048]----+
|             ..=.|
|         .   .= +|
|        . o .. o |
|       . . o  .  |
|    . . E      . |
|   * + o +    .  |
|oo= O . . .. .   |
|+B.B ... oo .    |
|*OO o..=*o       |
+----[SHA256]-----+
```

Nyt julkinen avaimeni löytyy tiedostosta `c/Users/user/.ssh/id_rsa.pub`

![image](src/vko/vko03/httpsvsssh2.png)

Kyseisen tiedoston sisällön voi avata Notepad -sovelluksella.

![image](src/vko/vko03/httpsvsssh3.png)

Kyseinen tekstipätkä on julkinen avaimesi yhdellä rivillä. Kyseinen rivi pitää kopioida kokonaisuudessaan ja syöttää Gitlab -palvelimelle.

Selaimessa valitse siis käyttäjäsi oikeasta yläkulmasta ja paina `Settings`

![image](src/vko/vko03/httpsvsssh4.png)

Tämän jälkeen valitse vasemmalta `SSH Keys` ja liitä id_rsa.pub -tiedoston sisältämä rivi **Key** -kenttään. Jos rivi on oikeassa formaatissa pitäisi **Title** -kentän täyttyä itsestään.

![image](src/vko/vko03/httpsvsssh5.png)

Voit halutessasi nimetä Title:n tarkemmaksi tai painaa **Add key**. Tämän jälkeen avautuu seuraava näkymä.

![image](src/vko/vko03/httpsvsssh6.png)

Nyt SSH -avainpari on sidottuna käyttäjätiliisi. Avainparisi salainen osio (salasana -avaimella AES -salattu) on sidottuna työasemaasi (esim. labranetin työasema tai kotikone). Edistyneemmät käyttäjät siirtävät yhtä avainta mukanansa tikulla ja käyttävät vain yhtä avainparia, mutta on mahdollista luoda useampia avainpareja eri sijainneissa käytettäväksi.

Hyökkääjän ongelma on päästä sekä tiedostoihisi (`id_rsa`, `id_rsa.pub`) ja salasanaasi käsiksi.

### Tiedonsiirtoprotokollan vaihto (HTTPS -> SSH)

Viimeisenä pitää vielä repositorion tiedonsiirtoprotokollaksi määrittää SSH.

Jos luot uuden projektin, niin gitlab asettaa oletuksena SSH:n päälle (jos siis tiliisi on sidottu SSH -avain).

![image](src/vko/vko03/httpsvsssh7.png)

Kloonaan nyt silti HTTPS:n ylitse repositorion itselleni ja vaihdan manuaalisesti komentolinjalta tiedonsiirtoprotokollaksi SSH:naputtelit

```
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop
$ git clone https://gitlab.labranet.jamk.fi/testaaja/testi.git
Cloning into 'testi'...
warning: You appear to have cloned an empty repository.

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop
$ cd testi

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git init
Reinitialized existing Git repository in C:/Users/user/Desktop/testi/.git/

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git add README.md

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git commit -m "README.md lisäys"
[master (root-commit) 81c3c00] README.md lisäys
 1 file changed, 3 insertions(+)
 create mode 100644 README.md

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git push
Counting objects: 3, done.
Writing objects: 100% (3/3), 234 bytes | 234.00 KiB/s, done.
Total 3 (delta 0), reused 0 (delta 0)
To https://gitlab.labranet.jamk.fi/testaaja/testi.git
 * [new branch]      master -> master
```

Tarkastetaan repositorion tiedonsiirtoprotokolla **git remote -v** -komennolla:

```
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git remote -v
origin  https://gitlab.labranet.jamk.fi/testaaja/testi.git (fetch)
origin  https://gitlab.labranet.jamk.fi/testaaja/testi.git (push)
```

Vaihdetaan SSH:lle, mutta otetaan URL ensin selainkäyttöliittymästä.

![image](src/vko/vko03/httpsvsssh8.png)

Ja vaihdetaan komentolinjalta **git remote** -komennolla url: `git@gitlab.labranet.jamk.fi:testaaja/testi.git` (**Huom!** Sinulla on siis eri url kuin HTTPS:ssä).

Kun olet saanut URL:n löydettyä. Jatkuu asia seuraavasti.

```
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git remote set-url origin git@gitlab.labranet.jamk.fi:testaaja/testi.git

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git remote -v
origin  git@gitlab.labranet.jamk.fi:testaaja/testi.git (fetch)
origin  git@gitlab.labranet.jamk.fi:testaaja/testi.git (push)
```

Tehdään muutos `README.md` -tiedostoon ja työnnetään päivitys SSH:n ylitse. Tehdään pieni muutos, jotta meillä on päivitettävää/pushattavaa repositorioon.

```
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git status
giOn branch master
Your branch is up to date with 'origin/master'.

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   README.md

no changes added to commit (use "git add" and/or "git commit -a")
t
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git add README.md

user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git commit -m "SSH käytössä"
[master f5a99b8] SSH käytössä
 1 file changed, 1 insertion(+), 1 deletion(-)
```

Huomioitavaa, että palvelimen julkinen SSH -avain pitää hyväksyä ensimmäisellä kerralla.

```
user@DESKTOP-9ONF5CP MINGW64 ~/Desktop/testi (master)
$ git push
The authenticity of host 'gitlab.labranet.jamk.fi (192.168.84.10)' can't be established.
ECDSA key fingerprint is SHA256:wRInSDBRTIPtzvR4bAZoQQ9UOiq3MUYFAVmeM9Z88h0.
Are you sure you want to continue connecting (yes/no)? yes
Warning: Permanently added 'gitlab.labranet.jamk.fi,192.168.84.10' (ECDSA) to the list of known hosts.
Enter passphrase for key '/c/Users/user/.ssh/id_rsa': <salasana>
Counting objects: 3, done.
Writing objects: 100% (3/3), 245 bytes | 245.00 KiB/s, done.
Total 3 (delta 0), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:testaaja/testi.git
   81c3c00..f5a99b8  master -> master
```

Nyt autentikaatiomenetelmäsi on turvallisempi! Tunnisteena on kryptografiset avaimet ja salasana jolla aukaiset kyseiset avaimet.

SSH avaimiin löytyy useita eri säilytysmekanismeja esim. [YubiKey](https://developers.yubico.com/). Tämä vahvistaa että lähdekoodia voi kehittää vain luotetut tahot (perustuen avaintenhallintaan) ja täten ohjelmiston kyberturvallisuutta on kehitetty tältä osalta.

# Diff -tiedot, Revisiohistoria, Statistiikka & Wiki

## Diff -tiedot komentolinjalta

Tarkastellaan kahta eri tiedostoa (`file1.txt` & `file2.txt`) kansiossa.

    sahka@SAHKA-PC MINGW64 ~/Desktop/git
    $ ls
    file1.txt  file2.txt

**tail** -komennolla tarkastellaan tiedostosisältö `file1.txt`
	
    sahka@SAHKA-PC MINGW64 ~/Desktop/git
    $ tail file1.txt
    Do you take the
    blue
    pill

**tail** -komennolla tarkastellaan tiedostosisältö `file2.txt`

    sahka@SAHKA-PC MINGW64 ~/Desktop/git
    $ tail file2.txt
    Do you take the
    red
    pill

Vertaillaan tiedostojen sisältöjä **git diff** -komennolla. 

*diff* analysoi kahta tiedostoa rivi riviltä ja visualisoi rivit, jotka eroavat. Komennolla näkee kätevästi erot tiedostojen välillä.
	
    sahka@SAHKA-PC MINGW64 ~/Desktop/git
    $ git diff --no-index file1.txt file2.txt
    diff --git a/file1.txt b/file2.txt
    index 4cbd5a8..0b8bfe0 100644
    --- a/file1.txt
    +++ b/file2.txt
    @@ -1,3 +1,3 @@
     Do you take the
    -blue
    +red
     pill
    \ No newline at end of file
	
Eroavaisuudet näkyvät **+** ja **-** merkkisinä riveinä. Yläpuolisen tulosteen 5. ja 6. rivi esittää mistä tiedostosta **-** merkkiset rivit ovat ja mistä **+** merkkiset rivit. Tiedostot siis eriävät toisistaan.

Eroavaisuuden lisäksi tiedostoista lasketaan [tiivistefunktio (hash algorithm)](https://en.wikipedia.org/wiki/Secure_Hash_Algorithms). Tiedon eheys ei ole git -opintojakson keskiössä, mutta kyseisellä algoritmillä voidaan tarkastaa tiedostosta lyhyt "tarkastussumma". Tätä tarkastussummaa voi käyttää esim. tiedostoversioita vertaillessa.

Tiedoston `file1.txt` tarkastussumma yläpuolisessa tulosteessa on **4cbd5a8**

Tiedoston `file2.txt` tarkastussumma yläpuolisessa tulosteessa on **0b8bfe0**

Git esittää lyhennetyn tarkastussumman, koska täyspitkämuoto tekee tulosteesta epäluettavan ja "harvoin" on tarpeellinen.

Alapuolisella komennolla näkee koko pitkän tarkastussumman. Huomattavaa on, että yläpuolisen ja alapuolisen tulosteen tarkastussummat ovat identtiset ensimmäiseltä 7 merkiltä.

    sahka@SAHKA-PC MINGW64 ~/Desktop/git
    $ git hash-object file1.txt
    4cbd5a83aef2d6174db57a91659cb5c2be4068dc
	
	sahka@SAHKA-PC MINGW64 ~/Desktop/git
	$ git hash-object file2.txt
	0b8bfe046a9f052b694243ec05a64303c42bba0c
	
Ymmärrettyämme nämä pohjalla toimivat perusteet voimme siirtyä Gitlab -ympäristön havainnointiin tiedoston kehityksestä.

## Diff -tiedot ja Gitlab -ympäristö

### Päivityksen luominen Gitlab -ympäristöön

Seuraavaksi otan file1.txt tiedoston ja siirrän sen gitlab -repositoriooni. Tarkastan tilanteen **git status** -komennolla.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)

        src/vko/vko03/file.txt

nothing added to commit but untracked files present (use "git add" to track)

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
```

Lisään sen projektiin ja kommentoin version.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add *

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   src/vko/vko03/file.txt


sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "file.txt lisäys repositorioon"
[master 5a83ba3] file.txt lisäys repositorioon
 1 file changed, 3 insertions(+)
 create mode 100644 src/vko/vko03/file.txt
```

Lopuksi työnnän päivityksen repositorioon.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 6, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (5/5), done.
Writing objects: 100% (6/6), 535 bytes | 535.00 KiB/s, done.
Total 6 (delta 3), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   ca19019..5a83ba3  master -> master
```

### Päivityksen tarkastelu ympäristössä

Selaimella aukaistessani repositorion näen henkilön profiilin kuvan ja **git commit** -viestin hänen tekemistä muutoksista. Lisäksi oikealla näkyy koko repositorion tarkastussumma **5a83ba3**. Tätä voi verrata aiempaan tulosteeseen **git push** -komennon yhteydessä.

![image](src/vko/vko03/diff1.png)

Lisäksi vasemmalta valikosta **Repository** ja sen alivalikko **Commits** näyttää kaikki eri commit:t projektin aikana. Alapuoleisessa kuviossa nähdään useita eri versioita, joita olen työstänyt repositoriossa ja niiden tarkastussummat oikealta.

![image](src/vko/vko03/diff2.png)

Yksittäistä committia voi klikata hiirellä ja tarkastella muunnokset projektin lähdetiedostoissa (lähdekoodissa).

![image](src/vko/vko03/diff3.png)

Tärkeä on nyt nähdä tässä vihreällä lisätyt rivit tiedostoon. 

Komentolinjalla file1.txt tarkoitti file.txt:n sisältöä ajanhetkellä 1.

Seuraavaksi muutamme file.txt:n sisältöä ajanhetkelle 2 (eli aiemmassa esimerkissä file2.txt). 

![image](src/vko/vko03/diff4.png)

Ja lisäämme repositorioon muutoksen

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   src/vko/vko03/file.txt

no changes added to commit (use "git add" and/or "git commit -a")

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add src/vko/vko03/file.txt

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "file.txt:hen muutos punaiseksi"
[master ba11918] file.txt:hen muutos punaiseksi
 1 file changed, 1 insertion(+), 1 deletion(-)
 
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 6, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (5/5), done.
Writing objects: 100% (6/6), 472 bytes | 472.00 KiB/s, done.
Total 6 (delta 4), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   5a83ba3..ba11918  master -> master
```

Tämän jälkeen voimme tarkastella **commit ba11918** tekemiä muutoksia.

![image](src/vko/vko03/diff5.png)

Poistamamme tiedot näkyvät punaisena ja lisäämämme vihreänä! Aivan kuten komentolinjalla työskennellessä.

Huomattavaa on myös, että yksittäisessä commit:ssa voi päivittyä useampi tiedosto. Kommentointi on mahdollista, jos haluaa esimerkiksi selittää syitä muutokseen tai joku muu kysyä miksi muutoksia on tehty.

## Revisiohistoria

Tämä "revisiohistoria" eri commit -tapahtumista on hyödyllinen useasta eri syystä.

- lähdekoodin auditointi
- bugien selvittäminen ja ongelmien korjaaminen
- ohjelmoijan työskentelyn tekeminen näkyväksi
- Projektin etenemisen seurattavuus
 
Otan esimerkkinä github -repositorion commit historian (esim 13.2.2018 projektissa 2100 eri commit tapahtumaa): https://github.com/hakimel/reveal.js/commits/master

![image](src/vko/vko03/diff6.png)

Git luo kyvyn tarkastella jokaista eri commit muutosta projektissa.

Voin myös tarkastella komentolinjalta muutoshistoriaa kloonaamalla repositorion itselleni (**git clone**) ja käyttämällä työkalua **git log**.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git
$ git clone https://github.com/hakimel/reveal.js.git
Cloning into 'reveal.js'...
remote: Counting objects: 10369, done.
remote: Compressing objects: 100% (3/3), done.
remote: Total 10369 (delta 1), reused 3 (delta 1), pack-reused 10364
Receiving objects: 100% (10369/10369), 7.75 MiB | 1.77 MiB/s, done.
Resolving deltas: 100% (5707/5707), done.

sahka@SAHKA-PC MINGW64 ~/Desktop/git
$ cd reveal.js/

sahka@SAHKA-PC MINGW64 ~/Desktop/git/reveal.js (master)
$ git log
commit 7991693bde3ee680868dfbfa1291d96735571c22 (HEAD -> master, origin/master, origin/HEAD)
Author: Benjamin Tan <demoneaux@gmail.com>
Date:   Wed Feb 7 12:51:14 2018 +0800

    Docs: add note on how to enable/disable preview links individually.

    Closes #2005.

commit 410f7767b9c96c330a1b62d35acbee666021e6ad
Author: Benjamin Tan <demoneaux@gmail.com>
Date:   Tue Feb 6 22:34:25 2018 +0800

    Docs: mention that syntax highlighting requires CSS theme file.

    Closes #2075.

commit 57a4c45cf69b11cb58304085b84ce3b095fb3077
Author: Benjamin Tan <demoneaux@gmail.com>
Date:   Tue Feb 6 22:12:35 2018 +0800

    Docs: avoid recommending global Grunt installation.
```

## Statistiikka / Aktiviteetti

Gitlab -ympäristö mahdollistaa työtilan statistiikan seurannan selaimen lävitse.

Käytän tässä kappaleessa esimerkkinä opiskelijoiden julkista repositoriota https://gitlab.labranet.jamk.fi/PRJTEAM-H/halinallet

Overview -> Activity

Alapuolisessa näkyy kaikki toiminnallisuus (kommentointi, issueiden tekeminen, commitit) repositoriossa.

![image](src/vko/vko03/activity1.png)

Työtilan eri työskentelijöiden commit määriä voidaan tarkastella Repository -> Contributors.

![image](src/vko/vko03/activity2.png)

Yksittäisen käyttäjän aktiviteettiä voi seurata https://gitlab.labranet.jamk.fi/username -polulla korvaten username esim. sahka tai muu käyttäjätunnus.

![image](src/vko/vko03/activity4.png)

## Wiki

Wiki on mielenkiintoinen lisäys repositorion sisältöön.

### Lähdekoodin seuranta

Wiki:lle on looginen syy lähdekoodin seurannan näkökulmasta repositoriossa. Lähdekoodi sisältää puhtaasti sovelluksen toiminnallisuuteen liittyvät tiedostot kuten esim.

>laskin.py

Wiki sitten sisältäisi selitykset miten laskin.py -tiedosto toimii ja miten sitä tulee käyttää. 

### Yleinen työskentely - repositoriossa vai wikissä?

Olen organisoinut tämän opintojakson siten, että "lähdekoodi" on markdown -tiedostoja, jotka on linkitetty toisiinsa ja kuvailevat opintojakson sisällön. Tästä nousee kysymys?

> Mitä sitten laittaisin Wikiin???

Tähän ei ole suoranaista vastausta. Ja vastaukset saattavat poiketa per henkilö. Täten myös eri repositorioissa Wikiä käytetään eri tavalla.

Opetellaan kuitenkin Wiki:n peruskäyttö.

Repositorion vasemmasta valikosta paina Wiki. Repositorio ei sisällä kotisivua, joten sivun pitäisi näkyä alapuolisena.

![image](src/vko/vko03/wiki1.png)

Luodaan wikisivu selain käyttöliittymän kautta eli lisää Content kenttään esimerkiksi:

```
# Wikin kotisivu

Tässä wikini
```

Ja paina **Create page** -näppäintä

Tämä luo Wikisivuston peruspolun eli esimerkiksi: https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso/wikis/home

Sivusto näkyy:

![image](src/vko/vko03/wiki2.png)

Teen muutaman sivun (Sivu1 ja Sivu2) ja seuraavassa kuvankaappauksessa näkyy oikealla automaattinen linkittäminen Wikisivuissa.

![image](src/vko/vko03/wiki3.png)

Oikealla kuvassa näkyy myös **Clone repository** -näppäin joka tarjoaa seuraavan polun 

> git@gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.wiki.git 

![image](src/vko/vko03/wiki4.png)

Eli repositorioni gitlab-opintojakso.git sisältää vielä erikseen oman repositorionsa Wiki -sivustolle gitlab-opintojakso.wiki.git

Tämä Wiki repositorio voidaan kloonata itselle paikalliseen taltiointiin.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git
$ git clone git@gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.wiki.git
Cloning into 'gitlab-opintojakso.wiki'...
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
remote: Counting objects: 9, done.
remote: Compressing objects: 100% (5/5), done.
remote: Total 9 (delta 1), reused 0 (delta 0)
Receiving objects: 100% (9/9), done.
Resolving deltas: 100% (1/1), done.

sahka@SAHKA-PC MINGW64 ~/Desktop/git
$ ls
file.txt  file2.txt  gitlab-opintojakso/  gitlab-opintojakso.wiki/
```

Nyt minulla on siis:

- gitlab-opintojakso/ -kansio, jossa on repositorion lähdekoodi
- gitlab-opintojakso.wiki/ -kansio, jossa on repositorion lähdekoodin wikisivusto

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git
$ cd gitlab-opintojakso.wiki

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso.wiki (master)
$ ls
home.md  sivu1.md  sivu2.md
```

Kyseisessä kansiossa on .md -tiedostoina aiemmin luodut Wiki-sivut. Wikisivuja voi nyt paikallisesti modifioida identtisesti lähdekoodin kanssa, mutta niiden version seurata on ikään kuin "repositorio repositorion sisällä".

Henkilökohtaisesti en oikein välitä tästä mallista, mutta jotkut pitävät. Itse suosisin repositorion lähdekoodin juureen tehtävän README.md -tiedosto, joka linkittää tämän jälkeen esim. doc -kansioon tai vastaavaan tarkempiin .md -tiedostoihin. 

Joissain tapauksissa tietenkin softakehittäjälle tulee vaatimus toimittaa erillinen dokumentaatio joka saattaisi olla johdonmukaista kehittää Wikiin. Tällöin lähdekoodi sijaitsee varsinaisessa repositoriossa ja wikissä sitten dokumentaatio.

Jokatapauksessa ymmärrän tälle olevan käyttötapauksensa ja siksi tämä myös Gitlab:sta löytyy.

# Tee harjoitustehtävä 3

Linkki harjoitustehtävään: [Harjoitustehtävä 3](src/vko/vko03_harj.md)

