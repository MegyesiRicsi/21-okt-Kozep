-- A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!

-- 9. feladat:
CREATE DATABASE tdhongrie DEFAULT CHARACTER SET UTf8 COLLATE utf8_hungarian_ci;

-- 11. feladat:
DELETE from csapat WHERE id=21

-- 12. feladat:
SELECT nev from versenyzo WHERE nemzetiseg="HUN" ORDER by nev

-- 13. feladat:
select nemzetiseg, COUNT(id) indulokSzama from versenyzo group by nemzetiseg ORDER by COUNT(id) DESC

-- 14. feladat:
SELECT szakasz, ido from eredmeny INNER JOIN versenyzo on eredmeny.versenyzoId=versenyzo.id WHERE versenyzo.nev="Valter Attila"

-- 15. feladat:
select csapat.csapatnev, COUNT(versenyzo.nev)
from csapat
inner join versenyzo on versenyzo.csapatId=csapat.id 
WHERE versenyzo.nemzetiseg="HUN"
GROUP by csapat.csapatNev 
HAVING COUNT(versenyzo.nev)>1

