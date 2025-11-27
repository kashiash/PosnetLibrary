using System.Text;
using NUnit.Framework;
using PosnetLibrary;

namespace PosnetTests
{
    /// <summary>
    /// Klasa testowa do rozpoczęcia pracy z drukarką Posnet.
    /// Zawiera podstawowe testy połączenia i konfiguracji drukarki sieciowej.
    /// </summary>
    public class StartZabawyZDrukarkaTest
    {
        // Ustawienia połączenia z drukarką
        // WAŻNE: Przed uruchomieniem testów należy skonfigurować drukarkę:
        // 1. Wejść do menu ustawień sieciowych w drukarce
        // 2. Ustawić adres IP na sztywno (statyczny), żeby się nie zmieniał na routerze
        // 3. Sprawdzić port drukarki - wydrukować raporty niefiskalne -> raport sieciowy
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
        /// Test podstawowy - sprawdzenie połączenia z drukarką przez wywołanie raportu dobowego.
        /// To pierwszy test, który należy uruchomić po skonfigurowaniu drukarki sieciowej.
        /// Jeśli drukarka zareaguje i wydrukuje raport dobowy, oznacza to, że połączenie działa poprawnie.
        /// </summary>
        [Test]
        public void DailyReportTest()
        {
            // Wywołanie raportu dobowego - drukarka powinna zareagować i wydrukować raport
            PosnetHelper.DailyReport();
        }

        /// <summary>
        /// Test ustawienia nagłówka paragonu.
        /// Nagłówek zawiera informacje o firmie: nazwę firmy, miejscowość i kod pocztowy.
        /// Ustawienia nagłówka będą widoczne na wszystkich paragonach wydrukowanych przez drukarkę.
        /// </summary>
        [Test]
        public void SetHeaderTest()
        {
            var nazwaFirmy = "�ryj z Hasioka";
            var miejscowosc = "Sosnowiec";
            var kod = "41-203";

            PosnetHelper.SetHeader(nazwaFirmy, miejscowosc, kod);
        }

        /// <summary>
        /// Test ustawienia stopki paragonu.
        /// Stopka może zawierać dodatkowe informacje, np. numer transakcji, opis, adres strony www.
        /// Ustawienia stopki będą widoczne na wszystkich paragonach wydrukowanych przez drukarkę.
        /// </summary>
        [Test]
        public void SetFooterTest()
        {
            PosnetHelper.SetFooter($"Nr transakcji: PA/2024/666/999/00125 {LF}Opis: {LF}Wydrukowano z programu Fleetman   &iwww.fleetman.com.pl");
        }

        /// <summary>
        /// Test kompleksowy - wykonanie wszystkich podstawowych testów w odpowiedniej kolejności.
        /// Kolejność:
        /// 1. Raport dobowy - sprawdzenie połączenia
        /// 2. Ustawienie nagłówka
        /// 3. Ustawienie stopki
        /// </summary>
        [Test]
        public void WszystkiePodstawoweTesty()
        {
            // Krok 1: Sprawdzenie połączenia - raport dobowy
            PosnetHelper.DailyReport();

            // Krok 2: Ustawienie nagłówka paragonu
            var nazwaFirmy = "�ryj z Hasioka";
            var miejscowosc = "Sosnowiec";
            var kod = "41-203";
            PosnetHelper.SetHeader(nazwaFirmy, miejscowosc, kod);

            // Krok 3: Ustawienie stopki paragonu
            PosnetHelper.SetFooter($"Nr transakcji: PA/2024/666/999/00125 {LF}Opis: {LF}Wydrukowano z programu Fleetman   &iwww.fleetman.com.pl");
        }
    }
}

