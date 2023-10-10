SELECT opiskelijanumero,sukunimi,etunimi,linja,aloitusvuosi,kotikunta FROM opiskelijat;

SELECT sukunimi, etunimi,kotikunta FROM opiskelijat;

SELECT DISTINCT kotikunta FROM opiskelijat;

SELECT sukunimi || ' ' || etunimi, kotikunta FROM opiskelijat;

SELECT * FROM Opiskelijat ORDER BY linja, aloitusvuosi;

SELECT opiskelijanumero,sukunimi,etunimi,linja,aloitusvuosi,kotikunta FROM Opiskelijat WHERE kotikunta='Pietarsaari';


