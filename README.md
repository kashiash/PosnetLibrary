# Posnet



# Obsługa drukarki posnet

To nie jest kopia dokumentacji a jedynie moje notatki jakie robiłem podczas czytanie pdf’a z firmy posnet.

Może zawierać błędy literówki itd.

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



###    [trfvbuyer] Dane nabywcy

 Identyfikator polecenia:       trfvbuyer

Parametry wejsciowe:

| Nazwa Parametru | Opis                                     | Wymagany | Typ      | Uwagi                                                        |
| --------------- | ---------------------------------------- | -------- | -------- | ------------------------------------------------------------ |
| na              | Nazwa nabywcy                            | TAK      | Alfanum. | Długość pola 1-256 znaków. Podział linii dokonuje się za pomocą znaku LF. |
| ni              | Numer NIP                                | TAK      | Alfanum. | Długość pola 1-20 znaków.                                    |
| ad              | Adres nabywcy                            | NIE      | Alfanum. | Pole może składać się z więcej niż 256 znaków. Podziału linii dokonuje się za pomocą znaku LF. |
| sc              | Sekcja w której ma być umieszczona linia | TAK      | Num.     | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                   | NIE      | Num.     | Bity wpływające na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

Odpowiedź urządzenia: standardowa

Uwagi: 

1. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem. 

2. Dostępność w trybie tylko do odczytu: NIE. 

   

Przykład użycia polecenia trfvbuyer: 

 `[STX]trfvbuyer[TAB]naSKLEP[TAB]ni222-333-44-55[TAB]adMostowa 123[TAB]sc0[TAB]#CRC16[ETX]`

| Nazwa Parametru | Opis                                      | Wymagany | Typ      | Uwagi                                                        |
| --------------- | ----------------------------------------- | -------- | -------- | ------------------------------------------------------------ |
| nb              | Numer faktury                             | TAK      | Alfanum. | Długość parametru 1-40 znaków. Parametr nie może zawierać samych spacji. |
| SC              | Sekcja, w której ma być umieszczona linia | TAK      | Num.     | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                    | NIE      | Num.     | Bity płynące na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

Odpowiedź urządzenia: standardowa

Uwagi:

1. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem.
2. Dostępność w trybie tylko do odczytu: NIE.



###    [trfvnumber] Numer faktury VAT          

Identyfikator polecenia:        `trfvnumber`         

Parametry wejsciowe:

| Nazwa Parametru | Opis                                      | Wymagany | Typ      | Uwagi                                                        |
| --------------- | ----------------------------------------- | -------- | -------- | ------------------------------------------------------------ |
| nb              | Numer faktury                             | TAK      | Alfanum. | Długość parametru 1-40 znaków. Parametr nie może zawierać samych spacji. |
| sc              | Sekcja, w której ma być umieszczona linia | TAK      | Num.     | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                    | NIE      | Num.     | Bity płynące na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

Odpowiedź urządzenia: standardowa

Uwagi:

1. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem.
2. Dostępność w trybie tylko do odczytu: NIE.

`[STX]trfvnumber[TAB]nb12[TAB]sc0[TAB]at0#CRC16[ETX]`

### [trfvfreedata] Niefiskalne dane w fakturze

**Identyfikator polecenia:** `trfvfreedata`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                      | Wymagany | Typ      | Uwagi                                                        |
| --------------- | ----------------------------------------- | -------- | -------- | ------------------------------------------------------------ |
| tx              | Treść linii                               | TAK      | Alfanum. | W zależności od deklaracji w rozpoczęciu faktury (trfvinit parametr In), maksymalna długość linii to 40 lub 56 znaków. |
| SC              | Sekcja, w której ma być umieszczona linia | NIE      | Num.     | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Komenda powinna wystąpić pomiędzy komendami trfvinit a trend.
2. Wartości wszystkich pól są kasowane po wykonaniu komendy trfvinit.
3. Na fakturze można umieścić do 100 linii niefiskalnych.
4. W treści linii można używać znaków formatujących tak jak w poleceniu hdrset czy ftrinfoset. Treść linii oraz znaki formatujące nie mogą przekroczyć 64 znaków.
5. Dostępność w trybie tylko do odczytu: NIE.

**Przykład użycia:**

```plaintext
[STX]trfvfreedata[TAB]txWX 12345[TAB]sc1[TAB]#CRC16[ETX]
```

### [trfvsep] Separator

**Identyfikator polecenia:** `trfvsep`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                      | Wymagany | Typ  | Uwagi                                                        |
| --------------- | ----------------------------------------- | -------- | ---- | ------------------------------------------------------------ |
| SC              | Sekcja, w której ma być umieszczona linia | TAK      | Num. | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Separatorem jest linia składająca się z samych kropek.

**Przykład użycia:**

```plaintext
[STX]trfvsep[TAB]s0[TAB]#CRC16[ETX]
```

### [trivcashmet] Metoda kasowa

**Identyfikator polecenia:** `trfvcashmet`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                     | Wymagany | Typ  | Uwagi                                                        |
| --------------- | ---------------------------------------- | -------- | ---- | ------------------------------------------------------------ |
| cm              | Drukowanie pola „Metoda kasowa"          | TAK      | BOOL | True - drukowanie aktywne, False - drukowanie nieaktywne     |
| SC              | Sekcja w której ma być umieszczona linia | TAK      | Num. | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                   | NIE      | Num. | Bity płynące na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Komenda powinna wystąpić pomiędzy komendami „trfvinit" a „trend".
2. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem.
3. Dostępność w trybie tylko do odczytu: NIE.

**Przykład użycia:**

```plaintext
[STX|trfvcashmet|TAB]cm1[TAB]sc0[TAB]at64[TAB|#CRC16[ETX]
```

### [trfvselfbill] Samofakturowanie

**Identyfikator polecenia:** `trfvselfbill`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                     | Wymagany | Typ  | Uwagi                                                        |
| --------------- | ---------------------------------------- | -------- | ---- | ------------------------------------------------------------ |
| sb              | Drukowanie pola „Samofakturowanie"       | TAK      | BOOL | True - drukowanie aktywne, False - drukowanie nieaktywne     |
| SC              | Sekcja w której ma być umieszczona linia | TAK      | Num. | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                   | NIE      | Num. | Bity wpływające na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Komenda powinna wystąpić pomiędzy komendami „trfvinit" a „trend".
2. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem.
3. Dostępność w trybie tylko do odczytu: NIE.

**Przykład użycia:**

```plaintext
[STX]trfvselfbill|[TAB]sb1|TAB|sc0|TAB|at64|TAB|#CRC16[ETX]
```

### [trfvselfbill] Samofakturowanie

**Identyfikator polecenia:** `trfvselfbill`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                     | Wymagany | Typ  | Uwagi                                                        |
| --------------- | ---------------------------------------- | -------- | ---- | ------------------------------------------------------------ |
| sb              | Drukowanie pola „Samofakturowanie"       | TAK      | BOOL | True - drukowanie aktywne, False - drukowanie nieaktywne     |
| SC              | Sekcja w której ma być umieszczona linia | TAK      | Num. | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                   | NIE      | Num. | Bity wpływające na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Komenda powinna wystąpić pomiędzy komendami `trfvinit` a `trend`
2. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem.
3. Dostępność w trybie tylko do odczytu: NIE.

**Przykład użycia:**

```plaintext
[STX]trfvselfbill|[TAB]sb1|TAB|sc0|TAB|at64|TAB|#CRC16[ETX]
```

### [trfvreverse] Odwrotne obciążenie

**Identyfikator polecenia:** `trfvreverse`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                     | Wymagany | Typ  | Uwagi                                                        |
| --------------- | ---------------------------------------- | -------- | ---- | ------------------------------------------------------------ |
| re              | Drukowanie pola „Odwrotne obciążenie"    | TAK      | BOOL | True - drukowanie aktywne, False - drukowanie nieaktywne     |
| sc              | Sekcja w której ma być umieszczona linia | TAK      | Num. | Zakres 0-2: 0 - sekcja nagłówka, 1 - sekcja danych, 2 - sekcja stopki |
| at              | Atrybuty linii wydruku                   | NIE      | Num. | Bity plywające na wygląd czcionki: 0x01 - szeroka czcionka, 0x02 - wysoka czcionka, 0x04 - podkreślenie, 0x08 - kursywa, 0x10 - pogrubienie, 0x20 - zanegowanie, 0x40 - wysrodkowanie |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Komenda powinna wystąpić pomiędzy komendami „trfvinit" a „trend".
2. Wartość parametru "at" może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 + 0x40) spowoduje ustawienie czcionki wysrodkowanej z podkreśleniem.
3. Dostępność w trybie tylko do odczytu: NIE.

**Przykład użycia:**

```plaintext
[STX|trfvreverse[TAB]re1[TAB]sc0[TAB]at64|TAB]#CRC16[ETX]
```

### [trline] Linia transakcji

**Identyfikator polecenia:** `trline`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                                | Wymagany | Typ      | Uwagi                                                        |
| --------------- | ----------------------------------- | -------- | -------- | ------------------------------------------------------------ |
| na              | Nazwa towaru                        | TAK      | Alfanum. | Do 80 znaków                                                 |
| vt              | Stawka VAT                          | TAK      | Num.     | Podaje się numer stawki (0 - 6)                              |
| pr              | Cena                                | TAK      | Kwota    | Zakres 1 - 499 999 999 999                                   |
| st              | Flaga stornowania                   | NIE      | BOOL     | False - brak stornowania (domyślnie), True - stornowanie     |
| wa              | Kwota total (cena x ilość)          | NIE      | Kwota    | Kwota total nie może przekroczyć zakresu 9 999 999 999       |
| il              | Ilość towaru                        | NIE      | Num.     | Domyślnie 1,000, Zakres 0,00000001 - 9 999 999 999           |
| op              | Opis towaru                         | NIE      | Alfanum. | Domyślnie pusty. Do 50 znaków                                |
| jm              | Jednostka miary                     | NIE      | Alfanum. | Do 4 znaków                                                  |
| rd              | Rabat (True)/narzut(False)          | NIE      | BOOL     | Domyślnie rabat                                              |
| rn              | Nazwa rabatu/narzutu                | NIE      | Alfanum. | Domyślnie pusta. Do 25 znaków                                |
| rp              | Wartość rabatu/narzutu procentowego | NIE      | Num.     | Do 99,99%. Nie przesyła się separatora części ułamkowej - określają ją dwie ostatnie cyfry |
| rW              | Wartość rabatu/narzutu kwotowego    | NIE      | Kwota    |                                                              |
| np              | PKWiU                               | NIE      | Alfanum. | Tylko na fakturze - do 49 znaków                             |
| nc              | Kod towaru                          | NIE      | Alfanum. | Tylko na fakturze. Do 51 znaków. Kody, których wydrukowanie przekracza możliwości mechanizmu drukarki, nie są drukowane - bez zgłaszania błędów. Maksymalne długości kodów możliwych do wydrukowania zbudowanych z cyfr to 51 znaków dla urządzeń Thermal i 50 znaków dla Thermo, Trio, Pospay, Vero, Evo, Fawag Box.  Długość kodu kreskowego na fakturze może być mniejsza w przypadku, gdy używane są znaki inne niż cyfry, w zależności od konfiguracji znaków zgodnie z specyfikacją kodu EAN128. Na fakturze drukowany jest zarówno kod kreskowy, jak i ciąg alfanumeryczny. |

Odpowiedź urządzenia jest w standardowym formacie. Poniżej znajdują się uwagi dotyczące obsługi linii transakcji:

1. Aby udzielić rabatu/narzutu procentowego, należy pominąć pole `rp` (procent).
2. Aby udzielić rabatu/narzutu kwotowego, należy pominąć pole `rw` (wartość).
3. Jeśli oba pola są przesłane, oznacza to, że jest to rabat procentowy, a pole `wartosc` to kwota rabatu/narzutu do weryfikacji.
4. Jeśli żadne pole (`rp` i `rw`) nie jest przesłane, nie ma rabatu/narzutu. Przestanie niepustego parametru `rn` powoduje wydruk linii uwzględniającej rabat: xxxxx lub uwzględniającej narzut: xxxxx w zależności od parametru `rd` (czy rabat).
5. Wystąpienie samego pola `rd` (czy rabat) jest ignorowane.
6. Wystąpienie pola opisu towaru (parametr `op`) zastępuje wydruk linii uwzględniającej rabat (dotyczy przerwania niepustego parametru `rn` bez parametrów wartości `rp` lub `rw`).
7. Rabat nie może przekraczać wartości linii sprzedaży (parametr `wa`).
8. Wartość linii sprzedaży po narzucie nie może przekraczać zakresu parametru `wa`.
9. Maksymalna liczba linii transakcji to:
   - 120 dla faktury,
   - 500 dla paragonu.
10. Pole PKWiU jest aktywne tylko dla faktury VAT.
11. Pole Kod towaru jest aktywne tylko dla faktury VAT.
12. Przy rozróżnianiu nazw towarów brane są pod uwagę tylko znaki alfanumeryczne (wielkość liter nie ma znaczenia), kropka, przecinek, procent i kreski ukośne.
13. Drukarki posiadają wbudowany mechanizm kontroli stawek VAT. Niedozwolone jest obniżanie a następnie zwiększanie stawki VAT przy sprzedaży towaru. W takim przypadku dojdzie do zablokowania możliwości sprzedaży towaru w nowej wyższej stawce (kod błędu 2106). Będzie możliwa sprzedaż tylko w poprzedniej stawce lub w stawce niższej niż poprzednia. Więcej informacji w dokumencie: OPIS MECHANIZMU KONTROLI STAWEK PODATKU W DRUKARKACH FISKALNYCH.
14. Dostępność w trybie tylko do odczytu: NIE.

Przykład użycia komendy linii transakcji:

```plaintext
[STX]trline|TAB]naMleko[TAB]vt2[TAB|pr245|TAB|#CRC16[ETX]
```



### [trnipset] Drukowanie NIP-u nabywcy

**Identyfikator polecenia:** `trnipset`

**Parametry wejściowe:**

| Nazwa Parametru | Opis                         | Wymagany | Typ      | Uwagi                                                        |
| --------------- | ---------------------------- | -------- | -------- | ------------------------------------------------------------ |
| ni              | NIP nabywcy                  | TAK      | Alfanum. | Do 30 znaków. Nie może być pusty.                            |
| dw              | Drukować jako wyróżnione?    | NIE      | BOOL     | Domyślnie: True                                              |
| ds              | Opis poprzedzający numer NIP | NIE      | Alfanum. | Do 56 znaków. Jeśli parametr nie występuje w rozkazie, na paragonie drukowany jest napis „NIP NABYWCY:" |

**Odpowiedź urządzenia:** standardowa

**Uwagi:**

1. Rozkaz można wysyłać w dowolnym momencie po rozpoczęciu paragonu i przed jego zakończeniem.
2. Rozkaz można wysyłać kilkakrotnie. Kolejne wystąpienie rozkazu powoduje nadpisanie poprzednio zapisanych wartości.
3. Wystąpienie w parametrze `ni` samych spacji powoduje brak wydruku sekcji NIP-u nabywcy oraz opisu wydruku.
4. Przestanie rozkazu nie powoduje natychmiastowego wydruku. NIP nabywcy jest drukowany razem ze stopką wydruku.
5. Dostępność w trybie tylko do odczytu: NIE

**Przykład:**

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