using System.Globalization;
using System.Text;
using NUnit.Framework;
using PosnetLibrary;



namespace PosnetTests
{

    public class Tests
    {



        string host = "192.168.50.47";
        int port = 6666; //2121;

        string[] testParagon = {
            "\u0002trinit\u0009#911D\u0003",
            "\u0002trline\u0009naChleb\u0009vt1\u0009pr200\u0009#B23A\u0003",
            "\u0002trpayment\u0009ty0\u0009wa200\u0009#5EF7\u0003",
            "\u0002trend\u0009#2902\u0003"
        };

        [SetUp]
        public void Setup()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PosnetHelper.SetConnectionSettings(host, port);
        }

        const string STX = "\u0002";
        const string TAB = "\u0009";
        const string ETX = "\u0003";
        const string LF = "\u000A";

        [Test]
        public void CrcTest()
        {

            var command1 = "trinit\u0009bm0\u0009";
            var crc1 = PosnetHelper.LiczSumeKontrolnaZInstrukcji(command1);
            Assert.AreEqual("4825", crc1);


            var command1b = $"trinit{TAB}bm0{TAB}";

            Assert.AreEqual(command1, command1b);

            var crc1b = PosnetHelper.LiczSumeKontrolnaZInstrukcji(command1b);
            Assert.AreEqual("4825", crc1b);


            string[] command1cArr = { "trinit", "bm0" };

            var command1c = PosnetHelper.fullCommand(command1cArr);

            Assert.AreEqual(command1, command1c);

            var crc3 = PosnetHelper.LiczSumeKontrolnaZInstrukcji(command1c);

            Assert.AreEqual("4825", crc3);

            var command2 = "trinit\u0009";
            var crc2 = PosnetHelper.LiczSumeKontrolnaZInstrukcji(command2);
            Assert.AreEqual("911D", crc2);

            var command2b = $"trinit{TAB}";
            var crc2b = PosnetHelper.LiczSumeKontrolnaZInstrukcji(command2b);
            Assert.AreEqual("911D", crc2b);

            var commandRtcGet = $"rtcget{TAB}";
            var crcrtc = PosnetHelper.LiczSumeKontrolnaZInstrukcji(commandRtcGet);
            Assert.AreEqual("7D61", crcrtc);


        }






        [Test]
        public void FullComandCrcTestTest()
        {

            string[] lineCommand = { "trline", "naChleb", "vt1", "pr200" };
            var fullLineCommand = PosnetHelper.fullCommandCrced(lineCommand);

            Assert.AreEqual("\u0002trline\u0009naChleb\u0009vt1\u0009pr200\u0009#B23A\u0003", fullLineCommand);
        }






        [Test]
        public void VatGetTest()
        {
            PosnetHelper.VatGet();
        }

        [Test]
        public void VatSetRatesTest()
        {
            // Przykład zgodny z dokumentacją: ustawienie stawek A=23%, B=8%, C=3%, D=0%, E=0%, F=nieaktywna (101), G=zwolniona (100)
            PosnetHelper.VatSetRates(va: 23, vb: 8, vc: 3, vd: 0, ve: 0, vf: 101, vg: 100);
        }

        [Test]
        public void PrintVatRatesListTest()
        {
            // Wydruk raportu serwisowego zawierającego listę stawek VAT
            PosnetHelper.PrintVatRatesList();
        }
        //[Test]
        //public void StatusLicznikowTest()
        //{


        //    using (TcpClient client = new TcpClient(host, port))
        //    {

        //        using (NetworkStream stream = client.GetStream())
        //        {
        //            var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "scnt" });

        //            SendByEthernet(endLineCommand, stream);
        //        }
        //    }
        //}

        //[Test]
        //public void StatusOgolnyTest()
        //{


        //    using (TcpClient client = new TcpClient(host, port))
        //    {

        //        using (NetworkStream stream = client.GetStream())
        //        {
        //            var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "sdev" });

        //            SendByEthernet(endLineCommand, stream);
        //        }
        //    }
        //}

        [Test]
        public void DailyReportTest()
        {
            PosnetHelper.DailyReport();

        }

        [Test]
        public void EparagonReportTest()
        {
            PosnetHelper.EparagonGet();

        }

        [Test]
        public void EparagongetStatusTest()
        {
            PosnetHelper.EparagonGetStatus();

        }



        [Test]
        public void EparagonSetScheduleTest()
        {
            PosnetHelper.EparagonSetSchedule(10, 15, 60, 1200, 100000);
        }

        [Test]
        public void EparagonGetScheduleTest()
        {
            PosnetHelper.EparagonGetSchedule();
        }

        [Test]
        public void EparagonSetStatusTest()
        {
            PosnetHelper.EparagonSetStatus(1);

        }

        [Test]
        public void EparagongetServerStatusTest()
        {
            PosnetHelper.EparagonGetStatus(1);

        }

        [Test]
        public void EparagonSetTest()
        {
            PosnetHelper.EparagonSetServer("https://debesciaki.free.beeceptor.com");
        }

        [Test]
        public void EparagonSetServerDodTest()
        {
            PosnetHelper.EparagonSetServer(0, "https://debesciaki.free.beeceptor.com");
        }

        [Test]
        public void EparagonServerConnectionTest()
        {
            PosnetHelper.EparagonTestServerConnection("https://debesciaki.free.beeceptor.com");
        }

        //[Test]
        //public void DisplayMessageTest()
        //{
        //    using (TcpClient client = new TcpClient(host, port))
        //    {
        //        using (NetworkStream stream = client.GetStream())
        //        {
        //            SendCommand(stream, new string[] { "dsptxtline", "id0", "no0", "ln***** ***" });

        //            SendCommand(stream, new string[] { "dsptxtline", "id0", "no1", "ln" });

        //            SendCommand(stream, new string[] { "dsptxtline", "id0", "no2", "lnWyskakuj z kasy" });
        //        }
        //    }
        //}

        [Test]
        public void SetHeaderTest()
        {

            var nazwaFirmy = "�ryj z Hasioka";
            var miejscowosc = "Sosnowiec";
            var kod = "41-203";

            PosnetHelper.SetHeader(nazwaFirmy, miejscowosc, kod);
        }



        [Test]
        public void SetFooterTest()
        {

            PosnetHelper.SetFooter($"Nr transakcji: PA/2024/666/999/00125 {LF}Opis: {LF}Wydrukowano z programu Fleetman   &iwww.fleetman.com.pl");

        }


        [Test]
        public void FleetmanRecipeTest()
        {

            var receipt = new FiscalReceipt();
            receipt.BuyerNIP = "6971061467";
            receipt.TransactionNumber = "PA/2024/666/999/00125";
            receipt.FiscalReceiptItems = new List<ItemOnFiscalReceipt>();
            receipt.Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing orci.";
            var line1 = new ItemOnFiscalReceipt("Porsche Panamera E-Hybrid", 2960, 5, "0"); receipt.FiscalReceiptItems.Add(line1);



            //for (int i = 1; i <= 20; i++)
            //{
            var line2 = new ItemOnFiscalReceipt("Fotelik op�ata dodatkowa", 100, 1, "1"); receipt.FiscalReceiptItems.Add(line2);
            var line3 = new ItemOnFiscalReceipt("Telefon satelitarny op�ata dodatkowa", 255, 5, "2", "dalsze obci�zenie na podstawie bilingu"); receipt.FiscalReceiptItems.Add(line3);
            var line4 = new ItemOnFiscalReceipt("Dodatkowy kierowca", 300, 2, "2"); receipt.FiscalReceiptItems.Add(line4);
            //  }

            PosnetHelper.PrintRecipe(receipt);
        }

        [Test]
        public void TestSetIDZ()
        {
            PosnetHelper.EparagonSetNextIDZ("PA/2024/666/999/00125");
        }

        [Test]
        public void TestCreateEdocument()
        {
            PosnetHelper.EparagonNewDocumentByIDZ("PA/2024/666/999/00125");
        }

        [Test]
        public void FiscalRecipeTest()
        {

            var receipt = new FiscalReceipt();
            receipt.BuyerNIP = "6971061467";
            receipt.TransactionNumber = "PA/2024/666/999/00125";

            receipt.FiscalReceiptItems = new List<ItemOnFiscalReceipt>();

            var line1 = new ItemOnFiscalReceipt("Piwerko---------������ѣӹ������-------IBU Pyszne", 20, 5, "0"); receipt.FiscalReceiptItems.Add(line1);



            //for (int i = 1; i <= 20; i++)
            //{
            var line2 = new ItemOnFiscalReceipt("Orzeszki", 100, 25, "1"); receipt.FiscalReceiptItems.Add(line2);
            var line3 = new ItemOnFiscalReceipt("Paluszki", 55, 5.5, "2", "Paluszki bardzo s�one,������ѣӹ������"); receipt.FiscalReceiptItems.Add(line3);
            var line4 = new ItemOnFiscalReceipt("Rzodkiewki", 110, 5.5, "2", "Wersja ekologiczna z nalotem ple�niowym"); receipt.FiscalReceiptItems.Add(line4);
            //  }

            PosnetHelper.PrintRecipe(receipt);
        }



        [Test]
        public void PolisNumbersFormattingTest()
        {
            double number = 12345.67;

            // Create a CultureInfo for Polish formatting
            CultureInfo polishCulture = new CultureInfo("pl-PL");

            // Format the double using the Polish culture
            string formattedNumber = number.ToString("0.##", polishCulture);
            Assert.AreEqual("", formattedNumber);
        }


    }




}