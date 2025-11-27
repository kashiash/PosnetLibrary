# Posnet



# Obsługa drukarki posnet

To nie jest kopia dokumentacji a jedynie moje notatki jakie robiłem podczas czytanie pdf'a z firmy posnet.

Może zawierać błędy literówki itd.

## Konfiguracja drukarki sieciowej

Po podłączeniu drukarki do sieci należy:

1. **Wejść do menu ustawień sieciowych** w drukarce
2. **Ustawić adres IP na sztywno** - najprawdopodobniej drukarka dostanie adres sieciowy z DHCP, ale dobrze jest ustawić adres statyczny, tak żeby się nie zmieniał na routerze. W przeciwnym razie później będzie ciężko do niej trafić.
3. **Sprawdzić port drukarki** - aby się dowiedzieć na jakim porcie działa drukarka, trzeba wydrukować raporty niefiskalne. W menu raportów niefiskalnych znajduje się raport sieciowy, który zawiera informacje o porcie.

## Testowanie połączenia z drukarką

Po skonfigurowaniu drukarki sieciowej, aby przetestować połączenie:

### Klasa startowa - StartZabawyZDrukarkaTest

**Zacznij od klasy testowej `StartZabawyZDrukarkaTest`** - zawiera wszystkie podstawowe testy potrzebne do rozpoczęcia pracy z drukarką w odpowiedniej kolejności.

Plik: `Posnettests/StartZabawyZDrukarkaTest.cs`

Klasa zawiera:
- **`DailyReportTest()`** - pierwszy test połączenia (raport dobowy) - to pierwsze koty za płoty
- **`SetHeaderTest()`** - ustawienie nagłówka paragonu (nazwa firmy, miejscowość, kod pocztowy)
- **`SetFooterTest()`** - ustawienie stopki paragonu (dodatkowe informacje na dole paragonu)
- **`WszystkiePodstawoweTesty()`** - kompleksowy test wykonujący wszystkie kroki w odpowiedniej kolejności

**WAŻNE:** Przed uruchomieniem testów należy ustawić IP i port drukarki w zmiennych `host` i `port` na początku klasy.

### Szczegółowe kroki testowania

1. **Ustawić IP i port drukarki w testach** - w klasie `StartZabawyZDrukarkaTest` (lub `UnitTest1.cs`) w zmiennych `host` i `port`:
   ```csharp
   string host = "192.168.50.47";
   int port = 6666;
   ```

2. **Wywołać raport dobowy** - uruchomić test `DailyReportTest()`, który wywołuje `PosnetHelper.DailyReport()`. W tym momencie drukarka powinna zareagować i wydrukować raport dobowy.

To pierwsze koty za płoty - podstawowy test połączenia.

### Dodatkowe testy konfiguracji

W pliku `Posnettests/UnitTest1.cs` dostępne są również inne testy pomocne przy konfiguracji i zaawansowanej pracy z drukarką.

## E-paragony - ważne informacje

### Wymagania dotyczące testowania e-paragonów

**WAŻNE:** Aby móc wysyłać testowo e-paragony, drukarka musi być **zafiskalizowana**. 

Niestety nie ma innej możliwości - trzeba się uśmiechnąć do producenta i wyburzyć drukarkę, która jest zafiskalizowana i pozwala wysyłać e-paragony. Bez zafiskalizowanej drukarki testowanie funkcjonalności e-paragonów nie jest możliwe.

### Wysyłanie e-paragonu mailem do klienta

Jeśli chodzi o to, żeby klient dostał e-paragon mailem, to według obecnej wiedzy **trzeba to obrabiać samemu**. 

**Rekomendowane rozwiązanie:**
- Najlepiej wydrukować paragon do **PDF**
- PDF załączyć do maila i wysłać do klienta

**Uwaga:** Obrazek paragonu nie powstaje automatycznie - trzeba to samemu ogarnąć. Przykład z aplikacji Lidla - paragon jest bardzo podobny do drukarkowego, ale to nie jest jego kopia, tylko samodzielnie przygotowany obrazek/PDF.

### Dostępne metody e-paragonów w bibliotece

W bibliotece dostępne są następujące metody do pracy z e-paragonami (znajdują się w klasie `PosnetHelper`):

- `EparagonGet()` - pobranie danych e-paragonu
- `EparagonGetStatus()` - pobranie statusu e-paragonu
- `EparagonSetStatus(int status)` - ustawienie statusu e-paragonu
- `EparagonSetSchedule(...)` - ustawienie harmonogramu wysyłki
- `EparagonGetSchedule()` - pobranie harmonogramu wysyłki
- `EparagonSetServer(string url)` - ustawienie serwera e-paragonów
- `EparagonSetServer(int recNo, string url)` - ustawienie serwera e-paragonów (z numerem rekordu)
- `EparagonTestServerConnection(string url)` - test połączenia z serwerem
- `EparagonSetNextIDZ(string idz)` - ustawienie następnego IDZ
- `EparagonNewDocumentByIDZ(string idz)` - utworzenie nowego dokumentu e-paragonu przez IDZ

Przykładowe testy znajdują się w pliku `Posnettests/UnitTest1.cs`:
- `EparagonReportTest()`
- `EparagongetStatusTest()`
- `EparagonSetStatusTest()`
- `EparagonSetScheduleTest()`
- `EparagonGetScheduleTest()`
- `EparagonSetTest()`
- `EparagonSetServerDodTest()`
- `EparagonServerConnectionTest()`
- `TestSetIDZ()`
- `TestCreateEdocument()`

## Wystawianie faktury VAT na drukarce posnet



 ##  [trfvinit] Rozpoczecie faktury vat  

 Identyfikator polecenia:            trfvinit 

| Nazwa Parametru | Opis                                         | Wymagany | Typ  | Uwagi                                                        |
| --------------- | -------------------------------------------- | -------- | ---- | ------------------------------------------------------------ |
| nm              | Nazwa faktury                                | NIE      | Num. | Do 23 znaków dla parametru In=40. Do 39 znaków dla parametru In=56. |
| cc              | Liczba kopii                                 | NIE      | Num. | Zakres 0 - 9. Domyślnie cc=0                                 |
| co              | Drukowanie na fakturze napisu ORYGINAL/KOPIA | NIE      | BOOL | True - drukowanie wtłaczone, False - brak drukowania. Wartość domyślna określana przez instrukcje `fvcfgset`. |
| In              | Długość linii danych niefiskalnych           | NIE      | Num. | Przyjmuje wartość 40 (domyślnie) lub 56 (tylko dla trybu 56 znaków w linii). Dane niefiskalne przesyłane w poleceniu `trfvfreedata`. |
| fn              | Długość linii danych fiskalnych              | NIE      | Num. | Przyjmuje wartość 40 (domyślnie) lub 56 (tylko dla trybu 56 znaków w linii). |

Odpowiedź urządzenia: standardowa

Uwagi:

1. Udane rozpoczęcie faktury jest możliwe w sytuacji, gdy stan totalizerów dobowych pozwala na wystawienie faktury o maksymalnej wartości (nie ma zagrożenia przepełnienia któregoś totalizera).

2. Po rozpoczęciu transakcji należy wystąpić z niezbędnymi danymi za pomocą rozkazów `trfvbuyer` i `trfvnumber`.

3. Po rozpoczęciu faktury nie można dokonywać: obrotu opakowaniami, używać form płatności, storno, rabatów (dozwolonym rabatem jest rabat w linii transakcji w poleceniu `trline`).

4. Wartość domyślna parametru `co` jest ustawiana przez rozkaz `fvcfgset`, która obowiązuje w przypadku gdy nie przesyła się go w rozpoczęciu faktury. W czasie transakcji obowiązujące są ustawienia przesyłane rozkazem `trfvinit`.

5. Anulowanie transakcji może spowodować wydruk faktury anulowanej, zależnie od konfiguracji (polecenie cancelledsaleprintcfgset). 

6. Dostępność w trybie tylko do odczytu: NIE. 

   

Przykład użycia polecenia trfvinit: 

 `[STX|trfvinit[TAB]nmNazwa_faktury[TAB]cc1[TAB]co1[TAB]#CRC16[ETX]`




```
[STX|trnipset|TAB|ni1112223344|TAB|dw0|TAB|#CRC16|ETX]
```





### [trpayment] Forma płatności w zakończeniu transakcji

**Identyfikator polecenia:** `trpayment`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                  | Wymagany | Typ      | Uwagi                                                        |
| --------------- | --------------------- | -------- | -------- | ------------------------------------------------------------ |
| ty              | Typ formy płatności   | TAK      | Num.     | 0 - gotówka, 2 - karta, 3 - czek, 4 - bon, 5 - kredyt, 6 - inna, 7 - voucher, 8 - przelew |
| wa              | Wartość wpłaty        | TAK      | Kwota    | Wartość wpłaty lub wartość reszty - zależnie od parametru re. Jak w rozkazie trline |
| na              | Nazwa formy płatności | NIE      | Alfanum. | Do 25 znaków. Domyślnie puste.                               |
| re              | Flaga reszty          | NIE      | BOOL     | False - płatność formą płatności, True - wydanie reszty      |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Typem formy płatności nie może być waluta.
2. Dla `ty = 0`, wartość parametru `na` nie znajdzie się na wydruku i w JPK.
3. Musi zostać przestawiona suma form płatności pokrywająca wartość do zapłaty.
4. Polecenie nie jest dostępne podczas drukowania faktury.
5. Dostępność w trybie tylko do odczytu: NIE.

**Przykład:**

```plaintext
[STX]trinit[TAB]bm0[TAB|#CRC16[ETX]
[STX]trline[TAB]naJabłka[TAB]vt1[TAB]pr200[TAB]wa200[TAB]#CRC16[ETX]
[STX]trpayment[TAB]ty2[TAB]wa500[TAB]re0[TAB]#CRC16[ETX] - płatność formą płatności
[STX]trpayment[TAB]ty0[TAB]wa300[TAB]re1[TAB|#CRC16[ETX] - określenie reszty
[STX]trend[TAB]to200[TAB]re300[TAB]fp500[TAB]#CRC16[ETX]
```

W tym przykładzie zaczynamy transakcję, dodajemy linię produktu (jabłka), przypisujemy płatność kartą, a następnie definiujemy płatność gotówką z określoną resztą i kończymy transakcję.

### [trend] Zakończenie transakcji

**Identyfikator polecenia:** `trend`

**Parametry wejściowe:**

| Nazwa | Opis                                               | Wymagany | Typ   | Uwagi                                                        |
| ----- | -------------------------------------------------- | -------- | ----- | ------------------------------------------------------------ |
| to    | Wartość fiskalna w zakończeniu                     | NIE      | Kwota |                                                              |
| op    | Wartość przestanych opakowań dodatnich (wydanych)  | NIE      | Kwota |                                                              |
| om    | Wartość przestanych opakowań ujemnych (zwróconych) | NIE      | Kwota |                                                              |
| fp    | Wartość przestanych form płatności                 | NIE      | Kwota |                                                              |
| re    | Wartość przestanej reszty                          | NIE      | Kwota |                                                              |
| fe    | Flaga automatycznego zakończenia stopki            | NIE      | BOOL  | True - bez przestawiania opakowań, dodatkowych linii (domyślnie) False - z przestawianiem |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Wartość fiskalna musi się zgadzać z wartością fiskalną paragonu.
2. Wartość form płatności i opakowań musi być zgodna z wartościami wcześniej przestanymi.
3. Wartość przestanych form płatności musi być równa lub większa od wartości do zapłaty.
4. Przestane reszty muszą spełnić warunek: FORMY_PŁATNOŚCI - RESZTA = DO_ZAPŁATY
5. Jeśli przestane formy płatności przekraczają kwotę DO ZAPŁATY i reszty nie zostały przestane, urządzenie samo liczy resztę.
6. Dostępność w trybie tylko do odczytu: NIE.

**Przykład:**

```plaintext
[STX]trend[TAB]to123[TAB]fp123[TAB|#CRC16[ETX]
```

W tym przykładzie zakończono transakcję, podając wartość fiskalną i wartość przestanych form płatności.

### [prncancel] Anulowanie transakcji lub wydruku

**Identyfikator polecenia:** `prncancel`, `trancel`

**Parametry wejściowe:** brak

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Rozkaz `trancel` jest synonimem rozkazu `prncancel`.
2. Dostępność w trybie tylko do odczytu: TAK.

**Przykład:**

```plaintext
[STX]prncancel[TAB]#CRC16[ETX]
```

W tym przykładzie anulowano transakcję lub wydruk.

### [eparagondefaultget] Pobranie konfiguracji domyślnego serwera usługi eDokument

**Identyfikator polecenia:** `eparagondefaultget`

**Parametry wejściowe:** brak

**Odpowiedź urządzenia:**

| Nazwa Parametru | Opis                             | Wymagany | Typ      | Uwagi                                             |
| --------------- | -------------------------------- | -------- | -------- | ------------------------------------------------- |
| ad              | Adres serwera usługi eDokument   | TAK      | Alfanum. | Do 80 znaków (RFC 3986)                           |
| ct              | Typ certyfikatu                  | NIE      | Num.     | 0 - Brak, 1 - Posnet Root, 2 - Odcisk certyfikatu |
| tp              | Odcisk SHA certyfikatu           | NIE      | Alfanum. | 40 znaków - heksadecymalnie                       |
| sg              | Czy wysłać grafikę?              | -        | BOOL     |                                                   |
| sh              | Czy wysłać stopkę?               | -        | BOOL     |                                                   |
| td              | Czy wysłać dane transakcji?      | -        | BOOL     |                                                   |
| hd              | Czy wysłać nagłówek?             | -        | BOOL     |                                                   |
| ex              | Parametr ignorowany.             | -        | BOOL     |                                                   |
| gb              | Czy wysłać dane binarne grafiki? | -        | BOOL     |                                                   |
| ts              | Czas oczekiwania na odpowiedź    | -        | Num.     | Czas w sekundach. Zakres 0 - 120.                 |
| tt              | Czas oczekiwania na wysyłkę      | -        | Num.     | Czas w sekundach. Zakres 0 - 120.                 |

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.

**Przykład:**

```plaintext
[STX]eparagondefaultget[TAB]#CRC16[ETX]
```

### [eparagondefaultset] Ustawienie konfiguracji domyślnego serwera usługi eDokument

**Identyfikator polecenia:** `eparagondefaultset`

**Parametry wejściowe:**

| Nazwa | Opis                                  | Wymagany | Typ      | Uwagi                                                        |
| ----- | ------------------------------------- | -------- | -------- | ------------------------------------------------------------ |
| ad    | Adres serwera usługi eDokument        | NIE      | Alfanum. | Do 80 znaków (RFC 3986) — Z przedrostkiem 'https://' lub<br>Do 72 znaki (RFC 3986) - bez przedrostka 'https://' |
| ct    | Typ certyfikatu                       | NIE      | Num.     | 0 - Brak, 1 - Posnet Root, 2 - Odcisk certyfikatu            |
| tp    | Odcisk SHA certyfikatu                | NIE      | Alfanum. | 40 znaków - heksadecymalnie                                  |
| sg    | Czy wysłać identyfikatory grafik?     | NIE      | BOOL     |                                                              |
| sh    | Czy wysłać stopkę?                    | NIE      | BOOL     |                                                              |
| td    | Czy wysłać dane transakcji?           | NIE      | BOOL     |                                                              |
| hd    | Czy wysłać nagłówek?                  | NIE      | BOOL     |                                                              |
| eX    | Parametr ignorowany.                  | NIE      | BOOL     | Należy przesłać 0.                                           |
| gb    | Czy wysłać dane binarne grafiki?      | NIE      | BOOL     |                                                              |
| ts    | Czas oczekiwania na odpowiedź serwera | NIE      | Num.     | Czas w sekundach. Zakres 0 - 120. Wartość domyślna: 15       |
| tt    | Czas oczekiwania na wysyłkę danych    | NIE      | Num.     | Czas w sekundach. Zakres 0 - 120. Wartość domyślna: 30       |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.

### [eparagonbufferget] Pobranie danych z bufora eDokument

**Identyfikator polecenia:** `eparagonbufferget`

**Parametry wejściowe:**

| Nazwa | Opis                            | Wymagany | Typ                 | Uwagi                                                        |
| ----- | ------------------------------- | -------- | ------------------- | ------------------------------------------------------------ |
| hd    | Numer identyfikacyjny dokumentu | NIE      | Num.                | Numer identyfikacyjny dokumentu eDokument                    |
| st    | Status dokumentu                | NIE      | Num.                | 1 - Wystawiony<br>2 - Błąd przy wysyłaniu (została<br>   nie powtórzona wysyłka)<br>3 - Niewystawiony<br>4 - Zarezerwowany (zostanie<br>   wykorzystany dla przyszłego paragonu) |
| sd    | Data zmiany stanu eDokumentu    | NIE      | Data i czas ISO8601 |                                                              |
| pr    | Czy wydrukowany (T/N)           | NIE      | BOOL                | True - dokument wydrukowany<br>False - brak wydruku          |
| di    | ID dokumentu                    | NIE      | Num.                | Numer identyfikacyjny dokumentu eDokument, unikalny<br>   w skali jednego dnia |
| mi    | Status drukarki                 | NIE      | Num.                | Status drukarki dla danego dokumentu: 0 - Błąd,<br>1 - Gotowa,<br>2 - Zajęta<br>   W przypadku braku drukarki status wynosi 1 |
| rd    | Rodzaj dokumentu                | NIE      | Alfanum.            | Rodzaj dokumentu eDokument                                   |
| gp    | ID grupy dokumentów             | NIE      | Num.                | Numer identyfikacyjny grupy dokumentów eDokument             |
| tl    | Ilość dokumentów w grupie       | NIE      | Num.                | Ilość dokumentów w grupie eDokument                          |

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.
2. W przypadku gdy parametr st = 4, parametry rd i sd zwracają datę „2000-01-01T01:00:00+01:00", a parametr di = 0.
3. W przypadku odczytu grafiki:
   - Parametr pr dla grafiki ma mieć zawsze wartość N.
   - Parametr id opisujący IDZ, zawiera unikalną ścieżkę identyfikującą grafikę np.: `ZBE1234567890-1-1234`.

**Przykład:**

```
[STX]eparagonbufferget[TAB]hd123[TAB]#CRC16[ETX]
```





## Kody 2D

Każdorazowy wydruk kodu musi być poprzedzony sekwencją przygotowującą do wydruku danego kodu (azteccode, amcode, pdf417code, qrcode). Kod może być wydrukowany po odpowiednim skonfigurowaniu stopki wydruku - polecenie ftrcfg, lub w formie nie fiskalnej - polecenie form-barcode2d. Liczba danych możliwych do zakodowania za pomocą kodów 2D (parametr „tx") zależy od kilku czynników:

- Ograniczenia wielkości danych: maksymalna długość parametru „tx" to 2000 bajtów (4000 w trybie hex).
- Szerokość papieru.
- Parametr „px" (liczba pikseli z których zbudowany jest pojedynczy punkt kodu): większa wartość tego parametru powoduje zwiększenie wymiarów drukowanego kodu.
- Parametr „el" (poziom korekcji błędów): zwiększanie tego parametru powoduje dodawanie nadmiarowych danych pomocnych w odczycie uszkodzonego (nieczytelnego) kodu, ale powoduje zwiększenie wymiarów drukowanego kodu.
- Ograniczenia wynikające ze specyfikacji samego kodu (różne w zależności od kodu).

Wygenerowanie kodu o zbyt dużych wymiarach może skutkować tym, że przestanie się on mieścić na papierze, co zostanie zasygnalizowane odpowiednim kodem błędu.





### [azteccode] Przygotowanie do wydruku dwuwymiarowego kodu kreskowego Aztec

**Identyfikator polecenia:** `azteccode`

**Parametry wejściowe:**

| Nazwa | Opis                                                         | Wymagany | Typ      | Uwagi                                                        |
| ----- | ------------------------------------------------------------ | -------- | -------- | ------------------------------------------------------------ |
| px    | Długość boku (w pikselach) pojedynczego punktu kodu          | NIE      | Num.     | Wartość minimalna: 2 (domyślnie)                             |
| el    | Poziom korekcji błędów                                       | NIE      | Num.     | Dopuszczalne wartości: 0 - (10%) najmniejszy poziom korekcji, 1 - (23%), 2 - (36%), 3 - (50%) największy poziom korekcji - największa liczba dodatkowych danych |
| hx    | Przełącznik między trybami wprowadzanych danych (Ascii / szesnastkowo) | NIE      | BOOL     | False - tryb Ascii (domyślnie), True - tryb Hex.             |
| tX    | Komunikat do wydrukowania                                    | TAK      | Alfanum. |                                                              |

**Odpowiedź urządzenia:** `standardowa`

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szerokości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
4. Polecenie niedostępne w FAWAG BOX 1.01.

**Przykład:**

```plaintext
[STX]azteccode|TAB|px2|TAB|el0[TAB|hx0[TAB|txKOMUNIKAT|TAB|#CRC16[ETX]
```

### [dmcode] Przygotowanie do wydruku dwuwymiarowego kodu kreskowego Data Matrix

**Identyfikator polecenia:** `dmcode`

**Parametry wejściowe:**

| Nazwa | Opis                                                         | Wymagany | Typ      | Uwagi                                            |
| ----- | ------------------------------------------------------------ | -------- | -------- | ------------------------------------------------ |
| px    | Długość boku (w pikselach) pojedynczego punktu kodu          | NIE      | Num.     | Wartość minimalna: 2 (domyślnie)                 |
| hx    | Przełącznik między trybami wprowadzanych danych (Ascii / szesnastkowo) | NIE      | BOOL     | False - tryb Ascii (domyślnie), True - tryb Hex. |
| tx    | Komunikat do wydrukowania                                    | TAK      | Alfanum. |                                                  |

**Odpowiedź urządzenia:** `standardowa`

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szerokości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
4. Polecenie niedostępne w FAWAG BOX 1.01.

**Przykład:**

```plaintext
[STX]dmcode[TAB]px2[TAB]hx0[TAB]txKOMUNIKAT[TAB]#CRC16[ETX]
```

### [pdf417code] Przygotowanie do wydruku dwuwymiarowego kodu kreskowego Pdf417

**Identyfikator polecenia:** `pdf417code`

**Parametry wejściowe:**

| Nazwa | Opis                                                         | Wymagany | Typ      | Uwagi                                                        |
| ----- | ------------------------------------------------------------ | -------- | -------- | ------------------------------------------------------------ |
| px    | Długość boku (w pikselach) pojedynczego punktu kodu          | NIE      | Num.     | Wartość minimalna: 2 (domyślnie)                             |
| yx    | Proporcja drukowanego piksela (wysokość / szerokość)         | NIE      | Num.     | 1..50, domyślnie 3                                           |
| el    | Poziom korekcji błędów                                       | NIE      | Num.     | 0 - (2 stowa kodowe przeznaczone na korekcję) najmniejszy poziom korekcji (domyślnie), 1 - (4 stowa kodowe), 2 - (8 stowa kodowe), 3 - (16 stow kodowych), 8 - (512 stow kodowych) największy poziom korekcji - największa liczba dodatkowych danych |
| cc    | Liczba kolumn danych w wydrukowanym kodzie kreskowym         | NIE      | Num.     | 1 (domyślnie) - 30                                           |
| rt    | Obrót drukowanego kodu                                       | NIE      | BOOL     | False - wydruk w poziomie (domyślnie), True - wydruk w pionie |
| hx    | Przełącznik między trybami wprowadzanych danych (Ascii / szesnastkowo) | NIE      | BOOL     | False - tryb Ascii (domyślnie), True - tryb Hex.             |
| tx    | Komunikat do wydrukowania                                    | TAK      | Alfanum. |                                                              |

**Odpowiedź urządzenia:** `standardowa`

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szerokości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
4. Polecenie niedostępne w FAWAG BOX 1.01.

**Przykład:**

```plaintext
[STX]pdf417code[TAB]px2[TAB]el0[TAB]cc2[TAB]rt1[TAB]hx0[TAB]txKOMUNIKAT[TAB]#CRC16[ETX]
```

### [qrcode] Przygotowanie do wydruku dwuwymiarowego kodu kreskowego QrCode

**Identyfikator polecenia:** `qrcode`

**Parametry wejściowe:**

| Nazwa | Opis                                                         | Wymagany | Typ      | Uwagi                                                        |
| ----- | ------------------------------------------------------------ | -------- | -------- | ------------------------------------------------------------ |
| px    | Długość boku (w pikselach) pojedynczego punktu kodu          | NIE      | Num.     | Wartość minimalna: 2 (domyślnie)                             |
| el    | Poziom korekcji błędów                                       | NIE      | Num.     | 0 - (L 7%) najmniejszy poziom korekcji (domyślnie), 1 - (M 15%), 2 - (Q 25%), 3 - (H 30%) największy poziom korekcji - największa liczba dodatkowych danych |
| hx    | Przełącznik między trybami wprowadzanych danych (Ascii / szesnastkowo) | NIE      | BOOL     | False - tryb Ascii (domyślnie), True - tryb Hex.             |
| tx    | Komunikat do wydrukowania                                    | TAK      | Alfanum. |                                                              |

**Odpowiedź urządzenia:** `standardowa`

**Uwagi:**

1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szerokości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).

**Przykład:**

```plaintext
[STX]qrcode[TAB]px2[TAB]el0[TAB]hx1[TAB]tx313233343536373839[TAB]#CRC16[ETX]
```