[Takaisin alkuun](README.md)

:movie_camera: [Opetusvideona](https://panopto.jamk.fi/Panopto/Pages/Viewer.aspx?id=0b217570-7bbf-4dfa-b609-ad8a00d3e05f) :movie_camera:

**Huom!** Video uusittu/päivitetty 2021 (Youtube -> Panopto)

# Branches & Merge Requests ja lopuksi repositorion asetuksia

Viimeiseksi viikoksi on valmisteltu haastavin vaihe työskentelystä.

Versionhallinta tähän mennessä on ollut henkilökohtaisen työtilan hallintaa. Tällöin harvemmin tulee ongelmia versioinnin kanssa.

Ongelmat alkavat, kun työtilassa on useampi työntekijä, jotka edistävät eri "haaroja" projektista. Näitä "haaroja" kutsutaan oksiksi eli branches. Voi olla tietenkin, että useampi henkilö edistää samaa haaraa.

## Branch

Haarojen tekeminen on subjektiivistä. Git:ssä usein puhutaan "Haaroitusstrategiasta" (eng. branching strategy).

Epäjohdonmukaista haarautumisessa (tai sen englanninkielisessä branch termissä) on, että haara voi yhtyä takaisin "runkoon" (eli ns. "master branch").

Yleisiä haarojen nimiä.
- **master**, repositorion virallinen julkaisu
- **release**, repositorion *testauksen* alla olevat julkaisut (voi olla myös release candidate)
- **hotfix**, pikapaikkaukset esim. bugi-ilmoituksista johtuvat korjaukset
- **development**, päärata johon "devaajat" (lue: ohjelmoijat) lyövät versioitaan
- **feature branch**, päärata saatetaan haluta joskus pilkkoa tietyiksi toiminnallisuuksiksi

Alapuolinen kuvio yrittää visualisoida haaroja. 

![image](src/vko/vko05/piirros.png)

Tein tähän kuvioon [https://draw.io:lla](https://draw.io) .png ja .xml -tiedoston, jotka tuon nyt repositorioon feature1 -branchinä.

Tarkastetaan olemassa olevat haarat **git branch** komennolla.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git branch
* master
```

Luodaan uusi haara

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git branch feature1
```

Tarkastetaan olemassa olevat haarat.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git branch
  feature1
* master
```

Siirrytään haaraan

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git checkout feature1
Switched to branch 'feature1'
```

Feature1 haaraa varten luon alapuoleisessa esimerkissä täysin uudet `piirros.png` & `piirros.xml`. Kyseiset tiedostot sijaitsevat esimerkissä kansiossa `src/vko/vko05/`.

Kopioidaan tiedostot /src/vko/vko05 -kansioon ja lisätään ne haaraan **git add** jne.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git status
On branch feature1
Untracked files:
  (use "git add <file>..." to include in what will be committed)

        src/vko/vko05/

nothing added to commit but untracked files present (use "git add" to track)

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git add *
The following paths are ignored by one of your .gitignore files:
lueminut.docx
Use -f if you really want to add them.

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git status
On branch feature1
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   src/vko/vko05/piirros.png
        new file:   src/vko/vko05/piirros.xml


sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git commit -m "piirrokset feature1 branchiin"
[feature1 f6802f3] piirrokset feature1 branchiin
 2 files changed, 1 insertion(+)
 create mode 100644 src/vko/vko05/piirros.png
 create mode 100644 src/vko/vko05/piirros.xml
```

**git push** varoittaa käyttäjää ks. alapuolella.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git push
fatal: The current branch feature1 has no upstream branch.
To push the current branch and set the remote as upstream, use

    git push --set-upstream origin feature1

```

 Nyt ei olla lataamassa master -haaraan vaan feature1 -haaraan. Palvelin ei tiedä kyseisestä feature1 -haarasta vielä mitään.
 
 `git push --set-upstream origin feature1` komennolla palvelimelle luodaan ja päivitetään feature1 -haara.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git push --set-upstream origin feature1
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 7, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (7/7), done.
Writing objects: 100% (7/7), 16.73 KiB | 8.36 MiB/s, done.
Total 7 (delta 3), reused 0 (delta 0)
remote:
remote: To create a merge request for feature1, visit:
remote:   https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso/merge_requests/new?merge_request%5Bsource_branch%5D=feature1
remote:
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
 * [new branch]      feature1 -> feature1
Branch 'feature1' set up to track remote branch 'feature1' from 'origin'.
```

Palvelimen selainkäyttöliittymään tuli Repository -> Branches alle uusi haara. 

Huom!

>remote: To create a merge request for feature1, visit:
>remote:   https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso/merge_requests/new?merge_request%5Bsource_branch%5D=feature1

Ehdottaa jo graafisesta käyttöliittymästä tehtävää "merge request" -toiminnetta (ks. [Merge Requests -kappale](#merge-requests)). Tässä jatkamme kuitenkin komentolinjalla esimerkin loppuun.

![image](src/vko/vko05/branching1.png)

Liitetään feature1 -haara takaisin master -haaraan.

Vaihdetaan takaisin master -haaraan.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature1)
$ git checkout master
Switched to branch 'master'
M       src/vko/vko05.md
Your branch is up to date with 'origin/master'.
```

Ja sitten **git merge --no-ff feature1** -komennolla tehdään liitos.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git merge --no-ff feature1
Merge made by the 'recursive' strategy.
 src/vko/vko05/piirros.png | Bin 0 -> 15895 bytes
 src/vko/vko05/piirros.xml |   1 +
 2 files changed, 1 insertion(+)
 create mode 100644 src/vko/vko05/piirros.png
 create mode 100644 src/vko/vko05/piirros.xml
```

Tarkastetaan status. Paikallinen master -haara on nyt edellä palvelimen master -haaraa, koska merge on tehty vain paikallisesti.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is ahead of 'origin/master' by 2 commits.
  (use "git push" to publish your local commits)

Changes not staged for commit:
  (use "git add <file>..." to update what will be committed)
  (use "git checkout -- <file>..." to discard changes in working directory)

        modified:   src/vko/vko05.md

no changes added to commit (use "git add" and/or "git commit -a")

```

Ja työnnetään merge tapahtuma palvelimen repositorioon.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 1, done.
Writing objects: 100% (1/1), 225 bytes | 225.00 KiB/s, done.
Total 1 (delta 0), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   5eb0c66..3e0f5ee  master -> master
```

Haaran tila muuttui "merged" palvelimella.

![image](src/vko/vko05/branching2.png)

Repository -> Graph näyttää haaroituksen gitlab -käyttöliittymässä. **--no-ff** -vipu git merge -komennossa teki merge -tapahtumasta itsenäisen commit:n, joka helpottaa palaamista tähän pisteeseen (ks. [Revert -kappale](#revert))

![image](src/vko/vko05/branching3.png)

## Merge Requests

**git merge** -komennosta pääsemme keskusteluun "kuka hyväksyy haaran sulautuksen". Suuremmassa sovellusprojektissa Merge -tapahtuma on ison tarkastelun piste. Vastuu on yleensä merge:n hyväksyjällä.

Tämän vuoksi eri tuotteissa tätä tapahtumaa kutsutaan eri nimillä. Esim. Gitlab: Merge request, Github: Pull request. Nämä aiheuttavat suuremman episodin lähekoodin tarkastelua (kuin mitä teimme yläpuolisessa), että voidaan välttää lähdekoodin ristiriidat.

Toteutetaan siis yläpuoleinen esimerkki **git push --set-upstream origin feature1** -komentoon asti, mutta tehdään Merge Request -pyyntö selainkäyttöliittymästä. Tehdään tämä esimerkki feature2 -haarana.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git branch feature2

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git checkout feature2
Switched to branch 'feature2'
```

Tehdään tiedosto feature2.md ja lisätään se feature2 haaraan.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature2)
$ git status
On branch feature2
Untracked files:
  (use "git add <file>..." to include in what will be committed)

        feature2.md

nothing added to commit but untracked files present (use "git add" to track)

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature2)
$ git add feature2.md

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature2)
$ git status
On branch feature2
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

        new file:   feature2.md
```

Tämän jälkeen työnnetään päivitys feature2 -haaraan.

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature2)
$ git commit -m "feature2.md lisätty"
[feature2 e77b789] feature2.md lisätty
 1 file changed, 3 insertions(+)
 create mode 100644 feature2.md

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature2)
$ git push --set-upstream origin feature2
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 3, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 304 bytes | 304.00 KiB/s, done.
Total 3 (delta 1), reused 0 (delta 0)
remote:
remote: To create a merge request for feature2, visit:
remote:   https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso/merge_requests/new?merge_request%5Bsource_branch%5D=feature2
remote:
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   41fc812..e77b789  feature2 -> feature2
Branch 'feature2' set up to track remote branch 'feature2' from 'origin'.
```

Tämän jälkeen avataan komentolinjan tarjoama linkki selaimeen. Näkymä on seuraava:

![image](src/vko/vko05/mergerequest1.png)

Titleksi tulee viimeisin commit -message. Merge Request -viestiä voi kuvailla tarkemmin, joten lisätään kommentti ja painetaan "Submit merge request". Tämän jälkeen avautuu alapuoleinen näkymä:

![image](src/vko/vko05/mergerequest2.png)

Työtila tarjoaa nyt keskustelutilan tälle sulautukselle. Keskustelun jälkeen muutokset (eli feature2.md) voidaan hyväksyä osaksi master -haaraa. Aiemmassa esimerkissä vain "väkisin sulautimme" lähdekoodimme master -haaraan, ilman suurempaa reflektointia/tarkastelua feature:n sisällöstä/toimivuudesta.

Tässä keskustelu tilassa näkyy Discussion, Commits ja Changes -välilehdet, josta voi tarkastella muutoksia. Tarkastetaan aluksi Commits.

![image](src/vko/vko05/mergerequest3.png)

Ja sitten Changes.

![image](src/vko/vko05/mergerequest4.png)

Muutokset ovat OK tämän auditoinnin jälkeen (huom! ne voisi ladata paikallisesti ja tarkastaa esim. ohjelmiston toiminta/kääntyvyys).

Painetaan nyt kuitenkin Modify commit message -nappulaa. Nyt Merge -tapahtumasta tulee oma commit ja tässä kentässä voi muokata commit viestiä.

![image](src/vko/vko05/mergerequest5.png)

Painetaan Merge -nappulaa ja näkymä muuttuu

![image](src/vko/vko05/mergerequest6.png)

Voimme tarkastaa feature2 erkanemisen ja sisällytyksen Repository -> Graph -valikosta

![image](src/vko/vko05/mergerequest7.png)

Nyt Merge Request:n käsittely on mennyt sulavasti selain käyttöliittymästä. Ymmärrettävää on, että riippuen haaran 'mittavista' muutoksista tässä voi kestää useampia päiviä/viikkoja ennen hyväksyntää master -haaraan. 

## Merge Conflicts

Hyvin usein git:n käyttö saa epämieluisia kokemuksia, kun ristiriitoja tapahtuu. Näitsä kutsutaan **Merge Conflict** -nimellä.

Generoidaan tässä esimerkkinä ristiriita yhteen tiedostoon.

Teen feature3 -haarassa tiedoston repositorion juureen nimeltä ruoka.md, jonka sisältönä on rivillä 1 "Makaronilaatikko".

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git branch feature3

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git checkout feature3
Switched to branch 'feature3'

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature3)
$ git status
On branch feature3
Untracked files:
  (use "git add <file>..." to include in what will be committed)

        ruoka.md

nothing added to commit but untracked files present (use "git add" to track)

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature3)
$ tail ruoka.md
Makaronilaatikko
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature3)
$ git add ruoka.md

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature3)
$ git commit -m "Feature3: ruoka.md lisätty"
[feature3 b6d9e0a] Feature3: ruoka.md lisätty
 1 file changed, 1 insertion(+)
 create mode 100644 ruoka.md

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature3)
$ git push --set-upstream origin feature3
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 3, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 312 bytes | 312.00 KiB/s, done.
Total 3 (delta 1), reused 0 (delta 0)
remote:
remote: To create a merge request for feature3, visit:
remote:   https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso/merge_requests/new?merge_request%5Bsource_branch%5D=feature3
remote:
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
 * [new branch]      feature3 -> feature3
Branch 'feature3' set up to track remote branch 'feature3' from 'origin'.
```

Teen master -haarassa tiedoston repositorion juureen nimeltä ruoka.md, jonka sisältönä on rivillä 1 "Jauhelihakeitto".

```
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (feature3)
$ git checkout master
Switched to branch 'master'
Your branch is up to date with 'origin/master'.

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ tail ruoka.md
Jauhelihakeitto
sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up to date with 'origin/master'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)

        ruoka.md

nothing added to commit but untracked files present (use "git add" to track)

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git add ruoka.md

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git commit -m "master: ruoka.md lisätty"
[master cc52ad7] master: ruoka.md lisätty
 1 file changed, 1 insertion(+)
 create mode 100644 ruoka.md

sahka@SAHKA-PC MINGW64 ~/Desktop/git/gitlab-opintojakso (master)
$ git push
Enter passphrase for key '/c/Users/sahka/.ssh/id_rsa':
Counting objects: 3, done.
Delta compression using up to 4 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 305 bytes | 305.00 KiB/s, done.
Total 3 (delta 1), reused 0 (delta 0)
To gitlab.labranet.jamk.fi:sahka/gitlab-opintojakso.git
   4f6e8de..cc52ad7  master -> master
```

Molemmat on nyt siis commitoitu eri haaroihin samalla tiedostonimellä, mutta eri sisällöllä. Tarkastetaan tilanne `Repository` -> `Graph` -näkymästä.

![image](src/vko/vko05/mergeconflict1.png)

Tehdään tällä kertaa `Merge Request` selainkäyttöliittymästä `Repository` -> `Branches` -näkymästä painamalla `Merge Request` -nappulaa. 

![image](src/vko/vko05/mergeconflict2.png)

Tämä avaa tutun käyttöliittymän sulautuspyynnöstä, johon voi kommentoida sulautusta. Poista täppä `delete source branch...` ja `Description` -kentän täytön jälkeen paina `Create Merge Request`.

![image](src/vko/vko05/mergeconflict2_2.png)

Seuraavaksi avautuu Merge:n hyväksyntään liittyvä näkymä, mutta `Merge` -nappula on harmaana! Vieressä on viesti **There are merge conflicts**!

![image](src/vko/vko05/mergeconflict3.png)

Nyt ihmisen (eli repositorion master -haaran vastuuhenkilön [lue: sinun]) pitää käydä manuaalisesti lävitse ristiriidat ja päättää mikä on oikea ratkaisu. Painetaan `Resolve Conflicts` -näppäintä joka avaa seuraavan näkymän.

![image](src/vko/vko05/mergeconflict4.png)

Ristiriita ruoka.md -tiedostossa vaatii päätöksiä
- Use ours (eli Makaronilaatikko oli `feature3` -haarassa)
- Use theirs (eli Jauhelihakeitto oli `master` -haarassa)
- `Edit inline` tarkoittaa, että voidaan muokata suoraan tiedostosisältö sellaiseksi kuin halutaan.
- Vasta tilanteen ratkettua voidaan hyväksyä `Commit to source branch`

`Edit inline` -näyttää tiedostosisällön, jonka voi ratkaista (ks. alapuolinen kuva).

**Huom!** Päivitin kuvia englanninkielistä materiaalia tehdessä 19.8.2021. 

* `Jauhelihakeitto -> Karelian Stew`
* `Makaronilaatikko -> Maccaroni Casserole`

![image](src/vko/vko05/mergeconflict5.png)

Nuolien suunnat tarkoittavat <<<<<<< (ours) ja >>>>>>> (theirs). Joka tapauksessa tiedostoon pitää jäädä nyt yksi rivi ilman näitä nuolimerkintöjä (ja ======= merkintöjä). 

Päätetään käyttää `master` -haaran sisältöä eli Jauhelihakeitto. Voimme poistaa muut rivit tästä TAI palata `Interactive mode` ja valita hiirellä soveltuvat rivit/väri.

![image](src/vko/vko05/mergeconflict6.png)

Hyväksytään lopputulos painamalla `Commit to source branch`. 

Tämän jälkeen seuraava ruutu aukeaa, mutta `Merge` nappula ei mene vihreäksi (date 19.8.2021). Saat sen vihreäksi menemällä `Close Merge Request` -> `Reopen Merge Request` -> Päivitä sivu (or F5) -> `Merge` pitäisi vaihtua vihreäksi. Erikoinen bugi, mutta toivottavasti korjataan Gitlab:n päästä. 
 
![image](src/vko/vko05/mergeconflict7.png)

Paina `Merge` ja seuraava ruutu pitäisi aueta.

Huomioitavaa kuvassa on, että resolve conflict -nappula teki ylimääräisen commitin toiseen haaraan (feature3), jonka jälkeen conflict ratkesi. Nyt haarat voidaan mergeä, eli yläpuolisessa kuvassa merge -nappula on vihreä. 

![image](src/vko/vko05/mergeconflict9.png)

Tarkastetaan vielä `Repository` -> `Graph` -näkymästä.

![image](src/vko/vko05/mergeconflict10.png)

### Yhteenvetona Merge Conflict -tilanteesta

Komentolinjalla Merge Conflict voi olla haastava peruskäyttäjälle hallita. Tämä aiheuttaa epämukavuutta git:n käyttöön.

Binääritiedostojen kanssa Merge Conflict on sietämätön, koska komentolinjalla et näe mitenkään viat binääritiedostoista. Graafisessa käyttöliittymässä on jotain mahdollisuuksia selviytyä binääritiedostojen merge conflict -tilanteista.

Suosittelen vahvasti käyttämään tekstipohjaisia dokumenttejä git -ympäristössä. Aiemmin keskusteltu **pandoc** -työkalu auttaa tähän. Jos binääritiedostoja käsittelee (.docx, .png) tulee olla todella varovainen ristiriitojen kanssa. 

## Repositorion asetuksista

### Settings -> General -valikon alta 

General project settings, Expand -nappulasta avautuu:

- **Project name**, Tämä muuttaa repositorion nimeä kosmeettisesti
- **Project Description**, tarkempia tietoja, kun projektiin saapuu
- **Default Branch**, Jos haluaa esim release -haaran olevan oletushaara joka projektista näkyy
- **Tags**, Jos haluaa gitlab -instanssissa esim tuotteeseen liittyvät repositoriot 'tägätä' yhdelle hakusanalle
- **Project avatar**, halutessasi kyseisen tuotteen logo

Permissions, Expand -nappulasta avautuu:

- **Project visibility**, :exclamation::exclamation::exclamation:, 
   - Private, Näkyy vain projektin jäsenille
   - Internal, Näkyy vain gitlab -palvelimen (rekisteröityneille) jäsenille
   - Public, Näkyy julkisesti Internetiin ilman kirjautumista
- **Issues**, haluaako ominaisuuden repositoriossa päälle vai pois päältä ja käyttäjätasot (esim. Public repositoriossa Internetin käyttäjät eivät voi tehdä issueita, pelkästään repositorion jäsenet[Only Project Members])
- **Repository**, View and edit files on hyvä jättää Everyone with Access, koska muuten tiedostoja ei edes näe (view) julkisessa repositoriossa. Tämän alikohdat kannattaa olla *Only Project Members*, koska muutoksia (merge) voi vain ehdottaa projektin jäsenet.
   - Eli tiedostojen editointi tekee aina oman haaran joka pitää mergettää masteriin
- **Wiki**, Wikisivuston voi poistaa, jos ei käytetä, mutta pääsääntöisesti sen muokkausoikeudet *Only Project Members*
- **Snippets**, Hyviä koodinpätkiä voi julkaista "Snippetteinä", joten niiden julkaiseminen projektista *Only Project Members*

Export Project, Expand -nappulasta avautuu:
- **Export project**, Tämä generoi palvelimella kyseisestä repositoriosta **.tar.gz** -tiedoston, jolla aloitit opintojakson. 
   - **.tar.gz** -tiedoston latauslinkki tulee käyttäjätunnuksesi sähköpostiosoitteeseen!
   - Nyt se tietenkin sisältää kaikki harjoitteesi.
   
Advanced Settings, Expand -nappulasta avautuu:

- **Rename project**, Jos nimeäisin projektin uudestaan, tekisin sen täältä... kyseinen toiminne voi kuitenkin rikkoa paljon ja siitä onkin varoituksia ihan Gitlab:n toimestakin
- **Remove project**, joskus projekteja saattaa haluta siivota ja siirtää ns. "cold storage" -levytilalle kansiorakenteeseen
   - Tämä siis poistaa palvelimelta koko repositorion, kannattaa kenties tehdä *Export Project* lähdekoodin säilytyksen lisäksi (issuet, jne tallentuu)

### Settings -> General -valikon alta 

Project Members -määrittää työtilan viralliset jäsenet (Internal ja Private -näkyvyydessä tärkeitä!)

Jäseniä voi lisätä joko yksittäisten käyttäjätunnusten kautta (Add member) tai jakaa ryhmälle (Share with group).

Jokaisella käyttäjällä on oikeustasot Gitlab -instanssissa. Tasot ovat:

- **Guest**, Käytännössä voi nähdä työtilan, tehdä issueita, kommentoida ja lukea wikiä
- **Reporter**, Voi yläpuolisten lisäksi ladata lähdekoodia, sitoa issuelle tekijät (assign), luoda leimoja (labels)
- **Developer**, Voi yläpuolisten lisäksi tehdä uusia haaroja, luoda merge requesteja, hyväksyä niitä, tehdä uusia committeja
- **Maintainer**, Voi yläpuolisten lisäksi suojata tiettyjä haaroja Developer -työskentelyltä (esim. release tai master) ja lisäksi lähes kaikki paitsi työtilan tuhoaminen
- **Owner**, voi tehdä kaiken ja myös tuhota työtilan, tuhota issueita, vaihtaa näkyvyyttä jne

Tarkemmat [Member Permission -taulukot Gitlab -dokumentaatiosta](https://docs.gitlab.com/ee/user/permissions.html#project-members-permissions).

# Tee harjoitustehtävä 5

Linkki harjoitustehtävään: [Harjoitustehtävä 5](src/vko/vko05_harj.md)