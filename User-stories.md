**User stories**
####Role####
Pořadatel – člověk ze školního klubu, který turnaj vede, zadává hráče, dvojice a výsledky. Jediný uživatel programu.
Technické požadavky určuje učitel jako zákazník, proto jsou stories psané tak, aby šly snadno měnit a rozšiřovat.
Hráči

**US-01 Přidání hráče**
- Jako pořadatel chci přidat hráče se jménem a přezdívkou, abych ho mohl přihlásit do turnaje.
  - Přezdívka je jedinečná a slouží jako identifikátor.
  - Pokud přezdívka už existuje nebo je prázdná, program to odmítne s vysvětlením.

**US-02 Výpis hráčů**
- Jako pořadatel chci vypsat všechny hráče, abych viděl, koho mám k dispozici.

**US-03 Odebrání hráče**
- Jako pořadatel chci odebrat hráče, abych mohl opravit chybně zadaného člověka.
  - Hráče s odehraným zápasem nejde smazat.
  - Program vysvětlí, proč smazání nebylo možné.
  - Turnaj

**US-04 Založení turnaje**
- Jako pořadatel chci založit turnaj s názvem, disciplínou a počtem kol, abych mohl začít turnaj řídit.
  - Otevřený je vždy jen jeden turnaj.
  - Počet kol musí být kladné číslo, název a disciplína nesmí být prázdné.

**US-05 Přihlášení hráčů do turnaje**
- Jako pořadatel chci přihlásit hráče do turnaje, abych určil, kdo se zúčastní.
  - Jde to jen do začátku prvního kola.

**US-06 Odhlášení hráče z turnaje**
- Jako pořadatel chci hráče z turnaje odhlásit, abych mohl reagovat na to, že někdo nepřijde.
  - Jde to jen do začátku prvního kola.
  - Kola a zápasy

**US-07 Vytvoření kola**
- Jako pořadatel chci vytvořit nové kolo, abych mohl turnaj posouvat dál.
  - Nejde vytvořit víc kol, než je v turnaji nastaveno.
  - Nejde vytvořit nové kolo, dokud předchozí není uzavřené.

**US-08 Ruční určení dvojic**
- Jako pořadatel chci ručně určit dvojice z přihlášených hráčů, protože losování zatím dělám já.
  - Hráč smí být v kole nejvýše jednou.
  - Do dvojice nejde dát hráče se sebou samým ani hráče, který není přihlášený.

**US-09 Volný los**
- Jako pořadatel chci, aby hráč bez soupeře dostal volný los, aby nebyl v turnaji znevýhodněn.
  - Hráči, kteří nejsou zařazeni do žádné dvojice, dostanou volný los automaticky.
  - Volný los se započítá do bodů podle pravidel ve SPECIFIKACE.md.

**US-10 Zadání výsledku zápasu**
- Jako pořadatel chci zadat výsledek zápasu (výhra prvního, výhra druhého, remíza), aby se promítl do tabulky.
  - Nejde zadat výsledek neexistujícího zápasu.
  - Neplatný vstup (text místo čísla, číslo mimo rozsah, prázdný vstup) program ošetří.

**US-11 Oprava výsledku**
- Jako pořadatel chci přepsat už zadaný výsledek, abych mohl opravit překlep.
  - Jde to jen dokud kolo není uzavřené.

**US-12 Uzavření kola**
- Jako pořadatel chci kolo uzavřít, abych mohl potvrdit, že je odehrané, a začít další.
  - Kolo nejde uzavřít, dokud nemají výsledek všechny zápasy.
  - Po uzavření už nejde výsledky měnit.
  - Tabulka

**US-13 Zobrazení tabulky**
- Jako pořadatel chci vidět tabulku s pořadím, hráčem, body a počtem odehraných zápasů, abych věděl, jak turnaj stojí.
  - Tabulka se přepočítá po každém zadaném nebo opraveném výsledku.
  - Body se počítají podle pravidel ve SPECIFIKACE.md včetně volných losů.
  - Při shodě bodů se rozstřel zatím neřeší.

**US-14 Definice pravidel bodování**
- Jako pořadatel chci mít jasně popsané bodování (výhra, remíza, volný los), abych mohl hráčům vysvětlit, jak se pořadí počítá.
  - Pravidla jsou zapsaná ve SPECIFIKACE.md.
  - Hodnoty bodů jsou v kódu na jednom místě, aby šly snadno změnit.
  - Uložení a načtení

**US-15 Uložení rozdělaného turnaje**
- Jako pořadatel chci rozdělaný turnaj uložit, abych mohl program vypnout a pokračovat později.
  - Ukládají se hráči, turnaj, všechna kola, zápasy i výsledky.
  - Formát je popsaný v NAVRH.md i s odůvodněním.

**US-16 Načtení turnaje**
- Jako pořadatel chci uložený turnaj načíst, abych pokračoval tam, kde jsem skončil.
  - Po načtení jde plynule pokračovat (další kolo, výsledky, tabulka).
  - Chybějící soubor program zvládne, například nabídne začít od nuly.
  - Poškozený soubor program zvládne, nespadne a srozumitelně to oznámí.
  - Odolnost a kvalita

**US-17 Ošetření vstupů**
- Jako pořadatel chci, aby program nespadl, když se překlepnu, abych neztratil rozdělaný turnaj.
  - Ošetřený je text místo čísla, číslo mimo rozsah i prázdný vstup.
  - Program po chybě znovu nabídne zadání.

**US-18 Ověření správnosti tabulky**
- Jako pořadatel chci mít doložené, že tabulka počítá správně, abych jí mohl věřit.
  - Ověření proběhne na turnaji se 4–5 hráči a aspoň 3 koly, včetně remízy a volného losu.
  - Výsledek z programu se porovná s ručním výpočtem a srovnání je zdokumentované.
