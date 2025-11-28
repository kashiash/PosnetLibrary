# Specyfikacja Protokołu POSNET

**Oznaczenie dokumentu:** POT-I-DEV-37  
**Wersja:** 5978  
**Data:** 2.11.2023

## Obsługiwane urządzenia

- POSNET THERMAL XL2 ONLINE 2.01
- POSNET THERMAL XL2 ONLINE S 2.01
- POSNET THERMAL HD ONLINE 2.01
- POSNET TEMO ONLINE 2.01
- POSNET TRIO ONLINE 2.01
- POSNET POSPAY ONLINE 2.01
- POSNET THERMAL HX 1.01
- POSNET THERMAL HX S 1.01
- POSNET VERO 2.01
- POSNET EVO 1.01
- FAWAG BOX 1.01

---

# Spis treści

## Ogólny opis protokołu

- [Ogólny opis protokołu](#ogólny-opis-protokołu)
- [Budowa ramki protokołu](#budowa-ramki-protokołu)
- [Suma kontrolna](#suma-kontrolna)
- [Odpowiedzi drukarki](#odpowiedzi-drukarki)
- [Błędy ramki](#błędy-ramki)
- [Typy danych](#typy-danych)
- [Tryby wykonania poleceń](#tryby-wykonania-poleceń)

## Sekwencje sterujące

- [rtcset - Ustawianie daty i czasu](#rtcset-ustawianie-daty-i-czasu)
- [rtcget - Odczyt daty i czasu](#rtcget-odczyt-daty-i-czasu)
- [rtcsync - Wywołanie synchronizacji czasu przez protokół](#rtcsync-wywołanie-synchronizacji-czasu-przez-protokół)
- [vatset - Programowanie stawek PTU](#vatset-programowanie-stawek-ptu)
- [vatget - Odczyt stawek PTU](#vatget-odczyt-stawek-ptu)
- [vatautoset - Programowanie automatycznej zmiany stawek PTU](#vatautoset-programowanie-automatycznej-zmiany-stawek-ptu)
- [vatautoget - Odczyt automatycznej zmiany stawek PTU](#vatautoget-odczyt-automatycznej-zmiany-stawek-ptu)
- [hdrset - Programowanie nagłówka](#hdrset-programowanie-nagłówka)
- [hdrget - Odczyt nagłówka](#hdrget-odczyt-nagłówka)
- [ftrinfoget - Odczytywanie linii informacyjnych w stopce](#ftrinfoget-odczytywanie-linii-informacyjnych-w-stopce)
- [ftrinfoset - Programowanie linii informacyjnych w stopce](#ftrinfoset-programowanie-linii-informacyjnych-w-stopce)
- [fiscalize - Fiskalizacja](#fiscalize-fiskalizacja)

---

# Ogólny opis protokołu

## Budowa ramki protokołu

Ramka protokołu składa się z następujących elementów:

| Pole | Wartość | Uwagi |
|------|---------|-------|
| STX | 02h | Rozpoczyna ramkę |
| id_polecenia | Mnemonik polecenia | Identyfikator polecenia |
| TAB | 09h | Znak tabulacji. Występuje po każdym identyfikatorze polecenia lub parametrze |
| ... | | |
| id_parametru | Dwu znakowy mnemonik parametru | Identyfikator parametru poprzedza każdy parametr. Kolejność parametrów jest dowolna w każdej sekwencji |
| Wartość parametru | Tekst lub liczba w zapisie dziesiętnym | Ilość parametrów w sekwencji jest zależna od polecenia |
| TAB | 09h | Po każdym parametrze zawsze występuje znak tabulacji |
| TOKEN | @XXXX | Opcjonalne pole. Token rozpoczyna się od znaku @ (40h) i występuje w postaci czterech cyfr dziesiętnych. Może występować w dowolnym miejscu między id_polecenia a #CRC16 |
| TAB | 09h | Po tokenie także należy przesłać tabulację |
| ... | | |
| # | Znak '#' | Znak poprzedzający sumę kontrolną |
| CRC16 | Liczba w zapisie szesnastkowym | Suma kontrolna liczona na podstawie algorytmu CRC16-CCITT |
| ETX | 03h | Kończy ramkę protokołu |

## Suma kontrolna

Przy obliczaniu sumy kontrolnej ramki protokołu nie bierze się pod uwagę znaków: STX, ETX oraz znaku '#' poprzedzającego sumę kontrolną.

Suma kontrolna sekwencji liczona jest wg wariantu algorytmu CRC16-CCITT o parametrach:

| Parametr algorytmu | Używana wartość | Opis |
|-------------------|----------------|------|
| poly | 0x1021 | Użyty wielomian |
| init | 0x0000 | Wartość początkowa sumy |
| refin | Nie (False) | Czy odwracać bity na wejściu? |
| refout | Nie (False) | Czy odwracać bity na wyjściu? |
| xorout | 0x0000 | Wartość z którą otrzymana suma jest xorowana w ostatnim etapie obliczania |

Użytą implementację można zwyczajowo zweryfikować obliczając sumę z napisu "123456789". Oczekiwana wartość to 0x31c3.

### Przykładowa implementacja w języku C

```c
unsigned char crc16htab[] = {
    0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70,
    0x81, 0x91, 0xa1, 0xb1, 0xc1, 0xd1, 0xe1, 0xf1,
    0x12, 0x02, 0x32, 0x22, 0x52, 0x42, 0x72, 0x62,
    0x93, 0x83, 0xb3, 0xa3, 0xd3, 0xc3, 0xf3, 0xe3,
    0x24, 0x34, 0x04, 0x14, 0x64, 0x74, 0x44, 0x54,
    0xa5, 0xb5, 0x85, 0x95, 0xe5, 0xf5, 0xc5, 0xd5,
    0x36, 0x26, 0x16, 0x06, 0x76, 0x66, 0x56, 0x46,
    0xb7, 0xa7, 0x97, 0x87, 0xf7, 0xe7, 0xd7, 0xc7,
    0x48, 0x58, 0x68, 0x78, 0x08, 0x18, 0x28, 0x38,
    0xc9, 0xd9, 0xe9, 0xf9, 0x89, 0x99, 0xa9, 0xb9,
    0x5a, 0x4a, 0x7a, 0x6a, 0x1a, 0x0a, 0x3a, 0x2a,
    0xdb, 0xcb, 0xfb, 0xeb, 0x9b, 0x8b, 0xbb, 0xab,
    0x6c, 0x7c, 0x4c, 0x5c, 0x2c, 0x3c, 0x0c, 0x1c,
    0xed, 0xfd, 0xcd, 0xdd, 0xad, 0xbd, 0x8d, 0x9d,
    0x7e, 0x6e, 0x5e, 0x4e, 0x3e, 0x2e, 0x1e, 0x0e,
    0xff, 0xef, 0xdf, 0xcf, 0xbf, 0xaf, 0x9f, 0x8f,
    0x91, 0x81, 0xb1, 0xa1, 0xd1, 0xc1, 0xf1, 0xe1,
    0x10, 0x00, 0x30, 0x20, 0x50, 0x40, 0x70, 0x60,
    0x83, 0x93, 0xa3, 0xb3, 0xc3, 0xd3, 0xe3, 0xf3,
    0x02, 0x12, 0x22, 0x32, 0x42, 0x52, 0x62, 0x72,
    0xb5, 0xa5, 0x95, 0x85, 0xf5, 0xe5, 0xd5, 0xc5,
    0x34, 0x24, 0x14, 0x04, 0x74, 0x64, 0x54, 0x44,
    0xa7, 0xb7, 0x87, 0x97, 0xe7, 0xf7, 0xc7, 0xd7,
    0x26, 0x36, 0x06, 0x16, 0x66, 0x76, 0x46, 0x56,
    0xd9, 0xc9, 0xf9, 0xe9, 0x99, 0x89, 0xb9, 0xa9,
    0x58, 0x48, 0x78, 0x68, 0x18, 0x08, 0x38, 0x28,
    0xcb, 0xdb, 0xeb, 0xfb, 0x8b, 0x9b, 0xab, 0xbb,
    0x4a, 0x5a, 0x6a, 0x7a, 0x0a, 0x1a, 0x2a, 0x3a,
    0xfd, 0xed, 0xdd, 0xcd, 0xbd, 0xad, 0x9d, 0x8d,
    0x7c, 0x6c, 0x5c, 0x4c, 0x3c, 0x2c, 0x1c, 0x0c,
    0xef, 0xff, 0xcf, 0xdf, 0xaf, 0xbf, 0x8f, 0x9f,
    0x6e, 0x7e, 0x4e, 0x5e, 0x2e, 0x3e, 0x0e, 0x1e
};

unsigned char crc16ltab[] = {
    0x00, 0x21, 0x42, 0x63, 0x84, 0xa5, 0xc6, 0xe7,
    0x08, 0x29, 0x4a, 0x6b, 0x8c, 0xad, 0xce, 0xef,
    0x31, 0x10, 0x73, 0x52, 0xb5, 0x94, 0xf7, 0xd6,
    0x39, 0x18, 0x7b, 0x5a, 0xbd, 0x9c, 0xff, 0xde,
    0x62, 0x43, 0x20, 0x01, 0xe6, 0xc7, 0xa4, 0x85,
    0x6a, 0x4b, 0x28, 0x09, 0xee, 0xcf, 0xac, 0x8d,
    0x53, 0x72, 0x11, 0x30, 0xd7, 0xf6, 0x95, 0xb4,
    0x5b, 0x7a, 0x19, 0x38, 0xdf, 0xfe, 0x9d, 0xbc,
    0xc4, 0xe5, 0x86, 0xa7, 0x40, 0x61, 0x02, 0x23,
    0xcc, 0xed, 0x8e, 0xaf, 0x48, 0x69, 0x0a, 0x2b,
    0xf5, 0xd4, 0xb7, 0x96, 0x71, 0x50, 0x33, 0x12,
    0xfd, 0xdc, 0xbf, 0x9e, 0x79, 0x58, 0x3b, 0x1a,
    0xa6, 0x87, 0xe4, 0xc5, 0x22, 0x03, 0x60, 0x41,
    0xae, 0x8f, 0xec, 0xcd, 0x2a, 0x0b, 0x68, 0x49,
    0x97, 0xb6, 0xd5, 0xf4, 0x13, 0x32, 0x51, 0x70,
    0x9f, 0xbe, 0xdd, 0xfc, 0x1b, 0x3a, 0x59, 0x78,
    0x88, 0xa9, 0xca, 0xeb, 0x0c, 0x2d, 0x4e, 0x6f,
    0x80, 0xa1, 0xc2, 0xe3, 0x04, 0x25, 0x46, 0x67,
    0xb9, 0x98, 0xfb, 0xda, 0x3d, 0x1c, 0x7f, 0x5e,
    0xb1, 0x90, 0xf3, 0xd2, 0x35, 0x14, 0x77, 0x56,
    0xea, 0xcb, 0xa8, 0x89, 0x6e, 0x4f, 0x2c, 0x0d,
    0xe2, 0xc3, 0xa0, 0x81, 0x66, 0x47, 0x24, 0x05,
    0xdb, 0xfa, 0x99, 0xb8, 0x5f, 0x7e, 0x1d, 0x3c,
    0xd3, 0xf2, 0x91, 0xb0, 0x57, 0x76, 0x15, 0x34,
    0x4c, 0x6d, 0x0e, 0x2f, 0xc8, 0xe9, 0x8a, 0xab,
    0x44, 0x65, 0x06, 0x27, 0xc0, 0xe1, 0x82, 0xa3,
    0x7d, 0x5c, 0x3f, 0x1e, 0xf9, 0xd8, 0xbb, 0x9a,
    0x75, 0x54, 0x37, 0x16, 0xf1, 0xd0, 0xb3, 0x92,
    0x2e, 0x0f, 0x6c, 0x4d, 0xaa, 0x8b, 0xe8, 0xc9,
    0x26, 0x07, 0x64, 0x45, 0xa2, 0x83, 0xe0, 0xc1,
    0x1f, 0x3e, 0x5d, 0x7c, 0x9b, 0xba, 0xd9, 0xf8,
    0x17, 0x36, 0x55, 0x74, 0x93, 0xb2, 0xd1, 0xf0
};

unsigned char hi = 0, lo = 0, index;
const char *s = "Ala ma kota.";

printf("crc od '%s' wynosi: ", s);
for (s; *s; s++) {
    index = hi ^ *s;
    hi = lo ^ crc16htab[index];
    lo = crc16ltab[index];
}
printf("%04X", (hi << 8) | lo);
```

### Przykład obliczania sumy kontrolnej sekwencji

Dla sekwencji: `[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]`

1. Odrzucamy STX, ETX oraz sumę kontrolną wraz z poprzedzającym znakiem '#' i otrzymujemy:
   ```
   trinit[TAB]bm0[TAB]
   ```

2. Po zastosowaniu algorytmu otrzymujemy wartość: `0x4825`

3. Co daje nam ramkę do wysłania w postaci:
   ```plaintext
   [STX]trinit[TAB]bm0[TAB]#4825[ETX]
   ```

## Odpowiedzi drukarki

**Standardowa odpowiedź drukarki** w przypadku przyjęcia poprawnej sekwencji:
```plaintext
[STX]identyfikator_rozkazu[TAB]#CRC16[ETX]
```

**Odpowiedź drukarki** w przypadku przyjęcia niepoprawnej sekwencji lub błędu jej wykonania:
```plaintext
[STX]identyfikator_rozkazu[TAB]?nnnn#CRC16[ETX]
```

gdzie `nnnn` – numer błędu, liczba w zapisie dziesiętnym.

## Błędy ramki

Budowa ramki odpowiedzi drukarki na przyjęcie błędnej ramki protokołu:

```plaintext
STX ERR TAB [@TOKEN TAB] ?ERR_NO TAB [cmID_POLECENIA TAB [fdNAZWA_POLA TAB]] CRC16 ETX
```

**Opis pól:**

- **STX** – znak rozpoczynający ramkę (02h)
- **ERR** – napis "ERR", oznacza ramkę wysłaną przez drukarkę jako odpowiedź na błędną ramkę
- **TAB** – tabulator (09h), separator pól ramki
- **@TOKEN** – token poprzedzony zawsze znakiem '@' (pole opcjonalne)
- **?**, **cm**, **fd** – nazwy pól ramki, poprzedzają odsyłane dane
- **ERR_NO** – numer błędu. Wykaz błędów znajduje się w ostatnim rozdziale specyfikacji
- **ID_POLECENIA** – identyfikator rozpoznanego polecenia w którym został znaleziony błąd (pole opcjonalne)
- **NAZWA_POLA** – nazwa pola w którym został wykryty błąd (pole opcjonalne)
- **CRC** – suma kontrolna
- **ETX** – znak kończący ramkę (03h)

## Typy danych

### Num.
Wartość numeryczna w zapisie dziesiętnym. Separator części ułamkowej: "." lub "," (przecinek lub kropka).

### Kwota
Typ określający wartość kwotową (np.: cena towaru, wartość rabatu kwotowego). Wartość maksymalna wynosi 9999999999.

W tym typie danych nie przesyła się separatora części ułamkowej. Dwie ostatnie cyfry stanowią część ułamkową.

### Totalizer
Totalizer dobowy. Maksymalna wartość wynosi 49999999999. W tym typie danych nie przesyła się separatora części ułamkowej. Dwie ostatnie cyfry stanowią część ułamkową.

### Alfanum
Wartość alfanumeryczna przesyłana za pomocą znaków ASCII. Dopuszczalne są znaki z zakresu 0x20-0xFF – w stronie kodowej WINDOWS-1250 drukowane są wszystkie znaki z zakresu. W innych stronach kodowych powyżej 0x7F drukowane są tylko znaki z alfabetu polskiego w odpowiednim kodowaniu oraz elementy budowy tabeli, pozostałe zamieniane są na spacje.

**Kody znaków (hex) wykorzystywane do budowy tabeli w różnych kodowaniach:**

| Znak | └ | ┘ | ┌ | ┐ | ┴ | ┬ | ├ | ┤ | │ | ─ | ┼ |
|------|---|---|---|---|---|---|---|---|---|---|---|
| WINDOWS-1250 | 81 | 88 | 90 | 98 | A0 | A4 | A8 | AD | B2 | B4 | B8 |
| MAZOVIA | C8 | BC | C9 | BB | CA | CB | CC | B9 | BA | CD | CE |
| LATIN 2 | 81 | 82 | 83 | 84 | 85 | 86 | 87 | 88 | 89 | 8A | 8B |

### Data
Data w formacie `yyyy-mm-dd`. Znak "-" może być zastąpiony znakami: '.' i '/'

### Data i czas
Format: `yyyy-mm-dd,hh:mm`. Znak "," może być zastąpiony przez: spację i ';'.

### Data i czas ISO8601
Format: `YYYY-MM-DDThh:mm:ss±hh:mm`. Dane w standardzie ISO 8601.

### BOOL
Wartość typu Bool. Może przyjmować wartości:

- **dla True:** 1 lub t lub T lub Y lub y
- **dla False:** 0 lub n lub N

## Tryby wykonania poleceń

Urządzenie posiada dwa tryby wykonywania poleceń: synchroniczny i asynchroniczny.

### Tryb synchroniczny
W tym trybie można wysłać wszystkie polecenia protokołu. Przesłane polecenia zapisywane są w buforze odbiorczym i kolejno wykonywane. Odpowiedź na polecenie odsyłana jest po jego wykonaniu.

### Tryb asynchroniczny
W tym trybie można przesłać tylko niektóre polecenia protokołu (`sprn`, `sdev`). Przesłane w tym trybie polecenia wykonywane są natychmiast. Odpowiedzi urządzenia na te polecenia również odsyłane są na bieżąco. Aby polecenie zostało wysłane w trybie asynchronicznym należy jego identyfikator poprzedzić znakiem '!'.

---

# Sekwencje sterujące

## [rtcset] Ustawianie daty i czasu

**Identyfikator polecenia:** `rtcset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| da | Data i czas | TAK | Data i czas | Ograniczenia w działaniu w trybie fiskalnym |
| st | Czy programowany czas jest czasem letnim? | NIE | BOOL | True – czas letni, False – czas zimowy |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. W trybie fiskalnym zakres regulacji zegara ograniczony jest do 2 godzin. Zmianę czasu można wykonać po raporcie dobowym przy zerowych totalizerach.
2. Jeśli parametr st nie został przesłany, urządzenie ustawi czas wg czasu obecnie obowiązującego.
3. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]rtcset[TAB]da2018-08-20;13:02[TAB]#CRC16[ETX]
```

### Wydruk

```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:2|
| N I E F I S K A L N Y |
|PROGRAMOWANIE ZEGARA |
|Zegar przed zmianą: 2018-08-20 13:06|
|Zegar po zmianie: 2018-08-20 13:02|
| N I E F I S K A L N Y |
|#001 KIEROWNIK 2018-08-20 13:02|
|CBB775FF49A970A52795885DD29AE3B786472A36|
| ZBF 1801007587 |
```

---

## [rtcget] Odczyt daty i czasu

**Identyfikator polecenia:** `rtcget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| da | Data i czas | - | Data i czas | |
| tm | Data i czas | - | Data i czas ISO8601 | |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład odpowiedzi

```plaintext
[STX]rtcget[TAB]da2020-10-20;11:49[TAB]tm2020-10-20T11:49:13+02:00[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]rtcget[TAB]#CRC16[ETX]
```

---

## [rtcsync] Wywołanie synchronizacji czasu przez protokół

**Identyfikator polecenia:** `rtcsync`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]rtcsync[TAB]#CRC16[ETX]
```

---

## [vatset] Programowanie stawek PTU

**Identyfikator polecenia:** `vatset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| va | Wartość stawki A w procentach | NIE | Num. | Brak parametru oznacza stawkę nieaktywną. Poprawna przesyłana wartość procentowa stawki zawiera się w granicach (0 – 99,99) |
| vb | Wartość stawki B w procentach | NIE | Num. | |
| vc | Wartość stawki C w procentach | NIE | Num. | |
| vd | Wartość stawki D w procentach | NIE | Num. | |
| ve | Wartość stawki E w procentach | NIE | Num. | |
| vf | Wartość stawki F w procentach | NIE | Num. | |
| vg | Wartość stawki G w procentach | NIE | Num. | |
| da | Aktualna data | NIE | Data | Data jest weryfikowana z bieżącym ustawieniem zegara systemowego. W przypadku braku parametru użytkownik musi potwierdzić datę z klawiatury |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Wartość stawki 100 oznacza stawkę zwolnioną.
2. Wartość stawki 101 oznacza stawkę nieaktywną.
3. Nie można zaprogramować wszystkich stawek jako nieaktywnych.
4. Próba zmiany stawek na takie same jak już są zaprogramowane w urządzeniu, powoduje ominięcie wykonania operacji i odesłanie statusu poprawnego wykonania polecenia.
5. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]vatset[TAB]va23[TAB]vb8[TAB]vc3[TAB]vd0[TAB]ve0[TAB]vf101[TAB]vg100[TAB]#CRC16[ETX]
```

### Wydruk

```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:3|
| N I E F I S K A L N Y |
| ZMIANA STAWEK PTU |
|STARE STAWKI => NOWE STAWKI |
|PTU A 23% PTU A 23%|
|PTU B 8% PTU B 8%|
|PTU C 5% PTU C 3%|
|PTU D 0% PTU D 0%|
|PTU E 1,23% PTU E 0%|
|PTU F ---- PTU F ----|
|G Zwolniona G Zwolniona|
| N I E F I S K A L N Y |
|#001 KIEROWNIK 2018-08-20 13:08|
|18E2CA19A6254C0C5018D179C09708A0621D27D2|
| ZBF 1801007587 |
```

---

## [vatget] Odczyt stawek PTU

**Identyfikator polecenia:** `vatget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| va | Wartość stawki A w procentach | - | Num. | Poprawna wartość procentowa stawki zawiera się w granicach (0 – 99,99). Odsyłane jest zawsze siedem stawek. Wartości przesyłane są z przecinkiem. 101,00 – stawka nieaktywna, 100,00 – stawka zwolniona |
| vb | Wartość stawki B w procentach | - | Num. | |
| vc | Wartość stawki C w procentach | - | Num. | |
| vd | Wartość stawki D w procentach | - | Num. | |
| ve | Wartość stawki E w procentach | - | Num. | |
| vf | Wartość stawki F w procentach | - | Num. | |
| vg | Wartość stawki G w procentach | - | Num. | |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład odpowiedzi

```plaintext
[STX]vatget[TAB]va22,00[TAB]vb7,00[TAB]vc101,00[TAB]vd101,00[TAB]ve101,00[TAB]vf101,00[TAB]vg100,00[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]vatget[TAB]#CRC16[ETX]
```

---

## [vatautoset] Programowanie automatycznej zmiany stawek PTU

**Identyfikator polecenia:** `vatautoset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| on | Włącz/wyłącz automatyczną zmianę stawek PTU | TAK | BOOL | True – automatyczna zmiana stawek włączona, pole daty wymagane. False – automatyczna zmiana stawek wyłączona, pozostałe pola ignorowane |
| va | Wartość stawki A w procentach | NIE | Num. | Brak parametru oznacza stawkę nieaktywną. Poprawna przesyłana wartość procentowa stawki zawiera się w granicach (0 – 99,99) |
| vb | Wartość stawki B w procentach | NIE | Num. | |
| vc | Wartość stawki C w procentach | NIE | Num. | |
| vd | Wartość stawki D w procentach | NIE | Num. | |
| ve | Wartość stawki E w procentach | NIE | Num. | |
| vf | Wartość stawki F w procentach | NIE | Num. | |
| vg | Wartość stawki G w procentach | NIE | Num. | |
| da | Data i czas automatycznej zmiany stawek | NIE | Data i czas | |
| ra | Automatyczna zmiana stawek bez udziału użytkownika | NIE | BOOL | True – użytkownik nie musi potwierdzać wykonania zmiany stawek PTU (jeżeli jest to konieczne wykona się również automatyczny raport dobowy). Domyślnie: False |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Wartość stawki 100 oznacza stawkę zwolnioną.
2. Wartość stawki 101 oznacza stawkę nieaktywną.
3. Nie można zaprogramować wszystkich stawek jako nieaktywnych.
4. Dostępność w trybie tylko do odczytu: NIE.
5. Jeżeli jest to konieczne raport dobowy jest wykonywany automatycznie.
6. Automatyczna zmiana stawek powoduje restart urządzenia. Przesłanie stawek identycznych z już zaprogramowanymi nie powoduje zapisu do pamięci fiskalnej i restartu urządzenia.
7. Jeśli zadeklarowane w poleceniu vatautoset wartości stawek zostaną zaprogramowane w drukarce przed czasem ich automatycznej zmiany, to automatyczna zmiana stawek nie zostanie wywołana.

### Przykład

```plaintext
[STX]vatautoset[TAB]on1[TAB]va22[TAB]vb7,00[TAB]vg100[TAB]da2010-11-11;11:11[TAB]#CRC16[ETX]
```

---

## [vatautoget] Odczyt automatycznej zmiany stawek PTU

**Identyfikator polecenia:** `vatautoget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| on | Stan automatycznej zmiany stawek PTU | - | BOOL | True – automatyczna zmiana stawek włączona. False – automatyczna zmiana stawek wyłączona |
| va | Wartość stawki A w procentach | - | Num. | Jeżeli automatyczna zmiana stawek PTU jest wyłączona, to zwracane są obecne wartości stawek PTU |
| vb | Wartość stawki B w procentach | - | Num. | |
| vc | Wartość stawki C w procentach | - | Num. | |
| vd | Wartość stawki D w procentach | - | Num. | |
| ve | Wartość stawki E w procentach | - | Num. | |
| vf | Wartość stawki F w procentach | - | Num. | |
| vg | Wartość stawki G w procentach | - | Num. | |
| da | Aktualna data | - | Data i czas | Jeżeli automatyczna zmiana stawek PTU jest wyłączona, to zwracana jest aktualna data |
| tm | Aktualna data | - | Data i czas ISO8601 | Jeżeli automatyczna zmiana stawek PTU jest wyłączona, to zwracana jest aktualna data |
| ra | Automatyczna zmiana stawek bez udziału użytkownika | - | BOOL | True – użytkownik nie musi potwierdzać wykonania zmiany stawek PTU (jeżeli jest to konieczne wykona się również automatyczny raport dobowy) |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład odpowiedzi

```plaintext
[STX]vatautoget[TAB]on1[TAB]va22,00[TAB]vb7,00[TAB]vc101,00[TAB]vd101,00[TAB]ve101,00[TAB]vf101,00[TAB]vg100,00[TAB]da2011-11-11;11:11[TAB]tm2011-11-11T11:11:00+01:00[TAB]ra1[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]vatautoget[TAB]#CRC16[ETX]
```

---

## [hdrset] Programowanie nagłówka

**Identyfikator polecenia:** `hdrset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| tx | Treść nagłówka | TAK | Alfanum | Może zawierać znaki formatujące. Maksymalna wielkość nagłówka to 600 bajtów |
| pr | Zapis nagłówka lub wydruk testowy | TAK | BOOL | True – zapis nagłówka, False – wydruk testowy nagłówka bez zapisu |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. **Nagłówek może składać się z następujących pól:**
   - **Nazwa firmy** – ciąg znaków [256] umieszczony między znacznikami `&1…&1` – pole obowiązkowe
   - **Kod pocztowy** – ciąg znaków [6] w formacie NN-NNN (N – cyfra) między znacznikami `&2…&2` – pole obowiązkowe
   - **Miejscowość** – ciąg znaków [70] umieszczony między znacznikami `&3…&3` – pole obowiązkowe
   - **Poczta** – ciąg znaków [70] umieszczony między znacznikami `&4…&4` – pole opcjonalne
   - **Ulica** – ciąg znaków [70] umieszczony między znacznikami `&5…&5` – pole opcjonalne
   - **Numer domu** – ciąg znaków [15] umieszczony między znacznikami `&6…&6` – pole opcjonalne
   - **Numer lokalu** – ciąg znaków [15] umieszczony między znacznikami `&7…&7` – pole opcjonalne
   - **Dane dodatkowe** – ciąg znaków umieszczony poza pozostałymi znacznikami. Dopuszczalne jest jednokrotne umieszczenie dodatkowych danych między znacznikami `&8...&8` – powoduje to ustawienie limitu danych ograniczonych tymi znakami do ciągu znaków [280] – pole opcjonalne

2. Dane przesłane w nagłówku (z wyjątkiem "Danych dodatkowych") są wykorzystane do utworzenia pliku JPK.

3. **Formatowanie tekstu:**
   - **wyśrodkowanie** – tekst ujęty między znacznikami `&c…&c`. Wyśrodkowanie stosuje się do całej linii. Nie jest konieczne kończenie wyśrodkowanego tekstu znacznikiem `&c`
   - **podwyższenie** – tekst ujęty między znacznikami `&h…&h`
   - **poszerzenie** – tekst ujęty między znacznikami `&b…&b`
   - **podkreślenie** – tekst ujęty między znacznikami `&u…&u`
   - **pochylenie** – tekst ujęty między znacznikami `&i…&i`
   - **negatyw** – tekst ujęty między znacznikami `&N…&N`
   - **czcionka powiększona 4-krotnie** – tekst w linii w której wystąpił przynajmniej jeden znacznik `&H`. Powiększenie 4-krotne stosuje się do całej linii. Znacznik `&H` może wystąpić na dowolnej pozycji w linii
   - **czcionka pogrubiona, zmniejszona odległość między znakami** – tekst ujęty między znacznikami `&s…&s`

4. Treść pól nagłówka można dzielić na linie za pomocą znaku końca linii LF (0x0A). Dzielenie dozwolone jest dla wszystkich pól z wyjątkiem pola "Kod pocztowy". W jednej linii można użyć 10 formatowań tekstu.

5. W jednej linii może być wydrukowane do 56 lub 40 znaków – w zależności od użytego mechanizmu drukującego i ustawień drukarki. Dla formatu tekstu poszerzonego (`&b…&b`) - limit ten zmniejsza się 2-krotnie, a dla czcionki powiększonej 4-krotnie (`&H`) - limit znaków w linii zmniejsza się 4-krotnie.

6. Znak '&' uzyskuje się poprzez '&&'.

7. Znak znajdujący się za pojedynczym znakiem '&' - nie jest drukowany.

8. W urządzeniach w których można stosować różne szerokości papieru, przy linii o maksymalnej długości zaprogramowanej w trybie 80mm/56znaków, po przełączeniu w tryb drukowania 40 znaków na linię, nastąpi zawinięcie tekstu z zachowaniem formatowania w przeniesionym tekście.

9. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]hdrset[TAB]tx&c&1Sklep SPOŻYWCZY KONFITURA&1&c[LF]ul. &c&5Gruszkowa&5&c &6123&6[LF]&c&202-281&2 &3Warszawa&3&c[LF]&c&8Otwarte poniedziałek-sobota 7-18&8&c[TAB]pr0[TAB]#CRC16[ETX]
```

### Wydruk

```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:8|
| N I E F I S K A L N Y |
| WYDRUK TESTOWY |
| |
|- - - - - - - - - - - - - - - - - - - - |
| Sklep SPOŻYWCZY KONFITURA |
| ul. Gruszkowa 123 |
| 02-281 Warszawa |
| Otwarte poniedziałek-sobota 7-18 |
|- - - - - - - - - - - - - - - - - - - - |
| DANE WYSYŁANE W JPK |
| |
|Nazwa firmy: Sklep SPOŻYWCZY KONFITURA |
|Kod pocztowy: 02-281 |
|Miejscowość: Warszawa |
|Poczta: |
|Ulica: Gruszkowa |
|Numer domu: 123 |
|Numer lokalu: |
|- - - - - - - - - - - - - - - - - - - - |
| N I E F I S K A L N Y |
|#001 KIEROWNIK 2018-08-20 13:22|
|21FB85A7B68FDF5CF6230CE056A0CFDEF0A6D7E0|
| ZBF 1801007587 |
```

---

## [hdrget] Odczyt nagłówka

**Identyfikator polecenia:** `hdrget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| tx | Treść nagłówka | - | Alfanum | Może zawierać znaki formatujące |

### Uwagi

1. Zwracane formatowanie, może różnić się od przesłanego w rozkazie programującym nagłówek pod względem kolejności odsyłanych znaków formatujących i braku końcowych znaków formatujących kończących daną linię. Kolejność odsyłanych znaków formatujących: `&c`, `&H`, `&b`, `&h`, `&u`, `&i`, `&N`, `&s`.

2. Użyty podczas programowania nagłówka znacznik `&w` jest odsyłany jako `&b`.

3. Dostępność w trybie tylko do odczytu: TAK.

### Przykład odpowiedzi

```plaintext
[STX]hdrget[TAB]tx&c&b&1Sklep KONFITURA&1[LF]&cul. &5Gruszkowa&5 &6123&6[LF]&c&202-281&2 &3Warszawa&3[LF]&c&8Otwarte poniedziałek-sobota 7-18&8[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]hdrget[TAB]#CRC16[ETX]
```

---

## [ftrinfoget] Odczytywanie linii informacyjnych w stopce

**Identyfikator polecenia:** `ftrinfoget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| tx | Treść linii informacyjnych w stopce. Linie rozdzielone są znakiem LF (0Ah) | - | Alfanum | W urządzeniu mogą być zaprogramowane maksymalnie trzy linie informacyjne |

### Uwagi

1. Zasady odsyłania takie jak dla rozkazu hdrget.
2. Dostępność w trybie tylko do odczytu: TAK.

### Przykład odpowiedzi

```plaintext
[STX]ftrinfoget[TAB]@6[TAB]tx&c&hDziękujemy[LF]&c&hZAPRASZAMY[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]ftrinfoget[TAB]#CRC16[ETX]
```

---

## [ftrinfoset] Programowanie linii informacyjnych w stopce

**Identyfikator polecenia:** `ftrinfoset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| tx | Treść linii informacyjnych w stopce | TAK | Alfanum | W urządzeniu można zaprogramować maksymalnie trzy linie informacyjne. Wszystkie puste linie na początku i na końcu parametru tx są pomijane. Nadmiarowe linie przesłane w parametrze tx są pomijane |
| lb | Czy wydruk na wszystkich dokumentach? | NIE | BOOL | False – tylko na następnym wydruku dowolnego typu. True – na wszystkich kolejnych: paragonach, fakturach, wydrukach rozliczenia opakowań oraz wydrukach opisanych w rozdziale Formatki – wydruki niefiskalne. Domyślnie False |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Znaki formatujące i ich zastosowanie jak w hdrset:
   - `&b` – czcionka poszerzona
   - `&c` – wyśrodkowanie tekstu
   - `&h` – czcionka wysoka
   - `&u` – czcionka podkreślona
   - `&w` – czcionka poszerzona
   - `&i` – kursywa
   - `&N` – czcionka w negatywie
   - `&H` – czcionka powiększona 4 krotnie
   - `&s` – czcionka pogrubiona, zmniejszona odległość między znakami

2. W obecnej wersji `&w` i `&b` oznaczają taki sam format tekstu.

3. Znak '&' uzyskuje się poprzez `&&`

4. Znak znajdujący się za pojedynczym znakiem `&` - nie jest drukowany.

5. Wybrany rodzaj formatowania będzie obowiązywał od pierwszego wystąpienia danego znaku formatującego do następnego wystąpienia tego znaku - albo do końca linii. W jednej linii może znaleźć się 10 znaków rozpoczynających formatowanie i 10 kończących. Wyśrodkowanie tekstu (`&c`) i formatowanie `&H` obowiązuje całą linię.

6. Znak LF (0Ah) rozdziela linie.

7. Aby zrezygnować z drukowania zaprogramowanych linii, należy wysłać do drukarki polecenie z pustym parametrem tx.

8. W jednej linii może być wydrukowane do 56 lub 40 znaków – w zależności od użytego mechanizmu drukującego i ustawień drukarki. Dla formatu tekstu poszerzonego (`&b…&b`) - limit ten zmniejsza się 2-krotnie, a dla czcionki powiększonej 4-krotnie (`&H`) - limit znaków w linii zmniejsza się 4-krotnie.

9. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]ftrinfoset[TAB]tx&c&hDZIĘKUJEMY&c&h[LF]&c&hZAPRASZAMY PONOWNIE&c&h[TAB]#CRC16[ETX]
```

---

## [fiscalize] Fiskalizacja

**Identyfikator polecenia:** `fiscalize`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| ni | Numer NIP | TAK | Alfanum | 10 znaków, tylko cyfry |
| dl | Typ licznika paragonów | NIE | BOOL | True – licznik dobowy, False – licznik ciągły |
| rn | Numer ewidencyjny | NIE | Alfanum | Do 14 znaków |
| da | Aktualna data i czas | NIE | Data i czas | |
| pr | Drukowanie raportu fiskalizacji | NIE | BOOL | True – raport jest drukowany (domyślnie), False – brak wydruku |
| ut | Typ użytkowania | NIE | Num. | 1 – stała, 2 – rezerwowa, 3 – mobilna, 5 – inny |
| ot | Typ własności | NIE | Num. | 1 – własność, 2 – dzierżawa, 3 – leasing, 4 – wynajem, 5 – inny |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Do przeprowadzenia fiskalizacji należy uprzednio zaprogramować odpowiednie dane za pomocą instrukcji `hdrset`, `vatset`, `servicedataset`, `servicemandataset`.

2. Przesłanie parametru rn (numer ewidencyjny) jest jednoznaczne z ponowną fiskalizacją drukarki. W przypadku fiskalizacji pierwotnej numer ewidencyjny otrzymywany jest z repozytorium (CRK).

3. Przesłanie poprawnej daty da powoduje że nie trzeba jej potwierdzać na klawiaturze.

4. Typ licznika paragonów dl jest wymagany jeśli zostało przesłane da.

5. Operacja wymaga potwierdzenia poprzez wciśnięcie zwory serwisowej po ukazaniu się komunikatu na wyświetlaczu drukarki.

6. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]fiscalize[TAB]ni1234567890[TAB]da2018-08-20;11:48[TAB]#CRC16[ETX]
```

### Wydruk

**Wydruk przed potwierdzeniem:**

```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
| nr:6|
| N I E F I S K A L N Y |
|- - - - - - - - - - - - - - - - - - - - |
|STAWKI PTU |
|PTU A 23% PTU B 8% PTU C 5% |
|PTU D 0% PTU E 1,23% G Zwolniona |
|- - - - - - - - - - - - - - - - - - - - |
| NIP 5222628262 |
|KATEGORIA OGÓLNA|
|TYP UŻYTKOWANIA MOBILNA|
|TYP WŁASNOŚCI WŁASNA|
|FISKALNY LICZNIK PARAGONÓW DOBOWY|
|NR FABRYCZNY PO808131055|
|NR PAMIĘCI CHRONIONEJ 1|
|DRUKARKA FISKALNA |
| POSNET THERMAL XL2 ONLINE|
|WERSJA PROGRAMU PRACY 2.01.12345678|
|- - - - - - - - - - - - - - - - - - - - |
|NIP SERWISU 5222628262|
|DANE SERWISANTA Jan Kowalski|
|SERWISANT ID CRP00001|
|- - - - - - - - - - - - - - - - - - - - |
|WALUTA EWIDENCYJNA PLN|
|- - - - - - - - - - - - - - - - - - - - |
| POTWIERDZAM ZGODNOŚĆ DANYCH |
| |
| |
| |
| ...........................… |
| |
| N I E F I S K A L N Y |
|#001 SERWIS 2018-08-20 11:48|
|484D121281231F9ACAACBDEEF333A73287E64843|
| ZBF 1801007587 |
```

**Wydruk po potwierdzeniu zamiaru kontynuowania fiskalizacji:**

```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:1|
| RAPORT FISKALNY FISKALIZACJI |
|- - - - - - - - - - - - - - - - - - - - |
|FISKALIZACJA 2018-08-20 11:49|
|- - - - - - - - - - - - - - - - - - - - |
|STAWKI PTU |
|PTU A 23% PTU B 8% PTU C 5% |
|PTU D 0% PTU E 1,23% G Zwolniona |
|- - - - - - - - - - - - - - - - - - - - |
|KATEGORIA OGÓLNA|
|FISKALNY LICZNIK PARAGONÓW DOBOWY|
|NR EWIDENCYJNY 2018/000003892|
|NR FABRYCZNY PO808131055|
|NR PAMIĘCI CHRONIONEJ 1|
|DRUKARKA FISKALNA |
| POSNET THERMAL XL2 ONLINE|
|WERSJA PROGRAMU PRACY 2.01.12345678|
|- - - - - - - - - - - - - - - - - - - - |
|NIP SERWISU 5222628262|
|DANE SERWISANTA Jan Kowalski|
|SERWISANT ID CRP00001|
|- - - - - - - - - - - - - - - - - - - - |
|WALUTA EWIDENCYJNA PLN|
|- - - - - - - - - - - - - - - - - - - - |
|#001 SERWIS 2018-08-20 11:49|
|A32211AE5DDFE25FCDB8FAEE4D0FCEA6F2F5A36D|
| {PL} ZBF 1801007587 |
```

---

## [taxofficedataset] Programowanie danych urzędu skarbowego

**Identyfikator polecenia:** `taxofficedataset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| us | Identyfikator urzędu skarbowego | TAK | Alfanum | Rozmiar 4-10 znaków. Tylko cyfry |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Polecenie pozostawione dla kompatybilności, nie ma wpływu na pracę urządzenia.
2. Polecenie działa tylko w trybie niefiskalnym.
3. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]taxofficedataset[TAB]us456[TAB]#CRC16[ETX]
```

---

## [taxofficedataget] Odczyt danych urzędu skarbowego

**Identyfikator polecenia:** `taxofficedataget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| us | Identyfikator urzędu skarbowego | - | Alfanum | |

### Uwagi

1. Polecenie pozostawione dla kompatybilności, zwraca pusty napis.
2. Polecenie działa tylko w trybie niefiskalnym.

### Przykład odpowiedzi

```plaintext
[STX]taxofficedataget[TAB]us456[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]taxofficedataget[TAB]#CRC16[ETX]
```

---

## [servicedataset] Programowanie danych serwisu

**Identyfikator polecenia:** `servicedataset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| ni | NIP serwisu | TAK | Alfanum | 10 znaków, tylko cyfry |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Polecenie działa tylko w trybie niefiskalnym.
2. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]servicedataset[TAB]ni1234567890[TAB]#CRC16[ETX]
```

---

## [servicedataget] Odczyt danych serwisu

**Identyfikator polecenia:** `servicedataget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| ni | NIP serwisu | - | Alfanum | |

### Uwagi

1. Polecenie działa tylko w trybie niefiskalnym.
2. Dostępność w trybie tylko do odczytu: NIE.

### Przykład odpowiedzi

```plaintext
[STX]servicedataget[TAB]ni1234567890[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]servicedataget[TAB]#CRC16[ETX]
```

---

## [servicemandataset] Programowanie danych serwisanta

**Identyfikator polecenia:** `servicemandataset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| na | Nazwisko serwisanta | TAK | Alfanum | Do 40 znaków |
| id | Numer serwisanta | TAK | Alfanum | Do 10 znaków |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Polecenie działa tylko w trybie niefiskalnym.
2. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]servicemandataset[TAB]naJan Kowalski[TAB]id286348[TAB]#CRC16[ETX]
```

---

## [servicemandataget] Odczyt danych serwisanta

**Identyfikator polecenia:** `servicemandataget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| na | Nazwisko serwisanta | - | Alfanum | |
| id | Numer serwisanta | - | Alfanum | |

### Uwagi

1. Polecenie działa tylko w trybie niefiskalnym.

### Przykład odpowiedzi

```plaintext
[STX]servicemandataget[TAB]naJan Kowalski[TAB]id286348[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]servicemandataget[TAB]#CRC16[ETX]
```

---

## [auth] Wprowadzanie kodu autoryzacyjnego

**Identyfikator polecenia:** `auth`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| co | Kod autoryzacyjny | TAK | Alfanum | Długość 14 znaków |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]auth[TAB]co05301311570451[TAB]#CRC16[ETX]
```

---

## [authcodereset] Anulowanie wprowadzonego kodu autoryzacyjnego

**Identyfikator polecenia:** `authcodereset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| co | Kod autoryzacyjny | TAK | Alfanum | Długość 14 znaków |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.
2. W trybie fiskalnym nie ma możliwości anulowania kodu bezterminowego.
3. Po resecie kodu, drukarka będzie pracować przez 30 dni od dnia, w którym kod został zresetowany a następnie będzie zablokowana, dopóki nie zostanie wprowadzony nowy kod autoryzacyjny.

### Przykład

```plaintext
[STX]authcodereset[TAB]co04058358035856[TAB]#CRC16[ETX]
```

---

## [authstateget] Odczyt stanu autoryzacji

**Identyfikator polecenia:** `authstateget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| il | Ilość pozostałych dni autoryzacji | - | Alfanum | |

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.
2. Wysłanie rozkazu do drukarki autoryzowanej bezterminowo powoduje odesłanie błędu ERR_AUTH_AUTHORIZED.

### Przykład odpowiedzi

```plaintext
[STX]authstateget[TAB]@7654[TAB]il30[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]authstateget[TAB]#CRC16[ETX]
```

---

## [maintenance] Wykonanie przeglądu technicznego

**Identyfikator polecenia:** `maintenance`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| te | Identyfikator serwisanta | TAK | Alfanum | Długość 20 znaków |
| da | Data kolejnego przeglądu | TAK | Data | |
| dc | Bieżąca data do potwierdzenia operacji | NIE | Data | |
| ek | Czy wymieniać klucze automatycznie? | NIE | BOOL | W przypadku zalecanej wymiany kluczy dla: True - wymiana wykona się, False - wymiana nie wykona się. Domyślna wartość: False |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.
2. Operacja wymaga potwierdzenia poprzez wciśnięcie zwory serwisowej po ukazaniu się komunikatu na wyświetlaczu drukarki.
3. Powoduje rejestrację zdarzenia wykonania przeglądu technicznego.
4. Informacja o konieczności wykonania przeglądu drukuje się po raporcie dobowym oraz pokazuje się na wyświetlaczu po włączeniu urządzenia.
5. Sygnalizacja o zbliżającym się terminie przeglądu uruchamiana jest na 14 dni przed zaprogramowaną datą.

### Przykład

```plaintext
[STX]maintenance[TAB]te987789[TAB]da2018-10-30[TAB]dc1982-03-02[TAB]ekN[TAB]#CRC16[ETX]
```

---

## [nextmaintenanceset] Programowanie daty przypomnienia o przeglądzie technicznym

**Identyfikator polecenia:** `nextmaintenanceset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| da | Data następnego przeglądu | TAK | Data | |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Informacja o konieczności wykonania przeglądu drukuje się po raporcie dobowym oraz pokazuje się na wyświetlaczu po włączeniu urządzenia.
2. Sygnalizacja o zbliżającym się terminie przeglądu uruchamiana jest na 14 dni przed zaprogramowaną datą.
3. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]nextmaintenanceset[TAB]da2018-10-30[TAB]#CRC16[ETX]
```

---

## [nextmaintenanceget] Pobranie daty następnego przeglądu serwisowego

**Identyfikator polecenia:** `nextmaintenanceget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| da | Data kolejnego przeglądu | - | Data | |

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.

### Przykład odpowiedzi

```plaintext
[STX]nextmaintenanceget[TAB]da2021-06-09[TAB]#CRC16[ETX]
```

### Przykład

```plaintext
[STX]nextmaintenanceget[TAB]#CRC16[ETX]
```

---

## [serviceintervention] Zarejestrowanie interwencji serwisowej

**Identyfikator polecenia:** `serviceintervention`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| da | Bieżąca data do potwierdzenia operacji | TAK | Data | |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.
2. Operacja wymaga potwierdzenia poprzez wciśnięcie zwory serwisowej po ukazaniu się komunikatu na wyświetlaczu drukarki.

### Przykład

```plaintext
[STX]serviceintervention[TAB]da1982-03-02[TAB]#CRC16[ETX]
```

---

## [opendrwr] Otwieranie szuflady

**Identyfikator polecenia:** `opendrwr`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Polecenie niedostępne w drukarce Temo.
2. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]opendrwr[TAB]#CRC16[ETX]
```

---

## [papfeed] Wysuw papieru

**Identyfikator polecenia:** `papfeed`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| ln | Ilość linii | TAK | Num. | Maksymalna ilość linii nie może przekraczać 20 |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Nie działa przy włączonej oszczędności papieru.
2. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]papfeed[TAB]ln6[TAB]#CRC16[ETX]
```

---

## [prncfgset] Konfiguracja wydruków

**Identyfikator polecenia:** `prncfgset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| nf | Flaga konfiguracji wydruków | NIE | Num. | 1 – wydruki niefiskalne drukowane i zapisywane w pamięci chronionej, 0 – wydruki niefiskalne tylko zapisywane w pamięci chronionej. Brak parametru nie zmienia sposobu dotychczasowego działania urządzenia |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.
2. Przesłanie parametru nf spoza zakresu, powoduje ustawienie wartości nf=1.

### Przykład

```plaintext
[STX]prncfgset[TAB]nf0[TAB]#CRC16[ETX]
```

---

## [prncfgget] Odczyt konfiguracji wydruków

**Identyfikator polecenia:** `prncfgget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| nf | Flaga konfiguracji wydruków | - | Num. | 1 – wydruki niefiskalne drukowane i zapisywane w pamięci chronionej, 0 – wydruki niefiskalne tylko zapisywane w pamięci chronionej |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie dostępne tylko w Pospay, Temo, Trio, Vero, Evo, Fawag Box.

### Przykład

```plaintext
[STX]prncfgget[TAB]#CRC16[ETX]
```

### Przykład odpowiedzi

```plaintext
[STX]prncfgget[TAB]nf0[TAB]#CRC16[ETX]
```

---

## [cancelledsaleprintcfgset] Konfiguracja wydruków paragonów i faktur anulowanych

**Identyfikator polecenia:** `cancelledsaleprintcfgset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| en | Flaga konfiguracji wydruków paragonów i faktur anulowanych | TAK | BOOL | True – drukowanie włączone, False – drukowanie wyłączone |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.
2. Transakcje anulowane zawsze zapisywane są w pamięci urządzenia.

### Przykład

```plaintext
[STX]cancelledsaleprintcfgset[TAB]en0[TAB]#CRC16[ETX]
```

---

## [cancelledsaleprintcfgget] Odczyt konfiguracji wydruków paragonów i faktur anulowanych

**Identyfikator polecenia:** `cancelledsaleprintcfgget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| en | Flaga konfiguracji wydruków paragonów i faktur anulowanych | - | BOOL | True – drukowanie włączone, False – drukowanie wyłączone |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]cancelledsaleprintcfgget[TAB]#CRC16[ETX]
```

---

## [billseparatorset] Konfiguracja wydruku separatora na paragonie

**Identyfikator polecenia:** `billseparatorset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| bl | Flaga konfiguracji wydruku separatora na paragonie | TAK | BOOL | True – drukowanie separatorów wyłączone, False – drukowanie separatorów włączone |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]billseparatorset[TAB]bl1[TAB]#CRC16[ETX]
```

---

## [billseparatorget] Odczyt konfiguracji wydruku separatora na paragonie

**Identyfikator polecenia:** `billseparatorget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| bl | Flaga konfiguracji wydruku separatora na paragonie | - | BOOL | True – drukowanie separatorów wyłączone, False – drukowanie separatorów włączone |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]billseparatorget[TAB]#CRC16[ETX]
```

### Przykład odpowiedzi

```plaintext
[STX]billseparatorget[TAB]bl0[TAB]#CRC16[ETX]
```

---

## [dayreportprintcfgset] Konfiguracja wydruku raportu dobowego

**Identyfikator polecenia:** `dayreportprintcfgset`

### Parametry wejściowe

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| en | Flaga drukowania raportu dobowego | NIE | BOOL | True – raport dobowy z wydrukiem, False – raport dobowy bez wydruku |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]dayreportprintcfgset[TAB]en1[TAB]#CRC16[ETX]
```

---

## [dayreportprintcfgget] Odczyt konfiguracji drukowania raportu dobowego

**Identyfikator polecenia:** `dayreportprintcfgget`

### Parametry wejściowe
Brak

### Odpowiedź urządzenia

| Nazwa | Opis | Wymagany | Typ | Uwagi |
|-------|------|----------|-----|-------|
| en | Flaga drukowania raportu dobowego | - | BOOL | True – raport dobowy z wydrukiem, False – raport dobowy bez wydruku |

### Uwagi

1. Dostępność w trybie tylko do odczytu: TAK.

### Przykład

```plaintext
[STX]dayreportprintcfgget[TAB]#CRC16[ETX]
```

---

## [stocash] Zwrot towaru

**Identyfikator polecenia:** `stocash`

### Parametry wejściowe

| Nazwa | Opis                                         | Wymagany | Typ  | Uwagi                                                        |
|-------|----------------------------------------------|----------|------|--------------------------------------------------------------|
| kw    | Kwota, za którą towar został nabyty         | TAK      | Num. | Do 499999999999. Dwie ostatnie cyfry stanowią część ułamkową |

### Odpowiedź urządzenia
Standardowa

### Uwagi

1. Operacja niefiskalna rejestrująca zwrot towaru za określoną kwotę.
2. Dostępność w trybie tylko do odczytu: NIE.

### Przykład

```plaintext
[STX]stocash[TAB]kw456[TAB]#CRC16[ETX]
```

### Wydruk

```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:156|
| N I E F I S K A L N Y |
|Zwrot towaru 4,56|
| N I E F I S K A L N Y |
|#001 KIEROWNIK 2018-09-10 13:15|
|1D415FF65644899AB140AD5DD26224CC92CFF091|
| ZBF 1801007587 |
```

---

*[Kontynuacja dokumentacji - kolejne funkcje będą dodawane systematycznie...]*
