[Takaisin alkuun](README.md)

# Git asennus, Git -alkeet & Markdown tiedostoformaatin muotoilut

:movie_camera: [Opetusvideona](https://youtu.be/d5njuIawE4c) :movie_camera:

Tämän viikon tiedoston sisältö on pitkä, joten sisällysluettelo alkuun.

1. [Git asennus](#git-asennus)
2. [Git alkeet](#git-alkeet)
3. [Markdown tiedostoformaatti](#markdown-tiedostoformaatti)
4. [Tee harjoitustehtävä 2](#tee-harjoitustehtävä-2)

## Git asennus

Oletan pääsääntöisesti opiskeiljan tulevan Windows -maailmasta. Siksi ohjeistukseni ja videomateriaalini perustuu pääsääntöisesti Windows -työskentelyyn.

### Windows

Ohje asentamiseen löytyy tästä linkistä: https://git-scm.com/download

Videoitu ohje Windows 10: https://youtu.be/hRWjyyyo3lM

**Käytä** [Notepad++ -ohjelmistoa](https://notepad-plus-plus.org/) tekstitiedostojen editointiin! *ÄLÄ KÄYTÄ perinteistä windows notepad*
- Perinteisessä notepad:ssä tulee vastaan ongelmia rivinvaihdon kanssa ks. [Newline](https://en.wikipedia.org/wiki/Newline)

### Linux

Ohje asentamiseen löytyy tästä linkistä: https://git-scm.com/download/linux

Videoitu ohje Ubuntu 16.04 LTS: https://youtu.be/bCgG4E0eniA

# Markdown & Git

## Markdown -tiedoston luonti ja Git -perusteet

Seuraavaksi tehdään perustoimenpiteet, että saamme yhden `file.md` -tiedoston liikkumaan paikallisen versionhallinnan ja keskitetyn version hallinnan välillä.

Tämän jälkeen esitetään miten tiedostoa voi muotoilla ja edetään harjoitustehtävään.

### Git alkeet

Työskentelemme opintojaksolla pääsääntöisesti **komentorivillä**. Tämä tarkoittaa, että sinun tulee käyttää esim. Windows:ssa **Git Bash**  (asennuksen jälkeen paina oikeata hiirennäppäintä työpöydällä / kansiossa).

![image](src/vko/vko02/gitbash.png)

Käskyt ovat kirjoitettu git bash:ssä.

Perustetaan aluksi kansio, jossa työskennellään versionhallinnan parissa (esim. `C:/Users/user/git/` tai `/home/user/git/`). Alapuolella Git Bash -komentolinjalta esimerkki.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~
$ pwd
/c/Users/Sahka-Laptop

Sahka-Laptop@DESKTOP-U189FED MINGW64 ~
$ mkdir git

Sahka-Laptop@DESKTOP-U189FED MINGW64 ~
$ cd git

Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git
$ pwd
/c/Users/Sahka-Laptop/git

```

Kloonataan työtila itselle `git` -kansion alle. Huomaa, että käyttäjätunnuksen pitää olla oma opiskelijanumero. Esim. https://gitlab.labranet.jamk.fi/k1234/gitlab-opintojakso.git (ks. alapuoleinen video)

![Repositorion linkki](http://student.labranet.jamk.fi/~sahka/taustamateriaali/repolinkki.webm)

Löydettyäsi linkin (Huom! Tässä vaiheessa opintoja HTTPS) ala seuraamaan alapuolisia ohjeita.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git
$ git clone https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso.git
Cloning into 'gitlab-opintojakso'...
```

Oma käyttäjätunnus

```
Username for 'https://gitlab.labranet.jamk.fi': sahka
```

Oma salasana

```
Password for 'https://sahka@gitlab.labranet.jamk.fi': <salasana>
```

Käyttäjätunnuksen ja salasanan mennessä oikein repositorion/projektin sisältö kopioituu paikalliselle kovalevylle `.../git/gitlab-opintojakso/` -kansioksi.

```
remote: Counting objects: 129, done.
remote: Compressing objects: 100% (66/66), done.
remote: Total 129 (delta 42), reused 44 (delta 20)
Receiving objects: 100% (129/129), 348.25 KiB | 0 bytes/s, done.
Resolving deltas: 100% (58/58), done.
Checking connectivity... done.
```

Tarkastetaan kansion sisältö **ls** komennolla ja siirrytään `gitlab-opintojakso` -kansioon **cd** -komennolla.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git
$ ls
gitlab-opintojakso/

Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git
$ cd gitlab-opintojakso/
```

Tarkastetaan kansion tilanne **git status** -komennolla.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up-to-date with 'origin/master'.
nothing to commit, working directory clean

```

Yläpuolisesta tekstistä tärkein on *nothing* *to* *commit* eli kansiossa ei ole muutoksia tapahtunut.

Tehdään tiedosto nimellä `etunimi_sukunimi_opiskelijanumero.md` ja laitetaan sisälle alapuolinen sisältö (# otsikko...).

Avaa esim. notepad ja luo tiedosto kansioon. Tarkasta, että tiedostopääte ei ole `etunimi_sukunimi_opiskelijanumero.md.txt` vaan `etunimi_sukunimi_opiskelijanumero.md`. 

Kopioi alapuolinen teksti tiedoston sisään

```
# otsikko

tekstiä
```

Tallennetaan tiedosto gitlab-opintojakso -kansioon esim. `.../git/gitlab-opintojakso/karo_saharinen_sahka.md` ja tarkastetaan komentolinjalta kansion tilanne muutoksista.

```
git status
On branch master
Your branch is up-to-date with 'origin/master'.
Untracked files:
  (use "git add <file>..." to include in what will be committed)

	karo_saharinen_sahka.md

nothing added to commit but untracked files present (use "git add" to track)
```

Git huomaa uuden tiedoston, jonka versioita ei seurata ("Untracked files:"). 

Tiedoston voi lisätä seurantaan/repositorioon komennolla.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git/gitlab-opintojakso (master)
$ git add karo_saharinen_sahka.md
```

Tarkastetaan jälleen status

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git/gitlab-opintojakso (master)
$ git status
On branch master
Your branch is up-to-date with 'origin/master'.
Changes to be committed:
  (use "git reset HEAD <file>..." to unstage)

	new file:   karo_saharinen_sahka.md

```

Tiedosto on siis otettu mukaan, mutta huomaa *to* *be* *committed*. Tiedosto on nyt lastattu valmiiksi seurantaan, mutta sitä ei ole vielä sidottu/otettu käyttöön projektiin/repositorioon. Otetaan tiedosto projektiin.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git/gitlab-opintojakso (master)
$ git commit -m "Oma markdown tiedostoni projektiin"
```

*-m* vipu tekee muutostekstin, joka on jälkeenpäin tarkasteltavissa. Tässä todetaan että ensimmäinen tiedosto luotu.

Jos commitoit ensimmäistä kertaa, ohjelma voi ilmottaa...

```
*** Please tell me who you are.

Run

  git config --global user.email "you@example.com"
  git config --global user.name "Your Name"

to set your account's default identity.
Omit --global to set the identity only in this repository.

fatal: unable to auto-detect email address (got 'sahka@sahka-VirtualBox.(none)')
```

Tällöin määritä käyttäjäsi (tietenkin omilla tiedoillasi)

```
git config --global user.email "karo.saharinen@jamk.fi"
git config --global user.name "Karo Saharinen"
```

Tämän jälkeen **git commit** onnistuu.

```
git commit -m "Oma markdown tiedostoni projektiin"
[master 8255e11] Oma markdown tiedostoni projektiin
 1 file changed, 3 insertions(+)
 create mode 100644 karo_saharinen_sahka.md
```

Nyt muutokset ovat sinun paikallisessa versionhallinnassasi. Ne pitää lähettää palvelimelle.

```
Sahka-Laptop@DESKTOP-U189FED MINGW64 ~/git/gitlab-opintojakso (master)
$ git push

warning: push.default is unset; its implicit value has changed in
Git 2.0 from 'matching' to 'simple'. To squelch this message
and maintain the traditional behavior, use:

  git config --global push.default matching

To squelch this message and adopt the new behavior now, use:

  git config --global push.default simple

When push.default is set to 'matching', git will push local branches
to the remote branches that already exist with the same name.

Since Git 2.0, Git defaults to the more conservative 'simple'
behavior, which only pushes the current branch to the corresponding
remote branch that 'git pull' uses to update the current branch.

See 'git help config' and search for 'push.default' for further information.
(the 'simple' mode was introduced in Git 1.7.11. Use the similar mode
'current' instead of 'simple' if you sometimes use older versions of Git)

Username for 'https://gitlab.labranet.jamk.fi': <k1234>
Password for 'https://sahka@gitlab.labranet.jamk.fi': <salasana>
Counting objects: 3, done.
Delta compression using up to 2 threads.
Compressing objects: 100% (2/2), done.
Writing objects: 100% (3/3), 356 bytes | 0 bytes/s, done.
Total 3 (delta 0), reused 0 (delta 0)
To https://gitlab.labranet.jamk.fi/sahka/gitlab-opintojakso.git
   7a3f1b5..8255e11  master -> master
```

Nyt muutokset on lähetetty palvelimelle. Versionhallinta on ehyt palvelimella ja omalla paikallisella koneellasi.

Selaimella siirtyessäsi repositorioon voit katsoa luomustasi Gitlab:n käyttöliittymästä.

Seuraavaksi on pitkä lista erillaisia Markdown -muotoiluun liittyviä ohjeita. Lopussa on [harjoitustehtävä](#tee-harjoitustehtävä-2).

## Markdown tiedostoformaatti

Nyt voit yläpuolisilla opeilla ruveta testailemaan Markdown -muotoiluja. Ohjeeni lähde: [https://docs.gitlab.com](https://docs.gitlab.com/ee/user/markdown.html).

### Otsikot

Otsikot muodostuvat risuaitojen/ristikkojen (#) määrästä tekstin edessä.

    # H1
    ## H2
    ### H3
    #### H4
    
Muodostaa:

# H1
## H2
### H3
#### H4

Otsikkoja voi linkittää sisällysluetteloon. Tästä lisää [#linkitys](#linkitys) -kappaleessa.

### Bold

Boldaus tapahtuu kahdella **tähdellä** tai __alaviivalla__.

```
Boldaus tapahtuu kahdella **tähdellä** tai __alaviivalla__.
```

### Strikethrough

Yliviivaus tapahtuu kahdella ~~aaltomerkillä~~ (`~`).

```
Yliviivaus tapahtuu kahdella ~~aaltomerkillä~~ (`~`).
```

### Kursivointi

Kursivointi tapahtuu yhdellä *tähdellä* tai _alaviivalla_.

```
Kursivointi tapahtuu yhdellä *tähdellä* tai _alaviivalla_.
```

### Koodi tai syntax highlight

Ohjelmointikieliä voi kätevästi esittää "laatikoissa" käyttäen kolme [gravis](http://webcgi.oulu.fi/oykk/abc/kielenhuolto/oikeinkirjoitus/valimerkit/muut_merkit/) (eng. backtick) merkkiä (<code>```</code>) ennen ja jälkeen. Katso esimerkit alapuolelta.

Toinen mahdollisuus on aloittaa rivi neljällä välilyönnillä.

#### Javascript

    ```javascript
    var s = "JavaScript syntax highlighting";
    alert(s);
    ```

Näyttää

```javascript
var s = "JavaScript syntax highlighting";
alert(s);
```

#### Python


    ```python
    def function():
        #indenting works just fine in the fenced code block
        s = "Python syntax highlighting"
        print s
    ```

Näyttää

```python
def function():
    #indenting works just fine in the fenced code block
    s = "Python syntax highlighting"
    print s
```

#### Ruby

    ```ruby
    require 'redcarpet'
    markdown = Redcarpet.new("Hello World!")
    puts markdown.to_html
    ```

Näyttää

```ruby
require 'redcarpet'
markdown = Redcarpet.new("Hello World!")
puts markdown.to_html
```

#### Kielineutraali tai 'yleisesti laatikkoon haluttava tekstin pätkä'

    ```
    No language indicated, so no syntax highlighting.
    s = "There is no highlighting for this."
    But let's throw in a <b>tag</b>.
    ```

Näyttää

```
No language indicated, so no syntax highlighting.
s = "There is no highlighting for this."
But let's throw in a <b>tag</b>.
```

### Linkitys

    [Rivillä näkyvä teksti](https://www.jamk.fi/)

Tuottaa

[Rivillä näkyvä teksti](https://www.jamk.fi/)

Yhden markdown -tiedoston sisällä voit tehdä linkkejä otsikkoihin seuraavasti.

    [Otsikot](#otsikot) -kappaleeseen

[Otsikot](#otsikot) -kappaleeseen linkki. Kyseinen kappale sisältää linkin takaisin #linkitys -kappaleeseen. Useamman sanan otsikot voi yhdistää linkkinä viivalla.

    [Kuvan lisääminen](#kuvan-lisääminen)

[Kuvan lisääminen](#kuvan-lisääminen)

### Kuvan lisääminen

Kuvat voi lisätä seuraavasti:

    Tässä JAMK:n logo (vie hiiri päälle, että näet otsikkotekstin):

    Yhtenä rivinä:
    ![Otsikkoteksti](src/jamk_it-instituutti_logo_engl_web_350x150.png "Otsikkoteksti1")

    Viittauksena (jos haluat esim. tiedoston alkuun kaikki tiedoston sisältämä media):
    ![Otsikkoteksti1][logo]

    [logo]: src/jamk_it-instituutti_logo_engl_web_350x150.png

Tässä JAMK:n logo (vie hiiri päälle, että näet otsikkotekstin):

Yhtenä rivinä:

![Kuva1](src/jamk_it-instituutti_logo_engl_web_350x150.png "Otsikkoteksti1")

Viittauksena (jos haluat esim. tiedoston alkuun kaikki tiedoston sisältämä media):

![Kuva2][logo]

[logo]: src/jamk_it-instituutti_logo_engl_web_350x150.png

### Videot

Kuvien tapaisesti linkit, joiden pääte on (`.mp4`, `.m4v`, `.mov`, `.webm`, and `.ogv`) muutetaan automaattisesti videotoistimeksi.

    Esimerkkivideo:

    ![Esimerkkivideo](http://student.labranet.jamk.fi/~sahka/password.webm)

Esimerkkivideo:

![Esimerkkivideo](http://student.labranet.jamk.fi/~sahka/password.webm)

### Listat

```no-highlight
1. First ordered list item
2. Another item
  * Unordered sub-list.
1. Actual numbers don't matter, just that it's a number
  1. Ordered sub-list
4. And another item.

* Unordered list can use asterisks
- Or minuses
+ Or pluses
```

1. First ordered list item
2. Another item
  * Unordered sub-list.
1. Actual numbers don't matter, just that it's a number
  1. Ordered sub-list
4. And another item.

* Unordered list can use asterisks
- Or minuses
+ Or pluses



#### Markbox

```no-highlight
- [x] Valmis tehtävä
- [ ] Keskenoleva tehtävä
    - [ ] Alitehtävä 1
    - [x] Alitehtävä 2
    - [ ] Alitehtävä 3
```

- [x] Valmis tehtävä
- [ ] Keskenoleva tehtävä
    - [ ] Alitehtävä 1
    - [x] Alitehtävä 2
    - [ ] Alitehtävä 3



### Taulukot

```
| otsikko 1 | otsikko 2 |
| --------- | --------- |
|  solu 1   |  solu 2   |
|  solu 3   |  solu 4   |
```

Teksti yläpuolella tuottaa seuraavan taulukon

| otsikko 1 | otsikko 2 |
| --------- | --------- |
|  solu 1   |  solu 2   |
|  solu 3   |  solu 4   |

**Huom!**

Kaksoispisteellä pystyy keskittämään tekstin.

```
|  Vasemmalle  | Keskelle |    Oikealle   |  Vasemmalle  | Keskelle |   Oikealle    |
| :----------- | :------: | ------------: | :----------- | :------: | ------------: |
| Cell 1       | Cell 2   | Cell 3        | Cell 4       | Cell 5   | Cell 6        |
| Cell 7       | Cell 8   | Cell 9        | Cell 10      | Cell 11  | Cell 12       |
```

|  Vasemmalle  | Keskelle |    Oikealle   |  Vasemmalle  | Keskelle |   Oikealle    |
| :----------- | :------: | ------------: | :----------- | :------: | ------------: |
| Cell 1       | Cell 2   | Cell 3        | Cell 4       | Cell 5   | Cell 6        |
| Cell 7       | Cell 8   | Cell 9        | Cell 10      | Cell 11  | Cell 12       |

### Emoji

Tekstiä voi myös hieman elävöittää lisäämällä :star2: sinun :speech_balloon:. 

:zap: Emojit toimivat Gitlab:n sisällä, mutta ei välttämättä suoraan kopioituna esim. Github:ssa :v:

Koodista voi nostaa esiin :bug: tai jos joku edistää hidasta :snail: koodiasi, voit lähettää myös :birthday:. 

Tarkemmat koodit löytyvät [Emoji Cheat Sheet](https://www.webfx.com/tools/emoji-cheat-sheet/), jos jokin on hukassa. :thumbsup:

> Ongelmia emojien kanssa? Käy tukeutumassa tarvittaessa tänne:
https://gitlab.com/gitlab-org/gitlab-ce/blob/master/doc/user/markdown.md#emoji

	Sometimes you want to :monkey: around a bit and add some :star2: to your :speech_balloon:. Well we have a gift for you:

	:zap: You can use emoji anywhere GFM is supported. :v:

	You can use it to point out a :bug: or warn about :speak_no_evil: patches. And if someone improves your really :snail: code, send them some :birthday:. People will :heart: you for that.

	If you are new to this, don't be :fearful:. You can easily join the emoji :family:. All you need to do is to look up on the supported codes.

	Consult the [Emoji Cheat Sheet](https://www.webfx.com/tools/emoji-cheat-sheet/) for a list of all supported emoji codes. :thumbsup:


# Tee harjoitustehtävä 2

Linkki harjoitustehtävään: [Harjoitustehtävä 2](src/vko/vko02_harj.md)