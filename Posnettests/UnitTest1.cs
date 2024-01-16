using System.Globalization;
using System.Net.Sockets;
using System.Text;
using NUnit.Framework;
using PosnetLibrary;



namespace PosnetTests
{

    public class Tests
    {



        string host = "192.168.50.166";
        int port = 6666;

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


            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "vatget" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }
        [Test]
        public void StatusLicznikowTest()
        {


            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "scnt" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        [Test]
        public void StatusOgolnyTest()
        {


            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "sdev" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        [Test]
        public void DailyReportTest()
        {


            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "dailyrep" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }





        [Test]
        public void DisplayMessageTest()
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    SendCommand(stream, new string[] { "dsptxtline", "id0", "no0", "ln***** ***" });

                    SendCommand(stream, new string[] { "dsptxtline", "id0", "no1", "ln" });

                    SendCommand(stream, new string[] { "dsptxtline", "id0", "no2", "lnWyskakuj z kasy" });
                }
            }
        }

        [Test]
        public void SetHeaderTest()
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                var nazwaFirmy = "Uslugi erotyczne Obajtek";
                var miejscowosc = "Pcim Dolny";
                var kod = "32-432";
                using (NetworkStream stream = client.GetStream())
                {
                    SendCommand(stream, new string[] { "hdrset", $"tx&c&b&1{nazwaFirmy}&1{LF}&c&b&2{kod}&2 &3 {miejscowosc}&3", "pr1" });
                }
            }
        }

        [Test]
        public void SetFooterTest()
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                // Uzyskanie strumienia sieciowego
                using (NetworkStream stream = client.GetStream())
                {
                    SendCommand(stream, new string[] { "ftrinfoset", $"tx&c&bPILES? NIE JEDZ!&c&b{LF}&c&b NIE PILES? WYPIJ!&c&b{LF}&c&HFLEETMAN RULEZ&H&c" });
                }
            }
        }


        [Test]
        public void AnulowanieTransakcjiTest()
        {
            AnulowanieTransakcji();
        }


        public void AnulowanieTransakcji()
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "prncancel" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        [Test]
        public void FiscalRecipeTest()
        {

            var receipt = new FiscalReceipt();
            receipt.FiscalReceiptItems = new List<ItemOnFiscalReceipt>();

            var line1 = new ItemOnFiscalReceipt("Piwerko1234567890123456•Øåè∆ —£”πøúüÊÒÛ≥45678901234567890IBU Pyszne", 20, 5, "0"); receipt.FiscalReceiptItems.Add(line1);



            //for (int i = 1; i <= 20; i++)
            //{
            var line2 = new ItemOnFiscalReceipt("Orzeszki", 100, 25, "1"); receipt.FiscalReceiptItems.Add(line2);
            var line3 = new ItemOnFiscalReceipt("Paluszki", 55, 5.5, "2", "Paluszki bardzo slone,•Øåè∆ —£”πøúüÊÒÛ≥"); receipt.FiscalReceiptItems.Add(line3);
            var line4 = new ItemOnFiscalReceipt("Rzodkiewki", 110, 5.5, "2", "Wersja ekologiczna z nalotem pleúniowym"); receipt.FiscalReceiptItems.Add(line4);
            //  }

            PrintRecipe(receipt);
        }

        private void PrintRecipe(FiscalReceipt receipt)
        {
            CultureInfo polishCulture = new CultureInfo("pl-PL");
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    try
                    {
                        SendCommand(stream, new string[] { "trinit", "bm1" });
                        //"\u0002trline\u0009naChleb\u0009vt1\u0009pr200\u0009#B23A\u0003",
                        foreach (var item in receipt.FiscalReceiptItems)
                        {
                            string formattedquantity = item.Quantity.ToString("0.##", polishCulture);
                            double price = (item.GrossAmount * 100.0 / item.Quantity);
                            SendCommand(stream, new string[] { "trline",
                            $"na{item.ItemName.Truncate(80)}",
                            $"vt{item.VatRate}",
                            $"pr{(int)price}",
                            $"il{formattedquantity}",
                            $"wa{(int)(item.GrossAmount * 100)}" ,
                            $"op{item.Description.Truncate(50)}"
                            });
                        }
                        SendCommand(stream, new string[] { "trend", $"to{(int)(receipt.GrossAmount * 100)}" });
                    }
                    catch (Exception ex)
                    {
                        AnulowanieTransakcji();
                    }

                }
            }
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




        [Test]
        public void SimpleRecipetest()
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                // Uzyskanie strumienia sieciowego
                using (NetworkStream stream = client.GetStream())
                {
                    //        "\u0002trinit\u0009#911D\u0003",
                    SendCommand(stream, new string[] { "trinit", "bm1" });
                    //"\u0002trline\u0009naChleb\u0009vt1\u0009pr200\u0009#B23A\u0003",
                    SendCommand(stream, new string[] { "trline", "naPiwerko", "vt1", "pr200" });
                    SendCommand(stream, new string[] { "trline", "naOrzeszki", "vt1", "pr300" });
                    SendCommand(stream, new string[] { "trline", "naúåledzik", "vt0", "pr500" });
                    SendCommand(stream, new string[] { "trline", "na•Øåè∆ —£”πøúüÊÒÛ≥", "vt2", "pr2330" });
                    //"\u0002trpayment\u0009ty0\u0009wa200\u0009#5EF7\u0003",
                    SendCommand(stream, new string[] { "trpayment", "ty0", "wa1000" });
                    SendCommand(stream, new string[] { "trpayment", "ty2", "wa200" });
                    SendCommand(stream, new string[] { "trpayment", "ty3", "wa1800" });
                    // SendCommand(stream, new string[] { "trpayment", "ty4", "wa330" });
                    // SendCommand(stream, new string[] { "trpayment", "ty5", "wa330" });
                    // SendCommand(stream, new string[] { "trpayment", "ty6", "wa330" });
                    // SendCommand(stream, new string[] { "trpayment", "ty7", "wa330" });
                    SendCommand(stream, new string[] { "trpayment", "ty8", "wa330" });


                    //"\u0002trend\u0009#2902\u0003"
                    SendCommand(stream, new string[] { "trend", "to3330", "fp3330" });
                }
            }
        }


        [Test]
        public void QuantityRecipeTest()
        {



            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    SendCommand(stream, new string[] { "trinit", "bm1" });
                    SendCommand(stream, new string[] { "trline", "naZiemniaczki", "vt1", "pr200", "il5,5", "wa1100" });
                    SendCommand(stream, new string[] { "trend", "to1100" });
                }
            }
        }
        enum paymentType
        {
            Gotowka = 0,
            Karta = 2,
            Czeka = 3,
            Bon = 4,
            Kredyt = 5,
            Inna = 6,
            Voucher = 7,
            Przelew = 8
        }

        private void SendCommand(NetworkStream stream, string[] command)
        {

            SendByEthernet(PosnetHelper.fullCommandEncodedCrced(command), stream);
        }

        [Test]
        public void EthernetTest()
        {

            string dailyRep = "dailyrep";
            string command3 = "\u0002trinit\u0009#911D\u0003";

            using (TcpClient client = new TcpClient(host, port))
            {
                // Uzyskanie strumienia sieciowego
                using (NetworkStream stream = client.GetStream())
                {

                    string[] startCommand = { "trinit", "bm0" };
                    SendByEthernet(PosnetHelper.fullCommandCrced(startCommand), stream);



                    SendByEthernet(PosnetHelper.fullCommandCrced(new string[] { "trline", "naChleb", "vt0", "pr200" }), stream);
                    SendByEthernet(PosnetHelper.fullCommandCrced(new string[] { "trline", "naPiwo", "vt1", "pr200" }), stream);
                    SendByEthernet(PosnetHelper.fullCommandCrced(new string[] { "trline", "naPampers", "vt2", "pr200" }), stream);
                    SendByEthernet(PosnetHelper.fullCommandCrced(new string[] { "trline", "naWhisky", "vt3", "pr200" }), stream);

                    // "\u0002trpayment\u0009ty0\u0009wa200\u0009#5EF7\u0003",

                    var paymentLineCommand = PosnetHelper.fullCommandCrced(new string[] { "trpayment", "ty0", "wa500" });

                    SendByEthernet(paymentLineCommand, stream);
                    var paymentLineCommand2 = PosnetHelper.fullCommandCrced(new string[] { "trpayment", "ty2", "wa100" });

                    SendByEthernet(paymentLineCommand2, stream);

                    var paymentLineCommand3 = PosnetHelper.fullCommandCrced(new string[] { "trpayment", "ty8", "wa200" });

                    SendByEthernet(paymentLineCommand3, stream);
                    //  "\u0002trend\u0009#2902\u0003"

                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "trend", "to800" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        private void SendByEthernet(byte[] data, NetworkStream stream)
        {

            // Wysy≥anie danych
            stream.Write(data, 0, data.Length);

            //foreach (byte b in data)
            //{
            //    Console.Write($"{b:X2} ");
            //}
            Console.WriteLine();
            Console.WriteLine($"Wys≥ano: {data.ToString()}");

            // Odbieranie odpowiedzi
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine();
            Console.WriteLine($"Odpowiedü od serwera: {response}");
            if (response.Contains("ERR") || response.Contains("?"))
            {
                ExtractError(response);
                throw new Exception($"Posnet Error {response}");
            }

        }


        private void SendByEthernet(string dataToSend, NetworkStream stream)
        {
            // Konwersja danych na tablicÍ bajtÛw
            byte[] data = Encoding.UTF8.GetBytes(dataToSend);

            // Wysy≥anie danych
            stream.Write(data, 0, data.Length);

            //foreach (byte b in data)
            //{
            //    Console.Write($"{b:X2} ");
            //}
            Console.WriteLine();
            Console.WriteLine($"Wys≥ano: {dataToSend}");

            // Odbieranie odpowiedzi
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine();
            Console.WriteLine($"Odpowiedü od serwera: {response}");
            if (response.Contains("ERR") || response.Contains("?"))
            {
                ExtractError(response);
                throw new Exception($"Posnet Error {response}");
            }

        }

        private void ExtractError(string response)
        {
            string[] result = response.Split(new string[] { STX, TAB, ETX, LF, " " }, StringSplitOptions.RemoveEmptyEntries);
            var code = result.Where(r => r.Contains("?")).FirstOrDefault();
            var message = ErrorHelper.GetErrorDescription(code);
            Console.WriteLine(message);

        }




    }




}