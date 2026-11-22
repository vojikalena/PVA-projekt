
# Specifikace: správa turnaje

## Slovník pojmů
- **Hráč** – účastník turnaje, má jedinečné ID a jméno.
- **Turnaj** – celek: název, hráči, kola, bodovací pravidla.
- **Kolo** – sada zápasů, v nichž každý hráč nastoupí nejvýše jednou.
- **Zápas** – utkání dvou hráčů s výsledkem (výhra 1, výhra 2, remíza, zatím nehraný).
- **Volný los** – hráč bez soupeře v daném kole (při lichém počtu hráčů).
- **Tabulka** – pořadí hráčů podle bodů, při shodě podle počtu výher a abecedy.

## Bodování
| Situace      | Body |
|--------------|------|
| Výhra        | 3    |
| Remíza       | 1    |
| Prohra       | 0    |
| Volný los    | 3    |

Volný los dostane každý hráč nejvýše jednou za turnaj (dostane ho ten,
kdo ho zatím neměl a má nejméně bodů).

## Funkce
1. Vytvořit turnaj (název, bodovací pravidla).
2. Přidat / odebrat hráče (jen před prvním kolem).
3. Vygenerovat další kolo (párování, přidělení volného losu).
4. Zadat / opravit výsledek zápasu.
5. Zobrazit tabulku.
6. Zobrazit historii zápasů hráče.
7. Uložit turnaj do souboru a načíst ho zpět.
