# IRF_Project
Informatikai Rendszerek Fejlesztése beadandó

1. Adatok importálása
C) XML feldolgozás (fájlból, vagy webszolgáltatásból)

    A napi korona adatok XML fájlban érkeznek egy input könyvtárba. A program ezeket olvassa fel és tárolja adatbázisba.
    Source: http://pandemia.hu/koronavirus-megyeterkep-magyarorszagi-adatok-megyei-bontasban/

2. Adatfeldolgozás
A) LINQ lekérdezés használata legalább egy WHERE feltétellel

    A tárolt adatokból le lehet kérdezni egy adott megye adatait, ami a háttérben LINQ lekérdezéssel működik.

3. Adatok exportálása / megjelenítése
A) Írás CSV fájlba

    A program az adatbázist időközönként csv fájlba menti le (backup).

4. Általános elemek
D) Timer használata

    A mentés Timer segítségével történik, ami a programból konfigurálható.
   
