# Git -versionhallinta ja Gitlab -projektien hallintaympäristö - TTZW0410 - 1op

Opintojaksolla opiskellaan Git -versionhallintatyökalun ja Gitlab -projektien/repositorioiden hallintaympäristön käyttö. Git:stä on ohjelmointialalla alkanut muodostumaan 'de facto' -työkalu lähdekoodin versiohallinnan seurantaan ja nämä käytänteet ovat sidottavissa alan kuin alan projektien hallintaan.

Materiaali on pääosin tehty vuonna elokuussa 2018 ja pieniä päivityksiä lisätty elokuussa 2020 & maaliskuussa 2021. Videoita ei ole uusittu vko01-03, joten tarkkaile materiaalia kirjalliselta puolelta. Videot on uusittu syksyllä 2021 vko04-05

:movie_camera: [Opintojaksosuunnitelman esittelyvideo](https://youtu.be/eH2TEMDFgv0) :movie_camera:

1. [Yleisesti](#yleisesti)
3. [Aikataulu](#aikataulu)
2. [Oppimateriaali](#oppimateriaali)
2. [Kirjallisuus](#kirjallisuus)
2. [Arviointi](#arviointi)
4. [Muuta](#muuta)

## Yleisesti

![JAMK IT-instituutti](src/jamk_it-instituutti_logo_engl_web_350x150.png "JAMK IT-instituutti")

| Yksikkö | JAMK, Teknologiayksikkö, IT-instituutti |
|:--------|:----------:|
| Opettaja | [Karo Saharinen](https://www.linkedin.com/in/karo-saharinen) - karo.saharinen@jamk.fi - [D571](https://www.jamk.fi/fi/Yhteystiedot/Lutakon-kampus/) |
| Lukukausi | Nonstop |
| Ryhmä | Mikä tahansa tutkinto-ohjelma |

Opintojakson tavoitteet voit lukea [opintojaksokuvaksesta Pepistä](https://opetussuunnitelmat.peppi.jamk.fi/fi/TTV2020SS/course_unit/TTZW0410). Opintojakson voi hyväksilukea [JAMK:n ohjeiden mukaisesti](https://opinto-oppaat.jamk.fi/fi/opinto-opas-amk/opiskelu/osaamisen-tunnistaminen-ja-tunnustaminen/).

## Aikataulu

Opintojen suositeltu järjestys alapuolella.

| Vko | Sisältö | Harjoitustehtävät |
|:--------|:----------:|---------|
| 01 | [Yleisesti Git & Gitlab, Issues ja Milestones](src/vko/vko01.md) | [Harjoitustehtävä 1](src/vko/vko01_harj.md) |
| 02 | [Git asennus, Git -alkeet & Markdown tiedostoformaatin muotoilut](src/vko/vko02.md) | [Harjoitustehtävä 2](src/vko/vko02_harj.md) |
| 03 | [Git HTTPS/SSH, Revisiohistoria, Diff -tiedot, Statistiikka & Wiki](src/vko/vko03.md) | [Harjoitustehtävä 3](src/vko/vko03_harj.md) |
| 04 | [Pandoc, binääritiedostot, .gitignore, draw.io ja CI/CD pipeline/ketjut](src/vko/vko04.md) | [Harjoitustehtävä 4](src/vko/vko04_harj.md) |
| 05 | [Branches, Merge Requests ja Merge Conflicts ja lopuksi repositorion asetuksia](src/vko/vko05.md) | [Harjoitustehtävä 5](src/vko/vko05_harj.md) |

### JAMK:n opiskelijat

Opintojakso löytyy tieto- ja viestintätekniikan -opiskelijoiden (TTV) opetussuunnitelmasta vapaastivalittavana .Opintojakso toteutetaan nonstop -mallilla, eli voit aloittaa opiskelun heti ilmoittautumalla [Pepissä](https://peppi.jamk.fi) opintojaksolle:

:scroll: [https://peppi.jamk.fi](https://peppi.jamk.fi) -> Opintoni -> Opintosuunnittelu (eHOPS) -> Ilmoittautumiset -> Hae opintoja -> Kirjoita "gitlab" ja paina Hae -> Ilmoittaudu  :scroll: 

Tarvittaessa tukeudu [Pepin ilmoittautumisten tukimateriaaliin.](https://oppimateriaalit.jamk.fi/peppi/opintoni/ilmoittautumiset-opintojaksojen-toteutuksille/)

### CampusOnline opiskelijat

Opintojakso avataan syys- ja kevätlukukaudelle erikseen. Ilmoittaudu CampusOnline ohjeiden mukaisesti.

## Oppimateriaali

Oppimateriaali jaetaan:
- Gitlab -exportoitu projektitiedosto, jonka saa [Moodle -työtilasta](https://moodle.jamk.fi). Tiedosto sisältää käytetyt materiaalit ja lähteet.

Keskustelua ja virtuaalista tukea:
- Kirjaudu @student.jamk.fi -sähköpostilla [Microsoft Teams:siin](https://teams.microsoft.com) ja liity sieltä avoimeen tiimiin: `TTZW0410 Git -versionhallinta ja Gitlab -projektien hallintaympäristö`
- Sähköpostia voi myös lähettää karo.saharinen@jamk.fi

### Ohje opintojakson aloittamiseen

Opintojakson voi suorittaa:
1. https://gitlab.labranet.jamk.fi -palvelimella (IT-instituutin opiskelijat), :movie_camera: [kirjautumisvideo](https://youtu.be/Yl1tR40XkPQ) :movie_camera:
2. https://gitlab.com -palvelimella (muut), :movie_camera: [kirjautumisvideo](https://www.youtube.com/watch?v=Yl1tR40XkPQ&feature=youtu.be&t=265) :movie_camera:

:exclamation: Rekisteröitymisen jälkeen ympäristöön pitää tuoda opintojakson sähköinen oppimisympäristö/projektitiedosto. En enää lähetä tätä tiedostoa sähköpostitse vaan linkki löytyy Moodlesta. Katso ohjeet :movie_camera: [videolta](https://youtu.be/bdAHBo_jHCA). :movie_camera:

## Kirjallisuus

[Chacon, S. & Straub, B. 2014. Pro Git.](https://github.com/progit/progit2/releases/download/2.1.241/progit.pdf)

## Arviointi

Opintojaksolla opiskelija palauttaa:

- **1op suoritus:** Opiskelija tekee kaikki harjoitustehtävät ja tehtävien valmistuttua lisää @sahka jäseneksi repositorioon (Maintainer -oikeuksilla). Tämä on viimeisen tehtävän, viimeinen tehtävä.

Palautukset arvioidaan Hyväksytty tai Hylätty.

## Muuta

Opintojaksolla ei ole läsnäolo- tai kontaktivelvollisuutta.

Opintojaksopalaute kerätään viimeisen tehtävän mukana.

## Lisenssi

Tämän opintojakson materiaalin on kirjoittanut [Karo Saharinen](https://www.linkedin.com/in/karo-saharinen/) ja se on lisensoitu [Creative Commons Nimeä-EiKaupallinen-EiMuutoksia 4.0 Kansainvälinen](http://creativecommons.org/licenses/by-nc-nd/4.0/) -lisenssillä.

[![Creative Commons -lisenssi](https://i.creativecommons.org/l/by-nc-nd/4.0/88x31.png)](http://creativecommons.org/licenses/by-nc-nd/4.0/)