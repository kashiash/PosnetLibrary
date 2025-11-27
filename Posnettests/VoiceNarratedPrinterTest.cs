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
                throw;
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

