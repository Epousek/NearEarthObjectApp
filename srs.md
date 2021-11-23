# Software Requirements Specification

17.11., Verze 2  
Jan Bezouška, janbezouska@outlook.com

## Konvence
 - 1 = nejvyšší důležitost
 - 3 = nejnižší důležitost

## Produkt jako celek

Aplikace bude poskytovat seznam asteroidů, ve kterých bude moci uživatel hledat podle různých parametrů.  
Každý asteroid bude mít několik základních informací, podle kterých bude vyhledatelný, a několik detailnějších informací, které se objeví po rozkliknutí, pokud má uživatel přístup k internetu.

## Uživatelské skupiny

Běžný uživatel má lehký zájem o astronomii, a pravděpoboně se nudí nebo nemá co dělat.  
Stráví tak část jeho volného času brouzdáním blízkých astronomických těles.

## Vymezení rozsahu

Aplikace nebude vypisovat všechny dostupné objekty, ale jen malou část z nich vzhledem k tomu, že jich existuje opravdu hodně.

## Předpoklady a závislosti

Aplikace bude závislá na API Nasy, ze které bude čerpat veškerá data. Dále bude závislá na knihovně Newtonsoft.

## Vlastnosti

### Vyhledávání
 - Důležitost = 1
 - Vstupy:
    - atribut podle kterého vyhledávat, např. vzdálenost od země, velikost atd.
    - rozptyl ve kterém vyhledávat (např. od velikosti x do velikosti y)
 - Výstup:
    - seznam objektů, které splňují vstupní požadavky
 - Možnost vyhledat konkrétní číslo s tím, že výsledkem bude nejbližší objekt

### Řazení

 - Důležitost = 2
 - Vstup:
    - atribut, např. doba, kdy proletí kolem země
 - Výstup:
    - seznam seřazený podle atributu

### Zobrazení podrobností

 - Důležitost = 3
 - Vstup:
    - rozkliknutí jakéhokoliv objektu
 - Výstup:
    - zobrazení podrobnějších informací o daném objektu
    - počet informací záleží na tom, zda je mobilní zařízení připojené na internet

 ## Hardwarová rozhraní

 Uživatel musí mít dotykové mobilní zařízení, a alespoň někdy přístup k internetu, který aplikace potřebuje pro získávání infromací.

 ## Softwarová rozhraní

 Aplikace bude testována na Androidu 9, a bude fungovat i na pozdějších verzích. Pravděpoobně bude fungovat i na verzích starších, ale to není zarůčeno.

 ## Výkonnost

 Rychlost bude záviset na rychlosti internetového připojení a mobilního zařízení uživatele.  
 Obecně bude vyhledávání trvat max. 2 vteřiny, a zobrazení detailů 3 vteřiny, většinou bude ale aplikace rychlejší.

## Spolehlivost

Může nastat situace, ve které nebudou načtená data, nebo se nenačtou všechna, pokud mobilní zařízení příjde o připojení k internetu.
