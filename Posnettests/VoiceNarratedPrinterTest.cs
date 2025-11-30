using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using PosnetLibrary;

namespace PosnetTests
{
    public class VoiceNarratedPrinterTest
    {
        string host = "192.168.50.47";
        int port = 6666;

        const string LF = "\u000A";

        [SetUp]
        public void Setup()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            
            PosnetHelper.SetConnectionSettings(host, port);
        }

        [Test]
        public async Task DailyReportWithVoiceNarration()
        {
            try
            {
                await SpeechService.SpeakAsync("Wywołuję raport dobowy z drukarki. Podejdź do drukarki i potwierdź datę.");
                
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

        [Test]
        public async Task SetHeaderWithVoiceNarration()
        {
            try
            {
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
                await EnsureNoOpenTransaction();
                throw;
            }
        }

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



        [Test]
        public async Task PrintReceiptItemByItemWithSlangProducts()
        {
            System.Net.Sockets.TcpClient? client = null;
            System.Net.Sockets.NetworkStream? stream = null;
            
            try
            {
                await EnsureNoOpenTransaction();
                
                await SpeechService.SpeakAsync("Rozpoczynam drukowanie paragonu z produktami dla Żulika.");
                
                var receipt = new FiscalReceipt
                {
                    TransactionNumber = "PA/2024/666/999/00125",
                    Notes = "Paragon z produktami dla żulika"
                };

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
                
                await SpeechService.SpeakAsync("Ustawiam stopkę paragonu.");
                PosnetHelper.SetFooter(receipt.TransactionNumber, receipt.Notes);
                
                await SpeechService.SpeakAsync("Rozpoczynam transakcję w drukarce.");
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                System.Globalization.CultureInfo polishCulture = new System.Globalization.CultureInfo("pl-PL");
                
                client = new System.Net.Sockets.TcpClient(host, port);
                stream = client.GetStream();
                
                SendCommandToStream(stream, new string[] { "trinit", "bm1" });
                
                double totalAmount = 0;
                var dodanePozycje = new List<(string nazwa, double cena, double ilosc, string vat, string opis)>();
                
                foreach (var (nazwa, cena, ilosc, vat, opis) in produkty)
                {
                    if (nazwa == "Guma")
                    {
                        double gumaKwota = cena * ilosc;
                        
                        await SpeechService.SpeakAsync("guma za 8");
                        
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
                        
                        await SpeechService.SpeakAsync("sory to nie ta guma");
                        
                        SendCommandToStream(stream, new string[] { "trline",
                            $"na{nazwa.Truncate(80)}",
                            $"vt{vat}",
                            $"pr{(int)gumaPrice}",
                            $"il{gumaIlosc}",
                            $"wa{(int)(gumaKwota * 100)}",
                            $"op{opis.Truncate(50)}",
                            "st1"
                        });
                        
                        await SpeechService.SpeakAsync("guma unimil, 1 paczka na noc za 8");
                        SendCommandToStream(stream, new string[] { "trline",
                            "naGuma unimil",
                            "vt1",
                            "pr400",
                            "il2",
                            "wa800",
                            "op1 paczka na noc"
                        });
                        
                        dodanePozycje.Add(("Guma unimil", 4.00, 2.0, "1", "1 paczka na noc"));
                        totalAmount += 8.00;
                        continue;
                    }
                    
                    double pozycjaKwota = cena * ilosc;
                    totalAmount += pozycjaKwota;
                    
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
                    
                    dodanePozycje.Add((nazwa, cena, ilosc, vat, opis));
                }
                
                await SpeechService.SpeakAsync($"Wszystkie {produkty.Length} pozycji zostały wysłane do drukarki. Łączna kwota: {totalAmount:F2} złotych.");
                
                var pozycjeDoStornowania = new[] { "Chipsy", "Cola", "Szkloki" };
                await SpeechService.SpeakAsync("Przekroczono budżet Żulika!. Wycofuję chipsy, colę i szkloki.");
                
                foreach (var nazwaDoStornowania in pozycjeDoStornowania)
                {
                    var pozycja = dodanePozycje.FirstOrDefault(p => p.nazwa == nazwaDoStornowania);
                    if (pozycja.nazwa != null)
                    {
                        double pozycjaKwota = pozycja.cena * pozycja.ilosc;
                        totalAmount -= pozycjaKwota;
                        
                        string formattedquantity = pozycja.ilosc.ToString("0.##", polishCulture);
                        double price = (pozycjaKwota * 100.0 / pozycja.ilosc);
                        
                        await SpeechService.SpeakAsync($"Wycofuję {pozycja.nazwa.ToLower()}.");
                        
                        SendCommandToStream(stream, new string[] { "trline",
                            $"na{pozycja.nazwa.Truncate(80)}",
                            $"vt{pozycja.vat}",
                            $"pr{(int)price}",
                            $"il{formattedquantity}",
                            $"wa{(int)(pozycjaKwota * 100)}",
                            $"op{pozycja.opis.Truncate(50)}",
                            "st1"
                        });
                    }
                }
                
                await SpeechService.SpeakAsync($"Po wycofaniu pozycji, łączna kwota wynosi: {totalAmount:F2} złotych.");
                await SpeechService.SpeakAsync("Zakańczam transakcję. Drukarka wydrukuje paragon.");
                
                SendCommandToStream(stream, new string[] { "trend", $"to{(int)(totalAmount * 100)}" });
                
                await SpeechService.SpeakAsync("Paragon został wydrukowany pomyślnie ze wszystkimi produktami.");
                await SpeechService.SpeakAsync("Życzę smacznego i nie dostaj sraczki.");
            }
            catch (Exception ex)
            {
                string errorMessage = $"Wystąpił błąd podczas drukowania paragonu. {GetErrorMessage(ex)}";
                await SpeechService.SpeakAsync(errorMessage);
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

        private void SendCommandToStream(System.Net.Sockets.NetworkStream stream, string[] command)
        {
            const string STX = "\u0002";
            const string TAB = "\u0009";
            const string ETX = "\u0003";
            
            byte[] data = PosnetHelper.fullCommandEncodedCrced(command);
            
            try
            {
                stream.Write(data, 0, data.Length);
                
                Encoding win1250 = Encoding.GetEncoding(1250);
                Console.WriteLine();
                Console.WriteLine($"Wysłano: {win1250.GetString(data)}");
                
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = win1250.GetString(buffer, 0, bytesRead);
                
                Console.WriteLine();
                Console.WriteLine($"Odpowiedź od serwera: {response}");
                if (response.Contains("ERR") || response.Contains("?"))
                {
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

        private async Task EnsureNoOpenTransaction()
        {
            try
            {
                PosnetHelper.AnulowanieTransakcji();
            }
            catch
            {
            }
        }

        private string GetErrorMessage(Exception ex)
        {
            if (ex == null)
                return "Nieznany błąd.";

            string message = ex.Message;

            if (message.Contains("ERR") || message.Contains("?"))
            {
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
                        return $"Błąd drukarki: kod {errorCode}";
                    }
                }
                
                return $"Błąd drukarki: {message}";
            }

            if (ex is System.Net.Sockets.SocketException socketEx)
            {
                return $"Błąd połączenia z drukarką. Kod błędu: {socketEx.SocketErrorCode}. Sprawdź, czy drukarka jest włączona i dostępna w sieci.";
            }

            return $"Błąd: {message}";
        }
    }
}

