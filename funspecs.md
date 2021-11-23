# Functional specifications

23.11.2021, verze 2  
Jan Bezouška, janbezouska@outlook.com

## Scénáře
 - Získání objektů
   - jakmile uživatel zapne aplikaci a má přístup k internetu, načtou se nové náhodné objekty z API
   - pokud zapne aplikaci, a přístup k internetu nemá:
     - pokud nikdy předtím nebyly objekty načteny, zobrazí se mu informace o tom, že potřebuje přístup k internetu
     - pokud už předtím objekty načteny byly, načtou se ty
 - Hlavní stránka
   - uživatel se bude pohybovat pouze na hlavní stránce
   - uživatel bude vyhledávat pomocí atributů
   - pokud bude úspěšně vyhledaný alespoň jeden objekt, zobrazí se počet vyhledaných objektu a jejich seznam
   - pokud nebude vyhledaný žádný objekt, uživatel na to bude upozorněn
 - Podrobnosti o objektu
   - uživatel rozklikne libovolný objekt
   - zobrazí se nová stránka s podrobnostmi o daném objektu
   - pokud má uživatel přístup k internetu, zobrazí se více informací
   - pokud uživatel nemá přístup k internetu, bude informován o tom, že má zobrazené omezené informace
 - Získat nové objekty
   - pouze s přístupem k internetu
   - uživatel otevře menu, a klikne na dané tlačítko
   - program vyhledá nové objekty z API

## Uživatelské rozhraní
![ui](https://user-images.githubusercontent.com/76868390/143014434-9cdf866e-3aa9-4260-a1dd-593c26d8f1ec.jpg)
