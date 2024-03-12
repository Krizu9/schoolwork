[Takaisin alkuun](README.md)

:movie_camera: [Opetusvideona](https://panopto.jamk.fi/Panopto/Pages/Viewer.aspx?id=3bc8f62e-f73d-4541-8d42-ad8a00d3e085) :movie_camera:

**Huom!** Video uusittu/päivitetty 2021 (Youtube -> Panopto)

# Pandoc, binääritiedostot, .gitignore ja draw.io

## Pandoc ja etunimi_sukunimi_opiskelijanumero.md

[Pandoc (- a universal document converter)](https://pandoc.org/index.html) on mukava ohjelmisto kääntelemään tiedostoja formaatista toiseen. Saatat esimerkiksi kirjoittaa markdown malliin raportin, jonka haluat kääntää .docx tiedostoksi.

Pandoc on asennettu `student.labranet.jamk.fi` -palvelimelle, jossa teemme käännökset. Tämä vaatii: 

* Tiedostojensiirto
	* WinSCP -sovellus: [https://winscp.net/eng/download.php](https://winscp.net/eng/download.php)
* SSH komentolinjatyökalu
	* Putty -sovellus: [https://www.putty.org/](https://www.putty.org/)
	
Lataa ja asenna sovellukset. Suosittelen `portable` versioita sovelluksista eli pelkästään `putty.exe` and `winscp.exe`.

Käynnistä WinSCP ja kirjaannu kuten alapuolella ohjeistettu.

![image](src/vko/vko04/winscp1.png)

Mene repositoriosi kansioon (`~/git/gitlab-course`) WinSCP:llä ja siirrä tiedostot kuten ohjeistettu alapuolella.

![image](src/vko/vko04/winscp2.png)

Käytä `Putty`a kirjautuaksesi `student.labranet.jamk.fi` -palvelimelle.

![image](src/vko/vko04/putty1.png)

Komentolinjalla kirjaudu sinun LabraNet tunnuksilla ja käytä pandoc sovellusta palvelimella. Esimerkki alapuolisessa kuvassa. 

![image](src/vko/vko04/putty2.png)

Lopuksi siirrä tiedostosi takaisin omalle tietokoneellesi. 

![image](src/vko/vko04/winscp3.png)

Lisää ne repositorioon. 

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)

        README.docx
        README.pdf

nothing added to commit but untracked files present (use "git add" to track)

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add *

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "binaaritiedostoja incoming"
[master 1f196fd] binaaritiedostoja incoming
 3 files changed, 134 insertions(+)
 create mode 100644 README.docx
 create mode 100644 README.pdf

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 5, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (5/5), done.
Writing objects: 100% (5/5), 118.65 KiB | 14.83 MiB/s, done.
Total 5 (delta 0), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   a6b0f52..1f196fd  master -> master
```

Voit avata .docx -tiedoston wordiin ja .pdf tiedoston readeriin. Kaikkien pitäisi toimia.

## Binääritiedosto

Commit sisällöstä näkee, että gitlab ei osaa esittää .docx -dokumenttia vaan tekstisisällön kohdalla lukee "File added".

![image](src/vko/vko04/binary1.png)

Ongelma tiedostossa on, että sen sisältö on binäärisessä muodossa eikä esim. ASCII tai UTF-8 -muodossa. Tämä tarkoittaa, että esim. **tail** -komento näyttää kohtalaisen erikoiselta .docx -tiedoston kohdalla.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ tail README.docx
▒▒▒▒ښp|Ā92▒\▒k|▒
                r▒▒w▒▒I▒▒▒hj,=▒▒▒▒j▒7▒▒▒
                                        ▒▒▒▒▒R)▒▒b▒▒▒n▒k9▒s2▒▒{PnJ▒▒▒e?▒▒5I3▒▒▒▒u▒}▒Qe▒▒▒▒TS8N!!
                ▒▒YJ▒▒▒&n▒ԍX▒P▒▒▒▒▒▒z#j▒▒X▒▒▒▒▒t▒t`▒▒@7▒Upm▒g0A▒▒▒▒f▒▒z▒_I▒▒v▒▒Ъ▒6▒NS▒=٥▒}▒▒ϵ▒▒▒▒Ы▒▒A;▒▒'&f▒x▒ט▒X$▒.ʃ▒▒j▒U▒h▒N▒▒▒h▒▒ڑ@▒▒▒h▒.▒V▒?▒S▒&▒▒▒t▒q▒▒?▒MqE▒Zj▒R▒/K▒▒*▒▒9▒F▒▒1▒▒
```

Tämä binäärimuoto rikkoo versionhallintaa git:ssä. Git on tarkoitettu tekstimuotoisen tiedostoformaatin versionhallintaan (lue: lähdekoodin). Git pystyy toimimaan binäärimuotoisen tiedon kanssa, mutta käyttäjän pitää tiedostaa mitä rajoitteita versionhallinta niille asettaa ja olla varovainen.

Avaamalla README.docx ja lisäämällä tekstiä nähdään että git joutuu työskentelemään .docx -tiedoston kanssa hieman erillailla (rewrite).

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   README.docx
		
no changes added to commit (use "git add" and/or "git commit -a")

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add *

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "binäärimuutoksia"
[master dc490d9] binäärimuutoksia
 3 files changed, 24 insertions(+), 1 deletion(-)
 rewrite README.docx (98%)
 create mode 100644 src/vko/vko04/binary1.png
 
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 8, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (7/7), done.
Writing objects: 100% (8/8), 81.56 KiB | 10.19 MiB/s, done.
Total 8 (delta 4), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   626ff1a..dc490d9  master -> master
```

Binäärinen tiedosto toimii vielä repositoriosta, mutta versionhallintaan ei ole enää mitään taetta. Satunnaisesti myös binäärisissä tiedostoissa on havaittu epävakautta. Käyttöön kohdistuu siis hieman riskiä.

## .gitignore

.gitignore` -tiedoston voi lisätä repositorioon, jos haluaa 100% varmasti poistaa tietyt tiedostotyypit repositorion seurannasta.

Github:lla on [esimerkki .gitignore:sta](https://gist.github.com/octocat/9257657), jossa selitetään miksei joitain tiedostoformaatteja haluta seurata. Sama tulosteena tähän.

```
# Compiled source #
###################
*.com
*.class
*.dll
*.exe
*.o
*.so

# Packages #
############
# it's better to unpack these files and commit the raw source
# git has its own built in compression methods
*.7z
*.dmg
*.gz
*.iso
*.jar
*.rar
*.tar
*.zip

# Logs and databases #
######################
*.log
*.sql
*.sqlite

# OS generated files #
######################
.DS_Store
.DS_Store?
._*
.Spotlight-V100
.Trashes
ehthumbs.db
Thumbs.db
```

Meidän tapauksessamme haluamme ehkä tästä repositoriosta poistaa .docx ja .pdf -tiedostot. Luodaan `.gitignore` -tiedosto repositorion juureen.

![image](src/vko/vko04/gitignore.png)

`.gitignore` -tiedostossa on pieniä kikkoja Windows -käyttöjärjestelmällä. Ohje [Stack Overflow:sta](https://stackoverflow.com/questions/10744305/how-to-create-gitignore-file):

```
If you're using Windows it will not let you create a file without a filename in Windows Explorer. It will give you the error "You must type a file name" if you try to rename a text file as .gitignore

To get around this I used the following steps

    Create the text file gitignore.txt
    Open it in a text editor and add your rules, then save and close
    Hold SHIFT, right click the folder you're in, then select Open command window here
    Then rename the file in the command line, with ren gitignore.txt .gitignore

You can get around this Windows Explorer error by appending a dot to the filename without extension: .gitignore. will be automatically changed to .gitignore
```

Tämän jälkeen voi lisätä .gitignore -tiedoston repositorioon.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add .gitignore

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   .gitignore


sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m ".gitignore"
[master 51afcd3] .gitignore
 1 file changed, 3 insertions(+)
 create mode 100644 .gitignore

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 3, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 301 bytes | 301.00 KiB/s, done.
Total 3 (delta 1), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   6560f6e..51afcd3  master -> master
```

Nyt kun .gitignore -tiedosto on lisätty. Voidaan poistaa `README.docx` -tiedosto git:n seurannasta.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git rm README.docx
rm 'README.docx'
```

Poistaminen on myös versiohistorian vaihe. Tämä poisto pitää ilmoittaa keskitettyyn versionhallintaan.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        deleted:    README.docx


sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "deleted README.docx"
[master ba74a0a] deleted README.docx
 1 file changed, 0 insertions(+), 0 deletions(-)
 delete mode 100644 README.docx

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 2, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (2/2), 236 bytes | 236.00 KiB/s, done.
Total 2 (delta 1), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   8251993..ba74a0a  master -> master
   
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

nothing to commit, working tree clean

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status

The following paths are ignored by one of your .gitignore files:
lueminut.docx
Use -f if you really want to add them.
```

Tämän jälkeen voimme lisätä `.docx` -tiedoston repositorioon ja huomata, että se ei tule seurantaan.

![image](src/vko/vko04/gitignore2.png)

## Kuviot

https://draw.io on mukava avoimen lähdekoodin työkalu piirtämiseen. Pääkohde korvaamiselle on esim. [Microsoft Visio]. Etuna git -maailmaan on, että piirretyt kuviot tallentuvat .drawio -tiedostona (xml), eli tekstimuotoisena.

Sivustolle mentäessä valitaan, että tallennetaan paikalliselle koneelle.

![image](src/vko/vko04/drawio.png)

Tämän jälkeen avataan uusi diagrammi. Myöhemmin voi avata tallentamansa tiedoston levyltä.

![image](src/vko/vko04/drawio2.png)

Piirsin alapuolisen kuvion ja käydään lävitse tallennukset. 

![image](src/vko/vko04/drawio3.png)

- File -> Save as... -> Filename: piirros.drawio -> Download
   1. Avaa selaimen tallennusikkunan, jonka voit sitten sisällyttää esim. repositoriosi juureen.
   2. tallentaa `.drawio` -formaatissa
- File -> Export as -> PNG -> Export -> Filename: piirros.png -> Download
   1. Avaa selaimen tallennusikkunan, jonka voit sitten sisällyttää esim. repositoriosi juureen.
   2. tallentaa `.png` -formaatissa
   
Tämän jälkeen kuvio ja sen png on lisättävissä repositorioon

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)

        piirros.png
        piirros.drawio

no changes added to commit (use "git add" and/or "git commit -a")

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add *
The following paths are ignored by one of your .gitignore files:
lueminut.docx
Use -f if you really want to add them.

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "piirros lisäys"
[master 0347635] piirros lisäys
 4 files changed, 9 insertions(+), 1 deletion(-)
 create mode 100644 piirros.png
 create mode 100644 piirros.drawio

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 8, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (8/8), done.
Writing objects: 100% (8/8), 5.35 KiB | 5.35 MiB/s, done.
Total 8 (delta 4), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   d188dff..0347635  master -> master
```

Nyt repositoriossa on versionhallinnassa
- piirros.drawio
- piirros.png

Drawio (xml) on tekstimuotoinen, mutta png on binäärimuotoinen (ks. alapuolinen kuva). Gitlab osaa kuitenkin visualisoida .png -formaatissa olevan tiedoston sisällön kuvaksi.

![image](src/vko/vko04/drawio4.png)

## Continuous Development / Continuous Integration (or CI/CD)

Lopuksi teemme lyhyen demon `CI/CD` pipelines/ketjuista, jotka löytyvät Gitlab -palvelimelta. 

Aloitamme lataamalla/kloonaamalla valmiiksi tehdyn repositorion osoitteesta:  [https://gitlab.labranet.jamk.fi/sahka/jamk-report-latex](https://gitlab.labranet.jamk.fi/sahka/jamk-report-latex).

```
Tester@DESKTOP-RPOG490 MINGW64 ~/git
$ git clone https://gitlab.labranet.jamk.fi/sahka/jamk-report-latex.git
Cloning into 'jamk-report-latex'...
remote: Enumerating objects: 30, done.
remote: Counting objects: 100% (30/30), done.
remote: Compressing objects: 100% (18/18), done.
Receiving objects:  65% (71/108)remote: Total 108 (delta 13), reused 25 (delta 11), pack-reused 78
Receiving objects: 100% (108/108), 285.75 KiB | 8.93 MiB/s, done.
Resolving deltas: 100% (53/53), done.
```

Sitten kopioimme korostetut tiedostot (pelkästään!!!) meidän repositorioon `gitlab-opintojakso` kansiossa.

![image](src/vko/vko04/cicd1.png)

Ja lisäämme ne versionhallintaan. **Huom!** kaksi `git add` komentoa.

```
Tester@DESKTOP-RPOG490 MINGW64 ~/Desktop/git/test (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        .gitlab-ci.yml
        jamk-report.cls
        jamk-report.tex
        refs.bib
        src/

nothing added to commit but untracked files present (use "git add" to track)

Tester@DESKTOP-RPOG490 MINGW64 ~/Desktop/git/test (master)
$ git add *

Tester@DESKTOP-RPOG490 MINGW64 ~/Desktop/git/test (master)
$ git add .gitlab-ci.yml
```

Ja lopuksi committaamme ne meidän repositorioon. 

```
Tester@DESKTOP-RPOG490 MINGW64 ~/Desktop/git/test (master)
$ git commit -m "CI/CD commit"
git p[master 0aa1463] CI/CD commit
 7 files changed, 716 insertions(+)
 create mode 100644 .gitlab-ci.yml
 create mode 100644 jamk-report.cls
 create mode 100644 jamk-report.tex
 create mode 100644 refs.bib
 create mode 100644 src/img/jamk_footer_new.png
 create mode 100644 src/img/jamk_header_new.png
 create mode 100644 src/img/test.png
 
Tester@DESKTOP-RPOG490 MINGW64 ~/Desktop/git/test (master)
$ git push
Enter passphrase for key '/c/Users/Tester/.ssh/id_rsa':
Enumerating objects: 12, done.
Counting objects: 100% (12/12), done.
Delta compression using up to 4 threads
Compressing objects: 100% (10/10), done.
Writing objects: 100% (11/11), 264.80 KiB | 1.90 MiB/s, done.
Total 11 (delta 0), reused 0 (delta 0), pack-reused 0
To gitlab.labranet.jamk.fi:testaaja/test.git
   b4e90bf..0aa1463  master -> master

Tester@DESKTOP-RPOG490 MINGW64 ~/Desktop/git/test (master)
```

Nyt voimme tarkastaa repositoriomme selaimen kautta, jotta näemme pipelinen/ketjun käynnistyvän (ole vikkelä, koska muuten pipeline saattaa olla jo "ajanut lävitse").

![image](src/vko/vko04/cicd2.png)

Klikkaamalla `running` ikonia (tai `CI/CD` -> `Pipelines`) löydämme "juoksevan" pipelinen/ketjun. 

![image](src/vko/vko04/cicd3.png)

Klikkaamalla `compile_pdf` pipelineä/ketjua voimme seurata sen edistystä komentolinjalla (palvelimen päässä).

![image](src/vko/vko04/cicd4.png)

...ja odotellaan hetki... jonka jälkeen meidän ketjumme/pipelinemme on valmistunut `Job succeeded` viestillä.

![image](src/vko/vko04/cicd5.png)

Klikkaamalla `Browse` oikealla voimme katsoa tuotettua pdf tiedostoa (tai `artifact` jonka pipeline on luonut). 

![image](src/vko/vko04/cicd6.png)

Ja klikkaamalla tiedostoa voimme tarkastella tiedostoa ja ladata sen paikallisesti, jos näin haluamme. 

![image](src/vko/vko04/cicd7.png)

Nyt jos editoimme `latex-report.tex` tiedostoa, saamme versionhallinnan kytkettyä PDF raportin tekemiseen. 

**...ja mikä parasta?**

Voimme aloittaa työskentelyn kaikkien oppilaitoksen palautusten kanssa käyttäen `git + jamk-report-latex` pipelineä/ketjua! :)

# Tee harjoitustehtävä 4

Linkki harjoitustehtävään: [Harjoitustehtävä 4](src/vko/vko04_harj.md)