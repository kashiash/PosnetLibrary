using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using PosnetLibrary;

namespace PosnetTests
{
    /// <summary>
    /// Test z narracją głosową - opowiada o tym, co się dzieje podczas operacji z drukarką.
    /// Używa syntezy mowy do informowania użytkownika o wykonywanych operacjach i błędach.
    /// </summary>
    public class VoiceNarratedPrinterTest
    {
        // Ustawienia połączenia z drukarką
        string host = "192.168.50.47";
        int port = 6666;

        const string LF = "\u000A";

        [SetUp]
        public void Setup()
        {
            // Rejestracja kodowania dla polskich znaków
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            // Ustawienie parametrów połączenia z drukarką
            PosnetHelper.SetConnectionSettings(host, port);
        }

        /// <summary>
        /// Test raportu dobowego z narracją głosową.
        /// Informuje użytkownika, że należy podejść do drukarki i potwierdzić datę.
        /// </summary>
        [Test]
        public async Task DailyReportWithVoiceNarration()
        {
            try
            {
                await SpeechService.SpeakAsync("Wywołuję raport dobowy z drukarki. Podejdź do drukarki i potwierdź datę.");
                
                // Wywołanie raportu dobowego
                PosnetHelper.DailyReport();
                
                await SpeechService.SpeakAsync("Raport dobowy został wywołany pomyślnie.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas wywoływania raportu dobowego. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                throw;
            }
        }

        /// <summary>
        /// Test ustawienia nagłówka z narracją głosową.
        /// Informuje użytkownika, że ustawia nagłówek i drukuje paragon.
        /// </summary>
        [Test]
        public async Task SetHeaderWithVoiceNarration()
        {
            try
            {
                // Anulujemy ewentualną otwartą transakcję przed ustawieniem nagłówka
                await EnsureNoOpenTransaction();
                
                await SpeechService.SpeakAsync("Ustawiam nagłówek paragonu. Drukarka będzie drukować paragon z nowym nagłówkiem.");
                
                var nazwaFirmy = "Fryj z Hasioka";
                var miejscowosc = "Sosnowiec";
                var kod = "41-203";

                PosnetHelper.SetHeader(nazwaFirmy, miejscowosc, kod);
                
                await SpeechService.SpeakAsync("Nagłówek został ustawiony pomyślnie.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas ustawiania nagłówka. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                // Próbujemy anulować transakcję w przypadku błędu
                await EnsureNoOpenTransaction();
                throw;
            }
        }

        /// <summary>
        /// Test ustawienia stopki z narracją głosową.
        /// </summary>
        [Test]
        public async Task SetFooterWithVoiceNarration()
        {
            try
            {
                await SpeechService.SpeakAsync("Ustawiam stopkę paragonu.");
                
                PosnetHelper.SetFooter($"Nr transakcji: PA/2024/666/999/00125 {LF}Opis: {LF}Wydrukowano z programu Fleetman   &iwww.fleetman.com.pl");
                
                await SpeechService.SpeakAsync("Stopka została ustawiona pomyślnie.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas ustawiania stopki. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                throw;
            }
        }

        /// <summary>
        /// Test kompleksowy z pełną narracją głosową wszystkich operacji.
        /// Opowiada o każdej wykonywanej operacji krok po kroku.
        /// </summary>
        [Test]
        public async Task CompleteTestWithVoiceNarration()
        {
            try
            {
                // Krok 1: Raport dobowy
                await SpeechService.SpeakAsync("Rozpoczynam test kompleksowy. Krok pierwszy: wywołuję raport dobowy. Podejdź do drukarki i potwierdź datę.");
                PosnetHelper.DailyReport();
                await SpeechService.SpeakAsync("Raport dobowy wykonany pomyślnie.");

                // Krok 2: Ustawienie nagłówka
                await SpeechService.SpeakAsync("Krok drugi: ustawiam nagłówek paragonu. Drukarka będzie drukować paragon z nowym nagłówkiem.");
                var nazwaFirmy = "Fryj z Hasioka";
                var miejscowosc = "Sosnowiec";
                var kod = "41-203";
                PosnetHelper.SetHeader(nazwaFirmy, miejscowosc, kod);
                await SpeechService.SpeakAsync("Nagłówek ustawiony pomyślnie.");

                // Krok 3: Ustawienie stopki
                await SpeechService.SpeakAsync("Krok trzeci: ustawiam stopkę paragonu.");
                PosnetHelper.SetFooter($"Nr transakcji: PA/2024/666/999/00125 {LF}Opis: {LF}Wydrukowano z programu Fleetman   &iwww.fleetman.com.pl");
                await SpeechService.SpeakAsync("Stopka ustawiona pomyślnie.");

                await SpeechService.SpeakAsync("Wszystkie operacje zakończone pomyślnie. Test kompleksowy zakończony.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas wykonywania testu kompleksowego. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                throw;
            }
        }

        /// <summary>
        /// Test drukowania paragonu z narracją głosową.
        /// Opowiada o każdym kroku drukowania paragonu.
        /// </summary>
        [Test]
        public async Task PrintReceiptWithVoiceNarration()
        {
            try
            {
                // Anulujemy ewentualną otwartą transakcję przed rozpoczęciem
                await EnsureNoOpenTransaction();
                
                await SpeechService.SpeakAsync("Rozpoczynam drukowanie paragonu fiskalnego.");

                var receipt = new FiscalReceipt
                {
                    TransactionNumber = "PA/2024/666/999/00125",
                    Notes = "Test paragonu z narracją głosową"
                };

                // Dodajemy pozycje do paragonu
                await SpeechService.SpeakAsync("Dodaję pozycje do paragonu.");
                receipt.FiscalReceiptItems.Add(new ItemOnFiscalReceipt("Chleb", 5.50, 1.0, "1", "Chleb pszenny"));
                receipt.FiscalReceiptItems.Add(new ItemOnFiscalReceipt("Mleko", 6.40, 2.0, "1", "Mleko 3,2%"));

                await SpeechService.SpeakAsync($"Dodano {receipt.FiscalReceiptItems.Count} pozycji do paragonu. Łączna kwota: {receipt.GrossAmount:F2} złotych.");
                await SpeechService.SpeakAsync("Wysyłam paragon do drukarki. Drukarka rozpocznie drukowanie paragonu.");
                
                PosnetHelper.PrintRecipe(receipt);
                
                await SpeechService.SpeakAsync("Paragon został wydrukowany pomyślnie.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas drukowania paragonu. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                // Próbujemy anulować transakcję w przypadku błędu
                await EnsureNoOpenTransaction();
                throw;
            }
        }

        /// <summary>
        /// Test sprawdzania i ustawiania stawek VAT z narracją głosową.
        /// Sprawdza czy są stawki VAT, jeśli nie ma - ustawia je, następnie drukuje listę stawek.
        /// </summary>
        [Test]
        public async Task CheckAndSetVatRatesWithVoiceNarration()
        {
            try
            {
                // Anulujemy ewentualną otwartą transakcję przed ustawieniem stawek VAT
                await EnsureNoOpenTransaction();
                
                await SpeechService.SpeakAsync("Sprawdzam stawki VAT w drukarce.");
                
                // Sprawdzamy stawki VAT - próbujemy je pobrać
                try
                {
                    PosnetHelper.VatGet();
                    await SpeechService.SpeakAsync("Stawki VAT są dostępne w drukarce.");
                }
                catch
                {
                    await SpeechService.SpeakAsync("Nie udało się pobrać stawek VAT. Ustawiam standardowe stawki.");
                }
                
                // Ustawiamy standardowe stawki VAT (drukarka zignoruje jeśli są już takie same)
                await SpeechService.SpeakAsync("Ustawiam standardowe stawki VAT: stawka A dwadzieścia trzy procent, stawka B osiem procent, stawka C pięć procent.");
                PosnetHelper.VatSetRates(va: 23, vb: 8, vc: 5, vd: 0, ve: 0, vf: 101, vg: 100);
                await SpeechService.SpeakAsync("Stawki VAT zostały ustawione pomyślnie.");
                
                // Wydruk listy stawek VAT
                await SpeechService.SpeakAsync("Drukuję listę stawek VAT. Podejdź do drukarki, aby odebrać wydruk.");
                PosnetHelper.PrintVatRatesList();
                
                await SpeechService.SpeakAsync("Lista stawek VAT została wydrukowana.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas sprawdzania lub ustawiania stawek VAT. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                // Próbujemy anulować transakcję w przypadku błędu
                await EnsureNoOpenTransaction();
                throw;
            }
        }

        /// <summary>
        /// Kompleksowy test: sprawdzenie stawek VAT, ustawienie jeśli brak, wydruk listy, następnie paragon.
        /// </summary>
        [Test]
        public async Task CompleteVatAndReceiptTestWithVoiceNarration()
        {
            try
            {
                // Anulujemy ewentualną otwartą transakcję przed rozpoczęciem
                await EnsureNoOpenTransaction();
                
                // Krok 1: Sprawdzenie stawek VAT
                await SpeechService.SpeakAsync("Rozpoczynam kompleksowy test. Krok pierwszy: sprawdzam stawki VAT w drukarce.");
                
                try
                {
                    PosnetHelper.VatGet();
                    await SpeechService.SpeakAsync("Stawki VAT są dostępne w drukarce.");
                }
                catch
                {
                    await SpeechService.SpeakAsync("Nie udało się pobrać stawek VAT. Ustawiam standardowe stawki.");
                }
                
                // Ustawiamy standardowe stawki VAT (drukarka zignoruje jeśli są już takie same)
                await SpeechService.SpeakAsync("Ustawiam standardowe stawki VAT: stawka A dwadzieścia trzy procent, stawka B osiem procent, stawka C pięć procent.");
                PosnetHelper.VatSetRates(va: 23, vb: 8, vc: 5, vd: 0, ve: 0, vf: 101, vg: 100);
                await SpeechService.SpeakAsync("Stawki VAT zostały ustawione pomyślnie.");
                
                // Krok 2: Wydruk listy stawek VAT
                await SpeechService.SpeakAsync("Krok drugi: drukuję listę stawek VAT. Podejdź do drukarki, aby odebrać wydruk.");
                PosnetHelper.PrintVatRatesList();
                await SpeechService.SpeakAsync("Lista stawek VAT została wydrukowana.");
                
                // Krok 3: Drukowanie paragonu
                await SpeechService.SpeakAsync("Krok trzeci: rozpoczynam drukowanie paragonu fiskalnego.");
                
                var receipt = new FiscalReceipt
                {
                    TransactionNumber = "PA/2024/666/999/00125",
                    Notes = "Test paragonu po sprawdzeniu stawek VAT"
                };
                
                await SpeechService.SpeakAsync("Dodaję pozycje do paragonu.");
                receipt.FiscalReceiptItems.Add(new ItemOnFiscalReceipt("Chleb", 5.50, 1.0, "1", "Chleb pszenny"));
                receipt.FiscalReceiptItems.Add(new ItemOnFiscalReceipt("Mleko", 6.40, 2.0, "1", "Mleko 3,2%"));
                
                await SpeechService.SpeakAsync($"Dodano {receipt.FiscalReceiptItems.Count} pozycji do paragonu. Łączna kwota: {receipt.GrossAmount:F2} złotych.");
                await SpeechService.SpeakAsync("Wysyłam paragon do drukarki. Drukarka rozpocznie drukowanie paragonu.");
                
                PosnetHelper.PrintRecipe(receipt);
                
                await SpeechService.SpeakAsync("Paragon został wydrukowany pomyślnie. Kompleksowy test zakończony.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas wykonywania kompleksowego testu. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                // Próbujemy anulować transakcję w przypadku błędu
                await EnsureNoOpenTransaction();
                throw;
            }
        }


        /// <summary>
        /// Test drukowania paragonu pozycja po pozycji z produktami dla żulika.
        /// Każda pozycja jest opisywana głosowo, a następnie od razu wysyłana do drukarki.
        /// </summary>
        [Test]
        public async Task PrintReceiptItemByItemWithSlangProducts()
        {
            System.Net.Sockets.TcpClient? client = null;
            System.Net.Sockets.NetworkStream? stream = null;
            
            try
            {
                // Anulujemy ewentualną otwartą transakcję
                await EnsureNoOpenTransaction();
                
                await SpeechService.SpeakAsync("Rozpoczynam drukowanie paragonu z produktami dla żulika. Będę dodawać pozycje jedna po drugiej i od razu wysyłać je do drukarki.");
                
                var receipt = new FiscalReceipt
                {
                    TransactionNumber = "PA/2024/666/999/00125",
                    Notes = "Paragon z produktami dla żulika"
                };

                // Lista produktów dla żulika z cenami
                var produkty = new[]
                {
                    ("Fajki za dyszkę", 10.00, 1.0, "1", "Papierosy"),
                    ("Piwerko kraftowe", 8.50, 2.0, "1", "Piwo kraftowe"),
                    ("Cola", 4.50, 1.0, "1", "Coca Cola"),
                    ("Orzeszki", 6.00, 1.0, "1", "Orzeszki ziemne"),
                    ("Chipsy", 7.50, 2.0, "1", "Chipsy ziemniaczane"),
                    ("Woda gazowana", 3.00, 1.0, "1", "Woda mineralna"),
                    ("Kawa", 12.00, 1.0, "1", "Kawa espresso"),
                    ("Szkloki", 5.50, 1.0, "1", "Cukierki"),
                    ("Guma", 4.00, 2.0, "1", "Gumy do żucia"),
                    ("Energetyk", 6.50, 1.0, "1", "Napój energetyczny")
                };
                
                // Ustawiamy stopkę przed rozpoczęciem transakcji
                await SpeechService.SpeakAsync("Ustawiam stopkę paragonu.");
                PosnetHelper.SetFooter(receipt.TransactionNumber, receipt.Notes);
                
                // Rozpoczynamy transakcję
                await SpeechService.SpeakAsync("Rozpoczynam transakcję w drukarce.");
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                System.Globalization.CultureInfo polishCulture = new System.Globalization.CultureInfo("pl-PL");
                
                client = new System.Net.Sockets.TcpClient(host, port);
                stream = client.GetStream();
                
                // Rozpoczęcie transakcji
                SendCommandToStream(stream, new string[] { "trinit", "bm1" });
                
                // Dodajemy pozycje jedna po drugiej z narracją i od razu wysyłamy do drukarki
                double totalAmount = 0;
                
                foreach (var (nazwa, cena, ilosc, vat, opis) in produkty)
                {
                    double pozycjaKwota = cena * ilosc;
                    totalAmount += pozycjaKwota;
                    
                    // Uproszczone dyktowanie - mówimy nazwę produktu i kwotę
                    string nazwaLower = nazwa.ToLower();
                    int kwotaZlote = (int)pozycjaKwota;
                    int kwotaGrosze = (int)((pozycjaKwota - kwotaZlote) * 100);
                    
                    if (kwotaGrosze == 0)
                    {
                        await SpeechService.SpeakAsync($"{nazwaLower} za {kwotaZlote}");
                    }
                    else
                    {
                        await SpeechService.SpeakAsync($"{nazwaLower} za {kwotaZlote} {kwotaGrosze}");
                    }
                    
                    // Wysyłamy pozycję do drukarki
                    string formattedquantity = ilosc.ToString("0.##", polishCulture);
                    double price = (pozycjaKwota * 100.0 / ilosc);
                    SendCommandToStream(stream, new string[] { "trline",
                        $"na{nazwa.Truncate(80)}",
                        $"vt{vat}",
                        $"pr{(int)price}",
                        $"il{formattedquantity}",
                        $"wa{(int)(pozycjaKwota * 100)}",
                        $"op{opis.Truncate(50)}"
                    });
                }
                
                await SpeechService.SpeakAsync($"Wszystkie {produkty.Length} pozycji zostały wysłane do drukarki. Łączna kwota: {totalAmount:F2} złotych.");
                await SpeechService.SpeakAsync("Zakańczam transakcję. Drukarka wydrukuje paragon.");
                
                // Zakończenie transakcji
                SendCommandToStream(stream, new string[] { "trend", $"to{(int)(totalAmount * 100)}" });
                
                await SpeechService.SpeakAsync("Paragon został wydrukowany pomyślnie ze wszystkimi produktami.");
                await SpeechService.SpeakAsync("Życzę smacznego i nie dostaj sraczki.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas drukowania paragonu. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
                // Próbujemy anulować transakcję w przypadku błędu
                if (stream != null && client != null)
                {
                    try
                    {
                        SendCommandToStream(stream, new string[] { "prncancel" });
                    }
                    catch { }
                }
                await EnsureNoOpenTransaction();
                throw;
            }
            finally
            {
                stream?.Dispose();
                client?.Dispose();
            }
        }

        /// <summary>
        /// Wysyła komendę do strumienia sieciowego drukarki.
        /// </summary>
        private void SendCommandToStream(System.Net.Sockets.NetworkStream stream, string[] command)
        {
            const string STX = "\u0002";
            const string TAB = "\u0009";
            const string ETX = "\u0003";
            
            // Używamy publicznej metody z PosnetHelper do tworzenia komendy z CRC
            byte[] data = PosnetHelper.fullCommandEncodedCrced(command);
            
            try
            {
                // Wysyłanie danych
                stream.Write(data, 0, data.Length);
                
                Encoding win1250 = Encoding.GetEncoding(1250);
                Console.WriteLine();
                Console.WriteLine($"Wysłano: {win1250.GetString(data)}");
                
                // Odbieranie odpowiedzi
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = win1250.GetString(buffer, 0, bytesRead);
                
                Console.WriteLine();
                Console.WriteLine($"Odpowiedź od serwera: {response}");
                if (response.Contains("ERR") || response.Contains("?"))
                {
                    // Wyciąganie błędu podobnie jak w PosnetHelper
                    string[] result = response.Split(new string[] { STX, TAB, ETX, LF, " " }, StringSplitOptions.RemoveEmptyEntries);
                    var code = result.Where(r => r.Contains("?")).FirstOrDefault();
                    if (!string.IsNullOrEmpty(code))
                    {
                        var message = ErrorHelper.GetErrorDescription(code);
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine($"Nieznany błąd: {response}");
                    }
                    throw new Exception($"Posnet Error {response}");
                }
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                Console.WriteLine($"Błąd połączenia sieciowego: {ex.Message}");
                throw new Exception($"Błąd połączenia z drukarką: {ex.Message}", ex);
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
                throw new Exception($"Błąd komunikacji z drukarką: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Upewnia się, że nie ma otwartej transakcji - anuluje ją jeśli istnieje.
        /// </summary>
        private async Task EnsureNoOpenTransaction()
        {
            try
            {
                PosnetHelper.AnulowanieTransakcji();
                // Nie mówimy głosowo - może nie być transakcji do anulowania
            }
            catch
            {
                // Ignorujemy błędy - może nie być otwartej transakcji
            }
        }

        /// <summary>
        /// Wyciąga czytelną wiadomość o błędzie z wyjątku.
        /// Próbuje znaleźć kod błędu Posnet i jego opis używając ErrorHelper.
        /// </summary>
        private string GetErrorMessage(Exception ex)
        {
            if (ex == null)
                return "Nieznany błąd.";

            string message = ex.Message;

            // Próbujemy wyciągnąć kod błędu Posnet z komunikatu
            if (message.Contains("ERR") || message.Contains("?"))
            {
                // Wyciągamy kod błędu (np. "?10" lub "ERR_XXX")
                var errorCodeMatch = Regex.Match(message, @"\?(\d+)");
                if (errorCodeMatch.Success)
                {
                    string errorCode = errorCodeMatch.Groups[1].Value;
                    try
                    {
                        string errorDescription = ErrorHelper.GetErrorDescription($"?{errorCode}");
                        return $"Błąd drukarki: {errorDescription}";
                    }
                    catch
                    {
                        // Jeśli nie udało się znaleźć opisu, zwracamy kod
                        return $"Błąd drukarki: kod {errorCode}";
                    }
                }
                
                // Jeśli wiadomość zawiera kod błędu w innym formacie, zwracamy ją bezpośrednio
                return $"Błąd drukarki: {message}";
            }

            // Jeśli to błąd sieciowy
            if (ex is System.Net.Sockets.SocketException socketEx)
            {
                return $"Błąd połączenia z drukarką. Kod błędu: {socketEx.SocketErrorCode}. Sprawdź, czy drukarka jest włączona i dostępna w sieci.";
            }

            // Dla innych błędów zwracamy ogólny komunikat
            return $"Błąd: {message}";
        }
    }
}

