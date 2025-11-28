# Wykaz kodów błędów drukarki Posnet

Ten dokument zawiera wykaz wszystkich kodów błędów drukarki Posnet zgodnie z dokumentacją protokołu komunikacji.

**Źródło:** Dokumentacja protokołu Posnet Online (POT-I-DEV-37 wersja: 5978)

**Zobacz także:** [README.md](README.md) - główna dokumentacja biblioteki

---

## Błędy ramki

Błędy związane z formatem i strukturą ramki protokołu komunikacyjnego.

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 1 | `PROTO_ERR_CMD_UNKNOWN` | Nierozpoznana komenda |
| 2 | `PROTO_ERR_CMD_MANDATORY_FIELDS` | Brak obowiązkowego pola |
| 3 | `PROTO_ERR_DATA_CONVERSION` | Błąd konwersji pola (np.: przesłana została wartość z przecinkiem w polu którego wartość przesyła się w częściach setnych np.: 12,34 zamiast 1234, lub przekroczony zakres danych) |
| 4 | `PROTO_ERR_TOKEN_INVALID` | Błędny token |
| 5 | `PROTO_ERR_CRC_INVALID` | Zła suma kontrolna |
| 6 | `PROTO_ERR_FLD_INVALID` | Błąd budowy ramki, brak mnemonika parametru |
| 7-9 | Zarezerwowane | Zarezerwowane |
| 10 | `PROTO_ERR_DATA_LENGTH` | Niewłaściwa długość pola danych |
| 11 | `PROTO_ERR_INPUT_BUFFER_OVERRUN` | Zapełniony bufor odbiorczy |
| 12 | `PROTO_ERR_CMD_IMMEDIATE_FORBIDDEN` | Nie można wykonać rozkazu w trybie natychmiastowym |
| 13 | `PROTO_ERR_TOKEN_NOT_FOUND` | Nie znaleziono rozkazu o podanym tokenie |
| 14 | `PROTO_ERR_INPUT_QUEUE_FULL` | Zapełniona kolejka wejściowa |
| 15 | `PROTO_ERR_SYNTAX` | Błąd budowy ramki, brak sumy kontrolnej |

---

## Błędy poleceń

### Błędy ogólne

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 30 | `ERR_CANCEL` | Błąd nietypowy - rezygnacja, przerwanie funkcji |
| 40 | `ERR_CMD_BLOCKED_FOR_INTERFACE` | Komenda niedozwolona dla danego interfejsu |
| 41 | `ERR_CMD_TRY_LATER` | Zasoby zajęte przez inny interfejs |
| 50 | `ERR_UNKN` | Błąd wykonywania operacji przez kasę |
| 51 | `ERR_ASSERT_FM` | Błąd wykonywania operacji przez kasę |
| 52 | `ERR_ASSERT_DB` | Błąd wykonywania operacji przez kasę |
| 53 | `ERR_ASSERT_SALE` | Błąd wykonywania operacji przez kasę |
| 54 | `ERR_ASSERT_UI` | Błąd wykonywania operacji przez kasę |
| 55 | `ERR_ASSERT_CFG` | Błąd wykonywania operacji przez kasę |
| 56 | `ERR_ASSERT_CM` | Błąd wykonywania operacji przez kasę |
| 323 | `ERR_OPER_BLOCKED` | Funkcja zablokowana w konfiguracji |
| 360 | `ERR_SERVICE_SWITCH_FOUND` | Znaleziono zworę serwisową |
| 361 | `ERR_SERVICE_SWITCH_NOT_FOUND` | Nie znaleziono zwory |
| 364 | `ERR_WRONG_PASSWORD_FORMAT` | Błędne hasło w sensie niezgodności z poprawnością składniową |
| 365 | `ERR_WRONG_AUTHORIZATION` | Błędne hasło w sensie niezgodności z tym z bazy |
| 382 | `ERR_RD_ZERO` | Próba wykonania raportu zerowego |
| 383 | `ERR_RD_NOT_PRINTED` | Brak raportu dobowego |
| 384 | `ERR_FM_NO_REC` | Brak rekordu w pamięci |
| 387 | `ERR_SL_FM_LOCKED` | Sprzedaż zablokowana. Brak miejsca w pamięci |
| 388 | `ERR_FM_LOCKED` | Operacja zablokowana. Brak miejsca w pamięci |
| 400 | `ERR_WRONG_VALUE` | Błędna wartość |
| 404 | `ERR_WRONG_CONTROL_CODE` | Wprowadzono nieprawidłowy kod kontrolny |

### Błędy zegara (RTC)

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 460 | `ERR_CLOCK_RTC_FSK` | Błąd zegara w trybie fiskalnym |
| 461 | `ERR_CLOCK_RTC_NFSK` | Błąd zegara w trybie niefiskalnym |
| 462 | `ERR_CLOCK_RTC_SYNC` | Błąd synchronizacji zegara z serwerem |
| 463 | `ERR_TIME_NOT_EXIST` | Podana data nie istnieje |
| 464 | `ERR_INVALID_ZONE` | Nieprawidłowa strefa czasowa |

### Błędy autoryzacji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 480 | `ERR_AUTH_AUTHORIZED` | Drukarka już autoryzowana, bezterminowo |
| 481 | `ERR_AUTH_NOT_STARTED` | Nie rozpoczęto jeszcze autoryzacji |
| 482 | `ERR_AUTH_WAS_ADDED` | Kod już wprowadzony |
| 483 | `ERR_AUTH_DAY_CNT` | Próba wprowadzenia błędnych wartości |
| 484 | `ERR_AUTH_BLOCKED` | Minął czas pracy kasy, sprzedaż zablokowana |
| 485 | `ERR_AUTH_BAD_CODE` | Błędny kod autoryzacji |
| 486 | `ERR_AUTH_TOO_MANY_WRONG_CODES` | Blokada autoryzacji. Wprowadź kod z klawiatury |
| 487 | `ERR_AUTH_ALL_CODES_USED` | Użyto już maksymalnej liczby kodów |
| 488 | `ERR_BLOCKED` | Subskrypcja wygasła, sprzedaż zablokowana |

### Błędy statystyk i kasy

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 499 | `ERR_ACTIVE_PROTO_THERMAL` | Aktywny protokół Thermal. Proszę zmienić protokół |
| 500 | `ERR_STAT_MIN_OVF` | Przepełnienie statystyki minimalnej |
| 501 | `ERR_STAT_MAX_OVF` | Przepełnienie statystyki maksymalnej |
| 502 | `ERR_CASH_IN_MAX_OVF` | Przepełnienie stanu kasy |
| 503 | `ERR_CASH_OUT_BELOW_0` | Wartość stanu kasy po wypłacie staje się ujemna (przyjmuje się stan zerowy kasy) |

### Błędy konfiguracji sieci i komunikacji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 700 | `ERR_INVALID_IP_ADDR` | Błędny adres IP |
| 701 | `ERR_INVALID_TONE_NUMBER` | Błąd numeru tonu |
| 702 | `ERR_ILLEGAL_DRAWER_IMPULSE_LEN` | Błąd długości impulsu szuflady |
| 703 | `ERR_ILLEGAL_VAT_RATE` | Błąd stawki VAT |
| 705 | `ERR_INVALID_SLEEP_TIME` | Błąd czasu uśpienia |
| 706 | `ERR_INVALID_TURNOFF_TIME` | Błąd czasu wyłączenia |
| 709 | `ERR_ILLEGAL_HDR_ATTR` | Błędny atrybut nagłówka |
| 713 | `ERR_CONFIG_SET` | Błędne parametry konfiguracji |
| 714 | `ERR_ILLEGAL_DSP_CONTRAST` | Błędna wartość kontrastu wyświetlacza |
| 715 | `ERR_ILLEGAL_DSP_LUMIN` | Błędna wartość podświetlenia wyświetlacza |
| 716 | `ERR_ILLEGAL_DSP_OFF_DELAY` | Błędna wartość czasu zaniku podświetlenia |
| 717 | `ERR_LINE_TOO_LONG` | Za długa linia nagłówka albo stopki |
| 718 | `ERR_ILLEGAL_COMM_CFG` | Błędna konfiguracja komunikacji |
| 719 | `ERR_ILLEGAL_PROTOCOL_CFG` | Błędna konfiguracja protokołu kom |
| 720 | `ERR_ILLEGAL_PORT` | Błędny identyfikator portu |
| 721 | `ERR_ILLEGAL_INFO_TXT_NUM` | Błędny numer tekstu reklamowego |
| 722 | `ERR_ILLEGAL_TIME_DIFF` | Podany czas wychodzi poza wymagany zakres |
| 723 | `ERR_ILLEGAL_TIME` | Podana data/czas niepoprawne |
| 724 | `ERR_ILLEGAL_HOUR_DIFF` | Inna godzina w różnicach czasowych 0<=>23 |
| 726 | `ERR_ILLEGAL_DSP_LINE_CONTENT` | Błędna zawartość tekstu w linii wyświetlacza |
| 727 | `ERR_ILLEGAL_DSP_SCROLL_VALUE` | Błędna wartość dla przewijania na wyświetlaczu |
| 728 | `ERR_ILLEGAL_PORT_CFG` | Błędna konfiguracja portu |
| 729 | `ERR_INVALID_MONITOR_CFG` | Błędna konfiguracja monitora transakcji |
| 730 | `ERR_PORT_BUSY_PC_1` | Port zajęty przez PC1 |
| 731 | `ERR_PORT_BUSY_TCPIP` | Port zajęty przez TCP/IP |
| 732 | `ERR_PORT_BUSY_SALE_MON` | Port zajęty przez monitor |
| 733 | `ERR_PORT_BUSY` | Port zajęty |
| 734 | `ERR_PORT_BUSY_TUNNEL` | Port zajęty przez tunelowanie |
| 735 | `ERR_IP_PORT_RESERVED` | Port zarezerwowany na usługi systemowe |
| 736 | `ERR_PORT_BUSY_PC_2` | Port zajęty przez PC2 |
| 738 | `ERR_NET_CONFIG` | Nieprawidłowa konfiguracja sieci |
| 739 | `ERR_ILLEGAL_DSP_ID` | Nieprawidłowy typ wyświetlacza |
| 740 | `ERR_ILLEGAL_DSP_ID_FOR_OFF_DELAY` | Dla tego typu wyświetlacza nie można ustawić czasu zaniku podświetlenia |
| 741 | `ERR_ILLEGAL_POWER_IND_INTERVAL` | Wartość czasu spoza zakresu |
| 745 | `ERR_ILLEGAL_CODE_PAGE_CFG` | Błędny numer strony kodowej |
| 746 | `ERR_INVALID_MONITOR_FRAME_CFG` | Błędna konfiguracja ramki monitora transakcji |
| 747 | `ERR_DHCP_ACTIVE_FUNCTION_UNAVAILABLE` | DHCP aktywne. Funkcja niedostępna |
| 748 | `ERR_DHCP_FORBIDDEN` | DHCP dozwolone tylko przy transmisji sieciowej |
| 752 | `ERR_THERMAL_OVER_TCPIP` | Protokół Thermal jest niedostępny po interfejsie TCP/IP |
| 762 | `ERR_IP_NOT_FOUND` | Nie znaleziono adresu IP |

### Błędy testów i bazy danych

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 820 | `ERR_TEST` | Negatywny wynik testu |
| 821 | `ERR_TEST_NO_CONF` | Brak testowanej opcji w konfiguracji |
| 857 | `ERR_DF_DB_NO_MEM` | Brak pamięci na inicjalizację bazy drukarkowej |
| 901 | `ERR_DB_REC_EXISTS` | Rekord już zaprogramowany |
| 903 | `ERR_DB_NO_RECORD` | Rekord nie istnieje |
| 905 | `ERR_DB_BASE_FULL` | Baza jest pełna |
| 910 | `ERR_DB_NAME_NOT_UNIQUE` | Nazwa nie jest unikalna |
| 974 | `ERR_DB_ILLEGAL_CNTX` | Niepoprawny kontekst bazy danych |
| 975 | `ERR_DB_CNTX_END` | Nie ma więcej rekordów wg kontekstu |

### Błędy pamięci fiskalnej (FM)

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 1000 | `ERR_FATAL_FM` | Błąd fatalny pamięci fiskalnej |
| 1001 | `ERR_FM_NCONN` | Wypięta pamięć fiskalna |
| 1002 | `ERR_FM_WRITE` | Błąd zapisu |
| 1003 | `ERR_FM_UNKN` | Błąd nie ujęty w specyfikacji bios |
| 1004 | `ERR_FM_CHKSUM_CNT` | Błędne sumy kontrolne |
| 1006 | `ERR_FM_COMM` | Błąd komunikacji z pamięcią fiskalną |
| 1007 | `ERR_FM_BAD_REC_ID` | Błędny id rekordu |
| 1010 | `ERR_FM_NU_PRESENT` | Numer unikatowy już zapisany |
| 1011 | `ERR_FM_NU_NO_PRESENT_FSK` | Brak numeru w trybie fiskalnym |
| 1012 | `ERR_FM_NU_WRITE` | Błąd zapisu numeru unikatowego |
| 1013 | `ERR_FM_NU_FULL` | Przepełnienie numerów unikatowych |
| 1015 | `ERR_FM_TIN_CNT` | Więcej niż jeden NIP |
| 1016 | `ERR_FM_READ_ONLY_NFSK` | Kasa w trybie do odczytu bez rekordu fiskalizacji |
| 1017 | `ERR_FM_CLR_RAM_CNT` | Przekroczono liczbę zerowań RAM |
| 1018 | `ERR_FM_REP_DAY_CNT` | Przekroczono liczbę raportów dobowych |
| 1025 | `ERR_FM_NU_FORMAT` | Błędny format numeru unikatowego |
| 1028 | `ERR_FM_REC_EMPTY` | Rekord w pamięci fiskalnej nie istnieje - obszar pusty |
| 1029 | `ERR_FM_REC_DATE` | Rekord w pamięci fiskalnej z datą wcześniejszą od poprzedniego |
| 1036 | `ERR_FM_EC_INTEGRITY` | Niezgodność danych pamięci chronionej |
| 1037 | `ERR_FM_PROTMEM_INTEGRITY` | Niezgodność danych pamięci chronionej. |
| 1038 | `ERR_FM_PROTMEM_VERIFY_ERROR` | Błąd weryfikacji pamięci chronionej. |
| 1039 | `ERR_FM_PROTMEM_FULL` | Pamięć chroniona zapełniona |
| 1040 | `ERR_FM_EC_INTEGRITY_DOC` | Niezgodność danych pamięci chronionej |
| 1041 | `ERR_FM_PROTMEM_ACCESS` | Błąd dostępu do pamięci chronionej. |
| 1044 | `ERR_FM_INCOMPLETE_FSK` | Nieudana fiskalizacja |
| 1045 | `ERR_FM_REC_DATA_WITH_LATER_DATE` | Data i czas wcześniejsze od daty ostatniego zapisu do pamięci fiskalnej. |
| 1050 | `ERR_FM_APP_MODE_FULL` | Przekroczona liczba zapisów trybów pracy |
| 1051 | `ERR_FM_APP_MODE_EMPTY` | Obszar konfiguracji trybów pracy jest pusty |
| 1052 | `ERR_FM_APP_MODE_READ` | Błąd odczytu trybu pracy |
| 1053 | `ERR_FM_READ` | Błąd odczytu |
| 1054 | `ERR_FM_READ_FACTORY_NUMBER` | Brak numeru fabrycznego! |
| 1055 | `ERR_FM_FACTORY_NUMBER_ALREADY_SET` | Numer fabryczny już zapisany! |
| 1056 | `ERR_FM_FACTORY_NUMBER_WRONG_FORMAT` | Nieprawidłowy format numeru fabrycznego. |
| 1057 | `ERR_FM_FSK_INCOMPLETE_DATA` | Dane niekompletne |
| 1060 | `ERR_FM_FILE_NOT_FOUND` | Brak pliku w pamięci fiskalnej. |
| 1061 | `ERR_FM_FILE_OPEN` | Błąd otwarcia pliku w pamięci fiskalnej. |
| 1062 | `ERR_FM_FILE_OPEN_RESOURCES` | Brak zasobów do otwarcia pliku |
| 1063 | `ERR_FM_FILE_ALREADY_OPEN` | Plik w pamięci fiskalnej już otwarty. |
| 1064 | `ERR_FM_FILE_READ` | Błąd odczytu pliku w pamięci fiskalnej. |
| 1066 | `ERR_FM_FILE_WRITE` | Błąd zapisu pliku w pamięci fiskalnej. |
| 1067 | `ERR_FM_FILE_CREATE` | Błąd utworzenia pliku w pamięci fiskalnej. |
| 1068 | `ERR_FM_FILE_ALREADY_EXIST` | Plik w pamięci fiskalnej już istnieje. |
| 1069 | `ERR_FM_NO_MEM` | Brak wolnej przestrzeni w pamięci fiskalnej. |
| 1070 | `ERR_FM_FILE_NO_MEM` | Brak wolnej przestrzeni w pliku |
| 1071 | `ERR_FM_FILE_SEEK` | Błąd ustawienia offsetu w pliku |
| 1072 | `ERR_FM_CRC_NOT_READY` | Suma kontrolna niewyliczona |
| 1073 | `ERR_FM_IS_LOCKED` | Próba zapisu do zablokowanej pamięci fiskalnej. |
| 1074 | `ERR_FM_UNREGISTERED` | Wykryto podmianę pamięci fiskalnej. |
| 1075 | `ERR_FM_LOST` | Wykryto zmiany w pamięci fiskalnej. |
| 1076 | `ERR_FM_TRANSACTION_GET` | Błąd utworzenia transakcji w pamięci fiskalnej. |
| 1077 | `ERR_FM_SHA_NOT_READY` | Suma kontrolna niewyliczona |
| 1078 | `ERR_FM_NOT_READY` | Pamięć fiskalna niegotowa. |
| 1079 | `ERR_FM_WRONG_FIRMWARE_VERSION` | Niezgodny firmware pamięci fiskalnej |

### Błędy biletów (TM)

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 1100 | `ERR_TM_READ_GROUP` | Błąd odczytu grupy biletowej |
| 1101 | `ERR_TM_WRITE_GROUP` | Błąd zapisu grupy biletowej |
| 1102 | `ERR_TM_READ_CATEGORY` | Błąd odczytu kategorii biletowej |
| 1103 | `ERR_TM_WRITE_CATEGORY` | Błąd zapisu kategorii biletowej |
| 1104 | `ERR_TM_READ_DAYREP` | Błąd odczytu raportu dziennego biletowego |
| 1105 | `ERR_TM_WRITE_DAYREP` | Błąd zapisu raportu dziennego biletowego |
| 1106 | `ERR_TM_READ_SALEINFO` | Błąd odczytu rekordu sprzedaży biletowej |
| 1107 | `ERR_TM_WRITE_SALEINFO` | Błąd zapisu rekordu sprzedaży biletowej |

### Błędy trybu pracy i urządzenia

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 1200 | `ERR_APP_MODE_WRONG` | Niewłaściwy tryb pracy |
| 1210 | `ERR_FM_DEVICE_ID` | Pamięć fiskalna niezgodna z typem urządzenia |
| 1211 | `ERR_FM_DEVICE_ID_READ` | Błąd odczytu identyfikatora typu urządzenia |

### Błędy transakcji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 1950 | `ERR_TR_TOT_OVR` | Przekroczony zakres totalizerów paragonu |
| 1951 | `ERR_TR_PF_OVR` | Wpłata formą płatności przekracza max. wpłatę |
| 1952 | `ERR_TR_PF_SUM_OVR` | Suma form płatności przekracza max. wpłatę |
| 1953 | `ERR_PAYMENT_OVR` | Formy płatności pokrywają już do zapłaty |
| 1954 | `ERR_TR_CHANGE_OVR` | Wpłata reszty przekracza max. wpłatę |
| 1955 | `ERR_TR_CHANGE_SUM_OVR` | Suma form płatności przekracza max. wpłatę |
| 1956 | `ERR_TR_TOTAL_OVR` | Przekroczony zakres total |
| 1957 | `ERR_TR_FISC_OVR` | Przekroczony maksymalny zakres paragonu |
| 1958 | `ERR_TR_PACK_OVR` | Przekroczony zakres wartości opakowań |
| 1959 | `ERR_TR_PACK_STORNO_OVR` | Przekroczony zakres wartości opakowań przy stornowaniu |
| 1961 | `ERR_TR_PF_REST_TOO_BIG` | Wpłata reszty zbyt duża |
| 1962 | `ERR_TR_PF_ZERO` | Wpłata formą płatności wartości 0 |
| 1963 | `ERR_TR_ADVANCE_OVR` | Przekroczony zakres zaliczki |
| 1964 | `ERR_TR_ADVANCE_BASE_OVR` | Przekroczony zakres podstawy zaliczki |
| 1965 | `ERR_TR_PACK_CNT_OVR` | Przekroczona ilość różnych opakowań zwrotnych |
| 1966 | `ERR_TR_ADVANCE_ZERO` | Zaliczka zerowa |
| 1980 | `ERR_TR_DISCNT_BASE_OVR` | Przekroczony zakres kwoty bazowej rabatu/narzutu |
| 1981 | `ERR_TR_DISCNT_AFTER_OVR` | Przekroczony zakres kwoty po rabacie / narzucie |
| 1982 | `ERR_TR_DISCNT_CALC` | Błąd obliczania rabatu/narzutu |
| 1983 | `ERR_TR_DISCNT_BASE_NEGATIVE_OR_ZERO` | Wartość bazowa ujemna lub równa 0 |
| 1984 | `ERR_TR_DISCNT_ZERO` | Wartość rabatu/narzutu zerowa |
| 1985 | `ERR_TR_DISCNT_AFTER_NEGATIVE_OR_ZERO` | Wartość po rabacie ujemna lub równa 0 |
| 1990 | `ERR_TR_STORNO_NOT_ALLOWED` | Niedozwolone stornowanie towaru. Błędny stan transakcji |
| 1991 | `ERR_TR_DISCNT_NOT_ALLOWED` | Niedozwolony rabat/narzut. Błędny stan transakcji |
| 1992 | `ERR_TR_EMPTY` | Brak pozycji na paragonie |
| 2000 | `ERR_TR_FLD_VAT` | Błąd pola VAT (błędny numer stawki lub nieaktywna stawka) |
| 2001 | `ERR_TR_FLD_QUANT_FRACTIONAL` | Ilość niecałkowita |
| 2002 | `ERR_NO_HDR` | Brak nagłówka |
| 2003 | `ERR_HDR` | Zaprogramowany nagłówek |
| 2004 | `ERR_NO_VAT` | Brak aktywnych stawek VAT |
| 2005 | `ERR_NO_TRNS_MODE` | Brak trybu transakcji |
| 2006 | `ERR_TR_FLD_PRICE` | Błąd pola cena (cena <= 0) |
| 2007 | `ERR_TR_FLD_QUANT` | Błąd pola ilość (ilość <= 0) |
| 2008 | `ERR_TR_FLD_TOTAL` | Błąd kwoty total |
| 2009 | `ERR_TR_FLD_TOTAL_ZERO` | Błąd kwoty total, równa zero |
| 2010 | `ERR_TOT_OVR` | Przekroczony zakres totalizerów dobowych |
| 2019 | `ERR_RTC_CERT_VALIDITY` | Data wykracza poza zakres ważności certyfikatów |
| 2020 | `ERR_RTC_DAY_CHANGED` | Zmiana daty niedozwolona |
| 2022 | `ERR_RTC_DIFF` | Zbyt duża różnica dat |
| 2023 | `ERR_RTC_HOUR` | Różnica większa niż 2 godziny w trybie użytkownika w trybie fiskalnym |
| 2024 | `ERR_RTC_BAD_FORMAT` | Zły format daty (np. 13 miesiąc) |
| 2025 | `ERR_RTC_FM_DATE` | Data wcześniejsza od ostatniego zapisu do modułu |
| 2026 | `ERR_RTC` | Błąd zegara |
| 2027 | `ERR_VAT_CHNG_CNT` | Przekroczono maksymalną liczbę zmian stawek VAT |
| 2028 | `ERR_VAT_SAME` | Próba zdefiniowana identycznych stawek VAT |
| 2029 | `ERR_VAT_VAL` | Błędne wartości stawek VAT |
| 2030 | `ERR_VAT_NO_ACTIVE` | Próba zdefiniowania stawek VAT wszystkich nieaktywnych |
| 2031 | `ERR_FLD_TIN` | Błąd pola NIP |
| 2032 | `ERR_FM_ID` | Błąd numeru unikatowego pamięci fiskalnej. |
| 2033 | `ERR_FISC_MODE` | Urządzenie w trybie fiskalnym |
| 2034 | `ERR_NO_FISC_MODE` | Urządzenie w trybie niefiskalnym |
| 2035 | `ERR_TOT_NOT_ZERO` | Niezerowe totalizery |
| 2036 | `ERR_READ_ONLY` | Urządzenie w stanie tylko do odczytu |
| 2037 | `ERR_NO_READ_ONLY` | Urządzenie nie jest w stanie tylko do odczytu |
| 2038 | `ERR_TRNS_MODE` | Urządzenie w trybie transakcji |
| 2039 | `ERR_TOT_ZERO` | Zerowe totalizery |
| 2040 | `ERR_CURR_CALC` | Błąd obliczeń walut, przepełnienie przy mnożeniu lub dzieleniu |
| 2041 | `ERR_TR_END_VAL_0` | Próba zakończenia pozytywnego paragonu z wartością 0 |
| 2042 | `ERR_REP_PER_DATE_FORMAT_FROM` | Błąd formatu daty początkowej |
| 2043 | `ERR_REP_PER_DATE_FORMAT_TO` | Błąd formatu daty końcowej |
| 2045 | `ERR_REP_PER_DATE_START_GT_CURR` | Data początkowa późniejsza od bieżącej daty |
| 2046 | `ERR_REP_PER_DATE_END_GT_FISK` | Data końcowa wcześniejsza od daty fiskalizacji |
| 2047 | `ERR_REP_PER_NUM_ZERO` | Numer początkowy lub końcowy równy zero |
| 2048 | `ERR_REP_NUMBER_RANGE` | Numer początkowy większy od numeru końcowego |
| 2049 | `ERR_REP_PER_NUM_TOO_BIG` | Numer raportu zbyt duży |
| 2050 | `ERR_REP_DATE_RANGE` | Data początkowa późniejsza od daty końcowej |
| 2052 | `ERR_TR_NO_MEM` | Brak pamięci w buforze transakcji |
| 2054 | `ERR_TR_END_PAYMENT` | Formy płatności nie pokrywają kwoty do zapłaty lub reszty |
| 2055 | `ERR_LINE` | Błędna linia |
| 2056 | `ERR_EMPTY_TXT` | Tekst pusty |
| 2057 | `ERR_SIZE` | Przekroczony rozmiar lub przekroczona liczba znaków formatujących |
| 2058 | `ERR_LINE_CNT` | Błędna liczba linii |
| 2059 | `ERR_BARCODE_FORMAT` | Błędny kod kreskowy |
| 2060 | `ERR_TR_BAD_STATE` | Błędny stan transakcji |
| 2062 | `ERR_PRN_START` | Jest wydrukowana część jakiegoś dokumentu |
| 2063 | `ERR_PAR` | Błąd parametru |
| 2064 | `ERR_FTR_NO_HDR` | Brak rozpoczęcia wydruku lub transakcji |
| 2066 | `ERR_FTR_NO_FTR` | Brak rozpoczęcia stopki wydruku |
| 2067 | `ERR_PRN_CFG_SET` | Błąd ustawień konfiguracyjnych wydruków / drukarki |
| 2070 | `ERR_WRONG_MAINTENANCE_TIME` | Data przeglądu wcześniejsza od systemowej |
| 2074 | `ERR_WRONG_SERVICE_ID` | Błędna długość numeru ID serwisanta |
| 2080 | `ERR_HEX_ODD` | Nieparzysta liczba danych w formacie HEX |
| 2081 | `ERR_HEX_PARAM` | Niepoprawna wartość dla formatu HEX |
| 2094 | `ERR_TR_CHANGE_EXIST` | Występuje forma płatności jako reszta |
| 2095 | `ERR_HEADER_TOO_LONG` | Nagłówek za długi |
| 2096 | `ERR_TIN_LENGTH` | Błędna długość NIP. Wymagane dokładnie 10 cyfr |
| 2097 | `ERR_HDR_PRINTED_EC_FULL` | Wydrukowany nagłówek. Wyłącz oszczędność papieru, i wykonaj raport okresowy |
| 2098 | `ERR_FM_DOC_FULL` | Pamięć fiskalna zapełniona |

### Błędy bazy drukarkowej

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2101 | `ERR_DF_DB_OVR` | Zapełnienie bazy |
| 2102 | `ERR_DF_DB_VAT_INACTIVE` | Stawka nieaktywna |
| 2103 | `ERR_DF_DB_VAT_INVALID` | Nieprawidłowa stawka VAT |
| 2104 | `ERR_DF_DB_NAME` | Błąd nazwy |
| 2105 | `ERR_DF_DB_NAME_VAT` | Błąd przypisania stawki |
| 2106 | `ERR_DF_DB_LOCKED` | Towar zablokowany |
| 2107 | `ERR_DF_DB_NAME_NOT_FOUND` | Nie znaleziono w bazie drukarkowej |
| 2110 | `ERR_AUTHORIZATION` | Błąd autoryzacji |

### Błędy terminala płatniczego

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2207 | `ERR_TERMINAL_IP_PORT` | Niedozwolony port TCP |
| 2211 | `ERR_TERMINAL_BREAK_COMMUNICATION` | Przerwano komunikację z terminalem! |
| 2282 | `ERR_TERMINAL_RCV_PARAM` | Niepoprawne dane z terminala |
| 2284 | `ERR_TERMINAL_CMD_EXEC` | Błąd podczas wykonania komendy |
| 2287 | `ERR_TERMINAL_CON_PORT` | Błąd operacji na porcie komunikacyjnym |
| 2290 | `ERR_TERMINAL_RCV_SYNTAX` | Niezrozumiała odpowiedź z terminala |

### Błędy formatów raportów

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2501 | `ERR_FORM_ID` | Błędny identyfikator raportu |
| 2502 | `ERR_FORM_LINE_NO` | Błędny identyfikator linii raportu |
| 2503 | `ERR_FORM_HDR_NO` | Błędny identyfikator nagłówka raportu |
| 2504 | `ERR_FORM_PAR_CNT` | Zbyt mało parametrów raportu |
| 2505 | `ERR_FORM_NOT_STARTED` | Raport nie rozpoczęty |
| 2506 | `ERR_FORM_STARTED` | Raport rozpoczęty |
| 2507 | `ERR_FORM_CMD` | Błędny identyfikator komendy |
| 2508 | `ERR_FORM_NOT_WIDE` | Próba wydrukowania szerokiej formatki na papierze 57mm |
| 2509 | `ERR_FORM_MASK` | Maska zakrywa zbyt dużo tekstu |
| 2521 | `ERR_DB_REP_PLU_ACTIVE` | Raport już rozpoczęty |
| 2522 | `ERR_DB_REP_PLU_NOT_ACTIVE` | Raport nie rozpoczęty |
| 2523 | `ERR_DB_REP_PLU_VAT_ID` | Błędna stawka VAT |
| 2532 | `ERR_FV_COPY_CNT` | Błędna liczba kopii faktur |
| 2533 | `ERR_FV_EMPTY_NUMBER` | Pusty numer faktury |
| 2534 | `ERR_FV_FORMAT` | Błędny format wydruku |
| 2535 | `ERR_FV_EMPTY_BUYER` | Puste dane nabywcy |

### Błędy rabatów i narzutów

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2600 | `ERR_DISCNT_TYPE` | Błędny typ rabatu/narzutu |
| 2601 | `ERR_TR_DISCNT_VALUE` | Wartość rabatu/narzutu spoza zakresu |

### Błędy VAT i dodatkowe

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2701 | `ERR_VAT_ID` | Błąd identyfikatora stawki podatkowej |
| 2702 | `ERR_FTRLN_ID` | Błędny identyfikator dodatkowej stopki |
| 2703 | `ERR_FTRLN_CNT` | Przekroczona liczba dodatkowych stopek |
| 2704 | `ERR_ACC_LOW` | Zbyt słaby akumulator |
| 2705 | `ERR_PF_TYPE` | Błędny identyfikator typu formy płatności |
| 2706 | `ERR_CHARGER_NOT_CONNECTED` | Brak zasilacza |
| 2707 | `ERR_CHARGER_MODE` | Błędna konfiguracja ładowarki |
| 2710 | `ERR_SERVICE_NOT_FOUND` | Usługa o podanym identyfikatorze nie jest uruchomiona |
| 2712 | `ERR_ILLEGAL_TIME_VALUE` | Wartość czasu poza zakresem |

### Błędy weryfikacji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2801 | `ERR_DISCNT_VERIFY` | Błąd weryfikacji wartości rabatu/narzutu |
| 2802 | `ERR_LNTOT_VERIFY` | Błąd weryfikacji wartości linii sprzedaży |
| 2803 | `ERR_PACKTOT_VERIFY` | Błąd weryfikacji wartości opakowania |
| 2804 | `ERR_CURRTOT_VERIFY` | Błąd weryfikacji wartości formy płatności |
| 2805 | `ERR_ENDTOT_VERIFY` | Błąd weryfikacji wartości fiskalnej |
| 2806 | `ERR_ENDPACKPLUS_VERIFY` | Błąd weryfikacji wartości opakowań dodatnich |
| 2807 | `ERR_ENDPACKMINUS_VERIFY` | Błąd weryfikacji wartości opakowań ujemnych |
| 2808 | `ERR_ENDPAYMENT_VERIFY` | Błąd weryfikacji wartości wpłaconych form płatności |
| 2809 | `ERR_ENDCHANGE_VERIFY` | Błąd weryfikacji wartości reszt |
| 2810 | `ERR_ENDPACK_EMPTY` | Próba zakończenia rozliczenia opakowań z wartościami 0 (przyjętych i wydanych) |

### Błędy stornowania

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2851 | `ERR_STORNO_QNT` | Błąd stornowania, błędna ilość |
| 2852 | `ERR_STORNO_AMT` | Błąd stornowania, błędna wartość |
| 2853 | `ERR_STORNO_PACK_NOT_FOUND` | Błąd stornowania, nie znaleziono opakowania |

### Błędy pamięci chronionej (EC)

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 2900 | `ERR_EC_NOT_ENOUGH_SPACE` | Stan pamięci chronionej nie pozwala na wydrukowanie tego dokumentu |
| 2901 | `ERR_EC_EDM_NOT_READY` | Nośnik niegotowy, operacja na nośniku trwa |
| 2902 | `ERR_EC_EDM_NOT_VERIFIED` | Nośnik nie został poprawnie zweryfikowany. |
| 2903 | `ERR_EC_DATA_PENDING` | Pamięć zawiera zbyt dużą ilość danych |
| 2904 | `ERR_EC_EDM_FULL` | Pamięć chroniona zapełniona. |
| 2907 | `ERR_EC_EDM_MISSING` | Brak dostępu do pamięci chronionej |
| 2908 | `ERR_EC_EDM_INVALID` | Nośnik nieprawidłowy - nieodpowiedni dla wybranej operacji |
| 2911 | `ERR_EC_EDM_FILE_NOT_FOUND` | Brak pliku na nośniku |
| 2913 | `ERR_EC_EDM_CHAIN_BROKEN` | Nośnik nie jest poprawnie zweryfikowany |
| 2916 | `ERR_EC_EDM_VERIFY_IN_PROGRESS` | Trwa weryfikacja nośnika |
| 2917 | `ERR_EC_DOC_TYPE` | Błędny typ dokumentu |
| 2918 | `ERR_EC_UNAVAILABLE` | Dane niedostępne (nieaktualne) |
| 2930 | `ERR_EC_DOC_NOT_FOUND` | Nie znaleziono dokumentu |

### Błędy walut

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3051 | `ERR_CURRENCY_ALREADY_CHANGED` | Nie można zmienić dwa razy waluty ewidencyjnej po RD |
| 3052 | `ERR_CURRENCY_SAME` | Próba ustawienia już ustawionej waluty |
| 3053 | `ERR_CURRENCY_INVALID_NAME` | Błędna nazwa waluty |
| 3054 | `ERR_CURRENCY_SHOULD_CHANGE` | Automatyczna zmiana waluty |
| 3055 | `ERR_CURRENCY_RATE` | Błędna wartość przelicznika kursu |
| 3056 | `ERR_CURRENCY_CHNG_CNT` | Przekroczono maksymalną liczbę zmian walut |
| 3080 | `ERR_VAT_RTC_OLD` | Próba zdefiniowania stawek VAT ze starą datą |
| 3084 | `ERR_VAT_SHOULD_CHANGE` | Automatyczna zmiana stawek VAT |
| 3085 | `ERR_VAT_INVALID_DATE` | Brak pola daty |

### Błędy fiskalizacji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3098 | `ERR_FISC_OWNERSHIP_TYPE` | Błąd parametru własności kasy |
| 3099 | `ERR_FISC_USE_TYPE` | Błąd parametru użytkowania kasy |
| 3100 | `ERR_FISC_AUTH_MISSING` | Brak parametru autoryzacji fiskalizacji |
| 3110 | `ERR_ILLEGAL_DRAWER_VOLTAGE` | Błąd napięcia szuflady |

### Błędy kodów 2D

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3200 | `ERR_CODE2D_NOTHING_TO_PRINT` | Próba wydruku pustego kodu |
| 3201 | `ERR_CODE2D_OUT_OF_PAPER` | Kod przekracza obszar papieru lub jest zbyt duży |
| 3202 | `ERR_CODE2D_SCALE` | Nieprawidłowa wartość skali wydruku |
| 3203 | `ERR_CODE2D_Y2X_RATIO` | Nieprawidłowa wartość parametru Y2X ratio |
| 3205 | `ERR_CODE2D_OUT_OF_MEMORY` | Kod przekracza dopuszczalny obszar pamięci |
| 3206 | `ERR_CODE2D_TOO_LONG_DATA_STREAM` | Strumień wejściowy przekracza dopuszczalną długość |
| 3207 | `ERR_CODE2D_COLUMN_COUNT_OVERRANGE` | Liczba kolumn poza zakresem |
| 3208 | `ERR_CODE2D_ROW_COUNT_OVERRANGE` | Liczba wierszy poza zakresem |
| 3209 | `ERR_CODE2D_ECC_LEVEL_OVERRANGE` | Poziom korekcji błędów poza zakresem |
| 3210 | `ERR_CODE2D_PIXEL_PER_MODULE` | Liczba pikseli na moduł poza zakresem |
| 3220 | `ERR_UNSUPPORTED_BARCODE` | Nieobsługiwany typ kodu kreskowego |
| 3221 | `ERR_BARCODE_WRITE` | Błąd zapisu kodu kreskowego |
| 3222 | `ERR_BARCODE_READ` | Błąd odczytu kodu kreskowego |

### Błędy grafik

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3250 | `ERR_IMG_SLOT_NO_OVERRANGE` | Numer grafiki poza zakresem |
| 3251 | `ERR_IMG_SLOT_EMPTY` | Brak grafiki w slocie |
| 3252 | `ERR_IMG_READ_ONLY` | Grafika tylko do odczytu |
| 3253 | `ERR_IMG_SIZE_OVERRANGE` | Niepoprawny rozmiar grafiki |
| 3254 | `ERR_IMG_OUT_OF_MEMORY` | Przekroczony rozmiar pamięci przeznaczony na grafikę |
| 3255 | `ERR_IMG_EC` | Błąd zapisu grafiki na pamięć chronioną. |
| 3256 | `ERR_IMG_FLASH_OPERATION` | Błąd zapisu grafiki |
| 3257 | `ERR_IMG_EC_LEVEL` | Poziom drukowalności grafik z kopii poza zakresem |
| 3258 | `ERR_IMG_DATA_SIZE` | Niepoprawny rozmiar danych |
| 3260 | `ERR_IMG_NAME` | Niepoprawna nazwa grafiki |
| 3261 | `ERR_IMG_READ` | Błąd odczytu grafiki |
| 3262 | `ERR_IMG_ALREADY_EXIST` | Grafika już istnieje |
| 3263 | `ERR_IMG_ADD_PROTECTED_MEMORY` | Błąd archiwizowania grafiki |
| 3264 | `ERR_IMG_SIZE_MISSING_FOR_RAW_IMAGE` | Brak podanego rozmiaru dla grafiki w formacie RAW |
| 3265 | `ERR_IMG_SIZE_PRESENT_FOR_BMP_IMAGE` | Konflikt parametrów: podano rozmiar dla grafiki BMP |
| 3266 | `ERR_IMG_INVALID_BMP_HEADER` | Niepoprawny nagłówek dla grafiki BMP |
| 3267 | `ERR_IMG_INVALID_FORMAT` | Niepoprawny format grafiki |
| 3268 | `ERR_IMG_ALREADY_IN_PROGRESS` | Programowanie grafiki w toku |
| 3269 | `ERR_IMG_REBUILD_ERROR` | Nieudany odczyt grafiki przy odbudowie bazy danych |

### Błędy trybu pracy aplikacji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3280 | `ERR_APP_MODE_IS_SAME` | Tryb pracy już zaprogramowany |
| 3281 | `ERR_APP_MODE_NOT_EXIST` | Tryb pracy poza zakresem |
| 3282 | `ERR_APP_MODE_WRITE` | Błąd zapisu trybu pracy |
| 3283 | `ERR_APP_MODE_CODE` | Błędny kod zmiany trybu pracy |

### Błędy sieci (WiFi, Bluetooth, COM)

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3432 | `ERR_CONN_NOW` | Brak aktywnego połączenia z siecią |
| 3440 | `ERR_WIFI_MODULE` | Błąd modułu WiFi |
| 3441 | `ERR_WIFI_NO_NETWORK` | Błąd połączenia z siecią WiFi |
| 3442 | `ERR_WIFI_INTERFACE_NO_ACTIVE` | Interfejs WiFi nieaktywny |
| 3444 | `ERR_WIFI_INVALID_SSID` | Niepoprawny SSID |
| 3445 | `ERR_WIFI_NOT_READY` | Moduł WiFi niegotowy |
| 3446 | `ERR_WIFI_UNKNOWN` | Nieznany błąd modułu WiFi |
| 3447 | `ERR_WIFI_NETWORK_IN_USE` | Nie można skasować połączonej sieci |
| 3448 | `ERR_WIFI_UNKNOWN_NETWORK` | Nieznana nazwa sieci |
| 3449 | `ERR_WIFI_EMPTY_RECORD` | Pusty rekord |
| 3450 | `ERR_WIFI_KEY_CHARSET` | Niepoprawny zestaw znaków |
| 3451 | `ERR_WIFI_VERSION_UNAVAILABLE` | Numer wersji modułu WiFi niedostępny |
| 3459 | `ERR_BLUETOOTH_PIN_CODE_EDIT` | Błędna długość kodu PIN |
| 3460 | `ERR_BLUETOOTH_MODULE` | Błąd modułu Bluetooth |
| 3461 | `ERR_BLUETOOTH_INTERFACE_NO_ACTIVE` | Interfejs Bluetooth nieaktywny |
| 3465 | `ERR_BLUETOOTH_DEL_PAIR_RECORD` | Nie można skasować urządzenia |
| 3466 | `ERR_BLUETOOTH_PAIR_TIMEOUT` | Upłynął czas parowania urządzeń |
| 3470 | `ERR_BLUETOOTH_NO_PRESENT` | Interfejs Bluetooth niedostępny |
| 3471 | `ERR_WIFI_NO_PRESENT` | Interfejs WiFi nieaktywny |
| 3472 | `ERR_COM_NO_PRESENT` | Interfejs COM nieaktywny |

### Błędy pamięci masowej

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3500 | `ERR_MASS_STORAGE_FILE_OPEN` | Błąd otwarcia pliku |
| 3501 | `ERR_MASS_STORAGE_READ` | Błąd odczytu nośnika |
| 3502 | `ERR_MASS_STORAGE_WRITE` | Błąd zapisu na nośnik |
| 3503 | `ERR_MASS_STORAGE_MISSING` | Brak pamięci zewnętrznej |
| 3504 | `ERR_MASS_STORAGE_ACCESS` | Błąd operacji na pamięci masowej |
| 3520 | `ERR_LOG_DIR_NOT_FOUND` | Nie znaleziono katalogu z logami |

### Błędy aktualizacji oprogramowania

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3700 | `ERR_FIRMWARE_UPDATE_DOWNLOAD_PROBLEM` | Błąd pobierania aktualizacji |
| 3701 | `ERR_FIRMWARE_UPDATE_FILE_OPEN` | Błąd otwarcia pliku aktualizacji |
| 3702 | `ERR_FIRMWARE_UPDATE_FILE_READ` | Błąd odczytu z pliku aktualizacji |
| 3703 | `ERR_FIRMWARE_UPDATE_FILE_WRITE` | Błąd zapisu do pliku aktualizacji |
| 3704 | `ERR_FIRMWARE_UPDATE_HTTP_ERROR` | Błąd połączenia z serwerem aktualizacji |
| 3705 | `ERR_FIRMWARE_UPDATE_DECRYPTION_PROBLEM` | Błąd deszyfrowania aktualizacji |
| 3706 | `ERR_FIRMWARE_UPDATE_DECRYPTION_WRONG_CONTENT` | Niewłaściwa zawartość pobranego pliku aktualizacji |
| 3707 | `ERR_FIRMWARE_UPDATE_BUSY` | Trwa sprawdzanie aktualizacji. Spróbuj ponownie później |
| 3708 | `ERR_FIRMWARE_UPDATE_INCOMPLETE_FILE` | Niekompletny plik z aktualizacją |
| 3709 | `ERR_FIRMWARE_UPDATE_INVALID` | Brak weryfikacji wersji |
| 3710 | `ERR_FIRMWARE_UPDATE_INCORRECT_URL` | Nieprawidłowy adres url aktualizacji |
| 3711 | `ERR_FIRMWARE_UPDATE_MAKE_DAY_REP` | Nie można wykonać RD! |
| 3712 | `ERR_FIRMWARE_UPDATE_LOADER_ERR` | Aktualizacja zakończona błędem |
| 3713 | `ERR_FIRMWARE_UPDATE_CHANGE_KEYS` | Brak możliwości wymiany kluczy. Zakończ aktualizację |
| 3714 | `ERR_FIRMWARE_UPDATE_READY_TO_INSTALL` | Aktualizacja gotowa do instalacji |

### Błędy certyfikatów

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3720 | `ERR_CERTIFICATE_FILE_CREATE` | Błąd utworzenia pliku z certyfikatem |
| 3721 | `ERR_CERTIFICATE_FILE_COPY` | Błąd kopiowania certyfikatu |
| 3722 | `ERR_CERTIFICATE_DELETE` | Błąd kasowania certyfikatu |
| 3723 | `ERR_CERTIFICATE_FILE_SIZE` | Zbyt duży rozmiar pliku z certyfikatem |
| 3724 | `ERR_CERTIFICATE_FILE_READ` | Błąd odczytu pliku z certyfikatem |
| 3725 | `ERR_CERTIFICATE_NOT_EXISTS` | Certyfikat nie istnieje |
| 3726 | `ERR_CSR_FILE_CREATE` | Błąd utworzenia pliku csr |
| 3727 | `ERR_CERTIFICATE_INCORRECT_FILE` | Nieprawidłowy plik certyfikatu |
| 3728 | `ERR_CERTIFICATE_EXPIRY` | Upłynął termin ważności certyfikatu |
| 3729 | `ERR_CERTIFICATE_INVALID` | Błąd weryfikacji certyfikatu |
| 3730 | `ERR_CERTIFICATE_FUTURE_EXPIRATION` | Certyfikat nie jest jeszcze ważny |
| 3731 | `ERR_CERTIFICATE_DIR_NOT_FOUND` | Nie znaleziono katalogu z certyfikatami |
| 3732 | `ERR_CERTIFICATE_FULL_MEMORY` | Osiągnięto maksymalną ilość wymiany kluczy publicznych |
| 3733 | `ERR_CERTIFICATE_LOCK_SALE` | Sprzedaż zablokowana. Brak przekazanych kluczy do Repozytorium |
| 3734 | `ERR_CERTIFICATE_EXCHANGE_KEYS_FISCAL_EVENT` | Za mało zdarzeń do wykonania operacji |
| 3735 | `ERR_CERTIFICATE_EXCHANGE_REQUIRED` | Sprzedaż zablokowana. Wgraj nowe certyfikaty |
| 3738 | `ERR_CERTIFICATE_EXCHANGE_FAIL` | Błąd wymiany certyfikatów. Wykonaj synchronizację czasu |
| 3750 | `ERR_MODULE_TPM` | Błąd modułu szyfrującego |
| 3751 | `ERR_TPM_GENERATE_RSA_KEY` | Błąd podczas generowania kluczy |
| 3752 | `ERR_TPM_NOT_ENOUGH_MEMORY` | Za mało pamięci w module szyfrującym |
| 3753 | `ERR_TPM_INCORRECT_STATE` | Niepoprawny stan modułu szyfrującego |

### Błędy kasy terminala

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3800 | `ERR_KASOTERMINAL_BEGIN_PRINT` | Błąd utworzenia wydruku |
| 3802 | `ERR_KASOTERMINAL_END_PRINT` | Błąd zakończenia wydruku |
| 3804 | `ERR_KASOTERMINAL_PRINTOUT_IN_PROGRESS` | Trwa wydruk |

### Błędy repozytorium i fiskalizacji

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 3901 | `ERR_REPOSITORY_FILE_READ` | Błąd odczytu z pliku |
| 3902 | `ERR_REPOSITORY_FILE_CREATE` | Błąd utworzenia pliku |
| 3903 | `ERR_REPOSITORY_BUSY` | Operacja w toku. Spróbuj ponownie |
| 3904 | `ERR_REPOSITORY_COMM_SERVER_CPD` | Błąd komunikacji z serwerem CPD |
| 3905 | `ERR_REPOSITORY_FISCALIZATION_SERIAL_NUMBER` | Odmowa fiskalizacji, błędny numer fabryczny |
| 3906 | `ERR_REPOSITORY_FISCALIZATION_UNIQUE_NUMBER` | Odmowa fiskalizacji, błędny numer unikatowy |
| 3907 | `ERR_REPOSITORY_FISCALIZATION_REGISTRATION_NUMBER` | Odmowa fiskalizacji, błędny numer ewidencyjny |
| 3908 | `ERR_REPOSITORY_FISCALIZATION_NIP` | Odmowa fiskalizacji, błędny numer NIP |
| 3909 | `ERR_REPOSITORY_FISCALIZATION_PERMISSION` | Odmowa fiskalizacji, brak uprawnień serwisanta |
| 3910 | `ERR_REPOSITORY_FISCALIZATION_SERIAL_UNIQUE_NUMBER` | Odmowa fiskalizacji, błędny numer fabryczny lub unikatowy |
| 3911 | `ERR_REPOSITORY_FISCALIZATION_SERIAL_REGISTRATION_NUMBER` | Odmowa fiskalizacji, błędny numer fabryczny lub ewidencyjny |
| 3912 | `ERR_REPOSITORY_FISCALIZATION_OPERATION_UNACCEPTABLE` | Odmowa fiskalizacji, operacja niedopuszczalna |
| 3913 | `ERR_REPOSITORY_FISCALIZATION_DURING_FISCALIZATION` | Odmowa fiskalizacji, kasa w trakcie fiskalizacji z innym NIP |
| 3914 | `ERR_REPOSITORY_FISCALIZATION_NONE_REGISTRATION_NUMBER` | Odmowa fiskalizacji, brak lub błędny numer ewidencyjny |
| 3915 | `ERR_REPOSITORY_FISCALIZATION_DEVICE_NOT_UNREGISTER` | Odmowa fiskalizacji, kasa nie wyrejestrowana |
| 3916 | `ERR_REPOSITORY_FISCALIZATION_FISCALMEM_CLOSE` | Odmowa fiskalizacji, pamięć fiskalna zamknięta |
| 3917 | `ERR_REPOSITORY_FISCALIZATION_NIP_REGISTRATION_NUMBER` | Odmowa fiskalizacji, błędny numer NIP lub numer ewidencyjny |
| 3918 | `ERR_REPOSITORY_FISCALIZATION_PREV_FISCALMEM_NOT_CLOSE` | Odmowa fiskalizacji, poprzednia pamięć fiskalna nie zamknięta |
| 3919 | `ERR_REPOSITORY_FISCALIZATION_TECHNICAL_ERROR` | Odmowa fiskalizacji, błąd techniczny, skontaktuj się z administratorem |
| 3920 | `ERR_REPOSITORY_SEND_DOCUMENT` | Operacja nieudana |
| 3921 | `ERR_REPOSITORY_PARAMETER` | Błędne dane z Ministerstwa |
| 3922 | `ERR_TAXOFFICE_TOO_SHORT` | Zbyt krótki identyfikator Urzędu Skarbowego |
| 3923 | `ERR_TAXOFFICE_ONLY_DIGIT` | Dozwolone tylko cyfry w ident. Urzędu Skarbowego |
| 3924 | `ERR_REPOSITORY_ADDRESS_TOO_SHORT` | Adres zbyt krótki |
| 3926 | `ERR_REPOSITORY_TRIGGER_TOO_EARLY` | Zbyt wczesne wywołanie połączenia z serwerem |
| 3927 | `ERR_REPOSITORY_ADDRESS_INCORRECT` | Nieprawidłowy adres url |
| 3929 | `ERR_REPOSITORY_MISSING_SHARED_KEY` | Sprzedaż zablokowana. Brak klucza współdzielonego |
| 3930 | `ERR_REPOSITORY_FISCALIZATION_DEVICE_REGISTERED` | Odmowa fiskalizacji, kasa zafiskalizowana |
| 3931 | `ERR_REPOSITORY_FISCALIZATION_NO_CERTIFICATES` | Odmowa fiskalizacji, brak certyfikatów kasy |
| 3932 | `ERR_REPOSITORY_FISCALIZATION_TIN_DIFFERENT` | Odmowa fiskalizacji, NIP właściciela inny niż w certyfikacie |
| 3933 | `ERR_REPOSITORY_FISCALIZATION_VERIFY_SOFTWARE` | Odmowa fiskalizacji, brak weryfikacji oprogramowania |

### Błędy dokumentów i zdarzeń

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 4000 | `ERR_PROTMEM_DOC_NOT_FOUND` | Nie znaleziono dokumentu |
| 4100 | `ERR_NO_EVENTS_IN_RANGE` | Brak zdarzeń w podanym zakresie |
| 4105 | `ERR_EVENTS_INVALID_TYPE` | Błędny typ zdarzenia |

### Błędy danych podatnika

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 4201 | `ERR_COMPANY_NAME_MISSING_OR_WRONG` | Brak lub błędna nazwa firmy w danych podatnika |
| 4202 | `ERR_POSTAL_CODE_MISSING_OR_WRONG` | Brak lub błędny kod pocztowy w danych podatnika |
| 4203 | `ERR_CITY_MISSING_OR_WRONG` | Brak lub błędna nazwa miasta w danych podatnika |
| 4204 | `ERR_POST_OFFICE_MISSING_OR_WRONG` | Brak lub błędna nazwa urzędu pocztowego w danych podatnika |
| 4205 | `ERR_STREET_MISSING_OR_WRONG` | Brak lub błędna nazwa ulicy w danych podatnika |
| 4206 | `ERR_NUMBER_MISSING_OR_WRONG` | Brak lub błędny numer domu w danych podatnika |
| 4207 | `ERR_SUB_NUMBER_MISSING_OR_WRONG` | Brak lub błędny numer lokalu w danych podatnika |
| 4208 | `ERR_ADDITIONAL_DATA_MISSING_OR_WRONG` | Brak lub błędne dodatkowe dane w danych podatnika |
| 4209 | `ERR_INVALID_POSTAL_CODE` | Błędny format kodu pocztowego |

### Błędy e-paragonów (eDokument)

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 4250 | `ERR_EPARAGON_QUEUE_FULL` | Kolejka danych do eDokumentu pełna |
| 4251 | `ERR_EPARAGON_SEND_DATA` | Błąd wysyłania danych |
| 4252 | `ERR_EPARAGON_FILE_OPEN` | Błąd otwarcia pliku |
| 4253 | `ERR_EPARAGON_FILE_WRITE` | Błąd zapisu do pliku |
| 4254 | `ERR_EPARAGON_FILE_SIGN` | Błąd podczas podpisywania pliku |
| 4255 | `ERR_EPARAGON_INCORRECT_URL` | Nieprawidłowy adres url |
| 4256 | `ERR_EPARAGON_PROCESSING` | EDokument w trakcie wysyłki |
| 4257 | `ERR_EPARAGON_LAST_DOC_EXIST` | Zarejestrowano eDokument dla ostatniego paragonu |
| 4258 | `ERR_EPARAGON_REGISTER_IDZ` | Zdefiniowano parametr IDZ dla kolejnego eDokumentu |
| 4259 | `ERR_EPARAGON_INCORRECT_URL_LENGTH` | Nieprawidłowy rozmiar adresu url |
| 4260 | `ERR_EPARAGON_INCORRECT_CERT_TYPE` | Nieprawidłowy rodzaj certyfikatu |
| 4271 | `ERR_EPARAGON_INCORRECT_THUMBPRINT_LENGTH` | Nieprawidłowy rozmiar odcisku |
| 4272 | `ERR_EPARAGON_URL_EMPTY` | Pusty adres URL |
| 4273 | `ERR_EPARAGON_SERVER_REQUIRES_CONFIGURATION` | Nie ma skonfigurowanego adresu serwera |
| 4275 | `ERR_EPARAGON_TEST_CONNECTION` | Nieudana próba połączenia testowego |
| 4276 | `ERR_EPARAGON_NO_BITMAP_TO_SEND` | Brak grafiki do wysłania |
| 4277 | `ERR_EPARAGON_IDZ_INVALID` | Nieprawidłowe pole IDZ |
| 4454 | `ERR_SOK_INCORRECT_URL` | Nieprawidłowy adres url |

### Błędy duty free

| Kod | Mnemonik | Opis |
|-----|----------|------|
| 4900 | `ERR_DUTY_FREE_DESTINATION_PORT_MISSING` | Brak identyfikatora portu docelowego |
| 4901 | `ERR_DUTY_FREE_DESTINATION_ALREADY_PRESENT` | Identyfikator portu docelowego już istnieje |
| 4902 | `ERR_DUTY_FREE_TOO_MANY_MIDWAY_PORTS` | Zdefiniowano nadmiarową liczbę portów przesiadkowych |
| 4903 | `ERR_DUTY_FREE_INVALID_PORT_DATA` | Błędne dane portu |

---

## Uwagi

- Wszystkie kody błędów są zwracane przez drukarkę w odpowiedzi na polecenia protokołu komunikacyjnego.
- W przypadku wystąpienia błędu, drukarka zwraca odpowiedź zawierającą kod błędu, identyfikator polecenia oraz opcjonalnie nazwę pola, w którym wystąpił błąd.
- Szczegółowe informacje o formacie odpowiedzi błędów znajdują się w dokumentacji protokołu komunikacyjnego.

---

**Dokument wygenerowany na podstawie:** Specyfikacja protokołu Posnet Online (POT-I-DEV-37 wersja: 5978)

