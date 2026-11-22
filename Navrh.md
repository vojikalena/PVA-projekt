# Návrh

## Třídy
- **Bodovani** – body za výhru, remízu, volný los (výchozí 3/1/3).
- **Hrac** – `id`, `jmeno`.
- **Zapas** – `hrac1`, `hrac2` (u volného losu prázdné), `vysledek`.
- **Kolo** – `cislo`, seznam zápasů.
- **Turnaj** – `nazev`, `bodovani`, seznam hráčů, seznam kol;
  metody: přidat hráče, vygenerovat kolo, zadat výsledek, spočítat tabulku.
- **Uloziste** – `ulozit(turnaj, soubor)`, `nacist(soubor)`.

Tabulka se **neukládá**, vždy se počítá z odehraných zápasů. Nemůže se tak
rozejít s výsledky.

## Formát ukládání (`.trn`, textový, jeden záznam na řádek)

    TRN;1
    TURNAJ;Jarní open
    BODOVANI;3;1;3
    HRAC;1;Anna
    HRAC;2;Boris
    HRAC;3;Cyril
    KOLO;1
    ZAPAS;1;2;V1
    ZAPAS;3;-;VOLNO
    KOLO;2
    ZAPAS;2;3;R
    ZAPAS;1;-;VOLNO

Výsledky: `V1` (vyhrál první), `V2`, `R` (remíza), `?` (nehráno).

## Odůvodnění
- **Textový formát po řádcích** – dá se otevřít v editoru, snadno se ladí a porovnává.
- **První řádek s verzí** (`TRN;1`) – formát lze později rozšířit a starší
  soubory poznat.
- **Typ záznamu na začátku řádku** – načítání je jednoduchý průchod řádky.
- **Odkazy přes ID, ne přes jména** – dva hráči se stejným jménem nevadí.
- **Středník jako oddělovač** – ve jménech je zakázaný (nebo se při ukládání
  nahradí), aby formát zůstal jednoznačný.
- **Odvozená data se neukládají** (tabulka, body) – menší soubor, žádné
  nesrovnalosti.
