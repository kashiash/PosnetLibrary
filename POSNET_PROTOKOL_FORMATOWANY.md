# Specyfikacja ProtokoĹ‚u POSNET

**Oznaczenie dokumentu:** POT-I-DEV-37  
**Wersja:** 5978  
**Data:** 2.11.2023

## ObsĹ‚ugiwane urzÄ…dzenia

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


SPECYFIKACJA PROTOKOŁU
POSNET
POSNET THERMAL XL2 ONLINE 2.01
POSNET THERMAL XL2 ONLINE S 2.01
POSNET THERMAL HD ONLINE 2.01
POSNET TEMO ONLINE 2.01
POSNET TRIO ONLINE 2.01
POSNET POSPAY ONLINE 2.01
POSNET THERMAL HX 1.01
POSNET THERMAL HX S 1.01
POSNET VERO 2.01
POSNET EVO 1.01
FAWAG BOX 1.01

Spis treści
Ogólny opis protokołu........................................................................................................................11
Budowa ramki protokołu...............................................................................................................11
Suma kontrolna..............................................................................................................................12
Odpowiedzi drukarki.....................................................................................................................13
Błędy ramki....................................................................................................................................14
Typy danych...................................................................................................................................14
Tryby wykonania poleceń..............................................................................................................15
Sekwencje sterujące............................................................................................................................16
## [rtcset] Ustawianie daty i czasu.....................................................................................................16
## [rtcget] Odczyt daty i czasu...........................................................................................................17
## [rtcsync] Wywołanie synchronizacji czasu przez protokół............................................................18
## [vatset] Programowanie stawek PTU............................................................................................19
## [vatget] Odczyt stawek PTU..........................................................................................................21
## [vatautoset] Programowanie automatycznej zmiany stawek PTU................................................22
## [vatautoget] Odczyt automatycznej zmiany stawek PTU..............................................................24
## [hdrset] Programowanie nagłówka................................................................................................26
## [hdrget] Odczyt nagłówka..............................................................................................................29
## [ftrinfoget] Odczytywanie linii informacyjnych w stopce.............................................................30
## [ftrinfoset] Programowanie linii informacyjnych w stopce...........................................................31
## [fiscalize] Fiskalizacja...................................................................................................................33
## [taxofficedataset] Programowanie danych urzędu skarbowego....................................................35
## [taxofficedataget] Odczyt danych urzędu skarbowego..................................................................36
## [servicedataset] Programowanie danych serwisu..........................................................................37
## [servicedataget] Odczyt danych serwisu........................................................................................38
## [servicemandataset] Programowanie danych serwisanta...............................................................39
## [servicemandataget] Odczyt danych serwisanta............................................................................40
## [auth] Wprowadzanie kodu autoryzacyjnego................................................................................41
## [authcodereset] Anulowanie wprowadzonego kodu autoryzacyjnego...........................................42
## [authstateget] Odczyt stanu autoryzacji.........................................................................................43
## [maintenance] Wykonanie przeglądu technicznego.......................................................................44
## [nextmaintenanceset] Programowanie daty przypomnienia o przeglądzie technicznym..............45
## [nextmaintenanceget] Pobranie daty następnego przeglądu serwisowego....................................46
## [serviceintervention] Zarejestrowanie interwencji serwisowej.....................................................47
## [opendrwr] Otwieranie szuflady....................................................................................................48
## [papfeed] Wysuw papieru..............................................................................................................49
## [prncfgset] Konfiguracja wydruków..............................................................................................50
## [prncfgget] Odczyt konfiguracji wydruków..................................................................................51
## [cancelledsaleprintcfgset] Konfiguracja wydruków paragonów i faktur anulowanych................52
## [cancelledsaleprintcfgget] Odczyt konfiguracji wydruków paragonów i faktur anulowanych.....53
## [billseparatorset] Konfiguracja wydruku separatora na paragonie................................................54
## [billseparatorget] Odczyt konfiguracji wydruku separatora na paragonie.....................................55
## [dayreportprintcfgset] Konfiguracja wydruku raportu dobowego.................................................56
## [dayreportprintcfgget] Odczyt konfiguracji drukowania raportu dobowego.................................57
## [doccfgset] Konfiguracja zapisu nagłówka dokumentu do pamięci chronionej............................58
## [doccfgget] Odczyt konfiguracji zapisu nagłówka dokumentu do pamięci chronionej................59
## [prnparamset] Ustawienie parametrów drukowania......................................................................60
## [prnparamget] Odczyt parametrów drukowania............................................................................61

## [prnwidthset] Ustawianie szerokości papieru................................................................................62
## [prnwidthget] Odczyt szerokości papieru......................................................................................63
## [appmodeget] Odczyt rodzaju drukarki.........................................................................................64
## [papersavecfg] Konfiguracja trybu oszczędności papieru.............................................................65
## [papersavecfgget] Odczyt konfiguracji trybu oszczędności papieru.............................................66
## [ftrcfg] Konfiguracja stopki wydruku............................................................................................67
## [barcodeheightset] Ustawienie wysokości kodu kreskowego.......................................................69
## [barcodeheightget] Odczyt konfiguracji wysokości kodu kreskowego.........................................70
## [fvcfgset] Ustawienie konfiguracji drukowania faktur..................................................................71
## [fvcfgget] Odczyt konfiguracji drukowania faktur........................................................................72
## [dspmode] Konfiguracja trybu wyświetlania informacji związanych z transakcją.......................73
## [dsptxtline] Dowolna linia informacyjna na wyświetlaczu...........................................................74
## [dsptxt] Dowolna zawartość wyświetlacza....................................................................................75
## [dspcmd] Wyświetlanie daty i czasu..............................................................................................76
## [windowtimecfgget] Odczyt konfiguracji czasu wyświetlania komunikatów...............................77
## [windowtimecfgset] Konfiguracja czasu wyświetlania komunikatów..........................................78
## [windowtimecfgreset] Resetowanie konfiguracja czasu wyświetlania komunikatów..................79
## [discounttypeset] Konfiguracja sposobu obliczania rabatu...........................................................80
## [discounttypeget] Odczyt konfiguracji sposobu obliczania rabatu................................................81
## [currrateset] Zmiana przelicznika walut........................................................................................82
## [currrateget] Odczyt przelicznika walut........................................................................................84
## [currset] Ustawienie daty automatycznej zmiany waluty..............................................................85
## [currget] Odczyt waluty ewidencyjnej...........................................................................................86
## [ecmedinfoget] Odczyt danych o nośniku pamięci chronionej.....................................................87
## [ecpubkeyget] Odczyt klucza publicznego....................................................................................88
## [ecprndoc] Wydruk dokumentów z pamięci chronionej................................................................89
## [break] Asynchroniczne przerwanie wydruku...............................................................................90
## [fsppswdset] Ustawienie hasła do serwera FSP.............................................................................91
## [svc] Tunelowanie danych do usługi.............................................................................................92
## [rpt] Powtarzanie odpowiedzi na wcześniej wysłany rozkaz........................................................93
## [protoswitch] Zmiana protokołu komunikacyjnego na Thermal...................................................94
## [dailyrepaccessset] Ustawianie dostępu do raportu dobowego z menu.........................................95
## [dailyrepaccessget] Odczyt konfiguracji dostępu do raportu dobowego z menu..........................96
## [menupswdset] Ustawienie hasła dostępu do menu......................................................................97
## [eclastprintouts] Wydruk ostatnich dokumentów z pamięci chronionej........................................98
## [ecprnfv] Wydruk faktury z pamięci chronionej............................................................................99
## [eclastdocnoget] Pobranie numeru ostatniego dokumentu określonego typu z pamięci chronionej
.....................................................................................................................................................100
## [billcountercfgget] Odczyt konfiguracji licznika paragonów......................................................101
## [beep] Generowanie sygnału dźwiękowego................................................................................102
## [dsptrnsreleasetimeoutset] Konfiguracja czasu wyświetlania transakcji po jej zakończeniu......103
## [dsptrnsreleasetimeoutget] Odczyt konfiguracji czasu wyświetlania transakcji po jej zakończeniu
.....................................................................................................................................................104
## [billtaxcompressget] Odczyt konfiguracji wydruku podsumowania VAT na paragonie.............105
## [billtaxcompressset] Konfiguracja wydruku podsumowania VAT na paragonie.........................106
## [hdrcompressset] Optymalizacja nagłówka dla wydruków niefiskalnych..................................107
[hdrcompressget]Odczyt optymalizacji nagłówka dla wydruków niefiskalnych........................108
## [ftrcompressset] Optymalizacja stopki dla wydruków niefiskalnych..........................................109
[ftrcompressget]Odczyt optymalizacji stopki dla wydruków niefiskalnych...............................110

## [factorynumberget] Odczyt numeru fabrycznego........................................................................111
## [factorynumberset] Zapis numeru fabrycznego...........................................................................112
## [signatureprintcfgget] Odczyt konfiguracji drukowania kodu 2d podpisu dokumentów............113
## [signatureprintcfgset] Ustawienie konfiguracji drukowania kodu 2d podpisu dokumentów......114
## [usbdrvtypeget] Odczyt typu sterownika USB............................................................................115
## [usbdrvtypeset] Ustawienie typu sterownika USB......................................................................116
## [subgettime] Pobranie informacji o dacie wygaśnięcia subskrypcji na działanie urządzenia.....117
## [verifysignaturesondemandset] Wywołanie weryfikacji podpisów raportów dobowych przy na-
stępnym uruchomieniu urządzenia..............................................................................................118
## [verifysignaturesondemandget] Odczyt zlecenia wywołania weryfikacji podpisów raportów do-
bowych przy następnym uruchomieniu urządzenia.....................................................................119
## [certinfoget] Odczyt certyfikatów z urządzenia...........................................................................120
## [eventhubcertinfoget] Odczyt certyfikatów CA AZURE z urządzenia.......................................122
## [onlineaddressesget] Odczyt adresów serwerów do usług online...............................................123
## [billlotteryconfigget] Odczyt konfiguracji Loterii Paragonowej nadawanej przez repozytorium
.....................................................................................................................................................124
## [sastokeninfoget] Odczyt informacji o SAS Token.....................................................................125
## [checksumsget] Odczyt sum kontrolnych programów................................................................126
## [quantitysigncfgget] Odczyt konfiguracji znaku ilości................................................................127
## [quantitysigncfgset] Konfiguracja znaku ilości...........................................................................128
## [prnspecialcfgset] Konfiguracja wydruków specjalnych.............................................................129
## [prnspecialcfgget] Odczyt konfiguracji wydruków specjalnych.................................................130
## [doccntget] Odczyt liczby wydrukowanych dokumentów..........................................................131
## [changekeys] Wywołanie wymiany kluczy TPM........................................................................132
Dodatkowe sekwencje do zapisu/odczytu........................................................................................133
## [memwrite] Zapis bloku danych do udostępnionej pamięci urządzenia......................................133
## [memread] Odczyt bloku danych z udostępnionej pamięci urządzenia......................................134
Konfiguracja sprzętowa....................................................................................................................135
## [drwparamset] Ustawianie parametrów szuflady........................................................................135
## [drwparamget] Odczyt parametrów szuflady..............................................................................136
## [powerindset] Dźwiękowa sygnalizacja braku zasilania.............................................................137
## [powerindget] Odczyt konfiguracji dźwiękowej sygnalizacja braku zasilania...........................138
## [cuttercfgset] Ustawienie konfiguracji obcinacza........................................................................139
## [cuttercfgget] Odczyt konfiguracji obcinacza..............................................................................140
## [dspcfg] Konfiguracja parametrów wyświetlaczy.......................................................................141
## [dspcfgget] Odczyt konfiguracji parametrów wyświetlaczy.......................................................142
## [kbdlockget] Odczyt ustawień blokowania klawiatury...............................................................143
## [kbdlockset] Zmiana ustawień blokowania klawiatury...............................................................144
## [kbdblockget] Odczyt statusu blokady klawiatury wywoływanej przez protokół.......................145
## [kbdblockset] Blokowanie klawiatury przez protokół.................................................................146
## [timeoutcfgset] Ustawienie czasu po jakim drukarka wyłączy się samoczynnie........................147
## [timeoutcfgget] Odczyt nastawy czasu po jakim drukarka wyłączy się samoczynnie................148
## [soundcfgset] Ustawienie dźwięków klawiszy............................................................................149
## [soundcfgget] Odczyt konfiguracji dźwięków klawiszy.............................................................150
## [comcfgset] Konfiguracja portów szeregowych..........................................................................151
## [comcfgget] Odczyt konfiguracji portów szeregowych...............................................................152
## [pccfgset] Konfiguracja interfejsu PC.........................................................................................153
## [pccfgget] Odczyt konfiguracji interfejsu PC..............................................................................155
## [tcpipcfgset] Konfiguracja interfejsu TCP/IP..............................................................................157

## [tcpipcfgget] Odczyt konfiguracji interfejsu TCP/IP...................................................................158
## [wifinetworkstat] Odczyt statusu sieci WiFi................................................................................159
## [wifilistnetworks] Odczyt listy skonfigurowanych połączeń WiFi.............................................160
## [wifinetworkadd] Konfiguracja połączenia z siecią WiFi...........................................................161
## [wifinetworkdel] Usunięcie konfiguracji wybranej sieci WiFi....................................................162
## [powersavemodeset] Ustawienie konfiguracji trybu oszczędzania energii w module WiFi i Blu-
etooth...........................................................................................................................................163
## [powersavemodeget] Odczyt konfiguracji trybu oszczędzania energii w module WiFi i Bluetooth
.....................................................................................................................................................164
## [bluetoothnameset] Ustawienie nazwy Bluetooth.......................................................................165
## [bluetoothnameget] Odczyt nazwy Bluetooth.............................................................................166
## [tunnelset] Zapis konfiguracji tunelowania.................................................................................167
## [tunnelget] Odczyt konfiguracji tunelowania..............................................................................168
## [fspset] Zapis konfiguracji odczytu pamięci chronionej..............................................................169
## [fspget] Odczyt konfiguracji odczytu pamięci chronionej..........................................................170
## [nearendsensorcfgset] Zapis konfiguracji działania czujnika końca papieru..............................171
## [nearendsensorcfgget] Odczyt konfiguracji działania czujnika końca papieru...........................172
## [chgcfgset] Konfiguracja pracy ładowarki..................................................................................173
## [chgcfgget] Odczyt konfiguracji pracy ładowarki.......................................................................174
Współpraca z serwerami EventHub i WebApi.................................................................................175
## [repositoryeventhubtrigger] Polecenie nawiązania połączenia z serwerem EventHub...............175
## [repositorywebapitrigger] Polecenie nawiązania połączenia z serwerem WebApi.....................176
## [repositoryeventhubstate] Odczyt statusu komunikacji z serwerem EventHub..........................177
## [repositorywebapistate] Odczyt statusu komunikacji z serwerem WebApi.................................178
## [connectionscheduleinfoget] Odczyt informacji o harmonogramie połączeń.............................179
## [repositorysenddatacheck] Sprawdzenie, czy zalecane jest wysłanie danych do repozytorium. 181
## [repositoryunregister] Wyrejestrowanie urządzenia....................................................................182
## [repositoryunregistercheck] Status wyrejestrowania urządzenia.................................................183
Aktualizacja oprogramowania..........................................................................................................184
## [schedulefirmwareupdateget] Odczyt harmonogramu aktualizacji oprogramowania.................184
```
## [firmwareupdatesourceget] Odczyt adresu serwera aktualizacji oprogramowania (SAO).........185
```
## [firmwareupdaterequest] Wywołanie sprawdzania dostępności aktualizacji..............................186
## [firmwareupdatestateget] Pobranie informacji o statusie realizacji komunikacji z SAO............187
## [firmwareupdatedownload] Wywołanie pobierania aktualizacji.................................................188
## [firmwareupdateinstall] Wywołanie instalacji aktualizacji..........................................................189
Obsługa grafiki.................................................................................................................................190
## [imgslotset] Programowanie grafiki............................................................................................190
## [imgslotappend] Programowanie grafiki – dodanie danych........................................................192
## [imgslotisbusy] Sprawdzenie, czy grafika jest w trakcie ładowania...........................................193
## [imgslotcancel] Anuluj ładowanie grafiki....................................................................................194
## [imgslotget] Odczyt parametrów grafiki......................................................................................195
## [imgslotreceive] Odczyt grafiki – odczyt danych........................................................................196
## [imgslotchecksum] Odczyt skrótu grafiki....................................................................................197
## [imgslotdocid] Odczyt numeru dokumentu w pamięci chronionej przypisanego do slotu.........198
## [imgslotdelete] Usunięcie zaprogramowanej grafiki...................................................................199
## [imgprogrep] Potwierdzenie programowania grafiki..................................................................200
## [imgheaderset] Wybór grafiki drukowanej w nagłówku.............................................................201
## [imgfooterset] Wybór grafiki drukowanej w stopce....................................................................202
## [imgdocget] Odczyt ustawień grafiki w dokumencie..................................................................203

## [imgecset] Konfiguracja wydruku grafiki z pamięci chronionej.................................................204
## [imgecget] Odczyt konfiguracji wydruku grafiki z pamięci chronionej......................................205
Współpraca z monitorem transakcji.................................................................................................206
## [trlogset] Konfiguracja interfejsu monitora transakcji.................................................................206
## [trlogget] Odczyt konfiguracji interfejsu monitora transakcji.....................................................207
## [trlogframecfgset] Konfiguracja ramki monitora transakcji........................................................208
## [trlogframecfgget] Odczyt konfiguracji ramki monitora transakcji............................................210
Drukowanie raportów.......................................................................................................................211
## [dailyrep] Raport dobowy............................................................................................................211
## [periodicrepbynumbers] Raport okresowy wg numerów............................................................213
## [periodicrepbydates] Raport okresowy wg dat............................................................................215
## [monthlyrep] Raport miesięczny.................................................................................................216
## [shiftrep] Raport zmianowy.........................................................................................................217
## [cashstaterep] Raport stanu kasy..................................................................................................218
## [imgrep] Raport grafik.................................................................................................................219
## [servicerep] Raport serwisowy....................................................................................................220
## [hardwarecfgrep] Raport konfiguracji.........................................................................................221
## [commcfgrep] Raport konfiguracji wejścia/wyjścia....................................................................222
## [reponline] Raport online.............................................................................................................223
## [eventsrepbynumbers] Raport zdarzeń wg numerów..................................................................224
## [eventsrepbydates] Raport zdarzeń wg dat..................................................................................226
## [eparagonrep] Raport konfiguracji eDokumentu.........................................................................228
## [endrepro] Raport rozliczeniowy.................................................................................................229
Formatki – wydruki niefiskalne........................................................................................................230
## [formstart] Rozpoczęcie formatki................................................................................................230
## [formisstarted] Status rozpoczęcie formatki................................................................................231
## [formline] Linia formatki.............................................................................................................232
## [formformattedline] Linia formatki z dowolnym formatowaniem..............................................234
## [formbarcode] Numer systemowy w formatce............................................................................235
## [formbarcode2d] dwuwymiarowy kod kreskowy w formatce.....................................................236
## [formcmd] Komenda w formatce................................................................................................237
## [formimage] Grafika w formatce.................................................................................................238
## [formtinyline] Linia formatki z małą czcionką............................................................................239
## [formend] Zakończenie formatki.................................................................................................240
Rodzaje formatek.........................................................................................................................241
2 – Transakcje odłożone..........................................................................................................241
3 – Funkcje operatora..............................................................................................................241
4 – Raport kasjera...................................................................................................................241
5 – Raport środków płatności..................................................................................................242
6 – Sprzedaż zarejestrowana w kasie......................................................................................243
7 – Pokwitowanie....................................................................................................................243
8 – Potwierdzenie wpłaty........................................................................................................243
9 – Bon upominkowy..............................................................................................................243
10 – Nota kredytowa...............................................................................................................243
11 – Nota kredytowa...............................................................................................................244
12 – Kupon rabatowy..............................................................................................................244
13 – Płatność za pobraniem....................................................................................................244
14 – Przelew bankowy............................................................................................................244
15 – Potwierdzenie sprzedaży bonu upominkowego..............................................................245

16 – Rabat dla pracownika......................................................................................................245
17 – Wymiana środków płatności...........................................................................................245
18 – Operacje kasowe.............................................................................................................245
19 – Błędy kasy.......................................................................................................................245
20 – Cennik.............................................................................................................................245
21 – Wydanie bonu upominkowego........................................................................................246
22 – Potwierdzenie transakcji kartą płatniczą.........................................................................246
23 – Potwierdzenie doładowania............................................................................................248
24 – Potwierdzenie skupu waluty...........................................................................................249
25 – Bon rabatowy..................................................................................................................249
26 – Raport zmianowy............................................................................................................249
27 – Rozliczenie konta............................................................................................................250
28 – Raport kasy/kasjera.........................................................................................................250
29 – Wpłata/wypłata...............................................................................................................252
30 – Stany liczników...............................................................................................................252
31 – Raport tankowania..........................................................................................................252
32 – Potwierdzenie zapłaty kartą............................................................................................252
33 – Waluta w sejfie................................................................................................................253
34 – Raport alarmu paliwa......................................................................................................253
35 – Bilet do myjni..................................................................................................................253
36 – Raport stanu paliw..........................................................................................................253
37 – Raport dostawy paliw......................................................................................................254
38 – Raport zmiany BP partnerclub........................................................................................254
39 – Potwierdzenie podarunku................................................................................................254
40 – Potwierdzenie wydania podarunku.................................................................................255
41 – Zamówienie.....................................................................................................................255
42 – Potwierdzenie /Raport /Bon............................................................................................255
43 – Pokwitowanie..................................................................................................................256
200 – Super-formatka..............................................................................................................257
201 – Formatka szeroka..........................................................................................................268
Kontrola bazy danych.......................................................................................................................269
## [dbchkstart] Rozpoczęcie kontroli bazy danych..........................................................................269
## [dbchkline] Linia kontroli bazy danych.......................................................................................271
## [dbchkend] Koniec kontroli bazy danych....................................................................................272
## [dbchkplu] Pytanie o możliwość sprzedaży towaru....................................................................273
## [dbtrdelall] Usunięcie wszystkich rekordów z bazy towarów.....................................................274
Transakcja.........................................................................................................................................275
## [trinit] Rozpoczęcie transakcji.....................................................................................................275
## [trfvinit] Rozpoczęcie faktury vat................................................................................................277
## [trfvbuyer] Dane nabywcy...........................................................................................................279
## [trfvnumber] Numer faktury VAT................................................................................................280
## [trfvfreedata] Niefiskalne dane w fakturze..................................................................................281
## [trfvsep] Separator.......................................................................................................................282
## [trfvcashmet] Metoda kasowa......................................................................................................283
## [trfvselfbill] Samofakturowanie...................................................................................................284
## [trfvreverse] Odwrotne obciążenie..............................................................................................285
## [trfvfree] Zwolnienie podatkowe.................................................................................................286
## [trfvexecution] Egzekucja............................................................................................................287
## [trfvrep] Przedstawiciel................................................................................................................288

## [trfvtransport] Środek transportu.................................................................................................289
## [trfvthreeway] Transakcja trójstronna..........................................................................................291
## [trfvtoursrv] Usługa turystyczna..................................................................................................292
## [trfvothergoods] Towary inne......................................................................................................293
## [trline] Linia transakcji................................................................................................................295
## [trnipset] Drukowanie NIP-u nabywcy........................................................................................297
## [fvprncopy] Drukowanie kopii ostatniej faktury.........................................................................299
Rabaty i narzuty................................................................................................................................300
## [trdiscntvat] Rabat w stawce PTU...............................................................................................300
## [trdiscntline] Rabat narzut do dowolnej linii...............................................................................302
## [trdiscntpromo] Promocja............................................................................................................304
## [trdiscntsubtot] Rabat narzut do podsumy...................................................................................306
## [trdiscntbill] Rabat narzut od paragonu.......................................................................................308
Transakcja opakowań.......................................................................................................................310
## [trpackinit] Rozpoczęcie transakcji opakowań............................................................................310
## [trpack] Linia opakowań..............................................................................................................311
## [trpackprnend] Wydruk linii opakowań w zakończeniu transakcji..............................................312
Zakończenie transakcji.....................................................................................................................314
## [trpayment] Forma płatności w zakończeniu transakcji..............................................................314
## [trpaymentdelete] Usunięcie formy płatności w zakończeniu transakcji....................................316
## [trpaymentcurr] Waluta w zakończeniu transakcji.......................................................................317
## [trpaymentcurrdelete] Usunięcie płatności walutą w zakończeniu transakcji.............................319
## [trpaymentcanc] Anulowanie wszystkich form płatności w zakończeniu transakcji..................320
## [showsubtotal] Pokaż podsumę...................................................................................................321
## [trsubtotcanc] Anulowanie danych wprowadzonych w podsumie..............................................322
## [tradvance] Zaliczka....................................................................................................................323
## [trend] Zakończenie transakcji.....................................................................................................325
## [prncancel] Anulowanie transakcji lub wydruku.........................................................................326
## [hardprncancel] Anulowanie transakcji lub wydruku niezależnie od interfejsu, który je zainicjali-
zował............................................................................................................................................327
```
Polecenia eDokument (eParagon i eFaktura)...................................................................................328
```
## [eparagondefaultget] Pobranie konfiguracji domyślnego serwera usługi eDokument................328
## [eparagondefaultset] Ustawienie konfiguracji domyślnego serwera usługi eDokument.............329
## [eparagonstatusget] Odczyt stanu usługi eDokument..................................................................331
## [eparagonstatusset] Ustawienie stanu usługi eDokument............................................................332
## [eparagonidzcancel] Anulowanie eDokumentu...........................................................................333
```
## [eparagonidznext] Ustawienie identyfikatora użytkownika (IDZ) kolejnego eDokumentu.......334
```
## [eparagonidzprev] Utworzenie eDokumentu z poprzedniego dokumentu...................................335
## [eparagonserverins] Ustawienie konfiguracji dodatkowego serwera usługi eDokument............336
## [eparagonserverget] Odczyt konfiguracji dodatkowego serwera usługi eDokument..................338
## [eparagonserverdel] Usunięcie konfiguracji dodatkowego serwera usługi eDokument.............340
## [eparagonserversearch] Znalezienie konfiguracji dodatkowego serwera usługi eDokument po ad-
resie serwera................................................................................................................................341
## [eparagonscheduleset] Ustawienie harmonogramu domyślnego usługi eDokument..................342
## [eparagonscheduleget] Pobieranie harmonogramu domyślnego usługi eDokument...................343
## [eparagonservercontextset] Ustawienie kontekstu do odczytu bazy serwerów eDokument.......344
## [eparagonbufferget] Odczyt rekordu z bufora eDokument..........................................................345
## [eparagonbufferdelall] Skasowanie całego bufora eDokument...................................................347
## [eparagonbufferdelrec] Skasowanie rekordu z bufora eDokument.............................................348

## [eparagonbuffercontextset] Ustawienie kontekstu do odczytu bufora eDokument.....................349
## [eparagonbuffercontextget] Odczyt kontekstowy rekordu z bufora eDokument........................350
## [eparagonconnectiontest] Wykonanie testowego połączenia z serwerem eDokument................352
## [eparagongraphicsend] Wysłanie grafiki ze slotu na wybrany serwer eDokument.....................353
## [eparagongraphicsendall] Wysłanie wszystkich grafik na wybrany serwer eDokument.............354
## [eparagonbufferoverrideset] Ustawienie nadpisywania bufora eDokument................................355
## [eparagonbufferoverrideget] Odczyt ustawienia nadpisywania bufora eDokument...................356
## [eparagonbufferfreecntget] Odczyt ilości wolnych rekordów bufora eDokument......................357
## [eparagonbuffersummaryget] Odczyt podsumowania rekordów bufora eDokument.................358
Kody 2D...........................................................................................................................................359
## [azteccode] przygotowanie do wydruku dwuwymiarowego kodu kreskowego Aztec................360
## [dmcode] przygotowanie do wydruku dwuwymiarowego kodu kreskowego Data Matrix.........361
## [pdf417code] przygotowanie do wydruku dwuwymiarowego kodu kreskowego Pdf417..........362
## [qrcode] przygotowanie do wydruku dwuwymiarowego kodu kreskowego QrCode.................364
Linie informacyjne...........................................................................................................................365
## [trftrln] Dodatkowe linie po transakcji........................................................................................365
## [trftrend] Zakończenie stopki po transakcji.................................................................................370
## [stocash] Zwrot towaru................................................................................................................371
## [packret] Zwrot opakowania........................................................................................................372
## [login] Logowanie kasjera...........................................................................................................373
## [logout] Wylogowanie kasjera.....................................................................................................374
## [cash] Wpłata i wypłata z/do kasy...............................................................................................375
Statusy urządzenia............................................................................................................................376
## [scomm] Status ogólny................................................................................................................376
## [strns] Status transakcji................................................................................................................377
## [sfsk] Status pamięci fiskalnej.....................................................................................................378
## [stot] Status totalizerów...............................................................................................................380
## [scnt] Status liczników.................................................................................................................383
## [sprn] Status mechanizmu............................................................................................................384
## [sdev] Status ogólny.....................................................................................................................385
## [sdrwr] Status szuflady................................................................................................................386
## [progid] Programowanie własnej nazwy, wersji i numeru identyfikacyjnego.............................387
## [resetprogid] Przywrócenie fabrycznych ustawień identyfikatorów...........................................388
## [sid] Zaprogramowany typ i wersja oprogramowania.................................................................389
## [getprogfiscid] Zaprogramowany numer identyfikacyjny...........................................................390
## [getrealid] Odczyt fabrycznej nazwy, wersji i numeru unikatowego..........................................391
## [usetypeget] Odczyt typu użytkowania kasy...............................................................................393
## [ownershiptypeget] Odczyt typu własności kasy.........................................................................394
## [sdspexternal] Status wyświetlacza wewnętrzny/zewnętrzny.....................................................395
## [scashstate] Niefiskalny stan kasy...............................................................................................396
Odczyt zawartości pamięci fiskalnej................................................................................................397
## [fmrectypeget] Odczyt rekordów pamięci fiskalnej wg numerów..............................................397
## [fmrecfindbydate] Odczyt rekordów pamięci fiskalnej wg czasu i daty.....................................399
## [fmrecrd] Odczyt rekordu raportu dobowego o zadanym numerze.............................................400
## [fmrecvat] Odczyt rekordu programowania stawek VAT o zadanym numerze...........................403
## [fmrecclr] Odczyt rekordu zerowania RAM o zadanym numerze..............................................404
## [fmrecfisc] Odczyt rekordu fiskalizacji urządzenia.....................................................................405
## [fmrecend] Odczyt rekordu przejścia w stan 'Tylko do odczytu'.................................................407
## [fmreccurrency] Odczyt rekordu zmiany waluty.........................................................................409

## [fmrecconnectionconfig] Odczyt rekordu zmiany adresu serwera CPD.....................................410
## [fmrecfirmwareupdate] Odczyt rekordu aktualizacji firmware...................................................411
## [fmrecfirmwareupdatefail] Odczyt rekordu niepowodzenia aktualizacji firmware....................412
## [fmrecservicemode] Odczyt rekordu wejścia/wyjścia z trybu serwisowego...............................413
## [fmrecmemorychange] Odczyt rekordu wymiany pamięci chronionej.......................................414
## [fmrecalgorithmerase] Odczyt rekordu kasowania algorytmu weryfikującego..........................415
## [fmrecupdatesourcechange] Odczyt rekordu zmiany źródła aktualizacji programu urządzenia. 416
## [fmrecdatetime] Odczyt rekordu zmiany daty i czasu.................................................................417
## [fmreckeychange] Odczyt rekordu wymiany klucza publicznego..............................................418
## [fmrecservice] Odczyt rekordu zdarzenia przeglądu technicznego.............................................419
## [fmrecmemoryverification] Odczyt rekordu zdarzenia błędu weryfikacji pamięci chronionej. .420
## [fmrecpowerfail] Odczyt rekordu zdarzenia awarii zasilania......................................................421
## [fmrecenumfail] Odczyt rekordu zdarzenia utraty ciągłości dokumentów.................................422
## [fmrecdataverification] Odczyt rekordu zdarzenia błędu weryfikacji danych............................423
## [fmrecprotmemoryfull] Odczyt rekordu zdarzenia zapełnienia pamięci chronionej...................424
## [fmrecfmmemoryfull] Odczyt rekordu zdarzenia zapełnienia pamięci fiskalnej........................425
## [fmrecprinterdisconnected] Odczyt rekordu zdarzenia odłączenia mechanizmu drukującego...426
## [fmreclcddisconnected] Odczyt rekordu zdarzenia odłączenia wyświetlacza klienta.................427
## [fmreckeysend] Odczyt rekordu zdarzenia braku przekazu klucza publicznego........................428
## [fmrecaddress] Odczyt rekordu zdarzenia zmiany adresu podatnika..........................................429
Znaki dopuszczalne w nazwach towarów........................................................................................430
Obliczenia realizowane przez drukarkę............................................................................................431
Obliczenia realizowane w trakcie transakcji...............................................................................431
Obliczenia realizowane w trakcie drukowania raportu dobowego..............................................435
Obliczenia realizowane w trakcie drukowania raportu okresowego...........................................437
Rozliczanie groszy.......................................................................................................................439
Opisy błędów....................................................................................................................................441

Ogólny opis protokołu
Budowa ramki protokołu
pole wartość uwagi
STX 02h Rozpoczyna ramkę
id_polecenia Mnemonik polecenia Identyfikator polece-
nia
TAB 09h Znak tabulacji. Wystę-
puje po każdym iden-
tyfikatorze polecenia
lub parametrze.
...
id_parametru Dwu znakowy mne-
monik parametru
Identyfikator parame-
tru poprzedza każdy
parametr. Kolejność
parametrów jest do-
wolna w każdej se-
kwencji.
Wartość parametru Tekst lub liczba w za-
pisie dziesiętnym
Ilość parametrów w
sekwencji jest zależna
od polecenia
TAB 09h Po każdym parametrze
zawsze występuje
znak tabulacji
TOKEN @XXXX Opcjonalne pole. To-
ken rozpoczyna się od
```
znaku @ (40h) i wy-
```
stępuje w postaci
czterech cyfr dziesięt-
nych. Może występo-
wać w dowolnym
miejscu między id_po-
lecenia a #CRC16
TAB 09h Po tokenie także nale-
ży przesłać tabulację.
...
# Znak '#' Znak poprzedzający
sumę kontrolną
CRC16 Liczba w zapisie
szesnastkowym
Suma kontrolna liczo-
na na podstawie algo-
rytmu CRC16-

CCITT.
ETX 03h Kończy ramkę proto-
kołu.
Suma kontrolna
Przy obliczaniu sumy kontrolnej ramki protokołu nie bierze się pod uwagę znaków: STX, ETX oraz
znaku '#' poprzedzającego sumę kontrolną.
Suma kontrolna sekwencji liczona jest wg wariantu algorytmu CRC16-CCITT o parametrach:
Parametr algorytmu Używana wartość Opis
poly 0x1021 Użyty wielomian.
init 0x0000 Wartość początkowa sumy.
```
refin Nie (False) Czy odwracać bity na wejściu?
```
```
refout Nie (False) Czy odwracać bity na wyjściu?
```
xorout 0x0000 Wartość z którą otrzymana su-
ma jest xorowana w ostatnim
etapie obliczania.
Użytą implementację można zwyczajowo zweryfikować obliczając sumę z napisu „123456789”.
Oczekiwana wartość to 0x31c3.
Przykładowa implementacja w języku C algorytmu wykorzystywanego w drukarce do obliczania
```
sumy:
```
```
```c
unsigned char crc16htab[] = {0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70,
```
0x81, 0x91, 0xa1, 0xb1, 0xc1, 0xd1, 0xe1, 0xf1,0x12, 0x02, 0x32, 0x22, 0x52, 0x42, 0x72, 0x62,
0x93, 0x83, 0xb3, 0xa3, 0xd3, 0xc3, 0xf3, 0xe3,0x24, 0x34, 0x04, 0x14, 0x64, 0x74, 0x44, 0x54,
0xa5, 0xb5, 0x85, 0x95, 0xe5, 0xf5, 0xc5, 0xd5,0x36, 0x26, 0x16, 0x06, 0x76, 0x66, 0x56, 0x46,
0xb7, 0xa7, 0x97, 0x87, 0xf7, 0xe7, 0xd7, 0xc7,0x48, 0x58, 0x68, 0x78, 0x08, 0x18, 0x28, 0x38,
0xc9, 0xd9, 0xe9, 0xf9, 0x89, 0x99, 0xa9, 0xb9,0x5a, 0x4a, 0x7a, 0x6a, 0x1a, 0x0a, 0x3a, 0x2a,
0xdb, 0xcb, 0xfb, 0xeb, 0x9b, 0x8b, 0xbb, 0xab,0x6c, 0x7c, 0x4c, 0x5c, 0x2c, 0x3c, 0x0c, 0x1c,
0xed, 0xfd, 0xcd, 0xdd, 0xad, 0xbd, 0x8d, 0x9d,0x7e, 0x6e, 0x5e, 0x4e, 0x3e, 0x2e, 0x1e, 0x0e,
0xff, 0xef, 0xdf, 0xcf, 0xbf, 0xaf, 0x9f, 0x8f,0x91, 0x81, 0xb1, 0xa1, 0xd1, 0xc1, 0xf1, 0xe1,
0x10, 0x00, 0x30, 0x20, 0x50, 0x40, 0x70, 0x60,0x83, 0x93, 0xa3, 0xb3, 0xc3, 0xd3, 0xe3, 0xf3,
0x02, 0x12, 0x22, 0x32, 0x42, 0x52, 0x62, 0x72,0xb5, 0xa5, 0x95, 0x85, 0xf5, 0xe5, 0xd5, 0xc5,
0x34, 0x24, 0x14, 0x04, 0x74, 0x64, 0x54, 0x44,0xa7, 0xb7, 0x87, 0x97, 0xe7, 0xf7, 0xc7, 0xd7,
0x26, 0x36, 0x06, 0x16, 0x66, 0x76, 0x46, 0x56,0xd9, 0xc9, 0xf9, 0xe9, 0x99, 0x89, 0xb9, 0xa9,
0x58, 0x48, 0x78, 0x68, 0x18, 0x08, 0x38, 0x28,0xcb, 0xdb, 0xeb, 0xfb, 0x8b, 0x9b, 0xab, 0xbb,
0x4a, 0x5a, 0x6a, 0x7a, 0x0a, 0x1a, 0x2a, 0x3a,0xfd, 0xed, 0xdd, 0xcd, 0xbd, 0xad, 0x9d, 0x8d,
0x7c, 0x6c, 0x5c, 0x4c, 0x3c, 0x2c, 0x1c, 0x0c,0xef, 0xff, 0xcf, 0xdf, 0xaf, 0xbf, 0x8f, 0x9f,
```
0x6e, 0x7e, 0x4e, 0x5e, 0x2e, 0x3e, 0x0e, 0x1e};
```
```

```
```c
unsigned char crc16ltab[] = {0x00, 0x21, 0x42, 0x63, 0x84, 0xa5, 0xc6, 0xe7,
```
0x08, 0x29, 0x4a, 0x6b, 0x8c, 0xad, 0xce, 0xef,0x31, 0x10, 0x73, 0x52, 0xb5, 0x94, 0xf7, 0xd6,
0x39, 0x18, 0x7b, 0x5a, 0xbd, 0x9c, 0xff, 0xde,0x62, 0x43, 0x20, 0x01, 0xe6, 0xc7, 0xa4, 0x85,
0x6a, 0x4b, 0x28, 0x09, 0xee, 0xcf, 0xac, 0x8d,0x53, 0x72, 0x11, 0x30, 0xd7, 0xf6, 0x95, 0xb4,
0x5b, 0x7a, 0x19, 0x38, 0xdf, 0xfe, 0x9d, 0xbc,0xc4, 0xe5, 0x86, 0xa7, 0x40, 0x61, 0x02, 0x23,
0xcc, 0xed, 0x8e, 0xaf, 0x48, 0x69, 0x0a, 0x2b,0xf5, 0xd4, 0xb7, 0x96, 0x71, 0x50, 0x33, 0x12,
0xfd, 0xdc, 0xbf, 0x9e, 0x79, 0x58, 0x3b, 0x1a,0xa6, 0x87, 0xe4, 0xc5, 0x22, 0x03, 0x60, 0x41,
0xae, 0x8f, 0xec, 0xcd, 0x2a, 0x0b, 0x68, 0x49,0x97, 0xb6, 0xd5, 0xf4, 0x13, 0x32, 0x51, 0x70,
0x9f, 0xbe, 0xdd, 0xfc, 0x1b, 0x3a, 0x59, 0x78,0x88, 0xa9, 0xca, 0xeb, 0x0c, 0x2d, 0x4e, 0x6f,
0x80, 0xa1, 0xc2, 0xe3, 0x04, 0x25, 0x46, 0x67,0xb9, 0x98, 0xfb, 0xda, 0x3d, 0x1c, 0x7f, 0x5e,
0xb1, 0x90, 0xf3, 0xd2, 0x35, 0x14, 0x77, 0x56,0xea, 0xcb, 0xa8, 0x89, 0x6e, 0x4f, 0x2c, 0x0d,
0xe2, 0xc3, 0xa0, 0x81, 0x66, 0x47, 0x24, 0x05,0xdb, 0xfa, 0x99, 0xb8, 0x5f, 0x7e, 0x1d, 0x3c,
0xd3, 0xf2, 0x91, 0xb0, 0x57, 0x76, 0x15, 0x34,0x4c, 0x6d, 0x0e, 0x2f, 0xc8, 0xe9, 0x8a, 0xab,
0x44, 0x65, 0x06, 0x27, 0xc0, 0xe1, 0x82, 0xa3,0x7d, 0x5c, 0x3f, 0x1e, 0xf9, 0xd8, 0xbb, 0x9a,
0x75, 0x54, 0x37, 0x16, 0xf1, 0xd0, 0xb3, 0x92,0x2e, 0x0f, 0x6c, 0x4d, 0xaa, 0x8b, 0xe8, 0xc9,
0x26, 0x07, 0x64, 0x45, 0xa2, 0x83, 0xe0, 0xc1,0x1f, 0x3e, 0x5d, 0x7c, 0x9b, 0xba, 0xd9, 0xf8,
```
0x17, 0x36, 0x55, 0x74, 0x93, 0xb2, 0xd1, 0xf0};
```
```
unsigned char hi=0, lo=0, index;const char *s= "Ala ma kota.";
```
```
printf ( "crc od '%s' wynosi: ", s);for (s;*s;s++)
```
```
{ index = hi ^ *s;hi = lo ^ crc16htab[index];
```
```
lo = crc16ltab[index];}
```
```
printf ( "%04X", (hi << 8) | lo );
```
```
Przykład obliczania sumy kontrolnej sekwencji:
```plaintext
[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]
```
1. Odrzucamy STX, ETX oraz sumę kontrolną wraz z poprzedzającym znakiem '#' i otrzymujemy
trinit[TAB]bm0[TAB]
2. Po zastosowaniu algorytmu otrzymujemy wartość:
```c
0x4825
3. Co daje nam ramkę do wysłania w postaci:
[STX]trinit[TAB]bm0[TAB]#4825[ETX]
Odpowiedzi drukarki
Standardowa odpowiedź drukarki w przypadku przyjęcia poprawnej sekwencji:
[STX]identyfikator_rozkazu[TAB]#CRC16[ETX]
Odpowiedź drukarki w przypadku przyjęcia niepoprawnej sekwencji lub błędu jej wykonania :
[STX]identyfikator_rozkazu[TAB]?nnnn#CRC16[ETX]
nnnn – numer błędu, liczba w zapisie dziesiętnym
```

Błędy ramki
Budowa ramki odpowiedzi drukarki na przyjęcie błędnej ramki protokołu:
STX ERR TAB [@TOKEN TAB] ?ERR_NO TAB [cmID_POLECENIA TAB [fdNAZWA_POLA
TAB]] CRC16 ETX
```
opis:
```
```
STX – znak rozpoczynający ramkę (02h)
```
ERR – napis „ERR”, oznacza ramkę wysłaną przez drukarkę jako odpowiedź na błędną ramkę
```
TAB – tabulator (09h), separator pól ramki
```
```
@TOKEN – token poprzedzony zawsze znakiem '@' (pole opcjonalne)
```
?, cm, fd – nazwy pól ramki, poprzedzają odsyłane dane.
ERR_NO – numer błędu. Wykaz błędów znajduje się w ostatnim rozdziale specyfikacji.
```
ID_POLECENIA – identyfikator rozpoznanego polecenia w którym został znaleziony błąd (pole
```
```
opcjonalne)
```
```
NAZWA_POLA – nazwa pola w którym został wykryty błąd (pole opcjonalne)
```
CRC – suma kontrolna
```
ETX – znak kończący ramkę (03h)
```
Typy danych
```
Num. - wartość numeryczna w zapisie dziesiętnym. Separator części ułamkowej: „.” lub „,” (prze-
```
```
cinek lub kropka).
```
```
Kwota – typ określający wartość kwotową (np.: cena towaru, wartość rabatu kwotowego).
```
Wartość maksymalna wynosi 9999999999.
W tym typie danych nie przesyła się separatora części ułamkowej. Dwie ostatnie cyfry stanowią
część ułamkową.
Totalizer – totalizer dobowy. Maksymalna wartość wynosi 49999999999. W tym typie danych nie
przesyła się separatora części ułamkowej. Dwie ostatnie cyfry stanowią część ułamkową.
Alfanum – wartość alfanumeryczna przesyłana za pomocą znaków ASCII. Dopuszczalne są znaki z
zakresu 0x20-0xFF – w stronie kodowej WINDOWS-1250 drukowane są wszystkie znaki z zakre-
su. W innych stronach kodowych powyżej 0x7F drukowane są tylko znaki z alfabetu polskiego w
odpowiednim kodowaniu oraz elementy budowy tabeli, pozostałe zamieniane są na spacje.
```
Kody znaków (hex) wykorzystywane do budowy tabeli w różnych kodowaniach:
```
└ ┘ ┌ ┐ ┴ ┬ ├ ┤ │ ─ ┼
WINDOWS-1250 81 88 90 98 A0 A4 A8 AD B2 B4 B8
MAZOVIA C8 BC C9 BB CA CB CC B9 BA CD CE
LATIN 2 81 82 83 84 85 86 87 88 89 8A 8B
Data – data w formacie yyyy-mm-dd. Znak „-” może być zastąpiony znakami: '.' i '/'
```
Data i czas - yyyy-mm-dd,hh:mm. Znak „,” może być zastąpiony przez: spację i ';'.
```
Data i czas ISO8601 - YYYY-MM-DDThh:mm:ss±hh:mm. Dane w standardzie ISO 8601.
BOOL – wartość typu Bool. Może przyjmować wartości:
dla True: 1 lub t lub T lub Y lub y
dla False: 0 lub n lub N

Tryby wykonania poleceń
Urządzenie posiada dwa trybu wykonywania poleceń: synchroniczny i asynchroniczny.
Tryb synchroniczny – w tym trybie można wysłać wszystkie polecenia protokołu. Przesłane polece-
nia zapisywane są buforze odbiorczym i kolejno wykonywane. Odpowiedź na polecenie odsyłana
jest po jego wykonaniu.
```
Tryb asynchroniczny – w tym trybie można przesłać tylko niektóre polecenia protokołu (sprn,
```
```
sdev). Przesłane w tym trybie polecenia wykonywane są natychmiast. Odpowiedzi urządzenia na te
```
polecenia również odsyłane są na bieżąco. Aby polecenie zostało wysłane w trybie asynchronicz-
nym należy jego identyfikator poprzedzić znakiem '!'.

Sekwencje sterujące
## [rtcset] Ustawianie daty i czasu
Identyfikator polecenia:
rtcset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Data i czas TAK Data i czas Ograniczenia w działaniu w
trybie fiskalnym.
st Czy programowany czas jest
czasem letnim?
NIE BOOL True – czas letni
False – czas zimowy
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. W trybie fiskalnym zakres regulacji zegara ograniczony jest do 2 godzin. Zmianę czasu
można wykonać po raporcie dobowym przy zerowych totalizerach.
2. Jeśli parametr st nie został przesłany, urządzenie ustawi czas wg czasu obecnie obowiązują-
cego.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```
```plaintext
[STX]rtcset[TAB]da2018-08-20;13:02[TAB]#CRC16[ETX]
```
```
```
Wydruk:
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

## [rtcget] Odczyt daty i czasu
Identyfikator polecenia:
rtcget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data i czas - Data i czas
tm Data i czas - Data i czas
ISO8601
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
```plaintext
[STX]rtcget[TAB]da2020-10-20;11:49[TAB]tm2020-10-20T11:49:13+02:00[TAB]#CRC16[ETX]
```
```
Przykład:
```plaintext
[STX]rtcget[TAB]#CRC16[ETX]
```

## [rtcsync] Wywołanie synchronizacji czasu przez protokół
Identyfikator polecenia:
rtcsync
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]rtcsync[TAB]#CRC16[ETX]
```

## [vatset] Programowanie stawek PTU
Identyfikator polecenia:
vatset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
va Wartość stawki A w procentach NIE Num. Brak parametru oznacza stawkę
nieaktywną. Poprawna przesyła-
na wartość procentowa stawki
```
zawiera się w granicach (0 –
```
```
99,99).
```
vb Wartość stawki B w procentach NIE Num.
vc Wartość stawki C w procentach NIE Num.
vd Wartość stawki D w procentach NIE Num.
ve Wartość stawki E w procentach NIE Num.
vf Wartość stawki F w procentach NIE Num.
vg Wartość stawki G w procentach NIE Num.
da Aktualna data NIE Data Data jest weryfikowana z bieżą-
cym ustawieniem zegara syste-
mowego.
W przypadku braku parametru
użytkownik musi potwierdzić da-
tę z klawiatury.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wartość stawki 100 oznacza stawkę zwolnioną.
2. Wartość stawki 101 oznacza stawkę nieaktywną.
3. Nie można zaprogramować wszystkich stawek jako nieaktywnych.
4. Próba zmiany stawek na takie same jak już są zaprogramowane w urządzeniu, powoduje po-
minięcie wykonania operacji i odesłanie statusu poprawnego wykonania polecenia.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
[STX]vatset[TAB]va23[TAB]vb8[TAB]vc3[TAB]vd0[TAB]ve0[TAB]vf101[TAB]
vg100[TAB]#CRC16[ETX]
```
Wydruk:
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

## [vatget] Odczyt stawek PTU
Identyfikator polecenia:
vatget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
va Wartość stawki A w procentach - Num. Poprawna wartość procentowa
stawki zawiera się w granicach
```
(0 – 99,99)
```
Odsyłane jest zawsze siedem sta-
wek. Wartości przesyłane są z
przecinkiem.
101,00 – stawka nieaktywna
100,00 – stawka zwolniona
vb Wartość stawki B w procentach - Num.
vc Wartość stawki C w procentach - Num.
vd Wartość stawki D w procentach - Num.
ve Wartość stawki E w procentach - Num.
vf Wartość stawki F w procentach - Num.
vg Wartość stawki G w procentach - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
[STX]vatget[TAB]va22,00[TAB]vb7,00[TAB]vc101,00[TAB]vd101,00[TAB]ve101,00[TAB]vf101
,00[TAB]vg100,00[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]vatget[TAB]#CRC16[ETX]
```

## [vatautoset] Programowanie automatycznej zmiany stawek PTU
Identyfikator polecenia:
vatautoset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
on Włącz/wyłącz automatyczną
zmianę stawek PTU.
TAK BOOL True – automatyczna
zmiana stawek włączo-
na,
pole daty wymagane.
False – automatyczna
zmiana stawek wyłączo-
na,
pozostałe pola ignoro-
wane.
va Wartość stawki A w procentach NIE Num. Brak parametru oznacza
stawkę
nieaktywną. Poprawna
przesyłana wartość pro-
centowa
stawki zawiera się w
granicach
```
(0 – 99,99).
```
vb Wartość stawki B w procentach NIE Num.
vc Wartość stawki C w procentach NIE Num.
vd Wartość stawki D w procentach NIE Num.
ve Wartość stawki E w procentach NIE Num.
vf Wartość stawki F w procentach NIE Num.
vg Wartość stawki G w procentach NIE Num.
da Data i czas automatycznej zmiany
stawek
NIE Data i czas
ra Automatyczna zmiana stawek bez
udziału użytkownika.
NIE BOOL True – użytkownik nie
musi potwierdzać wyko-
nania zmiany stawek
```
PTU (jeżeli jest to ko-
```
nieczne wykona się
również automatyczny
```
raport dobowy). Do-
```
myślnie: False
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```

1. Wartość stawki 100 oznacza stawkę zwolnioną.
2. Wartość stawki 101 oznacza stawkę nieaktywną.
3. Nie można zaprogramować wszystkich stawek jako nieaktywnych.
4. Dostępność w trybie tylko do odczytu: NIE.
5. Jeżeli jest to konieczne raport dobowy jest wykonywany automatycznie.
6. Automatyczna zmiana stawek powoduje restart urządzenia. Przesłanie stawek identycznych
z już zaprogramowanymi nie powoduje zapisu do pamięci fiskalnej i restartu urządzenia.
7. Jeśli zadeklarowane w poleceniu vatautoset wartości stawek zostaną zaprogramowane w
drukarce przed czasem ich automatycznej zmiany, to automatyczna zmiana stawek nie zo-
stanie wywołana.
Przykład:
[STX]vatautoset[TAB]on1[TAB]va22[TAB]vb7,00[TAB]vg100[TAB]da2010-11-
```
11;11:11[TAB]#CRC16[ETX]
```

## [vatautoget] Odczyt automatycznej zmiany stawek PTU
Identyfikator polecenia:
vatautoget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
on Stan automatycznej zmiany sta-
wek PTU.
- BOOL True – automatyczna
zmiana stawek włączona.
False – automatyczna
zmiana stawek wyłączona.
va Wartość stawki A w procentach - Num. Jeżeli automatyczna zmia-
na stawek PTU jest wyłą-
czona, to zwracane są
obecne wartości stawek
PTU.
vb Wartość stawki B w procentach - Num.
vc Wartość stawki C w procentach - Num.
vd Wartość stawki D w procentach - Num.
ve Wartość stawki E w procentach - Num.
vf Wartość stawki F w procentach - Num.
vg Wartość stawki G w procentach - Num.
da Aktualna data - Data i
czas
Jeżeli automatyczna zmia-
na stawek PTU jest wyłą-
czona, to zwracana jest
aktualna data.
tm Aktualna data - Data i
czas
ISO860
1
Jeżeli automatyczna zmia-
na stawek PTU jest wyłą-
czona, to zwracana jest
aktualna data.
ra Automatyczna zmiana stawek bez
udziału użytkownika.
- BOOL True – użytkownik nie
musi potwierdzać wyko-
nania zmiany stawek PTU
```
(jeżeli jest to konieczne
```
wykona się również auto-
```
matyczny raport dobowy).
```
```
Uwagi:
```

1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
[STX]vatautoget[TAB]on1[TAB]va22,00[TAB]vb7,00[TAB]vc101,00[TAB]vd101,00[TAB]ve-
```
101,00[TAB]vf101,00[TAB]vg100,00[TAB]da2011-11-11;11:11[TAB]da2011-11-
```
11T11:11:00+01:00[TAB]ra1[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]vatautoget[TAB]#CRC16[ETX]
```

## [hdrset] Programowanie nagłówka
Identyfikator polecenia:
hdrset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tx Treść nagłówka tak Alfanum. Może zawierać znaki formatu-
jące. Maksymalna wielkość
nagłówka to 600 bajtów.
pr Zapis nagłówka lub wydruk te-
stowy
tak BOOL True – zapis nagłówkach
False – wydruk testowy na-
główka bez zapisu.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Nagłówek może składać się z następujących pól:
Nazwa firmy – ciąg znaków [256] umieszczony między znacznikami &1…&1 – pole obo-
wiązkowe
```
Kod pocztowy – ciąg znaków [6] w formacie NN-NNN (N – cyfra) między znacznikami
```
&2…&2 – pole obowiązkowe
Miejscowość – ciąg znaków [70] umieszczony między znacznikami &3…&3 – pole obo-
wiązkowe
Poczta – ciąg znaków [70] umieszczony między znacznikami &4…&4 – pole opcjonalne
Ulica – ciąg znaków [70] umieszczony między znacznikami &5…&5 – pole opcjonalne
Numer domu - ciąg znaków [15] umieszczony między znacznikami &6…&6 – pole opcjo-
nalne
Numer lokalu - ciąg znaków [15] umieszczony między znacznikami &7…&7 – pole opcjo-
nalne
Dane dodatkowe – ciąg znaków umieszczony poza pozostałymi znacznikami. Dopuszczalne
jest jednokrotne umieszczenie dodatkowych danych między znacznikami &8...&8 – powo-
duje to ustawienie limitu danych ograniczonych tymi znakami do ciągu znaków [280]– pole
opcjonalne
2. Dane przesłane w nagłówku (z wyjątkiem „Danych dodatkowych” ) są wykorzystane do
utworzenia pliku JPK.
3. Formatowanie tekstu:
◦ wyśrodkowanie – tekst ujęty między znacznikami &c…&c. Wyśrodkowanie stosuje się
do całej linii. Nie jest konieczne kończenie wyśrodkowanego tekstu znacznikiem &c.
◦ podwyższenie – tekst ujęty między znacznikami &h…&h
◦ poszerzenie – tekst ujęty między znacznikami &b…&b

◦ podkreślenie – tekst ujęty między znacznikami &u…&u
◦ pochylenie – tekst ujęty między znacznikami &i…&i
◦ negatyw – tekst ujęty między znacznikami &N…&N
◦ czcionka powiększona 4-krotnie – tekst w linii w której wystąpił przynajmniej jeden
znacznik &H. Powiększenie 4-krotne stosuje się do całej linii. Znacznik &H może wy-
stąpić na dowolnej pozycji w linii.
◦ czcionka pogrubiona, zmniejszona odległość między znakami – tekst ujęty między
znacznikami &s…&s
```
Treść pól nagłówka można dzielić na linie za pomocą znaku końca linii LF (0x0A). Dziele-
```
nie dozwolone jest dla wszystkich pól z wyjątkiem pola „Kod pocztowy”.
W jednej linii można użyć 10 formatowań tekstu.
4. W jednej linii może być wydrukowane do 56 lub 40 znaków – w zależności od użytego me-
```
chanizmu drukującego i ustawień drukarki. Dla formatu tekstu poszerzonego (&b…&b) -
```
```
limit ten zmniejsza się 2-krotnie, a dla czcionki powiększonej 4-krotnie (&H) - limit znaków
```
w linii zmniejsza się 4-krotnie.
5. Znak '&' uzyskuje się poprzez '&&'.
6. Znak znajdujący się za pojedynczym znakiem '&' - nie jest drukowany.
7. W urządzeniach w których można stosować różne szerokości papieru, przy linii o maksy-
malnej długości zaprogramowanej w trybie 80mm/56znaków, po przełączeniu w tryb druko-
wania 40 znaków na linię, nastąpi zawinięcie tekstu z zachowaniem formatowania w prze-
niesionym tekście.
8. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
[STX]hdrset[TAB]tx&c&1Sklep SPOŻYWCZY KONFITURA&1&c[LF]ul.
&c&5Gruszkowa&5&c &6123&6[LF]&c&202-281&2 &3Warszawa&3&c[LF]&c&8Otwarte po-
niedziałek-sobota 7-18&8&c[TAB]pr0[TAB]#CRC16[ETX]
```
Wydruk:
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

## [hdrget] Odczyt nagłówka
Identyfikator polecenia:
hdrget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
tx Treść nagłówka - Alfanum. Może zawierać znaki formatu-
jące.
Przykład odpowiedzi:
[STX]hdrget[TAB]tx&c&b&1Sklep KONFITURA&1[LF]&cul. &5Gruszkowa&5
&6123&6[LF]&c&202-281&2 &3Warszawa&3[LF]&c&8Otwarte poniedziałek-sobota 7-
18&8[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Zwracane formatowanie, może różnić się od przesłanego w rozkazie programującym nagłó-
wek pod względem kolejności odsyłanych znaków formatujących i braku końcowych zna-
ków formatujących kończących daną linię. Kolejność odsyłanych znaków formatujących:
&c, &H, &b, &h, &u, &i, &N, &s.
2. Użyty podczas programowania nagłówka znacznik &w jest odsyłany jako &b.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]hdrget[TAB]#CRC16[ETX]
```

## [ftrinfoget] Odczytywanie linii informacyjnych w stopce
Identyfikator polecenia:
ftrinfoget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
tx Treść linii informacyjnych w
stopce. Linie rozdzielone są zna-
```
kiem LF (0Ah).
```
- Alfanum. W urządzeniu mogą być za-
programowane maksymalnie
trzy linie informacyjne.
Przykład odpowiedzi:
```plaintext
[STX]ftrinfoget[TAB]@6[TAB]tx&c&hDziękujemy[LF]&c&hZAPRASZAMY[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Zasady odsyłania takie jak dla rozkazu hdrget.
2. Dostępność w trybie tylko do odczytu: TAK.
```
Przykład:
```plaintext
[STX]ftrinfoget[TAB]#CRC16[ETX]
```

## [ftrinfoset] Programowanie linii informacyjnych w stopce
Identyfikator polecenia:
ftrinfoset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tx Treść linii informacyjnych w
stopce
TAK Alfanum. W urządzeniu można zapro-
gramować maksymalnie trzy
linie informacyjne. Wszystkie
puste linie na początku i na
końcu parametru tx są pomija-
ne. Nadmiarowe linie przesła-
ne w parametrze tx są pomija-
ne.
lb Czy wydruk na wszystkich do-
kumentach?
NIE BOOL False – tylko na następnym
wydruku dowolnego typu.
True – na wszystkich kolej-
```
nych: paragonach, fakturach,
```
wydrukach rozliczenia opako-
wań oraz wydrukach opisa-
nych w rozdziale Formatki –
wydruki niefiskalne .
Domyślnie False.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Znaki formatujące i ich zastosowanie jak w hdrset:
&b – czcionka poszerzona
&c – wyśrodkowanie tekstu
&h – czcionka wysoka
&u – czcionka podkreślona
&w – czcionka poszerzona
&i – kursywa
&N – czcionka w negatywie
&H – czcionka powiększona 4 krotnie
&s – czcionka pogrubiona, zmniejszona odległość między znakami
2. W obecnej wersji &w i &b oznaczają taki sam format tekstu.
3. Znak '&' uzyskuje się poprzez &&
4. Znak znajdujący się za pojedynczym znakiem & - nie jest drukowany.

5. Wybrany rodzaj formatowania będzie obowiązywał od pierwszego wystąpienia danego zna-
ku formatującego do następnego wystąpienia tego znaku- albo do końca linii. W jednej linii
może znaleźć się 10 znaków rozpoczynających formatowanie i 10 kończących. Wyśrodko-
```
wanie tekstu (&c) i formatowanie &H obowiązuje całą linię.
```
6. Znak LF (0Ah) rozdziela linie.
7. Aby zrezygnować z drukowania zaprogramowanych linii, należy wysłać do drukarki polece-
nie z pustym parametrem tx.
8. W jednej linii może być wydrukowane do 56 lub 40 znaków – w zależności od użytego me-
```
chanizmu drukującego i ustawień drukarki. Dla formatu tekstu poszerzonego (&b…&b) - li-
```
```
mit ten zmniejsza się 2-krotnie, a dla czcionki powiększonej 4-krotnie (&H) - limit znaków
```
w linii zmniejsza się 4-krotnie.
9. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
[STX]ftrinfoset[TAB]tx&c&hDZIĘKUJEMY&c&h[LF]&c&hZAPRASZAMY
PONOWNIE&c&h[TAB]#CRC16[ETX]

## [fiscalize] Fiskalizacja
Identyfikator polecenia:
fiscalize
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ni Numer NIP TAK Alfanum. 10 znaków, tylko cyfry
dl Typ licznika paragonów NIE BOOL True – licznik dobowy
False – licznik ciągły
rn Numer ewidencyjny NIE Alfanum. Do 14 znaków
da Aktualna data i czas NIE Data i czas
pr Drukowanie raportu fiskalizacji NIE BOOL True – raport jest drukowany
```
(domyślnie)
```
False – brak wydruku
ut Typ użytkowania NIE Num. 1 – stała, 2 – rezerwowa, 3 –
mobilna, 5 – inny
ot Typ własności NIE Num. 1 – własność, 2 – dzierżawa,
3 – leasing, 4 – wynajem, 5 –
inny
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Do przeprowadzenia fiskalizacji należy uprzednio zaprogramować odpowiednie dane za po-
mocą instrukcji hdrset, vatset, servicedataset, servicemandataset.
2. Przesłanie parametru rn (numer ewidencyjny) jest jednoznaczne z ponowną fiskalizacją dru-
karki. W przypadku fiskalizacji pierwotnej numer ewidencyjny otrzymywany jest z repozy-
```
torium (CRK).
```
3. Przesłanie poprawnej daty da powoduje że nie trzeba jej potwierdzać na klawiaturze.
4. Typ licznika paragonów dl jest wymagany jeśli zostało przesłane da.
5. Operacja wymaga potwierdzenia poprzez wciśniecie zwory serwisowej po ukazaniu się ko-
munikatu na wyświetlaczu drukarki
6. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```
```plaintext
[STX]fiscalize[TAB]ni1234567890[TAB]da2018-08–20;11:48[TAB]#CRC16[ETX]
```
```

```
Wydruk:
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
wydruk po potwierdzeniu zamiaru kontynuowania fiskalizacji:
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
```
| {PL} ZBF 1801007587 |
```

## [taxofficedataset] Programowanie danych urzędu skarbowego
Identyfikator polecenia:
taxofficedataset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
us Identyfikator urzędu skarbowego TAK Alfanum. Rozmiar 4-10 znaków. Tylko
cyfry.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie pozostawione dla kompatybilności, nie ma wpływu na pracę urządzenia
2. Polecenie działa tylko w trybie niefiskalnym.
3. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]taxofficedataset[TAB]us456[TAB]#CRC16[ETX]
```

## [taxofficedataget] Odczyt danych urzędu skarbowego
Identyfikator polecenia:
taxofficedataget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
us Identyfikator urzędu skarbowego - Alfanum.
Przykład odpowiedzi:
```plaintext
[STX]taxofficedataget[TAB]us456[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Polecenie pozostawione dla kompatybilności, zwraca pusty napis.
2. Polecenie działa tylko w trybie niefiskalnym.
```
Przykład:
```plaintext
[STX]taxofficedataget[TAB]#CRC16[ETX]
```

## [servicedataset] Programowanie danych serwisu
Identyfikator polecenia:
servicedataset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ni NIP serwisu TAK Alfanum. 10 znaków, tylko cyfry.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie działa tylko w trybie niefiskalnym.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]servicedataset[TAB]ni1234567890[TAB]#CRC16[ETX]
```

## [servicedataget] Odczyt danych serwisu
Identyfikator polecenia:
servicedataget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ni NIP serwisu - Alfanum.
Przykład odpowiedzi:
```plaintext
[STX]servicedataget[TAB]ni1234567890[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Polecenie działa tylko w trybie niefiskalnym.
2. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]servicedataget[TAB]#CRC16[ETX]
```

## [servicemandataset] Programowanie danych serwisanta
Identyfikator polecenia:
servicemandataset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwisko serwisanta TAK Alfanum. Do 40 znaków.
id Numer serwisanta TAK Alfanum. Do 10 znaków.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie działa tylko w trybie niefiskalnym.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]servicemandataset[TAB]naJan Kowalski[TAB]id286348[TAB]#CRC16[ETX]
```

## [servicemandataget] Odczyt danych serwisanta
Identyfikator polecenia:
servicemandataget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
na Nazwisko serwisanta - Alfanum.
id Numer serwisanta - Alfanum
Przykład odpowiedzi:
```plaintext
[STX]servicemandataget[TAB]naJan Kowalski[TAB]id286348[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Polecenie działa tylko w trybie niefiskalnym.
```
Przykład:
```plaintext
[STX]servicemandataget[TAB]#CRC16[ETX]
```

## [auth] Wprowadzanie kodu autoryzacyjnego
Identyfikator polecenia:
auth
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
co Kod autoryzacyjny TAK Alfanum. Długość 14 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]auth[TAB]co05301311570451[TAB]#CRC16[ETX]
```

## [authcodereset] Anulowanie wprowadzonego kodu autoryzacyjnego
Identyfikator polecenia:
authcodereset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
co Kod autoryzacyjny TAK Alfanum. Długość 14 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. W trybie fiskalnym nie ma możliwości anulowania kodu bezterminowego.
3. Po resecie kodu, drukarka będzie pracować przez 30 dni od dnia, w którym kod został zrese-
towany a następnie będzie zablokowana, dopóki nie zostanie wprowadzony nowy kod auto-
ryzacyjny.
Przykład:
```plaintext
[STX]authcodereset[TAB]co04058358035856[TAB]#CRC16[ETX]
```

## [authstateget] Odczyt stanu autoryzacji
Identyfikator polecenia:
authstateget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
il Ilość pozostałych dni autoryzacji - Alfanum.
Przykład odpowiedzi:
```plaintext
[STX]authstateget[TAB]@7654[TAB]il30[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Wysłanie rozkazu do drukarki autoryzowanej bezterminowo powoduje odesłanie błędu
ERR_AUTH_AUTHORIZED.
```
Przykład:
```plaintext
[STX]authstateget[TAB]#CRC16[ETX]
```

## [maintenance] Wykonanie przeglądu technicznego
Identyfikator polecenia:
maintenance
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
te Identyfikator serwisanta TAK Alfanum. Długość 20 znaków
da Data kolejnego przeglądu TAK Data
dc Bieżąca data do potwierdzenia
operacji
NIE Data
ek Czy wymieniać klucze automa-
tycznie?
NIE BOOL W przypadku zalecanej wy-
miany kluczy dla:
True - wymiana wykona się
False - wymiana nie wykona
się
Domyślna wartość: False.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Operacja wymaga potwierdzenia poprzez wciśniecie zwory serwisowej po ukazaniu się ko-
munikatu na wyświetlaczu drukarki
3. Powoduje rejestrację zdarzenia wykonania przeglądu technicznego.
4. Informacja o konieczności wykonania przeglądu drukuje się po raporcie dobowym oraz po-
kazuje się na wyświetlaczu po włączeniu urządzenia.
5. Sygnalizacja o zbliżającym się terminie przeglądu uruchamiana jest na 14 dni przed zapro-
gramowaną datą.
Przykład:
```plaintext
[STX]maintenance[TAB]te987789[TAB]da2018-10-30[tab]dc1982-03-02[TAB]ekN[TAB]#CRC16[ETX]
```

## [nextmaintenanceset] Programowanie daty przypomnienia o przeglądzie
technicznym
Identyfikator polecenia:
nextmaintenanceset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Data następnego przeglądu TAK Data
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Informacja o konieczności wykonania przeglądu drukuje się po raporcie dobowym oraz po-
kazuje się na wyświetlaczu po włączeniu urządzenia.
2. Sygnalizacja o zbliżającym się terminie przeglądu uruchamiana jest na 14 dni przed zapro-
gramowaną datą.
3. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]nextmaintenanceset[TAB]da2018-10-30[tab]#CRC16[ETX]
```

## [nextmaintenanceget] Pobranie daty następnego przeglądu serwisowe-
go
Identyfikator polecenia:
nextmaintenanceget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data kolejnego przeglądu - Data
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]nextmaintenanceget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]nextmaintenanceget[TAB]da2021-06-09[TAB]#CRC16[ETX]
```

## [serviceintervention] Zarejestrowanie interwencji serwisowej
Identyfikator polecenia:
serviceintervention
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Bieżąca data do potwierdzenia
operacji
TAK Data
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Operacja wymaga potwierdzenia poprzez wciśniecie zwory serwisowej po ukazaniu się ko-
munikatu na wyświetlaczu drukarki
Przykład:
```plaintext
[STX]serviceintervention[TAB]da1982-03-02[TAB]#CRC16[ETX]
```

## [opendrwr] Otwieranie szuflady
Identyfikator polecenia:
opendrwr
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]opendrwr[TAB]#CRC16[ETX]
```

## [papfeed] Wysuw papieru
Identyfikator polecenia:
papfeed
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ln Ilość linii TAK Num. Maksymalna ilość linii nie może
przekraczać 20.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Nie działa przy włączonej oszczędności papieru
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]papfeed[TAB]ln6[TAB]#CRC16[ETX]
```

## [prncfgset] Konfiguracja wydruków
Identyfikator polecenia:
prncfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nf Flaga konfiguracji wydruków. NIE Num. 1 – wydruki niefiskalne druko-
wane i zapisywane w pamięci
chronionej,
0 – wydruki niefiskalne tylko za-
pisywane w pamięci chronionej
Brak parametru nie zmienia spo-
sobu dotychczasowego działania
urządzenia.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Przesłanie parametru nf spoza zakresu, powoduje ustawienie wartości nf=1.
Przykład:
```plaintext
[STX]prncfgset[TAB]nf0[TAB]#CRC16[ETX]
```

## [prncfgget] Odczyt konfiguracji wydruków
Identyfikator polecenia:
prncfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nf Flaga konfiguracji wydruków. - Num. 1 – wydruki niefiskalne druko-
wane i zapisywane w pamięci
chronionej,
0 – wydruki niefiskalne tylko za-
pisywane w pamięci chronionej
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie dostępne tylko w Pospay, Temo, Trio, Vero, Evo, Fawag Box.
Przykład:
```plaintext
[STX]prncfgget[tab]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]prncfgget[TAB]nf0[TAB]#CRC16[ETX]
```

## [cancelledsaleprintcfgset] Konfiguracja wydruków paragonów i faktur
anulowanych
Identyfikator polecenia:
cancelledsaleprintcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
en Flaga konfiguracji wydruków
paragonów i faktur anulowa-
nych.
TAK BOOL True – drukowanie włączone
False – drukowanie wyłączone
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Transakcje anulowane zawsze zapisywane są w pamięci urządzenia.
Przykład:
```plaintext
[STX]cancelledsaleprintcfgset[TAB]en0[TAB]#CRC16[ETX]
```

## [cancelledsaleprintcfgget] Odczyt konfiguracji wydruków paragonów i
faktur anulowanych
Identyfikator polecenia:
cancelledsaleprintcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
en Flaga konfiguracji wydruków
paragonów i faktur anulowa-
nych.
- BOOL True – drukowanie włączone
False – drukowanie wyłączone
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]cancelledsaleprintcfgget[TAB]#CRC16[ETX]
```

## [billseparatorset] Konfiguracja wydruku separatora na paragonie
Identyfikator polecenia:
billseparatorset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
bl Flaga konfiguracji wydruku se-
paratora na paragonie.
TAK BOOL True – drukowanie separatorów
wyłączone
False – drukowanie separatorów
włączone
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]billseparatorset[TAB]bl1[TAB]#CRC16[ETX]
```

## [billseparatorget] Odczyt konfiguracji wydruku separatora na paragonie
Identyfikator polecenia:
billseparatorget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
bl Flaga konfiguracji wydruku se-
paratora na paragonie.
- BOOL True – drukowanie separatorów
wyłączone
False – drukowanie separatorów
włączone
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]billseparatorget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]billseparatorget[TAB]bl0[TAB]#CRC16[ETX]
```

## [dayreportprintcfgset] Konfiguracja wydruku raportu dobowego
Identyfikator polecenia:
dayreportprintcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
en Flaga drukowania raportu dobo-
wego.
NIE BOOL True – raport dobowy z wydru-
kiem
False – raport dobowy bez wy-
druku
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]dayreportprintcfgset[TAB]en1[TAB]#CRC16[ETX]
```

## [dayreportprintcfgget] Odczyt konfiguracji drukowania raportu dobowe-
go
Identyfikator polecenia:
dayreportprintcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
en Flaga drukowania raportu dobo-
wego.
- BOOL True – raport dobowy z wydru-
kiem
False – raport dobowy bez wy-
druku
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]dayreportprintcfgget[TAB]#CRC16[ETX]
```

## [doccfgset] Konfiguracja zapisu nagłówka dokumentu do pamięci chro-
nionej
Identyfikator polecenia:
doccfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
hc Flaga zapisu nagłówka do pa-
mięci chronionej
NIE BOOL True – nagłówek każdego doku-
mentu zapisywany
False – nagłówki dokumentów
nie zapisywane
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie pozostawione dla kompatybilności ze starszymi wersjami, nie powoduje zmian w
działaniu urządzenia. Obecnie nagłówki nie są zapisywane w pamięci chronionej.
Przykład:
```plaintext
[STX]doccfgset[TAB]hc1[TAB]#CRC16[ETX]
```

## [doccfgget] Odczyt konfiguracji zapisu nagłówka dokumentu do pamięci
chronionej
Identyfikator polecenia:
doccfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
hc Flaga zapisu nagłówka do pa-
mięci chronionej
- BOOL True – nagłówek każdego doku-
mentu zapisywany
False – nagłówki dokumentów
nie zapisywane
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]doccfgget[TAB]#CRC16[ETX]
```

## [prnparamset] Ustawienie parametrów drukowania
Identyfikator polecenia:
prnparamset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ps Czułość papieru NIE Num. Liczba z zakresu <1,4>.
```
1 – duża czułość papieru (mniej
```
energii zużywane do wydruko-
```
wania linii tekstu)
```
```
4 – mała czułość papieru (więcej
```
energii zużywane do wydruko-
```
wania linii tekstu)
```
px Rozszerzona czułość papieru NIE Num. Liczba z zakresu <1,16>.
```
1 – duża czułość papieru (mniej
```
energii zużywane do wydruko-
```
wania linii tekstu)
```
```
16 – mała czułość papieru (wię-
```
cej energii zużywane do wydru-
```
kowania linii tekstu)
```
sp Tryb ekonomiczny NIE Num. Liczba z zakresu <0,1>
0 – tryb ekonomiczny włączony
1 – tryb ekonomiczny wyłączony
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Włączenie trybu ekonomicznego powoduje wolniejsze i dokładniejsze drukowanie tekstu i
grafik zaprogramowanych w urządzeniu.
3. Urządzenia THERMAL XL2 nie obsługują trybu ekonomicznego. Parametr sp jest ignoro-
wany.
4. Parametr px występuje tylko w FAWAG BOX 1.01.
5. Parametr px ma większy priorytet niż parametr ps w sytuacji, gdy oba parametry zostaną
przesłane.
Przykład:
```plaintext
[STX]prnparamset[TAB]ps2[TAB]#CRC16[ETX]
```

## [prnparamget] Odczyt parametrów drukowania
Identyfikator polecenia:
prnparamget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ps Czułość papieru - Num. Liczba z zakresu <1,4>.
```
1 – duża czułość papieru (mniej
```
energii zużywane do wydruko-
```
wania linii tekstu)
```
```
4 – mała czułość papieru (więcej
```
energii zużywane do wydruko-
```
wania linii tekstu)
```
sp Tryb ekonomiczny - Num. Liczba z zakresu <0,1>
0 – tryb ekonomiczny włączony
1 – tryb ekonomiczny wyłączony
px Rozszerzona czułość papieru - Liczba z zakresu <1,16>.
```
1 – duża czułość papieru (mniej
```
energii zużywane do wydruko-
```
wania linii tekstu)
```
```
16 – mała czułość papieru (wię-
```
cej energii zużywane do wydru-
```
kowania linii tekstu)
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Włączenie trybu ekonomicznego powoduje wolniejsze i dokładniejsze drukowanie grafik
zaprogramowanych w urządzeniu.
3. Parametr px występuje tylko w FAWAG BOX 1.01.
Przykład odpowiedzi:
```plaintext
[STX]prnparamget[TAB]ps2[TAB]sp0[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]prnparamget[TAB]#CRC16[ETX]
```

## [prnwidthset] Ustawianie szerokości papieru
Identyfikator polecenia:
prnwidthset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
wd Szerokość papieru TAK Num. Liczba z zakresu <0,2>.
0 – szerokość papieru 80mm, 56
znaków w linii
1 – szerokość papieru 57mm, 40
```
znaków w linii (domyślnie)
```
2 – szerokość papieru 80mm, 40
znaków w linii
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo, Trio, Vero, Evo, Fawag Box.
2. Przesłanie parametru wd spoza zakresu, powoduje ustawienie wartości wd=1.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]prnwidthset[TAB]wd1[TAB]#CRC16[ETX]
```

## [prnwidthget] Odczyt szerokości papieru
Identyfikator polecenia:
prnwidthget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
wd Szerokość papieru - Num. Liczba z zakresu <0,2>.
0 – szerokość 80mm, 56 znaków
1 – szerokość 57mm, 40 znaków
2 – szerokość 80mm, 40 znaków
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo, Trio, Vero, Evo, Fawag Box.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]prnwidthget[TAB]#CRC16[ETX]
```

## [appmodeget] Odczyt rodzaju drukarki
Identyfikator polecenia:
appmodeget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
md Rodzaj drukarki - Num. 0 – standardowa
2 – wolnocłowa
3 – biletowa
5 – standardowa do zabudowy
6 – vendingowa
8 – biletowa do zabudowy
Przykład odpowiedzi:
```plaintext
[STX]appmodeget[TAB]md0[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
```
Przykład:
```plaintext
[STX]appmodeget[TAB]#CRC16[ETX]
```

## [papersavecfg] Konfiguracja trybu oszczędności papieru
Identyfikator polecenia:
papersavecfg
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ps tryb oszczędności papieru TAK BOOL False – wyłączony tryb oszczęd-
ności papieru
True – włączony tryb oszczędno-
ści
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Funkcja oszczędzania papieru, polega na zmniejszeniu odstępu między drukowanymi doku-
mentami. Oszczędność uzyskuje się przez zlikwidowanie górnego marginesu wydruku,
kosztem rozpoczęcia wydruku nagłówka następnego dokumentu - zabieg ten jest niezauwa-
żalny dla użytkownika.
2. Przy włączonej oszczędności papieru, zmiana grafiki w nagłówku nie nastąpi od pierwszego
w kolejności wydruku lecz dopiero od drugiego. Jest to spowodowane rozpoczęciem wydru-
ku starej grafiki jeszcze przed wydrukiem nowego dokumentu.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]papersavecfg[tab]ps0[TAB]#CRC16[ETX]
```

## [papersavecfgget] Odczyt konfiguracji trybu oszczędności papieru
Identyfikator polecenia:
papersavecfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ps tryb oszczędności papieru - BOOL False – wyłączony tryb oszczęd-
ności papieru
True – włączony tryb oszczędno-
ści
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]papersavecfgget[tab]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]papersavecfgget[tab]psT[TAB]#CRC16[ETX]
```

## [ftrcfg] Konfiguracja stopki wydruku
Identyfikator polecenia:
ftrcfg
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
cc Nazwa kasjera NIE Alfanum. Długość do 32 znaków.
Ograniczenia dla opcji wydru-
ku 40 znaków w linii:
dokumenty niefiskalne i ra-
porty fiskalne:
- dla cn o długości 8 znaków,
drukowane jest maksymalnie
```
29 znaków (trzy ostatnie są
```
```
ucinane).
```
```
paragony:
```
- dla licznika ciągłego (opcja
```
fiskalizacji) drukowane są 22
```
znaki.
- dla licznika dobowego (opcja
```
fiskalizacji) drukowane są 24
```
znaki.
cn Numer kasy NIE Alfanum. Długość do 8 znaków.
ca Zakres drukowania nazwy kasje-
ra i numeru kasy.
NIE Bool False – nazwa kasjera i numer
kasy obowiązują tylko do na-
stępnego wydruku
True – nazwa kasjera i numer
kasy obwiązują cały czas
Brak parametru nie zmienia
sposobu dotychczasowego
działania urządzenia.
sn Numer systemowy NIE Alfanum. Długość do 30 znaków
bc Kod kreskowy NIE Alfanum. Długość do 30 znaków
bb Kod kreskowy 2d NIE Num. Wydruk kodu 2d
0 – nie drukuj
1 – drukuj nad kodem 1d
2 – drukuj pod kodem 1d
ln Linia informacyjna NIE Alfanum. To samo co parametr tx w roz-
kazie ftrinfoset. Ograniczenia

w ilości przesłanych linii tak
jak w rozkazie ftrinfoset.
lb Zakres drukowania linii infor-
macyjnej
NIE Bool False – linia inform. drukowa-
na jest tylko na następnym pa-
```
ragonie (domyśl.)
```
True – linia informacyjna dru-
kowana jest na wszystkich pa-
ragonach
fe Sposób zakończenia stopki NIE Num. 0 – z wysuwem i obcięciem
```
papieru (domyślny)
```
1 – z wysuwem bez obcięcia
2 – bez wysuwu i obcięcia
3 – bez wysuwu, obcięcia i
wydruku nagłówka następnego
dokumentu niefiskalnego
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Aby zrezygnować z drukowania nazwy kasjera i numeru kasy przesłanych wraz z parametrem ca=1
```
(nazwa kasjera i numer kasy obwiązują cały czas), należy przesłać puste parametry cc i cn. Spowo-
```
```
duje to przyjęcie domyślnej nazwy kasjera (KIEROWNIK) i numeru kasy (001).
```
2. Aby zrezygnować z drukowania linii informacyjnych przesłanych wraz z parametrem lb=1, należy
przesłać pusty parametr ln.
3. Wysłanie rozkazu z parametrem fe=3 spowoduje wydruk dokumentu niefiskalnego bez nagłówka,
wysuwu i obcięcia tylko bezpośrednio po wydruku paragonu lub faktury. Sekcja dokumentów niefi-
skalnych bez nagłówka może składać się z większej liczby wydruków. W tym celu należy przesyłać
rozkaz z parametrem fe=3 nie bezpośrednio przed wydrukiem, lecz jeden dokument wcześniej.
4. Nie można uzyskać wydruków bez nagłówka (parametr fe=3) jeśli pierwszym wydrukiem po wysła-
niu rozkazu nie będzie paragon lub faktura zakończona pozytywnie. W takim wypadku działanie
rozkazu jest takie jak dla parametru fe=2.
5. Przesłanie parametru bb spoza zakresu, powoduje ustawienie wartości bb na ostatnią poprawną war-
```
tość jaka była przesłana od chwili włączenia urządzenia lub powoduje ustawienie bb=0 (pierwsze
```
```
wysłanie rozkazu po włączeniu urządzenia).
```
6. Przesłanie parametru fe spoza zakresu, powoduje jego zignorowanie.
7. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```
Kod 2d do wydruku powinien być przygotowany wcześniej (polecenia : azteccode, dmcode,
```
```
pdf417code, qrcode)
```
[STX]ftrcfg[TAB]ca1[TAB]ccHELMUT[TAB]cn129[TAB]sn876[TAB]bc1122334455[TAB]lnDZI
ĘKUJEMY[TAB]lb1[TAB]#CRC16[ETX]

## [barcodeheightset] Ustawienie wysokości kodu kreskowego
Identyfikator polecenia:
barcodeheightset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
ht Wysokość kodu kreskowego TAK Num. Zakres: 2-30 (w milimetrach)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]barcodeheightset[TAB]ht10[TAB]#CRC16[ETX]
```

## [barcodeheightget] Odczyt konfiguracji wysokości kodu kreskowego
Identyfikator polecenia:
barcodeheightget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
```
ht Wysokość kodu kreskowego - Num. Zakres: 2-30 (w milimetrach)
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]barcodeheightget[TAB]ht10[TAB]#CRC16[ETX]
```

## [fvcfgset] Ustawienie konfiguracji drukowania faktur
Identyfikator polecenia:
fvcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
co Drukowanie na fakturze napisu
ORYGINAŁ/KOPIA
NIE BOOL True – drukowanie włączone
False – brak drukowania
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]fvcfgset[TAB]co1[TAB]#CRC16[ETX]
```

## [fvcfgget] Odczyt konfiguracji drukowania faktur
Identyfikator polecenia:
fvcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
co Drukowanie na fakturze napisu
ORYGINAŁ/KOPIA
- BOOL True – drukowanie włączone
False – brak drukowania
cm Drukowanie kopii faktury - BOOL True – parametr pozostawiony
dla zachowania kompatybilno-
ści wstecznej, zwraca stałą
wartość
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]fvcfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]fvcfgget[TAB]coT[TAB]cmN[TAB]#CRC16[ETX]
```

## [dspmode] Konfiguracja trybu wyświetlania informacji związanych z
transakcją
Identyfikator polecenia:
dspmode
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ln Czy nazwę sprzedawanego towaru
wyświetlać wraz z wartością?
NIE BOOL True-tak, False-nie
dn Czy nazwę udzielanego rabatu wy-
świetlać wraz z wartością?
NIE BOOL True-tak, False-nie
pn Czy nazwę opakowania zwrotnego
wyświetlać wraz z wartością?
NIE BOOL True-tak, False-nie
yn Czy nazwę formy płatności wy-
świetlać wraz z wartością?
NIE BOOL True-tak, False-nie
cn Czy wyświetlać napis, „Do dopła-
ty”, czy przesłaną formę płatności?
NIE BOOL True-wyświetlanie „Do dopłaty” ,
False-wyświetlanie formy płatno-
ści
ls Czy na wyświetlaczu LED wyświe-
```
tlać wartość pozycji (False) czy
```
```
podsumę (True)?
```
NIE BOOL True-tak, False-nie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Jeżeli z wpłaconych form płatności wynika reszta, wyświetlana jest w pierwszej linii wartość reszty
niezależnie od konfiguracji wyświetlacza.
2. W urządzeniach z wyświetlaczem 4x20 lub graficznym, wyświetlane dane nie zależą od wartości
przesłanych parametrów: ln, dn, pn, cn, ls. Urządzenie stara się wyświetlić jak najwięcej informacji
o transakcji.
3. Nie przesłanie któregoś z parametrów nie zmienia sposobu dotychczasowego działania urządzenia
określanego przez ten parametr.
4. Konfigurację należy przeprowadzać poza transakcją.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dspmode[TAB]dn1[TAB]#CRC16[ETX]
```

## [dsptxtline] Dowolna linia informacyjna na wyświetlaczu
Identyfikator polecenia:
dsptxtline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza TAK Num. Wymagana wartość id = 0
no Numer linii TAK Num. Linie numerowane są od zera.
Wartości spoza zakresu nie
powodują odesłania błędu.
ln Zawartość linii TAK Alfanum. Maksymalna długość linii tek-
stu powinna być dopasowana
do możliwości zastosowanych
wyświetlaczy i nie może prze-
kraczać 30 znaków.
th Wyrównanie linii na wyświetla-
czu.
```
NIE Num. 0 – wyrównanie do lewej (do-
```
```
myślne ustawienie)
```
1 – wycentrowanie
2 – wyrównanie do prawej
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wysłanie sekwencji do wyświetlacza w trakcie transakcji lub po jej zakończeniu ale przed
```
upływem czasu zdefiniowanym poleceniem dsptrnsreleasetimeoutset (5-120 sek.), spowo-
```
```
duje zbuforowanie operacji (będzie wykonana w możliwym momencie).
```
2. Parametr th jest ignorowany dla urządzeń z wyświetlaczem alfanumerycznym. Wyrównanie
linii można regulować tylko w urządzeniach z wyświetlaczem graficznym.
3. W sytuacji, gdy zaprogramowano 4 linie wyświetlacza, a następnie wyświetlany jest zegar
```
systemowy lub tekst wbudowany (polecenie dspcmd id0 st0), powtórne wywołanie komen-
```
dy dsptxtline zmieniającej jedną z linii, spowoduje wyświetlenie również poprzednio zapro-
gramowanych linii.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dsptxtline[TAB]id0[TAB]no1[TAB]lnZAPRASZAMY[TAB]#CRC16[ETX]
```

## [dsptxt] Dowolna zawartość wyświetlacza
Identyfikator polecenia:
dsptxt
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza TAK Num. Wymagana wartość id = 0
st Zawartość wyświetlacza. TAK Alfanum. Maksymalna długość linii tek-
stu powinna być dopasowana
do możliwości zastosowanych
wyświetlaczy. Linie rozdziela
```
znak LF (0Ah)
```
th Wyrównanie linii na wyświetla-
czu.
```
NIE Num. 0 – wyrównanie do lewej (do-
```
```
myślne ustawienie)
```
1 – wycentrowanie
2 – wyrównanie do prawej
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wysłanie sekwencji do wyświetlacza w trakcie transakcji lub po jej zakończeniu ale przed
```
upływem czasu zdefiniowanym poleceniem dsptrnsreleasetimeoutset (5-120 sek.), spowo-
```
```
duje zbuforowanie operacji (będzie wykonana w możliwym momencie).
```
2. Parametr th jest ignorowany dla urządzeń z wyświetlaczem alfanumerycznym. Wyrównanie
linii można regulować tylko w urządzeniach z wyświetlaczem graficznym.
3. Wysłanie pustego parametru st powoduje skasowanie poprzedniego tekstu z wyświetlacza.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dsptxt[TAB]id0[TAB]stZAPRASZAMY[LF]JUTRO[TAB]#CRC16[ETX]
```

## [dspcmd] Wyświetlanie daty i czasu
Identyfikator polecenia:
dspcmd
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza TAK Num. Wymagana wartość id = 0
st Komenda określająca co ma być
wyświetlane
TAK Num. 0 – teksty wbudowane
1 – teksty wcześniej przesłane
2 – data i czas
Dla zachowania kompatybilno-
ści z przyszłymi wersjami, pa-
rametry spoza zakresu nie po-
wodują odesłania błędu i nie
powodują zmiany w działaniu
urządzenia.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wysłanie sekwencji do wyświetlacza w trakcie transakcji lub po jej zakończeniu ale przed
```
upływem czasu zdefiniowanym poleceniem dsptrnsreleasetimeoutset (5-120 sek.), spowo-
```
```
duje zbuforowanie operacji (będzie wykonana w możliwym momencie).
```
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dspcmd[TAB]id0[TAB]st1[TAB]#CRC16[ETX]
```

## [windowtimecfgget] Odczyt konfiguracji czasu wyświetlania komunika-
tów
Identyfikator polecenia:
windowtimecfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ti Komunikat informacyjny - Num. Czas w sekundach
ta Komunikat typu pytanie - Num. Czas w sekundach
te Komunikat typu sygnalizacja
błędu
- Num. Czas w sekundach
tj Komunikat typu informacja ser-
wisowa
- Num. Czas w sekundach
tm Komunikat wieloekranowy - Num. Czas w sekundach
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]windowtimecfgget[TAB]#CRC16[ETX]
```

## [windowtimecfgset] Konfiguracja czasu wyświetlania komunikatów
Identyfikator polecenia:
windowtimecfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ti Komunikat informacyjny NIE Num. Zakres w sekundach: 0 -300
ta Komunikat typu pytanie NIE Num. Zakres w sekundach: 10 -300
te Komunikat typu sygnalizacja
błędu
NIE Num. Zakres w sekundach: 0 -300
tj Komunikat typu informacja ser-
wisowa
NIE Num. Zakres w sekundach: 30 -300
tm Komunikat wieloekranowy NIE Num. Zakres w sekundach: 0 -300
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie działa poza transakcją.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
[STX]windowtimecfgset[TAB]ti111[TAB]ta111[TAB]te111[TAB]tj111[TAB]tm111[TAB]#CRC16[
ETX]

## [windowtimecfgreset] Resetowanie konfiguracja czasu wyświetlania ko-
munikatów
Identyfikator polecenia:
windowtimecfgreset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
ty Tryb obsługi urządzenia NIE Num. 0 – standardowy (z dostępem
```
```
do klawiatury) - domyślnie
```
```
1 – zdalny (przez protokół ko-
```
```
munikacyjny)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie działa poza transakcją.
2. Domyślne czasy komunikatów po resecie:
tryb zdalny
```
informacyjne: 1 sekunda
```
```
pytania: 10 sekund
```
błędy: 2 sekundy
```
serwisowe: 300 sekund
```
```
wieloekranowe: 1 sekunda
```
tryb standardowy
```
informacyjne: 9999 sekund
```
```
pytania: 9999 sekund
```
błędy: 9999 sekund
```
serwisowe: 300 sekund
```
```
wieloekranowe: 3 sekundy
```
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]windowtimecfgreset[TAB]ty0[TAB]#CRC16[ETX]
```

## [discounttypeset] Konfiguracja sposobu obliczania rabatu
Identyfikator polecenia:
discounttypeset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
dt Sposób obliczania rabatu NIE BOOL False – najpierw liczona jest
wartość po rabacie a potem ra-
bat
True– najpierw liczony jest ra-
bat a potem wartość po rabacie
Brak parametru nie zmienia
sposobu dotychczasowego
działania urządzenia.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
dla dt=0
```plaintext
[STX]discounttypeset[TAB]dt0[TAB]#CRC16[ETX]
[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]
[STX]trline[TAB]naDlugopis[TAB]vt2[TAB]pr1350[TAB]st0[TAB]wa1350[TAB]il1[TAB]#CRC16[ETX]
[STX]trdiscntbill[TAB]naPromocja[TAB]rd1[TAB]rp1500[TAB]#CRC16[ETX]
[STX]trend[TAB]to1148[TAB]#CRC16[ETX]
dla dt=1
[STX]discounttypeset[TAB]dt1[TAB]#CRC16[ETX]
[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]
[STX]trline[TAB]naDlugopis[TAB]vt2[TAB]pr1350[TAB]st0[TAB]wa1350[TAB]il1[TAB]#CRC16[ETX]
[STX]trdiscntbill[TAB]naPromocja[TAB]rd1[TAB]rp1500[TAB]#CRC16[ETX]
[STX]trend[TAB]to1147[TAB]#CRC16[ETX]
```

## [discounttypeget] Odczyt konfiguracji sposobu obliczania rabatu
Identyfikator polecenia:
discounttypeget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
dt Sposób obliczania rabatu - BOOL False – najpierw liczona jest
wartość po rabacie a potem ra-
bat
True– najpierw liczony jest ra-
bat a potem wartość po rabacie
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]discounttypeget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]discounttypeget[TAB]dt1[TAB]#CRC16[ETX]
```

## [currrateset] Zmiana przelicznika walut
Identyfikator polecenia:
currrateset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
on Stan przelicznika walut. TAK BOOL True – przelicznik włączony.
Pola ra i na wymagane.
False - przelicznik wyłączony
pozostałe pola ignorowane.
ra Kurs przelicznika walut. NIE Num. Sześć ostatnich cyfr stanowi
część ułamkową. Przesłana
wartość zaokrąglana jest do
czterech miejsc po przecinku.
Na przykład przesłanie warto-
```
ści 50 (0,000050) określa kurs
```
przelicznika na 0,0001
na Symbol waluty. NIE Alfanum. Dokładnie trzy duże litery bez
znaków diakrytycznych.
di Sposób przeliczania wartości w
walucie wg. kursu.
NIE BOOL True – kurs oznacza przelicza-
nie z waluty przesłanej na ewi-
dencyjną
```
(domyślne ustawienie)
```
False – kurs oznacza przelicza-
nie z waluty ewidencyjnej na
przesłaną
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Zabronione jest przesyłanie symbolu identycznego z obecnym symbolem waluty.
2. Maksymalny przelicznik to 9999,9999.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]currrateset[TAB]onT[TAB]ra3333333[TAB]naEUR[TAB]diT[TAB]#CRC16[ETX]
```
– ustawienie kursu: 1 EUR = 3,3333 PLN (zakładając że walutą ewidencyjną jest PLN).
```

[STX]currrateset[TAB]onT[TAB]ra0300055[TAB]naEUR[TAB]diN[TAB]#CRC16[ETX]
```
– ustawienie kursu: 1 PLN = 0,3001 EUR (zakładając że walutą ewidencyjną jest PLN).
```
```

## [currrateget] Odczyt przelicznika walut
Identyfikator polecenia:
currrateget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
on Stan przelicznika walut. - BOOL True – przelicznik włączony,
False – przelicznik wyłączony.
ra Kurs przeliczenia walut - Num. Sześć ostatnich cyfr stanowi
część ułamkową
na Symbol waluty. - Alfanum.
di Sposób przeliczania wartości w
walucie z kursu.
- BOOL True – kurs oznacza przelicza-
nie z waluty przesłanej na ewi-
dencyjną
False – kurs oznacza przelicza-
nie z waluty ewidencyjnej na
przesłaną
```
Uwagi:
```
1. Maksymalny przelicznik to 9999,9999.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```plaintext
[STX]currrateget[TAB]onT[TAB]ra0300100[TAB]naEUR[TAB]diN[TAB]#CRC16[ETX]
```
– ustawiony jest kurs: 1 PLN = 0,3001 EUR (zakładając że walutą ewidencyjną jest PLN).
```
[STX]currrateget[TAB]onN[TAB]ra0000000[TAB]na[TAB]diN[TAB]#CRC16[ETX]
– przelicznik walut wyłączony.
```

## [currset] Ustawienie daty automatycznej zmiany waluty
Identyfikator polecenia:
currset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Symbol waluty. TAK Alfanum. Dokładnie trzy duże litery bez
znaków diakrytycznych.
da Data i godzina zmiany waluty
ewidencyjnej.
TAK Data
i czas
Określa kiedy ma nastąpić au-
tomatyczna zmiana waluty.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Zabronione jest przesyłanie symbolu identycznego z obecnym symbolem waluty.
2. Przesłanie daty przeszłej, powoduje natychmiastowe wykonanie zmiany waluty.
3. Zmiana waluty możliwa jest tylko przy zerowych totalizerach. Po zatwierdzeniu polecenia
currset z datą przyszłą możliwa jest sprzedaż w aktualnej walucie, a przed wykonaniem
zmiany waluty wygenerowany zostanie raport dobowy, a następnie potwierdzenie wykona-
nej operacji.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```
```plaintext
[STX]currset[TAB]naEUR[TAB]da2017-01-01;8:00[TAB]#CRC16[ETX]
```
```

## [currget] Odczyt waluty ewidencyjnej
Identyfikator polecenia:
currget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
na Symbol obowiązującej waluty. - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.

## [ecmedinfoget] Odczyt danych o nośniku pamięci chronionej
Identyfikator polecenia:
ecmedinfoget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
pr Zawsze pr = 1 - Num
sf Ilość wolnego miejsca na nośni-
ku
- Num Wartość podana w kilobajtach
ca Pojemność nośnika - Num Wartość podana w kilobajtach
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.

## [ecpubkeyget] Odczyt klucza publicznego
Identyfikator polecenia:
ecpubkeyget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
rn Część N klucza publicznego - Alfanum. Zapis HEX
re Część E klucza publicznego - Alfanum. Zapis HEX
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.

## [ecprndoc] Wydruk dokumentów z pamięci chronionej
Identyfikator polecenia:
ecprndoc
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Typ drukowanego dokumentu NIE Num.
0 – paragony,
1 – faktury,
2 – niefiskalne,
3 – raporty dobowe,
5 – dowolne
fn Numer początkowy NIE Num. Domyślnie 0
tn Numer końcowy NIE Num. Domyślnie 999999999
fd Data i czas początkowe NIE Data i czas Domyślnie 2000-01-01 01:00
td Data i czas końcowe NIE Data i czas Domyślnie bieżąca data
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
il Liczba wydrukowanych dokumen-
tów
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Przerwanie wydruku komendą „break”.
3. Dla raportów dobowych (ty=3) oraz dowolnych wydruków (ty=5) numery początkowy i
końcowy nie są uwzględniane.
4. Dla wydruków niefiskalnych (ty=2) kryterium numer początkowy i końcowy odnosi się do
numeru drukowanego w nagłówku.
5. Dla paragonów, paragonów anulowanych (ty=0), faktur i faktur anulowanych (ty=1) kryte-
rium numer początkowy i numer końcowy odnosi się do numeru drukowanego w stopce.
6. Kod kreskowy na wydrukach z pamięci chronionej jest drukowany według aktualnej konfi-
guracji ustawianej poleceniem "barcodeheightset".
Przykład:
```
[STX]ecprndoc[TAB]ty0[TAB]fn0[TAB]tn100[TAB]fd2010-12-13;09:50[TAB]td2011-12-
```
```
13;09:50[TAB]#CRC16[ETX]
```

## [break] Asynchroniczne przerwanie wydruku
Identyfikator polecenia:
!break, break
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Komenda dostępna dla wydruku dokumentów z pamięci chronionej.
3. Komenda powinna być używana w trybie asynchronicznym (poprzedzona wykrzyknikiem)
Przykład:
```plaintext
[STX]!break[ETX]
```

## [fsppswdset] Ustawienie hasła do serwera FSP
Identyfikator polecenia:
fsppswdset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
pw hasło TAK Alfanum. Tekst o maksymalnej długości
16 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Skasowanie hasła wymaga komendy z „pustym tekstem”
przykład:
```plaintext
[STX]fsppswdset[TAB]pwKOTEK[TAB]#CRC16[ETX]
```

## [svc] Tunelowanie danych do usługi
Identyfikator polecenia:
svc
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator usługi TAK Alfanum. Numer usługi do której wysyła-
```
my dane (0-255):
```
1 – serwer FSP.
```
fl Flagi NIE Alfanum. Wartość bajtowa (0-255)
```
W przypadku komunikacji pa-
kietowej, znaczenie bajtu flag
jest następujące:
bit 0: początek pakietu
bit 1: koniec pakietu
da Dane NIE Alfanum. Dane, które mają być przesłane
```
do usługi (zapis HEX, max 256
```
```
znaków).
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator usługi - Alfanum. Numer usługi, która przesyła
dane.
```
fl Flagi - Alfanum. Wartość bajtowa (0-255)
```
da Dane - Alfanum. Dane przesłane przez usługę
```
(zapis HEX, max 256 znaków).
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie jest jedynie ramką transportową dla innych protokołów. W celu pobrania danych
od usługi, należy przesłać do niej ramkę z pustym polem danych.
3. Jeżeli pakiet nie mieści się w 128 bajtach (256 HEX), należy podzielić go przesyłając po-
```
szczególne części z odpowiednimi flagami (dla części, które nie kończą ani nie rozpoczyna-
```
```
ją pakietu, flagi = 0). Analogicznie dzielona jest odpowiedź, przy czym podczas pobierania
```
kolejnych części, należy przesyłać ramki z flagami = 0, aż do otrzymania końca pakietu.

## [rpt] Powtarzanie odpowiedzi na wcześniej wysłany rozkaz
Identyfikator polecenia:
rpt
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Drukarka odsyła odpowiedź, jaka została udzielona na rozkaz o tokenie równym tokenowi rozkazu
rpt.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Bufor jest w stanie pomieścić 32 odpowiedzi na sekwencje. Dodatkowo jest on ograniczony
do 1KiB danych wysłanych ramek, przechowywanych w wewnętrznej reprezentacji urzą-
dzenia.
Przykładowo: dla sekwencji <strns> zawierającej ok. 68 bajtów danych w wewnętrznej re-
prezentacji urządzenia, bufor jest w stanie pomieścić 1024 / 68 = ~15 odpowiedzi.
Przykład:
Został wysłany następujący rozkaz:
```plaintext
[STX]currget[TAB]@8765[TAB]#CRC16[ETX]
urządzenie odesłało odpowiedź:
[STX]currget[TAB]@8765[TAB]naPLN[TAB]#CRC16[ETX]
po wysłaniu rozkazu:
[STX]rpt[TAB]@8765[TAB]#CRC16[ETX]
otrzymujemy odpowiedź na rozkaz o tokenie 8765, czyli:
[STX]currget[TAB]@8765[TAB]naPLN[TAB]#CRC16[ETX]
jeśli rozkazu nie uda się odnaleźć, zwracany jest błąd:
[STX]ERR[TAB]@8765[TAB]er13[TAB]cmrpt[TAB]#CRC16[ETX]
Jest to błąd ramki protokołu o numerze 13.
```
Uwagi:
```
Urządzenie jest w stanie zapamiętać ograniczoną ilość odpowiedzi na wcześniej wysłane rozkazy.
```

## [protoswitch] Zmiana protokołu komunikacyjnego na Thermal
Identyfikator polecenia:
protoswitch
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
pi Numer interfejsu PC NIE Num. 1 - PC1 (domyślny)
```
2 - PC2
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Jeśli drukarka:
- jest w trybie transakcji,
- jest w trakcie wydruku dokumentu niefiskalnego,
- bufor wydruków nie jest pusty,
- drukuje kopie dokumentów z pamięci chronionej
nie następuje zmiana protokołu i zgłaszany jest błąd.
3. Jeśli operacja jest dopuszczalna, drukarka odsyła aplikacji standardową odpowiedź, po czym
następuje zmiana protokołu komunikacyjnego i restart urządzenia. Parametry komunikacji
```
(ustawienia portów) pozostają bez zmian.
```
4. Interfejs PC2 niedostępny w drukarce FAWAG BOX 1.01.

## [dailyrepaccessset] Ustawianie dostępu do raportu dobowego z menu
Identyfikator polecenia:
dailyrepaccessset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
mn Czy raport dobowy jest dostępny
z menu?
TAK BOOL True – jest dostępny
False – niedostępny z menu
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]dailyrepaccessset[TAB]mnN[TAB]#CRC16[ETX]
```

## [dailyrepaccessget] Odczyt konfiguracji dostępu do raportu dobowego z
menu
Identyfikator polecenia:
dailyrepaccessget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
mn Czy raport dobowy jest dostępny
z menu?
- BOOL True – jest dostępny
False – niedostępny z menu
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]dailyrepaccessget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]dailyrepaccessget[TAB]mn0[TAB]#CRC16[ETX]
```

## [menupswdset] Ustawienie hasła dostępu do menu
Identyfikator polecenia:
menupswdset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
pw hasło dostępu do menu TAK Alfanum. Długość hasła: 1 – 6 cyfr.
Przesłanie pustego parametru
pw wyłącza kontrolę dostępu
przez hasło.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]menupswdset[TAB]pw123456[TAB]#CRC16[ETX]
```

## [eclastprintouts] Wydruk ostatnich dokumentów z pamięci chronionej
Identyfikator polecenia:
eclastprintouts
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Liczba ostatnich dokumentów
do wydrukowania
TAK Num. Zakres 1-9.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eclastprintouts[TAB]no3[TAB]#CRC16[ETX]
```

## [ecprnfv] Wydruk faktury z pamięci chronionej
Identyfikator polecenia:
ecprnfv
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer faktury do wydrukowa-
nia
TAK Num. Jako numer faktury należy po-
dać numer wydruku, umiesz-
czony w stopce wydruku fak-
tury - w linii z nazwą kasjera,
numerem kasy, datą i czasem.
```
ut Rodzaj wydruku (dla klienta czy
```
```
wystawcy)
```
TAK Num. 1 – wydruk dla wystawcy
0 – wydruk dla klienta z napi-
sem 'DUPLIKAT'.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]ecprnfv[TAB]fn11[TAB]ut1[TAB]#CRC16[ETX]
```

## [eclastdocnoget] Pobranie numeru ostatniego dokumentu określonego
typu z pamięci chronionej
Identyfikator polecenia:
eclastdocnoget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Typ dokumentu z pamięci chro-
nionej
NIE Num. 0 – paragon
1 – anulowanie paragonu
2 – faktura
3 – anulowanie faktury
4 – raport dobowy
5 – wydruk niefiskalny
6 – zdarzenie
7 – raport fiskalizacji
8 – zmiana certyfikatu
9 – wysłanie certyfikatu
10 – grafika
11 – kod QR
12 – harmonogram połączeń
13 – nagłówek
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
di Numer dokumentu w pamięci
chronionej
- Num. di = 0 jeśli dokument nie zo-
stał odnaleziony w pamięci
chronionej
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Brak przesłanego parametru ty powoduje odesłanie numeru ostatniego dokumentu z pamięci
chronionej.
Przykład:
```plaintext
[STX]eclastdocnoget[TAB]ty0[TAB]#CRC16[ETX]
```

## [billcountercfgget] Odczyt konfiguracji licznika paragonów
Identyfikator polecenia:
billcountercfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
dl Czy licznik jest dobowy? - BOOL False – licznik ciągły
```
True – licznik dobowy (zero-
```
```
wany po raporcie dobowym)
```
```
Uwagi:
```
1. Konfiguracja licznika paragonów jest określana przy fiskalizacji. Nie można jej zmienić w
czasie użytkowania urządzenia.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]billcountercfgget[TAB]#CRC16[ETX]
```

## [beep] Generowanie sygnału dźwiękowego
Identyfikator polecenia:
!beep, beep
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]beep[TAB]#CRC16[ETX]
```

## [dsptrnsreleasetimeoutset] Konfiguracja czasu wyświetlania transakcji
po jej zakończeniu
Identyfikator polecenia:
dsptrnsreleasetimeoutset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tc Czas w sekundach wyświetlania
transakcji od momentu jej za-
kończenia.
NIE Num. Zakres: 5 – 120
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dsptrnsreleasetimeoutset[TAB]tc35[TAB]#CRC16[ETX]
```

## [dsptrnsreleasetimeoutget] Odczyt konfiguracji czasu wyświetlania
transakcji po jej zakończeniu
Identyfikator polecenia:
dsptrnsreleasetimeoutget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
tc Czas w sekundach wyświetlania
transakcji od momentu jej za-
kończenia.
NIE Num. Zakres: 5 – 120
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]dsptrnsreleasetimeoutget[TAB]#CRC16[ETX]
```

## [billtaxcompressget] Odczyt konfiguracji wydruku podsumowania VAT
na paragonie
Identyfikator polecenia:
billtaxcompressget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ob Czy optymalizacja wydruku
brutto/PTU jest włączona?
- BOOL
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]billtaxcompressget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]billtaxcompressget[TAB]obN[TAB]#CRC16[ETX]
```

## [billtaxcompressset] Konfiguracja wydruku podsumowania VAT na para-
gonie
Identyfikator polecenia:
billtaxcompressset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ob Czy włączyć optymalizację wy-
druku brutto/PTU?
TAK BOOL
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]billtaxcompressset [TAB]obY[TAB]#CRC16[ETX]
```

## [hdrcompressset] Optymalizacja nagłówka dla wydruków niefiskalnych
Identyfikator polecenia:
hdrcompressset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nf Optymalizacja nagłówka TAK bool False – optymalizacja wyłą-
czona
True – optymalizacja włączo-
na
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Przy włączonej optymalizacji napis NIEFISKALNY umieszczony jest w jednej linii razem z
numerem NIP i numerem wydruku. W trybie wydruku 40 znaków w linii, napis NIEFI-
SKALNY jest niepogrubiony i nierozstrzelony. W trybie wydruku 56 znaków w linii, napis
NIEFISKALNY jest pogrubiony.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]hdrcompressset[TAB]nf1[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:603 NIEFISKALNY|
|Wpłata do kasy 9,99|
| NIEFISKALNY |
|#19 Ania 2018-08-21 09:56|
|C7D5396F8EC552E23C22D2C65DBA60EF21EB8C37|
| ZBF 1801007587 |

[hdrcompressget]Odczyt optymalizacji nagłówka dla wydruków niefi-
skalnych
Identyfikator polecenia:
hdrcompressget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nf Optymalizacja nagłówka - bool False – optymalizacja wyłą-
czona
True – optymalizacja włączo-
na
```
Uwagi:
```
1. Przy włączonej optymalizacji napis NIEFISKALNY umieszczony jest w jednej linii razem z
numerem NIP i numerem wydruku. W trybie wydruku 40 znaków w linii, napis NIEFI-
SKALNY jest niepogrubiony i nierozstrzelony. W trybie wydruku 56 znaków w linii, napis
NIEFISKALNY jest pogrubiony.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]hdrcompressget[TAB]#CRC16[ETX]
```

## [ftrcompressset] Optymalizacja stopki dla wydruków niefiskalnych
Identyfikator polecenia:
ftrcompressset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nf Optymalizacja stopki TAK bool False – optymalizacja wyłą-
czona
True – optymalizacja włączo-
na
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. W trybie wydruku 56 znaków w linii, napis NIEFISKALNY umieszczony jest w jednej linii
z numerem kasy i nazwą kasjera a podpis dokumentu umieszczony jest w jednej linii wraz z
numerem unikatowym. W trybie 40 znaków w linii, optymalizacja nie wpływa na wydruk
stopki dokumentu.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]ftrcompressset[TAB]nf1[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:608|
| N I E F I S K A L N Y |
|Wpłata do kasy 9,99|
|NIEFISKALNY #19 Ania 2018-08-21 10:10|
|99E2D74A9869AC59428106294E5C80AC45DADB20 ZBF 1801007587|

[ftrcompressget]Odczyt optymalizacji stopki dla wydruków niefiskal-
nych
Identyfikator polecenia:
ftrcompressget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nf Optymalizacja stopki - bool False – optymalizacja wyłą-
czona
True – optymalizacja włączo-
na
```
Uwagi:
```
1. Przy włączonej optymalizacji, w trybie 40 znaków, napis NIEFISKALNY nie występuje na
końcu wydruku. W trybie wydruku 56 znaków w linii, napis NIEFISKALNY umieszczony
jest w jednej linii z numerem kasy i nazwą kasjera a podpis dokumentu umieszczony jest w
jednej linii wraz z numerem unikatowym.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]ftrcompressget[TAB]#CRC16[ETX]
```

## [factorynumberget] Odczyt numeru fabrycznego
Identyfikator polecenia:
factorynumberget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
fn Numer fabryczny - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]factorynumberget[TAB]#CRC16[ETX]
```

## [factorynumberset] Zapis numeru fabrycznego
Identyfikator polecenia:
factorynumberset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer fabryczny TAK Alfanum. 11 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]factorynumberset[TAB]fnPO807271327#CRC16[ETX]
```

## [signatureprintcfgget] Odczyt konfiguracji drukowania kodu 2d podpisu
dokumentów
Identyfikator polecenia:
signatureprintcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
pc Włączenie wydruku kodu 2d - BOOL True – kod jest drukowany
False – kod nie jest drukowany
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]signatureprintcfgget[TAB]#CRC16[ETX]
```

## [signatureprintcfgset] Ustawienie konfiguracji drukowania kodu 2d pod-
pisu dokumentów
Identyfikator polecenia:
signatureprintcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
pc Włączenie wydruku kodu 2d NIE BOOL. True – kod jest drukowany
False – kod nie jest drukowany
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]signatureprintcfgset[TAB]pc1[TAB]#CRC16[ETX]
```

## [usbdrvtypeget] Odczyt typu sterownika USB
Identyfikator polecenia:
usbdrvtypeget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ty Typ sterownika - Num. 0-Auto
1-Windows10 driver / Windows
driver
2-Posnet driver / Printer driver
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]usbdrvtypeget[TAB]#CRC16[ETX]
```

## [usbdrvtypeset] Ustawienie typu sterownika USB
Identyfikator polecenia:
usbdrvtypeset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Typ sterownika TAK Num. 0-Auto
1-Windows10 driver
2-Posnet driver
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: drukarka PosPay - TAK, inne urządzenia - NIE
Przykład:
```plaintext
[STX]usbdrvtypeset[TAB]ty0[TAB]#CRC16[ETX]
```

## [subgettime] Pobranie informacji o dacie wygaśnięcia subskrypcji na
działanie urządzenia
Identyfikator polecenia:
subgettime
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
wt Data ostrzeżenia - Data i
czas
ISO8601
lt Data blokady - Data i
czas
ISO8601
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]subgettime[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]subgettime[TAB]wt2088-01-01T00:00:00+1:00[TAB]lt2088-01-
05T00:00:00+1:00[TAB]#CRC16[ETX]

## [verifysignaturesondemandset] Wywołanie weryfikacji podpisów rapor-
tów dobowych przy następnym uruchomieniu urządzenia
Identyfikator polecenia:
verifysignaturesondemandset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
vs Status wywołania weryfikacji TAK BOOL True – włączenie weryfikacji
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]verifysignaturesondemandset[TAB]vs1[TAB]#CRC16[ETX]
```

## [verifysignaturesondemandget] Odczyt zlecenia wywołania weryfikacji
podpisów raportów dobowych przy następnym uruchomieniu urządze-
nia
Identyfikator polecenia:
verifysignaturesondemandget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
vs Status wywołania weryfikacji - BOOL True – włączenie weryfikacji
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]verifysignaturesondemandget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]verifysignaturesondemandget[TAB]ty0[TAB]#CRC16[ETX]
```

## [certinfoget] Odczyt certyfikatów z urządzenia
Identyfikator polecenia:
certinfoget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Typ certyfikatu TAK Num. 0 – certyfikat urządzenia
1 – certyfikat JSON
2 – certyfikat AZURE
```
3 – certyfikat CPD (TLS)
```
```
4 – certyfikat CPD (JSON)
```
5 – certyfikat CA PRODUCENTA
6 – certyfikat CA CPD
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Typ certyfikatu - Num. Jak dla parametrów wejścio-
wych
ok Czy w urządzeniu jest wgrany
poprawny certyfikat?
- BOOL
da Data ważności certyfikatu - Data Zawiera ważne dane tylko
gdy certyfikat jest poprawny
fp Odcisk palca certyfikatu - Alfanum. Zawiera ważne dane tylko
gdy certyfikat jest poprawny
sn Numer seryjny certyfikatu - Alfanum. Zawiera ważne dane tylko
gdy certyfikat jest poprawny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Jeśli certyfikat danego typu nie jest obecny w urządzeniu lub nie jest poprawny, to pola da,
fp, sn należy zignorować.
Przykład:
```plaintext
[STX]certinfoget[TAB]id0[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]certinfoget[TAB]id0[TAB]okT[TAB]da2021-10-14[TAB]fpE1:AC:E3:54:95:46:2F:7B

:DB:66:62:D8:00:F4:A7:7E:41:5C:21:27[TAB]sn33:00:03:00:A5:50:55:A2:FF:CA:32:08:21:00:00:
66:63:BE:A5[TAB]#CRC16[ETX]

## [eventhubcertinfoget] Odczyt certyfikatów CA AZURE z urządzenia
Identyfikator polecenia:
eventhubcertinfoget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nr Numer kolejny certyfikatu TAK Num. Dopuszczalne wartości od ze-
ra do liczby certyfikatów CA
AZURE w urządzaniu. Proce-
dura odczytu - patrz uwagi.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nr Numer kolejny certyfikatu - Num.
ok Czy w urządzeniu jest wgrany
poprawny certyfikat?
- BOOL Jeśli nie jest poprawny to po-
la da, fp, sn należy zignoro-
wać
da Data ważności certyfikatu - Data Zawiera ważne dane tylko
gdy certyfikat jest poprawny
fp Odcisk palca certyfikatu - Alfanum. Zawiera ważne dane tylko
gdy certyfikat jest poprawny
sn Numer seryjny certyfikatu - Alfanum. Zawiera ważne dane tylko
gdy certyfikat jest poprawny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Certyfikaty typu CA AZURE należy odczytywać po kolei od nr 0 zwiększając nr o jeden aż
```
do odebrania certyfikatu niepoprawnego (tj gdy odpowiedź zawiera okN).
```
3. Maksymalna liczba certyfikatów typu CA AZURE w urządzeniu to 10.
Przykład:
```plaintext
[STX]eventhubcertinfoget[TAB]nr2[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]eventhubcertinfoget[TAB]nr0[TAB]okT[TAB]da2021-10-14[TAB]fpE1:AC:E3:54:95:
46:2F:7B:DB:66:62:D8:00:F4:A7:7E:41:5C:21:27[TAB]sn33:00:03:00:A5:50:55:A2:FF:CA:32:08:
21:00:00:66:63:BE:A5[TAB]#CRC16[ETX]

## [onlineaddressesget] Odczyt adresów serwerów do usług online
Identyfikator polecenia:
onlineaddressesget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Typ serwera TAK Num. 0 – zarezerwowane
1 – Serwer repozytorium
2 – Serwer WebAPI
3 – Serwer Aktualizacji oprogramo-
wania
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Typ serwera - Num. Jak dla parametrów wejścio-
wych
ok Czy w urządzeniu skonfiguro-
wany jest ten typ serwera?
- BOOL
ad Adres serwera - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]onlineaddressesget[TAB]id1[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]onlineaddressesget[TAB]id1[TAB]okT[TAB]adhttps://esb-te.mf.gov.pl:5062/api/SerwerCPD/Com-
mand[TAB]#CRC16[ETX]

## [billlotteryconfigget] Odczyt konfiguracji Loterii Paragonowej nadawa-
nej przez repozytorium
Identyfikator polecenia:
billlotteryconfigget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
en Czy drukować kod QR Loterii
Paragonowej na paragonie?
- BOOL
wa Próg wartości paragonu powyżej
którego ma być drukowany kod
QR Loterii Paragonowej
- Kwota Wartość ważna tylko gdy dru-
kowanie kodu jest włączone
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]billlotteryconfigget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]billlotteryconfigget[TAB]enN[TAB]wa0[TAB]#CRC16[ETX]
```

## [sastokeninfoget] Odczyt informacji o SAS Token
Identyfikator polecenia:
sastokeninfoget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ok Czy urządzenie otrzymało waż-
ny SAS Token?
- BOOL
da Data ważności SAS Token - Data i czas
ISO8601
Zawiera ważne dane tylko
gdy certyfikat jest poprawny
st SAS Token - Alfanum. Zawiera ważne dane tylko
gdy certyfikat jest poprawny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Jeśli w urządzeniu nie ma ważnego SAS Token to zawartość pól da i st należy zignorować
Przykład:
```plaintext
[STX]sastokeninfoget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]sastokeninfoget[TAB]okT[TAB]da2020-10-20T11:49:13+02:00[TAB]stXXXXX.YYYYY.ZZZZZ[TAB]#CRC16[ETX]
```

## [checksumsget] Odczyt sum kontrolnych programów
Identyfikator polecenia:
checksumsget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ap Suma programu pracy kasy - Alfanum.
fm Suma programu pracy pamięci
fiskalnej
- Alfanum.
ld Suma programu aktualizacji - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]checksumsget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]checksumsget[TAB]ap69BA9AB548EE8F0BA2FF88C196A380D11B67BA8BDE-
832C2CD40B59F5DC3972D3[TAB]fm3E2CCBF33E92328C0EC2FB14EBA3162DE16877B275CBE-
2C7ED5CB630F631F5EB[TAB]ldDEADBEEF[TAB]#CRC16[ETX]

## [quantitysigncfgget] Odczyt konfiguracji znaku ilości
Identyfikator polecenia:
quantitysigncfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
qa Konfiguracja pierwszego znaku
ilości
- Num.
0 – brak znaku, 1 – spacja,
2 – *, 3 – X, 4 – x, 5 – •,
6 – ·, 7 – ×qb Konfiguracja drugiego znaku
ilości
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]quantitysigncfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]quantitysigncfgget[TAB]qa1[TAB]qb4[TAB]#CRC16[ETX]
```

## [quantitysigncfgset] Konfiguracja znaku ilości
Identyfikator polecenia:
quantitysigncfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
qa Konfiguracja pierwszego znaku
ilości
NIE Num.
0 – brak znaku, 1 – spacja,
2 – *, 3 – X, 4 – x, 5 – •,
6 – ·, 7 – ×qb Konfiguracja drugiego znaku
ilości
NIE Num.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Dostępność w trybie transakcji: NIE.
3. Konfiguracja znaków ilości:
```
• Wpływa na wydruk wszystkich paragonów (również kopii z pamięci chronionej) od
```
zmiany konfiguracji.
• Wymagana minimalna liczba znaków ilości to 1.
• W wypadku gdy konfigurujemy tylko jeden znak ilości nie ma znaczenia czy prześlemy
go jako qa czy qb.
• W wypadku przesłania tylko jednego z parametrów qa i qb drugi domyślnie przyjmuje
wartość ‘brak znaku’.
• W przypadku konfigurowania obu znaków ilości przynajmniej jeden musi być spacją.
Przykład:
```plaintext
[STX]quantitysigncfgset[TAB]qa0[TAB]qb7[TAB]#CRC16[ETX]
```

## [prnspecialcfgset] Konfiguracja wydruków specjalnych
Identyfikator polecenia:
prnspecialcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sp Flaga konfiguracji wydruków
specjalnych
NIE Num. 1 – wydruki specjalne druko-
wane i zapisywane w pamięci
chronionej,
0 – wydruki specjalne tylko
zapisywane w pamięci chro-
nionej
Brak parametru nie zmienia
sposobu dotychczasowego
działania urządzenia.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Wydruki specjalne to: wydruk programowania nagłówka, wydruk zmiany stawek PTU, wy-
druk zmiany waluty ewidencyjnej.
Przykład:
```plaintext
[STX]prnspecialcfgset[TAB]sp0[TAB]#CRC16[ETX]
```

## [prnspecialcfgget] Odczyt konfiguracji wydruków specjalnych
Identyfikator polecenia:
prnspecialcfgget
Parametry wejściowe:
standardowa
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
sp Flaga konfiguracji wydruków
specjalnych
- Num. 1 – wydruki specjalne druko-
wane i zapisywane w pamięci
chronionej,
0 – wydruki specjalne tylko
zapisywane w pamięci chro-
nionej.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Wydruki specjalne to: wydruk programowania nagłówka, wydruk zmiany stawek PTU, wy-
druk zmiany waluty ewidencyjnej.
Przykład:
```plaintext
[STX]prnspecialcfgget[TAB]#CRC16[ETX]
```

## [doccntget] Odczyt liczby wydrukowanych dokumentów
Identyfikator polecenia:
doccntget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
bi Liczba paragonów i faktur - Num. Łącznie z anulowanymi
al Liczba wszystkich wydruków - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]doccntget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]doccntget[TAB]bi11[TAB]al21[TAB]#CRC16[ETX]
```

## [changekeys] Wywołanie wymiany kluczy TPM
Identyfikator polecenia:
changekeys
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Bieżąca data do potwierdzenia
operacji
TAK Data
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Operacja wymaga potwierdzenia poprzez wciśniecie zwory serwisowej po ukazaniu się ko-
munikatu na wyświetlaczu drukarki
Przykład:
```plaintext
[STX]changekeys[TAB]da1982-03-02[TAB]#CRC16[ETX]
```

Dodatkowe sekwencje do zapisu/odczytu
## [memwrite] Zapis bloku danych do udostępnionej pamięci urządzenia
Identyfikator polecenia:
memwrite
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres początkowy, pod któ-
ry należy zapisać dane
TAK num. Zakres: 0-127.
dt Dane TAK alfanum. Każde dwa znaki przedstawiają
jeden bajt danych zapisany w sys-
temie szesnastkowym. Np. liczba
162 będzie przedstawiona jako
„A2”, a liczba 12 jako „0C”.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Udostępniony blok pamięci w przestrzeni adresowej urządzenia ma rozmiar 128 bajtów. Za
inicjalizację oraz integralność danych odpowiedzialny jest programista.
Odpowiedź urządzenia:
standardowa
Przykład:
```plaintext
[STX]memwrite[TAB]ad10[TAB]dtA200A20CA2[TAB]#CRC16[ETX]
```

## [memread] Odczyt bloku danych z udostępnionej pamięci urządzenia
Identyfikator polecenia:
memread
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres początkowy bloku pa-
mięci
NIE num. Zakres: 0-127.
Jeśli nie jest podany, przyjmowa-
na jest wartość 0.
si Rozmiar bloku pamięci w baj-
tach
NIE num. Jeśli nie jest podany, za koniec
bloku danych przyjmuje się ko-
niec udostępnionej pamięci.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
dt Zawartość bloku pamięci - alfanum. Każde dwa znaki przedstawiają
jeden bajt danych zapisany w
systemie szesnastkowym. Np.
liczba 162 będzie przedstawiona
jako „A2”, a liczba 12 jako „0C”.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Udostępniony blok pamięci w przestrzeni adresowej urządzenia ma rozmiar 128 bajtów. Za
inicjalizację oraz integralność danych odpowiedzialny jest programista.
Przykład:
```plaintext
[STX]memread[TAB]ad10[TAB]si5[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]memread[TAB]dtA200A20CA2[TAB]#CRC16[ETX]
```

Konfiguracja sprzętowa
## [drwparamset] Ustawianie parametrów szuflady
Identyfikator polecenia:
drwparamset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
im Długość impulsu NIE Num. Zakres: 1-10
id Identyfikator szuflady NIE Num. Parametr powinien przyjmo-
wać wartość 0.
vt Napięcie szuflady NIE Num. 0 – 6V
1 – 12V
2 – 18V
3 – 24V
fs Czujnik otwarcia szuflady NIE BOOL True – czujnik obsługiwany
False – brak obsługi
ks Czujnik kluczyka szuflady NIE BOOL True – czujnik obsługiwany
False – brak obsługi
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo.
2. Napięcia szuflady nie można zmienić programowo w drukarce Trio. Przy wysyłaniu rozkazu
należy pominąć parametr vt.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]drwparamset[TAB]im5[TAB]id0[TAB]vt1[TAB]fs1[TAB]ks1[TAB]#CRC16[ETX]
```

## [drwparamget] Odczyt parametrów szuflady
Identyfikator polecenia:
drwparamget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
im Długość impulsu - Num. Zakres: 1-10
id Identyfikator szuflady - Num. Przyjmuje wartość 0.
vt Napięcie szuflady - Num. 0 – 6V
1 – 12V
2 – 18V
3 – 24V
fs Czujnik otwarcia szuflady - BOOL True – czujnik obsługiwany
False – brak obsługi
ks Czujnik kluczyka szuflady - BOOL True – czujnik obsługiwany
False – brak obsługi
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]drwparamget[TAB]#CRC16[ETX]
```

## [powerindset] Dźwiękowa sygnalizacja braku zasilania
Identyfikator polecenia:
powerindset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
in Interwał czasowy (w sekundach)
```
pomiędzy dźwiękami informują-
cymi o braku zasilania.
TAK Num. Zakres: 0-60
0 – brak sygnalizacji
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]powerindset[TAB]in25[TAB]#CRC16[ETX]
```

## [powerindget] Odczyt konfiguracji dźwiękowej sygnalizacja braku zasi-
lania
Identyfikator polecenia:
powerindget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
```
in Interwał czasowy (w sekundach)
```
pomiędzy dźwiękami informują-
cymi o braku zasilania.
- Num. Zakres: 0-60,
0 – brak sygnalizacji
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]powerindget[TAB]#CRC16[ETX]
```

## [cuttercfgset] Ustawienie konfiguracji obcinacza
Identyfikator polecenia:
cuttercfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ct sposób działania obcinacza. NIE Num. 0 – brak
1 – częściowe
2 – pełne
ch Wysokość noża. NIE Num. 0 – niski
1 – wysoki
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie dostępne w drukarkach nie posiadających obcinacza, dla zachowania kompatybil-
ności tych urządzeń z istniejącym oprogramowaniem.
2. Drukarka Thermal HX 1.01 nie obsługuje pełnego obcięcia papieru. Wysłanie ct=2 powodu-
je ustawienie obcięcia częściowego.
3. Ustawienie wysokości noża ma wpływ na ilość wysuwanego papieru po zakończeniu wy-
druku.
4. Przesłanie parametru ch spoza zakresu, powoduje ustawienie wartości ch=0.
5. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]cuttercfgset[TAB]ct1[TAB]#CRC16[ETX]
```

## [cuttercfgget] Odczyt konfiguracji obcinacza
Identyfikator polecenia:
cuttercfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ct sposób działania obcinacza. - Num. 0 – brak
1 – częściowe
2 – pełne
ch Wysokość noża. - Num. 0 – niski
1 – wysoki
```
Uwagi:
```
1. Polecenie dostępne w drukarkach nie posiadających obcinacza, dla zachowania kompatybil-
ności tych urządzeń z istniejącym oprogramowaniem.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]cuttercfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]cuttercfgget[TAB]ct1[TAB]ch1[TAB]#CRC16[ETX]
```

## [dspcfg] Konfiguracja parametrów wyświetlaczy
Identyfikator polecenia:
dspcfg
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza TAK Num. Wymagana wartość id = 1
co Kontrast wyświetlacza NIE Num. Zakres: 1 – 16
lu Jasność podświetlenia NIE Num. Zakres: 1 – 16
ls Tryb pracy podświetlenia NIE Num. 0 – zawsze wyłączone
1 – podświetlenie włączone
2 – podświetlenie włączone tyl-
ko przy zasilaniu z sieci
od Opóźnienie wyłączenia podświe-
tlenia w sekundach
NIE Num. Zakres: 0 – 999
Funkcja zaimplementowana w
drukarkach Temo, Trio, Vero,
Evo, Fawag Box.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Jeśli któryś z opcjonalnych parametrów nie zostanie przesłany, wartość danego parametru w
drukarce nie zostanie zmieniona.
2. Działanie podświetlenia wyświetlacza jest zależne również od ustawień czasu wyłączenia
podświetlenia, które można regulować w menu drukarki.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]dspcfg[TAB]id1[TAB]co8[TAB]lu16[TAB]ls2[TAB]od100[TAB]#CRC16[ETX]
```

## [dspcfgget] Odczyt konfiguracji parametrów wyświetlaczy
Identyfikator polecenia:
dspcfgget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza TAK Num. Wymagana wartość id = 1
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza - Num. id = 1
co Kontrast wyświetlacza - Num. Zakres: 1 – 16
lu Jasność podświetlenia - Num. Zakres: 1 – 16
ls Tryb pracy podświetlenia - Num. 0 – zawsze wyłączone
1 – podświetlenie włączone
2 – podświetlenie włączone tyl-
ko przy zasilaniu z sieci
od Opóźnienie wyłączenia podświe-
tlenia
- Num. Funkcja zaimplementowana w
drukarkach Temo, Trio, Vero,
Evo, Fawag Box. W pozosta-
łych urządzeniach zwracana
wartość nie wpływa na działa-
nie urządzenia.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Działanie podświetlenia wyświetlacza jest zależne również od ustawień czasu wyłączenia
podświetlenia, które można regulować w menu drukarki.
Przykład:
```plaintext
[STX]dspcfgget[TAB]id1[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]dspcfgget[TAB]id1[TAB]co8[TAB]lu16[TAB]ls2[TAB]od100[TAB]#CRC16[ETX]
```

## [kbdlockget] Odczyt ustawień blokowania klawiatury
Identyfikator polecenia:
kbdlockget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
to Czas w sekundach, po którym
następuje blokada klawiatury
- Num. to=0 oznacza funkcję nieak-
tywną
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.

## [kbdlockset] Zmiana ustawień blokowania klawiatury
Identyfikator polecenia:
kbdlockset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
to Czas w sekundach, po którym
następuje blokada klawiatury
TAK Num. Zakres 0...300
```
to=0 oznacza funkcję nieak-
```
tywną
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.

## [kbdblockget] Odczyt statusu blokady klawiatury wywoływanej przez
protokół
Identyfikator polecenia:
!kbdblockget, kbdblockget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
bl Stan klawiatury - Num. True – klawiatura zablokowana
False – klawiatura odblokowana
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Rozkaz dostępny tylko w drukarce PosPay.
3. Rozkaz zwraca status blokady klawiatury ustawiany rozkazem kbdblockset.
4. Rozkaz nie zwraca statusu blokady klawiatury włączanej po upływie określonego czasu
```
(kbdlockset).
```
5. Nie można usunąć blokady za pomocą klawiatury.
6. Blokada jest aktywna do ponownego włączenia urządzenia.

## [kbdblockset] Blokowanie klawiatury przez protokół
Identyfikator polecenia:
!kbdblockset, kbdblockset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
bl Stan klawiatury TAK Bool True – klawiatura zablokowana
False – klawiatura odblokowana
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Rozkaz dostępny tylko w drukarce PosPay.
3. Nie można usunąć blokady za pomocą klawiatury.
4. Blokada jest aktywna do ponownego włączenia urządzenia.

## [timeoutcfgset] Ustawienie czasu po jakim drukarka wyłączy się samo-
czynnie
Identyfikator polecenia:
timeoutcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
td Czas w minutach po jakim dru-
karka wyłączy się samoczynnie,
jeśli nie jest podłączone zasila-
nie zewnętrzne i nie będą na
niej wykonywane
żadne czynności.
NIE Num. Zakres 0 – 180
0 - drukarka zawsze włączona
tc Czas w minutach po jakim dru-
karka wyłączy się samoczynnie,
jeśli jest podłączone zasilanie
zewnętrzne i nie będą na niej
wykonywane
żadne czynności.
NIE Num Zakres 0 – 180
0 - drukarka zawsze włączona
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]timeoutcfgset[TAB]td30[TAB]tc0[TAB]#CRC16[ETX]
```

## [timeoutcfgget] Odczyt nastawy czasu po jakim drukarka wyłączy się
samoczynnie
Identyfikator polecenia:
timeoutcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
td Czas w minutach po jakim dru-
karka wyłączy się samoczynnie,
jeśli nie jest podłączone zasila-
nie zewnętrzne i nie będą na
niej wykonywane
żadne czynności.
- Num. Zakres 0 – 180
0 - drukarka zawsze włączona
tc Czas w minutach po jakim dru-
karka wyłączy się samoczynnie,
jeśli jest podłączone zasilanie
zewnętrzne i nie będą na niej
wykonywane
żadne czynności.
- Num Zakres 0 – 180
0 - drukarka zawsze włączona
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]timeoutcfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]timeoutcfgget[TAB]td30[TAB]tc0[TAB]#CRC16[ETX]
```

## [soundcfgset] Ustawienie dźwięków klawiszy
Identyfikator polecenia:
soundcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
kb Ustawienie dźwięków klawiszy NIE BOOL False – dźwięki wyłączone
True – dźwięki włączone
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]soundcfgset[TAB]kb1[TAB]#CRC16[ETX]
```

## [soundcfgget] Odczyt konfiguracji dźwięków klawiszy
Identyfikator polecenia:
soundcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
kb Ustawienie dźwięków klawiszy - BOOL False – dźwięki wyłączone
True – dźwięki włączone
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]soundcfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]soundcfgget[TAB]kb1[TAB]#CRC16[ETX]
```

## [comcfgset] Konfiguracja portów szeregowych
Identyfikator polecenia:
comcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer portu szeregowego TAK Num. 1 - ...
sp Prędkość transmisji TAK Num. 1200, 2400, 4800, 9600,
19200, 38400, 57600, 115200,
230400
da Długość danych TAK Num. Zawsze przyjmuje wartość 8
st Bity stop TAK Num. Zakres 1-2
```
pa Kontrola parzystości TAK Num. None(0), Odd(1), Even(2)
```
fl Konfiguracja kontroli przepływu TAK Num. 0-Brak kontroli
1-Handshake RTS-CTS
3-Handshake XON-XOFF
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Prędkość transmisji 230400 występuje tylko w urządzeniu Evo.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
[STX]comcfgset[TAB]no1[TAB]sp19200[TAB]fl0[TAB]da8[TAB]pa0[TAB]st1[TAB]#CRC16[ET
X]

## [comcfgget] Odczyt konfiguracji portów szeregowych
Identyfikator polecenia:
comcfgget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer portu szeregowego TAK Num. 1 - ...
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
sp Prędkość transmisji - Num. 1200, 2400, 4800, 9600,
19200, 38400, 57600, 115200,
230400
da Długość danych - Num. Zawsze przyjmuje wartość 8
st Bity stop - Num. Zakres 1-2
```
pa Kontrola parzystości - Num. None(0), Odd(1), Even(2)
```
fl Konfiguracja kontroli przepływu - Num. 0-Brak kontroli
1-Handshake RTS-CTS
3-Handshake XON-XOFF
```
Uwagi:
```
1. Prędkość transmisji 230400 występuje tylko w urządzeniu Evo.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]comcfgget[TAB]no1[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]comcfgget[TAB]sp19200[TAB]da8[TAB]st1[TAB]pa0[TAB]fl0[TAB]#CRC16[ETX]
```

## [pccfgset] Konfiguracja interfejsu PC
Identyfikator polecenia:
pccfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Typ portu szeregowego TAK Num. 0 – brak
1 – COM,
2 – USB,
4 – TCP/IP
7 – Bluetooth
no Numer portu NIE Num. 1 - … dla portu COM
1024 – 49151 dla TCP/IP
pr Protokół transmisji NIE Num. 0 – Posnet
1 – Thermal
cp Strona kodowa NIE Num. 0 – WIN1250
1 – LATIN2,
2 – MAZOVIA,
```
pi Numer interfejsu PC NIE Num. 1 – PC1 (domyślny)
```
2 – PC2
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Pole "no" jest wymagane w przypadku gdy interfejs ustawiany jest na porcie COM lub po
TCP/IP. Dla USB i Bluetooth może przyjąć jedynie wartość 1.
2. Przy wyborze protokołu Thermal strona kodowa jest ignorowana. Jest ustawiane MAZO-
VIA.
3. Nie można wyłączyć obu interfejsów (id=0). Próba wyłączenia jedynego aktywnego inter-
fejsu spowoduje zgłoszenie błędu.
4. Parametr id=1 niedostępny w urządzeniach bez portu com.
5. Parametr id=7 niedostępny w urządzeniach bez modułu Bluetooth.
6. Interfejs PC2 niedostępny w drukarce FAWAG BOX 1.01.
7. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]pccfgset[TAB]id1[TAB]no1[TAB]pr1[TAB]cp0[TAB]pi1[TAB]#CRC16[ETX]
```

## [pccfgget] Odczyt konfiguracji interfejsu PC
Identyfikator polecenia:
pccfgget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
pi Numer interfejsu PC NIE Num. 1 – PC1 (domyślny)
```
2 – PC2
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Typ portu szeregowego - Num. 0 – brak
1 – COM,
2 – USB,
4 – TCP/IP
7 – Bluetooth
no Numer portu - Num. 1 - … dla portu COM
1024 – 49151 dla TCP/IP
pr Protokół transmisji - Num. 0 – Posnet
1 – Thermal
cp Strona kodowa - Num. 0 – WIN1250
1 – LATIN2,
2 – MAZOVIA,
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Parametr id=1 niedostępny w urządzeniach bez portu com.
2. Parametr id=7 niedostępny w urządzeniach bez modułu Bluetooth.
3. Interfejs PC2 niedostępny w drukarce FAWAG BOX 1.01.
4. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]pccfgget[TAB]pi1[TAB]#CRC16[ETX]
```

Przykład odpowiedzi:
```plaintext
[STX]pccfgget[TAB]id1[TAB]no1[TAB]pr1[TAB]cp0[TAB]#CRC16[ETX]
```

## [tcpipcfgset] Konfiguracja interfejsu TCP/IP
Identyfikator polecenia:
tcpipcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
id Typ portu TAK Num. 1 – COM (tylko w Evo)
```
4 – Ethernet
```
5 – USB (NET)
```
6 – WiFi
```
no Numer portu wybranego typu NIE Num. (1-...)
```
ip Adres IP NIE Alfanum.
ma Maska podsieci NIE Alfanum.
ge Adres bramy NIE Alfanum.
dp Dns preferowany NIE Alfanum.
da Dns alternatywny NIE Alfanum.
dh Czy DHCP ma być włączone? NIE BOOL True – włączony
False – wyłączony
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Pole "no" jest wymagane w przypadku gdy interfejs ustawiany jest na porcie COM.
2. Jeśli dh = True parametry ip, ma i ge nie są wymagane.
3. Nieprzesłanie dp spowoduje ustawienie adresu DNS na 8.8.8.8
4. Nieprzesłanie da spowoduje ustawienie adresu DNS na 8.8.4.4
5. Parametr id=6 niedostępny w urządzeniach bez modułu WiFi.
6. W urządzeniu Vero, parametr id może przyjąć tylko wartość 5.
7. W urządzeniu Evo, parametr id może przyjąć tylko wartość 1 lub 5.
8. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]tcpipcfgset[TAB]id4[TAB]ip192.168.1.1[TAB]#CRC16[ETX]
```

## [tcpipcfgget] Odczyt konfiguracji interfejsu TCP/IP
Identyfikator polecenia:
tcpipcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
```
id Typ portu - Num. 1 – COM (tylko w Evo)
```
4 – Ethernet
```
5 – USB (NET)
```
6 – WiFi
```
no Numer portu wybranego typu - Num. (1-...)
```
ip Adres IP - Alfanum.
ma Maska podsieci - Alfanum.
ge Adres bramy - Alfanum.
dp Dns preferowany - Alfanum.
da Dns alternatywny - Alfanum.
dh Czy DHCP jest włączone? - BOOL True – włączone
False – wyłączone
```
Uwagi:
```
1. Parametr id=6 niedostępny w urządzeniach bez modułu WiFi.
2. Dostępność w trybie tylko do odczytu: TAK.
3. W urządzeniu Vero, parametr id może przyjąć tylko wartość 5.
4. W urządzeniu Evo, parametr id może przyjąć tylko wartość 1 lub 5.
Przykład:
```plaintext
[STX]tcpipcfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]tcpipcfgget[TAB]id5[TAB]no1[TAB]ip192.168.137.242[TAB]ma255.255.255.0[TAB]ge-
192.168.137.1[TAB]dp192.168.137.1[TAB]da0.0.0.0[TAB]dhT[TAB]#CRC16[ETX]

## [wifinetworkstat] Odczyt statusu sieci WiFi
Identyfikator polecenia:
wifinetworkstat
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
cc Czy urządzenie jest połączone z
siecią WiFi?
- BOOL. True – urządzenie połączone
False – urządzenie nie połą-
czone
na Nazwa sieci - Alfanum.
cn Liczba zapisanych sieci - Num.
cm Maksymalna liczba możliwych
do zapisania sieci
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]wifinetworkstat[TAB]#CRC16[ETX]
```

## [wifilistnetworks] Odczyt listy skonfigurowanych połączeń WiFi
Identyfikator polecenia:
wifilistnetworks
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ix Indeks zapisanego rekordu TAK Num. Zakres:
0 … liczba zapamiętanych
sieci
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa sieci. - Alfanum.
ac Czy aktywne automatyczne łą-
czenie z siecią?
- BOOL. True – automatyczne łączenie
aktywne.
False – brak automatycznego
łączenia.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]wifilistnetworks[TAB]ix0[TAB]#CRC16[ETX]
```

## [wifinetworkadd] Konfiguracja połączenia z siecią WiFi
Identyfikator polecenia:
wifinetworkadd
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa sieci TAK Alfanum. Długość do 32 znaków.
```
Dopuszczalne są litery (alfabet
```
```
angielski), cyfry i następujące
```
```
znaki: !"#$%&'()*+,-./:;<=>?
```
```
@[\]^_`{|}~
```
ps Hasło do sieci TAK Alfanum. Długość do 32 znaków.
```
Dopuszczalne są litery (alfabet
```
```
angielski), cyfry i następujące
```
```
znaki: !"#$%&'()*+,-./:;<=>?
```
```
@[\]^_`{|}~
```
ac Czy automatyczne łączenie z
siecią włączone?
TAK BOOL. True – włączone
False – wyłączone
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Wysłanie polecenia powoduje rozłączenie z obecną siecią i próbę połączenia z siecią prze-
słaną w poleceniu.
3. Automatyczne łączenie z siecią (parametr ac), polega na samoczynnym połączeniu z siecią
po włączeniu urządzenia lub po utracie połączenia.
4. Przy połączeniu z siecią niezabezpieczoną należy przesyłać pusty parametr ps.
Przykład:
```plaintext
[STX]wifinetworkadd[TAB]naSiec01[TAB]psQwerty123[TAB]ac1[TAB]#CRC16[ETX]
```

## [wifinetworkdel] Usunięcie konfiguracji wybranej sieci WiFi
Identyfikator polecenia:
wifinetworkdel
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa sieci TAK Alfanum. Długość do 32 znaków.
```
Dopuszczalne są litery (alfabet
```
```
angielski), cyfry i następujące
```
```
znaki: !"#$%&'()*+,-./:;<=>?
```
```
@[\]^_`{|}~
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]wifinetworkdel[TAB]naSiec01[TAB]#CRC16[ETX]
```

## [powersavemodeset] Ustawienie konfiguracji trybu oszczędzania energii
w module WiFi i Bluetooth
Identyfikator polecenia:
powersavemodeset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sm włączenie/wyłączenie trybu
oszczędzania energii
TAK BOOL True – tryb oszczędzania włą-
czony
False – tryb oszczędzania wy-
łączony
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w urządzeniach bez modułu WiFi/Bluetooth.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]powersavemodeset[TAB]sm1[TAB]#CRC16[ETX]
```

## [powersavemodeget] Odczyt konfiguracji trybu oszczędzania energii w
module WiFi i Bluetooth
Identyfikator polecenia:
powersavemodeget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
sm włączenie/wyłączenie trybu
oszczędzania energii
TAK BOOL True – tryb oszczędzania włą-
czony
False – tryb oszczędzania wy-
łączony
```
Uwagi:
```
1. Polecenie niedostępne w urządzeniach bez modułu WiFi/Bluetooth.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]powersavemodeget[TAB]#CRC16[ETX]
```

## [bluetoothnameset] Ustawienie nazwy Bluetooth
Identyfikator polecenia:
bluetoothnameset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa Bluetooth TAK Alfanum.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w urządzeniach bez modułu Bluetooth .
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]bluetoothnameset[TAB]naDrukarka1[TAB]#CRC16[ETX]
```

## [bluetoothnameget] Odczyt nazwy Bluetooth
Identyfikator polecenia:
bluetoothnameget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa Bluetooth TAK Alfanum.
```
Uwagi:
```
1. Polecenie niedostępne w urządzeniach bez modułu Bluetooth.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]bluetoothnameget[TAB]#CRC16[ETX]
```

## [tunnelset] Zapis konfiguracji tunelowania
Identyfikator polecenia:
tunnelset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sp numer portu szeregowego TAK Num. 0 – COM1
```
1 – COM2 (w urządzeniach
```
posiadających dodatkowy port
```
com)
```
en czy tunelowanie włączone? TAK BOOL
da port danych NIE Num. Domyślnie 4141
di port diagnostyczny NIE Num. Domyślnie 4142
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo, Vero, Evo, Fawag Box.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]tunnelset[TAB]sp1[TAB]en1[TAB]#CRC16[ETX]
```

## [tunnelget] Odczyt konfiguracji tunelowania
Identyfikator polecenia:
tunnelget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sp numer portu szeregowego TAK Num. 0 – COM1
```
1 – COM2 (w urządzeniach
```
posiadających dodatkowy port
```
com)
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
en czy tunelowanie włączone? - BOOL
da port danych - Num.
di port diagnostyczny - Num.
```
Uwagi:
```
1. Polecenie niedostępne w drukarce Temo, Vero, Evo, Fawag Box.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]tunnelget[TAB]sp0[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]tunnelget[TAB]en1[TAB]da2002[TAB]di2003[TAB]#CRC16[ETX]
```

## [fspset] Zapis konfiguracji odczytu pamięci chronionej
Identyfikator polecenia:
fspset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tp numer portu TCP/IP TAK Num.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]fspset[TAB]tp2121[TAB]#CRC16[ETX]
```

## [fspget] Odczyt konfiguracji odczytu pamięci chronionej
Identyfikator polecenia:
fspget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
tp numer portu TCP/IP - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]fspget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]fspget[TAB]tp2121[TAB]#CRC16[ETX]
```

## [nearendsensorcfgset] Zapis konfiguracji działania czujnika końca pa-
pieru
Identyfikator polecenia:
nearendsensorcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
en Konfiguracja czujnika TAK BOOL True – czujnik włączony
False – czujnik wyłączony
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Gdy urządzenie nie posiada czujnika, wysłanie polecenia nie będzie miało skutku. Urządze-
nie nie zgłasza błędu w takiej sytuacji.
Przykład:
```plaintext
[STX]nearendsensorcfgset[TAB]en1[TAB]#CRC16[ETX]
```

## [nearendsensorcfgget] Odczyt konfiguracji działania czujnika końca pa-
pieru
Identyfikator polecenia:
nearendsensorcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
en Konfiguracja czujnika - BOOL True – czujnik włączony
False – czujnik wyłączony
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Gdy urządzenie nie posiada czujnika, wysłanie polecenia zawsze zwraca en = False.
Przykład:
```plaintext
[STX]nearendsensorcfgget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]nearendsensorcfgget[TAB]en1[TAB]#CRC16[ETX]
```

## [chgcfgset] Konfiguracja pracy ładowarki
Identyfikator polecenia:
chgcfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
mo Konfiguracja ładowarki – prąd
ładowania
TAK Num. 0 – Standardowy
1 – Obniżony
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie dostępne tylko w drukarce Fawag Box.
Przykład:
```plaintext
[STX]chgcfgset[TAB]#CRC16[ETX]
```

## [chgcfgget] Odczyt konfiguracji pracy ładowarki
Identyfikator polecenia:
chgcfgget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
mo Konfiguracja ładowarki – prąd
ładowania
Nie Num. 0 – Standardowy
1 – Obniżony
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie dostępne tylko w drukarce Fawag Box.
Przykład:
```plaintext
[STX]chgcfgset[TAB]#CRC16[ETX]
```

Współpraca z serwerami EventHub i WebApi
## [repositoryeventhubtrigger] Polecenie nawiązania połączenia z serwe-
rem EventHub
Identyfikator polecenia:
repositoryeventhubtrigger
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]repositoryeventhubtrigger[TAB]#CRC16[ETX]
```

## [repositorywebapitrigger] Polecenie nawiązania połączenia z serwerem
WebApi
Identyfikator polecenia:
repositorywebapitrigger
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]repositorywebapitrigger[TAB]#CRC16[ETX]
```

## [repositoryeventhubstate] Odczyt statusu komunikacji z serwerem
EventHub
Identyfikator polecenia:
repositoryeventhubstate
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data i czas ostatniego połączenia
z serwerem
- Data i czas
ISO8601
ds Data i czas ostatniego udanego
połączenia z serwerem
- Data i czas
ISO8601
df Data i czas ostatniego nieudane-
go połączenia z serwerem
- Data i czas
ISO8601
lr Flaga informująca o statusie
ostatniego połączenia
- BOOL True – ostatnie operacje
zakończone z wynikiem
pozytywnym
False – ostatnie operacje
zakończone z wynikiem
negatywnym
ac Flaga informująca czy przesył
danych został ukończony
- BOOL True – operacje przesyłu danych
są wykonywane
False – operacje przesyłu
danych zostały zakończone
```
Uwagi:
```
1. W trybie niefiskalnym parametr da, ds, df zawsze zwraca 2000-01-01T01:00:00+01:00.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]repositoryeventhubstate[TAB]#CRC16[ETX]
```

## [repositorywebapistate] Odczyt statusu komunikacji z serwerem WebA-
pi
Identyfikator polecenia:
repositorywebapistate
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data i czas ostatniego połączenia
z serwerem
- Data i czas
ISO8601
ds Data i czas ostatniego udanego
połączenia z serwerem
- Data i czas
ISO8601
df Data i czas ostatniego nieudane-
go połączenia z serwerem
- Data i czas
ISO8601
lr Flaga informująca o statusie
ostatniego połączenia
- BOOL True – ostatnie operacje
zakończone z wynikiem
pozytywnym
Fale – ostatnie operacje
zakończone z wynikiem
negatywnym
ac Flaga informująca czy wykony-
wane operacje zostały zakończo-
ne
- BOOL True – operacje są wykonywane
False – operacje zostały
zakończone
```
Uwagi:
```
1. W trybie niefiskalnym parametr da, ds, df zawsze zwraca 2000-01-01T01:00:00+01:00.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]repositorywebapistate[TAB]#CRC16[ETX]
```

## [connectionscheduleinfoget] Odczyt informacji o harmonogramie połą-
czeń
Identyfikator polecenia:
connectionscheduleinfoget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
co Kod komendy - Alfanum.
of Czy wysyłka EventHub jest w
stanie offline?
- BOOL
eh Wysyłka EventHub - Num. Wartość zignorować gdy pa-
rametr of jest ‘T’
wa Sprawdzanie WebApi - Num.
bi Czy wysyłać paragony? - BOOL
cb Czy wysyłać paragony anulowa-
ne?
- BOOL
in Czy wysyłać faktury? BOOL
ci Czy wysyłać faktury anulowa-
ne?
BOOL
dr Czy wysyłać raporty dobowe? BOOL
nf Czy wysyłać dokumenty niefi-
skalne?
BOOL
ev Czy wysyłać zdarzenia? BOOL
fr Czy wysyłać raport fiskalizacji? BOOL
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]connectionscheduleinfoget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:

[STX]connectionscheduleinfoget[TAB]coTFD.ZAB1701001116.2020-11-05T10:50:00.049Z[TAB]
eh7200[TAB]ofN[TAB]wa1800[TAB]biN[TAB]cbT[TAB]inN[TAB]ciT[TAB]drT[TAB]nfT[TAB]
evN[TAB]frT[TAB]#CRC16[ETX]

## [repositorysenddatacheck] Sprawdzenie, czy zalecane jest wysłanie da-
nych do repozytorium
Identyfikator polecenia:
repositorysenddatacheck
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
cs Czy zalecane jest połączenie z
repozytorium?
- BOOL True – zalecane połączenie z
repozytorium
```
(repositoryeventhubtrigger)
```
False – połączenie z
repozytorium nie wymagane
```
Uwagi:
```
1. Urządzenie powinno być w trybie fiskalnym.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]repositorysenddatacheck[TAB]#CRC16[ETX]
```

## [repositoryunregister] Wyrejestrowanie urządzenia
Identyfikator polecenia:
repositoryunregister
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Urządzenie powinno być w trybie tylko do odczytu.
Przykład:
```plaintext
[STX]repositoryunregister[TAB]#CRC16[ETX]
```

## [repositoryunregistercheck] Status wyrejestrowania urządzenia
Identyfikator polecenia:
repositoryunregistercheck
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
st Status wyrejestrowania urządze-
nia
- Num. 0 – urządzenie wyrejestrowane
1 – błąd wyrejestrowania
2 – stan nieznany
```
Uwagi:
```
1. Urządzenie powinno być w trybie tylko do odczytu.
Przykład:
```plaintext
[STX]repositoryunregistercheck[TAB]#CRC16[ETX]
```

Aktualizacja oprogramowania
## [schedulefirmwareupdateget] Odczyt harmonogramu aktualizacji opro-
gramowania
Identyfikator polecenia:
schedulefirmwareupdateget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
sd Harmonogram aktualizacji - Num. Czas w sekundach, określający
częstotliwość sprawdzania
```
dostępnych aktualizacji (min. 1
```
```
minuta – max. 31 dni)
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]schedulefirmwareupdateget[TAB]#CRC16[ETX]
```

## [firmwareupdatesourceget] Odczyt adresu serwera aktualizacji oprogra-
```
mowania (SAO)
```
Identyfikator polecenia:
firmwareupdatesourceget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ur Adres serwera aktualizacji - Alfanum. Od 9 do 140 znaków.
Adres serwera, musi rozpoczynać
się od „https://”.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]firmwareupdatesourceget[TAB]#CRC16[ETX]
```

## [firmwareupdaterequest] Wywołanie sprawdzania dostępności aktuali-
zacji
Identyfikator polecenia:
firmwareupdaterequest
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Status realizacji polecenia odsyłany jest za pomocą rozkazu firmwareupdatestateget
Przykład:
```plaintext
[STX]firmwareupdaterequest[TAB]#CRC16[ETX]
```

## [firmwareupdatestateget] Pobranie informacji o statusie realizacji komu-
nikacji z SAO
Identyfikator polecenia:
firmwareupdatestateget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
op Opis statusu:
"Sprawdzanie aktualizacji"
"Pobieranie aktualizacji"
"Aktualizacja gotowa: <Nazwa aktuali-
zacji>"
"Brak aktualizacji"
"Dostępna aktualizacja: <Nazwa aktu-
alizacji>"
- Alfanum.
da Data i czas ostatniej zmiany sta-
tusu
- Data i czas
tm Data i czas ostatniej zmiany sta-
tusu
- Data i czas
ISO8601
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]firmwareupdatestateget[TAB]#CRC16[ETX]
```

## [firmwareupdatedownload] Wywołanie pobierania aktualizacji
Identyfikator polecenia:
firmwareupdatedownload
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Status realizacji polecenia odsyłany jest za pomocą rozkazu firmwareupdatestateget
Przykład:
```plaintext
[STX]firmwareupdatedownload[TAB]#CRC16[ETX]
```

## [firmwareupdateinstall] Wywołanie instalacji aktualizacji
Identyfikator polecenia:
firmwareupdateinstall
Parametry wejściowe:
brak
Odpowiedź urządzenia:
brak odpowiedzi, restart urządzenia
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]firmwareupdateinstall[TAB]#CRC16[ETX]
```

Obsługa grafiki
## [imgslotset] Programowanie grafiki
Identyfikator polecenia:
imgslotset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer programowanej grafiki TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
wx Szerokość grafiki w pikselach NIE Num. maks. 640
hx Wysokość grafiki w pikselach NIE Num. maks. 640
```
tx Dane z grafiką NIE Alfanum. maks. 1KB (tryb HEX)
```
bm Dane grafiki w formacie BMP NIE BOOL domyślnie - False
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Grafika może występować w dwóch formatach:
```
a) bitmapa jednokolorowa, gdzie kolor czarny reprezentowany jest przez logiczną '1', a naj-
```
```
starszy bit w bajcie drukowany jest po lewej stronie (zwana dalej formatem RAW)
```
```
b) mapa bitowa BMP
```
3. Parametry wx i hx są obowiązkowe dla formatu RAW, a niedozwolone dla formatu BMP. Pa-
rametr bm z wartością "True" jest obowiązkowy dla BMP i niedozwolony dla RAW.
4. Liczba bajtów danych grafiki - wynika z rozmiaru bitmapy
```
a) Dla formatu RAW:
```
1. 'Liczba bajtów dla jednej linijki' = część całkowita z (('szerokość' + 7) / 8)
2. 'Całkowita liczba bajtów' = 'Liczb bajtów dla jednej linijki' * 'wysokość'
```
b) Dla formatu BMP rozmiar grafiki zapisany jest w nagłówku przesyłanym razem z resztą
```
danych
5. Dane grafiki powinny być podzielone w paczki po maks. 1KB i dodawane za pomocą ko-
mendy „imgslotappend”
6. W urządzeniach, które ze względu na typ mechanizmu drukującego nie mogą drukować gra-
fiki o maksymalnej szerokości, przesłane dane są skalowane do możliwości sprzętowych
urządzenia. Skalowanie powoduje zachowanie proporcji grafiki.
Maksymalne szerokości grafiki dla poszczególnych urządzeń
Thermal HD tryb 80mm = 640
Thermal HD tryb 57mm = 460

Thermal XL2 i HX tryb 80mm = 576
Thermal XL2 i HX tryb 57mm = 432
Trio, Temo, PosPay, Vero, Evo, Fawag Box = 384
7. Komenda usuwa poprzednią grafikę znajdującą się w danym slocie.
Przykłady:
```plaintext
[STX]imgslotset[TAB]no1[TAB]wx400[TAB]hx400[TAB]#CRC16[ETX]
[STX]imgslotset[TAB]no2[TAB]bm1[TAB]#CRC16[ETX]
```

## [imgslotappend] Programowanie grafiki – dodanie danych
Identyfikator polecenia:
imgslotappend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer programowanej grafiki TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
```
tx Dane z grafiką TAK Alfanum. maks. 1KB (tryb HEX)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Wymagana jest wcześniejsze zaprogramowanie grafiki komendą „imgslotset”
Przykład:
```plaintext
[STX]imgslotappend[TAB]no1[TAB]tx000000000000000004FF00[TAB]CRC16[ETX]
```

## [imgslotisbusy] Sprawdzenie, czy grafika jest w trakcie ładowania
Identyfikator polecenia:
imgslotisbusy
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ib Informacja o stanie ładowania
grafiki
- BOOL True - grafika jest w trakcie ła-
dowania, False - grafika nie
jest w trakcie ładowania
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]imgslotisbusy[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]imgslotisbusy[TAB]ib1[TAB]#CRC16[ETX]
```

## [imgslotcancel] Anuluj ładowanie grafiki
Identyfikator polecenia:
imgslotcancel
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]imgslotcancel[TAB]#CRC16[ETX]
```

## [imgslotget] Odczyt parametrów grafiki
Identyfikator polecenia:
imgslotget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer programowanej grafiki TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
wx Szerokość grafiki - Num.
hx Wysokość grafiki - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Dane grafiki powinny być odczytywane za pomocą komendy „imgslotreceive” w paczkach
po maks. 256B
Przykład:
```plaintext
[STX]imgslotget[TAB]no1[TAB]#CRC16[ETX]
```

## [imgslotreceive] Odczyt grafiki – odczyt danych
Identyfikator polecenia:
imgslotreceive
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer odczytywanej grafiki TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
ad Adres TAK Num.
rb Ilość bajtów TAK Num Maksymalnie 256 bajtów
```
bm Format grafiki NIE BOOL Domyślnie False (format
```
```
RAW), True dla formatu BMP
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
tx Dane z grafiką - Alfanum. tryb HEX
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Dane grafiki zwracane są w zapisie szesnastkowym (dwa znaki na każdy bajt) dlatego ilość
znaków w odpowiedzi będzie dwa razy większa niż wartość parametru rb.
3. Liczba bajtów danych grafiki - wynika z rozmiaru bitmapy
```
a) Dla formatu RAW:
```
1. 'Liczba bajtów dla jednej linijki' = część całkowita z (('szerokość' + 7) / 8)
2. 'Całkowita liczba bajtów' = 'Liczb bajtów dla jednej linijki' * 'wysokość'
```
b) Dla formatu BMP rozmiar grafiki zapisany jest w nagłówku przesyłanym razem z resztą
```
danych
Przykład:
```plaintext
[STX]imgslotreceive[TAB]no1[TAB]ad0[TAB]rb256[TAB]CRC16[ETX]
```

## [imgslotchecksum] Odczyt skrótu grafiki
Identyfikator polecenia:
imgslotchecksum
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer odczytywanej grafiki TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
```
bm Format grafiki NIE BOOL Domyślnie False (format
```
```
RAW), True dla formatu BMP
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
sh Skrót SHA1 grafiki w zadanym
formacie
- Alfanum. tryb HEX
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Zwracany jest skrót SHA1 grafiki w formacie heksadecymalnym, co daje 40 znaków alfanu-
merycznych.
3. Na potrzeby wyliczania skrótu grafika konwertowana jest do stosownego formatu zgodnie z
parametrem bm
Przykład:
```plaintext
[STX]imgslotchecksum[TAB]no1[TAB]bm1[TAB]CRC16[ETX]
```
Przykład odpowiedzi:
[STX]imgslotchecksum[TAB]sh123456789A123456789A123456789A123456789A[TAB]CRC16[
ETX]

## [imgslotdocid] Odczyt numeru dokumentu w pamięci chronionej przypi-
sanego do slotu
Identyfikator polecenia:
imgslotdocid
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer odczytywanej grafiki TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Numer dokumentu w pamięci
chronionej
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Zwracany jest numer dokumentu w pamięci chronionej, który przypisany jest do podanego
slotu
Przykład:
```plaintext
[STX]imgslotdocid[TAB]no1[TAB]CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]imgslotdocid[TAB]id190[TAB]CRC16[ETX]
```

## [imgslotdelete] Usunięcie zaprogramowanej grafiki
Identyfikator polecenia:
imgslotdelete
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer grafiki do usunięcia TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Grafika zostanie usunięta jedynie z bazy danych, nie z pamięci chronionej
3. W przypadku odbudowy bazy danych grafik na podstawie pamięci chronionej, usunięte tą
komendą grafiki mogą zostać przywrócone
Przykład:
```plaintext
[STX]imgslotdelete[TAB]no1[TAB]CRC16[ETX]
```

## [imgprogrep] Potwierdzenie programowania grafiki
Identyfikator polecenia:
imgprogrep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer grafiki do wydrukowania TAK Num. Zakres: 1-500
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]imgprogrep[TAB]no1[TAB]CRC16[ETX]
```

## [imgheaderset] Wybór grafiki drukowanej w nagłówku
Identyfikator polecenia:
imgheaderset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer grafiki drukowanej w na-
główku
TAK Num. 0 – nie drukuj grafiki w na-
główku
```
Zakres: 1-500
```
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Jeżeli włączona jest opcja 'oszczędności papieru', to aktywacja zmiany grafiki w nagłówku
```
może skutkować dopiero od następnego wydruku (nie od najbliższego).
```
Przykład:
```plaintext
[STX]imgheaderset[TAB]no1[TAB]CRC16[ETX]
```

## [imgfooterset] Wybór grafiki drukowanej w stopce
Identyfikator polecenia:
imgfooterset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer grafiki drukowanej w
stopce
TAK Num. 0 – nie drukuj grafiki w stopce
```
Zakres: 1-500
```
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]imgfooterset[TAB]no1[TAB]CRC16[ETX]
```

## [imgdocget] Odczyt ustawień grafiki w dokumencie
Identyfikator polecenia:
imgdocget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
hd Numer grafiki zaprogramowanej
w nagłówku
- Num. 0 – nie drukuj grafiki w na-
główku
```
Zakres: 1-500
```
Dla FAWAG BOX: 1-40
ft Numer grafiki zaprogramowanej
w stopce
- Num. 0 – nie drukuj grafiki w stopce
```
Zakres: 1-500
```
Dla FAWAG BOX: 1-40
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]imgdocget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]imgdocget[TAB]hd1[TAB]ft2[TAB]#CRC16[ETX]
```

## [imgecset] Konfiguracja wydruku grafiki z pamięci chronionej
Identyfikator polecenia:
imgecset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
lv Zakres grafik drukowanych z pa-
mięci chronionej
TAK Num. 0 – w potwierdzeniach progra-
mowania grafik,
1 – jak dla 0 oraz grafiki w
stopkach i nagłówkach
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]imgecset[TAB]lv1[TAB]CRC16[ETX]
```

## [imgecget] Odczyt konfiguracji wydruku grafiki z pamięci chronionej
Identyfikator polecenia:
imgecget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
lv Zakres grafik drukowanych z
kopii
- Num. 0 – w potwierdzeniach progra-
mowania grafik,
1 – jak dla 0 oraz grafiki w
stopkach i nagłówkach
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]imgecget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]imgecget[TAB]lv1[TAB]#CRC16[ETX]
```

Współpraca z monitorem transakcji
## [trlogset] Konfiguracja interfejsu monitora transakcji
Identyfikator polecenia:
trlogset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Typ portu szeregowego TAK Num. 0 – brak,
1 – COM,
2 – USB,
4 – TCP/IP
7 – Bluetooth
no Numer portu NIE Num. 1 - … dla portu COM
1024 – 49151 dla TCP/IP
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Pole "no" jest wymagane w przypadku gdy interfejs ustawiany jest na porcie COM lub po
TCP/IP. Dla USB może przyjąć jedynie wartość 1.
2. Parametr id=1 niedostępny w urządzeniach bez portu com.
3. Parametr id=7 niedostępny w urządzeniach bez modułu Bluetooth.
4. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]trlogset[TAB]id0[TAB]#CRC16[ETX]
```

## [trlogget] Odczyt konfiguracji interfejsu monitora transakcji
Identyfikator polecenia:
trlogget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Typ portu szeregowego - Num. 0 – brak,
1 – COM,
2 – USB,
4 – TCP/IP
7 – Bluetooth
no Numer portu - Num. 1 - … dla portu COM
1024 – 49151 dla TCP/IP
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Parametr id=1 niedostępny w urządzeniach bez portu com.
2. Parametr id=7 niedostępny w urządzeniach bez modułu Bluetooth.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]trlogget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]trlogget[TAB]id1[TAB]no0[TAB]#CRC16[ETX]
```

## [trlogframecfgset] Konfiguracja ramki monitora transakcji
Identyfikator polecenia:
trlogframecfgset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Id elementu ramki TAK Num.
na Ciąg znaków konfiguracji ele-
mentu ramki
TAK Alfanum.
Odpowiedź urządzenia:
standardowa
Przykład:
```plaintext
[STX]trlogframecfgset[TAB]id0[TAB]na3031[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Ciąg znaków konfiguracji elementu ramki to ciąg kodów ASCII zapisanych szesnastkowo
```
(np. 3031 oznacza „01”); każdy kod powinien być zapisany na dwóch znakach (np. kod zna-
```
```
ku tabulacji - 09, kod znaku nowej linii – 0A). Maksymalna długość łańcucha znaków – 20
```
```
(10 kodów ASCII).
```
3. Tabela poniżej opisuje przyporządkowanie poszczególnych ciągów do konkretnych elemen-
tów ramki monitora oraz ustawienia domyślne:
id Element ramki
Wartość domyślna
ASCII szesnastkowo
0 Początek ramki <CR> 0D
1 Koniec ramki <LF> 0A
2 Separator pól ramki <TAB> 09
3 Typ ramki 'rozpoczęcie sprzedaży' 30 3330
4 Typ ramki 'rozpoczęcie opakowań' 31 3331
5 Typ ramki 'rozpoczęcie faktury' 32 3332
6 Typ ramki 'anulowanie paragonu' 3 33
7 Typ ramki 'anulowanie rozliczenia opakowań' 5 35
```

8 Typ ramki 'zakończenie paragonu' 2 32
9 Typ ramki 'zakończenie rozliczenia opakowań' 4 34
10 Typ ramki 'zakończenie faktury' 10 3130
11 Typ ramki 'sprzedaż' 0 30
12 Typ ramki 'stornowanie' 1 31
13 Typ ramki ''zalogowanie 20 3230
14 Typ ramki 'wylogowanie' 21 3231
15 Typ ramki 'wpłata do kasy' 6 36
16 Typ ramki 'wypłata z kasy' 7 37
17 Typ ramki 'wpłata formy płatności podczas sprzedaży' 8 38
18 Typ ramki 'reszta podczas sprzedaży' 9 39
19 Typ ramki 'rabat do linii lub stawki vat’ 51 3531
```
20 Typ ramki 'rabat do grupy (do podsumy lub paragonu)' 57 3537
```
29 Typ ramki 'separator końca linii dla tekstu wieloliniowego' <Space> 20
30 Typ ramki 'zaliczka' 40 3430
31 Typ ramki 'storno zaliczki' 41 3431
32 Typ ramki 'przejście do podsumy' 45 3435
33 Typ ramki 'anulowanie faktury' 11 3131

## [trlogframecfgget] Odczyt konfiguracji ramki monitora transakcji
Identyfikator polecenia:
trlogframecfgget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Id elementu ramki TAK Num. Patrz opis trlogframecfgset
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Id elementu ramki - Num. Patrz opis trlogframecfgset
na Ciąg znaków konfiguracji ele-
mentu ramki
- Alfanum. Patrz opis trlogframecfgset
Odpowiedź urządzenia:
standardowa
Przykład:
```plaintext
[STX]trlogframecfgget[TAB]id0[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
```plaintext
[STX]trlogframecfgget[TAB]id0[TAB]na3031[TAB]#CRC16[ETX]
```
Uwagi:
```
1. Jednorazowo można odczytać konfigurację tylko jednego elementu ramki.
2. Reszta uwag jak w opisie polecenia trlogframecfgset.
3. Dostępność w trybie tylko do odczytu: TAK.
```

Drukowanie raportów
## [dailyrep] Raport dobowy
Identyfikator polecenia:
dailyrep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Aktualna data NIE Data Data jest weryfikowana z bieżą-
cym ustawieniem zegara syste-
mowego.
W przypadku braku parametru
użytkownik musi potwierdzić da-
tę z klawiatury.
up Potwierdzenie dostępności aktu-
alizacji
NIE Bool True – potwierdzenie informacji
o dostępnej aktualizacji
False – brak potwierdzenia
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. W trybie fiskalnym, nie można wykonać kolejno dwóch zerowych raportów dobowych (gdy
```
totalizery są zerowe).
```
2. Parametr up nie jest obsługiwany w urządzeniach THERMAL XL2 ONLINE 2.01, THER-
MAL XL2 ONLINE S 2.01, THERMAL HD ONLINE 2.01, POSPAY ONLINE 2.01,
THERMAL HX 1.01, THERMAL HX S 1.01, VERO 2.01, EVO 1.01.
3. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dailyrep[TAB]da2007-02-19[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:7|
| RAPORT FISKALNY |
| DOBOWY NR 2 |
|OD:2018-10-15 14:27 DO:2018-10-15 14:27|

|- - - - - - - - - - - - - - - - - - - - |
|PTU A 23% PTU B 8% PTU C 3% |
|PTU D 0% PTU E 0% G Zwolniona |
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA PTU A 8,13|
|SPRZEDAŻ OPODATKOWANA PTU B 0,00|
|SPRZEDAŻ OPODATKOWANA PTU C 0,00|
|SPRZEDAŻ OPODATKOWANA PTU D 0,00|
|SPRZEDAŻ OPODATKOWANA PTU E 0,00|
|SPRZEDAŻ OPODATKOWANA PTU AFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU BFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU CFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU DFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU EFV 0,00|
|SPRZEDAŻ ZWOLNIONA G 0,00|
|SPRZEDAŻ ZWOLNIONA GFV 0,00|
|KWOTA PTU A 1,87|
|KWOTA PTU B 0,00|
|KWOTA PTU C 0,00|
|KWOTA PTU D 0,00|
|KWOTA PTU E 0,00|
|KWOTA PTU AFV 0,00|
|KWOTA PTU BFV 0,00|
|KWOTA PTU CFV 0,00|
|KWOTA PTU DFV 0,00|
|KWOTA PTU EFV 0,00|
|ŁĄCZNA KWOTA PTU 1,87|
|ŁĄCZNA SPRZEDAŻ BRUTTO 10,00|
|- - - - - - - - - - - - - - - - - - - - |
|WALUTA EWIDENCYJNA PLN|
|- - - - - - - - - - - - - - - - - - - - |
|ZDARZENIA |
| SYTUACJE AWARYJNE 0|
| PROGRAMOWANIE L-0 / O-0|
| ZMIANY W BAZIE 0|
|- - - - - - - - - - - - - - - - - - - - |
|PARAGONY 1 FAKTURY 0|
|PARAGONY ANULOWANE 1 / 10,00|
|DOKUMENTY NIEFISKALNE 0|
|- - - - - - - - - - - - - - - - - - - - |
|#001 KIEROWNIK 2018-10-15 14:27|
|2D5BD5BC144BB8DF12A19DCAC957A7C7C37B4A5D|
```
| {PL} ZBF 1801007583 |
```

## [periodicrepbynumbers] Raport okresowy wg numerów
Identyfikator polecenia:
periodicrepbynumbers
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer początkowy TAK Num.
tn Numer końcowy TAK Num.
su Czy ma być drukowany tylko ra-
port podsumowujący?
NIE BOOL Domyślnie False – pełny raport
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]periodicrepbynumbers[TAB]fn5[TAB]tn34[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 |
| RAPORT FISKALNY |
| OKRESOWY |
|FISKALIZACJA: 2018-10-15 14:26|
|- - - - - - - - - - - - - - - - - - - - |
|OD 2018-10-15 14:27 DO 2018-10-15 14:27|
|OD RAPORTU 1 DO RAPORTU 2|
|- - - - - - - - - - - - - - - - - - - - |
|RAPORT FISKALNY DOBOWY 1|
|OD:2018-10-15 14:27 DO:2018-10-15 14:27|
|- - - - - - - - - - - - - - - - - - - - |
|PTU A 23% PTU B 8% PTU C 3% |
|PTU D 0% PTU E 0% G Zwolniona |
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA PTU A 8,13|
|SPRZEDAŻ OPODATKOWANA PTU B 0,00|
|SPRZEDAŻ OPODATKOWANA PTU C 0,00|
|SPRZEDAŻ OPODATKOWANA PTU D 0,00|
|SPRZEDAŻ OPODATKOWANA PTU E 0,00|
|SPRZEDAŻ OPODATKOWANA PTU AFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU BFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU CFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU DFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU EFV 0,00|
|SPRZEDAŻ ZWOLNIONA G 0,00|
|SPRZEDAŻ ZWOLNIONA GFV 0,00|
|KWOTA PTU A 1,87|
|KWOTA PTU B 0,00|
|KWOTA PTU C 0,00|
|KWOTA PTU D 0,00|
|KWOTA PTU E 0,00|
|KWOTA PTU AFV 0,00|
|KWOTA PTU BFV 0,00|
|KWOTA PTU CFV 0,00|
|KWOTA PTU DFV 0,00|
|KWOTA PTU EFV 0,00|
|ŁĄCZNA KWOTA PTU 1,87|
|ŁĄCZNA SPRZEDAŻ BRUTTO 10,00|
|- - - - - - - - - - - - - - - - - - - - |
|WALUTA EWIDENCYJNA PLN|
|- - - - - - - - - - - - - - - - - - - - |
|RAPORT FISKALNY DOBOWY 2|
|OD:2018-10-15 14:27 DO:2018-10-15 14:27|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA PTU A 8,13|
|SPRZEDAŻ OPODATKOWANA PTU B 0,00|
|SPRZEDAŻ OPODATKOWANA PTU C 0,00|
|SPRZEDAŻ OPODATKOWANA PTU D 0,00|
|SPRZEDAŻ OPODATKOWANA PTU E 0,00|

|SPRZEDAŻ OPODATKOWANA PTU AFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU BFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU CFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU DFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU EFV 0,00|
|SPRZEDAŻ ZWOLNIONA G 0,00|
|SPRZEDAŻ ZWOLNIONA GFV 0,00|
|KWOTA PTU A 1,87|
|KWOTA PTU B 0,00|
|KWOTA PTU C 0,00|
|KWOTA PTU D 0,00|
|KWOTA PTU E 0,00|
|KWOTA PTU AFV 0,00|
|KWOTA PTU BFV 0,00|
|KWOTA PTU CFV 0,00|
|KWOTA PTU DFV 0,00|
|KWOTA PTU EFV 0,00|
|ŁĄCZNA KWOTA PTU 1,87|
|ŁĄCZNA SPRZEDAŻ BRUTTO 10,00|
|- - - - - - - - - - - - - - - - - - - - |
|WALUTA EWIDENCYJNA PLN|
|- - - - - - - - - - - - - - - - - - - - |
| PODSUMOWANIE |
|- - - - - - - - - - - - - - - - - - - - |
| PLN |
|SPRZEDAŻ OPODATKOWANA PTU A 16,26|
|SPRZEDAŻ OPODATKOWANA PTU B 0,00|
|SPRZEDAŻ OPODATKOWANA PTU C 0,00|
|SPRZEDAŻ OPODATKOWANA PTU D 0,00|
|SPRZEDAŻ OPODATKOWANA PTU E 0,00|
|SPRZEDAŻ OPODATKOWANA PTU AFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU BFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU CFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU DFV 0,00|
|SPRZEDAŻ OPODATKOWANA PTU EFV 0,00|
|SPRZEDAŻ ZWOLNIONA G 0,00|
|SPRZEDAŻ ZWOLNIONA GFV 0,00|
|KWOTA PTU A 3,74|
|KWOTA PTU B 0,00|
|KWOTA PTU C 0,00|
|KWOTA PTU D 0,00|
|KWOTA PTU E 0,00|
|KWOTA PTU AFV 0,00|
|KWOTA PTU BFV 0,00|
|KWOTA PTU CFV 0,00|
|KWOTA PTU DFV 0,00|
|KWOTA PTU EFV 0,00|
|- - - - - - - - - - - - - - - - - - - - |
|ŁĄCZNA SP. BRUTTO PLN 20,00|
|- - - - - - - - - - - - - - - - - - - - |
|ZDARZENIA |
| SYTUACJE AWARYJNE 0|
| PROGRAMOWANIE L-2 / O-0|
| ZMIANY W BAZIE 1|
|- - - - - - - - - - - - - - - - - - - - |
|PARAGONY 2 FAKTURY 0|
|PARAGONY ANULOWANE PLN 2 / 20,00|
|DOKUMENTY NIEFISKALNE 0|
|- - - - - - - - - - - - - - - - - - - - |
|#001 KIEROWNIK 2018-10-15 14:28|
```
| {PL} ZBF 1801007583 |
```

## [periodicrepbydates] Raport okresowy wg dat
Identyfikator polecenia:
periodicrepbydates
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fd Data początkowa TAK Data
td Data końcowa TAK Data
su Czy ma być drukowany tylko ra-
port podsumowujący?
NIE BOOL Domyślnie False – pełny raport
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]periodicrepbydates[TAB]fd2018-06-19[TAB]td2018-08-25[TAB]#CRC16[ETX]
```
```
Wydruk:
```
Przykład wydruku z wykorzystaniem rozkazu periodicrepbydates jak w rozkazie periodicrepby-
numbers.

## [monthlyrep] Raport miesięczny
Identyfikator polecenia:
monthlyrep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Data początkowa TAK Data W przesyłanej dacie brany jest
pod uwagę rok i miesiąc. Dzień
jest ignorowany, ale z
zachowaniem poprawnego for-
matu zapisu całej daty.
su Czy ma być drukowany tylko ra-
port podsumowujący?
NIE BOOL Domyślnie False – pełny raport
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie wykonuje raport okresowy obejmujący wskazany miesiąc.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]monthlyrep[TAB]da2021-06-19[TAB]#CRC16[ETX]
```
```
Wydruk:
```
Przykład wydruku z wykorzystaniem rozkazu monthlyrep jak w rozkazie periodicrepbynumbers.

## [shiftrep] Raport zmianowy
Identyfikator polecenia:
shiftrep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sh Nazwa zmiany. TAK Alfanum. Do 8 znaków
zr Czy ma to być raport zerujący? NIE BOOL Domyślnie False – czytający
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]shiftrep[TAB]shPIERWSZA[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:651|
| N I E F I S K A L N Y |
| RAPORT ZMIANOWY |
|Zmiana: PIERWSZA|
|Kasjer: Wojtek|
|Sprzedaż: 0,00|
|ILOŚĆ PARAGONÓW: 0|
|ILOŚĆ ANULOWANYCH PARAGONÓW: 0|
|Liczba stornowanych pozycji: 0|
|Wpłaty do kasy: 0,00|
|Wypłaty z kasy: 0,00|
|STAN KASY: 200000916,34|
|Początek zmiany: 2018-08-23 11:13|
|Koniec zmiany: 2018-08-23 11:13|
| N I E F I S K A L N Y |
|#11 Wojtek 2018-08-23 11:13|
|B5ED04CF636168800F25C95CCD9D45B55F86BC5A|
| ZBF 1801007587 |

## [cashstaterep] Raport stanu kasy
Identyfikator polecenia:
cashstaterep
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]cashstaterep[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:662|
| N I E F I S K A L N Y |
|STAN KASY 200000936,32|
| N I E F I S K A L N Y |
|#11 Wojtek 2018-08-23 11:57|
|87EF92E130EE78BEC673A2A7D56C7D396C4A1569|
| ZBF 1801007587 |

## [imgrep] Raport grafik
Identyfikator polecenia:
imgrep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer początkowy grafiki. NIE Num. Zakres: 1-500.
tn Numer końcowy grafiki. NIE Num. Zakres: 1-500.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]imgrep[TAB]fn1[TAB]tn3[TAB]#CRC16[ETX]
```

## [servicerep] Raport serwisowy
Identyfikator polecenia:
servicerep
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]servicerep[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE || POSNET POLSKA S.A. |
| ul. Municypalna 33 || 02-281 Warszawa |
| www.posnet.com ||NIP 5222628262 nr:674|
| N I E F I S K A L N Y || RAPORT SERWISOWY |
|DRUKARKA FISKALNA || POSNET THERMAL XL2 ONLINE|
|WERSJA PROGRAMU PRACY 2.01.12345678|| SUMA PROGRAMU 12345678B93D74E579387589|
|089014835656023577686022C34756F20113A536||PROGRAM AKTUALIZACJI 4A98B32C|
|KATEGORIA OGÓLNA||TYP UŻYTKOWANIA MOBILNA| - linia nie jest drukowana w trybie niefiskalnym
|TYP WŁASNOŚCI WŁASNA| - linia nie jest drukowana w trybie niefiskalnym|NR FABRYCZNY PO808201253|
|NR UNIKATOWY ZBF 1801007587||NR PAMIĘCI CHRONIONEJ 1|
|FISKALNY LICZNIK PARAGONÓW DOBOWY||TRYB PRACY DRUKARKI FISKALNY|
|FISKALIZACJA 2018-08-20 13:05||NR EWIDENCYJNY 2018/000003897|
|- - - - - - - - - - - - - - - - - - - - ||STAWKI PTU 1/30|
|PTU A 23% PTU B 8% PTU C 3% ||PTU D 0% PTU E 0% G Zwolniona |
|RAPORTY FISKALNE DOBOWE 9/1830||ZEROWANIA PAMIĘCI OPERACYJNEJ 0/200|
|ZDARZENIA 17/25260||WALUTA EWIDENCYJNA PLN 0/10|
|PRÓBY PRZEKAZU DANYCH 1|| N I E F I S K A L N Y |
|#11 Wojtek 2018-08-23 12:09||1B32F54FBF435F68DEE768522488A3E16A6B03B1|
| ZBF 1801007587 |

## [hardwarecfgrep] Raport konfiguracji
Identyfikator polecenia:
hardwarecfgrep
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]hardwarecfgrep[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:675|
| N I E F I S K A L N Y |
| RAPORT KONFIGURACJI |
| Wyświetlacz operatora / klienta |
|Typ wyświetlacza Wbudowany LCD 4x20|
|Jasność 8|
|Podświetlenie Zawsze|
|Kontrast 8|
|- - - - - - - - - - - - - - - - - - - - |
| Wydruk |
|Jakość wydruku 2|
|Oszczędność papieru TAK|
|Raportów dobowych TAK|
|Dokumentów niefiskalnych TAK|
|Dokumentów specjalnych TAK|
|Kodu podpisu cyfrowego NIE|
|Tryb ekonomiczny TAK|
|Papier eko NIE|
|Opcja wydruku 57mm, 40 znaków|
|- - - - - - - - - - - - - - - - - - - - |
| Szuflada |
|Impuls szuflady 5|
|Napięcie szuflady 12V|
|Kontrola otwarcia szuflady NIE|
|Kontrola stanu klucza szuflady NIE|
|- - - - - - - - - - - - - - - - - - - - |
| Czasy komunikatów |
|Informacyjne 9999 sek.|
|Pytania 9999 sek.|
|Błędy 9999 sek.|
|Serwisowe 30 sek.|
|Wieloekranowe 3 sek.|
|- - - - - - - - - - - - - - - - - - - - |
| Funkcje |
|Dźwięki klawiszy TAK|
|Konfiguracja noża Standardowy|
|Sygnalizacja braku zasilania 10 sek.|
|Czas wyłączenia |
| Z zasilaczem BRAK|
| Bez zasilacza 10 min.|
|Blokada klawiatury Wyłączona|
|Obcinacz Obc. częściowe|
|Typ zasilacza Typ B|
|Typ mechanizmu Standard|
|Drukuj napisy ORYGINAŁ / KOPIA TAK|
|Grafika na wydrukach archiwalnych NIE|
|Rozliczanie rabatu procentowego |
| Od kwoty po rabacie|
|Drukowanie raportu dobowego | wyst.w
| Protokół i menu| Thermal
|Optymalizacja brutto/PTU NIE|- HX
|Separatory na paragonach TAK|- wyst.w
|Znak ilości na paragonach ' x'| Pospay,
|Fiskalny licznik paragonów DOBOWY| Temo,
|- - - - - - - - - - - - - - - - - - - - | Trio,
|#11 Wojtek 2018-08-23 12:16| Vero,
|01C2979DF94BF06372561B8D00E5EA7C5CAB5558| Evo
| ZBF 1801007587 |

## [commcfgrep] Raport konfiguracji wejścia/wyjścia
Identyfikator polecenia:
commcfgrep
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]commcfgrep[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE || POSNET POLSKA S.A. |
| ul. Municypalna 33 || 02-281 Warszawa |
| www.posnet.com ||NIP 5222628262 nr:676|
| N I E F I S K A L N Y || RAPORT KONFIGURACJI |
| WEJŚCIA/WYJŚCIA ||Interfejs PC1 |
| Interfejs COM 1|| Protokół POSNET|
| Strona kodowa WINDOWS 1250||Interfejs PC2 |
| Interfejs Brak|| Protokół POSNET|
| Strona kodowa WINDOWS 1250||Konfiguracja TCP/IP |
| Interfejs Ethernet|| Adres IP 192.168.36.165|
| Maska podsieci 255.255.255.0|
| Brama 192.168.36.1|| Preferowany DNS 192.168.10.10|
| Alternatywny DNS 192.168.10.11|| DHCP TAK|
|Porty i urządzenia || COM 1 115200, 8, 1, Brak, XON/XOFF |
| Komputer|| USB |
| Port 2121 Odczyt pam.chron.|| Bluetooth |
| ETHERNET DOSTĘPNY|| MAC CC-CC-CC-CC-CC-CC|
| WIFI DOSTĘPNY|| MAC CC-CC-CC-CC-CC-CD|
```
| USB (NET) DOSTĘPNY|| Sterownik USB Auto|
```
| OBCINACZ PAPIERU DOSTĘPNY|| N I E F I S K A L N Y |
|#11 Wojtek 2018-08-23 12:21||34C31ACC76A51287D8869BBB712BA18894065BFD|
| ZBF 1801007587 |

## [reponline] Raport online
Identyfikator polecenia:
reponline
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]reponline[TAB]#CRC16[ETX]
```
```
Wydruk:| POSNET POLSKA S.A. |
```
| 02-281 Warszawa || www.posnet.com |
|NIP 5222628262 nr:677|| N I E F I S K A L N Y |
| RAPORT ONLINE ||SERWER REPOZYTORIUM |
| https://esb-te.mf.gov.pl:5062/api/Se|| rwerCPD/Command |
| CRK: testowe || WebApi adres: |
| https://test-e-kasy.mf.gov.pl:443 || EventHub Sas Token: |
| SharedAccessSignature sr=https%3a%2f|| %2fcrr-eh-ne-tst.servicebus.windows.|
| fdilgi%5oubh7o-oiu-ooguoru-5ldfgklld|| gfjsdi4ligjkgbxv-79lxfjklg9ldf-b=785|
| 568&skn=SendPolicy || Data ważności 2021-02-11 12:29|
|- - - - - - - - - - - - - - - - - - - - ||SERWER AKTUALIZACJI |
| https://193.150.2.198/ || Status aktualizacji: |
| Aktualizacja gotowa || 2018-08-20 13:03 |
|- - - - - - - - - - - - - - - - - - - - ||HARMONOGRAM PRZEKAZU DANYCH |
| Kod komendy TFD.|| ZBF1801007587.2018-08-20T11:05:29.582Z|
| Wysyłka EventHub 100|| Sprawdzanie WebApi 100|
| Szczegółowa wysyłka danych: || Paragon NIE|
| Paragon Anulowany TAK|| Faktura NIE|
| Faktura Anulowana TAK|| Raport Dobowy TAK|
| Wydruk Niefiskalny TAK|| Zdarzenie NIE|
| Raport Fiskalizacji TAK||- - - - - - - - - - - - - - - - - - - - |
|KODY QR NA PARAGONACH || Kwota Wyłączone|
|- - - - - - - - - - - - - - - - - - - - || CERTYFIKATY |
|URZĄDZENIA: || Odcisk SHA1: F2:B0:8B:4D:3D:6C:69:|
| 12:9F:B3:B3:5E:F3:B3:9E:E4:4A:EB:AE:13|
| Numer seryjny: 07:EE|| Data ważności: 2019-08-20|
|JSON: || Odcisk SHA1: FC:D0:8B:99:3D:6C:60:|
| 09:EA:B3:B3:5E:F3:B3:9E:E4:4A:EB:51:6C|| Numer seryjny: 07:EF|
| Data ważności: 2019-08-20||CA PRODUCENTA : |
| Odcisk SHA1: 49:77:8B:99:3D:6C:38:|| 51:CC:B3:B3:5E:F3:B3:9E:E4:4A:EB:51:F3|
| Numer seryjny: 45|| Data ważności: 2028-05-12|
|AZURE: || Odcisk SHA1: 11:D3:A1:30:0C:0D:8B:|
| D4:15:7E:CF:90:C6:49:07:01:C0:60:00:0D|| Numer seryjny: 3A:00:00:00:0D:8B:|
| D4:15:7E:CF:90:C6:49:00:01:00:00:00:0D|| Data ważności: 2092-07-10|
```
|CPD (TLS): || Odcisk SHA1: 23:63:A1:37:9C:01:8B:|
```
| 64:65:1E:7F:50:C6:49:47:01:C0:64:00:0D|| Numer seryjny: 3A:00:00:00:0E:A0:|
| E7:CE:4E:E6:CE:F8:9F:00:01:00:00:00:0E|| Data ważności: 2092-07-10|
```
|CPD (JSON): || Odcisk SHA1: E4:C2:A1:30:0C:0D:33:|
```
| F0:35:7E:CF:90:C6:49:07:01:C0:60:43:0D|| Numer seryjny: 3A:00:00:00:08:E6:|
| 8F:55:81:5D:4E:A6:3A:00:01:00:00:00:08|| Data ważności: 2092-07-10|
|CA CPD: || Odcisk SHA1: 73:D5:A1:34:0C:0D:3B:|
| 4E:15:7E:CF:90:C6:49:07:01:C0:12:00:51|| Numer seryjny: 5B:00:00:00:06:27:|
| D0:E9:08:13:A8:EA:73:00:00:00:00:00:06|| Data ważności: 2092-07-10|
|CA AZURE: || Odcisk SHA1: 00:B3:A1:30:0C:0D:BB:|
| 78:15:7E:CF:90:C6:49:07:01:C0:60:00:CC|| Numer seryjny: 2D:00:02:21:43:05:|
| 4C:64:23:8C:AD:12:60:00:00:00:02:21:43|| Data ważności: 2020-02-22|
| Numer seryjny: 7B:00:00:DF:98:78:|| E0:17:04:D2:E2:74:67:00:00:00:00:DF:98|
| Data ważności: 2020-02-22||#11 Wojtek 2018-08-23 12:33|
|24ACEFE96FF10B01F603266B3C3A1B58562636D6|| ZBF 1801007587 |

## [eventsrepbynumbers] Raport zdarzeń wg numerów
Identyfikator polecenia:
eventsrepbynumbers
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer początkowy TAK Num.
tn Numer końcowy TAK Num.
ty Typ zdarzenia 0 – wszystkie
1 – fiskalizacja
2 – zerowanie RAM
3 – zmiana stawek VAT
4 – przejście w tryb „Tylko do odczy-
tu”
5 – zmiana waluty ewidencyjnej
6 – zmiana konfiguracji przekazu da-
nych
7 – zmiana adresu punktu sprzedaży
8 – aktualizacja programu pracy
9 – nieudana aktualizacja programu
10 – wejście w tryb serwisowych
11 – wymiana pamięci chronionej
12 – kasowanie algorytmu weryfiku-
jącego
13 – zmiana źródła aktualizacji pro-
gramu pracy kasy
14 – zmiana daty i czasu
15 – wymiana klucza publicznego ka-
sy
16 – wykonanie przeglądu technicz-
nego
17 – błąd weryfikacji pamięci chro-
nionej
18 – awaria zasilania
19 – utrata ciągłości numerów doku-
mentów
20 – błąd weryfikacji danych
21 – zapełnienie pamięci chronionej
22 – zapełnienie pamięci fiskalnej
23 – odłączenie mechanizmu drukują-
cego
24 – sytuacje awaryjne
25 – brak przekazu klucza publiczne-
go
su Czy ma być drukowany tylko ra-
port podsumowujący?
NIE BOOL Domyślnie False – pełny raport
Odpowiedź urządzenia:

standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eventsrepbynumbers[TAB]fn5[TAB]ty0[TAB]tn34[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 |
| RAPORT FISKALNY ZDARZEŃ wg RFD |
| ŁĄCZNY |
|OD 2018-08-20 15:02 DO 2018-08-20 15:24|
|OD RFD 5 DO RFD 6|
|- - - - - - - - - - - - - - - - - - - - |
| PODSUMOWANIE ILOŚCI ZDARZEŃ |
|FISKALIZACJA 0|
|TRYB TYLKO DO ODCZYTU 0|
|TRYB SERWISOWY WŁĄCZ./WYŁĄCZ. 0|
|PRZEGLĄD TECHNICZNY 0|
|KASOWANIE ALGORYTMU WERYFIKUJĄCEGO 0|
|ZMIANA DATY I CZASU 0|
|ZMIANA STAWEK PTU 0|
|ZMIANA WALUTY EWIDENCYJNEJ 0|
|WYMIANA PAMIĘCI CHRONIONEJ 0|
|BŁĄD WERYFIKACJI PAM. CHRONIONEJ 0|
|ZEROWANIE PAMIĘCI OPERACYJNEJ 0|
|ŹRÓDŁO AKTUALIZACJI PROGRAMU PRACY 0|
|AKTUALIZACJA PROGRAMU PRACY 0|
|BŁĄD AKTUALIZACJI PROGRAMU PRACY 0|
|WYMIANA KLUCZA PUBLICZNEGO 0|
|KONFIGURACJA PRZEKAZU DANYCH 0|
|AWARIA ZASILANIA 0|
|UTRATA CIĄGŁOŚCI NR DOKUMENTÓW 0|
|ZMIANA ADRESU PUNKTU SPRZEDAŻY 0|
|BLOKADY SPRZEDAŻY |
| BŁĄD WERYFIKACJI DANYCH 0|
| ZAPEŁNIENIE PAM. CHRONIONEJ 0|
| ZAPEŁNIENIE PAM. FISKALNEJ 0|
| ODŁĄCZENIE MECH. DRUKUJĄCEGO 0|
| ODŁĄCZENIE WYŚWIET. NABYWCY 0|
| BRAK PRZEKAZU KLUCZA PUBLICZNEGO 0|
|- - - - - - - - - - - - - - - - - - - - |
|#11 Wojtek 2018-08-23 12:45|
```
| {PL} ZBF 1801007587 |
```

## [eventsrepbydates] Raport zdarzeń wg dat
Identyfikator polecenia:
eventsrepbydates
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fd Data początkowa TAK Num.
td Data końcowa TAK Num.
ty Typ zdarzenia TAK Num. 0 – wszystkie
1 – fiskalizacja
2 – zerowanie RAM
3 – zmiana stawek VAT
4 – przejście w tryb „Tylko do odczy-
tu”
5 – zmiana waluty ewidencyjnej
6 – zmiana konfiguracji przekazu da-
nych
7 – zmiana adresu punktu sprzedaży
8 – aktualizacja programu pracy
9 – nieudana aktualizacja programu
10 – wejście w tryb serwisowych
11 – wymiana pamięci chronionej
12 – kasowanie algorytmu weryfiku-
jącego
13 – zmiana źródła aktualizacji pro-
gramu pracy kasy
14 – zmiana daty i czasu
15 – wymiana klucza publicznego ka-
sy
16 – wykonanie przeglądu technicz-
nego
17 – błąd weryfikacji pamięci chro-
nionej
18 – awaria zasilania
19 – utrata ciągłości numerów doku-
mentów
20 – błąd weryfikacji danych
21 – zapełnienie pamięci chronionej
22 – zapełnienie pamięci fiskalnej
23 – odłączenie mechanizmu drukują-
cego
24 – sytuacje awaryjne
25 – brak przekazu klucza publiczne-
go
su Czy ma być drukowany tylko ra-
port podsumowujący?
NIE BOOL Domyślnie False – pełny raport

Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
[STX]eventsrepbydates[TAB]fd2018-08-09[TAB]td2018-08-10[TAB]ty0[TAB]
su0[TAB]#CRC16[ETX]
```
Wydruk:
```
Przykład wydruku z wykorzystaniem rozkazu eventsrepbydates jak w rozkazie eventsrepbynum-
bers.

## [eparagonrep] Raport konfiguracji eDokumentu
Identyfikator polecenia:
eparagonrep
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Przez eDokument rozumie się eParagon lub eFakturę.
Przykład:
```plaintext
[STX]eparagonrep[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 |
| NIEFISKALNY |
| RAPORT KONFIGURACJI EPARAGONU |
|Status Nieaktywny|
| KONFIGURACJA DOMYŚLNEGO SERWERA |
|Adres: Brak |
|Konfiguracja: pC,iG,dG,N,S,D,E,T=15,W=0|
|- - - - - - - - - - - - - - - - - - - - |
| HARMONOGRAM EPARAGONU |
|Nowe [s]: 20,25,30|
|Zaległe [s]: 3600|
|Czas ważności [s]: 604800|
|- - - - - - - - - - - - - - - - - - - - |
| BUFOR EPARAGONU |
|BUFOR EPARAGONU 0/500|
|NADPISYWANIE BUFORA NIE|
| NIEFISKALNY |
|#11 Wojtek 2020-08-23 12:45|
|978A656D67978A656D67978A656D67978A656D67|
| ZBF 1801007587 |

## [endrepro] Raport rozliczeniowy
Identyfikator polecenia:
endrepro
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Aktualna data TAK Data
su Typ raportu NIE BOOL False – pełny raport
True – raport podsumowujący
```
(domyślnie)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wykonanie raportu rozliczeniowego powoduje przejście drukarki w stan Tylko Do Odczytu.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]endrepro[TAB]da2021-03-15[TAB]su0[TAB]#CRC16[ETX]
```

Formatki – wydruki niefiskalne
## [formstart] Rozpoczęcie formatki
Identyfikator polecenia:
formstart
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num. Zakres: 2-43, 200, 201
fh Numer nagłówka formatki NIE Num. Domyślnie fh=0
al Dodatkowy opis nagłówka nr 84
w super-formatce oraz nagłówka
0 w formatce szerokiej.
NIE Alfanum. Maksymalna długość 56 zna-
ków. W super-formatce opis
jest ucinany po 40 znaku. Para-
metr ignorowany dla innych
numerów nagłówka i formatek
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]formstart[TAB]fn2[TAB]fh1[TAB]#CRC16[ETX]
```

## [formisstarted] Status rozpoczęcie formatki
Identyfikator polecenia:
formisstarted
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
is Status rozpoczęcia formatki TAK BOOL True – formatka rozpoczęta
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]formisstarted[TAB]#CRC16[ETX]
```

## [formline] Linia formatki
Identyfikator polecenia:
formline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
s1 Parametr linii formatki NIE Alfanum. Parametry występujące w jed-
nej linii formatki są przesyłane
jako parametr s1 i rozdzielone
```
są jedynie znakiem LF (0Ah).
```
Parametr musi występować je-
żeli takie są wymagania linii
formatki . Maksymalne długo-
ści parametrów dla każdej z
formatek, określone są w roz-
dziale „Rodzaje formatek” -
liczba przesłanych znaków nie
powinna przekraczać liczby
znaków '#' w rozpatrywanym
numerze formatki.
Parametr linii może być typem
```
alfanumerycznym (oznaczny
```
```
skrótem alfanum), lub alfanu-
```
merycznym wyrównanym do
```
prawej strony (oznaczony
```
```
skrótem alfanum-p). Możliwe
```
do wydrukowania formatki
opisuje rozdział Rodzaje for-
matek.
fn Numer formatki TAK Num.
fl Numer linii formatki TAK Num.
sw Podwójna szerokość znaku NIE BOOL True – znak poszerzony
sh Podwójna wysokość znaku NIE BOOL True – znak podwyższony
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.

2. Jeżeli po zmianie czcionki na szeroką, drukowany tekst formatki nie mieści się w linii, to
```
jest on ucinany w miejscu przekroczenia szerokości druku (20znaków), przenoszony do na-
```
stępnego wiersza i jest dosuwany do prawej strony. Jeżeli po podziale linia zawiera same
spacje to nie jest drukowana.
Przykład:
```plaintext
[STX]formline[TAB]s11234[LF]BBBBB[TAB]fn3[TAB]fl0[TAB]#CRC16[ETX]
```
```
Wydruk:
```
przykładowa formatka nr 3
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:738|
| N I E F I S K A L N Y |
| RAPORT FUNKCJI OPERATORA |
|Funkcja 1234 linia012345678linia0123456|
| |
|- - - - - - - - - - - - - - - - - - - - |
|#11 Wojtek 2018-08-23 13:15|
|89FFE0FE2EE0C28ACD9C0E1C29BD33B66E1C3264|
| ZBF 1801007587 |

## [formformattedline] Linia formatki z dowolnym formatowaniem
Identyfikator polecenia:
formformattedline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
s1 Zawartość linii formatki z for-
matowaniem
TAK Alfanum. W linii mogą wystąpić znaki
formatujące opisane w polece-
niach hdrset i ftrinfoset za wy-
```
jątkiem podziału linii (znak
```
```
LF(0Ah)).
```
Maksymalna długość parame-
tru to 96 znaków w tym 56
znaków drukowalnych.
fn Numer formatki TAK Num. Patrz uwagi.
ma Maska NIE Alfanum. Rozmiar i budowa parametru
ma powinna być dopasowana
do budowy parametru s1.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie dostępne tylko w super-formatce (200) i formatce szerokiej (201)
2. Działanie maski: w pamięci chronionej zostanie zapisany znak '*' zamiast przesłanej warto-
ści w parametrze s1, jeśli na pozycji tego znaku w parametrze ma występuje znak '*' lub '#'.
Przykład: s1='123456789', ma=' **** ', w pamięci chronionej zostanie zapisa-
```
ne: '123****89'. Jeśli w rozkazie wykorzystywane jest maskowanie znaków, przynaj-
```
mniej trzy znaki z linii powinny być jawne w pamięci chronionej.
3. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]formformattedline[TAB]s1&c&u&iTreść&i&u[LF]fn200[TAB]#CRC16[ETX]
```

## [formbarcode] Numer systemowy w formatce
Identyfikator polecenia:
formbarcode
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num.
bc Numer mający być wydrukowa-
ny w postaci kodu kreskowego
TAK Alfanum.
```
bt Rodzaj drukowanego kodu NIE Num. 0 – EAN 128 (domyślnie)
```
1 – EAN 13
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Dla bt=1, można przesłać kod o długości 12 znaków – suma kontrolna zostanie wyliczona
przez drukarkę.
Przykład:
```plaintext
[STX]formbarcode[TAB]fn2[TAB]bc987098912[TAB]#CRC16[ETX]
```

## [formbarcode2d] dwuwymiarowy kod kreskowy w formatce
Identyfikator polecenia:
formbarcode2d
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Kod do wydruku powinien być przygotowany wcześniej (polecenia : azteccode, dmcode,
```
pdf417code, qrcode)
```
3. Wydruk kodu powoduje jego unieważnienie.
Przykład:
```plaintext
[STX]formbarcode2d[TAB]fn2[TAB]#CRC16[ETX]
```

## [formcmd] Komenda w formatce
Identyfikator polecenia:
formcmd
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num.
cm Numer komendy TAK Num. 0 – pusta linia
1 – separator
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]formcmd[TAB]fn2[TAB]cm1[TAB]#CRC16[ETX]
```

## [formimage] Grafika w formatce
Identyfikator polecenia:
formimage
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num.
no Numer zaprogramowanej grafiki TAK Num. Zakres: 1 – 500
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]formimage[TAB]fn2[TAB]no1[TAB]#CRC16[ETX]
```

## [formtinyline] Linia formatki z małą czcionką
Identyfikator polecenia:
formtinyline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num.
s1 Zawartość linii formatki TAK Alfanum. Maksymalna długość parame-
tru to 80 znaków dla papieru
80 mm i 51 znaków dla papie-
ru 57mm.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda dostępna w super-formatce (formatka 200) i formatce szerokiej (formatka 201)
2. W drukarce Temo, Trio, Vero, Evo, Fawag Box maksymalna długość parametru s1 to 51
znaków.
3. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]formtinyline[TAB]fn200[TAB]s1Tekst[TAB]#CRC16[ETX]
```

## [formend] Zakończenie formatki
Identyfikator polecenia:
formend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fn Numer formatki TAK Num.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]formend[TAB]fn2[TAB]#CRC16[ETX]
```

Rodzaje formatek
2 – Transakcje odłożone
TRANSAKCJE ODŁOŻONE 0 - nagłówek
POTWIERDZENIE DOKONANIA TRANSAKCJI 1 - nagłówek
```
Kasa: ################################## 0 alfanum-p
```
Numer transakcji: ###################### 1 alfanum-p
Numer kasjera: ######################### 2 alfanum-p
```
Uwagi:
```
1. Linie można przestawiać i powielać
3 – Funkcje operatora
RAPORT FUNKCJI OPERATORA 0 - nagłówek
Funkcja #### ########################## 0 alfanum-p, alfanum.
```
Uwagi:
```
1. Linie można przestawiać i powielać
4 – Raport kasjera
```
RAPORT KASJERA X 0 – nagłówek, (podwójna szerokość)
```
```
RAPORT KASJERA Z 1 – nagłówek, (podwójna szerokość)
```
```
RAPORT KASY X 2 – nagłówek, (podwójna szerokość)
```
```
RAPORT KASY Z 3 – nagłówek, (podwójna szerokość)
```
```
OFFLINE KASJERA 4 – nagłówek, (podwójna szerokość)
```
```
ONLINE KASJERA 5 – nagłówek, (podwójna szerokość)
```
```
LICZENIE KASY 6 – nagłówek, (podwójna szerokość)
```
```
WYPŁATA KASJERA 7 – nagłówek, (podwójna szerokość)
```
```
WPŁATA KASJERA 8 – nagłówek, (podwójna szerokość)
```
```
ROZLICZENIE KASJERA 9 – nagłówek, (podwójna szerokość)
```
LICZBA RESETÓW: ### 0 alfanum-p
NUMER KASY # ########################### 1 alfanum-p, alfanum.
```
SUMY ŁĄCZNE 2 (podwójna szerokość)
```
SUMA BIEŻĄCA DODATNIA ############### 3 alfanum-p
SUMA BIEŻĄCA UJEMNA ############### 4 alfanum-p
SUMA POPRZEDNIA DODATNIA ############### 5 alfanum-p
SUMA POPRZEDNIA UJEMNA ############### 6 alfanum-p
------------ 7 iinia bez parametru
SUMA ŁĄCZNA DODATNIA ############### 8 alfanum-p
SUMA ŁĄCZNA UJEMNA ############### 9 alfanum-p
```
SUMY SPRZEDAŻY 10 (podwójna szerokość)
```
```
TOWARY: 11 linia bez parametru
```
##### POZYCJE DODATNIE ############### 12 alfanum-p, alfanum-p
##### USŁUGI, INNE ############### 13 alfanum-p, alfanum-p
##### POZYCJE UJEMNE ############### 14 alfanum-p, alfanum-p
##### DODATNIE KOREKTY ############### 15 alfanum-p, alfanum-p
##### UJEMNE KOREKTY ############### 16 alfanum-p, alfanum-p
##### KUPON SKLEPOWY ############### 17 alfanum-p, alfanum-p
PODSUMA TOWARÓW ############### 18 alfanum-p,
PODSUMA PODATKU ############### 19 alfanum-p
RABAT / DOPŁATA 20 linia bez parametru
RABAT HEJ HEM ############### 21 alfanum-p
RABAT / DOPŁATA 2 ############### 22 alfanum-p
RABAT / DOPŁATA 3 ############### 23 alfanum-p
RABAT DLA PRACOWNIKA ############### 24 alfanum-p
PODSUMA RABATU/DOPŁATY ############### 25 alfanum-p
------------ 26 linia bez parametru
SPRZEDAŻ NETTO ŁĄCZNIE ############### 27 alfanum-p
```
SUMY ŚROD. PŁATNOŚCI 28 (podwójna szerokość)
```
ŚRODKI PŁATNOŚCI 29 linia bez parametru
ŚRODEK PŁ.##: ### ############ ####### 30 alfanum-p, alfanum, alfanum, alfanum-p
##### KWOTA ############### 31 alfanum-p, alfanum-p
##### ZEBRANE ############### 32 alfanum-p, alfanum-p
##### W OBIEGU ############### 33 alfanum-p, alfanum-p

##### START W OB. ############### 34 alfanum-p, alfanum-p
##### TYP PŁ. NR 2 ############### 35 alfanum-p, alfanum-p
PODSUMA ŚR. PŁATNOŚCI ############### 36 alfanum-p
KOREKTA ŚRODKÓW PŁATNOŚCI 37 linia bez parametru
##### DOD. FUNKCJI BANK. ############### 38 alfanum-p, alfanum-p
##### POMN. FUNKCJI BANK.############### 39 alfanum-p, alfanum-p
##### USTAW. ZAOKRĄGLEŃ ############### 40 alfanum-p, alfanum-p
##### ZAPAM. CZ. PŁATN. ############### 41 alfanum-p, alfanum-p
##### PRZYW. CZ. PŁATN. ############### 42 alfanum-p, alfanum-p
##### OPŁATA PŁATNOŚCI ############### 43 alfanum-p, alfanum-p
PODSUMA KOREKTY PŁATN. ############### 44 alfanum-p
------------- 45 linia bez parametru
ŚRODKI PŁATNICZE ŁĄCZNIE ############### 46 alfanum-p
```
INNE SUMY 47 (podwójna szerokość)
```
##### OBNIŻKI DODATNIE ############### 48 alfanum-p, alfanum-p
##### OBNIŻKI UJEMNE ############### 49 alfanum-p, alfanum-p
##### KOREKCJE BŁĘDÓW ############### 50 alfanum-p, alfanum-p
##### SUMA ZWROTÓW ############### 51 alfanum-p, alfanum-p
##### ZWROTY KOSZTÓW ############### 52 alfanum-p, alfanum-p
##### ŚRODKI UNIEWAŻN. ############### 53 alfanum-p, alfanum-p
##### POZYCJE SPRZEDAŻY ############### 54 alfanum-p, alfanum-p
##### RABAT ZBIORCZY ############### 55 alfanum-p, alfanum-p
##### SPRZEDAŻ ANULOWANA ############### 56 alfanum-p, alfanum-p
##### SPRZEDAŻ ZAPAMIĘT. ############### 57 alfanum-p, alfanum-p
##### SPRZEDAŻ UNIEWAŻN. ############### 58 alfanum-p, alfanum-p
##### SPRZEDAŻ PRZYWOŁ. ############### 59 alfanum-p, alfanum-p
##### ZAMIANA ŚR. PŁATN. ############### 60 alfanum-p, alfanum-p
##### BEZ PODATKU ############### 61 alfanum-p, alfanum-p
##### KWOTA ZWOLNIONA ############### 62 alfanum-p, alfanum-p
##### ZWROT NADPŁAC. PTU ############### 63 alfanum-p, alfanum-p
##### ZNACZKI WYEMITOW. ############### 64 alfanum-p, alfanum-p
##### POZYCJE Z KLAWIAT. ######% 65 alfanum-p, alfanum-p
##### POZYCJE SKANOWANE ######% 66 alfanum-p, alfanum-p
##### POZYCJE WAŻONE ######% 67 alfanum-p, alfanum-p
POZYCJE WAŻONE ŁĄCZNIE ############### 68 alfanum-p
##### TRANSAKCJE DODATNIE 69 alfanum-p, alfanum-p
##### ZWROT NADPŁACONEJ GOTÓWKI 70 alfanum-p, alfanum-p
##### INNE TRANSAKCJE 71 alfanum-p, alfanum-p
##### OTWARCIE SZUFLADY 72 alfanum-p, alfanum-p
##### SUMA BIEŻĄCA 73 alfanum-p, alfanum-p
##### LICZBA KLIENTÓW 74 alfanum-p, alfanum-p
##:## CZAS PRACY KASJERA 75 alfanum-p, alfanum-p
##:## CZASOWE WYŁĄCZENIE KASY 76 alfanum-p, alfanum-p
##:## CZAS WPROWADZANIA TOWARÓW 77 alfanum-p, alfanum-p
##:## CZAS PŁACENIA 78 alfanum-p, alfanum-p
##:## CZAS OTWARCIA SZUFLADY 79 alfanum-p, alfanum-p
################ ####################### 80 alfanumeryczny, alfanumeryczny
############################# ########## 81 alfanumeryczny, alfanumeryczny
*** RAZEM WPŁATA ############# 82 alfanumeryczny
*** RAZEM WYPŁATA ############# 83 alfanumeryczny
*** RAZEM POLICZONE ############# 84 alfanumeryczny
PODPIS KASJERA 85 linia bez parametru
- - - - - - - - - - - - - - - - - 86 linia bez parametru
```
WALUTA: ### 87 alfanumeryczny
```
####### x ###### = ############ ### 88 alfanumeryczne
RAZEM ############### ### 89 alfanumeryczne
```
Uwagi:
```
1. Linie można przestawiać i powielać
5 – Raport środków płatności
RAPORT ŚRODKÓW PŁATNOŚCI 0 - nagłówek
KASJER ######## 0 alfanum-p
ŚRODEK PŁ.##: ### ############ ####### 1 alfanum-p, alfanum, alfanum,alfanum-p
##### KWOTA ############### 2 alfanum-p, alfanum-p
##### ZEBRANE ############### 3 alfanum-p, alfanum-p
##### W OBIEGU ############### 4 alfanum-p, alfanum-p
##### START W OB. ############### 5 alfanum-p, alfanum-p
PODSUMA ŚR. PŁATNOŚCI ############### 6 alfanum-p
```
Uwagi:
```
1. Linie można przestawiać i powielać

6 – Sprzedaż zarejestrowana w kasie
SPRZEDAŻ ZAREJ. W KASIE 0 - nagłówek
NUMER KASY # ### 0 alfanum-p, alfanumeryczny
PODSUMA SPRZEDAŻY ################ 1 alfanum-p
PODSUMA RACH. SPRZEDAŻY ################ 2 alfanum-p
PODSUMA RABATU / DOPŁ. ################ 3 alfanum-p
---------------- 4 linia bez parametru
SPRZEDAŻ ŁĄCZNIE ################ 5 alfanum-p
```
Uwagi:
```
1. Linie można przestawiać i powielać
7 – Pokwitowanie
POKWITOWANIE 0 - nagłówek
```
ZWROT: ################################# 0 alfanum-p
```
ŚRODEK PŁ.: ############################ 1 alfanumeryczny
```
KWOTA: ################################# 2 alfanum-p
```
```
KONTO: ################################# 3 alfanum-p
```
```
PODPIS: .............................. 4
```
```
Uwagi:
```
1. Linie można przestawiać i powielać
8 – Potwierdzenie wpłaty
POTWIERDZENIE WPŁATY 0 - nagłówek
DO DOKUM.SPRZED.: ###################### 0 alfanum-p
ŚRODEK PŁ.: ############################ 1 alfanumeryczny
```
KONTO: ################################# 2 alfanum-p
```
```
KWOTA: ################################# 3 alfanum-p
```
WPŁATA: ###################### 4 alfanum-p
```
RESZTA: ############################ 5 alfanum-p
```
```
Uwagi:
```
1. Linie można przestawiać i powielać
9 – Bon upominkowy
```
BON UPOMINKOWY 0 -nagłówek, (podwójna szerokość)
```
```
*** ZREALIZOWANO *** 0 (podwójna szerokość)
```
```
Kwota: ################################# 1
```
```
Kasjer: ################################ 2
```
```
Data: ########## Godz.: ################ 3
```
```
Sklep: ################################# 3
```
```
Uwagi:
```
1. W linii 2 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
2. W linii 3 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
3. Pozostałe parametry są alfanum. wyrównane do prawej.
4. Linia 3 skutkuje dwoma wierszami wydruku.
10 – Nota kredytowa
```
NOTA KREDYTOWA 0 -nagłówek, (podwójna szerokość)
```
```
*ZREALIZOWANO* 0 (podwójna szerokość)
```
```
Kwota: ################################# 1
```
```
Kasjer: ################################ 2
```
```
Data: ########## Godz.: ################ 3
```
```
Sklep: ################################# 3
```
```
Uwagi:
```
1. W linii 2 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
2. W linii 3 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
3. Pozostałe parametry są alfanum. wyrównane do prawej.

4. Linia 3 skutkuje dwoma wierszami wydruku.
11 – Nota kredytowa
```
NOTA KREDYTOWA 0 -nagłówek, (podwójna szerokość)
```
```
Kwota: ################################# 0
```
Słownie: ############################### 1
Zwrot nr: ############################## 2
```
Kasjer: ################################ 3
```
```
Data: ########## Godz.: ################ 4
```
```
Sklep: ################################# 4
```
```
Uwagi:
```
1. W linii 1 parametr alfabetyczny
2. W linii 3 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
3. W linii 4 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
4. Pozostałe parametry są alfanum. wyrównane do prawej.
5. Linia 4 skutkuje dwoma wierszami wydruku.
12 – Kupon rabatowy
```
KUPON RABATOWY 0 -nagłówek, (podwójna szerokość)
```
```
*** ZREALIZOWANO *** 0 (podwójna szerokość)
```
```
Kwota: ################################# 1
```
```
Kasjer: ################################ 2
```
```
Data: ########## Godz.: ################ 3
```
```
Sklep: ################################# 3
```
```
Uwagi:
```
1. W linii 2 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
2. W linii 3 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
3. Pozostałe parametry są alfanum. wyrównane do prawej.
4. Linia 3 skutkuje dwoma wierszami wydruku.
13 – Płatność za pobraniem
PŁATNOŚĆ 'ZA POBRANIEM' 0 -nagłówek
*** SPRZEDAŻ ZAREJESTROWANA *** 0
Nr identyfikacyjny: #################### 1
```
Kwota: ################################# 2
```
```
Kasjer: ################################ 3
```
```
Data: ########## Godz.: ################ 4
```
```
Sklep: ################################# 4
```
```
Uwaga:
```
1. W linii 3 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
2. W linii 4 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
3. Pozostałe parametry są alfanum. wyrównane do prawej.
4. Linia 4 skutkuje dwoma wierszami wydruku.
14 – Przelew bankowy
```
PRZELEW BANKOWY 0 -nagłowek, (podwójna szerokość)
```
```
*** ZREALIZOWANO *** 0 (podwójna szerokość)
```
Nr klienta: ############################ 1
```
Kwota: ################################# 2
```
```
Saldo: ################################# 3
```
```
Kasjer: ################################ 4
```
```
Data: ########## Godz.: ################ 5
```
```
Sklep: ################################# 5
```
```
Uwagi:
```
1. W linii 4 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
2. W linii 5 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
3. Pozostałe parametry są alfanum. wyrównane do prawej.
4. Linia 5 skutkuje dwoma wierszami wydruku.

15 – Potwierdzenie sprzedaży bonu upominkowego
Potw. sprzedaży bonu upominkowego 0 -nagłówek
Wartość bonu: ########################## 0
```
Nazwa: ################################# 1
```
```
Kasjer: ################################ 2
```
```
Data: ########## Godz.: ################ 3
```
```
Sklep: ################################# 3
```
```
Uwagi:
```
1. W linii 1 parametr alfabetyczny
2. W linii 2 nazwa kasjera z drukarki ("KIEROWNIK" lub zalogowany kasjer).
3. W linii 3 parametr 3 jest alfanumeryczny (numer sklepu lub nazwa).
4. Pozostałe parametry są alfanum. wyrównane do prawej.
5. Linia 3 skutkuje dwoma wierszami wydruku.
16 – Rabat dla pracownika
RABAT DLA PRACOWNIKA 0 – nagłówek
Rabat dla pracownika: ################## 0 alfanum-p
Numer pracownika: ###################### 1 alfanum-p
```
Kwota: ################################# 2 alfanum-p
```
```
PODPIS: .............................. 3 linia bez parametru
```
```
Uwagi:
```
1. Linie można przestawiać i powielać.
17 – Wymiana środków płatności
WYMIANA ŚRODKÓW PŁATNOŚCI 0 - nagłówek
```
Z: ################################## 0 alfanumeryczny
```
```
NA: ################################## 1 alfanumeryczny
```
```
Uwagi:
```
1. Linie można przestawiać i powielać.
18 – Operacje kasowe
OPERACJE KASOWE 0 - nagłówek
OPERACJA ###: ######################### 0 alfanum-p, alfanumeryczny
```
Uwagi:
```
1. Linie można przestawiać i powielać.
19 – Błędy kasy
BŁĘDY KASY 0 - nagłówek
BŁĄD KRYTYCZNY 0
```
Serwis : ########################### 1 alfanumeryczny
```
Urządzenie : ###################### 2 alfanumeryczny
Urządzenie dod. : ##################### 3 alfanumeryczny
```
Funkcja : ######################### 4 alfanumeryczny
```
```
Podfunkcja : ########################### 5 alfanumeryczny
```
Rejestr # : ########################### 6 alfanum-p, alfanumeryczny
Trans # : ########################### 7 alfanum-p, alfanumeryczny
Kod błędu : ########################### 8 alfanumeryczny
```
Uwagi:
```
1. Linie można przestawiać i powielać.
20 – Cennik
CENNIK 0 - nagłówek
ZMIANY CEN 1 - nagłówek

STATYSTYKA SPRZEDAŻY 2 - nagłówek
POTWIERDZENIE DOKONANIA TRANSAKCJI 3 - nagłówek
SKLEP ######################### 0 alfanumeryczny
DATA ######## ######## 1 alfanum-p, alfanum-p
Kod art: ############# Cena: ########,## 2 alfanum-p, alfanum-p, alfanum-p
Kod art: ############# Data: ########### 3 alfanum-p, alfanum-p
```
Cena1: ########,## Cena2: ########,## 4 alfanum-p,alfanum-p,alfanum-p,alfanum-p
```
Ilość: ########### 5 alfanum-p
```
Uwagi:
```
1. Linie można przestawiać i powielać.
21 – Wydanie bonu upominkowego
WYDANIE BONU UPOMINKOWEGO 0 - nagłówek
BON UPOMINKOWY: ################ 0 alfanum-p
NUMER BONU: #################### 1 alfanumeryczny
```
SUMA: ############## 2 alfanum-p
```
ŚRODEK PŁ.: ############################ 3 alfanumeryczny
```
KWOTA: ################################# 4 alfanum-p
```
```
KONTO: ################################# 5 alfanum-p
```
```
RESZTA: ############################ 6 alfanum-p
```
```
Uwagi:
```
1. Linie można przestawiać i powielać.
22 – Potwierdzenie transakcji kartą płatniczą
Potwierdzenie zapłaty kartą 0 - nagłówek
Potwierdzenie zapłaty rachunku 1 - nagłówek
Pokwitowanie 2 - nagłówek
Pokwitowanie transakcji uznania 3 - nagłówek
Potwierdzenie unieważnienia 4 - nagłówek
Potwierdzenie odmowy autoryzacji 5 - nagłówek
Potwierdzenie pre-autoryzacji 6 - nagłówek
Potwierdzenie odmowy 7 - nagłówek
Transaction confirmation 8 - nagłówek
Cancellation confirmation 9 - nagłówek
Pre-authorization confirmation 10 - nagłówek
Declination confirmation 11 - nagłówek
```
Kasa: ### Kasjer: ####### 0 alfanumeryczny, alfanumeryczny
```
Nr dowodu sprzedaży: ############### 1 alfanumeryczny
Nr transakcji: ############### 2 alfanumeryczny
```
TID: ######## UID: ################ 3 alfanumeryczny, alfanumeryczny
```
```
TID: ######## MID: ################ 4 alfanumeryczny, alfanumeryczny
```
Zapłata rachunku nr: ################### 5 alfanumeryczny
```
Dla: ################################### 6 alfanumeryczny
```
Nr klienta: ############################ 7 alfanumeryczny
```
Karta: ################################# 8 alfanumeryczny
```
###################### Ważna do: ##/## 9 wszystkie alfanumeryczne
Sprzedaż: PLN ###################### 10 alfanumeryczny
```
Uznanie: PLN ###################### 11 alfanumeryczny
```
Gotówka: PLN ###################### 12 alfanumeryczny
Słownie: ############################### 13 alfanumeryczny
############################### 14 alfanumeryczny
```
Prowizja: PLN ################## 15 alfanumeryczny
```
Razem do zapłaty: PLN ################## 16 alfanumeryczny
Kod autoryzacji: ################ 17 alfanumeryczny
Liczba punktów za transakcję: ########## 18 alfanumeryczny
Liczba punktów po transakcji: ########## 19 alfanumeryczny
Kwota na karcie: ############### 20 alfanumeryczny
Proszę obciążyć moje konto 21 alfanumeryczny
Proszę uznać moje konto 22 alfanumeryczny
Transakcja unieważniona 23 alfanumeryczny
KOD PIN ZGODNY 24 alfanumeryczny
........................ 25 alfanumeryczny
podpis posiadacza karty 26 alfanumeryczny
podpis kasjera 27 alfanumeryczny
podpis klienta 28 alfanumeryczny
```
ORYGINAŁ 29 alfanumeryczny, (podwójna szerokość)
```
```
KOPIA 30 alfanumeryczny, (podwójna szerokość)
```

```
Sprzedaż: ### ###################### 31 alfanumeryczny, alfanumeryczny, (podwójna wysokość)
```
```
Uznanie: ### ###################### 32 alfanumeryczny, alfanumeryczny, (podwójna wysokość)
```
```
Gotówka: ### ###################### 33 alfanumeryczny, alfanumeryczny, (podwójna wysokość)
```
```
Prowizja: ### ################## 34 alfanumeryczny, alfanumeryczny
```
Razem do zapłaty: ### ################## 35 alfanumeryczny, alfanumeryczny
```
AID: ################################# 36 alfanumeryczny
```
```
TC: ################################### 37 alfanumeryczny
```
```
AAC: ################################### 38 alfanumeryczny
```
```
PSN: ################################### 39 alfanumeryczny
```
```
ATC: ################################### 40 alfanumeryczny
```
```
ARC: ################################### 41 alfanumeryczny
```
```
AAA: ########## TD:############ 42 alfanumeryczny, alfanumeryczny
```
TAC DEFAULT: ########################### 43 alfanumeryczny
TAC DENIAL: ############################ 44 alfanumeryczny
TAC ONLINE: ############################ 45 alfanumeryczny
IAC DEFAULT: ########################### 46 alfanumeryczny
IAC DENIAL: ############################ 47 alfanumeryczny
IAC ONLINE: ############################ 48 alfanumeryczny
Commercial Code ##########: ############ 49 alfanumeryczny, alfanumeryczny
Dodatkowa dana: ######################## 50 alfanumeryczny
Nr dowodu tożsamości:................... 51 linia bez parametru
Centrum Autoryzacji:#################### 52 alfanumeryczny
POTWIERDZENIE ODMOWY AUTORYZACJI 53 linia bez parametru
TRANSAKCJA ODRZUCONA 54 linia bez parametru
Komunikat systemowy: ################### 55 alfanumeryczny
Wpłata: ### ###################### 56 alfanumeryczny, alfanumeryczny
```
Razem: ### ###################### 57 alfanumeryczny, alfanumeryczny
```
```
Zwrot: ### ###################### 58 alfanumeryczny, alfanumeryczny
```
```
Cashback: ### ###################### 59 alfanumeryczny, alfanumeryczny
```
```
Cash: ### ###################### 60 alfanumeryczny, alfanumeryczny
```
```
SALE: ### ###################### 61 alfanumeryczny, alfanumeryczny
```
```
REFUND: ### ###################### 62 alfanumeryczny, alfanumeryczny
```
FX RATE: ############################### 63 alfanumeryczny
TRANSACTION CURRENCY: ################## 64 alfanumeryczny
DCC service provided by: ############### 65 alfanumeryczny
REJECTION RECEIPT TRANSACTION WAS 66 linia bez parametru
REJECTED SYSTEM MESSAGE: ############### 67 alfanumeryczny
CANCELLATION RECEIPT TRANSACTION WAS 68 linia bez parametru
CANCELED 69 linia bez parametru
PIN VERIFIED 70 linia bez parametru
SIGNATURE 71 linia bez parametru
Pre-autoryz: ### ###################### 72 alfanumeryczny, alfanumeryczny
Acquirer/Processor: #################### 73 alfanumeryczny
Ecr no: ### Cashier: ####### 74 alfanumeryczny, alfanumeryczny
Receipt number: ############### 75 alfanumeryczny
Transaction number: ############### 76 alfanumeryczny
Invoice number: ################### 77 alfanumeryczny
```
For: ################################### 78 alfanumeryczny
```
Client number: ######################### 79 alfanumeryczny
```
Card: ################################## 80 alfanumeryczny
```
##################### Valid date: ##/## 81 wszystkie alfanumeryczne
Pre-auth: ### ###################### 82 alfanumeryczny, alfanumeryczny
```
Sale: ### ###################### 83 alfanumeryczny, alfanumeryczny
```
```
Refund: ### ###################### 84 alfanumeryczny, alfanumeryczny
```
In words: ############################## 85 alfanumeryczny
```
Statement: ############################# 86 alfanumeryczny
```
```
Commission: ### ################## 87 alfanumeryczny, alfanumeryczny
```
Total amount: ### ################## 88 alfanumeryczny, alfanumeryczny
Authorization code: ############ 89 alfanumeryczny
Points for transaction: ########## 90 alfanumeryczny
Points after transaction: ########## 91 alfanumeryczny
Amount on the card: ############### 92 alfanumeryczny
System message: ######################## 93 alfanumeryczny
Commercial Code ######################## 94 alfanumeryczny
Extra data: ############################ 95 alfanumeryczny
Document ID: ........................... 96 alfanumeryczny
Numer płatności: 97 alfanum-p
######################################## 97 alfanum-p
Numer kontrolny: 98 alfanum-p
######################################## 98 alfanum-p
Kod kreskowy: 99 alfanum-p
######################################## 99 alfanum-p
Wartość: ### ################## 100 alfanumeryczne
Opłata: ### ################## 101 alfanumeryczne

Razem do zapłaty: ### ################## 102 alfanumeryczne
```
TID: ################################### 103 alfanumeryczny
```
```
MID: ################################### 104 alfanumeryczny
```
```
UID: ################################### 105 alfanumeryczny
```
```
AIC: ################################### 106 alfanumeryczny
```
```
AID: ################################### 107 alfanumeryczny
```
```
GROC: ################################## 108 alfanumeryczny
```
```
ATC: ################################### 109 alfanumeryczny
```
Wystawca faktury: 110 alfanum-p
######################################## 110 alfanum-p
Tytułem: 111 alfanum-p
######################################## 111 alfanum-p
PROSZĘ ZACHOWAĆ POTWIERDZENIE 112 linia bez parametru
OBSŁUGA KLIENTA: ####################### 113 alfanumeryczny
```
Dla: 114 alfanum-p
```
######################################## 114 alfanum-p
Zapłata rachunku nr: ################### 115 alfanumeryczny
DCC TRANSACTION 116 linia bez parametru
```
Acquirer: ############################## 117 alfanumeryczny
```
```
Sale: ############## ### 118 alfanumeryczne
```
Exchange rate: 119 linia bez parametru
############## ### = ############## ### 120 alfanumeryczne
I have chosen not to use the 121 linia bez parametru
#################### currency conversion 122 alfanumeryczny, tekst wycentrowany niezależnie od
dług.
process and agree that I will have no 123 linia bez parametru
recourse against #################### 124 alfanumeryczny
concerning the currency conversion or 125 linia bez parametru
its disclosure. 126 linia bez parametru
PLEASE DEBIT MY ACCOUNT 127 linia bez parametru
Kod Nazwa ###################### Grupa 128 alfanumeryczny
##### ################################## 129 alfanumeryczny, alfanumeryczny
################################## ##### 130 alfanumeryczny, alfanumeryczny
Forma ####################### Uwagi 131 alfanumeryczny
########## ############################# 132 alfanumeryczny, alfanumeryczny
############################# ########## 133 alfanumeryczny, alfanumeryczny
```
UWAGI:
```
1. Linie można przestawiać i powielać
2. Parametry wyrównane do prawej mogą być w całości przeniesione do następnej linii, jeśli nie
mieszczą się w pierwszej.
23 – Potwierdzenie doładowania
Potwierdzenie doładowania numeru GSM 0 - nagłówek
Potwierdzenie poprawności numeru 1 – nagłówek
Potwierdzenie realizacji doładowania 2 – nagłówek
Kupon elektroniczny 3 - nagłówek
```
DOŁADOWANIE 4 - nagłówek (dwie wycentrowane linie, podwójnej szer.)
```
ENERGETYCZNE
```
Kasa: ### Kasjer: ####### 0 alfanumeryczny, alfanumeryczny
```
Nr dowodu sprzedaży: ############### 1 alfanumeryczny
Kod doładowujący: ###################### 2 alfanumeryczny
```
Dla: ############################### 3 alfanumeryczny
```
Numer telefonu: ######### 4 alfanumeryczny
Potwierdzenie doładowania przez SMS 5 linia bez parametru
Wartość PLN: ########### 6 alfanumeryczny
Potwierdzam prawidłowość numeru telefonu 7 linia bez parametru
........................ 8 linia bez parametru
podpis klienta 9 linia bez parametru
Marka pre-paid: ######################## 10 alfanumeryczny
Id konta: ############################## 11 alfanumeryczny
Numer referencyjny: #################### 12 alfanumeryczny
Numer seryjny: ######################### 13 alfanumeryczny
Data ważności: ########## 14 alfanumeryczny
```
Lp:##################################### 15 alfanumeryczny
```
Kod doładowujący: ###################### 16 alfanum., linia o podwójnej wysokości,
Kod ################ 17 alfanum., linia o podwójnej szerokości,
Kod ################ 18 alfanum., linia o podwójnej szerokości i wysokości,
Numer ewidencyjny: 19 alfanum-p
########################################
Deklarowana kwota: 20 alfanum-p
########################################

Nr transakcji: 21 alfanum-p
########################################
Data generacji kodu: 22 alfanum-p
########################################
Wprowadź do licznika: 23 alfanum-p
########################################
Twój nowy kod: 24 alfanum-p
########################################
PROSIMY O SPRAWDZENIE ORAZ AKCEPTACJĘ 25 dwie wycentrowane linie
ROZLICZENIA !
```
Energia: 26 alfanum-p
```
########################################
Przesył zmienny: 27 alfanum-p
########################################
Przesył stały: 28 alfanum-p
########################################
Opłaty stałe: 29 alfanum-p
########################################
Kwota prowizji: 30 alfanum-p
########################################
Razem do zapłaty: 31 alfanum-p
########################################
```
UWAGI:
```
1. Linie można przestawiać i powielać.
2. Każdy znak kodu doładowującego w liniach 2, 16, 17, 18 na kopii formatki drukowany jest jako
"*".
3. Parametry wyrównane do prawej mogą być w całości przeniesione do następnej linii, jeśli nie
mieszczą się w pierwszej.
24 – Potwierdzenie skupu waluty
Potwierdzenie skupu waluty 0 - nagłówek
```
Kasa: ### Kasjer: ####### 0 alfanumeryczny, alfanumeryczny
```
Nr dowodu sprzedaży: ############### 1 alfanumeryczny
Skup waluty: #### ########### 2 alfanumeryczny, alfanumeryczny
Kurs skupu waluty: ##################### 3 alfanumeryczny
Wartość PLN: ########### 4 alfanumeryczny
Słownie: ############################### 5 alfanumeryczny
############################### 6 alfanumeryczny
```
UWAGI:
```
1. Linie można powielać i przestawiać.
25 – Bon rabatowy
```
BON RABATOWY 0 – nagłówek, (podwójna szerokość)
```
```
LISTA TOWARÓW 1 – nagłówek, (podwójna szerokość)
```
```
Sklep:### Kasa: ### Kasjer: ####### 0 wszystkie alfanumeryczne
```
Nr dowodu sprzedaży: ################### 1 alfanumeryczny
PREMIOWANE TOWARY KWOTA PREMII 2 linia bez parametru
```
TOWAR:#################### ########### 3 alfanumeryczny, alfanumeryczny
```
```
RAZEM ########### 4 alfanumeryczny, alfanumeryczny, (podwójna szerokość)
```
```
PREMIA:############# 5 alfanumeryczny, (podwójna szerokość)
```
```
PREMIA:################################# 6 alfanumeryczny
```
WAŻNY:################################## 7 alfanumeryczny
DZIĘKUJEMY 8 linia bez parametru
DO ZOBACZENIA 9 linia bez parametru
```
UWAGI:
```
1. Linie można powielać i przestawiać.
26 – Raport zmianowy
```
RAPORT ZMIANOWY 0 – nagłówek, (podwójna szerokość)
```
```
Zmiana: ###################### 0 alfanumeryczny
```
```
Kasjer: ###################### 1 alfanumeryczny
```
```
PRZYCHODY: ###################### 2 alfanum-p
```
Sprzedaż gotówkowa:##################### 3 alfanum-p

Karta ################: ################ 4 alfanumeryczny, alfanum-p
Czek ################: ################ 5 alfanumeryczny, alfanum-p
Bon ################: ################ 6 alfanumeryczny, alfanum-p
Wpłaty do kasy: ###################### 7 alfanum-p
Wydania opakowań: ###################### 8 alfanum-p
```
ROZCHODY: ###################### 9 alfanum-p
```
Wypłaty z kasy: ###################### 10 alfanum-p
Zwroty opakowań: ###################### 11 alfanum-p
```
ROZLICZENIE 12 (podwójna szerokość)
```
Gotówka: ###################### 13 alfanum-p
Karta ################: ################ 14 alfanumeryczny, alfanum-p
Czek ################: ################ 15 alfanumeryczny, alfanum-p
Bon ################: ################ 16 alfanumeryczny, alfanum-p
```
Opakowania: ###################### 17 alfanum-p
```
```
RAZEM 18 (podwójna szerokość)
```
STAN KASY: ###################### 19 alfanum-p
ILOŚĆ PARAGONÓW: ###################### 20 alfanum-p
ILOŚĆ ANULOWANYCH PARAGONÓW:############ 21 alfanum-p
Liczba stornowanych pozycji:############ 22 alfanum-p
Początek zmiany: ############ 23 alfanumeryczny
Koniec zmiany: ############ 24 alfanumeryczny
```
UWAGI:
```
1. Linie można powielać i przestawiać.
27 – Rozliczenie konta
```
Rozliczenie konta 0 – nagłówek, (podwójna szerokość)
```
Saldo karty upominkowej 1 – nagłówek
```
Karta upominkowa 2 – nagłówek, (podwójna szerokość)
```
Potwierdzenie płatności kartą 3 – nagłówek
Wymiana środków płatności 4 – nagłówek
```
Saldo karty iCard 5 – nagłówek, (podwójna szerokość)
```
Potwierdzenie transakcji iCard 6 – nagłówek
Rozliczenie konta ########## 0 alfanumeryczny
Stan konta przed transakcją: ########## 1 alfanumeryczny
Przyznana premia: ########## 2 alfanumeryczny
```
Wykorzystane: ########## 3 alfanumeryczny
```
Stan konta po transakcji: ########## 4 alfanumeryczny
Artykuł nr: ######## ########## 5 alfanum-p, alfanum-p
Nazwa karty: ##################### 6 alfanumeryczny
Numer karty: ################### 7 alfanum-p
Numer autoryzacji: ##### 8 alfanum-p
Data ważności karty: ########## 9 alfanum-p
Saldo karty: ############### 10 alfanum-p
iCard - Pobrano: ######### 11 alfanum-p
Karta iCard: ############### ######### 12 alfanumeryczny, alfanum-p
Środek pł. wydano ######## ########## 13 alfanumeryczny, alfanum-p
Kwota iCard: ########## 14 alfanum-p
Środek pł.################# ########## 15 alfanumeryczny, alfanum-p
```
Razem: ########## 16 alfanum-p
```
```
Reszta: ########## 17 alfanum-p
```
```
UWAGI:
```
1. Linie można powielać i przestawiać.
28 – Raport kasy/kasjera
```
RAPORT KASJERA 0 – nagłówek, (podwójna szerokość)
```
```
RAPORT SKRÓCONY 1 – nagłówek, (podwójna szerokość)
```
Rodzaje płatności 0
Konto klienta : ############ 1
```
Routex : ############ 2
```
```
LOMO : ############ 3
```
```
DKV : ############ 4
```
```
UTA : ############ 5
```
Routex Manual : ############ 6
LOMO Manual : ############ 7
DKV Manual : ############ 8
UTA Manual : ############ 9
Karta bankowa i T&E : ############ 10

```
Czeki : ############ 11
```
```
Vouchery : ############ 12
```
Gotówka w PLN : ############ 13
Dewizy przel. : ############ 14
RAZEM ############# 15
Przychody 16 linia bez parametru
Kwota otwarcia : ############ 17
Sprzedaż : ############ 18
Wpłaty : ############ 19
Wpłyn. na rach : ############ 20
Różnice inkaso : ############ 21
RAZEM ############# 22
Rozchody 23 linia bez parametru
```
Zwroty : ############ 24
```
Wypłaty : ############ 25
Kwota zamknięcia : ############ 26
RAZEM ############# 27
Płatności w PLN 28 linia bez parametru
Czeki w sejfie : ############ 29
Czeki w kasie : ############ 30
RAZEM ############# 31
Vouch. w sejfie : ############ 32
Vouch. w kasie : ############ 33
RAZEM ############# 34
Gotówka w sejfie : ############ 35
Gotówka w kasie : ############ 36
RAZEM ############# 37
Płatności w dewizach 38 linia bez parametru
DM w sejfie : ############ 39
DM w kasie : ############ 40
RAZEM ############# 41
USD w sejfie : ############ 42
USD w kasie : ############ 43
RAZEM ############# 44
GBP w sejfie : ############ 45
GBP w kasie : ############ 46
RAZEM ############# 47
Sejf 48 linia bez parametru
Nr schowka #### 49
Gotówka w PLN : ############ 50
```
Czeki : ############ 51
```
```
Voucher : ############ 52
```
```
DM : ############ 53
```
```
USD : ############ 54
```
```
GBP : ############ 55
```
Rozliczenie kasjera 56 linia bez parametru
Czeki w kasie : ############ 57
Zliczono czeki : ############ 58
RÓŻNICA ############ 59
Vouch. w kasie : ############ 60
Zlicz. Vouch. : ############ 61
RÓŻNICA ############ 62
Gotówka w PLN : ############ 63
Zliczono gotów. : ############ 64
RÓŻNICA ############ 65
DM w kasie : ############ 66
DM zliczono : ############ 67
RÓŻNICA ############ 68
USD w kasie : ############ 69
USD zliczono : ############ 70
RÓŻNICA ############ 71
GBP w kasie : ############ 72
GBP zliczono : ############ 73
RÓŻNICA ############ 74
Zmiana zamknięta 75 linia bez parametru
Zmiana nr ### 76
```
Kasjer: #################### 77 alfanumeryczny
```
UWAGI
1. Linie można powielać i przestawiać.
2. W linii 77 parametr alfanumeryczny, pozostałe alfanumeryczne wyrównane do prawej.

29 – Wpłata/wypłata
```
POKWITOWANIE WPŁATY 0 – nagłówek, (podwójna szerokość)
```
```
POKWITOWANIE WYPŁATY 1 – nagłówek, (podwójna szerokość)
```
```
Numer:###### 0
```
```
Komu: ################### 1
```
TYTUŁ WPŁATY/WYPŁATY ILE 2
Przedpłata do par.nr ############# 3
Zabezpieczenie ############# 4
Do zafakturowania ############# 5
Bilon ############# 6
Wpłata 1 ############# 7
Wpłata 2 ############# 8
Sejf ############# 9
Wypłata 1 ############# 10
Wypłata 2 ############# 11
Do banku ############# 12
Bilon ############# 13
Wypłata ############# 14
Razem ############# 15
Powyższą kwotę otrzymałem 16 linia bez parametru
--------------------------- 17 linia bez parametru
PODPIS 18 linia bez parametru
```
Uwagi:
```
1. Linia 1 parametr alfanumeryczny, pozostałe alfanum. wyrównane do prawej.
2. Linie można powielać i przestawiać.
30 – Stany liczników
```
STANY LICZNIKÓW 0 – nagłówek, (podwójna szerokość)
```
Pompa ## ##### stan ################lit. 0
Ogółem liczniki 1 linia bez parametru
Paliwo ############################lit. 2
```
Uwagi:
```
1. We wszystkich liniach występują parametry alfanumeryczne wyrównane do prawej.
2. Linie można powielać i przestawiać.
31 – Raport tankowania
```
RAPORT TANKOWANIA 0 – nagłówek, (podwójna szerokość)
```
Nr Gatunek Obj. zb. Rezerwa Alarm 0 linia bez parametru
## ########## ######## ##### ######## 1
```
Uwagi:
```
1. Wszystkie parametry alfanumeryczne wyrównane do prawej.
2. Linie można powielać i przestawiać.
32 – Potwierdzenie zapłaty kartą
```
KARTA KREDYTOWA 0 – nagłówek, (podwójna szerokość)
```
Numer transakcji: ##### 0 alfanum-p
```
Data: ######## Godzina: #### 1 alfanum-p, alfanum-p
```
Nazwa karty: ################# 2 alfanumeryczny
Numer karty: #################### 3 alfanum-p
Transakcja karty: ###### 4 alfanum-p
Numer autoryzacji: ###### 5 alfanum-p
Identyfikator autoryzacji: ####### 6 alfanum-p
Lp. Nazwa jm Ilość 7 linia bez parametru
## ############## ### ####### 8 alfanum-p, alfanum., alfanum., alfanum-p
```
KWOTA: ########## 9 alfanum-p
```
........................................ 10 linia bez parametru
podpis 11 linia bez parametru
```
Posiadacz: ######################### 12 alfanumeryczny
```
Dane ident.: ######################### 13 alfanumeryczny
Dane ident.: ######################### 14 alfanumeryczny
```
Przebieg: ############### 15 alfanum-p
```

Kod kierowcy: ########## 16 alfanum-p
Nr rej.: ################## 17 alfanumeryczny
```
Uwagi:
```
1. Linie można powielać i przestawiać.
33 – Waluta w sejfie
```
WALUTA W SEJFIE 0 – nagłówek, (podwójna szerokość)
```
OGÓŁEM GOTÓWKA W SEJFIE : ########## 0
### ########## W SEJFIE : ########## 1
OGÓŁEM CZEKI W SEJFIE : ########## 2
OGÓŁEM VOUCHERY W SEJFIE : ########## 3
OGÓŁEM W SEJFIE : ########## 4
NUMER SKRYTKI ############### 5
```
Uwagi:
```
1. Wszystkie parametry alfanumeryczne wyrównane do prawej.
2. Linie można powielać i przestawiać.
34 – Raport alarmu paliwa
```
RAPORT ALARMU PALIWA 0 – nagłówek, (podwójna szerokość)
```
Zbiornik nr ####### 0
Paliwo opis ################# 1
RODZAJ ALARMU: 2 linia bez parametru
############################## 3
############################## 4
############################## 5
DATA ############## 6
CZAS ######### 7
```
Uwagi:
```
1. Wszystkie parametry alfanumeryczne wyrównane do prawej.
2. Linie można powielać i przestawiać.
35 – Bilet do myjni
```
BILET DO MYJNI 0 – nagłówek, (podwójna szerokość)
```
WAŻNY NA ## PROGRAM NR ## ZŁ ###### 0
W CELU URUCHOMIENIA MYJNI WPROWADŹ 1 linia bez parametru
KOD PROGRAMU 2 linia bez parametru
```
K O D : # # # # # # # # # # # # # # # 3 (podwójna szerokość)
```
WYDANY W DNIU ############ CZAS ######## 4
ZAPRASZAMY DO KORZYSTANIA 5 linia bez parametru
Z NASZYCH MYJNI 6 linia bez parametru
```
Uwagi:
```
1. Linia 3 – podwójna szerokość, wycentrowana
2. Parametr kod alfanumeryczny, reszta parametrów alfanumeryczna wyrównana do prawej
3. Linie można powielać i przestawiać.
36 – Raport stanu paliw
STAN ZBIORNIKÓW RAPORT 0 - nagłówek
MODUŁ: ### POZYCJA:### SONDA NR #### 0 alfanum., alfanum-p, alfanum-p
```
OPIS: ################################ 1 alfanumeryczny
```
```
PRODUKT: ############################# 2 alfanumeryczny
```
POZIOM OBJĘTOŚĆ 3 linia bez parametru
```
(CM) (LTR) 4 linia bez parametru
```
POJEMNOŚĆ ########## ############ 5
```
PRODUKT : ########## ############ 6
```
```
WODA : ########## ############ 7
```
```
RAZEM : ########## ############ 8
```
KOREKTA O TEMPERATURĘ 9 linia bez parametru
```
PRODUKT : ####################### 10
```
```
WODA : ####################### 11
```

```
RAZEM : ####################### 12
```
MAX.POZIOM NAPEŁ: ###################### 13
MAX.DO NAPEŁNIENIA: #################### 14
ŚREDNIA TEMPERATURA PRODUKTU: ########## 15
```
Uwagi:
```
1. Parametry bez opisu są typu alfanumerycznego wyrównanego do prawej.
2. Linie można powielać i przestawiać.
37 – Raport dostawy paliw
```
RAPORT DOSTAWY PALIW 0 – nagłówek, (podwójna szerokość)
```
```
ZBIORNIK: ####### 0
```
```
OZNACZENIE: ###### PRODUKT: ############ 1
```
RAPORT DOSTAWY – STABILNYCH 2 linia bez parametru
PRZED DOSTAWĄ 3 linia bez parametru
OBJĘTOŚĆ PRODUKTU: ################### 4
OBJĘTOŚĆ WODY: ################### 5
OBJ. DO WYPEŁ.: ################### 6
TEMPERATURA PRODUKTU: ################ 7
PO DOSTAWIE 8 linia bez parametru
OBJĘTOŚĆ PRODUKTU: ################### 9
OBJĘTOŚĆ WODY: ################### 10
MAX. DO WYPEŁ.: ################### 11
TEMPERATURA PRODUKTU: ################ 12
DOSTAWA 13 linia bez parametru
```
DATA: ############ CZAS: ############# 14
```
OBJĘTOŚĆ: ################## 15
TEMPERATURA ################## 16
```
DOSTAWA NETTO(15C): ################## 17
```
TEMPERATURA PRODUKTU: ################ 18
KSIĘGOWA OBJ.DOSTAWY:################# 19
ROZBIEŻNOŚĆ: ################## 20
```
Uwagi:
```
1. Wszystkie parametry alfanumeryczne wyrównane do prawej
2. Linie można powielać i przestawiać.
38 – Raport zmiany BP partnerclub
```
BP partnerclub 0 – nagłówek, (podwójna szerokość)
```
```
Klub LifeStyle 1 – nagłówek, (podwójna szerokość)
```
Nr terminala nazwa stacji 0
######### ###################### 1 alfanum-p, alfanumeryczny
Nr kolejny ############## 2
Kod terminala ############## 3
Operator ###################### 4
Czas rozpoczęcia ######### 5
Data rozpoczęcia ############## 6
Czas zakończenia ######### 7
Data zakończenia ############## 8
Tariff PKT man. TR. man. 9 linia bez parametru
TAR ##: ########################### 10
% Wydania ###################### 11
Litry sprzedane ###################### 12
Litry wydane ###################### 13
DAR ###################### 14
Punkty wymienione ###################### 15
Punkty wczytane ###################### 16
Trans. Wydano ###################### 17
```
Uwagi:
```
1. W linii 1 występuje parametr alfanumeryczny, pozostałe parametry są alfanumeryczne wyrównane
do prawej
2. Linie można powielać i przestawiać.
39 – Potwierdzenie podarunku
```
BP partnerclub 0 – nagłówek, (podwójna szerokość)
```

```
Klub LifeStyle 1 – nagłówek, (podwójna szerokość)
```
Nr terminala nazwa stacji 0 linia bez parametru
######### ###################### 1 alfanum-p, alfanumeryczny
Ilość ######### Podarunek numer ####### 2
Punktów za podarunek ############## 3
Razem punkty z podarunek ############## 4
Numer karty ######################### 5
Punkty początkowe ############## 6
Punkty skasowane ############## 7
Nowych punktów razem ############## 8
Nazwa ################################## 9 alfanumeryczny
Dziękujemy. Do zobaczenia. 10
Nr terminala ############## 11
Kod sprzedawcy ############## 12
Data ############# Kasjer nr ######### 13
Czas ########## 14
```
Uwagi:
```
1. W linii 1 i 9 występuje parametr alfanumeryczny, pozostałe parametry są alfanumeryczne wy-
równane do prawej
2. Linie można powielać i przestawiać.
40 – Potwierdzenie wydania podarunku
```
BP partnerclub 0 – nagłówek, (podwójna szerokość)
```
```
Klub LifeStyle 1 – nagłówek, (podwójna szerokość)
```
Czas ########## Data ################# 0
Ilość ########## Podarunek numer ####### 1
Punktów za podarunek ############## 2
Razem punkty z podarunek ############## 3
Nazwa ################################## 4
```
Uwagi:
```
1. Linia 4 parametr alfanumeryczny, pozostałe parametry są alfanumeryczne wyrównane do prawej.
2. Linie można powielać i przestawiać.
41 – Zamówienie
ZAMÓWIENIE 0 - nagłówek
```
Kelner: ################################ 0 alfanumeryczny
```
```
Stolik: ################################ 1 alfanumeryczny
```
- - - - - - - - - - - - - - - - - - - - 2 linia bez parametru
```
Towar: ################################# 3 alfanumeryczny
```
```
Opis: ################################## 4 alfanumeryczny
```
Ilość: ################################# 5 alfanumeryczny
```
Uwagi:
```
1. Wszystkie linie można przestawiać i powielać
42 – Potwierdzenie /Raport /Bon
```
POTWIERDZENIE 0 – nagłówek, (podwójna szerokość)
```
```
RAPORT 1 – nagłówek, (podwójna szerokość)
```
```
BON 2 – nagłówek, (podwójna szerokość)
```
Potwierdzenie ########################## 0 alfanumeryczny, linia wycentrowana
Raport ################################# 1 alfanumeryczny, linia wycentrowana
Pokwitowanie ########################### 2 alfanumeryczny, linia wycentrowana
Bon #################################### 3 alfanumeryczny, linia wycentrowana
Wydruk ################################# 4 alfanumeryczny, linia wycentrowana
Tytuł ################################## 5 alfanumeryczny, linia wycentrowana
Część ################################## 6 alfanumeryczny, linia wycentrowana
Blok ################################### 7 alfanumeryczny, linia wycentrowana
Kasjer ################# Kasa ########## 8 alfanumeryczny, alfanumeryczny
Data ################ Godzina ########## 9 alfanumeryczny, alfanumeryczny
Opis ################################### 10 alfanumeryczny
Nazwa ################################## 11 alfanumeryczny
Numer ################################## 12 alfanumeryczny

Tytułem ################################ 13 alfanumeryczny
Kod #################################### 14 alfanumeryczny
Liczba ################################# 15 alfanumeryczny
Typ #################################### 16 alfanumeryczny
Stan ################################### 17 alfanumeryczny
Zmiana ################################# 18 alfanumeryczny
Z ###################################### 19 alfanumeryczny
Na ##################################### 20 alfanumeryczny
Konto ################################## 21 alfanumeryczny
Kurs ################################### 22 alfanumeryczny
Operator ############################### 23 alfanumeryczny
Dla #################################### 24 alfanumeryczny
Klient ################################# 25 alfanumeryczny
cd. #################################### 26 alfanumeryczny
Ilość ################################## 27 alfanumeryczny
Wpłata ################################# 28 alfanumeryczny
Wypłata ################################ 29 alfanumeryczny
Opłata ################################# 30 alfanumeryczny
Dopłata ################################ 31 alfanumeryczny
Przedpłata ############################# 32 alfanumeryczny
Prowizja ############################### 33 alfanumeryczny
Odsetki ################################ 34 alfanumeryczny
Kwota ################################## 35 alfanumeryczny
Przychody ############################## 36 alfanumeryczny
Rozchody ############################### 37 alfanumeryczny
Sprzedaż ############################### 38 alfanumeryczny
Uznanie ################################ 39 alfanumeryczny
Saldo ################################## 40 alfanumeryczny
Gotówka ################################ 41 alfanumeryczny
Opakowanie ############################# 42 alfanumeryczny
Rabat ################################## 43 alfanumeryczny
Narzut ################################# 44 alfanumeryczny
Promocja ############################### 45 alfanumeryczny
Premia ################################# 46 alfanumeryczny
Płatność ############################### 47 alfanumeryczny
Forma ################################## 48 alfanumeryczny
Środek płat. ########################### 49 alfanumeryczny
Transakcja anulowana 50 linia bez parametru, wycentrowana
Proszę obciążyć moje konto 51 linia bez parametru, wycentrowana
Proszę uznać moje konto 52 linia bez parametru, wycentrowana
Oryginał 53 linia bez parametru, wycentrowana
Kopia 54 linia bez parametru, wycentrowana
..................... 55 linia bez parametru, wycentrowana
Podpis ################################# 56 alfanumeryczny, linia wycentrowana
Sprawdził ############################## 57 alfanumeryczny, linia wycentrowana
Zatwierdził ############################ 58 alfanumeryczny, linia wycentrowana
Tytuł ################################## 59 alfanumeryczny, linia wycentrowana i podw. wysokość
Tytuł ############## 60 alfanumeryczny, linia wycentr., podwójna szer.
Tytuł ############## 61 alfanumeryczny, linia wycentr., podw. szer. i wys.
Kod Nazwa ###################### Grupa 62 alfanumeryczny
##### ################################## 63 alfanumeryczne
################################## ##### 64 alfanumeryczne
Forma ####################### Uwagi 65 alfanumeryczny
########## ############################# 66 alfanumeryczne
############################# ########## 67 alfanumeryczne
Słownie: ############################### 68 alfanumeryczny
############################### 69 alfanumeryczny
```
Uwagi:
```
1. Wszystkie linie można przestawiać i powielać
43 – Pokwitowanie
0 - nagłówek
```
Kasa: ### Kasjer: ####### 0 alfanumeryczny
```
Nr dowodu sprzedaży: ############### 1 alfanumeryczny
```
TID: ######## UID: ################ 2 alfanumeryczny
```
```
TID: ######## MID: ################ 3 alfanumeryczny
```
Zapłata rachunku nr: ################### 4 alfanumeryczny
```
Dla: ################################# 5 alfanumeryczny
```
```
Karta: ################################# 6 alfanumeryczny
```
###################### Ważna do: ##/## 7 alfanumeryczny
Sprzedaż: PLN ########### 8 alfanumeryczny, podwójna wysokość

```
Uznanie: PLN ########### 9 alfanumeryczny, podwójna wysokość
```
Gotówka: PLN ########### 10 alfanumeryczny, podwójna wysokość
Słownie: ############################### 11 alfanumeryczny
############################### 12 alfanumeryczny
Kod autoryzacji: ############ 13 alfanumeryczny
Liczba punktów za transakcję: ######### 14 alfanumeryczny
Liczba punktów po transakcji: ######### 15 alfanumeryczny
Kwota na karcie: ########### 16 alfanumeryczny
Proszę obciążyć moje konto 17 linia bez parametru, wycentrowana
Proszę uznać moje konto 18 linia bez parametru, wycentrowana
Transakcja unieważniona 19 linia bez parametru, wycentrowana
KOD PIN ZGODNY 20 linia bez parametru, wycentrowana
........................ 21 linia bez parametru, wycentrowana
Podpis posiadacza karty 22 linia bez parametru, wycentrowana
```
ORYGINAŁ 23 (podwójna szerokość, wycentrowana)
```
```
KOPIA 24 (podwójna szerokość, wycentrowana)
```
```
Uwagi:
```
1. Wszystkie linie można przestawiać i powielać
200 – Super-formatka
Tzw. super-formatka zawiera wszystkie linie występujące w innych formatkach.
TRANSAKCJE ODŁOŻONE 0 - nagłówek
POTWIERDZENIE DOKONANIA TRANSAKCJI 1 - nagłówek
RAPORT FUNKCJI OPERATORA 2 - nagłówek
```
RAPORT KASJERA X 3 – nagłówek, (podwójna szerokość)
```
```
RAPORT KASJERA Z 4 – nagłówek, (podwójna szerokość)
```
```
RAPORT KASY X 5 – nagłówek, (podwójna szerokość)
```
```
RAPORT KASY Z 6 – nagłówek, (podwójna szerokość)
```
```
OFFLINE KASJERA 7 – nagłówek, (podwójna szerokość)
```
```
ONLINE KASJERA 8 – nagłówek, (podwójna szerokość)
```
RAPORT ŚRODKÓW PŁATNOŚCI 9 - nagłówek
SPRZEDAŻ ZAREJ. W KASIE 10 - nagłówek
POKWITOWANIE 11 - nagłówek
POTWIERDZENIE WPŁATY 12 - nagłówek
```
BON UPOMINKOWY 13 – nagłówek, (podwójna szerokość)
```
```
NOTA KREDYTOWA 14 – nagłówek, (podwójna szerokość)
```
```
NOTA KREDYTOWA 15 – nagłówek, (podwójna szerokość)
```
```
KUPON RABATOWY 16 – nagłówek, (podwójna szerokość)
```
PŁATNOŚĆ 'ZA POBRANIEM' 17 – nagłówek
```
PRZELEW BANKOWY 18 – nagłowek, (podwójna szerokość)
```
Potw. sprzedaży bonu upominkowego 19 – nagłówek,
RABAT DLA PRACOWNIKA 20 – nagłówek
WYMIANA ŚRODKÓW PŁATNOŚCI 21 - nagłówek
OPERACJE KASOWE 22 - nagłówek
BŁĘDY KASY 23 - nagłówek
CENNIK 24 - nagłówek
ZMIANY CEN 25 - nagłówek
STATYSTYKA SPRZEDAŻY 26 - nagłówek
POTWIERDZENIE DOKONANIA TRANSAKCJI 27 - nagłówek
WYDANIE BONU UPOMINKOWEGO 28 - nagłówek
Potwierdzenie zapłaty kartą 29 - nagłówek
Potwierdzenie zapłaty rachunku 30 - nagłówek
Pokwitowanie 31 - nagłówek
Pokwitowanie transakcji uznania 32 - nagłówek
Potwierdzenie unieważnienia 33 - nagłówek
Potwierdzenie odmowy autoryzacji 34 - nagłówek
Potwierdzenie pre-autoryzacji 35 - nagłówek
Potwierdzenie odmowy 36 - nagłówek
Transaction confirmation 37 - nagłówek
Cancellation confirmation 38 - nagłówek
Pre-authorization confirmation 39 - nagłówek
Declination confirmation 40 - nagłówek
Potwierdzenie doładowania numeru GSM 41 - nagłówek
Potwierdzenie poprawności numeru 42 – nagłówek
Potwierdzenie realizacji doładowania 43 – nagłówek
Kupon elektroniczny 44 - nagłówek
Potwierdzenie skupu waluty 45 - nagłówek
```
BON RABATOWY 46 – nagłówek, (podwójna szerokość)
```
```
LISTA TOWARÓW 47 – nagłówek, (podwójna szerokość)
```
```
RAPORT ZMIANOWY 48 – nagłówek, (podwójna szerokość)
```

```
Rozliczenie konta 49 – nagłówek, (podwójna szerokość)
```
Saldo karty upominkowej 50 – nagłówek
```
Karta upominkowa 51 – nagłówek, (podwójna szerokość)
```
Potwierdzenie płatności kartą 52 – nagłówek
Wymiana środków płatności 53 - nagłówek
```
Saldo karty iCard 54 – nagłówek, (podwójna szerokość)
```
Potwierdzenie transakcji iCard 55 - nagłówek
```
RAPORT KASJERA 56 – nagłówek, (podwójna szerokość)
```
```
RAPORT SKRÓCONY 57 – nagłówek, (podwójna szerokość)
```
```
POKWITOWANIE WPŁATY 58 – nagłówek, (podwójna szerokość)
```
```
POKWITOWANIE WYPŁATY 59 – nagłówek, (podwójna szerokość)
```
```
STANY LICZNIKÓW 60 – nagłówek, (podwójna szerokość)
```
```
RAPORT TANKOWANIA 61 – nagłówek, (podwójna szerokość)
```
```
KARTA KREDYTOWA 62 – nagłówek, (podwójna szerokość)
```
```
WALUTA W SEJFIE 63 – nagłówek, (podwójna szerokość)
```
```
RAPORT ALARMU PALIWA 64 – nagłówek, (podwójna szerokość)
```
```
BILET DO MYJNI 65 – nagłówek, (podwójna szerokość)
```
STAN ZBIORNIKÓW RAPORT 66 - nagłówek
```
RAPORT DOSTAWY PALIW 67 – nagłówek, (podwójna szerokość)
```
```
BP partnerclub 68 – nagłówek, (podwójna szerokość)
```
```
Klub LifeStyle 69 – nagłówek, (podwójna szerokość)
```
```
BP partnerclub 70 – nagłówek, (podwójna szerokość)
```
```
Klub LifeStyle 71 – nagłówek, (podwójna szerokość)
```
```
BP partnerclub 72 – nagłówek, (podwójna szerokość)
```
```
Klub LifeStyle 73 – nagłówek, (podwójna szerokość)
```
ZAMÓWIENIE 74 – nagłówek
```
POTWIERDZENIE 75 – nagłówek, (podwójna szerokość)
```
```
RAPORT 76 – nagłówek, (podwójna szerokość)
```
```
BON 77 – nagłówek, (podwójna szerokość)
```
```
BILET 78 – nagłówek, (podwójna szerokość)
```
DOŁADOWANIE 79 – nagłówek,
```
ENERGETYCZNE (w dwóch liniach, podwójna szerokość)
```
```
LICZENIE KASY 80 – nagłówek, (podwójna szerokość)
```
```
WYPŁATA KASJERA 81 – nagłówek, (podwójna szerokość)
```
```
WPŁATA KASJERA 82 – nagłówek, (podwójna szerokość)
```
```
ROZLICZENIE KASJERA 83 – nagłówek, (podwójna szerokość)
```
DOKUMENT NIEFISKALNY 84 – nagłówek – może zawierać dodatkowy opis –
```
patrz: opis polecania formstart
```
```
85 – nagłówek, (pusty)
```
```
Kasa: ################################## 0 alfanum-p
```
Numer transakcji: ###################### 1 alfanum-p
Numer kasjera: ######################### 2 alfanum-p
Funkcja #### ########################## 3 alfanum-p, alfanumeryczny
LICZBA RESETÓW: ### 4 alfanum-p
NUMER KASY # ########################### 5 alfanum-p, alfanumeryczny
```
SUMY ŁĄCZNE 6 (podwójna szerokość)
```
SUMA BIEŻĄCA DODATNIA ############### 7 alfanum-p
SUMA BIEŻĄCA UJEMNA ############### 8 alfanum-p
SUMA POPRZEDNIA DODATNIA ############### 9 alfanum-p
SUMA POPRZEDNIA UJEMNA ############### 10 alfanum-p
------------ 11 linia bez parametru
SUMA ŁĄCZNA DODATNIA ############### 12 alfanum-p
SUMA ŁĄCZNA UJEMNA ############### 13 alfanum-p
```
SUMY SPRZEDAŻY 14 (podwójna szerokość)
```
```
TOWARY: 15 linia bez parametru
```
##### POZYCJE DODATNIE ############### 16 alfanum-p, alfanum-p
##### USŁUGI, INNE ############### 17 alfanum-p, alfanum-p
##### POZYCJE UJEMNE ############### 18 alfanum-p, alfanum-p
##### DODATNIE KOREKTY ############### 19 alfanum-p, alfanum-p
##### UJEMNE KOREKTY ############### 20 alfanum-p, alfanum-p
##### KUPON SKLEPOWY ############### 21 alfanum-p, alfanum-p
PODSUMA TOWARÓW ############### 22 alfanum-p
PODSUMA PODATKU ############### 23 alfanum-p
RABAT / DOPŁATA 24 linia bez parametru
RABAT HEJ HEM ############### 25 alfanum-p
RABAT / DOPŁATA 2 ############### 26 alfanum-p
RABAT / DOPŁATA 3 ############### 27 alfanum-p
RABAT DLA PRACOWNIKA ############### 28 alfanum-p
PODSUMA RABATU/DOPŁATY ############### 29 alfanum-p
------------ 30 linia bez parametru
SPRZEDAŻ NETTO ŁĄCZNIE ############### 31 alfanum-p
```
SUMY ŚROD. PŁATNOŚCI 32 (podwójna szerokość)
```
ŚRODKI PŁATNOŚCI 33 linia bez parametru
ŚRODEK PŁ.##: ### ############ ####### 34 alfanum-p, alfanum, alfanum, alfanum-p

##### KWOTA ############### 35 alfanum-p, alfanum-p
##### ZEBRANE ############### 36 alfanum-p, alfanum-p
##### W OBIEGU ############### 37 alfanum-p, alfanum-p
##### START W OB. ############### 38 alfanum-p, alfanum-p
##### TYP PŁ. NR 2 ############### 39 alfanum-p, alfanum-p
PODSUMA ŚR. PŁATNOŚCI ############### 40 alfanum-p, alfanum-p
KOREKTA ŚRODKÓW PŁATNOŚCI 41 linia bez parametru
##### DOD. FUNKCJI BANK. ############### 42 alfanum-p, alfanum-p
##### POMN. FUNKCJI BANK.############### 43 alfanum-p, alfanum-p
##### USTAW. ZAOKRĄGLEŃ ############### 44 alfanum-p, alfanum-p
##### ZAPAM. CZ. PŁATN. ############### 45 alfanum-p, alfanum-p
##### PRZYW. CZ. PŁATN. ############### 46 alfanum-p, alfanum-p
##### OPŁATA PŁATNOŚCI ############### 47 alfanum-p, alfanum-p
PODSUMA KOREKTY PŁATN. ############### 48 alfanum-p
------------- 49 linia bez parametru
ŚRODKI PŁATNICZE ŁĄCZNIE ############### 50 alfanum-p
```
INNE SUMY 51 (podwójna szerokość)
```
##### OBNIŻKI DODATNIE ############### 52 alfanum-p, alfanum-p
##### OBNIŻKI UJEMNE ############### 53 alfanum-p, alfanum-p
##### KOREKCJE BŁĘDÓW ############### 54 alfanum-p, alfanum-p
##### SUMA ZWROTÓW ############### 55 alfanum-p, alfanum-p
##### ZWROTY KOSZTÓW ############### 56 alfanum-p, alfanum-p
##### ŚRODKI UNIEWAŻN. ############### 57 alfanum-p, alfanum-p
##### POZYCJE SPRZEDAŻY ############### 58 alfanum-p, alfanum-p
##### RABAT ZBIORCZY ############### 59 alfanum-p, alfanum-p
##### SPRZEDAŻ ANULOWANA ############### 60 alfanum-p, alfanum-p
##### SPRZEDAŻ ZAPAMIĘT. ############### 61 alfanum-p, alfanum-p
##### SPRZEDAŻ UNIEWAŻN. ############### 62 alfanum-p, alfanum-p
##### SPRZEDAŻ PRZYWOŁ. ############### 63 alfanum-p, alfanum-p
##### ZAMIANA ŚR. PŁATN. ############### 64 alfanum-p, alfanum-p
##### BEZ PODATKU ############### 65 alfanum-p, alfanum-p
##### KWOTA ZWOLNIONA ############### 66 alfanum-p, alfanum-p
##### ZWROT NADPŁAC. PTU ############### 67 alfanum-p, alfanum-p
##### ZNACZKI WYEMITOW. ############### 68 alfanum-p, alfanum-p
##### POZYCJE Z KLAWIAT. ######% 69 alfanum-p, alfanum-p
##### POZYCJE SKANOWANE ######% 70 alfanum-p, alfanum-p
##### POZYCJE WAŻONE ######% 71 alfanum-p, alfanum-p
POZYCJE WAŻONE ŁĄCZNIE ############### 72 alfanum-p
##### TRANSAKCJE DODATNIE 73 alfanum-p, alfanum-p
##### ZWROT NADPŁACONEJ GOTÓWKI 74 alfanum-p, alfanum-p
##### INNE TRANSAKCJE 75 alfanum-p, alfanum-p
##### OTWARCIE SZUFLADY 76 alfanum-p, alfanum-p
##### SUMA BIEŻĄCA 77 alfanum-p, alfanum-p
##### LICZBA KLIENTÓW 78 alfanum-p, alfanum-p
##:## CZAS PRACY KASJERA 79 alfanum-p, alfanum-p
##:## CZASOWE WYŁĄCZENIE KASY 80 alfanum-p, alfanum-p
##:## CZAS WPROWADZANIA TOWARÓW 81 alfanum-p, alfanum-p
##:## CZAS PŁACENIA 82 alfanum-p, alfanum-p
##:## CZAS OTWARCIA SZUFLADY 83 alfanum-p, alfanum-p
KASJER ######## 84 alfanum-p
ŚRODEK PŁ.##: ### ############ ####### 85 alfanum-p, alfanum, alfanum, alfanum-p
##### KWOTA ############### 86 alfanum-p, alfanum-p
##### ZEBRANE ############### 87 alfanum-p, alfanum-p
##### W OBIEGU ############### 88 alfanum-p, alfanum-p
##### START W OB. ############### 89 alfanum-p, alfanum-p
PODSUMA ŚR. PŁATNOŚCI ############### 90 alfanum-p
NUMER KASY # ### 91 alfanum-p, alfanumeryczny
PODSUMA SPRZEDAŻY ################ 92 alfanum-p
PODSUMA RACH. SPRZEDAŻY ################ 93 alfanum-p
PODSUMA RABATU / DOPŁ. ################ 94 alfanum-p
---------------- 95 linia bez parametru
SPRZEDAŻ ŁĄCZNIE ################ 96 alfanum-p
```
ZWROT: ################################# 97 alfanum-p
```
ŚRODEK PŁ.: ############################ 98 alfanumeryczny
```
KWOTA: ################################# 99 alfanum-p
```
```
KONTO: ################################# 100 alfanum-p
```
```
PODPIS: .............................. 101 linia bez parametru
```
DO DOKUM.SPRZED.: ###################### 102 alfanum-p
ŚRODEK PŁ.: ############################ 103 alfanumeryczny
```
KONTO: ################################# 104 alfanum-p
```
```
KWOTA: ################################# 105 alfanum-p
```
WPŁATA: ###################### 106 alfanum-p
```
RESZTA: ############################ 107 alfanum-p
```
*** ZREALIZOWANO *** 108 linia bez parametru, podwójna szer.

```
Kwota: ################################# 109 alfanum-p
```
```
Kasjer: ################################ 110 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 111 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# 111 parametry: alfanum-p,alfanum-p,alfanum
```
*ZREALIZOWANO* 112 linia bez parametru, podwójna szer.
```
Kwota: ################################# 113 alfanum-p
```
```
Kasjer: ################################ 114 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 115 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# parametry: alfanum-p,alfanum-p,alfanum
```
```
Kwota: ################################# 116 alfanum-p
```
Słownie: ############################### 117 alfanumeryczny
Zwrot nr: ############################## 118 alfanum-p
```
Kasjer: ################################ 119 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 120 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# parametry: alfanum-p,alfanum-p,alfanum
```
*** ZREALIZOWANO *** 121 linia bez parametru, podwójna szer.
```
Kwota: ################################# 122 alfanum-p
```
```
Kasjer: ################################ 123 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 124 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# parametry: alfanum-p,alfanum-p,alfanum
```
*** SPRZEDAŻ ZAREJESTROWANA *** 125 linia bez parametru
Nr identyfikacyjny: #################### 126 alfanum-p
```
Kwota: ################################# 127 alfanum-p
```
```
Kasjer: ################################ 128 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 129 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# parametry: alfanum-p,alfanum-p,alfanum
```
*** ZREALIZOWANO *** 130 linia bez parametru, podwójna szer.
Nr klienta: ############################ 131 alfanum-p
```
Kwota: ################################# 132 alfanum-p
```
```
Saldo: ################################# 133 alfanum-p
```
```
Kasjer: ################################ 134 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 135 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# parametry: alfanum-p,alfanum-p,alfanum
```
Wartość Bonu: ########################## 136 alfanum-p
```
Nazwa: ################################# 137 alfanumeryczny
```
```
Kasjer: ################################ 138 brak param., nazwa kasjera z drukarki
```
```
Data: ########## Godz.: ################ 139 linia skutkuje dwoma wierszami wydruku,
```
```
Sklep: ################################# parametry: alfanum-p,alfanum-p,alfanum
```
Rabat dla pracownika: ################## 140 alfanum-p
Numer pracownika: ###################### 141 alfanum-p
```
KWOTA: ################################# 142 alfanum-p
```
```
PODPIS: .............................. 143 linia bez parametru
```
```
Z: ################################## 144 alfanumeryczny
```
```
NA: ################################## 145 alfanumeryczny
```
OPERACJA ###: ######################### 146 alfanum-p, alfanumeryczny
BŁĄD KRYTYCZNY 147 linia bez parametru
```
Serwis : ########################### 148 alfanumeryczny
```
Urządzenie : ###################### 149 alfanumeryczny
Urządzenie dod. : ##################### 150 alfanumeryczny
```
Funkcja : ######################### 151 alfanumeryczny
```
```
Podfunkcja : ########################### 152 alfanumeryczny
```
Rejestr # : ########################### 153 alfanum-p, alfanumeryczny
Trans # : ########################### 154 alfanum-p, alfanumeryczny
Kod błędu : ########################### 155 alfanumeryczny
SKLEP ######################### 156 alfanumeryczny
DATA ######## ######## 157 alfanum-p, alfanum-p
Kod art: ############# Cena: ########,## 158 alfanum-p, alfanum-p, alfanum-p
Kod art: ############# Data: ########### 159 alfanum-p, alfanum-p
```
Cena1: ########,## Cena2: ########,## 160 alfanum-p,alfanum-p,alfanum-p,alfanum-p
```
Ilość: ########### 161 alfanum-p
BON UPOMINKOWY: ################ 162 alfanum-p
NUMER BONU: #################### 163 alfanumeryczny
```
SUMA: ############## 164 alfanum-p
```
ŚRODEK PŁ.: ############################ 165 alfanumeryczny
```
KWOTA: ################################# 166 alfanum-p
```
```
KONTO: ################################# 167 alfanum-p
```
```
RESZTA: ############################ 168 alfanum-p
```
```
Kasa: ### Kasjer: ####### 169 alfanumeryczny, alfanumeryczny
```
Nr dowodu sprzedaży: ############### 170 alfanumeryczny
Nr transakcji: ############### 171 alfanumeryczny
```
TID: ######## UID: ################ 172 alfanumeryczny, alfanumeryczny
```
```
TID: ######## MID: ################ 173 alfanumeryczny, alfanumeryczny
```
Zapłata rachunku nr: ################### 174 alfanumeryczny
```
Dla: ################################### 175 alfanumeryczny
```

Nr klienta: ############################ 176 alfanumeryczny
```
Karta: ################################# 177 alfanumeryczny
```
###################### Ważna do: ##/## 178 wszystkie alfanumeryczne
Sprzedaż: PLN ###################### 179 alfanumeryczny
```
Uznanie: PLN ###################### 180 alfanumeryczny
```
Gotówka: PLN ###################### 181 alfanumeryczny
Słownie: ############################### 182 alfanumeryczny
############################### 183 alfanumeryczny, +
```
Prowizja: PLN ################## 184 alfanumeryczny
```
Razem do zapłaty: PLN ################## 185 alfanumeryczny
Kod autoryzacji: ################ 186 alfanumeryczny
Liczba punktów za transakcję: ########## 187 alfanumeryczny
Liczba punktów po transakcji: ########## 188 alfanumeryczny
Kwota na karcie: ############### 189 alfanumeryczny
Proszę obciążyć moje konto 190 linia bez parametru
Proszę uznać moje konto 191 linia bez parametru
Transakcja unieważniona 192 linia bez parametru
KOD PIN ZGODNY 193 linia bez parametru
........................ 194 linia bez parametru
podpis posiadacza karty 195 linia bez parametru
podpis kasjera 196 linia bez parametru
podpis klienta 197 linia bez parametru
ORYGINAŁ 198 linia bez parametru, podwójna szer.
KOPIA 199 linia bez parametru, podwójna szer.
```
Sprzedaż: ### ###################### 200 alfanumeryczny, alfanumeryczny, (podwójna wys.)
```
```
Uznanie: ### ###################### 201 alfanumeryczny, alfanumeryczny, (podwójna wys.)
```
```
Gotówka: ### ###################### 202 alfanumeryczny, alfanumeryczny, (podwójna wys.)
```
```
Prowizja: ### ################## 203 alfanumeryczny, alfanumeryczny
```
Razem do zapłaty: ### ################## 204 alfanumeryczny, alfanumeryczny
```
AID: ################################# 205 alfanumeryczny
```
```
TC: ################################### 206 alfanumeryczny
```
```
AAC: ################################### 207 alfanumeryczny
```
```
PSN: ################################### 208 alfanumeryczny
```
```
ATC: ################################### 209 alfanumeryczny
```
```
ARC: ################################### 210 alfanumeryczny
```
```
AAA: ########## TD:############ 211 alfanumeryczny, alfanumeryczny
```
TAC DEFAULT: ########################### 212 alfanumeryczny
TAC DENIAL: ############################ 213 alfanumeryczny
TAC ONLINE: ############################ 214 alfanumeryczny
IAC DEFAULT: ########################### 215 alfanumeryczny
IAC DENIAL: ############################ 216 alfanumeryczny
IAC ONLINE: ############################ 217 alfanumeryczny
Commercial Code ##########: ############ 218 alfanumeryczny, alfanumeryczny
Dodatkowa dana: ######################## 219 alfanumeryczny
Nr dowodu tożsamości:................... 220
Centrum Autoryzacji:#################### 221 alfanumeryczny
POTWIERDZENIE ODMOWY AUTORYZACJI 222 linia bez parametru
TRANSAKCJA ODRZUCONA 223 linia bez parametru
Komunikat systemowy: ################### 224 alfanumeryczny
Wpłata: ### ###################### 225 alfanumeryczny, alfanumeryczny
```
Razem: ### ###################### 226 alfanumeryczny, alfanumeryczny
```
```
Zwrot: ### ###################### 227 alfanumeryczny, alfanumeryczny
```
```
Cashback: ### ###################### 228 alfanumeryczny, alfanumeryczny
```
```
Cash: ### ###################### 229 alfanumeryczny, alfanumeryczny
```
```
SALE: ### ###################### 230 alfanumeryczny, alfanumeryczny
```
```
REFUND: ### ###################### 231 alfanumeryczny, alfanumeryczny
```
FX RATE: ############################### 232 alfanumeryczny
TRANSACTION CURRENCY: ################## 233 alfanumeryczny
DCC service provided by: ############### 234 alfanumeryczny
REJECTION RECEIPT TRANSACTION WAS 235 linia bez parametru
REJECTED SYSTEM MESSAGE: ############### 236 alfanumeryczny
CANCELLATION RECEIPT TRANSACTION WAS 237 linia bez parametru
CANCELED 238 linia bez parametru
PIN VERIFIED 239 linia bez parametru
SIGNATURE 240 linia bez parametru
Pre-autoryz: ### ###################### 241 alfanumeryczny, alfanumeryczny
Acquirer/Processor: #################### 242 alfanumeryczny
Ecr no: ### Cashier: ####### 243 alfanumeryczny, alfanumeryczny
Receipt number: ############### 244 alfanumeryczny
Transaction number: ############### 245 alfanumeryczny
Invoice number: ################### 246 alfanumeryczny
```
For: ################################### 247 alfanumeryczny
```
Client number: ######################### 248 alfanumeryczny
```
Card: ################################## 249 alfanumeryczny
```

##################### Valid date: ##/## 250 wszystkie alfanumeryczne
Pre-auth: ### ###################### 251 alfanumeryczny, alfanumeryczny
```
Sale: ### ###################### 252 alfanumeryczny, alfanumeryczny
```
```
Refund: ### ###################### 253 alfanumeryczny, alfanumeryczny
```
In words: ############################## 254 alfanumeryczny
```
Statement: ############################# 255 alfanumeryczny
```
```
Commission: ### ################## 256 alfanumeryczny, alfanumeryczny
```
Total amount: ### ################## 257 alfanumeryczny, alfanumeryczny
Authorization code: ############ 258 alfanumeryczny
Points for transaction: ########## 259 alfanumeryczny
Points after transaction: ########## 260 alfanumeryczny
Amount on the card: ############### 261 alfanumeryczny
System message: ######################## 262 alfanumeryczny
Commercial Code ######################## 263 alfanumeryczny
Extra data: ############################ 264 alfanumeryczny
Document ID: ........................... 265 linia bez parametru
```
Kasa: ### Kasjer: ####### 266 alfanumeryczny, alfanumeryczny
```
Nr dowodu sprzedaży: ############### 267 alfanumeryczny
Kod doładowujący: ###################### 268 alfanumeryczny
wszystkie znaki na kopii druk. jako "*"
```
Dla: ############################### 269 alfanumeryczny
```
Numer telefonu: ######### 270 alfanumeryczny
Potwierdzenie doładowania przez SMS 271 linia bez parametru
Wartość PLN: ########### 272 alfanumeryczny
Potwierdzam prawidłowość numeru telefonu 273 linia bez parametru
........................ 274 linia bez parametru
podpis klienta 275 linia bez parametru
Marka pre-paid: ######################## 276 alfanumeryczny
Id konta: ############################## 277 alfanumeryczny
Numer referencyjny: #################### 278 alfanumeryczny
Numer seryjny: ######################### 279 alfanumeryczny
Data ważności: ########## 280 alfanumeryczny
```
Lp:##################################### 281 alfanumeryczny
```
Kod doładowujący: ###################### 282 alfanum., podwójna wysokość
wszystkie znaki na kopii druk. jako "*"
Kod ################ 283 alfanum., linia o podwójnej szerokości
wszystkie znaki na kopii druk. jako "*"
Kod ################ 284 alfanum.,
linia o podwójnej szerokości i wysokości
wszystkie znaki na kopii druk. jako "*"
```
Kasa: ### Kasjer: ####### 285 alfanumeryczny, alfanumeryczny
```
Nr dowodu sprzedaży: ############### 286 alfanumeryczny
Skup waluty: #### ########### 287 alfanumeryczny, alfanumeryczny
Kurs skupu waluty: ##################### 288 alfanumeryczny
Wartość PLN: ########### 289 alfanumeryczny
Słownie: ############################### 290 alfanumeryczny
############################### 291 alfanumeryczny, +
```
Sklep:### Kasa: ### Kasjer: ####### 292 wszystkie alfanumeryczne
```
Nr dowodu sprzedaży: ################### 293 alfanumeryczny
PREMIOWANE TOWARY KWOTA PREMII 294 linia bez parametru
```
TOWAR:#################### ########### 295 alfanumeryczny, alfanumeryczny
```
```
RAZEM ########### 296 alfanumeryczny, (podwójna szerokość)
```
```
PREMIA:############# 297 alfanumeryczny, (podwójna szerokość)
```
```
PREMIA:################################# 298 alfanumeryczny
```
WAŻNY:################################## 299 alfanumeryczny
DZIĘKUJEMY 300 linia bez parametru
DO ZOBACZENIA 301 linia bez parametru
```
Zmiana: ###################### 302 alfanumeryczny
```
```
Kasjer: ###################### 303 alfanumeryczny
```
```
PRZYCHODY: ###################### 304 alfanum-p
```
Sprzedaż gotówkowa:##################### 305 alfanum-p
Karta ################: ################ 306 alfanumeryczny, alfanum-p
Czek ################: ################ 307 alfanumeryczny, alfanum-p
Bon ################: ################ 308 alfanumeryczny, alfanum-p
Wpłaty do kasy: ###################### 309 alfanum-p
Wydania opakowań: ###################### 310 alfanum-p
```
ROZCHODY: ###################### 311 alfanum-p
```
Wypłaty z kasy: ###################### 312 alfanum-p
Zwroty opakowań: ###################### 313 alfanum-p
ROZLICZENIE 314 linia bez parametru, podwójna szer.
Gotówka: ###################### 315 alfanum-p
Karta ################: ################ 316 alfanumeryczny, alfanum-p
Czek ################: ################ 317 alfanumeryczny, alfanum-p
Bon ################: ################ 318 alfanumeryczny, alfanum-p

```
Opakowania: ###################### 319 alfanum-p
```
```
RAZEM 320 (podwójna szerokość)
```
STAN KASY: ###################### 321 alfanum-p
ILOŚĆ PARAGONÓW: ###################### 322 alfanum-p
ILOŚĆ ANULOWANYCH PARAGONÓW:############ 323 alfanum-p
Liczba stornowanych pozycji:############ 324 alfanum-p
Początek zmiany: ############ 325 alfanumeryczny
Koniec zmiany: ############ 326 alfanumeryczny
Rozliczenie konta ########## 327 alfanumeryczny
Stan konta przed transakcją: ########## 328 alfanumeryczny
Przyznana premia: ########## 329 alfanumeryczny
```
Wykorzystane: ########## 330 alfanumeryczny
```
Stan konta po transakcji: ########## 331 alfanumeryczny
Artykuł nr: ######## ########## 332 alfanum-p, alfanum-p
Nazwa karty: ##################### 333 alfanumeryczny
Numer karty: ################### 334 alfanum-p
Numer autoryzacji: ##### 335 alfanum-p
Data ważności karty: ########## 336 alfanum-p
Saldo karty: ############### 337 alfanum-p
iCard - Pobrano: ######### 338 alfanum-p
Karta iCard: ############### ######### 339 alfanumeryczny, alfanum-p
Środek pł. wydano ######## ########## 340 alfanumeryczny, alfanum-p
Kwota iCard: ########## 341 alfanum-p
Środek pł.################# ########## 342 alfanumeryczny, alfanum-p
```
Razem: ########## 343 alfanum-p
```
```
Reszta: ########## 344 alfanum-p
```
Rodzaje płatności 345 linia bez parametru
Konto klienta : ############ 346 alfanum-p
```
Routex : ############ 347 alfanum-p
```
```
LOMO : ############ 348 alfanum-p
```
```
DKV : ############ 349 alfanum-p
```
```
UTA : ############ 350 alfanum-p
```
Routex Manual : ############ 351 alfanum-p
LOMO Manual : ############ 352 alfanum-p
DKV Manual : ############ 353 alfanum-p
UTA Manual : ############ 354 alfanum-p
Karta bankowa i T&E : ############ 355 alfanum-p
```
Czeki : ############ 356 alfanum-p
```
```
Vouchery : ############ 357 alfanum-p
```
Gotówka w PLN : ############ 358 alfanum-p
Dewizy przel. : ############ 359 alfanum-p
RAZEM ############# 360 alfanum-p
Przychody 361 linia bez parametru
Kwota otwarcia : ############ 362 alfanum-p
Sprzedaż : ############ 363 alfanum-p
Wpłaty : ############ 364 alfanum-p
Wpłyn. na rach : ############ 365 alfanum-p
Różnice inkaso : ############ 366 alfanum-p
RAZEM ############# 367 alfanum-p
Rozchody 368 linia bez parametru
```
Zwroty : ############ 369 alfanum-p
```
Wypłaty : ############ 370 alfanum-p
Kwota zamknięcia : ############ 371 alfanum-p
RAZEM ############# 372 alfanum-p
Płatności w PLN 373 linia bez parametru
Czeki w sejfie : ############ 374 alfanum-p
Czeki w kasie : ############ 375 alfanum-p
RAZEM ############# 376 alfanum-p
Vouch. w sejfie : ############ 377 alfanum-p
Vouch. w kasie : ############ 378 alfanum-p
RAZEM ############# 379 alfanum-p
Gotówka w sejfie : ############ 380 alfanum-p
Gotówka w kasie : ############ 381 alfanum-p
RAZEM ############# 382 alfanum-p
Płatności w dewizach 383 linia bez parametru
DM w sejfie : ############ 384 alfanum-p
DM w kasie : ############ 385 alfanum-p
RAZEM ############# 386 alfanum-p
USD w sejfie : ############ 387 alfanum-p
USD w kasie : ############ 388 alfanum-p
RAZEM ############# 389 alfanum-p
GBP w sejfie : ############ 390 alfanum-p
GBP w kasie : ############ 391 alfanum-p
RAZEM ############# 392 alfanum-p

Sejf 393 linia bez parametru
Nr schowka #### 394 alfanum-p
Gotówka w PLN : ############ 395 alfanum-p
```
Czeki : ############ 396 alfanum-p
```
```
Voucher : ############ 397 alfanum-p
```
```
DM : ############ 398 alfanum-p
```
```
USD : ############ 399 alfanum-p
```
```
GBP : ############ 400 alfanum-p
```
Rozliczenie kasjera 401 linia bez parametru
Czeki w kasie : ############ 402 alfanum-p
Zliczono czeki : ############ 403 alfanum-p
RÓŻNICA ############ 404 alfanum-p
Vouch. w kasie : ############ 405 alfanum-p
Zlicz. vouch. : ############ 406 alfanum-p
RÓŻNICA ############ 407 alfanum-p
Gotówka w PLN : ############ 408 alfanum-p
Zliczono gotów. : ############ 409 alfanum-p
RÓŻNICA ############ 410 alfanum-p
DM w kasie : ############ 411 alfanum-p
DM zliczono : ############ 412 alfanum-p
RÓŻNICA ############ 413 alfanum-p
USD w kasie : ############ 414 alfanum-p
USD zliczono : ############ 415 alfanum-p
RÓŻNICA ############ 416 alfanum-p
GBP w kasie : ############ 417 alfanum-p
GBP zliczono : ############ 418 alfanum-p
RÓŻNICA ############ 419 alfanum-p
Zmiana zamknięta 420 alfanum-p
Zmiana nr ### 421 alfanum-p
```
Kasjer: #################### 422 alfanumeryczny
```
```
Numer:###### 423 alfanum-p
```
```
Komu: ################### 424 alfanumeryczny
```
TYTUŁ WPŁATY/WYPŁATY ILE 425 linia bez parametru
Przedpłata do par.nr ############# 426 alfanum-p
Zabezpieczenie ############# 427 alfanum-p
Do zafakturowania ############# 428 alfanum-p
Bilon ############# 429 alfanum-p
Wpłata 1 ############# 430 alfanum-p
Wpłata 2 ############# 431 alfanum-p
Sejf ############# 432 alfanum-p
Wypłata 1 ############# 433 alfanum-p
Wypłata 2 ############# 434 alfanum-p
Do banku ############# 435 alfanum-p
Bilon ############# 436 alfanum-p
Wypłata ############# 437 alfanum-p
Razem ############# 438 alfanum-p
Powyższą kwotę otrzymałem 439 alfanum-p
--------------------------- 440 alfanum-p
PODPIS 441 alfanum-p
Pompa ## ##### stan ################lit. 442 wszystkie alfanum-p
Ogółem liczniki 443 alfanum-p
Paliwo ############################lit. 444 alfanum-p
Nr Gatunek Obj. zb. Rezerwa Alarm 445 linia bez parametru
## ########## ######## ##### ######## 446 wszystkie alfanum-p, +
Numer transakcji: ##### 447 alfanum-p
```
Data: ######## Godzina: #### 448 alfanum-p, alfanum-p
```
Nazwa karty: ################# 449 alfanumeryczny
Numer karty: #################### 450 alfanum-p
Transakcja karty: ###### 451 alfanum-p
Numer autoryzacji: ###### 452 alfanum-p
Identyfikator autoryzacji: ####### 453 alfanum-p
Lp. Nazwa jm Ilość 454 linia bez parametru
## ############## ### ####### 455 alfanum-p, alfanum., alfanum., alfanum-p, +
```
KWOTA: ########## 456 alfanum-p
```
........................................ 457 linia bez parametru
podpis 458 linia bez parametru
```
Posiadacz: ######################### 459 alfanumeryczny
```
Dane ident.: ######################### 460 alfanumeryczny
Dane ident.: ######################### 461 alfanumeryczny
```
Przebieg: ############### 462 alfanum-p
```
Kod kierowcy: ########## 463 alfanum-p
Nr rej.: ################## 464 alfanumeryczny
OGÓŁEM GOTÓWKA W SEJFIE : ########## 465 alfanum-p
### ########## W SEJFIE : ########## 466 wszystkie alfanum-p

OGÓŁEM CZEKI W SEJFIE : ########## 467 alfanum-p
OGÓŁEM VOUCHERY W SEJFIE : ########## 468 alfanum-p
OGÓŁEM W SEJFIE : ########## 469 alfanum-p
NUMER SKRYTKI ############### 470 alfanum-p
Zbiornik nr ####### 471 alfanum-p
Paliwo opis ################# 472 alfanum-p
RODZAJ ALARMU: 473 linia bez parametru
############################## 474 alfanum-p, +
############################## 475 alfanum-p, +
############################## 476 alfanum-p, +
DATA ############## 477 alfanum-p,
CZAS ######### 478 alfanum-p
WAŻNY NA ## PROGRAM NR ## ZŁ ###### 479 wszystkie alfanum-p
W CELU URUCHOMIENIA MYJNI WPROWADŹ 480 linia bez parametru
KOD PROGRAMU 481 linia bez parametru
```
KOD : ############### 482 dowolny, podwójna szer., wycentrowane
```
WYDANY W DNIU ############ CZAS ######## 483 alfanum-p, alfanum-p
ZAPRASZAMY DO KORZYSTANIA 484 linia bez parametru
Z NASZYCH MYJNI 485 linia bez parametru
MODUŁ: ### POZYCJA:### SONDA NR #### 486 alfanum., alfanum-p, alfanum-p
```
OPIS: ################################ 487 alfanumeryczny
```
```
PRODUKT: ############################# 488 alfanumeryczny
```
POZIOM OBJĘTOŚĆ 489 linia bez parametru
```
(CM) (LTR) 490 linia bez parametru
```
POJEMNOŚĆ ########## ############ 491 alfanum-p, alfanum-p
```
PRODUKT : ########## ############ 492 alfanum-p, alfanum-p
```
```
WODA : ########## ############ 493 alfanum-p, alfanum-p
```
```
RAZEM : ########## ############ 494 alfanum-p, alfanum-p
```
KOREKTA O TEMPERATURĘ 495 linia bez parametru
```
PRODUKT : ####################### 496 alfanum-p
```
```
WODA : ####################### 497 alfanum-p
```
```
RAZEM : ####################### 498 alfanum-p
```
MAX.POZIOM NAPEŁ: ###################### 499 alfanum-p
MAX.DO NAPEŁNIENIA: #################### 500 alfanum-p
ŚREDNIA TEMPERATURA PRODUKTU: ########## 501 alfanum-p
```
ZBIORNIK: ####### 502 alfanum-p
```
```
OZNACZENIE: ###### PRODUKT: ############ 503 alfanum-p, alfanum-p
```
RAPORT DOSTAWY – STABILNYCH 504 linia bez parametru
PRZED DOSTAWĄ 505 linia bez parametru
OBJĘTOŚĆ PRODUKTU: ################### 506 alfanum-p
OBJĘTOŚĆ WODY: ################### 507 alfanum-p
OBJ. DO WYPEŁ.: ################### 508 alfanum-p
TEMPERATURA PRODUKTU: ################ 509 alfanum-p
PO DOSTAWIE 510 linia bez parametru
OBJĘTOŚĆ PRODUKTU: ################### 511 alfanum-p
OBJĘTOŚĆ WODY: ################### 512 alfanum-p
MAX. DO WYPEŁ.: ################### 513 alfanum-p
TEMPERATURA PRODUKTU: ################ 514 alfanum-p
DOSTAWA 515 linia bez parametru
```
DATA: ############ CZAS: ############# 516 alfanum-p, alfanum-p
```
OBJĘTOŚĆ: ################## 517 alfanum-p
TEMPERATURA ################## 518 alfanum-p
```
DOSTAWA NETTO(15C): ################## 519 alfanum-p
```
TEMPERATURA PRODUKTU: ################ 520 alfanum-p
KSIĘGOWA OBJ.DOSTAWY:################# 521 alfanum-p
ROZBIEŻNOŚĆ: ################## 522 alfanum-p
Nr terminala nazwa stacji 523 linia bez parametru
######### ###################### 524 alfanum-p, alfanumeryczny, +
Nr kolejny ############## 525 alfanum-p
Kod terminala ############## 526 alfanum-p
Operator ###################### 527 alfanum-p
Czas rozpoczęcia ######### 528 alfanum-p
Data rozpoczęcia ############## 529 alfanum-p
Czas zakończenia ######### 530 alfanum-p
Data zakończenia ############## 531 alfanum-p
Tariff PKT man. TR. man. 532 linia bez parametru
TAR ##: ########################### 533 alfanum-p, alfanum-p
% Wydania ###################### 534 alfanum-p
Litry sprzedane ###################### 535 alfanum-p
Litry wydane ###################### 536 alfanum-p
DAR ###################### 537 alfanum-p
Punkty wymienione ###################### 538 alfanum-p
Punkty wczytane ###################### 539 alfanum-p
Trans. Wydano ###################### 540 alfanum-p

Nr terminala nazwa stacji 541 linia bez parametru
######### ###################### 542 alfanum-p, alfanumeryczny, +
Ilość ######### Podarunek numer ####### 543 alfanum-p, alfanum-p
Punktów za podarunek ############## 544 alfanum-p
Razem punkty z podarunek ############## 545 alfanum-p
Numer karty ######################### 546 alfanum-p
Punkty początkowe ############## 547 alfanum-p
Punkty skasowane ############## 548 alfanum-p
Nowych punktów razem ############## 549 alfanum-p
Nazwa ################################## 550 alfanumeryczny
Dziękujemy. Do zobaczenia. 551 linia bez parametru
Nr terminala ############## 552 alfanum-p
Kod sprzedawcy ############## 553 alfanum-p
Data ############# Kasjer nr ######### 554 alfanum-p, alfanum-p
Czas ########## 555 alfanum-p
Czas ########## Data ################# 556 alfanum-p, alfanum-p
Ilość ########## Podarunek numer ####### 557 alfanum-p, alfanum-p
Punktów za podarunek ############## 558 alfanum-p
Razem punkty z podarunek ############## 559 alfanum-p
Nazwa ################################## 560 alfanumeryczny
```
Kelner: ################################ 561 alfanumeryczny
```
```
Stolik: ################################ 562 alfanumeryczny
```
- - - - - - - - - - - - - - - - - - - - 563 linia bez parametru
```
Towar: ################################# 564 alfanumeryczny
```
```
Opis: ################################## 565 alfanumeryczny
```
Ilość: ################################# 566 alfanumeryczny
Potwierdzenie ########################## 567 alfanumeryczny
Raport ################################# 568 alfanumeryczny
Pokwitowanie ########################### 569 alfanumeryczny
Bon #################################### 570 alfanumeryczny
Wydruk ################################# 571 alfanumeryczny
Tytuł ################################## 572 alfanumeryczny
Część ################################## 573 alfanumeryczny
Blok ################################### 574 alfanumeryczny
Kasjer ################# Kasa ########## 575 alfanumeryczny, alfanumeryczny
Data ################ Godzina ########## 576 alfanumeryczny, alfanumeryczny
Opis ################################### 577 alfanumeryczny
Nazwa ################################## 578 alfanumeryczny
Numer ################################## 579 alfanumeryczny
Tytułem ################################ 580 alfanumeryczny
Kod #################################### 581 alfanumeryczny
Liczba ################################# 582 alfanumeryczny
Typ #################################### 583 alfanumeryczny
Stan ################################### 584 alfanumeryczny
Zmiana ################################# 585 alfanumeryczny
Z ###################################### 586 alfanumeryczny
Na ##################################### 587 alfanumeryczny
Konto ################################## 588 alfanumeryczny
Kurs ################################### 589 alfanumeryczny
Operator ############################### 590 alfanumeryczny
Dla #################################### 591 alfanumeryczny
Klient ################################# 592 alfanumeryczny
cd. #################################### 593 alfanumeryczny
Ilość ################################## 594 alfanumeryczny
Wpłata ################################# 595 alfanumeryczny
Wypłata ################################ 596 alfanumeryczny
Opłata ################################# 597 alfanumeryczny
Dopłata ################################ 598 alfanumeryczny
Przedpłata ############################# 599 alfanumeryczny
Prowizja ############################### 600 alfanumeryczny
Odsetki ################################ 601 alfanumeryczny
Kwota ################################## 602 alfanumeryczny
Przychody ############################## 603 alfanumeryczny
Rozchody ############################### 604 alfanumeryczny
Sprzedaż ############################### 605 alfanumeryczny
Uznanie ################################ 606 alfanumeryczny
Saldo ################################## 607 alfanumeryczny
Gotówka ################################ 608 alfanumeryczny
Opakowanie ############################# 609 alfanumeryczny
Rabat ################################## 610 alfanumeryczny
Narzut ################################# 611 alfanumeryczny
Promocja ############################### 612 alfanumeryczny
Premia ################################# 613 alfanumeryczny
Płatność ############################### 614 alfanumeryczny

Forma ################################## 615 alfanumeryczny
Środek płat. ########################### 616 alfanumeryczny
Transakcja anulowana 617 linia bez parametru, wycentrowana
Proszę obciążyć moje konto 618 linia bez parametru, wycentrowana
Proszę uznać moje konto 619 linia bez parametru, wycentrowana
Oryginał 620 linia bez parametru, wycentrowana
Kopia 621 linia bez parametru, wycentrowana
..................... 622 linia bez parametru, wycentrowana
Podpis ################################# 623 alfanumeryczny
Sprawdził ############################## 624 alfanumeryczny
Zatwierdził ############################ 625 alfanumeryczny
Tytuł ################################## 626 alfanumeryczny,
linia wycentrowana, podwójna wysokość
Tytuł ############## 627 alfanumeryczny,
linia wycentr., podwójna szer.
Tytuł ############## 628 alfanumeryczny,
linia wycentr., podw. szer. i wysokość
Kod Nazwa ###################### Grupa 629 alfanumeryczny
##### ################################## 630 alfanumeryczne, +
################################## ##### 631 alfanumeryczne, +
Forma ####################### Uwagi 632 alfanumeryczny
########## ############################# 633 alfanumeryczne, +
############################# ########## 634 alfanumeryczne, +
Słownie: ############################### 635 alfanumeryczny
############################### 636 alfanumeryczny, +
Nr transakcji ########################## 637 alfanumeryczny
Nr biletu ############################## 638 alfanumeryczny
Tytuł ################################## 639 alfanumeryczny
####-##-## ##:## 640 wszystkie alfanum-p
Cena biletu ############################ 641 alfanumeryczny
Bilet ################################## 642 alfanumeryczny
Ilość biletów ########################## 643 alfanumeryczny
Opis miejsc ############################ 644 alfanumeryczny
Sektor ################################# 645 alfanumeryczny
```
Sala: ######## Rząd: ##### Miejsce: #### 646 alfanumeryczne
```
Sala ################################### 647 alfanumeryczny
Rząd: ##### Miejsca: ################### 648 alfanumeryczne
Nr rezerwacji: ######################### 649 alfanumeryczny
MIEJSCA NIENUMEROWANE 650 linia bez parametru, wycentrowana
Numer ewidencyjny: ##################### 651 alfanum-p
Deklarowana kwota: ##################### 652 alfanum-p
Nr transakcji: ######################### 653 alfanum-p
Data generacji kodu: ################### 654 alfanum-p
Wprowadź do licznika: ################## 655 alfanum-p
Twój nowy kod: ######################### 656 alfanum-p
PROSIMY O SPRAWDZENIE ORAZ AKCEPTACJĘ 657 podwójna linia bez parametru, wycentrowana,
ROZLICZENIA !
```
Energia: ############################### 658 alfanum-p
```
Przesył zmienny: ####################### 659 alfanum-p
Przesył stały: ######################### 660 alfanum-p
Opłaty stałe: ########################## 661 alfanum-p
Kwota prowizji: ######################## 662 alfanum-p
Razem do zapłaty: ###################### 663 alfanum-p
################ ####################### 664 alfanumeryczny, alfanumeryczny, +
############################# ########## 665 alfanumeryczny, alfanumeryczny, +
*** RAZEM WPŁATA ############# 666 alfanumeryczny
*** RAZEM WYPŁATA ############# 667 alfanumeryczny
*** RAZEM POLICZONE ############# 668 alfanumeryczny
PODPIS KASJERA 669 linia bez parametru
- - - - - - - - - - - - - - - - - 670 linia bez parametru
```
WALUTA: ### 671 alfanumeryczny
```
####### x ###### = ############ ### 672 alfanumeryczne
RAZEM ############### ### 673 alfanumeryczne
Numer płatności: 674 linia bez parametru
######################################## 674 alfanum-p
Numer kontrolny: 675 linia bez parametru
######################################## 675 alfanum-p
Kod kreskowy: 676 linia bez parametru
######################################## 676 alfanum-p
Wartość: ### ################## 677 alfanumeryczne
Opłata: ### ################## 678 alfanumeryczne
Razem do zapłaty: ### ################## 679 alfanumeryczne
```
TID: ################################### 680 alfanumeryczny
```
```
MID: ################################### 681 alfanumeryczny
```

```
UID: ################################### 682 alfanumeryczny
```
```
AIC: ################################### 683 alfanumeryczny
```
```
AID: ################################### 684 alfanumeryczny
```
```
GROC: ################################## 685 alfanumeryczny
```
```
ATC: ################################### 686 alfanumeryczny
```
Wystawca faktury: 687 linia bez parametru
######################################## 687 alfanum-p
Tytułem: ############################### 688 alfanum-p
PROSZĘ ZACHOWAĆ POTWIERDZENIE 689 linia bez parametru, wycentrowana
OBSŁUGA KLIENTA: ####################### 690 alfanumeryczny
```
Dla: 691 linia bez parametru
```
######################################## 691 alfanum-p
Zapłata rachunku nr: ################### 692 alfanumeryczny
DCC TRANSACTION 693 linia bez parametru, wycentrowana
```
Acquirer: ############################## 694 alfanumeryczny
```
```
Sale: ############## ### 695 alfanumeryczne
```
Exchange rate: 696 linia bez parametru
############## ### = ############## ### 697 alfanumeryczne
I have chosen not to use the 698 linia bez parametru, wycentrowana
#################### currency conversion 699 alfanumeryczny, tekst wycentrowany
niezależnie od dług.
process and agree that I will have no 700 linia bez parametru, wycentrowana
recourse against #################### 701 alfanumeryczny, tekst wycentrowany
niezależnie od dług.
concerning the currency conversion or 702 linia bez parametru, wycentrowana
its disclosure. 703 linia bez parametru, wycentrowana
PLEASE DEBIT MY ACCOUNT 704 linia bez parametru, wycentrowana
Kod Nazwa ###################### Grupa 705 alfanumeryczny
##### ################################## 706 alfanumeryczny, alfanumeryczny, +
################################## ##### 707 alfanumeryczny, alfanumeryczny, +
Forma ####################### Uwagi 708 alfanumeryczny
########## ############################# 709 alfanumeryczny, alfanumeryczny, +
############################# ########## 710 alfanumeryczny, alfanumeryczny, +
|######################################| 711 alfanumeryczny, +
```
Uwagi:
```
1. Parametry wyrównane do prawej mogą być w całości przeniesione do następnej linii, jeśli nie
mieszczą się w pierwszej.
2. Linie oznaczone „+” kontrolowane są pod kątem wystąpienia napisu „Paragon fiskalny”. Jeśli
napis ten wystąpi zwracany jest błąd a linia nie jest drukowana.
201 – Formatka szeroka
Formatka do wydruku tylko na papierze 80 mm
DOKUMENT NIEFISKALNY 0 – nagłówek – może zawierać dodatkowy
opis – patrz: opis polecania formstart
```
1 – nagłówek, (pusty)
```
|######################################################| 0 alfanumeryczny
Kod Nazwa ###################################### Grupa 1 alfanumeryczny
##### ################################################## 2 alfanumeryczny
################################################## ##### 3 alfanumeryczny
Forma ####################################### Uwagi 4 alfanumeryczny
########## ############################################# 5 alfanumeryczny
############################################# ########## 6 alfanumeryczny
Numer ID ######################## Opis 7 alfanumeryczny
############### ######################################## 8 alfanumeryczny
######################################## ############### 9 alfanumeryczny
Oddział ########################################## Adres 10 alfanumeryczny
#################### ################################### 11 alfanumeryczny
################################### #################### 12 alfanumeryczny
Dystrybutor ############### Stanowisko ################ 13 alfanumeryczny
############################ ########################### 14 alfanumeryczny
```
Uwagi:
```
1. Linie można powielać i przestawiać.
2. Formatka do wydruku tylko na papierze 80 mm
3. Formatka niedostępna w drukarce Temo, Trio, Vero, Evo, Fawag Box.

Kontrola bazy danych
## [dbchkstart] Rozpoczęcie kontroli bazy danych
Identyfikator polecenia:
dbchkstart
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty 1 – raport kontroli bazy PLU
2 – raport towarów zablokowa-
nych
TAK Num.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. W wyniku działania sekwencji na wydruku w polu "PTU:DRUKARKA" drukowana jest
stawka PTU towaru w bazie towarowej.
2. Definicja towaru zablokowanego:towar zablokowany to towar dla którego obniżono stawkę,
można go sprzedawać w stawce obniżonej, ale nie można w stawce wyższej.
Przykład:
Towar1 był sprzedany w stawce 23%, następnie 8%. Towar jest zablokowany. Nie można go
```
sprzedawać w stawce większej niż 8% (czyli również 23%). Można nadal sprzedawać towar
```
w 8%. W przypadku gdyby został sprzedany w stawce 3%, nie będzie można go sprzedawać
w stawce 8%.
3. Sekwencja działa w powiązaniu z sekwencjami dbchkline, dbchkend.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dbchkstart[TAB]ty1[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:745|
| N I E F I S K A L N Y |
| Raport kontroli bazy |
| PLU |
|PLU/NR PTU:BAZA PTU:DRUKARKA|
|- - - - - - - - - - - - - - - - - - - - |
|Mleko |
|000001 B 8,00 % |
|Ser |
|000002 B NIEAKTYWNA ?|

|Dzbanek |
|000003 A 8,00 % |
|- - - - - - - - - - - - - - - - - - - - |
|Ilość towarów: 3|
|Ilość różnic: 2|
|#11 Wojtek 2018-08-29 10:58|
|81D11376166B28A21BE4D0C8A459D42323CFB82E|
| ZBF 1801007587 |

## [dbchkline] Linia kontroli bazy danych
Identyfikator polecenia:
dbchkline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
vt Stawka sprawdzanego towaru TAK Num. Numer z zakresu: 0-6
na Nazwa sprawdzanego towaru TAK Alfanum. Do 80 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Sekwencja działa w powiązaniu z sekwencjami dbchkstart, dbchkend.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dbchkline[TAB]vt0[TAB]naMLEKO[TAB]#CRC16[ETX]
```

## [dbchkend] Koniec kontroli bazy danych
Identyfikator polecenia:
dbchkend
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]dbchkend[TAB]#CRC16[ETX]
```

## [dbchkplu] Pytanie o możliwość sprzedaży towaru
Identyfikator polecenia:
dbchkplu
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
vt Stawka vat towaru TAK Num. Parametr ignorowany. Powi-
nien przyjmować wartość z za-
```
kresu (0 - 6)
```
na Nazwa towaru TAK Alfanum. Do 80 znaków
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
vv Stawka w jakiej ostatnio sprze-
dawany był towar.
- Num. 101,00 – oznacza że towar nie
był jeszcze sprzedawany.
bl Flaga określająca możliwość
sprzedaży towaru w stawce wyż-
szej od wartości pola „vv”
- Bool True – towar zablokowany, brak
możliwości sprzedaży w stawce
wyższej.
False – towar nie jest zablokowa-
ny, jest możliwość sprzedaży w
stawce wyższej.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład odpowiedzi:
```plaintext
[STX]dbchkplu[TAB]vv101,00[TAB]blN[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]dbchkplu[TAB]vt1[TAB]naMLEKO[TAB]#CRC16[ETX]
```

## [dbtrdelall] Usunięcie wszystkich rekordów z bazy towarów
Identyfikator polecenia:
dbtrdelall
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Bieżąca data do potwierdzenia
operacji
TAK Data
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Dostępność w trybie transakcji: NIE
3. Operacja wymaga potwierdzenia poprzez wciśniecie zwory serwisowej po ukazaniu się ko-
munikatu na wyświetlaczu drukarki.
Przykład:
```plaintext
[STX]dbtrdelall[TAB]da1982-03-02[TAB]#CRC16[ETX]
```

Transakcja
## [trinit] Rozpoczęcie transakcji
Identyfikator polecenia:
trinit
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
bm Włączenie trybu blokowego NIE Bool True – tryb blokowy
```
False – tryb on-line (domyślnie)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Urządzenie umożliwia wysłanie w rozpoczętej transakcji do 500 pozycji sprzedaży z raba-
tem i opisem towaru.
2. Udane rozpoczęcie transakcji jest możliwe w sytuacji, gdy stan totalizerów dobowych po-
```
zwala na wystawienia paragonu o maksymalnej wartości (nie ma zagrożenia przepełnienia
```
```
któregoś totalizera).
```
3. Anulowanie transakcji w trybie blokowym może spowodować wydruk paragonu anulowa-
```
nego zależnie od konfiguracji (polecenie cancelledsaleprintcfgset).
```
4. Ustawienie trybu online (bm0) w przypadku chęci wystawienia eDokomunetu, zawsze bę-
dzie skutkowało wydrukiem paragonu i przesłaniem dokumentu na wcześniej zaprogramo-
wany adres e-serwera.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trinit[TAB]bm1[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:743|
| PARAGON FISKALNY |
|Mleko 1 x9,99 9,99B|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA B 9,99|
|PTU B 8,00 % 0,74|
|SUMA PTU 0,74|
|SUMA PLN 9,99|

|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 9,99 PLN|
|00001 #11 Wojtek 2018-08-29 10:58|
|5561F35A5FB3114F6B3A5E00354CA957CC7E99AC|
```
| {PL} ZBF 1801007587 |
```

## [trfvinit] Rozpoczęcie faktury vat
Identyfikator polecenia:
trfvinit
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nm Nazwa faktury NIE Num. Do 23 znaków dla parametru
```
ln=40.
```
Do 39 znaków dla parametru
```
ln=56.
```
cc Liczba kopii NIE Num. Zakres 0 – 9. Domyślnie cc=0
co Drukowanie na fakturze napisu
ORYGINAŁ/KOPIA
NIE BOOL True – drukowanie włączone
False – brak drukowania.
Wartość domyślna określana
przez instrukcję fvcfgset.
ln Długość linii danych niefiskal-
nych
```
NIE Num. Przyjmuje wartość 40 (domyśl-
```
```
nie) lub 56 (tylko dla trybu 56
```
```
znaków w linii).
```
Dane niefiskalne przesyłane w
poleceniu trfvfreedata.
```
fn Długość linii danych fiskalnych NIE Num. Przyjmuje wartość 40 (domyśl-
```
```
nie) lub 56 (tylko dla trybu 56
```
```
znaków w linii)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Udane rozpoczęcie faktury jest możliwe w sytuacji, gdy stan totalizerów dobowych pozwala
```
na wystawienia faktury o maksymalnej wartości (nie ma zagrożenia przepełnienia któregoś
```
```
totalizera).
```
2. Po rozpoczęciu transakcji należy wysłać niezbędne dane za pomocą rozkazów trfvbuyer i
trfvnumber.
3. Po rozpoczęciu faktury nie można dokonywać: obrotu opakowaniami, używać form płatno-
```
ści, stornowań, rabatów (dozwolonym rabatem jest rabat w linii transakcji w poleceniu trli-
```
```
ne).
```
4. Wartość domyślna parametru co jest ustawiana przez rozkaz fvcfgset, która obowiązuje w
przypadku gdy nie przesyła się go w rozpoczęciu faktury. W czasie transakcji obowiązujące
są ustawienia przesyłane rozkazem trfvinit.

5. Anulowanie transakcji może spowodować wydruk faktury anulowanej zależnie od konfigu-
```
racji (polecenie cancelledsaleprintcfgset).
```
6. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trfvinit[TAB]nmNazwa_faktury[TAB]cc1[TAB]co1[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|FAKTURA 98765 |
| ORYGINAŁ |
|nr: 98765 |
|Nabywca: |
| Jan Kowalski |
|Warszawa ul.Śliwkowa 12 |
|NIP: 123-456-78-90 |
|Sprzedawca: |
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
| NIP: 5222628262 |
|- - - - - - - - - - - - - - - - - - - - |
|towar1 |
| opis_towaru |
| 1 x 10,00 10,00|
| PTU A 23,00 % 1,87|
| Wartość netto: 8,13|
|- - - - - - - - - - - - - - - - - - - - |
|VAT% w.netto w.VAT w.brutto|
|- - - - - - - - - - - - - - - - - - - - |
|A 23 8,13 1,87 10,00|
|RAZEM 8,13 1,87 10,00|
|- - - - - - - - - - - - - - - - - - - - |
|Do zapłaty PLN 10,00 |
|Słownie: |
|dziesięć PLN 0/100 |
|0000002 #001 KIEROWNIK 2018-08-29 12:09|
|7DDC5F2DDBC60E43F4D294BC766EECE051353CF7|
```
| {PL} ZBF 1801007587 |
```

## [trfvbuyer] Dane nabywcy
Identyfikator polecenia:
trfvbuyer
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa nabywcy TAK Alfanum. Długość pola 1-256 znaków.
Podziału linii dokonuje się za
pomocą znaku LF.
ni Numer NIP TAK Alfanum. Długość pola 1-20 znaków
ad Adres nabywcy NIE Alfanum. Pole może składać się z nie
więcej niż 256 znaków.
Podziału linii dokonuje się za
pomocą znaku LF.
sc Sekcja w której ma być umiesz-
czona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
2. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
[STX]trfvbuyer[TAB]naSKLEP[TAB]ni222-333-44-55[TAB]adMostowa
123[TAB]sc0[TAB]#CRC16[ETX]

## [trfvnumber] Numer faktury VAT
Identyfikator polecenia:
trfvnumber
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nb Numer faktury TAK Alfanum. Długość parametru 1-40 zna-
ków. Parametr nie może zawie-
rać samych spacji.
sc Sekcja w której ma być umiesz-
czona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
2. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvnumber[TAB]nb12[TAB]sc0[TAB]at0#CRC16[ETX]
```

## [trfvfreedata] Niefiskalne dane w fakturze
Identyfikator polecenia:
trfvfreedata
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tx Treść linii TAK Alfanum. W zależności od deklara-
cji w rozpoczęciu faktury
```
(trfvinit parametr ln),
```
maksymalna długość linii
to 40 lub 56 znaków.
sc Sekcja w której ma być umiesz-
czona linia
NIE Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami trfvinit a trend.
2. Wartości wszystkich pól kasowane są po wysłaniu komendy trfvinit.
3. Na fakturze można umieścić do 100 linii niefiskalnych.
4. W treści linii można używać znaków formatujących tak jak w poleceniu hdrset czy ftrinfo-
set. Treść linii oraz znaki formatujące nie mogą przekroczyć 64 znaków.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trfvfreedata[TAB]txWX 12345[TAB]sc1[TAB]#CRC16[ETX]
```

## [trfvsep] Separator
Identyfikator polecenia:
trfvsep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sc Sekcja w której ma być umiesz-
czona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Separatorem jest linia złożona z samych kropek.
Przykład:
```plaintext
[STX]trfvsep[TAB]sc0[TAB]#CRC16[ETX]
```

## [trfvcashmet] Metoda kasowa
Identyfikator polecenia:
trfvcashmet
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
cm Drukowanie pola „Metoda ka-
sowa”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvcashmet[TAB]cm1[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvselfbill] Samofakturowanie
Identyfikator polecenia:
trfvselfbill
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sb Drukowanie pola „Samofaktu-
rowanie”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvselfbill[TAB]sb1[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvreverse] Odwrotne obciążenie
Identyfikator polecenia:
trfvreverse
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
re Drukowanie pola „Odwrotne
obciążenie”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvreverse[TAB]re1[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvfree] Zwolnienie podatkowe
Identyfikator polecenia:
trfvfree
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
fr Drukowanie pola „Podstawa
```
zwolnienia:”
```
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
ba Uzasadnienie zastosowanego
zwolnienia podatkowego.
NIE Alfanum. Do 256 znaków.
Jeśli fr = True, parametr jest wyma-
gany.
Tekst można podzielić na 15 linii za
pomocą znaku LF. Nadmiarowe
znaki LF są ignorowane.
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd czcion-
```
ki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvfree[TAB]fr1[TAB]baArt. 43 ust. 1[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvexecution] Egzekucja
Identyfikator polecenia:
trfvexecution
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ex Drukowanie pól „Egzekucja” TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
ed Dane organu egzekucyjnego NIE Alfanum. Do 600 znaków. Jeśli ex = True,
parametr jest wymagany.
dd Dane dłużnika NIE Alfanum. Do 600 znaków. Jeśli ex = True,
parametr jest wymagany.
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
[STX]trfvexecution[TAB]ex1[TAB]edOrganEgzekucyjny[TAB]ddDłużnik[TAB]sc0[TAB]at64
[TAB]#CRC16[ETX]

## [trfvrep] Przedstawiciel
Identyfikator polecenia:
trfvrep
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
re Drukowanie pola „Dane przed-
stawiciela”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
rd Dane przedstawiciela NIE Alfanum. Do 256 znaków.
Jeśli re = True, parametr jest wyma-
gany.
Tekst można podzielić na 15 linii za
pomocą znaku LF. Nadmiarowe
znaki LF są ignorowane.
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd czcionki:
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvrep[TAB]re1[TAB]rdPrzedstawiciel[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvtransport] Środek transportu
Identyfikator polecenia:
trfvtransport
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tr Drukowanie pól „Środek trans-
portu”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
ad Data dopuszczenia pojazdu NIE Alfanum. Format YYYY-MM-DD. Jeśli tr
= True, parametr jest wymagany.
mi Przebieg pojazdu NIE Num. Przebieg pojazdu w kilometrach
- w przypadku pojazdów lądo-
wych, o których mowa w art. 2
pkt 10 lit. a ustawy. Do 22 zna-
ków, w tym 3 po przecinku. Se-
paratorem części ułamkowej mu-
si być przecinek.
hr Liczba godzin roboczych NIE Num. Liczba godzin roboczych używa-
nia nowego środka transportu -
w przypadku jednostek pływają-
cych, o których mowa w art. 2
pkt 10 lit. b, oraz statków po-
wietrznych, o których mowa w
art. 2 pkt 10 lit. c ustawy. Zakres
0 - 4294967295
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```

```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
```c
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
[STX]trfvtransport[TAB]tr1[TAB]ad2011-11-11[TAB]mi123456[TAB]
hr56789[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]

## [trfvthreeway] Transakcja trójstronna
Identyfikator polecenia:
trfvthreeway
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
tw Drukowanie pola „Dane trans-
akcji trójstronnej”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
td Dane transakcji trójstronnej NIE Alfanum. Do 256 znaków.
Jeśli tw = True, parametr jest wyma-
gany.
Tekst można podzielić na 15 linii za
pomocą znaku LF. Nadmiarowe
znaki LF są ignorowane.
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd czcion-
```
ki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvthreeway[TAB]tw1[TAB]tdTransakcja3[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvtoursrv] Usługa turystyczna
Identyfikator polecenia:
trfvtoursrv
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ts Drukowanie pola „Procedura
marży dla biur podróży”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
3. Dostępność w trybie tylko do odczytu: NIE.
```
Przykład:
```plaintext
[STX]trfvtoursrv[TAB]ts1[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]
```

## [trfvothergoods] Towary inne
Identyfikator polecenia:
trfvothergoods
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
og Drukowanie pola „Procedura
marży dla towarów innych”
TAK BOOL True – drukowanie aktywne
False – drukowanie nieaktywne
gd Dozwolone wartości parame-
```
tru:
```
„Procedura marży - towary
używane”
„Procedura marży - dzieła
sztuki”
„Procedura marży - przedmio-
ty kolekcjonerskie i antyki”
NIE Alfanum. Dozwolone zamiennie małe i
wielkie litery. Jeśli og = True,
parametr jest wymagany.
sc Sekcja w której ma być
umieszczona linia
TAK Num. Zakres 0-2
0 – sekcja nagłówka
1 – sekcja danych
2 – sekcja stopki
at Atrybuty linii wydruku NIE Num. Bity wpływające na wygląd
```
czcionki:
```
```c
0x01 – szeroka czcionka
0x02 – wysoka czcionka
0x04 – podkreślenie
0x08 – kursywa
0x10 – pogrubienie
0x20 – zanegowanie
0x40 – wyśrodkowanie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda powinna wystąpić pomiędzy komendami „trfvinit” a „trend”.
2. W rozkazie mogą wystąpić wszystkie dozwolone wartości parametru gd – rozdzielone zna-
```
kiem nowej linii (LF).
```
3. Wartość parametru at może być sumą poszczególnych stylów czcionki np.: at = 68 (0x04 +
```
0x40) spowoduje ustawienie czcionki wyśrodkowanej z podkreśleniem.
```
4. Dostępność w trybie tylko do odczytu: NIE.
```

Przykład:
[STX]trfvothergoods[TAB]og1[TAB]gdProcedura marży - TOWARY UŻYWANE[LF]Procedura
marży - dzieła sztuki[TAB]sc0[TAB]at64[TAB]#CRC16[ETX]

## [trline] Linia transakcji
Identyfikator polecenia:
trline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa towaru TAK Alfanum. Do 80 znaków.
```
vt Stawka VAT TAK Num. Podaje się numer stawki (0 - 6)
```
pr Cena TAK Kwota Zakres 1 – 499 999 999 999
```
st Flaga stornowania NIE BOOL False - brak stornowania (do-
```
```
myślnie)
```
True - stornowanie
```
wa Kwota total (cena x ilość) NIE Kwota Kwota total nie może przekro-
```
czyć zakresu 9 999 999 999
il Ilość towaru NIE Num. Domyślnie 1,000
Zakres 0,00000001 – 9 999 999
999
op Opis towaru NIE Alfanum. Domyślnie pusty. Do 50 znaków
jm Jednostka miary NIE Alfanum. Do 4 znaków
```
rd Rabat(True)/narzut(False) NIE BOOL Domyślnie rabat
```
rn Nazwa rabatu/narzutu NIE Alfanum. Domyślnie pusta. Do 25 znaków
rp Wartość rabatu/narzutu procen-
towego
NIE Num. Do 99,99%
Nie przesyła się separatora czę-
ści ułamkowej – określają ją
dwie ostatnie cyfry
rw Wartość rabatu/narzutu kwoto-
wego
NIE Kwota
np PKWiU NIE Alfanum Tylko na fakturze – do 49 zna-
ków
nc Kod towaru NIE Alfanum Tylko na fakturze.
Do 51 znaków. Kody których wy-
drukowanie przekracza możliwości
mechanizmu drukarki, nie są druko-
wane – bez zgłaszania błędów.
Maksymalne długości kodów moż-
liwych do wydrukowania zbudowa-
nych z cyfr to 51 znaków dla urzą-
dzeń Thermal i 50 znaków dla Te-
mo, Trio, Pospay, Vero, Evo, Fawag

Box.
Dla kodów w których użyte są inne
znaki poza cyframi, maksymalna
długość kodu możliwa do wydruko-
wania może być mniejsza – zależy
od konfiguracji znaków – wg specy-
fikacji kodu EAN128.
Na fakturze drukowany jest kod
kreskowy oraz ciąg alfanumerycz-
ny.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. W celu udzielenia rabatu/narzutu procentowego należy przesłać pole rp (procent)
2. W celu udzielenia rabatu/narzutu kwotowego należy przesłać pole rw (wartość)
3. Jeżeli oba pola są przesłane, to oznacza że jest to rabat procentowy, a pole wartość jest to
kwota rabatu/narzutu do weryfikacji.
4. Jeżeli żadne pole (rp i rw) nie jest przesłane, to nie ma rabatu/narzutu. Przesłanie niepustego
parametru rn powoduje wydruk linii uwzględniającej rabat: xxxxx lub uwzględniającej na-
```
rzut: xxxxx w zależności od parametru rd (czy rabat).
```
5. Wystąpienie samego pola rd (czy rabat) jest ignorowane.
6. Wystąpienie pola opisu towaru (parametr op) zastępuje wydruk linii uwzględniającej rabat
```
(dotyczy przesłania niepustego parametru rn bez parametrów wartości rp lub rw (patrz:
```
```
uwaga 4)).
```
7. Rabat nie może przekraczać wartości linii sprzedaży (parametr wa).
8. Wartość linii sprzedaży po narzucie nie może przekraczać zakresu parametru wa.
9. Maksymalna liczba linii transakcji to:
• 120 dla faktury,
• 500 dla paragonu.
10. Pole PKWiU jest aktywne tylko dla faktury VAT.
11. Pole Kod towaru jest aktywne tylko dla faktury VAT.
12. Przy rozróżnianiu nazw towarów brane są pod uwagę tylko znaki alfanumeryczne (wielkość
```
liter nie ma znaczenia), kropka, przecinek, procent i kreski ukośne.
```
13. Drukarki posiadają wbudowany mechanizm kontroli stawek VAT. Niedozwolone jest obni-
żanie a następnie zwiększanie stawki VAT przy sprzedaży towaru. W takim przypadku doj-
```
dzie do zablokowania możliwości sprzedaży towaru w nowej wyższej stawce (kod błędu
```
```
2106). Będzie możliwa sprzedaż tylko w poprzedniej stawce lub w stawce niższej niż po-
```
przednia. Więcej informacji w dokumencie: OPIS MECHANIZMU KONTROLI STAWEK
PODATKU W DRUKARKACH FISKALNYCH.
14. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trline[TAB]naMleko[TAB]vt2[TAB]pr245[TAB]#CRC16[ETX]
```

## [trnipset] Drukowanie NIP-u nabywcy
Identyfikator polecenia:
trnipset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ni NIP nabywcy TAK Alfanum. Do 30 znaków. Nie może być
pusty.
dw Drukować jako wyróżnione? NIE BOOL Domyślnie: True
ds Opis poprzedzający numer NIP NIE Alfanum. Do 56 znaków.
Jeśli parametr nie występuje w
rozkazie, na paragonie druko-
wany jest napis „NIP NA-
```
BYWCY:”
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Rozkaz można wysyłać w dowolnym momencie po rozpoczęciu paragonu i przed jego za-
kończeniem.
2. Rozkaz można wysyłać kilkakrotnie. Kolejne wysłanie rozkazu powoduje nadpisanie po-
przednio zapisanych wartości.
3. Wysłanie w parametrze ni samych spacji, powoduje brak wydruku sekcji NIP-u nabywcy
oraz opisu wydruku.
4. Przesłanie rozkazu nie powoduje natychmiastowego wydruku. NIP nabywcy jest drukowany
razem ze stopką wydruku.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trnipset[TAB]ni1112223344[TAB]dw0[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:13|
| PARAGON FISKALNY |
|towar 1 1 x10,00 10,00A|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 10,00|

|PTU A 23,00 % 1,87|
|SUMA PTU 1,87|
|SUMA PLN 10,00|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 10,00 PLN|
|00007 #001 KIEROWNIK |
|NABYWCA: 1112223344|
| 2018-08-29 14:05|
|292A978F4DFD5255C6ED6810619550F587A8889F|
```
| {PL} ZBF 1801007587 |
```

## [fvprncopy] Drukowanie kopii ostatniej faktury
Identyfikator polecenia:
fvprncopy
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie dostępne tylko w drukarce Temo, Trio, Evo i Fawag BOX.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]fvprncopy[TAB]#CRC16[ETX]
```

Rabaty i narzuty
## [trdiscntvat] Rabat w stawce PTU
Identyfikator polecenia:
trdiscntvat
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
vt Identyfikator stawki w której
udzielany jest narzut lub rabat
TAK Num. Jak w rozkazie trline
```
rd Rabat(True)/narzut(False) NIE BOOL Domyślnie rabat
```
rp Wartość procentowa rabatu/na-
rzutu
NIE Num. Jak w rozkazie trline
rw Wartość rabatu/narzutu kwoto-
wego
NIE Kwota Jak w rozkazie trline
na Nazwa rabatu narzutu NIE Alfanum. Do 25 znaków. Domyślnie pu-
sta
rt Kwota do której udzielany jest
rabat/narzut
NIE Kwota
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Oprócz pola vt, w rozkazie musi wystąpić pole rp lub rw.
2. Jeśli występują obydwa pola rp i rw, to rabat/narzut jest procentowy, a parametr rw musi
być równy kwocie, o jaką rabat/narzut zmieni wartość transakcji.
3. Jeśli rt puste, kwota do której udzielany jest rabat/narzut jest wartością totalizera w danej
stawce.
4. Polecenie nie jest dostępne podczas drukowania faktury.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trdiscntvat[TAB]vt0[TAB]rd1[TAB]rp1500[TAB]nastały klient[TAB]#CRC16[ETX]
```
```
Wydruk:
```

| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:19|
| PARAGON FISKALNY |
|Sok owocowy 1 x12,00 12,00A|
|Ciastka czekoladowe 1 x20,00 20,00B|
|OPUST stały klient 15,00 % -1,80A|
|- - - - - - - - - - - - - - - - - - - - |
|OPUSTY ŁĄCZNIE -1,80|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 10,20|
|SPRZEDAŻ OPODATKOWANA B 20,00|
|PTU A 23,00 % 1,91|
|PTU B 8,00 % 1,48|
|SUMA PTU 3,39|
|SUMA PLN 30,20|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 30,20 PLN|
|00013 #001 KIEROWNIK 2018-08-29 14:27|
|9EC684FB873EA213C19C8FE48926BC23EF1402F8|
```
| {PL} ZBF 1801007587 |
```

## [trdiscntline] Rabat narzut do dowolnej linii
Identyfikator polecenia:
trdiscntline
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
vt Identyfikator stawki w której
udzielany jest rabat/narzut i w
której był sprzedany towar
TAK Num. Jak w rozkazie trline
ds Nazwa towaru którego dotyczy
rabat
TAK Alfanum. Do 80 znaków
rt Kwota sprzedaży od której
udzielany jest rabat/narzut
TAK Kwota
st Anulowanie rabatu/narzutu
```
(True) / bez anulowania (False)
```
NIE BOOL Domyślnie False
```
rd Rabat(True)/narzut(False) NIE BOOL Domyślnie rabat
```
rp Wartość rabatu/narzutu procen-
towego
NIE Num. Jak w rozkazie trline
rw Wartość rabatu/narzutu kwoto-
wego
NIE Kwota Jak w rozkazie trline
na Nazwa rabatu/narzutu NIE Alfanum. Domyślnie pusta. Do 25 zna-
ków.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Oprócz pola vt, w rozkazie musi wystąpić pole rp lub rw.
2. Jeśli występują obydwa pola rp i rw, to rabat/narzut jest procentowy, a parametr rw musi
być równy kwocie, o jaką rabat/narzut zmieni wartość transakcji.
3. Polecenie nie jest dostępne podczas drukowania faktury.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trdiscntline[TAB]vt0[TAB]dsCUKIER[TAB]rt111[TAB]rp1000[TAB]#CRC16[ETX]
```
```
Wydruk:
```

| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:42|
| PARAGON FISKALNY |
|CUKIER 1 x1,11 1,11A|
|OPUST 10,00 % -0,11A|
|Do plu: CUKIER|
|- - - - - - - - - - - - - - - - - - - - |
|OPUSTY ŁĄCZNIE -0,11|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 1,00|
|PTU A 23,00 % 0,19|
|SUMA PTU 0,19|
|SUMA PLN 1,00|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 1,00 PLN|
|00005 #001 KIEROWNIK 2018-09-04 10:29|
|4CE3116E2613FE6672884FAFAE41701C2E735B6F|
```
| {PL} ZBF 1801007587 |
```

## [trdiscntpromo] Promocja
Identyfikator polecenia:
trdiscntpromo
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
vt Identyfikator stawki w której
udzielany jest rabat/narzut i w
której był sprzedany towar
TAK Num. Jak w rozkazie trline
rw Wartość promocji TAK Kwota Jak w rozkazie trline
st Anulowanie rabatu/narzutu
```
(True) / bez anulowania (False)
```
NIE BOOL Domyślnie False
na Nazwa promocji NIE Alfanum. Do 25 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie nie jest dostępne podczas drukowania faktury.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trdiscntpromo[TAB]vt1[TAB]rw50[TAB]naStały klient[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:50|
| PARAGON FISKALNY |
|CUKIERKI 1 x2,00 2,00B|
|OBNIŻKA Stały klient -0,50B|
|- - - - - - - - - - - - - - - - - - - - |
|OPUSTY ŁĄCZNIE -0,50|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA B 1,50|
|PTU B 8,00 % 0,11|
|SUMA PTU 0,11|
|SUMA PLN 1,50|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 1,50 PLN|
|00013 #001 KIEROWNIK 2018-09-04 10:45|

|03F6C82D962A6F3B2B0CA8CAA5FCCF7246EA9504|
```
| {PL} ZBF 1801007587 |
```

## [trdiscntsubtot] Rabat narzut do podsumy
Identyfikator polecenia:
trdiscntsubtot
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa rabatu/narzutu NIE Alfanum. Domyślnie pusta. Do 25 zna-
ków.
```
rd Rabat(True)/narzut(False) NIE BOOL Domyślnie rabat
```
rp Wartość rabatu/narzutu procen-
towego
NIE Num. Jak w rozkazie trline
rw Wartość rabatu/narzutu kwoto-
wego
NIE Kwota Jak w rozkazie trline
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Jeśli występują obydwa pola rp i rw, to rabat/narzut jest procentowy, a parametr rw musi
być równy kwocie, o jaką rabat/narzut zmieni wartość transakcji. Brak obu pól powoduje
błąd.
2. Nie można stornować tego rabatu/narzutu, można wykonać operację odwrotną (rabat ↔ na-
```
rzut).
```
3. Polecenie nie jest dostępne podczas drukowania faktury.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trdiscntsubtot[TAB]nastały klient[TAB]rd1[TAB]rp1500[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:55|
| PARAGON FISKALNY |
|Cukierki 1 x10,00 10,00A|
|Ciastka 1 x25,00 25,00A|
|Podsuma: 35,00|
|OPUST stały klient 15,00 % -5,25 |
|Podsuma: 29,75|
|- - - - - - - - - - - - - - - - - - - - |

|OPUSTY ŁĄCZNIE -5,25|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 29,75|
|PTU A 23,00 % 5,56|
|SUMA PTU 5,56|
|SUMA PLN 29,75|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 29,75 PLN|
|00018 #001 KIEROWNIK 2018-09-04 11:07|
|B2232B44A916FFE6CD4CEB7FB33E76E93EC23DC2|
```
| {PL} ZBF 1801007587 |
```

## [trdiscntbill] Rabat narzut od paragonu
Identyfikator polecenia:
trdiscntbill
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa rabatu/narzutu NIE Alfanum. Do 25 znaków. Domyślnie pu-
sta
```
rd Rabat(True)/narzut(False) NIE BOOL Domyślnie rabat
```
rp Wartość rabatu/narzutu typu pro-
centowego
NIE Num. Jak w rozkazie trline
rw Wartość rabatu/narzutu typu
kwotowego
NIE Kwota Jak w rozkazie trline
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Można udzielić kilka rabatów/narzutów od paragonu.
2. Jeśli występują obydwa pola rp i rw, to rabat/narzut jest procentowy, a parametr rw musi
być równy kwocie, o jaką rabat/narzut zmieni wartość transakcji. Brak obu pól powoduje
błąd.
3. Nie można stornować tego rabatu/narzutu, można wykonać operację odwrotną (rabat ↔ na-
```
rzut).
```
4. Polecenie nie jest dostępne podczas drukowania faktury.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trdiscntbill[TAB]nastały klient[TAB]rd1[TAB]rp2000[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:57|
| PARAGON FISKALNY |
|Cukierki 1 x1,00 1,00A|
|Ciastka 1 x2,00 2,00B|
|- - - - - - - - - - - - - - - - - - - - |
|Podsuma: 3,00|

| OPUST stały klient 20,00 % -0,60 |
|- - - - - - - - - - - - - - - - - - - - |
|OPUSTY ŁĄCZNIE -0,60|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 0,80|
|SPRZEDAŻ OPODATKOWANA B 1,60|
|PTU A 23,00 % 0,15|
|PTU B 8,00 % 0,12|
|SUMA PTU 0,27|
|SUMA PLN 2,40|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 2,40 PLN|
|00020 #001 KIEROWNIK 2018-09-04 11:29|
|ACEA0A8B651F2033B75AA706FCED71CCFD321979|
```
| {PL} ZBF 1801007587 |
```

Transakcja opakowań
## [trpackinit] Rozpoczęcie transakcji opakowań
Identyfikator polecenia:
trpackinit
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Rozpoczęcie transakcji opakowań umożliwia jedynie obrót opakowaniami. Nie ma możli-
wości sprzedaży towarów.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpackinit[TAB]#CRC16[ETX]
```

## [trpack] Linia opakowań
Identyfikator polecenia:
trpack
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa opakowania NIE Num. Do 11 cyfr
```
ne Opakowanie wydane (False)/
```
```
opakowanie zwrócone (True)
```
NIE BOOL Domyślnie False - wydane.
```
st Flaga stornowania (stornowanie
```
```
– True)
```
NIE BOOL Domyślnie False
pr Cena opakowania TAK Kwota Zakres 1 – 9 999 999 999
il Ilość opakowań NIE Num. Domyślnie 1,000
```
Zakres: 1 – 9 999 999 999
```
wa Total = cena x ilość NIE Kwota Jak w rozkazie trline
de Opis do opakowania NIE Alfanum Długość do 50 znaków. War-
tość parametru skracana jest do
pierwszych 40 przesłanych
znaków.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Aby był możliwy obrót opakowaniami musi być otwarta transakcja: trinit (obrót towarami i
```
opakowaniami) lub trpackinit (tylko obrót opakowaniami).
```
2. Przesłana w parametrze il ilość opakowań musi być liczbą całkowitą.
3. Oznaczenie opakowania na wydruku zależy od przesłanej nazwy (parametr na) oraz opisu
```
(parametr de).
```
4. Polecenie nie jest dostępne podczas drukowania faktury.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpack[TAB]na123[TAB]pr150[TAB]wa150[TAB]#CRC16[ETX]
```

## [trpackprnend] Wydruk linii opakowań w zakończeniu transakcji
Identyfikator polecenia:
trpackprnend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa opakowania NIE Num. Do 12 cyfr. Dla na=0 nazwa
jest niedrukowana – zachowa-
nie domyślne
```
ne Opakowanie wydane (False)/
```
```
opakowanie zwrócone(True)
```
NIE BOOL Domyślnie False. Parametr po-
winien mieć taką samą wartość,
jak analogiczny parametr wy-
stępujący w poleceniu trpack
pr Cena opakowania TAK Kwota Zakres 1 – 9 999 999 999
il Ilość opakowań NIE Num. Domyślnie 1,000
```
Zakres: 1 – 9 999 999 999
```
wa Total = cena x ilość NIE Kwota Jak w rozkazie trline
de Opis do opakowania NIE Alfanum Długość taka sama jak pole
"op" w rozkazie trline
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Komenda pozostawiona dla kompatybilności ze starszymi wersjami urządzeń.
2. Wydrukowane są opakowania wysłane komendą trpack.
3. Zakończenie transakcji następuje po wysłaniu rozkazu trftrend.
4. Polecenie nie jest dostępne podczas drukowania faktury.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpackprnend[TAB]na1000000[TAB]pr123[TAB]ne1[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |

|NIP 5222628262 nr:84|
| PARAGON FISKALNY |
|Cukierki 1 x98,76 98,76B|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA B 98,76|
|PTU B 8,00 % 7,32|
|SUMA PTU 7,32|
|SUMA PLN 98,76|
|- - - - - - - - - - - - - - - - - - - - |
|OPAKOWANIA ZWROTNE WYDANIA |
```
| Opakowanie zwr.(1000000) 1x1,23 1,23|
```
|OPAKOWANIA ZWROTNE SUMA 1,23|
|DO ZAPŁATY 99,99 PLN |
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 99,99 PLN|
|00042 #001 KIEROWNIK 2018-09-04 14:29|
|05A417D1B2262820991679B31573A0B79F83C671|
```
| {PL} ZBF 1801007587 |
```

Zakończenie transakcji
## [trpayment] Forma płatności w zakończeniu transakcji
Identyfikator polecenia:
trpayment
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Typ formy płatności TAK Num. 0 – gotówka, 2 – karta, 3 –
czek, 4 – bon, 5 – kredyt, 6 –
inna, 7 – voucher, 8 – przelew
wa Wartość wpłaty TAK Kwota Wartość wpłaty lub wartość
reszty – zależnie od parametru
re.
Jak w rozkazie trline
na Nazwa formy płatności NIE Alfanum. Do 25 znaków. Domyślnie pu-
sta.
re Flaga reszty NIE BOOL False – płatność formą płatno-
ści
True – wypłata reszty
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Typem formy płatności nie może być waluta
2. Dla ty = 0, wartość parametru na nie znajdzie się na wydruku i w JPK.
3. Musi zostać przesłana suma form płatności pokrywająca wartość do zapłaty.
4. Polecenie nie jest dostępne podczas drukowania faktury.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]
[STX]trline[TAB]naJabłka[TAB]vt1[TAB]pr200[TAB]wa200[TAB]#CRC16[ETX]
[STX]trpayment[TAB]ty2[TAB]wa500[TAB]re0[TAB]#CRC16[ETX] – płatność formą płatności
[STX]trpayment[TAB]ty0[TAB]wa300[TAB]re1[TAB]#CRC16[ETX] – określenie reszty
[STX]trend[TAB]to200[TAB]re300[TAB]fp500[TAB]#CRC16[ETX]
```

```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:85|
| PARAGON FISKALNY |
|Jabłka 1 x2,00 2,00B|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA B 2,00|
|PTU B 8,00 % 0,15|
|SUMA PTU 0,15|
|SUMA PLN 2,00|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|KARTA 5,00 PLN|
|RESZTA GOTÓWKA 3,00 PLN|
|00043 #001 KIEROWNIK 2018-09-04 14:40|
|A47361BD9831A83BDAB12A3FD0E5D3E731DA2508|
```
| {PL} ZBF 1801007587 |
```

## [trpaymentdelete] Usunięcie formy płatności w zakończeniu transakcji
Identyfikator polecenia:
trpaymentdelete
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Typ formy płatności TAK Num. 0 – gotówka, 2 – karta, 3 –
czek, 4 – bon, 5 – kredyt, 6 –
inna, 7 – voucher, 8 – przelew
wa Wartość wpłaty TAK Kwota Wartość wpłaty lub wartość
reszty – zależnie od parametru
re.
Jak w rozkazie trline
na Nazwa formy płatności NIE Alfanum. Do 25 znaków. Domyślnie pu-
sta.
re Flaga reszty NIE BOOL False – płatność formą płatno-
ści
True – wypłata reszty
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Typem formy płatności nie może być waluta
2. Musi zostać przesłana suma form płatności pokrywająca wartość do zapłaty.
3. Polecenie nie jest dostępne podczas drukowania faktury.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpaymentdelete[TAB]ty2[TAB]wa3000[TAB]naKarta[TAB]#CRC16[ETX]
```

## [trpaymentcurr] Waluta w zakończeniu transakcji
Identyfikator polecenia:
trpaymentcurr
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
wc Wartość wpłaty w walucie TAK Kwota
wa Wartość wpłaty w walucie ewi-
dencyjnej
NIE Kwota Waluta przeliczona na walutę
ewidencyjną
ra Kurs waluty TAK Num. Cztery najmłodsze cyfry należą
```
do części ułamkowej (np:
```
```
12345 oznacza 1,2345 )
```
Maksymalna wartość:
99999999999
na Nazwa waluty TAK Alfanum. Do 25 znaków. Domyślnie pu-
sta
sb Symbol waluty TAK Alfanum. Dokładnie trzy duże litery bez
znaków diakrytycznych.
re Flaga reszty NIE BOOL Domyślnie False. Zachowanie
analogiczne do parametru re w
rozkazie trpayment
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie nie jest dostępne podczas drukowania faktury.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpaymentcurr[TAB]wc10[TAB]naEuro[TAB]sbEUR[TAB]ra40000[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:114|
| PARAGON FISKALNY |

|Cukier 1 x1,00 1,00A|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 1,00|
|PTU A 23,00 % 0,19|
|SUMA PTU 0,19|
|SUMA PLN 1,00|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|WALUTA OBCA DOLAR |
| USD PRZELICZNIK 1 USD = 3,7214 PLN|
| 0,27 USD 1,00 PLN|
| WPŁATA 0,27 USD|
|00013 #001 KIEROWNIK 2018-09-04 15:18|
|039F037C64AFE30DA49325B1CA80339F70150502|
```
| {PL} ZBF 1801007587 |
```

## [trpaymentcurrdelete] Usunięcie płatności walutą w zakończeniu trans-
akcji
Identyfikator polecenia:
trpaymentcurrdelete
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
wc Wartość wpłaty w walucie TAK Kwota
wa Wartość wpłaty w walucie ewi-
dencyjnej
NIE Kwota Waluta przeliczona na walutę
ewidencyjną
ra Kurs waluty TAK Num. Cztery najmłodsze cyfry należą
```
do części ułamkowej (np:
```
```
12345 oznacza 1,2345 )
```
Maksymalna wartość:
99999999999
na Nazwa waluty TAK Alfanum. Do 25 znaków. Domyślnie pu-
sta
sb Symbol waluty TAK Alfanum. 3 znaki
re Flaga reszty NIE BOOL Domyślnie False. Zachowanie
analogiczne do parametru re w
rozkazie trpayment
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie nie jest dostępne podczas drukowania faktury.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpaymentcurrdelete[TAB]wc10[TAB]sbEUR[TAB]ra40000[TAB]#CRC16[ETX]
```

## [trpaymentcanc] Anulowanie wszystkich form płatności w zakończeniu
transakcji
Identyfikator polecenia:
trpaymentcanc
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie nie jest dostępne podczas drukowania faktury.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trpaymentcanc[TAB]#CRC16[ETX]
```

## [showsubtotal] Pokaż podsumę
Identyfikator polecenia:
showsubtotal
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Pokazuje podsumę na wyświetlaczu klienta (z uwzględnieniem operacji na opakowaniach) i
```
powoduje wydruk podsumy na paragonie (bez uwzględnienia operacji na opakowaniach).
```
2. Wysłanie rozkazu showsubtotal po przesłaniu formy płatności lub rabatu od paragonu, spo-
woduje odesłanie błędu.
3. Wysłanie polecenia przed pierwszą linią transakcji zwraca błąd.
4. Podczas drukowania faktury polecenie jest ignorowane.
5. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]showsubtotal[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:150|
| PARAGON FISKALNY |
|Cukierki 1 x10,00 10,00A|
|Podsuma: 10,00|

## [trsubtotcanc] Anulowanie danych wprowadzonych w podsumie
Identyfikator polecenia:
trsubtotcanc
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Anuluje rabat od paragonu i wszystkie formy płatności użyte podczas paragonu lub niefi-
skalnego rozliczenia opakowań zwrotnych.
2. Polecenie nie jest dostępne podczas drukowania faktury.
3. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trsubtotcanc[TAB]#CRC16[ETX]
```

## [tradvance] Zaliczka
Identyfikator polecenia:
tradvance
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa zaliczki NIE Alfanum Do 80 znaków.
W przypadku braku przesłania
nazwy, drukowana jest nazwa
stała: „ZALICZKA”
```
vt Stawka VAT TAK Num Podaje się numer stawki (0 - 6)
```
pr Cena TAK Kwota
st Flaga stornowania NIE BOOL False - brak stornowania
True - stornowanie
Domyślnie False
wa Kwota od której jest udziela-
na zaliczka
TAK Parametr wa musi być mniejszy
lub równy aktualnej wartości
sprzedaży w stawce, której do-
tyczy zaliczka.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Przesłanie zaliczki pomniejsza wartość fiskalną paragonu/faktury, co należy uwzględnić w
zakończeniu transakcji.
2. Jeśli wartość zaliczki jest równa wartości fiskalnej paragonu/faktury, jest możliwe zakoń-
czenie transakcji z wartością zerową.
3. W poleceniu jest możliwość wykonania storna częściowego.
4. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]
[STX]trline[TAB]naTowar A[TAB]vt0[TAB]pr1000[TAB]#CRC16[ETX]
[STX]tradvance[TAB]naZALICZKA[TAB]vt0[TAB]pr500[TAB]wa1000[TAB]#CRC16[ETX]
[STX]tradvance[TAB]naZALICZKA[TAB]vt0[TAB]pr300[TAB]st1[TAB]wa500[TAB]#CRC16[ETX]
[STX]trend[TAB]to800[TAB]#CRC16[ETX]
```

```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:151|
| PARAGON FISKALNY |
|Towar A 1 x10,00 10,00A|
|ZALICZKA 10,00 -5,00A|
| 5,00 |
| #STORNO# |
|ZALICZKA 2,00 +3,00A|
| 5,00 |
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA A 8,00|
|PTU A 23,00 % 1,50|
|SUMA PTU 1,50|
|SUMA PLN 8,00|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 8,00 PLN|
|00049 #001 KIEROWNIK 2018-09-10 12:45|
|73F7598D81369D327D2F6A606A643BF9A8772560|
```
| {PL} ZBF 1801007587 |
```

## [trend] Zakończenie transakcji
Identyfikator polecenia:
trend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
to Wartość fiskalna w zakończeniu NIE Kwota
op Wartość przesłanych opakowań do-
```
datnich (wydanych)
```
NIE Kwota
om Wartość przesłanych opakowań
```
ujemnych (zwróconych)
```
NIE Kwota
fp Wartość przesłanych form płatności NIE Kwota
re Wartość przesłanych reszt NIE Kwota
fe Flaga automatycznego zakończenia
stopki
NIE BOOL True – bez przesyłania opa-
kowań, dodatkowych linii
```
(domyślnie)
```
False – z przesyłaniem
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Wartość fiskalna musi się zgadzać z wartością fiskalną paragonu.
2. Wartość form płatności i opakowań musi być zgodna z wartościami wcześniej przesłanymi.
3. Wartość przesłanych form płatności musi być równa lub większa od wartości do zapłaty.
4. Przesłane reszty muszą spełnić warunek: FORMY_PŁATNOŚCI – RESZTA = DO_ZAPŁA-
TY
5. Jeśli przesłane formy płatności przekraczają kwotę DO ZAPŁATY i reszty nie zostały prze-
słane, urządzenie samo liczy resztę.
6. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]trend[TAB]to123[TAB]fp123[TAB]#CRC16[ETX]
```

## [prncancel] Anulowanie transakcji lub wydruku
Identyfikator polecenia:
prncancel, trcancel
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Rozkaz trcancel jest synonimem rozkazu prncancel.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]prncancel[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:154|
| PARAGON FISKALNY |
|Towar A 1 x10,00 10,00A|
| TRANSAKCJA ANULOWANA |
|00052 #001 KIEROWNIK 2018-09-10 12:55|
|0C93CA4C9545F814072357C7C540336878503260|
```
| {PL} ZBF 1801007587 |
```

## [hardprncancel] Anulowanie transakcji lub wydruku niezależnie od inter-
fejsu, który je zainicjalizował.
Identyfikator polecenia:
hardprncancel
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]hardprncancel[TAB]#CRC16[ETX]
```

```
Polecenia eDokument (eParagon i eFaktura)
```
## [eparagondefaultget] Pobranie konfiguracji domyślnego serwera usługi
eDokument
Identyfikator polecenia:
eparagondefaultget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera usługi eDoku-
ment
- Alfanum. Do 80 znaków (RFC 3986)
ct Typ certyfikatu - Num. 0 – Brak,
1 – Posnet Root
2 – Odcisk certyfikatu
tp Odcisk SHA certyfikatu - Alfanum. 40 znaków – heksadecymalnie
gi Czy wysyłać grafikę? - BOOL
ft Czy wysyłać stopkę? - BOOL
td Czy wysyłać dane transakcji? - BOOL
hd Czy wysyłać nagłówek? - BOOL
ex Parametr ignorowany. - BOOL
gb Czy wysyłać dane binarne grafi-
ki?
- BOOL
ts Czas oczekiwania na odpowiedź
serwera.
- Num. Czas w sekundach.
Zakres 0 – 120.
tt Czas oczekiwania na wysyłkę. - Num. Czas w sekundach.
Zakres 0 – 120.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagondefaultget[TAB]#CRC16[ETX]
```

## [eparagondefaultset] Ustawienie konfiguracji domyślnego serwera usłu-
gi eDokument
Identyfikator polecenia:
eparagondefaultset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera usługi eDoku-
ment
```
NIE Alfanum. Do 80 znaków (RFC 3986) – z
```
przedrostkiem 'https://'
lub
```
Do 72 znaki (RFC 3986) – bez
```
przedrostka 'https://'
ct Typ certyfikatu NIE Num. 0 – Brak,
1 – Posnet Root
2 – Odcisk certyfikatu
tp Odcisk SHA certyfikatu NIE Alfanum. 40 znaków – heksadecymalnie
gi Czy wysyłać identyfikatory gra-
fik?
NIE BOOL
ft Czy wysyłać stopkę? NIE BOOL
td Czy wysyłać dane transakcji? NIE BOOL
hd Czy wysyłać nagłówek? NIE BOOL
ex Parametr ignorowany. NIE BOOL Należy przesyłać 0.
gb Czy wysyłać dane binarne grafi-
ki?
NIE BOOL
ts Czas oczekiwania na odpowiedź
serwera.
NIE Num. Czas w sekundach.
Zakres 0 – 120.
Wartość domyślna: 15
tt Czas oczekiwania na wysyłkę
danych.
NIE Num. Czas w sekundach.
Zakres 0 – 120.
Wartość domyślna: 30
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.

2. W przypadku niepodania adresu serwera ustawiany jest adres domyślny. Jeśli nie podano
wcześniej adresu serwera domyślnego parametr ad należy traktować jako wymagany.
3. W przypadku przesłania adresu ad, który nie posiada przedrostka 'https://' to zostanie on au-
tomatycznie dodany do przesłanego adresu.
4. Jeśli w przedrostku wystąpią wielkie litery, urządzenie zamieni je na małe.
5. W przypadku niepowodzenia wysyłki danych ustawianych parametrem tt, paragon jest dru-
kowany.
Przykład:
```plaintext
[STX]eparagondefaultset[TAB]adeparag.mf.gov.pl[TAB]ct1[TAB]#CRC16[ETX]
```

## [eparagonstatusget] Odczyt stanu usługi eDokument
Identyfikator polecenia:
eparagonstatusget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
st Status usługi eDokument - BOOL Gdzie:
0 – Nieaktywny,
1 – Aktywny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonstatusget[TAB]#CRC16[ETX]
```

## [eparagonstatusset] Ustawienie stanu usługi eDokument
Identyfikator polecenia:
eparagonstatusset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
st Status usługi eDokument TAK BOOL Gdzie:
0 – Nieaktywny,
1 – Aktywny
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonstatusset[TAB]st1[TAB]#CRC16[ETX]
```

## [eparagonidzcancel] Anulowanie eDokumentu
Identyfikator polecenia:
eparagonidzcancel
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Polecenie powoduje skasowanie identyfikatora użytkownika eDokumentu (IDZ) nadanego
poleceniem eparagonidznext.
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]eparagonidzcancel[TAB]#CRC16[ETX]
```

```
## [eparagonidznext] Ustawienie identyfikatora użytkownika (IDZ) kolejne-
```
go eDokumentu
Identyfikator polecenia:
eparagonidznext
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id IDZ eDokumentu TAK Alfanum. Do 128 znaków
```
ad Adres serwera eDokumentu NIE Alfanum. Do 80 znaków (RFC 3986),
```
gdzie przy braku parametru
ustawiany jest adres serwera
domyślnego.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
```
ha Identyfikator eDokumentu - Num. Od 0 do 4294967295 (unikalny
```
```
dla każdego eDokumentu)
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. Polecenie można przesłać przed rozpoczęciem transakcji (deklaracja wysłania przyszłego
```
eParagonu), jak i między poleceniami rozpoczynającymi i kończącymi transakcję (deklara-
```
```
cja wysłania obecnego dokumentu jako eParagon).
```
3. W przypadku niepodania adresu serwera ustawiany jest adres domyślny.
4. Polecenie nie działa, gdy jest wysłane w czasie przesyłania dodatkowych linii po transakcji
```
(między poleceniami trend i trftrend).
```
Przykład:
```plaintext
[STX]eparagonidznext[TAB]id11[TAB]adeparag.mf.gov.pl[TAB]#CRC16[ETX]
```

## [eparagonidzprev] Utworzenie eDokumentu z poprzedniego dokumentu
Identyfikator polecenia:
eparagonidzprev
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
id Identyfikator użytkownika (IDZ)
```
eDokumentu
TAK Alfanum. Do 128 znaków
```
ad Adres serwera eDokument NIE Alfanum. Do 80 znaków (RFC 3986),
```
gdzie przy braku parametru
ustawiany jest adres serwera
domyślnego.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ha Unikalny identyfikator eDoku-
mentu
- Num. Od 0 do 4294967295 (unikalny
```
dla każdego eDokumentu)
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. W przypadku niepodania adresu serwera ustawiany jest adres domyślny.
3. Polecenie działa tylko poza transkacją.
Przykład:
```plaintext
[STX]eparagonidzprev[TAB]id11[TAB]adeparag.mf.gov.pl[TAB]#CRC16[ETX]
```

## [eparagonserverins] Ustawienie konfiguracji dodatkowego serwera
usługi eDokument
Identyfikator polecenia:
eparagonserverins
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
rn Numer rekordu bazy serwerów TAK Num. Od 0 do 9
ad Adres serwera usługi eDoku-
ment
```
NIE Alfanum. Do 80 znaków (RFC 3986) –
```
z przedrostkiem 'https://'
lub
```
Do 72 znaków (RFC 3986) –
```
bez przedrostka 'https://'
ct Typ certyfikatu NIE Num. 0 – Brak,
1 – Posnet Root
2 – Odcisk certyfikatu
tp Odcisk SHA certyfikatu NIE Alfanum. 40 znaków – heksadecymalnie
gi Czy wysyłać grafikę? NIE BOOL
ft Czy wysyłać stopkę? NIE BOOL
td Czy wysyłać dane transakcji? NIE BOOL
hd Czy wysyłać nagłówek? NIE BOOL
ex Czy wysyłać dane dodatkowe? NIE BOOL
gb Czy wysyłać dane binarne grafi-
ki?
NIE BOOL
ts Czas oczekiwania na odpowiedź
serwera.
NIE Num. Czas w sekundach.
Zakres 0-120.
Wartość domyślna: 15
tt Czas oczekiwania na wysyłkę. NIE Num. Czas w sekundach.
Zakres 0-120.
Wartość domyślna: 30
ov Czy nadpisać istniejący rekord?
```
(T/N)
```
NIE BOOL
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```

1. Dostępność w trybie tylko do odczytu: TAK.
2. Parametr ad nie jest wymagany w przypadku modyfikacji rekordu. Jest wymagany przy do-
dawaniu nowego rekordu.
3. W przypadku przesłania adresu 'ad', który nie posiada przedrostka 'https://' to zostanie on au-
tomatycznie dodany do przesłanego adresu.
4. Jeśli w przedrostku wystąpią wielkie litery, urządzenie zamieni je na małe.
Przykład:
```plaintext
[STX]eparagonserverins[TAB]rn8[TAB]adeparag.mf.gov.pl[TAB]ct1[TAB]#CRC16[ETX]
```

## [eparagonserverget] Odczyt konfiguracji dodatkowego serwera usługi
eDokument
Identyfikator polecenia:
eparagonserverget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
rn Numer rekordu z bazy serwerów NIE Num. Od 0 do 9
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
rn Numer rekordu z bazy serwerów - Num. Od 0 do 9
ad Adres serwera usługi eDoku-
ment
- Alfanum. Do 80 znaków (RFC 3986)
ct Typ certyfikatu - Num. 0 – Brak,
1 – Posnet Root
2 – Odcisk certyfikatu
tp Odcisk SHA certyfikatu - Alfanum. 40 znaków – heksadecymalnie
gi Czy wysyłać grafikę? - BOOL
ft Czy wysyłać stopkę? - BOOL
td Czy wysyłać dane transakcji? - BOOL
hd Czy wysyłać nagłówek? - BOOL
ex Czy wysyłać dane dodatkowe? - BOOL
gb Czy wysyłać dane binarne grafi-
ki?
- BOOL
ts Czas oczekiwania na odpowiedź
serwera.
- Num. Czas w sekundach.
Zakres 0-120.
tt Czas oczekiwania na wysyłkę. - Num. Czas w sekundach.
Zakres 0-120.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Parametr rn nie jest wymagany w przypadku ustawionego kontekstu do odczytu bazy serwe-
rów eDokument.

Przykład:
```plaintext
[STX]eparagonserverget[TAB]rn8[TAB]#CRC16[ETX]
```

## [eparagonserverdel] Usunięcie konfiguracji dodatkowego serwera usłu-
gi eDokument
Identyfikator polecenia:
eparagonserverdel
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
rn Numer rekordu bazy serwerów TAK Num. Od 0 do 9
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonserverdel[TAB]rn8[TAB]#CRC16[ETX]
```

## [eparagonserversearch] Znalezienie konfiguracji dodatkowego serwera
usługi eDokument po adresie serwera
Identyfikator polecenia:
eparagonserversearch
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera usługi eDoku-
ment
```
TAK Alfanum. Do 80 znaków (RFC 3986)
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
rn Numer rekordu bazy serwerów - Num. Od 0 do 9
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonserversearch[TAB]adeparag.mf.gov.pl[TAB]#CRC16[ETX]
```

## [eparagonscheduleset] Ustawienie harmonogramu domyślnego usługi
eDokument
Identyfikator polecenia:
eparagonscheduleset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
sa Czas wykonania I próby ponow-
nego wysłania eDokumentu
TAK Num. Czas w sekundach.
```
Min: 5 sek. Maks: 300 sek.
```
sb Czas wykonania II próby po-
nownego wysłania eDokumentu
NIE Num. Czas w sekundach.
```
Min: 5 sek. Maks: 300 sek.
```
sc Czas wykonania III próby po-
nownego wysłania eDokumentu
NIE Num. Czas w sekundach.
```
Min: 5 sek. Maks: 300 sek.
```
sd Czas wykonania IV próby po-
nownego wysłania eDokumentu
NIE Num. Czas w sekundach.
```
Min: 5 sek. Maks: 300 sek.
```
se Czas wykonania V próby po-
nownego wysłania eDokumentu
NIE Num. Czas w sekundach.
```
Min: 5 sek. Maks: 300 sek.
```
op Czas cyklicznego wysyłania
eDokumentu do momentu prze-
kroczenia maksymalnego czasu
```
życia eDokumentu (parametr
```
```
‘tl’).
```
TAK Num. Czas w sekundach.
```
Min: 600 sek. Maks: 86400
```
sek.
Zaczyna obowiązywać po wy-
konaniu wszystkich aktyw-
nych prób harmonogramu.
tl Maksymalny czas życia eDoku-
mentu ze statusem nieudanej
przesyłki.
TAK Num. Czas w sekundach.
```
Min: 5 sek. Maks: 2592000
```
```
sek.(30 dni)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Przesłanie któregoś z parametrów: sb, sc, sd, se z wartością 0, oznacza koniec definiowania
harmonogramu. Następne parametry definiujące kolejne próby wysłania eParagonu mają
być nieprzesłane lub przesłane z wartością 0.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonscheduleset[TAB]sa123[TAB]#CRC16[ETX]
```

## [eparagonscheduleget] Pobieranie harmonogramu domyślnego usługi
eDokument
Identyfikator polecenia:
eparagonscheduleget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
sa Czas wykonania I próby ponow-
nego wysłania eDokumentu
TAK Num.
sb Czas wykonania II próby po-
nownego wysłania eDokumentu
NIE Num.
sc Czas wykonania III próby po-
nownego wysłania eDokumentu
NIE Num.
sd Czas wykonania IV próby po-
nownego wysłania eDokumentu
NIE Num.
se Czas wykonania V próby po-
nownego wysłania eDokumentu
NIE Num.
op Czas cyklicznego wysyłania
eParagonu do momentu przekro-
czenia maksymalnego czasu ży-
```
cia eDokumentu (parametr ‘tl’).
```
NIE Num.
tl Maksymalny czas życia eDoku-
mentu ze statusem nieudanej
przesyłki.
NIE Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonscheduleget[TAB]#CRC16[ETX]
```

## [eparagonservercontextset] Ustawienie kontekstu do odczytu bazy ser-
werów eDokument
Identyfikator polecenia:
eparagonservercontextset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Typ wyszukiwania TAK Num. 0 – Odczyt po numerach
1 – Odczyt po adresie serwera
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonservercontextset[TAB]ty1[TAB]#CRC16[ETX]
```

## [eparagonbufferget] Odczyt rekordu z bufora eDokument
Identyfikator polecenia:
eparagonbufferget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
hd Identyfikator eDokumentu TAK Num. Od 0 do 4294967295 (unikal-
```
```
ny dla każdego eDokumentu)
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
```
ad Adres serwera eDokument - Alfanum. Do 80 znaków (RFC 3986)
```
di Numer dokumentu z nośnika/ba-
zy danych
- Num.
id Identyfikator użytkownika eDo-
```
kumentu (IDZ)
```
- Alfanum.
```
hd Identyfikator eDokumentu - Num. Od 0 do 4294967295 (unikalny
```
```
dla każdego eDokumentu)
```
rd Data zarejestrowania eDoku-
mentu
- Data i
czas
ISO8601
```
uc Kod błędu UPO (potwierdzenie
```
```
odbioru)
```
- Alfanum. Otrzymany kod UPO spoza za-
kresu jest ignorowany przez
```
urządzenie (do 16 znaków
```
```
ASCII z zakresu 0x20 do 0x7F)
```
hc Kod HTTP - Num. Kod odpowiedzi http,
```
gdzie:
```
0 – nie doszło do połączenia
http lub nie uzyskano kodu
http.
Inne zgodnie z kodami http
cc Kod CURL - Num. Gdzie:
0 – Ok
Inne błąd.
ac Kod Aplikacji - Num. Gdzie:
0 – Ok
Inne błąd.
st Stan eDokumentu - Num. 0 – Nowy

1 – Wysłany
```
2 – Błąd przy wysyłaniu (zosta-
```
```
nie powtórzona wysyłka)
```
3 – Niewysłany
```
(nie zostanie ponownie przesła-
```
```
ny)
```
```
4 – Zarezerwowany (zostanie
```
wykorzystany dla przyszłego
```
paragonu)
```
sd Data zmiany stanu eDokumentu - Data i
czas
ISO8601
```
pr Czy wydrukowany(T/N). - BOOL True – dokument wydrukowa-
```
ny
False – brak wydruku
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. W przypadku gdy parametr st = 4, parametry rd i sd zwracają datę „2000-01-
01T01:00:00+01:00” a parametr di = 0.
3. W przypadku odczytu grafiki:
- parametr pr dla grafiki ma mieć zawsze wartość N.
- parametr id opisujący IDZ, zawiera unikalną ścieżkę identyfikującą grafikę np.:
ZBE1234567890-1-1234.
Przykład:
```plaintext
[STX]eparagonbufferget[TAB]hd123[TAB]#CRC16[ETX]
```

## [eparagonbufferdelall] Skasowanie całego bufora eDokument
Identyfikator polecenia:
eparagonbufferdelall
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonbufferdelall[TAB]#CRC16[ETX]
```

## [eparagonbufferdelrec] Skasowanie rekordu z bufora eDokument
Identyfikator polecenia:
eparagonbufferdelrec
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
hd Identyfikator eDokumentu TAK Num. Od 0 do 4294967295 (unikal-
```
```
ny dla każdego eDokumentu)
```
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonbufferdelrec[TAB]hd12345[TAB]#CRC16[ETX]
```

## [eparagonbuffercontextset] Ustawienie kontekstu do odczytu bufora
eDokument
Identyfikator polecenia:
eparagonbuffercontextset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ty Sposób wyszukiwania rekordów TAK Num. 0 – Po dacie
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonbuffercontextset[TAB]ty0[TAB]#CRC16[ETX]
```

## [eparagonbuffercontextget] Odczyt kontekstowy rekordu z bufora eDo-
kument
Identyfikator polecenia:
eparagonbuffercontextget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera eDokument - Alfanum.
di Numer dokumentu z nośnika/ba-
zy danych
- Num.
id Identyfikator użytkownika eDo-
```
kument (IDZ)
```
- Alfanum.
hd Identyfikator eDokument - Num.
rd Data zarejestrowania eDoku-
mentu
- Data i
czas
ISO8601
```
uc Kod błędu UPO (potwierdzenie
```
```
odbioru)
```
- Alfanum. Otrzymany kod UPO spoza
zakresu jest ignorowany przez
```
urządzenie (do 16 znaków
```
ASCII z zakresu 0x20 do
```
```c
0x7F).
```
hc Kod HTTP - Num. Kod odpowiedzi http,
```
gdzie:
```
0 – nie doszło do połączenia
http lub nie uzyskano kodu
http.
Inne zgodnie z kodami http.
cc Kod CURL - Num. Gdzie:
0 – Ok
Inne błąd.
ac Kod Aplikacji - Num. Gdzie:
0 – Ok
Inne błąd.
st Stan eDokumentu - Num. 0 – Nowy
1 – Wysłany
```
2 – Błąd przy wysyłaniu (zo-
```
```

```
stanie powtórzona wysyłka)
```
3 – Niewysłany
```
(nie zostanie ponownie prze-
```
```
słany)
```
```
4 – Zarezerwowany (zostanie
```
wykorzystany dla przyszłego
```
paragonu)
```
sd Data zmiany stanu eDokumentu - Data i
czas
ISO8601
```
pr Czy wydrukowany(T/N). - BOOL
```
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonbuffercontextget[TAB]#CRC16[ETX]
```

## [eparagonconnectiontest] Wykonanie testowego połączenia z serwerem
eDokument
Identyfikator polecenia:
eparagonconnectiontest
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera usługi eDoku-
ment
```
NIE Num. Do 80 znaków (RFC 3986).
```
W przypadku braku parame-
tru, testowane jest połączenie
z serwerem o adresie przesła-
nym w poleceniu eparagonde-
faultset.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ap Kod Aplikacji - Num. Gdzie:
0 – Ok
Inne błąd.
ht Kod HTTP - Num. Kod odpowiedzi http,
```
gdzie:
```
0 – nie doszło do połączenia
http lub nie uzyskano kodu
http.
Inne zgodnie z kodami http
cu Kod CURL - Num. Gdzie:
0 – Ok
Inne błąd.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonconnectiontest[TAB]adeparag.mf.gov.pl[TAB]#CRC16[ETX]
```

## [eparagongraphicsend] Wysłanie grafiki ze slotu na wybrany serwer
eDokument
Identyfikator polecenia:
eparagongraphicsend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera usługi eDoku-
ment
```
NIE Num. Do 80 znaków (RFC 3986)
```
id Numer slotu zapisanej grafiki TAK Num. Od 1 do 500
Dla FAWAG BOX od 1 do 40
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
hd Identyfikator eDokument - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. W przypadku niepodania adresu serwera ustawiany jest adres domyślny.
Przykład:
```plaintext
[STX]eparagongraphicsend[TAB]adeparag.mf.gov.pl[TAB]id123[TAB]#CRC16[ETX]
```

## [eparagongraphicsendall] Wysłanie wszystkich grafik na wybrany ser-
wer eDokument
Identyfikator polecenia:
eparagongraphicsendall
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ad Adres serwera usługi eDoku-
ment
```
NIE Num. Do 80 znaków (RFC 3986)
```
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
bs Ilość wysłanych grafik - Num. Ilość wysłanych grafik, jest
uzależniona od stanu kolejki
bufora eDokument.
bn Ilość zapisanych grafik w slo-
tach
- Num. Od 1 do 500
Dla FAWAG BOX od 1 do 40
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
2. W przypadku zapełnienia kolejki bufora, kolejne grafiki nie są wysyłane.
3. W przypadku niepodania adresu serwera ustawiany jest adres domyślny.
Przykład:
```plaintext
[STX]eparagongraphicsendall[TAB]adeparag.mf.gov.pl[TAB]#CRC16[ETX]
```

## [eparagonbufferoverrideset] Ustawienie nadpisywania bufora eDoku-
ment
Identyfikator polecenia:
eparagonbufferoverrideset
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
ov Status nadpisywania bufora TAK BOOL True – nadpisywanie włączo-
ne.
Domyślnie False.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Dla ov = False, nadpisywane są najstarsze rekordy z bufora eDokumentu o stanie 1 (wysła-
```
ny) lub 3 (niewysłany - nie zostanie ponownie przesłany). Ostatnie 10 rekordów o stanie 1 i
```
3 ma zabezpieczenie przed skasowaniem - nie mogą być nadpisane.
```
Dla ov = True, nadpisywane są również najstarsze rekordy o stanie 2 (błąd przy wysyłaniu -
```
```
zostanie powtórzona wysyłka). Ostatnie 10 rekordów o stanie 1 i 3 ma zabezpieczenie przed
```
skasowaniem - nie mogą być nadpisane.
Przykład:
```plaintext
[STX]eparagonbufferoverrideset[TAB]ov1[TAB]#CRC16[ETX]
```

## [eparagonbufferoverrideget] Odczyt ustawienia nadpisywania bufora
eDokument
Identyfikator polecenia:
eparagonbufferoverrideget
Parametry wejściowe:
standardowa
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ov Status nadpisywania bufora - BOOL True – nadpisywanie włączo-
ne.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Dla ov = False, nadpisywane są najstarsze rekordy z bufora eDokumentu o stanie 1 (wysła-
```
ny) lub 3 (niewysłany - nie zostanie ponownie przesłany). Ostatnie 10 rekordów o stanie 1 i
```
3 ma zabezpieczenie przed skasowaniem - nie mogą być nadpisane.
```
Dla ov = True, nadpisywane są również najstarsze rekordy o stanie 2 (błąd przy wysyłaniu -
```
```
zostanie powtórzona wysyłka). Ostatnie 10 rekordów o stanie 1 i 3 ma zabezpieczenie przed
```
skasowaniem - nie mogą być nadpisane.
Przykład:
```plaintext
[STX]eparagonbufferoverrideget[TAB]#CRC16[ETX]
```

## [eparagonbufferfreecntget] Odczyt ilości wolnych rekordów bufora eDo-
kument
Identyfikator polecenia:
eparagonbufferfreecntget
Parametry wejściowe:
standardowa
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
rc Ilość wolnych rekordów - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonbufferfreecntget [TAB]#CRC16[ETX]
```

## [eparagonbuffersummaryget] Odczyt podsumowania rekordów bufora
eDokument
Identyfikator polecenia:
eparagonbuffersummaryget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
fr Liczba wolnych rekordów bufora eDoku-
ment
- Num.
ne Liczba rekordów o statusie NEW - Num.
ok Liczba rekordów o statusie OK - Num.
fi Liczba rekordów o statusie FAILED - Num.
ft Liczba rekordów o statusie FATAL - Num.
re Liczba rekordów o statusie RESERVED - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]eparagonbuffersummaryget[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]eparagonbuffersummaryget[TAB]fr470[TAB]ne10[TAB]ok10[TAB]fi10[TAB]ft0[TAB]re0[T
AB]#CRC16[ETX]

Kody 2D
Każdorazowy wydruk kodu musi być poprzedzony sekwencją przygotowującą do wydruku danego
```
kodu (azteccode, dmcode, pdf417code, qrcode). Kod może być wydrukowany po odpowiednim
```
skonfigurowaniu stopki wydruku – polecenie ftrcfg, lub w formatce niefiskalnej – polecenie form-
barcode2d.
```
Liczba danych możliwych do zakodowania za pomocą kodów 2d (parametr „tx”) zależy od kilku
```
czynników:
- od ograniczenia wielkości danych – maksymalna długość parametru „tx” to 2000 bajtów (4000 w
```
trybie hex)
```
- od szerokości papieru
- od parametru „px” (liczba pikseli z których zbudowany jest pojedynczy punkt kodu) - większa
wartość tego parametru powoduje zwiększenie wymiarów drukowanego kodu.
- od parametru „el” (poziom korekcji błędów) – zwiększanie tego parametru powoduje dodawanie
```
nadmiarowych danych pomocnych w odczycie uszkodzonego (nieczytelnego) kodu, ale powoduje
```
zwiększenie wymiarów drukowanego kodu.
- od ograniczeń związanych ze specyfikacją samego kodu (różnie w zależności od kodu)
Wygenerowanie kodu o zbyt dużych wymiarach może skutkować tym, że przestanie się on mieścić
na papierze, co zostanie zasygnalizowane odpowiednim kodem błędu.

## [azteccode] przygotowanie do wydruku dwuwymiarowego kodu kresko-
wego Aztec
Identyfikator polecenia:
azteccode
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
px Długość boku (w pikselach) po-
```
jedynczego punktu kodu
NIE Num. Wartość minimalna:
```
2 (domyślnie)
```
el Poziom korekcji błędów NIE Num. Dopuszczalne wartości:
```
0 – (10%) najmniejszy poziom
```
korekcji,
```
1 – (23%)
```
```
2 – (36%)
```
```
3 – (50%) największy poziom
```
korekcji - największa liczba do-
datkowych danych
hx Przełącznik pomiędzy trybami
```
wprowadzanych danych (Ascii /
```
```
szesnastkowo)
```
```
NIE BOOL False – tryb Ascii (domyślnie)
```
True – tryb Hex.
tx Komunikat do wydrukowania TAK Alfanum
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szero-
kości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
4. Polecenie niedostępne w FAWAG BOX 1.01.
Przykład:
```plaintext
[STX]azteccode[TAB]px2[TAB]el0[TAB]hx0[TAB]txKOMUNIKAT[TAB]#CRC16[ETX]
```

## [dmcode] przygotowanie do wydruku dwuwymiarowego kodu kreskowe-
go Data Matrix
Identyfikator polecenia:
dmcode
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
px Długość boku (w pikselach) po-
```
jedynczego punktu kodu
NIE Num. Wartość minimalna:
```
2 (domyślnie)
```
hx Przełącznik pomiędzy trybami
```
wprowadzanych danych (Ascii /
```
```
szesnastkowo)
```
```
NIE BOOL False – tryb Ascii (domyślnie)
```
True - tryb Hex.
tx Komunikat do wydrukowania TAK Alfanum
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szero-
kości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
4. Polecenie niedostępne w FAWAG BOX 1.01.
Przykład:
```plaintext
[STX]dmcode[TAB]px2[TAB]hx0[TAB]txKOMUNIKAT[TAB]#CRC16[ETX]
```

## [pdf417code] przygotowanie do wydruku dwuwymiarowego kodu kre-
skowego Pdf417
Identyfikator polecenia:
pdf417code
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
px Długość boku (w pikselach) po-
```
jedynczego punktu kodu
NIE Num. Wartość minimalna:
```
2 (domyślnie)
```
yx Proporcja drukowanego piksela
```
(wysokość / szerokość)
```
NIE Num. 1..50
Domyślnie 3
el Poziom korekcji błędów NIE Num. Dopuszczalne wartości:
```
0 – (2 słowa kodowe przezna-
```
```
czone na korekcję) najmniej-
```
```
szy poziom korekcji (domyśl-
```
```
nie),
```
```
1 – (4 słowa kodowe),
```
```
2 – (8 słowa kodowe),
```
```
3 – (16 słów kodowych),
```
...
```
8 – (512 słów kodowych) naj-
```
większy poziom korekcji - naj-
większa liczba dodatkowych
danych
cc Liczba kolumn danych w wydru-
kowanym kodzie kreskowym.
```
NIE Num. 1 (domyślnie)
```
..
30
rt Obrót drukowanego kodu NIE BOOL False – wydruk w poziomie
```
(domyślnie)
```
True – wydruk w pionie
hx Przełącznik pomiędzy trybami
```
wprowadzanych danych (Ascii /
```
```
szesnastkowo)
```
```
NIE BOOL False – tryb Ascii (domyślnie)
```
True - tryb Hex.
tx Komunikat do wydrukowania TAK Alfanum
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```

1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szero-
kości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
4. Polecenie niedostępne w FAWAG BOX 1.01.
Przykład:
[STX]pdf417code[TAB]px2[TAB]el0[TAB]cc2[TAB]rt1[TAB]hx0[TAB]txKOMUNIKAT[TAB]#C
RC16[ETX]

## [qrcode] przygotowanie do wydruku dwuwymiarowego kodu kreskowe-
go QrCode
Identyfikator polecenia:
qrcode
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
```
px Długość boku (w pikselach)
```
pojedynczego punktu kodu
NIE Num. Wartość minimalna:
```
2 (domyślnie)
```
el Poziom korekcji błędów NIE Num. Dopuszczalne wartości:
```
0 – (L 7%) najmniejszy poziom ko-
```
```
rekcji, (domyślnie)
```
```
1 – (M 15%)
```
```
2 – (Q 25%)
```
```
3 – (H 30%) największy poziom ko-
```
rekcji - największa liczba dodatko-
wych danych
hx Przełącznik pomiędzy trybami
```
wprowadzanych danych (Ascii
```
```
/ szesnastkowo)
```
```
NIE BOOL False – tryb Ascii (domyślnie)
```
True - tryb Hex.
tx Komunikat do wydrukowania TAK Alfanum
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Ilość danych możliwych do zakodowania jest zależna od parametrów wejściowych i szerokości papieru.
3. Maksymalna długość kodu to 2000 znaków (4000 znaków w formacie hex).
Przykład:
```plaintext
[STX]qrcode[TAB]px2[TAB]el0[TAB]hx1[TAB]tx313233343536373839[TAB]#CRC16[ETX]
```

Linie informacyjne
## [trftrln] Dodatkowe linie po transakcji
Identyfikator polecenia:
trftrln
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator linii TAK Num.
na Treść linii NIE Alfanum. W zależności od możliwości
mechanizmu i konfiguracji wy-
```
druku:
```
- do 40 znaków dla ustawień 40
```
znaków w linii (papier 57 mm)
```
- do 56 znaków dla ustawień 56
```
znaków w linii (papier 80 mm)
```
sw Podwójna szerokość znaku NIE BOOL True – znak poszerzony
sh Podwójna wysokość znaku NIE BOOL True – znak podwyższony
```
Id:
```
0 - Nr transakcji alfanumeryczny
1 - Punkty alfanumeryczny
2 - Suma punktów alfanumeryczny
3 - Nr rejestracyjny alfanumeryczny
4 - Nazwisko alfanumeryczny
5 - Karta alfanumeryczny
6 - Numer karty alfanumeryczny
7 - Ważna do alfanumeryczny
8 - Kasjer alfanumeryczny
9 - Nazw. kasjera alfanumeryczny
10 - Zaliczka alfanumeryczny
11 - Waluta alfanumeryczny
12 - Przelicznik alfanumeryczny
13 - Nr zamówienia alfanumeryczny
14 - Nr pracownika alfanumeryczny
15 - Nazw. pracownika alfanumeryczny

16 - Konto przed tr. alfanumeryczny
17 - Przyznano alfanumeryczny
18 - Wykorzystano alfanumeryczny
19 - Konto po trans. alfanumeryczny
20 - Klient stały alfanumeryczny
21 - Voucher alfanumeryczny
22 - Wartość Voucher alfanumeryczny
23 - Zapłata Voucher alfanumeryczny
24 - napis predefiniowany bez parametru
```
25 - linia bez słowa kluczowego (15
```
```
spacji)
```
alfanumeryczny
26 – Ilość sprzedanych towarów alfanumeryczny
27 – Numer pracownika alfanumeryczny
28 – Numer klienta alfanumeryczny
29 – Udzielono łącznie rabatów alfanumeryczny
30 – Numer alfanumeryczny
31 – Kod alfanumeryczny
32 – Nazwa alfanumeryczny
33 – Opis alfanumeryczny
34 – Liczba alfanumeryczny
35 – Klient alfanumeryczny
36 – Kwota alfanumeryczny
37 – Promocja alfanumeryczny
38 – Info alfanumeryczny
39 – Do faktury alfanumeryczny
40 – Ad. alfanumeryczny
41 – napis predefiniowany z uwzględ-
nieniem znaków formatujących
bez parametru
42 – napis predefiniowany z małą
czcionką
alfanumeryczny
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```

1. Flaga automatycznego zakończenia stopki paragonu (fe) w zakończeniu transakcji musi być
ustawiona na False
2. Nie można wysyłać dodatkowych linii przy wystawianiu faktury vat.
3. Po zakończeniu paragonu może być wydrukowanych do 60 linii.
4. Zakończenie wydruku następuje po wysłaniu rozkazu trftrend
5. Dostępność w trybie tylko do odczytu: NIE.
6. Dla id=41 oraz id=42, nie działają parametry sw i sh. Dla id=41 znaki formatujące są takie
jak w rozkazie ftrinfoset.
Przykład:
przykładowa transakcja:
```plaintext
[STX]trinit[TAB]bm0[TAB]#CRC16[ETX]
[STX]trline[TAB]naSok pomidorowy[TAB]vt1[TAB]pr350[TAB]il1[TAB]#CRC16[ETX]
[STX]trend[TAB]to350[TAB]op0[TAB]om0[TAB]fe0[TAB]#CRC16[ETX]
[STX]trftrln[TAB]id2[TAB]na987[TAB]#CRC16[ETX]
[STX]trftrln[TAB]id15[TAB]naJan Kowalski[TAB]#CRC16[ETX]
[STX]trftrend[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:155|
| PARAGON FISKALNY |
|Sok pomidorowy 1 x3,50 3,50B|
|- - - - - - - - - - - - - - - - - - - - |
|SPRZEDAŻ OPODATKOWANA B 3,50|
|PTU B 8,00 % 0,26|
|SUMA PTU 0,26|
|SUMA PLN 3,50|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|GOTÓWKA 3,50 PLN|
|00053 #001 KIEROWNIK 2018-09-10 13:11|
|1F062B7D07EDD2640DFA59228FFC0809B09DC27E|
```
| {PL} ZBF 1801007587 |
```
|Suma punktów: 987|
|Nazw. pracownika: Jan Kowalski|
Opis łamania tekstów:
Pojedyncza linia w zakończeniu transakcji jest projektowana na 40 znaków w linii dla słowa klu-
czowego i maksymalnie 40 znaków dla parametru. W przypadku czcionki o podwójnej szerokości
tekst który nie mieści się w linii może być podzielony na maksymalnie cztery linie. Podział na ko-
lejne linie wykonywany jest w miejscu wystąpienia spacji lub jeśli tekst po takim podziale nie
zmieści się w 2 linijkach to dzielony jest po przekroczeniu 20 znaków w linii. Tekst z parametrem
dzielony jest na maksymalnie 3 linie o ile pierwszy wyraz rozpoczyna się w tej samej linii co słowo
kluczowe. Tekst z parametrem wyrównywany jest do prawej strony.
Przykład wydruku dla pojedynczej szerokości znaku:
1234567890123456789012345678901234567890

Słowo kluczowe: tekst użytkownika
Przykłady wydruków dla podwójnej szerokości znaku:
123456789012345678901234567890
Słowo kluczowe: tekst użytkow.
123456789012345678901234567890
Słowo kluczowe: tekst
użytkownika
123456789012345678901234567890
Słowo_kluczowe_na_ponad_20_zna
ków_bez_spacji: tekst
123456789012345678901234567890
Słowo_kluczowe_na
ponad_20_znaków_ze_spacją:
tekst użytkownika
123456789012345678901234567890
Słowo kluczowe_na_ponad_20_zna
ków_ze_spacją: tekst
użytkownika
123456789012345678901234567890
Słowo kluczowe:
tekst_użytkownika
123456789012345678901234567890
Słowo kluczowe:
tekst_użytkownika_na_ponad_20_
znaków_bez_spacji
123456789012345678901234567890
Słowo_kluczowe_na_ponad_20_zna
ków_bez_spacji:
tekst_użytkownika_na_ponad_20_
znaków_bez_spacji
123456789012345678901234567890
Słowo_kluczowe_na_ponad_20_zna
ków_bez_spacji: tekst
uż._na_ponad_20_znaków_bez_spa
cji_po_tekst_spacja
123456789012345678901234567890
Słowo_kluczowe: tekst
uż._na_ponad_20_znaków_bez_spa
cji_po_tekst_spacja
123456789012345678901234567890
Słowo_kluczowe_na
```
ponad_20_zn_po_na_spacja:tekst
```
uż._na_ponad_20_znaków_bez_spa
cji_po_tekst_spacja

## [trftrend] Zakończenie stopki po transakcji
Identyfikator polecenia:
trftrend
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Rozkaz umożliwia zakończenie transakcji w której drukowane są opakowania lub dodatko-
```
we linie (trpackprnend, trftrln)
```
2. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
Przykład z wykorzystaniem rozkazu trftrend jak w rozkazie trftrln

## [stocash] Zwrot towaru
Identyfikator polecenia:
stocash
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
kw Kwota, za którą towar został na-
byty
TAK Num. Do 499999999999.
Dwie ostatnie cyfry stanowią
część ułamkową.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]stocash[TAB]kw456[TAB]#CRC16[ETX]
```
```
Wydruk:
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

## [packret] Zwrot opakowania
Identyfikator polecenia:
packret
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
kw Kwota opakowania TAK Kwota
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]packret[TAB]kw345[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:165|
| N I E F I S K A L N Y |
|- - - - - - - - - - - - - - - - - - - - |
|OPAKOWANIA ZWROTNE PRZYJĘCIA |
| Opakowanie zwr. 1x3,45 -3,45|
|OPAKOWANIA ZWROTNE SUMA -3,45|
|DO ZWROTU 3,45 PLN|
|- - - - - - - - - - - - - - - - - - - - |
|ROZLICZENIE PŁATNOŚCI |
|RESZTA GOTÓWKA 3,45 PLN|
| N I E F I S K A L N Y |
|#001 KIEROWNIK 2018-09-10 13:33|
|735012B4CAED2AB87DBE7CC416859A2E03D57921|
| ZBF 1801007587 |

## [login] Logowanie kasjera
Identyfikator polecenia:
login
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa kasjera TAK Alfanum. Tak jak w opisie rozkazu
ftrcfg.
nk Numer kasy NIE Alfanum. Długość do 8 znaków.
dr Flaga wydruku NIE BOOL Domyślnie False – bez wydru-
ku
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]login[TAB]naKAJTEK[TAB]dr1[TAB]nk11[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:169|
| N I E F I S K A L N Y |
| Rozpoczęcie pracy |
| kasjera |
|Kasjer Kajtek|
|Numer kasy 11|
| N I E F I S K A L N Y |
|#11 Kajtek 2018-09-10 13:49|
|38F355E7A42B696C64E9F9AE0689538DF0D25FCD|
| ZBF 1801007587 |

## [logout] Wylogowanie kasjera
Identyfikator polecenia:
logout
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
na Nazwa kasjera NIE Alfanum. Tak jak w opisie rozkazu
ftrcfg.
nk Numer kasy NIE Alfanum. Długość do 8 znaków.
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]logout[TAB]naKAJTEK[TAB]nk11[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:172|
| N I E F I S K A L N Y |
| Zakończenie pracy |
| kasjera |
|Kasjer Kajtek|
|Numer kasy 11|
| N I E F I S K A L N Y |
|#11 Kajtek 2018-09-10 13:53|
|889850FFC630592B9C9266CFE8A10A1E5EF2BF42|
| ZBF 1801007587 |

## [cash] Wpłata i wypłata z/do kasy
Identyfikator polecenia:
cash
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
kw Kwota wpłaty/wypłaty TAK Num. Do 499999999999.
Dwie ostatnie cyfry stanowią
część ułamkową.
wp Wpłata / wypłata TAK BOOL True - wpłata, False - wypłata
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: NIE.
Przykład:
```plaintext
[STX]cash[TAB]kw50[TAB]wpT[TAB]#CRC16[ETX]
```
```
Wydruk:
```
| POSNET THERMAL XL2 ONLINE |
| POSNET POLSKA S.A. |
| ul. Municypalna 33 |
| 02-281 Warszawa |
| www.posnet.com |
|NIP 5222628262 nr:176|
| N I E F I S K A L N Y |
|Wpłata do kasy 99,99|
| N I E F I S K A L N Y |
|#001 KIEROWNIK 2018-09-10 13:56|
|7E2CEEC0E0BCF7A4ACB8D5CEBAB12EEB99E29802|
| ZBF 1801007587 |

Statusy urządzenia
## [scomm] Status ogólny
Identyfikator polecenia:
scomm
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
fs Czy kasa jest w trybie fiskal-
```
nym? (T/N)
```
- BOOL True – tryb fiskalny
```
tz Czy totalizery są zerowe? (T/N) - BOOL True – totalizery zerowe
```
ts Typ rozpoczętej transakcji. - Num. 0 – brak transakcji
16 – paragon
17 – paragon w tryb. blokowym
33 – faktura
48 – opakowania
hr Czy zaprogramowany nagłó-
```
wek? (T/N)
```
- BOOL True – nagłówek zaprogramo-
wany
nu Numer identyfikacyjny - Alfanum. Patrz opis [progid].
```
td Czy tryb tylko do odczytu? (T/
```
```
N)
```
- BOOL True – urządzenie w stanie
TDO
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]scomm[TAB]#CRC16[ETX]
```

## [strns] Status transakcji
Identyfikator polecenia:
strns
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
```
to Czy transakcja jest otwarta? - Num. 0 – brak lub nieznany (np. po zerowaniu
```
```
RAM)
```
1 – otwarta
ts Rodzaj dokumentu, który jest właśnie
```
drukowany (jeśli to=1) lub też rodzaj do-
```
kumentu, który został wydrukowany jako
```
ostatni (jeśli to=0)
```
- Num. 0 – poza transakcją (np. po zerowaniu
```
RAM)
```
16 – paragon
17 – paragon w tryb. blokowym
33 – faktura
48 – opakowania
va Stan totalizera stawki A - Kwota Wartości totalizerów są zerowane po
wysłaniu rozkazu rozpoczynającego
```
transakcję lub w przypadku awarii (ze-
```
```
rowanie RAM).
```
vb Stan totalizera stawki B - Kwota
vc Stan totalizera stawki C - Kwota
vd Stan totalizera stawki D - Kwota
ve Stan totalizera stawki E - Kwota
vf Stan totalizera stawki F - Kwota
vg Stan totalizera stawki G - Kwota
```
pp Wartość opakowań (dodatnia) - Kwota
```
```
pm Wartość opakowań (ujemna) - Kwota
```
re Reszty - Kwota
fp Wpłaty w formie płatności - Kwota
fe Status zakończenia sekcji fiskalnej stop-
ki.
- Bool 1 – zakończono część fiskalną, ale nie
```
dokończono wydruku (przesłano trend,
```
```
nie przesłano trftrend)
```
0 – w przeciwnym wypadku
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]strns[TAB]#CRC16[ETX]
```

## [sfsk] Status pamięci fiskalnej
Identyfikator polecenia:
sfsk
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
fs Czy urządzenie jest w trybie fi-
```
skalnym? (T/N)
```
- BOOL True – tryb fiskakny
cl Licznik zerowań ram - Num.
rd Licznik raportów dobowych - Num.
vt Licznik zmian stawek VAT - Num.
va Wartosc stawki A w procentach - Num. Poprawna wartość procentowa
stawki zawiera się w granicach
```
(0 – 99,99)
```
Odsyłane jest zawsze siedem
stawek. Wartości przesyłane są
z przecinkiem.
101,00 – stawka nieaktywna
100,00 – stawka zwolniona
vb Wartosc stawki B w procentach - Num.
vc Wartosc stawki C w procentach - Num.
vd Wartosc stawki D w procentach - Num.
ve Wartosc stawki E w procentach - Num.
vf Wartosc stawki F w procentach - Num.
vg Wartosc stawki G w procentach - Num.
rw Data ostatniego raportu dobowe-
go
- Data
tm Data ostatniego raportu dobowe-
go
- Data i
czas
ISO8601
nu Numer identyfikacyjny - Alfanum. Patrz opis [progid].
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Dla fs = False, stałą wartość przyjmują parametry: cl=0, rd=0, vt=0, rw=”2000-01-
```
01;01:00”
```
Przykład odpowiedzi:

[STX]sfsk[TAB]fsT[TAB]cl1[TAB]rd14[TAB]vt5[TAB]va22,00[TAB]vb7,00[TAB]vc0,00[TAB]v
```
d3,00[TAB]ve101,00[TAB]vf101,00[TAB]vg100,00[TAB]rw2010-02-24;08:20[TAB]rw2010-02-
```
24T08:20:00+01:00[TAB]nuABC 1234567890[TAB]#CRC16 [ETX]

## [stot] Status totalizerów
Identyfikator polecenia:
stot
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymaga-
ny
Typ Uwagi
no Numer następnego raportu dobo-
wego
- Num.
fa Totalizer faktury w stawce A - Totalizer
fb Totalizer faktury w stawce B - Totalizer
fc Totalizer faktury w stawce C - Totalizer
fd Totalizer faktury w stawce D - Totalizer
fe Totalizer faktury w stawce E - Totalizer
ff Totalizer faktury w stawce F - Totalizer
fg Totalizer faktury w stawce G - Totalizer
fn Licznik faktur - Num.
pa Totalizer paragonu w stawce A - Totalizer
pb Totalizer paragonu w stawce B - Totalizer
pc Totalizer paragonu w stawce C - Totalizer
pd Totalizer paragonu w stawce D - Totalizer
pe Totalizer paragonu w stawce E - Totalizer
pf Totalizer paragonu w stawce F - Totalizer
pg Totalizer paragonu w stawce G - Totalizer
pn Licznik paragonów - Num.
ct Totalizer anulowanych parago-
nów
- Totalizer
cn Licznik anulowanych parago-
nów
- Num.
cc Liczba zmian w bazie towarowej - Num.
va Wartość stawki A - Num. Poprawna wartość procentowa

stawki zawiera się w grani-
```
cach (0 – 99,99)
```
Odsyłane jest zawsze siedem
stawek. Wartości przesyłane
są z przecinkiem.
101,00 – stawka nieaktywna
100,00 – stawka zwolniona
vb Wartość stawki B - Num.
vc Wartość stawki C - Num.
vd Wartość stawki D - Num.
ve Wartość stawki E - Num.
vf Wartość stawki F - Num.
vg Wartość stawki G - Num.
ds Data rozpoczęcia sprzedaży - Data i czas W przypadku braku sprzedaży
zwracana jest wartość 2000-
```
01-01;01:00
```
is Data rozpoczęcia sprzedaży - Data i czas
ISO8601
W przypadku braku sprzedaży
zwracana jest wartość 2000-
01-01T01:00:00+01:00
de Data zakończenia sprzedaży - Data i czas W przypadku braku sprzedaży
zwracana jest wartość 2000-
```
01-01;01:00
```
ie Data zakończenia sprzedaży - Data i czas
ISO8601
W przypadku braku sprzedaży
zwracana jest wartość 2000-
01-01T01:00:00+01:00
ft Totalizer anulowanych faktur - Num.
fl Licznik anulowanych faktur - Num.
nf Ilość wydruków niefiskalnych - Num.
bc Liczba sytuacji awaryjnych - Num.
le Liczba zdarzeń wykonanych
przez użytkownika
- Num.
oe Liczba zdarzeń wykonanych
ONLINE
- Num.
tf Liczba nieudanych prób przeka-
zu danych
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]stot[TAB]#CRC16[ETX]
```
Przykład odpowiedzi:
[STX]stot[tab]no1432[TAB]fa0[TAB]fb0[TAB]fc0[TAB]fd0[TAB]fe0[TAB]ff0[TAB]fg0[TAB]fn0
[TAB]pa233[TAB]pb112[TAB]pc4300[TAB]pd0[TAB]pe0[TAB]pf0[TAB]pg0[TAB]pn28[TAB]ct0
[TAB]cn0[TAB]cc5[TAB]va22,00[TAB]vb7,00[TAB]vc3,00[TAB]vd0[TAB]ve0[TAB]vf101,00[T

AB]vg100,00[TAB]ds2018-09-01:8:00[TAB]is2018-09-01T8:00:00+01:00[TAB]de2018-09–
```
01;16:00[TAB]ie2018-09–01T16:00:00+01:00[TAB]ft0[TAB]
```
fl0[TAB]nf10[TAB]bc1[TAB]le1[TAB]oe1[TAB]tf0[TAB]#CRC16[ETX]

## [scnt] Status liczników
Identyfikator polecenia:
scnt
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
rd Licznik raportów dobowych - Num.
hn Numer ostatnio wydrukowanego
nagłówka
- Num.
bn Licznik paragonów poprawnie
zakończonych
- Num.
fn Licznik faktur poprawnie zakoń-
czonych
- Num.
nu Numer identyfikacyjny - Alfanum. Patrz opis [progid].
bc Licznik paragonów anulowa-
nych
- Num.
bt Numer ostatniego paragonu - Num.
fc Licznik faktur anulowanych - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]scnt[TAB]#CRC16[ETX]
```

## [sprn] Status mechanizmu
Identyfikator polecenia:
!sprn, sprn
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
pr Status mechanizmu - Num. Status mechanizmu może
przyjmować następujące warto-
ści:
0 – brak błędu
1 – podniesiona dźwignia /
otwarta pokrywa
2 – brak dostępu do mechani-
zmu
3 – podniesiona pokrywa
5 – brak papieru – oryginał
6 – nieodpowiednia temperatu-
ra lub zasilanie
7 – chwilowy zanik zasilania
8 – błąd obcinacza
9 – błąd zasilacza
10 – podniesiona pokrywa przy
obcinaniu
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]!sprn[TAB]#CRC16[ETX]
```

## [sdev] Status ogólny
Identyfikator polecenia:
!sdev, sdev
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ds Status urządzenia. - Num. Status może przyjmować nastę-
pujące wartości:
0 – gotowość
1 – w menu
2 – oczekiwanie na klawisz
3 – oczekiwanie na reakcję
```
użytkownika (wystąpił błąd)
```
cp Czy jest podłączona ładowarka? - BOOL True – ładowarka podłączona
qe Czy kolejka rozkazów jest pu-
sta?
- BOOL True – kolejka pusta
pe Czy kończy się papier? - BOOL True – kończy się papier
Pole ważne o ile czujnik bli-
skiego końca papieru jest obec-
ny. W przeciwnym wypadku
zawsze zwraca False.
tl Status interfejsu komunikacyjne-
go wykorzystywanego w czasie
transakcji.
- Num. 0 – zasoby transakcji wolne
1 – zasoby transakcji zajęte
przez PC1
2 – zasoby transakcji zajęte
przez PC2
3 – zasoby transakcji zajęte
przez system urządzenia.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]!sdev[TAB]#CRC16[ETX]
```

## [sdrwr] Status szuflady
Identyfikator polecenia:
!sdrwr, sdrwr
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ds Status szuflady. - Num. 0 – otwarta
1 – zamknięta
2 – stan nieznany
ks Status kluczyka - Num. 0 – otwarty
1 – zamknięty
2 – stan nieznany
```
Uwagi:
```
1. Stan nieznany może wystąpić w przypadku gdy drukarka ma wyłączoną obsługę danego sta-
tusu, lub szuflada takim sygnałem nie dysponuje.
2. Polecenie niedostępne w drukarce Temo.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]!sdrwr[TAB]#CRC16[ETX]
```

## [progid] Programowanie własnej nazwy, wersji i numeru identyfikacyjne-
go
Ze względu na zmiany w przepisach zmienił się format numeru unikatowego co może powodować problemy z kompa-
tybilnością starszych programów komunikujących się z drukarkami Posnet. Aby wyjść naprzeciw użytkownikom takich
programów dokonano zmiany znaczenia pól odpowiedzi na statusy zawierające do tej pory numer unikatowy. Nowe
```
znaczenie tych pól to numer identyfikacyjny. Jednocześnie udostępniono polecenie ([progid]) pozwalające na zmianę
```
wartości tego numeru. Numer identyfikacyjny skonfigurowany w przy pomocy tego polecenia ma wpływ tylko na pro -
tokół komunikacyjny i odsyłany jest jedynie w poleceniach odczytu statusu urządzenia nie mających charakteru fiskal -
```
nego. Równocześnie dodano nowe polecenie pozwalające na odczytanie numeru unikatowego urządzenia ([getrealid]).
```
Domyślna wartość numeru identyfikacyjnego równa jest wartości numeru unikatowego urządzenia.
Jako dodatkowe udogodnienie polecenie [progid] pozwala na zmianę nazwy i numeru wersji oprogramowania urządze-
nia zwracanych w statusach protokołu.
Identyfikator polecenia:
progid
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
nm Typ urządzenia TAK Alfanum. Max 40 znaków
vr Wersja oprogramowania TAK Alfanum. Max 20 znaków
nu Numer identyfikacyjny TAK Alfanum. Max 20 znaków
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Wysłanie pustych parametrów nm, vr, nu powoduje wyczyszczenie programowanych wcze-
śniej danych i przywrócenie wartości oryginalnych.
Przykład odpowiedzi:
```plaintext
[STX]progid[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]progid[TAB]nmdrukarka1[TAB]vrv1.23[TAB]nuNumer 123[TAB]#CRC16[ETX]
```

## [resetprogid] Przywrócenie fabrycznych ustawień identyfikatorów
Patrz opis [progid].
Identyfikator polecenia:
resetprogid
Parametry wejściowe:
brak
Odpowiedź urządzenia:
standardowa
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```plaintext
[STX]resetprogid[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]resetprogid[TAB]#CRC16[ETX]
```

## [sid] Zaprogramowany typ i wersja oprogramowania
Identyfikator polecenia:
sid
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nm Zaprogramowany typ urzą-
dzenia
TAK Alfanum. Patrz opis [progid] i [getrealid].
vr Zaprogramowana wersja
oprogramowania
TAK Alfanum. Patrz opis [progid] i [getrealid].
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. W przypadku drukarki Thermal XL2 ONLINE S, wartością domyślną parametru nm (nie
```
zmodyfikowaną przez polecenie progid) jest „POSNET THERMAL XL2 ONLINE”.
```
Przykład odpowiedzi:
```plaintext
[STX]sid[TAB]nmDRUKARKA 1[TAB]vr9.12a[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]sid[TAB]#CRC16[ETX]
```

## [getprogfiscid] Zaprogramowany numer identyfikacyjny
Identyfikator polecenia:
getprogfiscid
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nu Zaprogramowany numer
identyfikacyjny
- Alfanum. Patrz opis [progid] i [getrealid].
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```plaintext
[STX]getprogfiscid[TAB]nuNumer 123#CRC16[ETX]
```
Przykład:
```plaintext
[STX]getprogfiscid[TAB]#CRC16[ETX]
```

## [getrealid] Odczyt fabrycznej nazwy, wersji i numeru unikatowego
Patrz opis [progid].
Identyfikator polecenia:
getrealid
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
nm Typ urządzenia - Alfanum. - Dla POSNET THERMAL XL2 ONLINE 2.01odsyłane jest: POSNET THERMAL XL2 ONLINE
- Dla POSNET THERMAL XL2 ONLINE S 2.01
odsyłane jest: POSNET THERMAL XL2 ONLINE S
- Dla POSNET THERMAL HD ONLINE 2.01
odsyłane jest: POSNET THERMAL HD ONLINE
- Dla POSNET TEMO ONLINE 2.01
odsyłane jest: POSNET TEMO ONLINE
- Dla POSNET TRIO ONLINE 2.01
odsyłane jest: POSNET TRIO ONLINE
- Dla POSNET POSPAY ONLINE 2.01
odsyłane jest: POSNET POSPAY ONLINE
- Dla POSNET THERMAL HX 1.01
odsyłane jest: POSNET THERMAL HX
- Dla POSNET THERMAL HX S 1.01
odsyłane jest: POSNET THERMAL HX S
- Dla POSNET VERO 2.01
odsyłane jest: POSNET VERO
- Dla POSNET EVO 1.01
odsyłane jest: POSNET EVO
- Dla FAWAG BOX 1.01
odsyłane jest: FAWAG BOX
vr Wersja oprogramowania - Alfanum. - Dla POSNET THERMAL XL2 ONLINE 2.01odsyłane jest: 30.01
- Dla POSNET THERMAL XL2 ONLINE S 2.01
odsyłane jest: 30.01
- Dla POSNET THERMAL HD ONLINE 2.01
odsyłane jest: 31.01
- Dla POSNET TEMO ONLINE 2.01
odsyłane jest: 32.01
- Dla POSNET TRIO ONLINE 2.01
odsyłane jest: 33.01
- Dla POSNET POSPAY ONLINE 2.01
odsyłane jest: 34.01
- Dla POSNET THERMAL HX 1.01
odsyłane jest: 38.01
- Dla POSNET THERMAL HX S 1.01
odsyłane jest: 38.01

- Dla POSNET VERO 2.01
odsyłane jest: 35.01
- Dla POSNET EVO 1.01
odsyłane jest: 39.01
- Dla FAWAG BOX 1.01
odsyłane jest: 52.01
nu Numer unikatowy - Alfanum.
```
vf Wersja urządzenia - Alfanum. Wersja wyświetlana na starcie urządzenia i drukowana naraporcie serwisowym (wersja programu pracy).
```
```
Uwagi:
```
1. Parametr vf jest zwracany w drukarce Fawag BOX i w nowszych urządzeniach.
2. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
[STX]getrealid[TAB]nmPOSNET THERMAL XL2 ONLINE[TAB]vr30.01[TAB]nuDDD
1234567891[TAB]vf2.01.A1B2C3D4[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]getrealid[TAB]#CRC16[ETX]
```

## [usetypeget] Odczyt typu użytkowania kasy
Identyfikator polecenia:
usetypeget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ty Typ użytkowania - Num. 1 – stała, 2 – rezerwowa, 3 – mo-
bilna, 4 – wirtualna, 5 – inny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie nie działa w trybie niefiskalnym.
Przykład odpowiedzi:
```plaintext
[STX]usetypeget[TAB]ty4[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]usetypeget[TAB]#CRC16[ETX]
```

## [ownershiptypeget] Odczyt typu własności kasy
Identyfikator polecenia:
ownershiptypeget
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ty Typ własności - Num. 1 – własność, 2 – dzierżawa, 3 –
leasing, 4 – wynajem, 5 – inny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Polecenie nie działa w trybie niefiskalnym.
Przykład odpowiedzi:
```plaintext
[STX]ownershiptypeget[TAB]ty1[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]ownershiptypeget[TAB]#CRC16[ETX]
```

## [sdspexternal] Status wyświetlacza wewnętrzny/zewnętrzny
Identyfikator polecenia:
!sdspexternal, sdspexternal
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza TAK Num. id = 1
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
id Identyfikator wyświetlacza - Num. id = 1
ex Czy wyświetlacz zewnętrzny? - BOOL False – wewnętrzny
True – zewnętrzny
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]!sdspexternal[TAB]id1[TAB]#CRC16[ETX]
```

## [scashstate] Niefiskalny stan kasy
Identyfikator polecenia:
scashstate
Parametry wejściowe:
brak
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
cs Niefiskalny stan kasy - Totalizer Maksymalna wartość odsyłana
to 4 999 999 999 99 .
```
Uwagi:
```
1. Po przekroczeniu maksymalnej wartości, stan kasy jest zerowany, a jego nowa wartość od-
powiada kwocie, która spowodowała to przekroczenie.
2. Wypłata o wartości przekraczającej stan kasy, powoduje wyzerowanie stanu kasy.
3. Dostępność w trybie tylko do odczytu: TAK.
Przykład:
```plaintext
[STX]scashstate[TAB]#CRC16[ETX]
```

Odczyt zawartości pamięci fiskalnej
## [fmrectypeget] Odczyt rekordów pamięci fiskalnej wg numerów
Identyfikator polecenia:
fmrectypeget
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu w pamięci fi-
skalnej
TAK Num. Pierwszy rekord ma numer 0.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
ty Typ odczytanego rekordu - Num. 0 brak rekordu
1 rekord raport dobowy
2 rekord zmiana stawek PTU
3 rekord zerowanie RAM
5 rekord przejścia w stan tylko do od-
czytu
6 rekord fiskalizacji
7 rekord zmiany waluty ewidencyjnej
8 rekord zmiany konfiguracji przeka-
zu danych
9 rekord aktualizacji programu
10 rekord nieudanej aktualizacji pro-
gramu
11 rekord wejścia/wyjścia w tryb ser-
wisowy
12 rekord wymiany pamięci chronio-
nej
13 rekord kasowania algorytmu wery-
fikującego
14 rekord zmiany źródła aktualizacji
programu pracy
15 rekord zmiany daty i czasu
16 rekord wymiany klucza publiczne-
go kasy
17 rekord przegląd techniczny
18 rekord błędu weryfikacji pamięci
chronionej
```
19 rekord awarii zasilania (POWER
```
```
FAIL)
```
20 rekord utraty ciągłości nr doku-
mentów
21 rekord błędu weryfikacji danych
22 rekord zapełnienia pamięci chro-
nionej

23 rekord zapełnienia pamięci fiskal-
nej
24 rekord odłączenie mech. drukują-
cego
25 rekord odłączenie wyświetlacza
nabywcy
26 rekord brak przekazu klucza pu-
blicznego
27 rekord zmiany adresu podatnika
no Kolejny numer rekordu danego
typu w pamięci fiskalnej
- Num. Numeracja dla każdego typu
rekordu jest oddzielna.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. W przypadku gdy szukany rekord nie zostanie odnaleziony, parametr ty przyjmuje wartość 0
lub zgłaszany błąd o kodzie 384 – „Brak rekordu w pamięci”.
Przykład odpowiedzi:
```plaintext
[STX]fmrectypeget[TAB]ty6[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]fmrectypeget[TAB]no0[TAB]#CRC16[ETX]
```

## [fmrecfindbydate] Odczyt rekordów pamięci fiskalnej wg czasu i daty
Identyfikator polecenia:
fmrecfindbydate
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
da Data i czas TAK Data i czas Zostanie odszukany rekord o
dacie i czasie równej przesła-
nej, lub pierwszy rekord po
dacie przesłanej.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu z pamięci fiskal-
nej liczony od 0.
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. W przypadku, gdy w pamięci fiskalnej znajdują się dwa rekordy o tej samej dacie i czasie,
rozkaz fmrecfindbydate odczytuje tylko ten z nich, który został zapisany jako pierwszy.
Przykład odpowiedzi:
```plaintext
[STX]fmrecfindbydate[TAB]no9[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]fmrecfindbydate[TAB]da2007-04-04,11:15[TAB]#CRC16[ETX]
```

## [fmrecrd] Odczyt rekordu raportu dobowego o zadanym numerze
Identyfikator polecenia:
fmrecrd
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu raportu dobowe-
go liczony od 1
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego raportu dobowego
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data wykonanie raportu dobowego - Data i czas
tm Data wykonanie raportu dobowego - Data i czas
ISO8601
no Numer raportu dobowego - Num.
fa Totalizer faktury w stawce A - Totalizer
fb Totalizer faktury w stawce B - Totalizer
fc Totalizer faktury w stawce C - Totalizer
fd Totalizer faktury w stawce D - Totalizer
fe Totalizer faktury w stawce E - Totalizer
ff Totalizer faktury w stawce F - Totalizer
fg Totalizer faktury w stawce G - Totalizer
fn Ilość faktur VAT - Num.
fo Kwota anulowanych faktur od
ostatniego raportu dobowego
- Totalizer Dwie ostatnie cyfry stanowią
część ułamkową.
fl Ilość anulowanych faktur od ostat-
niego raportu dobowego
- Num.
pa Totalizer paragonu w stawce A - Totalizer Dwie ostatnie cyfry stanowią
część ułamkową.pb Totalizer paragonu w stawce B - Totalizer
pc Totalizer paragonu w stawce C - Totalizer
pd Totalizer paragonu w stawce D - Totalizer
pe Totalizer paragonu w stawce E - Totalizer
pf Totalizer paragonu w stawce F - Totalizer
pg Totalizer paragonu w stawce G - Totalizer
pn Ilość wydrukowanych paragonów - Num.

od ostatniego raportu dobowego
ct Kwota anulowanych paragonów od
ostatniego raportu dobowego
- Totalizer Dwie ostatnie cyfry stanowią
część ułamkową.
cn Ilość anulowanych paragonów od
ostatniego raportu dobowego
- Num.
cc Liczba zmian w bazie towarowej od
ostatniego raportu dobowego
- Num.
nn Liczba wydruków dokumentów
niefiskalnych od ostatniego raportu
dobowego.
- Num.
ss Data rozpoczęcia sprzedaży objętej
raportem
- Data i czas Przy braku sprzedaży odsyłane
```
jest 2000-01-01;01:00
```
is Data rozpoczęcia sprzedaży objętej
raportem
- Data i czas
ISO8601
W przypadku braku sprzedaży
zwracana jest wartość 2000-01-
01T01:00:00+01:00
se Data zakończenia sprzedaży objętej
raportem
- Data i czas Przy braku sprzedaży odsyłane
```
jest 2000-01-01;01:00
```
ie Data zakończenia sprzedaży objętej
raportem
- Data i czas
ISO8601
W przypadku braku sprzedaży
zwracana jest wartość 2000-01-
01T01:00:00+01:00
fs Liczba sytuacji awaryjnych - Num.
lt Liczba zdarzeń wykonanych przez
użytkownika
- Num.
ot Liczba zdarzeń wykonanych ONLI-
NE
- Num.
ft Liczba nieudanych prób przekazu
danych od ostatniego raportu dobo-
wego
- Num.
si Podpis cyfrowy - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecrd[TAB]da2018-12-02;11:17[TAB]tm2018-12-02T11:17:00+01:00[TAB]
```
no5[TAB]fa0[TAB]fb0[TAB]fc0[TAB]fd0[TAB]fe0[TAB]ff0[TAB]fg0[TAB]fn0[TAB]fo0[TAB]fl0[TAB]pa224000[T
AB]pb168000[TAB]pc168000[TAB]pd0[TAB]pe0[TAB]pf0[TAB]pg0[TAB]pn2[TAB]ct0[TAB]cn0[TAB]cc10[TAB]n
```
n34[TAB]ss2007-12-01;11:17[TAB]is2007-12-01T11:17:00+01:00[TAB]se2007-12-02;11:10[TAB]ie2007-12-
```
02T11:10:00+01:00[TAB]fs4[TAB]lt33[TAB]ot[2]ft1[TAB] si815B08F337185F7500DC0F41736A2716412BFA08B
61A51F665686A51E1045633D976ED6C99F7F58B2FCC039C58B7AB6436C98E-
61622CDC766268B4B95893C932CC9D80D3E8FC1AAA9737C522925841CA47377EAC04C5DFF2059AEBE-
06CBBE0DFE673DA3D6327CE31ECB252606A6EBA1B86676996D65DEFED2000FFEDE-
945C8ED337500F2940C5685EE2728505329648CD3F45BAE7D6F2995A21895E59514386557E11360D1DA-
68446ABE7A65B3F2482D8D93D5E7C835AF03EBDE9BFABE-

31B6EFF90B544FCC900F5B92283CDBF74371F304D224C322EFEE0CA8BAC1ACF45ED80BE168DA142223BE-
CADC0D5336BEF96E20FF86511ABDADFCFA9700DFE96B4E95AC#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecrd[TAB]no4[TAB]#CRC16[ETX]
```

## [fmrecvat] Odczyt rekordu programowania stawek VAT o zadanym nu-
merze
Identyfikator polecenia:
fmrecvat
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu programowania
stawek liczony od 1
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu programo-
wania stawek
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data wykonania zmiany stawek - Data i czas
tm Data wykonania zmiany stawek - Data i czas
ISO8601
no Numer zmiany stawek - Num.
va Wartość stawki A - Num. Poprawna wartość procento-
wa stawki zawiera się w gra-
```
nicach (0 – 99,99)
```
Odsyłane jest zawsze siedem
stawek. Wartości przesyłane
są z przecinkiem.
101,00 – stawka nieaktywna
100,00 – stawka zwolniona
vb Wartość stawki B - Num.
vc Wartość stawki C - Num.
vd Wartość stawki D - Num.
ve Wartość stawki E - Num.
vf Wartość stawki F - Num.
vg Wartość stawki G - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecvat[TAB]da2007-11-29;11:13[TAB]tm2007-11-29T11:13:00+01:00[TAB]
```
no1[TAB]va22,00[TAB]vb7,00[TAB]vc3,00[TAB]vd101,00[TAB]ve101,00[TAB]vf101,00[TAB]v
g100,00[TAB]#CRC16[ETX]
Przykład:

```plaintext
[STX]fmrecvat[TAB]no4[TAB]#CRC16[ETX]
```
## [fmrecclr] Odczyt rekordu zerowania RAM o zadanym numerze
Identyfikator polecenia:
fmrecclr
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zerowania RAM
liczony od 1
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle da-
ne ostatniego rekordu zero-
wania RAM
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data zerowania RAM - Data i czas
tm Data zerowania RAM - Data i czas
ISO8601
no Numer zerowania - Num.
r1 Przyczyna zerowania 1 - Num.
r2 Przyczyna zerowania 2 - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
2. Interpretacja przyczyny zerowania RAM. Zerowanie RAM było typu:
▪ 'Z' gdy r1 i r2 są równe zeru
▪ 'W' gdy r1 lub r2 nie jest równe zeru
Przykład odpowiedzi:
```
[STX]fmrecclr[TAB]da2007-12-05;14:36[TAB]tm2007-12-05T14:36:00+01:00[TAB]
```
no1[TAB]r11028[TAB]r20[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecclr[TAB]no4[TAB]#CRC16[ETX]
```

## [fmrecfisc] Odczyt rekordu fiskalizacji urządzenia
Identyfikator polecenia:
fmrecfisc
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu fiskalizacji li-
czony od 1
NIE Num. Urządzenie zafiskalizowane posia-
da tylko jeden rekord fiskalizacji.
Urządzenie niezafiskalizowane nie
posiada żadnego rekordu fiskaliza-
cji.
Parametr no powinien przyjmować
wartość 1 lub powinien być pomija-
ny.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data fiskalizacji - Data i czas
tm Data fiskalizacji - Data i czas
ISO8601
ni Numer NIP urządzenia - Alfanum.
no Numer rekordu fisakalizacji - Num.
am Tryb pracy urządzenia - Num. 0 – standardowy, 1 – aptecz-
ny, 2 – wolnocłowy, 3 – bile-
towy
rn Numer ewidencyjny - Alfanum.
fn Numer fabryczny - Alfanum.
bc Rodzaj licznika paragonów - BOOL True – licznik dobowych
False – licznik ciągły
na Waluta ewidencyjna - Alfanum.
va Wartość stawki A w procentach - Num. Poprawna wartość procento-
wa stawki zawiera się w gra-
```
nicach (0 – 99,99)
```
Wartości przesyłane są z
przecinkiem.
101,00 – stawka nieaktywna
100,00 – stawka zwolniona
vb Wartość stawki B w procentach - Num.
vc Wartość stawki C w procentach - Num.
vd Wartość stawki D w procentach - Num.
ve Wartość stawki E w procentach - Num.
vf Wartość stawki F w procentach - Num.
vg Wartość stawki G w procentach - Num.

```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecfisc[TAB]da2018-11-19;11:13[TAB]tm2018-11-19T11:13:00+01:00[TAB]
```
no1[TAB]ni9998887766[TAB]am0[TAB]
rn2018/000003370[TAB]fnPO808011022[TAB]bcT#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecfisc[TAB]no1[TAB]#CRC16[ETX]
```

## [fmrecend] Odczyt rekordu przejścia w stan 'Tylko do odczytu'
Identyfikator polecenia:
fmrecend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu przejścia w stan
tylko do odczytu liczony od 1
NIE Num. Urządzenie zafiskalizowane
może posiadać tylko jeden re-
kord tego typu.
Parametr no powinien przyj-
mować wartość 1 lub powi-
nien być pomijany.
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data przejścia w stan tylko do
odczytu
- Data i czas
tm Data przejścia w stan tylko do
odczytu
- Data i czas
ISO8601
no Numer rekordu przejścia w stan
tylko do odczytu
- Num.
re Przyczyna przejścia w stan tylko
do odczytu
- Num. 0 – zapełnienie pamięci fi-
skalnej
1 – przekroczony limit zero-
wań pamięci
2 – przekroczony limit zda-
rzeń
3 – wykonanie raportu rozli-
czeniowego
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecend[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no1[TAB]re3[TAB]#CRC16[ETX]

Przykład:
```plaintext
[STX]fmrecend[TAB]no1[TAB]#CRC16[ETX]
```

## [fmreccurrency] Odczyt rekordu zmiany waluty
Identyfikator polecenia:
fmreccurrency
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zmiany waluty NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle da-
ne ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zmiany waluty - Data i czas
tm Data rekordu zmiany waluty Data i czas
ISO8601
no Numer rekordu - Num.
na Symbol waluty. - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmreccurrency[TAB]da2007-12-05;14:48[TAB]tm2007-12-05T14:48:00+01:00[TAB]
```
no2[TAB]naPLN[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmreccurrency[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecconnectionconfig] Odczyt rekordu zmiany adresu serwera CPD
Identyfikator polecenia:
fmrecconnectionconfig
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zmiany adresu
serwera
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zmiany adresu - Data i czas
tm Data rekordu zmiany adresu - Data i czas
ISO8601
no Numer rekordu - Num.
ad Adres serwera - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecconnectionconfig[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00
```
[TAB]no2[TAB]adhttps://esb-te.mf.gov.pl:5062/api/SerwerCPD/Command [TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecconnectionconfig[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecfirmwareupdate] Odczyt rekordu aktualizacji firmware
Identyfikator polecenia:
fmrecfirmwareupdate
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu aktualizacji NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle da-
ne ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu aktualizacji - Data i czas
tm Data rekordu aktualizacji - Data i czas
ISO8601
no Numer rekordu - Num.
fn Nazwa firmware - Alfanum.
ch Suma kontrolna - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecfirmwareupdate[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]fn4A98B32C[TAB] ch89748A97B93D74E-
579387589089014835656023577686022C34756F20113A536[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecfirmwareupdate[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecfirmwareupdatefail] Odczyt rekordu niepowodzenia aktualizacji
firmware
Identyfikator polecenia:
fmrecfirmwareupdate
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu niepowodzenia
aktualizacji
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle da-
ne ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu niepowodzenia ak-
tualizacji
- Data i czas
tm Data rekordu niepowodzenia ak-
tualizacji
- Data i czas
ISO8601
no Numer rekordu - Num.
ec Kod błędu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecfirmwareupdatefail[TAB]da2007-12-05;14:48[TAB]tm2007-12-05T14:48:00+01:00
```
[TAB]no2[TAB]ec3704[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecfirmwareupdatefail[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecservicemode] Odczyt rekordu wejścia/wyjścia z trybu serwisowe-
go
Identyfikator polecenia:
fmrecservicemode
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu we/wy z trybu
serwisowego
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu we/wy z trybu ser-
wisowego
- Data i czas
tm Data rekordu we/wy z trybu ser-
wisowego
- Data i czas
ISO8601
no Numer rekordu - Num.
en Wejście/wyjście z trybu serwiso-
wego
- BOOL True – wejście
False – wyjście
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecservicemode[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00
```
[TAB]no2[TAB]en1[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecservicemode[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecmemorychange] Odczyt rekordu wymiany pamięci chronionej
Identyfikator polecenia:
fmrecmemorychange
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu wymiany pamię-
ci chronionej
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu wymiany pamięci
chronionej
- Data i czas
tm Data rekordu wymiany pamięci
chronionej
- Data i czas
ISO8601
no Numer rekordu - Num.
lr Ostatni raport dobowy przenie-
siony do pamięci chronionej.
- Num.
ld Ostatni zapisany dokument w
pamięci chronionej.
- Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecmemorychange[TAB]da2019-05-13;08:18[TAB]tm2019-05-13T08:18:00+01:00
```
[TAB]no3[TAB]lr1125[TAB]ld23801[TAB] #CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecmemorychange[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecalgorithmerase] Odczyt rekordu kasowania algorytmu weryfikują-
cego
Identyfikator polecenia:
fmrecalgorithmerase
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu kasowania algo-
rytmu
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu kasowania algoryt-
mu
- Data i czas
tm Data rekordu kasowania algoryt-
mu
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecalgorithmerase[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecalgorithmerase[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecupdatesourcechange] Odczyt rekordu zmiany źródła aktualizacji
programu urządzenia
Identyfikator polecenia:
fmrecupdatesourcechange
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zmiany źródła
aktualizacji programu
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zmiany źródła ak-
tualizacji programu
- Data i czas
tm Data rekordu zmiany źródła ak-
tualizacji programu
- Data i czas
ISO8601
no Numer rekordu - Num.
ad Adres serwera aktualizacji Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecupdatesourcechange[TAB]da2018-12-05;14:48[TAB]tm2018-12-
```
05T14:48:00+01:00[TAB]no2[TAB]adhttps:/193.150.2.198/[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecupdatesourcechange[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecdatetime] Odczyt rekordu zmiany daty i czasu
Identyfikator polecenia:
fmrecdatetime
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zmiany daty i
czasu
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zmiany daty i cza-
su
- Data i czas
tm Data rekordu zmiany daty i cza-
su
- Data i czas
ISO8601
no Numer rekordu - Num.
nt Czas po zmianie - Data i czas
ni Czas po zmianie - Data i czas
ISO8601
ot Czas przed zmianą - Data i czas
oi Czas przed zmianą - Data i czas
ISO8601
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecdatetime[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
```
no2[TAB]nt2018-12-05;14:48[TAB]ni2018-12-05T14:48:00+01:00[TAB]ot2018-12-
```
```
05;14:45[TAB]oi2018-12-05T14:45:00+01:00[TAB]#CRC16[ETX]
```
Przykład:
```plaintext
[STX]fmrecdatetime[TAB]no2[TAB]#CRC16[ETX]
```

## [fmreckeychange] Odczyt rekordu wymiany klucza publicznego
Identyfikator polecenia:
fmreckeychange
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu wymiany klucza
publicznego
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle da-
ne ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu wymiany klucza
publicznego
- Data i czas
tm Data rekordu wymiany klucza
publicznego
- Data i czas
ISO8601
no Numer rekordu - Num.
fo Offset w pliku z certyfikatami - Num.
ty Typ klucza - Num. 0 – certyfikat TLS
1 – certyfikat JSON
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmreckeychange[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]fo100[TAB]ty0[TAB] #CRC16[ETX]
Przykład:
```plaintext
[STX]fmreckeychange[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecservice] Odczyt rekordu zdarzenia przeglądu technicznego
Identyfikator polecenia:
fmrecservice
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia prze-
glądu technicznego
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia przeglą-
du technicznego
- Data i czas
tm Data rekordu zdarzenia przeglą-
du technicznego
- Data i czas
ISO8601
no Numer rekordu - Num.
si Numer serwisanta - Alfanym.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecservice[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]si456100[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecservice[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecmemoryverification] Odczyt rekordu zdarzenia błędu weryfikacji
pamięci chronionej
Identyfikator polecenia:
fmrecmemoryverification
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia błędu
weryfikacji pamięci fiskalnej
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia błędu
weryfikacji pamięci chronionej
- Data i czas
tm Data rekordu zdarzenia błędu
weryfikacji pamięci chronionej
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecmemoryverification[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00
```
[TAB]no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecmemoryverification[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecpowerfail] Odczyt rekordu zdarzenia awarii zasilania
Identyfikator polecenia:
fmrecpowerfail
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia awarii
zasilania
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia awarii
zasilania
- Data i czas
tm Data rekordu zdarzenia awarii
zasilania
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecpowerfail[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecpowerfail[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecenumfail] Odczyt rekordu zdarzenia utraty ciągłości dokumentów
Identyfikator polecenia:
fmrecenumfail
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia utraty
ciągłości dokumentów
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia utraty
ciągłości dokumentów
- Data i czas
tm Data rekordu zdarzenia utraty
ciągłości dokumentów
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecenumfail[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecenumfail[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecdataverification] Odczyt rekordu zdarzenia błędu weryfikacji da-
nych
Identyfikator polecenia:
fmrecdataverification
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia błąd
weryfikacji danych
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia błąd we-
ryfikacji danych
- Data i czas
tm Data rekordu zdarzenia błąd we-
ryfikacji danych
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecdataverification[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecdataverification[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecprotmemoryfull] Odczyt rekordu zdarzenia zapełnienia pamięci
chronionej
Identyfikator polecenia:
fmrecprotmemoryfull
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia zapeł-
nienia pamięci chronionej
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle da-
ne ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia zapełnie-
nia pamięci chronionej
- Data i czas
tm Data rekordu zdarzenia zapełnie-
nia pamięci chronionej
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecprotmemoryfull[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecprotmemoryfull[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecfmmemoryfull] Odczyt rekordu zdarzenia zapełnienia pamięci fi-
skalnej
Identyfikator polecenia:
fmrecfmmemoryfull
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia zapeł-
nienia pamięci fiskalnej
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia zapełnie-
nia pamięci fiskalnej
- Data i czas
tm Data rekordu zdarzenia zapełnie-
nia pamięci fiskalnej
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecfmmemoryfull[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecfmmemoryfull[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecprinterdisconnected] Odczyt rekordu zdarzenia odłączenia me-
chanizmu drukującego
Identyfikator polecenia:
fmrecprinterdisconnected
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia odłą-
czenia mechanizmu drukującego
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia odłącze-
nia mechanizmu drukującego
- Data i czas
tm Data rekordu zdarzenia odłącze-
nia mechanizmu drukującego
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecprinterdisconnected[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00
```
[TAB]no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecprinterdisconnected[TAB]no2[TAB]#CRC16[ETX]
```

## [fmreclcddisconnected] Odczyt rekordu zdarzenia odłączenia wyświetla-
cza klienta
Identyfikator polecenia:
fmreclcddisconnected
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia odłą-
czenia wyświetlacza klienta
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia odłącze-
nia wyświetlacza klienta
- Data i czas
tm Data rekordu zdarzenia odłącze-
nia wyświetlacza klienta
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmreclcddisconnected[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmreclcddisconnected[TAB]no2[TAB]#CRC16[ETX]
```

## [fmreckeysend] Odczyt rekordu zdarzenia braku przekazu klucza pu-
blicznego
Identyfikator polecenia:
fmreckeysend
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia braku
przekazu klucza publicznego
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia braku
przekazu klucza publicznego
- Data i czas
tm Data rekordu zdarzenia braku
przekazu klucza publicznego
- Data i czas
ISO8601
no Numer rekordu - Num.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmreckeysend[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmreckeysend[TAB]no2[TAB]#CRC16[ETX]
```

## [fmrecaddress] Odczyt rekordu zdarzenia zmiany adresu podatnika
Identyfikator polecenia:
fmrecaddress
Parametry wejściowe:
Nazwa Opis Wymagany Typ Uwagi
no Numer rekordu zdarzenia zmia-
ny adresu podatnika
NIE Num. Jeśli pole no nie zostanie wy-
słane, urządzenie odeśle dane
ostatniego rekordu
Odpowiedź urządzenia:
Nazwa Opis Wymagany Typ Uwagi
da Data rekordu zdarzenia zmiany
adresu podatnika
- Data i czas
tm Data rekordu zdarzenia zmiany
adresu podatnika
- Data i czas
ISO8601
no Numer rekordu - Num.
pc Kod pocztowy - Alfanum.
ci Miasto - Alfanum.
po Poczta - Alfanum.
st Ulica - Alfanum.
nu Numer domu - Alfanum.
sn Numer lokalu - Alfanum.
```
Uwagi:
```
1. Dostępność w trybie tylko do odczytu: TAK.
Przykład odpowiedzi:
```
[STX]fmrecaddress[TAB]da2018-12-05;14:48[TAB]tm2018-12-05T14:48:00+01:00[TAB]
```
no2[TAB]pc00-950[TAB]ciWarszawa[TAB]poWarszawa[TAB]stGruszkowa[TAB]
nu456[TAB]sn7[TAB]#CRC16[ETX]
Przykład:
```plaintext
[STX]fmrecaddress[TAB]no2[TAB]#CRC16[ETX]
```

Znaki dopuszczalne w nazwach towarów
W nazwach towarów programowanych w drukarkach dopuszczalne są następujące znaki:
• w stronie kodowej WINDOWS-1250 drukowane są wszystkie znaki z zakresu
```c
0x20-0xFF.
```
• W innych stronach kodowych (Mazovia, Latin 2) powyżej 0x7F drukowane są
```
tylko znaki z alfabetu polskiego w odpowiednim kodowaniu oraz elementy bu-
dowy tabeli, pozostałe zamieniane są na spacje.
Nie wszystkie ze znaków dopuszczalnych są brane pod uwagę podczas weryfikacji
nazw towarów. Porównywane są tylko:
```
• litery (wraz z polskimi znakami diakrytycznymi) bez rozróżniania wielko-
```
ści,
• cyfry,
• przecinek, kropka, ukośniki „\” i „/” oraz „%”
Pozostałe znaki są pomijane przy weryfikacji.
```
Przykład 1:
Poniższe nazwy towarów są dopuszczalne:
– Coca-Cola
– cocacola
– COCACOLA
– coca cola
– COCA COLA
– <coca- - -cola>
– coca:cola
ale z punktu widzenia porównywania nazw towarów są tożsame.
Przykład 2:
Poniższe przykładowe nazwy towarów nie są dopuszczalne ponieważ są tożsame z na-
zwą pustą:
– ______________
– <<<<?????>>>>
– ??????????????
– :::::::::::::::::::::::::::
```
– ;;;;;;;;;;;;;;;;;;;;;;;;;;;
```
– ^^^^^^^^^^^^^^^^^^
– [[[[[[[[[[[[[[[[[[[[[[[[[[[
– ]]]]]]]]]]]]]]]]]]]]]]]]]]]
```
– <:;__?[^^^^^^]__ ?;:>
```
```
– (nazwa z samych spacji)
```

Obliczenia realizowane przez drukarkę
Najważniejsze obliczenia służące do obliczania podatku PTU, wykonywane są przez drukarkę w
```
trakcie:
```
```
• realizacji transakcji (drukowania paragonu fiskalnego),
```
• drukowania raportu dobowego,
```
• drukowania raportu okresowego (rozliczeniowego).
```
Kwota podatku PTU może być obliczana dwoma sposobami: na podstawie kwoty NETTO lub
```
kwoty BRUTTO. Z uwagi na konieczność zaokrągleń numerycznych wyników cząstkowych (i sta-
```
```
nu totalizerów) w każdym przypadku uzyskamy nieco inny wynik końcowy. Przyjęto więc sposób
```
```
realizacji obliczeń numerycznych (wynikający z uzgodnień z Ministerstwem Finansów) oparty o
```
założenie, że w systemie sprzedaży detalicznej podstawowe znaczenie mają kwoty BRUTTO. W
związku z tym, podczas wykonywania transakcji drukarka otrzymuje z aplikacji kwoty BRUTTO
```
dla poszczególnych pozycji paragonu. W TOTALIZERACH (licznikach) drukarki są akumulowane
```
```
wartości BRUTTO sprzedaży w poszczególnych grupach podatkowych (A, B, C, D, E, F, G).
```
Punktem wyjścia dla wszystkich obliczeń są aktualne wartości stawek podatkowych prze-
chowywanych w pamięci fiskalnej. Po włączeniu urządzenia, stawki PTU zapisane jako ostatnie do
pamięci fiskalnej, przepisywane są do tablicy STAWKA[A..G]. Zmiana stawek PTU powoduje za-
pis nowych wartości w pamięci fiskalnej oraz wpisanie ich do tablicy.
Obliczenia realizowane w trakcie transakcji
```
Podczas realizacji transakcji drukarka otrzymuje z aplikacji (od użytkownika) informacje o kolej-
```
```
nych pozycjach paragonu (sprzedanych artykułach). Z punktu widzenia obliczeń i rejestracji podat-
```
ku, w odniesieniu do każdego artykułu istotne są następujące informacje:
- nazwa artykułu,
- cena jednostkowa BRUTTO,
- ilość,
- kod stawki PTU,
- rabat/ narzut procentowy lub kwotowy,
- wartość pozycji BRUTTO.
Na początku realizacji transakcji drukarka zeruje sumy sprzedaży w grupach podatkowych
dla paragonu, umieszczane w tablicy BRUTTO[A..G], czyli wykonuje się:
```
BRUTTO[A] := 0;
```
```
BRUTTO[B] := 0;
```
```
BRUTTO[C] := 0;
```
```
BRUTTO[D] := 0;
```
```
BRUTTO[E] := 0;
```
```
BRUTTO[F] := 0;
```

BRUTTO[G] := 0.
Zerowana jest też kwota należności dla klienta:
```
P_TOTAL := 0;
```
```
(przyjęto oznaczenie P_TOTAL aby odróżnić tę wartość od kwoty TOTAL otrzymanej z systemu w
```
```
sekwencji kończącej transakcję)
```
Po otrzymaniu z każdej pozycji paragonu wartości BRUTTO i kodu stawki PTU,
gdzie PTU = A, B, C, D, E, F lub G , drukarka oblicza:
```
BRUTTO[PTU] := BRUTTO[PTU] + BRUTTO {brak rabatu/ narzutu}
```
lub
```
BRUTTO[PTU] := BRUTTO[PTU] + BRUTTO - RABAT {rabat kwotowy}
```
lub
```
BRUTTO[PTU] := BRUTTO[PTU] + BRUTTO po rabacie(wartość obliczana wg algorytmu
```
```
umieszczonego we wstępie ) { rabat %}
```
lub
```
BRUTTO[PTU] := BRUTTO[PTU] + BRUTTO + NARZUT {narzut kwotowy}
```
lub
```
BRUTTO[PTU] := BRUTTO[PTU] + BRUTTO*(1 + NARZUT/100) {narz. %}
```
```
oraz:
```
```
P_TOTAL := P_TOTAL + BRUTTO {brak rabatu/narzutu}
```
lub
```
P_TOTAL := P_TOTAL + BRUTTO – RABAT {rabat kwotowy}
```
lub
```
P_TOTAL := P_TOTAL + BRUTTO po rabacie (wartość obliczana wg algorytmu umieszczonego
```
```
we wstępie ) { rabat procentowy}
```
lub
```
P_TOTAL := P_TOTAL + BRUTTO + NARZUT {narzut kwotowy}
```
lub
```
P_TOTAL := P_TOTAL + BRUTTO * (1 + NARZUT/100) {narzut procentowy}
```
```
gdzie:
```
RABAT, NARZUT : umieszczana przez aplikację w sekwencji linii paragonu wartość pola RA-
```
BAT (procentowa lub kwotowa), powodująca zwiększenie lub zmniejszenie kwoty należności dla
```
klienta.

Wszystkie wyżej wymienione obliczenia są prowadzone z precyzją 10-cyfrową. Wystąpienie
```
nadmiaru obliczeniowego spowoduje zgłoszenie błędu (w tym przypadku będzie to zgłoszone jako
```
```
kod błędu 19 - błąd wartości CENA).
```
Wartość chwilowa P_TOTAL w przypadku realizacji transakcji w trybie "On-Line" jest też
```
wysyłana na wyświetlacze klienta i operatora (wraz z nazwą towaru).
```
```
UWAGA:
```
Naliczanie podatku PTU w grupach A..F jest prowadzone wg zasady:
Sumowanie kwot sprzedaży BRUTTO w grupach A..G i obliczanie kwot należnego podatku w gru-
pach na podstawie sum obliczanych jak wyżej.
```
Po zakończeniu transakcji przez system (odebraniu poprawnej sekwencji kończącej para-
```
```
gon) otrzymujemy wartości:
```
BRUTTO[A]...BRUTTO[G], P_TOTAL.
Wynik P_TOTAL porównywany jest z wartością TOTAL otrzymaną z systemu w sekwencji koń-
czącej paragon. Aby poprawnie zakończyć transakcję obie te kwoty muszą być jednakowe.
Jeżeli w sekwencji kończącej paragon przesłano niezerową wartość rabatu i niezerowy para-
```
metr Px ( Px - rodzaj rabatu/narzutu ) to następuje korekcja sum BRUTTO[A]..BRUTTO[G] we-
```
dług wzorów:
```
BRUTTO[PTU]:= wg algorytmu opisanego we wstępie {rabat %}
```
lub
```
BRUTTO[PTU]:= BRUTTO[PTU] - RABAT {rabat kwotowy}
```
lub
```
BRUTTO[PTU]:= BRUTTO[PTU]*( 1 + RABAT/100 ) {narzut %}
```
lub
```
BRUTTO[PTU]:= BRUTTO[PTU] + RABAT {narzut kwotowy}
```
```
gdzie:
```
```
RABAT : wartość rabatu lub narzutu (procentowa lub kwotowa) przesłana w sekwencji końca
```
paragonu w polu RABAT.
Przykład:
W przypadku narzutu procentowego :
```
BRUTTO[A] := BRUTTO[A] * (1 + RABAT / 100),
```
```
BRUTTO[B] := BRUTTO[B] * (1 + RABAT / 100),
```
```
BRUTTO[C] := BRUTTO[C] * (1 + RABAT / 100),
```
```
BRUTTO[D] := BRUTTO[D] * (1 + RABAT / 100),
```
```
BRUTTO[E] := BRUTTO[E] * (1 + RABAT / 100),
```
```
BRUTTO[F] := BRUTTO[F] * (1 + RABAT / 100),
```

```
BRUTTO[G] := BRUTTO[G] * (1 + RABAT / 100).
```
Tak uzyskane wyniki zaokrąglane są do 0,01 zł. Następnie obliczane są wartości podatku PTU w
grupach podatkowych:
```
PTU[A] := BRUTTO[A] * STAWKA[A] / (1 + STAWKA[A]),
```
```
PTU[B] := BRUTTO[B] * STAWKA[B] / (1 + STAWKA[B]),
```
```
PTU[C] := BRUTTO[C] * STAWKA[C] / (1 + STAWKA[C]),
```
```
PTU[D] := BRUTTO[D] * STAWKA[D] / (1 + STAWKA[D]),
```
```
PTU[E] := BRUTTO[E] * STAWKA[E] / (1 + STAWKA[E]),
```
```
PTU[F] := BRUTTO[F] * STAWKA[F] / (1 + STAWKA[F]),
```
```
PTU[G] := BRUTTO[G] * STAWKA[G] / (1 + STAWKA[G]).
```
```
(te wartości też są zaokrąglane do drugiej cyfry po przecinku)
```
Ostatecznie obliczane są wartości netto w grupach podatkowych:
NETTO[A] := BRUTTO[A] - PTU[A],
NETTO[B] := BRUTTO[B] - PTU[B],
NETTO[C] := BRUTTO[C] - PTU[C],
NETTO[D] := BRUTTO[D] - PTU[D],
```
NETTO[E} := BRUTTO[E] - PTU[E],
```
NETTO[F] := BRUTTO[F] - PTU[F],
NETTO[G] := BRUTTO[G] - PTU[G].
Na paragonie drukowane są te wartości BRUTTO[A]...BRUTTO[G], oraz PTU[A]...PTU[G], które
```
są niezerowe. Jeżeli nie występuje rabat/narzut, to kwota końcowa P_TOTAL (równa TOTAL) dru-
```
kowana jest czcionką o podwójnej szerokości jako kwota do zapłacenia przez klienta. Jeżeli nato-
```
miast występuje rabat/narzut, to kwota ta drukowana jest w linii o pojedynczej szerokości (pod ha-
```
```
słem 'PODSUMA:'). W następnej linii jest wielkość rabatu/narzutu , natomiast sumę należności dla
```
klienta wyliczamy jeszcze raz:
```
P_TOTAL := BRUTTO[A] + ..... + BRUTTO[G]
```
```
(ponieważ kwoty po prawej stronie równania zostały przeliczone wcześniej przy uwzględnieniu
```
```
wielkości rabatu/narzutu).
```
```
Tak uzyskana suma drukowana jest w linii o podwójnej szerokości (pod hasłem 'SUMA zł'), jako
```
ostateczna kwota należności dla klienta.
Jeżeli paragon zakończono sekwencją z uwzględnieniem kaucji, to ostateczna kwota do zapłaty
przez klienta jest liczona wg wzoru:
```
P_TOTAL := BRUTTO[A]+ ...+ BRUTTO[G]+KAUCJA_POBRANA-KAUCJA_ZWROCONA
```
Jeżeli w sekwencji kończącej transakcję aplikacja przesłała wartość wpłaty przez klienta
```
(WPLATA), to:
```

```
RESZTA := WPLATA - P_TOTAL;
```
Jeżeli wynik jest dodatni, to na paragonie drukowane są dwie dodatkowe linie zawierające wielkość
wpłaty oraz reszty.
Ostatnim etapem realizacji transakcji jest aktualizacja totalizerów drukarki, które zawierają
następujące lokacje:
- kwoty sprzedaży BRUTTO w grupach podatkowych:
TOT[A], TOT[B], TOT[C], TOT[D], TOT[E], TOT[F], TOT[G], oraz
- licznik paragonów fiskalnych PAR_NUM.
Licznik paragonów fiskalnych ma zakres 0.. 9999 i jest zwiększany przed wydrukowaniem jego
```
wartości w stopce paragonu oraz zerowany po wykonaniu raportu dobowego (licznik ten jest zero-
```
```
wany również po fiskalizacji i zerowaniu RAM).
```
Kwoty sprzedaży są aktualizowane zgodnie z kwotami BRUTTO obliczonymi dla paragonu w gru-
pach podatkowych:
TOT[A] := TOT[A] + BRUTTO[A],
TOT[B] := TOT[B] + BRUTTO[B],
TOT[C] := TOT[C] + BRUTTO[C],
TOT[D] := TOT[D] + BRUTTO[D],
TOT[E] := TOT[E] + BRUTTO[E],
TOT[F] := TOT[F] + BRUTTO[F],
TOT[G] := TOT[G] + BRUTTO[G].
Zakres licznika paragonów na raporcie dobowym wynosi: 9999, zakresy sum sprzedaży dobowej
wynoszą 499 999 999,99
Jeżeli w wyniku wykonania sekwencji kończącej paragon wystąpił błąd - przepełnienie totalizerów,
czyli obrót dzienny w co najmniej jednej z grup podatkowych przekracza powyższy zakres - należy
wtedy wykonać raport dobowy i ponowić wykonanie transakcji.
Obliczenia realizowane w trakcie drukowania raportu dobowego
Wykonanie raportu dobowego jest związane z następującymi operacjami:
- dzienna sprzedaż BRUTTO w grupach podatkowych (wartości TOT[A]...TOT[G] zostaje przepi-
```
sana z totalizerów do pamięci fiskalnej (pamięci trwałej PROM !),
```
- po dokonaniu tego zapisu lokacje totalizerów są zerowane,
- drukowany jest odpowiedni raport , zawierający kwoty NETTO sprzedaży w grupach podatko-
wych, kwoty należnego podatku dla danych grup podatkowych, łączną kwotę należnego podatku
oraz łączny obrót.
Technika obliczania danych dla raportu dobowego ma duże znaczenie, ponieważ stanowią one
podstawę do rozliczenia podatku PTU - w odróżnieniu od danych o należnym podatku zawartych

na paragonach, które mają charakter wyłącznie informacyjny.
Niezależnie od przyjętego sposobu obliczania PTU dla paragonów, z uwagi na zaokrąglenia nu-
meryczne, podatek obliczany na podstawie dziennej sprzedaży w grupach podatkowych będzie
nieco się różnić od uzyskanego ze zsumowania kwot PTU drukowanych na paragonach w danym
okresie.
Przyjęty sposób naliczania podatku dla raportu dobowego został uzgodniony z Ministerstwem Fi-
nansów i jest następujący:
1. Obliczane są kwoty należnego podatku PTU dla poszczególnych grup A..G, wg wyrażeń:
```
R_PTU[A] := TOT[A] * STAWKA[A] / (1 + STAWKA[A]),
```
............
```
R_PTU[G] := TOT[G] * STAWKA[G] / (1 + STAWKA[G]),
```
```
(przyjęto oznaczenia R_PTU[A]...R_PTU[G] dla odróżnienia od analogicznych kwot wylicza-
```
```
nych dla paragonu - te kwoty już nie wymagają zaokrąglenia).
```
2. Na raporcie dobowym są drukowane zarówno niezerowe jak i zerowe kwoty
```
R_PTU[A]...R_PTU[G] (nie dotyczy to stawek nieaktywnych i zwolnionych).
```
3. Kwoty sprzedaży NETTO dla poszczególnych grup podatkowych są wyliczane na podstawie
kwot sprzedaży BRUTTO akumulowanych w TOTALIZERACH drukarki, zwiększanych z każdą
```
transakcją (TOT[A]...TOT[G]) oraz takwoty należnego podatku PTU dla poszczególnych grup
```
A..G :
R_NETTO[A] := TOT[A] - R_PTU[A],
............
```
R_NETTO[G] := TOT[G] - R_PTU[G]).
```
```
(przyjęto oznaczenia R_NETTO[A]...R_NETTO[G] dla odróżnienia od analogicznych kwot wyli-
```
```
czanych dla paragonu). Wyniki powyższych obliczeń są zaokrąglane do pozycji 0,01 zł .
```
4. Na raporcie są zawsze drukowane kwoty R_NETTO[A]..R_NETTO[G] dla "aktywnych" stawek
```
PTU(nawet jeżeli odpowiednie kwoty są zerowe !).
```
Są one opatrzone tytułem:
SPRZED. OPODATK. PTU 'x',
gdzie 'x' = 'A'..'G' - identyfikuje grupę podatkową.
Ponadto drukowana jest sprzedaż w grupie zwolnionej od podatku, akumulowana w lokacji totali-
zera TOT[X] i oznaczona tytułem:
SPRZED. ZWOLN. PTU 'x'
gdzie 'x' - oznaczenie literowe stawki zwolnionej.
5. Obliczana jest łączna kwota należnego podatku oraz łączna sprzedaż:
```
TOT_PTU := R_PTU[A] + .... + R_PTU[G],
```
```
R_TOTAL := TOT[A] + .... + TOT[G],
```

```
(te obliczenia są prowadzone z precyzją 14-cyfrową, stąd nadmiar arytmetyczny nie może wystąpić,
```
```
nawet jeżeli wartości lokacji totalizerów TOT[A]..TOT[G] są bliskie maksymalnym).
```
6. Obie kwoty są drukowane na raporcie dobowym i opatrzone tytułami:
'ŁĄCZNA KWOTA PTU' oraz ŁĄCZNA NALEŻNOŚĆ'.
Na raporcie dobowym jest również drukowana liczba i kwota anulowanych paragonów a także licz-
ba paragonów fiskalnych wydrukowanych od ostatniego raportu dobowego. Licznik paragonów fi-
```
skalnych drukarki (lokacja PAR_NUM totalizerów) zlicza paragony i jest zerowany w momencie
```
drukowania raportu dobowego.
Uwaga !
Jeżeli było zerowanie RAM, to licznik paragonów został wyzerowany.
Aktualna liczba paragonów jest drukowana na raporcie pod tytułem:
'ILOŚĆ PARAGONÓW'.
Uwaga !
Jeżeli przed rozpoczęciem sprzedaży w danym dniu wykonywano zmiany w bazie towarowej
drukarki to na wydruku raportu dobowego pojawi się informacja o tych zmianach.
Obliczenia realizowane w trakcie drukowania raportu okresowego
Podstawowa część raportu okresowego składa się z sekwencyjnego opisu poszczególnych rekordów
```
(zapisów) w pamięci fiskalnej. Zapisy te dotyczą różnych sytuacji - mogą to być raporty dobowe,
```
zmiany stawek PTU, zerowania RAM i inne. Podstawowe znaczenie z punktu widzenia obliczeń i
rejestracji obrotu mają raporty dobowe. Technika obliczeniowa dla poszczególnych raportów dobo-
wych drukowanych w obrębie raportu okresowego jest identyczna jak opisana w poprzednim punk-
cie. Jest to oczywiste zważywszy, że wykonanie raportu dobowego polega między innymi na trwa-
łym wpisaniu stanu totalizerów drukarki do pamięci fiskalnej.
W trakcie raportu okresowego zapisy te są zatem odczytywane po kolei i wykonywane są identycz-
```
ne obliczenia jak dla raportu dobowego, z tą różnicą, że dane wejściowe (w powyższych wyraże-
```
```
niach TOT[A]...TOT[G]) nie pochodzą z totalizerów drukarki (jak w raporcie dobowym), lecz z pa-
```
mięci fiskalnej. Druga istotna różnica dotyczy stawek PTU. Przed rozpoczęciem drukowania rapor-
```
tu przeszukiwana jest pamięć fiskalna w celu wyznaczenia początkowych stawek PTU (znajdowa-
```
```
ny jest ostatni zapis o zmianach stawek PTU przed datą początkową raportu). Wyznaczone stawki
```
są drukowane jako pierwsze, pod nagłówkiem raportu okresowego . Obliczenia danych dla pierw-
szego raportu dobowego, ujętego w raporcie okresowym zakładają zapisane początkowo wartości
stawek. Jeżeli w trakcie drukowania raportu zostanie odkryty zapis o zmianie stawek , to zostaną
wydrukowane nowe wartości stawek PTU i w oparciu o nie będą prowadzone dalsze obliczenia dla
raportów dobowych .
Podczas drukowania raportu okresowego obliczane są na bieżąco sumy kwot BRUTTO i
kwot PTU dla całego raportu tj. po obliczeniu i wydrukowaniu danych dla każdego z odczytanych
raportów dobowych drukarka oblicza :
RO_BRUTTO[A] := RO_BRUTTO[A] + RD_BRUTTO[A],
..........
RO_BRUTTO[G] := RO_BRUTTO[G] + RD_BRUTTO[G],

```
oraz:
```
RO_PTU[A] := RO_PTU[A] + RD_PTU[A],
.........
RO_PTU[G] := RO_PTU[G] + RD_PTU[G],
```
wreszcie:
```
RO_NETTO[A] : = RO_BRUTTO[A] - RO_PTU[A],
...........
RO_NETTO[G] : = RO_BRUTTO[G] - RO_PTU[G],
```
gdzie:
```
RD_BRUTTO[A]..RD_BRUTTO_[G], RD_PTU[A]..RD_PTU[G]
są wartościami obliczonymi dla danego raportu dobowego zapisanego w pamięci fiskalnej.
Ostatecznie obliczane są łączne wartości podatku i należności:
```
RO_TOT_PTU := RO_PTU[A] + RO_PTU[B] + ....... + RO_PTU[G],
```
```
RO_TOTAL := RO_BRUTTO[A] + RO_BRUTTO[B] + ......+ RO_BRUTTO[G],
```
Wszystkie wyżej wymienione obliczenia są prowadzone z precyzją 14-cyfrową, co daje maksymal-
ny możliwy obrót w okresie objętym raportem okresowym równy: 999 999 999 999,99 zł, nie nale-
ży zatem spodziewać się nadmiaru arytmetycznego.
Uzyskane kwoty :
RO_NETTO[A]..RO_NETTO[G], RO_PTU[A]..RO_PTU[G], RD_TOT_PTU,RD_TOTAL
są zatem sumami odpowiednich pozycji z poszczególnych raportów cząstkowych. Zwróćmy uwagę,
że nie może być inaczej, ze względu na sygnalizowane wcześniej możliwe zmiany stawek PTU.
```
Z tego względu (nawet jeżeli stawki PTU w trakcie drukowania całego raportu są stałe) kontrola
```
obliczania kwot należnego podatku w oparciu o sumy RO_NETTO[A]..RO_NETTO[G]
```
może wykazać nieznaczny błąd obliczeniowy (zaokrąglenia kwot cząstkowych
```
```
RO_NETTO[A]..RO_NETTO[G] !).
```
```
Kwoty:
```
RO_NETTO[A]..RO_NETTO[F], RO_PTU[A]..RO_PTU[G], RD_TOT_PTU, RD_TOTAL
są drukowane na końcu raportu, w jego podsumowaniu zatytułowanym:
'ŁĄCZNY RAPORT OKRESOWY'
Ponadto drukowana jest suma kwot sprzedaży w grupach zwolnionych od podatku, akumulowanych
w lokacji totalizerów zaprogramowanych ze stawką zwolnioną. Np.: jeśli zaprogramowano stawki
zwolnione F i G, to kwota sumy sprzedaży w tych stawkach oznaczona jest tytułem:
'SPRZED. ZWOLN. PTU F, G'
Jeżeli w raportowanym okresie wystąpiła zmiana stawek PTU, to w łącznym raporcie okresowym,
```
przy pozycjach KWOTA PTU 'x' (gdzie 'x' = A...G) zmienionej stawki pojawi się znak '+'.
```
```
UWAGA:
```

```
Powyższe informacje dotyczą wszystkich raportów okresowych (od ... do, miesięcznego i raportu
```
```
rozliczeniowego).
```
Rozliczanie groszy
W przypadku gdy suma poszczególnych totalizerów wynikająca z obliczeń nie równa się wysokości
paragonu po udzieleniu rabatu/narzutu kwotowego, lub wysokości rabatu/narzutu nie da się rozdzie-
lić poszczególnym totalizerom przy wykorzystaniu arytmetyki, stosowany jest następujący algo-
rytm dystrybucji nadmiarowych groszy:
Rabat procentowy
W drukarce rabat procentowy obliczany jest dwiema metodami w zależności od konfiguracji urzą-
```
dzenia:
```
Metoda 1:
```
wartość' = (( 100- R) * wartość) / 100
```
```
Rabat = wartość - wartość' -kwota rabatu
```
Metoda 2:
```
Rabat = (wartość * R)/100 -kwota rabatu
```
Wartość' = wartość - Rabat
wartość - wartość przed rabatem
wartość' - wartość po rabacie
R - wartość procentowa rabatu
Narzut procentowy
```
Narzutx' = (Xvatx * N)/100
```
Xvatx' = Xvatx + Narzutx'
Rabat kwotowy
```
r: kwota rabatu
```
XvA...XvG: kwota sprzedaży dla poszczególnych stawek VAT przed rabatem
```
Xa = Suma(XvA...XvG): podsuma przed rabatem
```
```
XaPo = Xa – r : podsuma po rabacie
```
Inicjujemy roboczy parametr
```
Z = 0
```
```
Dla każdej i-tej stawki VAT (gdzie i = A..G) wyliczamy kwotę sprzedaży po rabacie, zaokrąglając w
```
dół do pełnych groszy:
```
XviPo = (Xvi * XaPo) / Xa
```
a do Z dodajemy resztę z powyższego dzielenia

```
Z = Z + ((Xvi * XaPo) mod Xa)
```
Jeśli w danej iteracji wartość Z osiągnęła lub przekroczyła wartość Xa, wówczas obliczoną w tej
iteracji kwotę sprzedaży XviPo zwiększamy o 1 grosz, zaś wartość Z zmniejszamy o Xa:
```
XviPo = XiPo + 1
```
```
Z = Z - Xa
```
Narzut kwotowy
Kwoty sprzedaży przy narzucie kwotowym wyliczane są analogicznie jak przy rabacie kwotowym,
z tą różnicą, że wartość narzutu jest dodawany do kwoty podsumy.
```
n: kwota narzutu
```
XvA...XvG: kwota sprzedaży dla poszczególnych stawek VAT przed narzutem
```
Xa = Suma(XvA...XvG): podsuma przed narzutem
```
```
XaPo = Xa + n : podsuma po narzucie
```
Inicjujemy roboczy parametr
```
Z = 0
```
```
Dla każdej i-tej stawki VAT (gdzie i = A..G) wyliczamy kwotę sprzedaży po narzucie, zaokrąglając
```
w dół do pełnych groszy:
```
XviPo = (Xvi * XaPo) / Xa
```
a do Z dodajemy resztę z powyższego dzielenia
```
Z = Z + ((Xvi * XaPo) mod Xa)
```
Jeśli w danej iteracji wartość Z osiągnęła lub przekroczyła wartość Xa, wówczas obliczoną w tej
iteracji kwotę sprzedaży XviPo zwiększamy o 1 grosz, zaś wartość Z zmniejszamy o Xa:
```
XviPo = XiPo + 1
```
```
Z = Z – Xa
```
```
UWAGI:
```
Korekcja totalizerów nie może spowodować zmniejszenia wartości totalizera w przypadku kiedy
udzielony był narzut, ani powiększenia wartości totalizera w przypadku kiedy udzielony został ra-
bat.

Opisy błędów
Błędy ramki
LP MNEMONIK OPIS
1 PROTO_ERR_CMD_UNKNOWN Nierozpoznana komenda
2 PROTO_ERR_CMD_MANDATORY_FIELDS Brak obowiązkowego pola
```
3 PROTO_ERR_DATA_CONVERSION Błąd konwersji pola (np.: przesłana została wartość z przecinkiem w polu które-
```
go wartość przesyła się w częściach setnych np.: 12,34 zamiast 1234, lub prze-
```
kroczony zakres danych)
```
4 PROTO_ERR_TOKEN_INVALID Błędny token
5 PROTO_ERR_CRC_INVALID Zła suma kontrolna
6 PROTO_ERR_FLD_INVALID Błąd budowy ramki, brak mnemonika parametru
7-9 Zarezerwowane Zarezerwowane
10 PROTO_ERR_DATA_LENGTH Niewłaściwa długość pola danych
11 PROTO_ERR_INPUT_BUFFER_OVERRUN Zapełniony bufor odbiorczy
12 PROTO_ERR_CMD_IMMEDIATE_FORBIDDEN Nie można wykonać rozkazu w trybie natychmiastowym
13 PROTO_ERR_TOKEN_NOT_FOUND Nie znaleziono rozkazu o podanym tokenie
14 PROTO_ERR_INPUT_QUEUE_FULL Zapełniona kolejka wejściowa
15 PROTO_ERR_SYNTAX Błąd budowy ramki, brak sumy kontrolnej
Błędy poleceń
LP MNEMONIK OPIS
30 ERR_CANCEL Błąd nietypowy - rezygnacja, przerwanie funkcji
40 ERR_CMD_BLOCKED_FOR_INTERFACE Komenda niedozwolona dla danego interfejsu
41 ERR_CMD_TRY_LATER Zasoby zajęte przez inny interfejs
50 ERR_UNKN Błąd wykonywania operacji przez kasę
51 ERR_ASSERT_FM Błąd wykonywania operacji przez kasę
52 ERR_ASSERT_DB Błąd wykonywania operacji przez kasę
53 ERR_ASSERT_SALE Błąd wykonywania operacji przez kasę
54 ERR_ASSERT_UI Błąd wykonywania operacji przez kasę
55 ERR_ASSERT_CFG Błąd wykonywania operacji przez kasę
56 ERR_ASSERT_CM Błąd wykonywania operacji przez kasę
323 ERR_OPER_BLOCKED Funkcja zablokowana w konfiguracji
360 ERR_SERVICE_SWITCH_FOUND Znaleziono zworę serwisową
361 ERR_SERVICE_SWITCH_NOT_FOUND Nie znaleziono zwory
364 ERR_WRONG_PASSWORD_FORMAT Błędne hasło w sensie niezgodności z poprawnością składniową
365 ERR_WRONG_AUTHORIZATION Błędne hasło w sensie niezgodności z tym z bazy
382 ERR_RD_ZERO Próba wykonania raportu zerowego
383 ERR_RD_NOT_PRINTED Brak raportu dobowego
384 ERR_FM_NO_REC Brak rekordu w pamięci
387 ERR_SL_FM_LOCKED Sprzedaż zablokowana. Brak miejsca w pamięci
388 ERR_FM_LOCKED Operacja zablokowana. Brak miejsca w pamięci
400 ERR_WRONG_VALUE Błędna wartość
404 ERR_WRONG_CONTROL_CODE Wprowadzono nieprawidłowy kod kontrolny

LP MNEMONIK OPIS
460 ERR_CLOCK_RTC_FSK Błąd zegara w trybie fiskalnym
461 ERR_CLOCK_RTC_NFSK Błąd zegara w trybie niefiskalnym
462 ERR_CLOCK_RTC_SYNC Błąd synchronizacji zegara z serwerem
463 ERR_TIME_NOT_EXIST Podana data nie istnieje
464 ERR_INVALID_ZONE Nieprawidłowa strefa czasowa
480 ERR_AUTH_AUTHORIZED Drukarka już autoryzowana, bezterminowo
481 ERR_AUTH_NOT_STARTED Nie rozpoczęto jeszcze autoryzacji
482 ERR_AUTH_WAS_ADDED Kod już wprowadzony
483 ERR_AUTH_DAY_CNT Próba wprowadzenia błędnych wartości
484 ERR_AUTH_BLOCKED Minął czas pracy kasy, sprzedaż zablokowana
485 ERR_AUTH_BAD_CODE Błędny kod autoryzacji
486 ERR_AUTH_TOO_MANY_WRONG_CODES Blokada autoryzacji. Wprowadź kod z klawiatury
487 ERR_AUTH_ALL_CODES_USED Użyto już maksymalnej liczby kodów
488 ERR_BLOCKED Subskrypcja wygasła, sprzedaż zablokowana
499 ERR_ACTIVE_PROTO_THERMAL Aktywny protokół Thermal. Proszę zmienić protokół
500 ERR_STAT_MIN_OVF Przepełnienie statystyki minimalnej
501 ERR_STAT_MAX_OVF Przepełnienie statystyki maksymalnej
502 ERR_CASH_IN_MAX_OVF Przepełnienie stanu kasy
```
503 ERR_CASH_OUT_BELOW_0 Wartość stanu kasy po wypłacie staje się ujemna (przyjmuje się stan zerowy kasy)
```
700 ERR_INVALID_IP_ADDR Błędny adres IP
701 ERR_INVALID_TONE_NUMBER Błąd numeru tonu
702 ERR_ILLEGAL_DRAWER_IMPULSE_LEN Błąd długości impulsu szuflady
703 ERR_ILLEGAL_VAT_RATE Błąd stawki VAT
705 ERR_INVALID_SLEEP_TIME Błąd czasu uśpienia
706 ERR_INVALID_TURNOFF_TIME Błąd czasu wyłączenia
709 ERR_ILLEGAL_HDR_ATTR Błędny atrybut nagłówka
713 ERR_CONFIG_SET Błędne parametry konfiguracji
714 ERR_ILLEGAL_DSP_CONTRAST Błędna wartość kontrastu wyświetlacza
715 ERR_ILLEGAL_DSP_LUMIN Błędna wartość podświetlenia wyświetlacza
716 ERR_ILLEGAL_DSP_OFF_DELAY Błędna wartość czasu zaniku podświetlenia
717 ERR_LINE_TOO_LONG Za długa linia nagłówka albo stopki
718 ERR_ILLEGAL_COMM_CFG Błędna konfiguracja komunikacji
719 ERR_ILLEGAL_PROTOCOL_CFG Błędna konfiguracja protokołu kom
720 ERR_ILLEGAL_PORT Błędny identyfikator portu
721 ERR_ILLEGAL_INFO_TXT_NUM Błędny numer tekstu reklamowego
722 ERR_ILLEGAL_TIME_DIFF Podany czas wychodzi poza wymagany zakres
723 ERR_ILLEGAL_TIME Podana data/czas niepoprawne
724 ERR_ILLEGAL_HOUR_DIFF Inna godzina w różnicach czasowych 0<=>23
726 ERR_ILLEGAL_DSP_LINE_CONTENT Błędna zawartość tekstu w linii wyświetlacza
727 ERR_ILLEGAL_DSP_SCROLL_VALUE Błędna wartość dla przewijania na wyświetlaczu
728 ERR_ILLEGAL_PORT_CFG Błędna konfiguracja portu
729 ERR_INVALID_MONITOR_CFG Błędna konfiguracja monitora transakcji
730 ERR_PORT_BUSY_PC_1 Port zajęty przez PC1
731 ERR_PORT_BUSY_TCPIP Port zajęty przez TCP/IP
732 ERR_PORT_BUSY_SALE_MON Port zajęty przez monitor
733 ERR_PORT_BUSY Port zajęty
734 ERR_PORT_BUSY_TUNNEL Port zajęty przez tunelowanie
735 ERR_IP_PORT_RESERVED Port zarezerwowany na usługi systemowe
736 ERR_PORT_BUSY_PC_2 Port zajęty przez PC2
738 ERR_NET_CONFIG Nieprawidłowa konfiguracja sieci
739 ERR_ILLEGAL_DSP_ID Nieprawidłowy typ wyświetlacza
740 ERR_ILLEGAL_DSP_ID_FOR_OFF_DELAY Dla tego typu wyświetlacza nie można ustawić czasu zaniku podświetlenia
741 ERR_ILLEGAL_POWER_IND_INTERVAL Wartość czasu spoza zakresu
745 ERR_ILLEGAL_CODE_PAGE_CFG Błędny numer strony kodowej
746 ERR_INVALID_MONITOR_FRAME_CFG Błędna konfiguracja ramki monitora transakcji

LP MNEMONIK OPIS
747 ERR_DHCP_ACTIVE_FUNCTION_UNAVAILABLE DHCP aktywne. Funkcja niedostępna
748 ERR_DHCP_FORBIDDEN DHCP dozwolone tylko przy transmisji sieciowej
752 ERR_THERMAL_OVER_TCPIP Protokół Thermal jest niedostępny po interfejsie TCP/IP
762 ERR_IP_NOT_FOUND Nie znaleziono adresu IP
820 ERR_TEST Negatywny wynik testu
821 ERR_TEST_NO_CONF Brak testowanej opcji w konfiguracji
857 ERR_DF_DB_NO_MEM Brak pamięci na inicjalizację bazy drukarkowej
901 ERR_DB_REC_EXISTS Rekord już zaprogramowany
903 ERR_DB_NO_RECORD Rekord nie istnieje
905 ERR_DB_BASE_FULL Baza jest pełna
910 ERR_DB_NAME_NOT_UNIQUE Nazwa nie jest unikalna
974 ERR_DB_ILLEGAL_CNTX Niepoprawny kontekst bazy danych
975 ERR_DB_CNTX_END Nie ma więcej rekordów wg kontekstu
1000 ERR_FATAL_FM Błąd fatalny pamięci fiskalnej
1001 ERR_FM_NCONN Wypięta pamięć fiskalna
1002 ERR_FM_WRITE Błąd zapisu
1003 ERR_FM_UNKN Błąd nie ujęty w specyfikacji bios
1004 ERR_FM_CHKSUM_CNT Błędne sumy kontrolne
1006 ERR_FM_COMM Błąd komunikacji z pamięcią fiskalną
1007 ERR_FM_BAD_REC_ID Błędny id rekordu
1010 ERR_FM_NU_PRESENT Numer unikatowy już zapisany
1011 ERR_FM_NU_NO_PRESENT_FSK Brak numeru w trybie fiskalnym
1012 ERR_FM_NU_WRITE Błąd zapisu numeru unikatowego
1013 ERR_FM_NU_FULL Przepełnienie numerów unikatowych
1015 ERR_FM_TIN_CNT Więcej niż jeden NIP
1016 ERR_FM_READ_ONLY_NFSK Kasa w trybie do odczytu bez rekordu fiskalizacji
1017 ERR_FM_CLR_RAM_CNT Przekroczono liczbę zerowań RAM
1018 ERR_FM_REP_DAY_CNT Przekroczono liczbę raportów dobowych
1025 ERR_FM_NU_FORMAT Błędny format numeru unikatowego
1028 ERR_FM_REC_EMPTY Rekord w pamięci fiskalnej nie istnieje - obszar pusty
1029 ERR_FM_REC_DATE Rekord w pamięci fiskalnej z datą wcześniejszą od poprzedniego
1036 ERR_FM_EC_INTEGRITY Niezgodność danych pamięci chronionej
1037 ERR_FM_PROTMEM_INTEGRITY Niezgodność danych pamięci chronionej.
1038 ERR_FM_PROTMEM_VERIFY_ERROR Błąd weryfikacji pamięci chronionej.
1039 ERR_FM_PROTMEM_FULL Pamięć chroniona zapełniona
1040 ERR_FM_EC_INTEGRITY_DOC Niezgodność danych pamięci chronionej
1041 ERR_FM_PROTMEM_ACCESS Błąd dostępu do pamięci chronionej.
1044 ERR_FM_INCOMPLETE_FSK Nieudana fiskalizacja
1045 ERR_FM_REC_DATA_WITH_LATER_DATE Data i czas wcześniejsze od daty ostatniego zapisu do pamięci fiskalnej.
1050 ERR_FM_APP_MODE_FULL Przekroczona liczba zapisów trybów pracy
1051 ERR_FM_APP_MODE_EMPTY Obszar konfiguracji trybów pracy jest pusty
1052 ERR_FM_APP_MODE_READ Błąd odczytu trybu pracy
1053 ERR_FM_READ Błąd odczytu
1054 ERR_FM_READ_FACTORY_NUMBER Brak numeru fabrycznego!
1055 ERR_FM_FACTORY_NUMBER_ALREADY_SET Numer fabryczny już zapisany!
1056 ERR_FM_FACTORY_NUMBER_WRONG_FORMAT Nieprawidłowy format numeru fabrycznego.
1057 ERR_FM_FSK_INCOMPLETE_DATA Dane niekompletne
1060 ERR_FM_FILE_NOT_FOUND Brak pliku w pamięci fiskalnej.
1061 ERR_FM_FILE_OPEN Błąd otwarcia pliku w pamięci fiskalnej.
1062 ERR_FM_FILE_OPEN_RESOURCES Brak zasobów do otwarcia pliku
1063 ERR_FM_FILE_ALREADY_OPEN Plik w pamięci fiskalnej już otwarty.
1064 ERR_FM_FILE_READ Błąd odczytu pliku w pamięci fiskalnej.
1066 ERR_FM_FILE_WRITE Błąd zapisu pliku w pamięci fiskalnej.
1067 ERR_FM_FILE_CREATE Błąd utworzenia pliku w pamięci fiskalnej.
1068 ERR_FM_FILE_ALREADY_EXIST Plik w pamięci fiskalnej już istnieje.

LP MNEMONIK OPIS
1069 ERR_FM_NO_MEM Brak wolnej przestrzeni w pamięci fiskalnej.
1070 ERR_FM_FILE_NO_MEM Brak wolnej przestrzeni w pliku
1071 ERR_FM_FILE_SEEK Błąd ustawienia offsetu w pliku
1072 ERR_FM_CRC_NOT_READY Suma kontrolna niewyliczona
1073 ERR_FM_IS_LOCKED Próba zapisu do zablokowanej pamięci fiskalnej.
1074 ERR_FM_UNREGISTERED Wykryto podmianę pamięci fiskalnej.
1075 ERR_FM_LOST Wykryto zmiany w pamięci fiskalnej.
1076 ERR_FM_TRANSACTION_GET Błąd utworzenia transakcji w pamięci fiskalnej.
1077 ERR_FM_SHA_NOT_READY Suma kontrolna niewyliczona
1078 ERR_FM_NOT_READY Pamięć fiskalna niegotowa.
1079 ERR_FM_WRONG_FIRMWARE_VERSION Niezgodny firmware pamięci fiskalnej
1100 ERR_TM_READ_GROUP Błąd odczytu grupy biletowej
1101 ERR_TM_WRITE_GROUP Błąd zapisu grupy biletowej
1102 ERR_TM_READ_CATEGORY Błąd odczytu kategorii biletowej
1103 ERR_TM_WRITE_CATEGORY Błąd zapisu kategorii biletowej
1104 ERR_TM_READ_DAYREP Błąd odczytu raportu dziennego biletowego
1105 ERR_TM_WRITE_DAYREP Błąd zapisu raportu dziennego biletowego
1106 ERR_TM_READ_SALEINFO Błąd odczytu rekordu sprzedaży biletowej
1107 ERR_TM_WRITE_SALEINFO Błąd zapisu rekordu sprzedaży biletowej
1200 ERR_APP_MODE_WRONG Niewłaściwy tryb pracy
1210 ERR_FM_DEVICE_ID Pamięć fiskalna niezgodna z typem urządzenia
1211 ERR_FM_DEVICE_ID_READ Błąd odczytu identyfikatora typu urządzenia
1950 ERR_TR_TOT_OVR Przekroczony zakres totalizerów paragonu
1951 ERR_TR_PF_OVR Wpłata formą płatności przekracza max. wpłatę
1952 ERR_TR_PF_SUM_OVR Suma form płatności przekracza max. wpłatę
1953 ERR_PAYMENT_OVR Formy płatności pokrywają już do zapłaty
1954 ERR_TR_CHANGE_OVR Wpłata reszty przekracza max. wpłatę
1955 ERR_TR_CHANGE_SUM_OVR Suma form płatności przekracza max. wpłatę
1956 ERR_TR_TOTAL_OVR Przekroczony zakres total
1957 ERR_TR_FISC_OVR Przekroczony maksymalny zakres paragonu
1958 ERR_TR_PACK_OVR Przekroczony zakres wartości opakowań
1959 ERR_TR_PACK_STORNO_OVR Przekroczony zakres wartości opakowań przy stornowaniu
1961 ERR_TR_PF_REST_TOO_BIG Wpłata reszty zbyt duża
1962 ERR_TR_PF_ZERO Wpłata formą płatności wartości 0
1963 ERR_TR_ADVANCE_OVR Przekroczony zakres zaliczki
1964 ERR_TR_ADVANCE_BASE_OVR Przekroczony zakres podstawy zaliczki
1965 ERR_TR_PACK_CNT_OVR Przekroczona ilość różnych opakowań zwrotnych
1966 ERR_TR_ADVANCE_ZERO Zaliczka zerowa
1980 ERR_TR_DISCNT_BASE_OVR Przekroczony zakres kwoty bazowej rabatu/narzutu
1981 ERR_TR_DISCNT_AFTER_OVR Przekroczony zakres kwoty po rabacie / narzucie
1982 ERR_TR_DISCNT_CALC Błąd obliczania rabatu/narzutu
1983 ERR_TR_DISCNT_BASE_NEGATIVE_OR_ZERO Wartość bazowa ujemna lub równa 0
1984 ERR_TR_DISCNT_ZERO Wartość rabatu/narzutu zerowa
1985 ERR_TR_DISCNT_AFTER_NEGATIVE_OR_ZERO Wartość po rabacie ujemna lub równa 0
1990 ERR_TR_STORNO_NOT_ALLOWED Niedozwolone stornowanie towaru.Błędny stan transakcji
1991 ERR_TR_DISCNT_NOT_ALLOWED Niedozwolony rabat/narzut.Błędny stan transakcji
1992 ERR_TR_EMPTY Brak pozycji na paragonie
```
2000 ERR_TR_FLD_VAT Błąd pola VAT ( błędny numer stawki lub nieaktywna stawka)
```
2001 ERR_TR_FLD_QUANT_FRACTIONAL Ilość niecałkowita
2002 ERR_NO_HDR Brak nagłówka
2003 ERR_HDR Zaprogramowany nagłówek
2004 ERR_NO_VAT Brak aktywnych stawek VAT
2005 ERR_NO_TRNS_MODE Brak trybu transakcji
```
2006 ERR_TR_FLD_PRICE Błąd pola cena ( cena <= 0 )
```
```
2007 ERR_TR_FLD_QUANT Błąd pola ilość ( ilość <= 0 )
```

LP MNEMONIK OPIS
2008 ERR_TR_FLD_TOTAL Błąd kwoty total
2009 ERR_TR_FLD_TOTAL_ZERO Błąd kwoty total, równa zero
2010 ERR_TOT_OVR Przekroczony zakres totalizerów dobowych
2019 ERR_RTC_CERT_VALIDITY Data wykracza poza zakres ważności certyfikatów
2020 ERR_RTC_DAY_CHANGED Zmiana daty niedozwolona
2022 ERR_RTC_DIFF Zbyt duża różnica dat
2023 ERR_RTC_HOUR Różnica większa niż 2 godziny w trybie użytkownika w trybie fiskalnym
```
2024 ERR_RTC_BAD_FORMAT Zły format daty (np. 13 miesiąc )
```
2025 ERR_RTC_FM_DATE Data wcześniejsza od ostatniego zapisu do modułu
2026 ERR_RTC Błąd zegara
2027 ERR_VAT_CHNG_CNT Przekroczono maksymalną liczbę zmian stawek VAT
2028 ERR_VAT_SAME Próba zdefiniowana identycznych stawek VAT
2029 ERR_VAT_VAL Błędne wartości stawek VAT
2030 ERR_VAT_NO_ACTIVE Próba zdefiniowania stawek VAT wszystkich nieaktywnych
2031 ERR_FLD_TIN Błąd pola NIP
2032 ERR_FM_ID Błąd numeru unikatowego pamięci fiskalnej.
2033 ERR_FISC_MODE Urządzenie w trybie fiskalnym
2034 ERR_NO_FISC_MODE Urządzenie w trybie niefiskalnym
2035 ERR_TOT_NOT_ZERO Niezerowe totalizery
2036 ERR_READ_ONLY Urządzenie w stanie tylko do odczytu
2037 ERR_NO_READ_ONLY Urządzenie nie jest w stanie tylko do odczytu
2038 ERR_TRNS_MODE Urządzenie w trybie transakcji
2039 ERR_TOT_ZERO Zerowe totalizery
2040 ERR_CURR_CALC Błąd obliczeń walut, przepełnienie przy mnożeniu lub dzieleniu
2041 ERR_TR_END_VAL_0 Próba zakończenia pozytywnego paragonu z wartością 0
2042 ERR_REP_PER_DATE_FORMAT_FROM Błąd formatu daty początkowej
2043 ERR_REP_PER_DATE_FORMAT_TO Błąd formatu daty końcowej
2045 ERR_REP_PER_DATE_START_GT_CURR Data początkowa późniejsza od bieżącej daty
2046 ERR_REP_PER_DATE_END_GT_FISK Data końcowa wcześniejsza od daty fiskalizacji
2047 ERR_REP_PER_NUM_ZERO Numer początkowy lub końcowy równy zero
2048 ERR_REP_NUMBER_RANGE Numer początkowy większy od numeru końcowego
2049 ERR_REP_PER_NUM_TOO_BIG Numer raportu zbyt duży
2050 ERR_REP_DATE_RANGE Data początkowa późniejsza od daty końcowej
2052 ERR_TR_NO_MEM Brak pamięci w buforze transakcji
2054 ERR_TR_END_PAYMENT Formy płatności nie pokrywają kwoty do zapłaty lub reszty
2055 ERR_LINE Błędna linia
2056 ERR_EMPTY_TXT Tekst pusty
2057 ERR_SIZE Przekroczony rozmiar lub przekroczona liczba znaków formatujących
2058 ERR_LINE_CNT Błędna liczba linii
2059 ERR_BARCODE_FORMAT Błędny kod kreskowy
2060 ERR_TR_BAD_STATE Błędny stan transakcji
2062 ERR_PRN_START Jest wydrukowana część jakiegoś dokumentu
2063 ERR_PAR Błąd parametru
2064 ERR_FTR_NO_HDR Brak rozpoczęcia wydruku lub transakcji
2066 ERR_FTR_NO_FTR Brak rozpoczęcia stopki wydruku
2067 ERR_PRN_CFG_SET Błąd ustawień konfiguracyjnych wydruków / drukarki
2070 ERR_WRONG_MAINTENANCE_TIME Data przeglądu wcześniejsza od systemowej
2074 ERR_WRONG_SERVICE_ID Błędna długość numeru ID serwisanta
2080 ERR_HEX_ODD Nieparzysta liczba danych w formacie HEX
2081 ERR_HEX_PARAM Niepoprawna wartość dla formatu HEX
2094 ERR_TR_CHANGE_EXIST Występuje forma płatności jako reszta
2095 ERR_HEADER_TOO_LONG Nagłówek za długi
2096 ERR_TIN_LENGTH Błędna długość NIP. Wymagane dokładnie 10 cyfr
2097 ERR_HDR_PRINTED_EC_FULL Wydrukowany nagłówek. Wyłącz oszczędność papieru, i wykonaj raport okreso-
wy

LP MNEMONIK OPIS
2098 ERR_FM_DOC_FULL Pamięć fiskalna zapełniona
2101 ERR_DF_DB_OVR Zapełnienie bazy
2102 ERR_DF_DB_VAT_INACTIVE Stawka nieaktywna
2103 ERR_DF_DB_VAT_INVALID Nieprawidłowa stawka VAT
2104 ERR_DF_DB_NAME Błąd nazwy
2105 ERR_DF_DB_NAME_VAT Błąd przypisania stawki
2106 ERR_DF_DB_LOCKED Towar zablokowany
2107 ERR_DF_DB_NAME_NOT_FOUND Nie znaleziono w bazie drukarkowej
2110 ERR_AUTHORIZATION Błąd autoryzacji
2207 ERR_TERMINAL_IP_PORT Niedozwolony port TCP
2211 ERR_TERMINAL_BREAK_COMMUNICATION Przerwano komunikację z terminalem!
2282 ERR_TERMINAL_RCV_PARAM Niepoprawne dane z terminala
2284 ERR_TERMINAL_CMD_EXEC Błąd podczas wykonania komendy
2287 ERR_TERMINAL_CON_PORT Błąd operacji na porcie komunikacyjnym
2290 ERR_TERMINAL_RCV_SYNTAX Niezrozumiała odpowiedź z terminala
2501 ERR_FORM_ID Błędny identyfikator raportu
2502 ERR_FORM_LINE_NO Błędny identyfikator linii raportu
2503 ERR_FORM_HDR_NO Błędny identyfikator nagłówka raportu
2504 ERR_FORM_PAR_CNT Zbyt mało parametrów raportu
2505 ERR_FORM_NOT_STARTED Raport nie rozpoczęty
2506 ERR_FORM_STARTED Raport rozpoczęty
2507 ERR_FORM_CMD Błędny identyfikator komendy
2508 ERR_FORM_NOT_WIDE Próba wydrukowania szerokiej formatki na papierze 57mm
2509 ERR_FORM_MASK Maska zakrywa zbyt dużo tekstu
2521 ERR_DB_REP_PLU_ACTIVE Raport już rozpoczęty
2522 ERR_DB_REP_PLU_NOT_ACTIVE Raport nie rozpoczęty
2523 ERR_DB_REP_PLU_VAT_ID Błędna stawka VAT
2532 ERR_FV_COPY_CNT Błędna liczba kopii faktur
2533 ERR_FV_EMPTY_NUMBER Pusty numer faktury
2534 ERR_FV_FORMAT Błędny format wydruku
2535 ERR_FV_EMPTY_BUYER Puste dane nabywcy
2600 ERR_DISCNT_TYPE Błędny typ rabatu/narzutu
2601 ERR_TR_DISCNT_VALUE Wartość rabatu/narzutu spoza zakresu
2701 ERR_VAT_ID Błąd identyfikatora stawki podatkowej
2702 ERR_FTRLN_ID Błędny identyfikator dodatkowej stopki
2703 ERR_FTRLN_CNT Przekroczona liczba dodatkowych stopek
2704 ERR_ACC_LOW Zbyt słaby akumulator
2705 ERR_PF_TYPE Błędny identyfikator typu formy płatności
2706 ERR_CHARGER_NOT_CONNECTED Brak zasilacza
2707 ERR_CHARGER_MODE Błędna konfiguracja ładowarki
2710 ERR_SERVICE_NOT_FOUND Usługa o podanym identyfikatorze nie jest uruchomiona
2712 ERR_ILLEGAL_TIME_VALUE Wartość czasu poza zakresem
2801 ERR_DISCNT_VERIFY Błąd weryfikacji wartości rabatu/narzutu
2802 ERR_LNTOT_VERIFY Błąd weryfikacji wartości linii sprzedaży
2803 ERR_PACKTOT_VERIFY Błąd weryfikacji wartości opakowania
2804 ERR_CURRTOT_VERIFY Błąd weryfikacji wartości formy płatności
2805 ERR_ENDTOT_VERIFY Błąd weryfikacji wartości fiskalnej
2806 ERR_ENDPACKPLUS_VERIFY Błąd weryfikacji wartości opakowań dodatnich
2807 ERR_ENDPACKMINUS_VERIFY Błąd weryfikacji wartości opakowań ujemnych
2808 ERR_ENDPAYMENT_VERIFY Błąd weryfikacji wartości wpłaconych form płatności
2809 ERR_ENDCHANGE_VERIFY Błąd weryfikacji wartości reszt
```
2810 ERR_ENDPACK_EMPTY Próba zakończenia rozliczenia opakowań z wartościami 0 (przyjętych i wyda-
```
```
nych)
```
2851 ERR_STORNO_QNT Błąd stornowania, błędna ilość
2852 ERR_STORNO_AMT Błąd stornowania, błędna wartość

LP MNEMONIK OPIS
2853 ERR_STORNO_PACK_NOT_FOUND Błąd stornowania, nie znaleziono opakowania
2900 ERR_EC_NOT_ENOUGH_SPACE Stan pamięci chronionej nie pozwala na wydrukowanie tego dokumentu
2901 ERR_EC_EDM_NOT_READY Nośnik niegotowy, operacja na nośniku trwa
2902 ERR_EC_EDM_NOT_VERIFIED Nośnik nie został poprawnie zweryfikowany.
2903 ERR_EC_DATA_PENDING Pamięć zawiera zbyt dużą ilość danych
2904 ERR_EC_EDM_FULL Pamięć chroniona zapełniona.
2907 ERR_EC_EDM_MISSING Brak dostępu do pamięci chronionej
2908 ERR_EC_EDM_INVALID Nośnik nieprawidłowy - nieodpowiedni dla wybranej operacji
2911 ERR_EC_EDM_FILE_NOT_FOUND Brak pliku na nośniku
2913 ERR_EC_EDM_CHAIN_BROKEN Nośnik nie jest poprawnie zweryfikowany
2916 ERR_EC_EDM_VERIFY_IN_PROGRESS Trwa weryfikacja nośnika
2917 ERR_EC_DOC_TYPE Błędny typ dokumentu
```
2918 ERR_EC_UNAVAILABLE Dane niedostępne (nieaktualne)
```
2930 ERR_EC_DOC_NOT_FOUND Nie znaleziono dokumentu
3051 ERR_CURRENCY_ALREADY_CHANGED Nie można zmienić dwa razy waluty ewidencyjnej po RD
3052 ERR_CURRENCY_SAME Próba ustawienia już ustawionej waluty
3053 ERR_CURRENCY_INVALID_NAME Błędna nazwa waluty
3054 ERR_CURRENCY_SHOULD_CHANGE Automatyczna zmiana waluty
3055 ERR_CURRENCY_RATE Błędna wartość przelicznika kursu
3056 ERR_CURRENCY_CHNG_CNT Przekroczono maksymalną liczbę zmian walut
3080 ERR_VAT_RTC_OLD Próba zdefiniowania stawek VAT ze starą datą
3084 ERR_VAT_SHOULD_CHANGE Automatyczna zmiana stawek VAT
3085 ERR_VAT_INVALID_DATE Brak pola daty
3098 ERR_FISC_OWNERSHIP_TYPE Błąd parametru własności kasy
3099 ERR_FISC_USE_TYPE Błąd parametru użytkowania kasy
3100 ERR_FISC_AUTH_MISSING Brak parametru autoryzacji fiskalizacji
3110 ERR_ILLEGAL_DRAWER_VOLTAGE Błąd napięcia szuflady
3200 ERR_CODE2D_NOTHING_TO_PRINT Próba wydruku pustego kodu
3201 ERR_CODE2D_OUT_OF_PAPER Kod przekracza obszar papieru lub jest zbyt duży
3202 ERR_CODE2D_SCALE Nieprawidłowa wartość skali wydruku
3203 ERR_CODE2D_Y2X_RATIO Nieprawidłowa wartość parametru Y2X ratio
3205 ERR_CODE2D_OUT_OF_MEMORY Kod przekracza dopuszczalny obszar pamięci
3206 ERR_CODE2D_TOO_LONG_DATA_STREAM Strumień wejściowy przekracza dopuszczalną długość
3207 ERR_CODE2D_COLUMN_COUNT_OVERRANGE Liczba kolumn poza zakresem
3208 ERR_CODE2D_ROW_COUNT_OVERRANGE Liczba wierszy poza zakresem
3209 ERR_CODE2D_ECC_LEVEL_OVERRANGE Poziom korekcji błędów poza zakresem
3210 ERR_CODE2D_PIXEL_PER_MODULE Liczba pikseli na moduł poza zakresem
3220 ERR_UNSUPPORTED_BARCODE Nieobsługiwany typ kodu kreskowego
3221 ERR_BARCODE_WRITE Błąd zapisu kodu kreskowego
3222 ERR_BARCODE_READ Błąd odczytu kodu kreskowego
3250 ERR_IMG_SLOT_NO_OVERRANGE Numer grafiki poza zakresem
3251 ERR_IMG_SLOT_EMPTY Brak grafiki w slocie
3252 ERR_IMG_READ_ONLY Grafika tylko do odczytu
3253 ERR_IMG_SIZE_OVERRANGE Niepoprawny rozmiar grafiki
3254 ERR_IMG_OUT_OF_MEMORY Przekroczony rozmiar pamięci przeznaczony na grafikę
3255 ERR_IMG_EC Błąd zapisu grafiki na pamięć chronioną.
3256 ERR_IMG_FLASH_OPERATION Błąd zapisu grafiki
3257 ERR_IMG_EC_LEVEL Poziom drukowalności grafik z kopii poza zakresem
3258 ERR_IMG_DATA_SIZE Niepoprawny rozmiar danych
3260 ERR_IMG_NAME Niepoprawna nazwa grafiki
3261 ERR_IMG_READ Błąd odczytu grafiki
3262 ERR_IMG_ALREADY_EXIST Grafika już istnieje
3263 ERR_IMG_ADD_PROTECTED_MEMORY Błąd archiwizowania grafiki
3264 ERR_IMG_SIZE_MISSING_FOR_RAW_IMAGE Brak podanego rozmiaru dla grafiki w formacie RAW
3265 ERR_IMG_SIZE_PRESENT_FOR_BMP_IMAGE Konflikt parametrów: podano rozmiar dla grafiki BMP

LP MNEMONIK OPIS
3266 ERR_IMG_INVALID_BMP_HEADER Niepoprawny nagłówek dla grafiki BMP
3267 ERR_IMG_INVALID_FORMAT Niepoprawny format grafiki
3268 ERR_IMG_ALREADY_IN_PROGRESS Programowanie grafiki w toku
3269 ERR_IMG_REBUILD_ERROR Nieudany odczyt grafiki przy odbudowie bazy danych
3280 ERR_APP_MODE_IS_SAME Tryb pracy już zaprogramowany
3281 ERR_APP_MODE_NOT_EXIST Tryb pracy poza zakresem
3282 ERR_APP_MODE_WRITE Błąd zapisu trybu pracy
3283 ERR_APP_MODE_CODE Błędny kod zmiany trybu pracy
3432 ERR_CONN_NOW Brak aktywnego połączenia z siecią
3440 ERR_WIFI_MODULE Błąd modułu WiFi
3441 ERR_WIFI_NO_NETWORK Błąd połączenia z siecią WiFi
3442 ERR_WIFI_INTERFACE_NO_ACTIVE Interfejs WiFi nieaktywny
3444 ERR_WIFI_INVALID_SSID Niepoprawny SSID
3445 ERR_WIFI_NOT_READY Moduł WiFi niegotowy
3446 ERR_WIFI_UNKNOWN Nieznany błąd modułu WiFi
3447 ERR_WIFI_NETWORK_IN_USE Nie można skasować połączonej sieci
3448 ERR_WIFI_UNKNOWN_NETWORK Nieznana nazwa sieci
3449 ERR_WIFI_EMPTY_RECORD Pusty rekord
3450 ERR_WIFI_KEY_CHARSET Niepoprawny zestaw znaków
3451 ERR_WIFI_VERSION_UNAVAILABLE Numer wersji modułu WiFi niedostępny
3459 ERR_BLUETOOTH_PIN_CODE_EDIT Błędna długość kodu PIN
3460 ERR_BLUETOOTH_MODULE Błąd modułu Bluetooth
3461 ERR_BLUETOOTH_INTERFACE_NO_ACTIVE Interfejs Bluetooth nieaktywny
3465 ERR_BLUETOOTH_DEL_PAIR_RECORD Nie można skasować urządzenia
3466 ERR_BLUETOOTH_PAIR_TIMEOUT Upłynął czas parowania urządzeń
3470 ERR_BLUETOOTH_NO_PRESENT Interfejs Bluetooth niedostępny
3471 ERR_WIFI_NO_PRESENT Interfejs WiFi nieaktywny
3472 ERR_COM_NO_PRESENT Interfejs COM nieaktywny
3500 ERR_MASS_STORAGE_FILE_OPEN Błąd otwarcia pliku
3501 ERR_MASS_STORAGE_READ Błąd odczytu nośnika
3502 ERR_MASS_STORAGE_WRITE Błąd zapisu na nośnik
3503 ERR_MASS_STORAGE_MISSING Brak pamięci zewnętrznej
3504 ERR_MASS_STORAGE_ACCESS Błąd operacji na pamięci masowej
3520 ERR_LOG_DIR_NOT_FOUND Nie znaleziono katalogu z logami
3700 ERR_FIRMWARE_UPDATE_DOWNLOAD_PRO-
BLEM
Błąd pobierania aktualizacji
3701 ERR_FIRMWARE_UPDATE_FILE_OPEN Błąd otwarcia pliku aktualizacji
3702 ERR_FIRMWARE_UPDATE_FILE_READ Błąd odczytu z pliku aktualizacji
3703 ERR_FIRMWARE_UPDATE_FILE_WRITE Błąd zapisu do pliku aktualizacji
3704 ERR_FIRMWARE_UPDATE_HTTP_ERROR Błąd połączenia z serwerem aktualizacji
3705 ERR_FIRMWARE_UPDATE_DECRYPTION_PRO-
BLEM
Błąd deszyfrowania aktualizacji
3706 ERR_FIRMWARE_UPDATE_DECRYPTION_WRON
G_CONTENT
Niewłaściwa zawartość pobranego pliku aktualizacji
3707 ERR_FIRMWARE_UPDATE_BUSY Trwa sprawdzanie aktualizacji. Spróbuj ponownie później
3708 ERR_FIRMWARE_UPDATE_INCOMPLETE_FILE Niekompletny plik z aktualizacją
3709 ERR_FIRMWARE_UPDATE_INVALID Brak weryfikacji wersji
3710 ERR_FIRMWARE_UPDATE_INCORRECT_URL Nieprawidłowy adres url aktualizacji
3711 ERR_FIRMWARE_UPDATE_MAKE_DAY_REP Nie można wykonać RD!
3712 ERR_FIRMWARE_UPDATE_LOADER_ERR Aktualizacja zakończona błędem
3713 ERR_FIRMWARE_UPDATE_CHANGE_KEYS Brak możliwości wymiany kluczy. Zakończ aktualizację
3714 ERR_FIRMWARE_UPDATE_READY_TO_INSTALL Aktualizacja gotowa do instalacji
3720 ERR_CERTIFICATE_FILE_CREATE Błąd utworzenia pliku z certyfikatem
3721 ERR_CERTIFICATE_FILE_COPY Błąd kopiowania certyfikatu
3722 ERR_CERTIFICATE_DELETE Błąd kasowania certyfikatu

LP MNEMONIK OPIS
3723 ERR_CERTIFICATE_FILE_SIZE Zbyt duży rozmiar pliku z certyfikatem
3724 ERR_CERTIFICATE_FILE_READ Błąd odczytu pliku z certyfikatem
3725 ERR_CERTIFICATE_NOT_EXISTS Certyfikat nie istnieje
3726 ERR_CSR_FILE_CREATE Błąd utworzenia pliku csr
3727 ERR_CERTIFICATE_INCORRECT_FILE Nieprawidłowy plik certyfikatu
3728 ERR_CERTIFICATE_EXPIRY Upłynął termin ważności certyfikatu
3729 ERR_CERTIFICATE_INVALID Błąd weryfikacji certyfikatu
3730 ERR_CERTIFICATE_FUTURE_EXPIRATION Certyfikat nie jest jeszcze ważny
3731 ERR_CERTIFICATE_DIR_NOT_FOUND Nie znaleziono katalogu z certyfikatami
3732 ERR_CERTIFICATE_FULL_MEMORY Osiągnięto maksymalną ilość wymiany kluczy publicznych
3733 ERR_CERTIFICATE_LOCK_SALE Sprzedaż zablokowana. Brak przekazanych kluczy do Repozytorium
3734 ERR_CERTIFICATE_EXCHANGE_KEYS_FISCAL_E
VENT
Za mało zdarzeń do wykonania operacji
3735 ERR_CERTIFICATE_EXCHANGE_REQUIRED Sprzedaż zablokowana. Wgraj nowe certyfikaty
3738 ERR_CERTIFICATE_EXCHANGE_FAIL Błąd wymiany certyfikatów. Wykonaj synchronizację czasu
3750 ERR_MODULE_TPM Błąd modułu szyfrującego
3751 ERR_TPM_GENERATE_RSA_KEY Błąd podczas generowania kluczy
3752 ERR_TPM_NOT_ENOUGH_MEMORY Za mało pamięci w module szyfrującym
3753 ERR_TPM_INCORRECT_STATE Niepoprawny stan modułu szyfrującego
3800 ERR_KASOTERMINAL_BEGIN_PRINT Błąd utworzenia wydruku
3802 ERR_KASOTERMINAL_END_PRINT Błąd zakończenia wydruku
3804 ERR_KASOTERMINAL_PRINTOUT_IN_PROGRESS Trwa wydruk
3901 ERR_REPOSITORY_FILE_READ Błąd odczytu z pliku
3902 ERR_REPOSITORY_FILE_CREATE Błąd utworzenia pliku
3903 ERR_REPOSITORY_BUSY Operacja w toku. Spróbuj ponownie
3904 ERR_REPOSITORY_COMM_SERVER_CPD Błąd komunikacji z serwerem CPD
3905 ERR_REPOSITORY_FISCALIZATION_SERIAL_NU
MBER
Odmowa fiskalizacji, błędny numer fabryczny
3906 ERR_REPOSITORY_FISCALIZATION_UNIQUE_NU
MBER
Odmowa fiskalizacji, błędny numer unikatowy
3907 ERR_REPOSITORY_FISCALIZATION_REGISTRAC-
TION_NUMBER
Odmowa fiskalizacji, błędny numer ewidencyjny
3908 ERR_REPOSITORY_FISCALIZATION_NIP Odmowa fiskalizacji, błędny numer NIP
3909 ERR_REPOSITORY_FISCALIZATION_PERMISSION Odmowa fiskalizacji, brak uprawnień serwisanta
3910 ERR_REPOSITORY_FISCALIZATION_SERIAL_UNI-
QUE_NUMBER
Odmowa fiskalizacji, błędny numer fabryczny lub unikatowy
3911 ERR_REPOSITORY_FISCALIZATION_SERIAL_RE-
GISTRACTION_NUMBER
Odmowa fiskalizacji, błędny numer fabryczny lub ewidencyjny
3912 ERR_REPOSITORY_FISCALIZATION_OPERATION_
UNACCEPTABLE
Odmowa fiskalizacji, operacja niedopuszczalna
3913 ERR_REPOSITORY_FISCALIZATION_DURING_FI-
SCALIZATION
Odmowa fiskalizacji, kasa w trakcie fiskalizacji z innym NIP
3914 ERR_REPOSITORY_FISCALIZATION_NONE_REGI-
STRACTION_NUMBER
Odmowa fiskalizacji, brak lub błędny numer ewidencyjny
3915 ERR_REPOSITORY_FISCALIZATION_DEVICE_NO
T_UNREGISTER
Odmowa fiskalizacji, kasa nie wyrejestrowana
3916 ERR_REPOSITORY_FISCALIZATION_FISCAL-
MEM_CLOSE
Odmowa fiskalizacji, pamięć fiskalna zamknięta
3917 ERR_REPOSITORY_FISCALIZATION_NIP_REGI-
STRACTION_NUMBER
Odmowa fiskalizacji, błędny numer NIP lub numer ewidencyjny
3918 ERR_REPOSITORY_FISCALIZATION_PREV_FI-
SCALMEM_NOT_CLOSE
Odmowa fiskalizacji, poprzednia pamięć fiskalna nie zamknięta
3919 ERR_REPOSITORY_FISCALIZATION_TECHNICAL_
ERROR
Odmowa fiskalizacji, błąd techniczny, skontaktuj się z administratorem
3920 ERR_REPOSITORY_SEND_DOCUMENT Operacja nieudana
3921 ERR_REPOSITORY_PARAMETER Błędne dane z Ministerstwa
3922 ERR_TAXOFFICE_TOO_SHORT Zbyt krótki identyfikator Urzędu Skarbowego
3923 ERR_TAXOFFICE_ONLY_DIGIT Dozwolone tylko cyfry w ident. Urzędu Skarbowego

LP MNEMONIK OPIS
3924 ERR_REPOSITORY_ADDRESS_TOO_SHORT Adres zbyt krótki
3926 ERR_REPOSITORY_TRIGGER_TOO_EARLY Zbyt wczesne wywołanie połączenia z serwerem
3927 ERR_REPOSITORY_ADDRESS_INCORRECT Nieprawidłowy adres url
3929 ERR_REPOSITORY_MISSING_SHARED_KEY Sprzedaż zablokowana. Brak klucza współdzielonego
3930 ERR_REPOSITORY_FISCALIZATION_DEVICE_RE-
GISTERED
Odmowa fiskalizacji, kasa zafiskalizowana
3931 ERR_REPOSITORY_FISCALIZATION_NO_CERTIFI-
CATES
Odmowa fiskalizacji, brak certyfikatów kasy
3932 ERR_REPOSITORY_FISCALIZATION_TIN_DIFFE-
RENT
Odmowa fiskalizacji, NIP właściciela inny niż w certyfikacie
3933 ERR_REPOSITORY_FISCALIZATION_VERIFY_SO-
FTWARE
Odmowa fiskalizacji, brak weryfikacji oprogramowania
4000 ERR_PROTMEM_DOC_NOT_FOUND Nie znaleziono dokumentu
4100 ERR_NO_EVENTS_IN_RANGE Brak zdarzeń w podanym zakresie
4105 ERR_EVENTS_INVALID_TYPE Błędny typ zdarzenia
4201 ERR_COMPANY_NAME_MISSING_OR_WRONG Brak lub błędna nazwa firmy w danych podatnika
4202 ERR_POSTAL_CODE_MISSING_OR_WRONG Brak lub błędny kod pocztowy w danych podatnika
4203 ERR_CITY_MISSING_OR_WRONG Brak lub błędna nazwa miasta w danych podatnika
4204 ERR_POST_OFFICE_MISSING_OR_WRONG Brak lub błędna nazwa urzędu pocztowego w danych podatnika
4205 ERR_STREET_MISSING_OR_WRONG Brak lub błędna nazwa ulicy w danych podatnika
4206 ERR_NUMBER_MISSING_OR_WRONG Brak lub błędny numer domu w danych podatnika
4207 ERR_SUB_NUMBER_MISSING_OR_WRONG Brak lub błędny numer lokalu w danych podatnika
4208 ERR_ADDITIONAL_DATA_MISSING_OR_WRONG Brak lub błędne dodatkowe dane w danych podatnika
4209 ERR_INVALID_POSTAL_CODE Błędny format kodu pocztowego
4250 ERR_EPARAGON_QUEUE_FULL Kolejka danych do eDokumentu pełna
4251 ERR_EPARAGON_SEND_DATA Błąd wysyłania danych
4252 ERR_EPARAGON_FILE_OPEN Błąd otwarcia pliku
4253 ERR_EPARAGON_FILE_WRITE Błąd zapisu do pliku
4254 ERR_EPARAGON_FILE_SIGN Błąd podczas podpisywania pliku
4255 ERR_EPARAGON_INCORRECT_URL Nieprawidłowy adres url
4256 ERR_EPARAGON_PROCESSING EDokument w trakcie wysyłki
4257 ERR_EPARAGON_LAST_DOC_EXIST Zarejestrowano eDokument dla ostatniego paragonu
4258 ERR_EPARAGON_REGISTER_IDZ Zdefiniowano parametr IDZ dla kolejnego eDokumentu
4259 ERR_EPARAGON_INCORRECT_URL_LENGTH Nieprawidłowy rozmiar adresu url
4260 ERR_EPARAGON_INCORRECT_CERT_TYPE Nieprawidłowy rodzaj certyfikatu
4271 ERR_EPARAGON_INCORRECT_THUMBPRINT_LE
NGHT
Nieprawidłowy rozmiar odcisku
4272 ERR_EPARAGON_URL_EMPTY Pusty adres URL
4273 ERR_EPARAGON_SERVER_REQUIRES_CONFIGU-
RATION
Nie ma skonfigurowanego adresu serwera
4275 ERR_EPARAGON_TEST_CONNECTION Nieudana próba połączenia testowego
4276 ERR_EPARAGON_NO_BITMAP_TO_SEND Brak grafiki do wysłania
4277 ERR_EPARAGON_IDZ_INVALID Nieprawidłowe pole IDZ
4454 ERR_SOK_INCORRECT_URL Nieprawidłowy adres url
4900 ERR_DUTY_FREE_DESTINATION_PORT_MISSING Brak identyfikatora portu docelowego
4901 ERR_DUTY_FREE_DESTINATION_ALREADY_PRE
SENT
Identyfikator portu docelowego już istnieje
4902 ERR_DUTY_FREE_TOO_MANY_MIDWAY_PORTS Zdefiniowano nadmiarową liczbę portów przesiadkowych
4903 ERR_DUTY_FREE_INVALID_PORT_DATA Błędne dane portu
