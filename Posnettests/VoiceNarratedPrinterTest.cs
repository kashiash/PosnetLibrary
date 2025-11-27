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
                var dodanePozycje = new List<(string nazwa, double cena, double ilosc, string vat, string opis)>();
                
                foreach (var (nazwa, cena, ilosc, vat, opis) in produkty)
                {
                    // Specjalna obsługa dla "Guma" - dodajemy błędną, anulujemy ją stornem, i dodajemy właściwą
                    if (nazwa == "Guma")
                    {
                        double gumaKwota = cena * ilosc;
                        
                        // Uproszczone dyktowanie
                        await SpeechService.SpeakAsync("guma za 8");
                        
                        // Wysyłamy pozycję do drukarki
                        string gumaIlosc = ilosc.ToString("0.##", polishCulture);
                        double gumaPrice = (gumaKwota * 100.0 / ilosc);
                        SendCommandToStream(stream, new string[] { "trline",
                            $"na{nazwa.Truncate(80)}",
                            $"vt{vat}",
                            $"pr{(int)gumaPrice}",
                            $"il{gumaIlosc}",
                            $"wa{(int)(gumaKwota * 100)}",
                            $"op{opis.Truncate(50)}"
                        });
                        
                        // Mówimy że to nie ta guma i anulujemy pozycję przez storno (st=True)
                        await SpeechService.SpeakAsync("sory to nie ta guma");
                        
                        // Anulujemy pozycję przez storno - dodajemy tę samą pozycję z st=True
                        SendCommandToStream(stream, new string[] { "trline",
                            $"na{nazwa.Truncate(80)}",
                            $"vt{vat}",
                            $"pr{(int)gumaPrice}",
                            $"il{gumaIlosc}",
                            $"wa{(int)(gumaKwota * 100)}",
                            $"op{opis.Truncate(50)}",
                            "st1"  // st=True - stornowanie (anulowanie pozycji)
                        });
                        
                        // Dodajemy właściwą gumę - Guma unimil, 1 paczka na noc
                        await SpeechService.SpeakAsync("guma unimil, 1 paczka na noc za 8");
                        SendCommandToStream(stream, new string[] { "trline",
                            "naGuma unimil",
                            "vt1",
                            "pr400",
                            "il2",
                            "wa800",
                            "op1 paczka na noc"
                        });
                        
                        // Nie dodajemy błędnej gumy do totalAmount, tylko właściwą
                        dodanePozycje.Add(("Guma unimil", 4.00, 2.0, "1", "1 paczka na noc"));
                        totalAmount += 8.00; // Tylko właściwa guma
                        continue;
                    }
                    
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
                    
                    // Zapisujemy pozycję na wypadek anulowania
                    dodanePozycje.Add((nazwa, cena, ilosc, vat, opis));
                }
                
                await SpeechService.SpeakAsync($"Wszystkie {produkty.Length} pozycji zostały wysłane do drukarki. Łączna kwota: {totalAmount:F2} złotych.");
                
                // Wycofujemy chipsy, colę i szkloki na końcu
                var pozycjeDoStornowania = new[] { "Chipsy", "Cola", "Szkloki" };
                await SpeechService.SpeakAsync("Wycofuję chipsy, colę i szkloki.");
                
                foreach (var nazwaDoStornowania in pozycjeDoStornowania)
                {
                    var pozycja = dodanePozycje.FirstOrDefault(p => p.nazwa == nazwaDoStornowania);
                    if (pozycja.nazwa != null)
                    {
                        double pozycjaKwota = pozycja.cena * pozycja.ilosc;
                        totalAmount -= pozycjaKwota; // Odejmujemy od całkowitej kwoty
                        
                        string formattedquantity = pozycja.ilosc.ToString("0.##", polishCulture);
                        double price = (pozycjaKwota * 100.0 / pozycja.ilosc);
                        
                        await SpeechService.SpeakAsync($"Wycofuję {pozycja.nazwa.ToLower()}.");
                        
                        // Wysyłamy storno - tę samą pozycję z st=1
                        SendCommandToStream(stream, new string[] { "trline",
                            $"na{pozycja.nazwa.Truncate(80)}",
                            $"vt{pozycja.vat}",
                            $"pr{(int)price}",
                            $"il{formattedquantity}",
                            $"wa{(int)(pozycjaKwota * 100)}",
                            $"op{pozycja.opis.Truncate(50)}",
                            "st1"  // st=True - stornowanie (anulowanie pozycji)
                        });
                    }
                }
                
                await SpeechService.SpeakAsync($"Po wycofaniu pozycji, łączna kwota wynosi: {totalAmount:F2} złotych.");
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

