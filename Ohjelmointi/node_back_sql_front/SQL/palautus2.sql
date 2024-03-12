SELECT opiskelijanumero,sukunimi,etunimi,linja,aloitusvuosi,kotikunta FROM opiskelijat WHERE aloitusvuosi = 2016 AND Linja = 'Sähkö' AND kotikunta = 'Pietarsaari';

SELECT sukunimi,etunimi,linja,aloitusvuosi,kotikunta FROM opiskelijat WHERE NOT kotikunta = 'Kokkola' AND NOT kotikunta = 'Pietarsaari' AND NOT kotikunta = 'Vaasa';

SELECT jaksotunnus,nimike,laajuus,tyyppi FROM JAKSOT WHERE laajuus > 2 AND tyyppi ='sähkö';

SELECT jaksotunnus,nimike,laajuus,tyyppi FROM jaksot WHERE jaksotunnus LIKE 'A%';

SELECT jaksotunnus,nimike,laajuus,tyyppi FROM jaksot WHERE nimike LIKE 'Ohjelm%';

SELECT opiskelijanumero,sukunimi,etunimi,linja,aloitusvuosi,kotikunta FROM opiskelijat WHERE opiskelijanumero IN (SELECT opiskelijanumero FROM suoritukset WHERE jaksotunnus = 'Y010' AND arvosana > 0);