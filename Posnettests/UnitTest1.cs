using NUnit.Framework;
using System.Diagnostics;

using System.Text;


using System.Net.Sockets;
using System.IO.Ports;
using System.Collections;
using System.IO;
using System.Globalization;
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




        const string STX = "\u0002";
        const string TAB = "\u0009";
        const string ETX = "\u0003";
        const string LF = "\u000A";

        [Test]
        public void CrcTest()
        {

            var command1 = "trinit\u0009bm0\u0009";
            var crc1 = LiczSumeKontrolnaZInstrukcji(command1);
            Assert.AreEqual("4825", crc1);


            var command1b = $"trinit{TAB}bm0{TAB}";

            Assert.AreEqual(command1, command1b);

            var crc1b = LiczSumeKontrolnaZInstrukcji(command1b);
            Assert.AreEqual("4825", crc1b);


            string[] command1cArr = { "trinit", "bm0" };

            var command1c = fullCommand(command1cArr);

            Assert.AreEqual(command1, command1c);

            var crc3 = LiczSumeKontrolnaZInstrukcji(command1c);

            Assert.AreEqual("4825", crc3);

            var command2 = "trinit\u0009";
            var crc2 = LiczSumeKontrolnaZInstrukcji(command2);
            Assert.AreEqual("911D", crc2);

            var command2b = $"trinit{TAB}";
            var crc2b = LiczSumeKontrolnaZInstrukcji(command2b);
            Assert.AreEqual("911D", crc2b);

            var commandRtcGet = $"rtcget{TAB}";
            var crcrtc = LiczSumeKontrolnaZInstrukcji(commandRtcGet);
            Assert.AreEqual("7D61", crcrtc);


        }


        string fullCommand(string[] command)
        {

            string joinedString = string.Join(TAB, command);

            return $"{joinedString}{TAB}";
        }


        string fullCommandCrced(string[] command)
        {

            string joinedString = fullCommand(command);
            string crc = LiczSumeKontrolnaZInstrukcji(joinedString);

            return $"{STX}{joinedString}#{crc}{ETX}";
        }

        string fullCommandCrced(string command)
        {


            string crc = LiczSumeKontrolnaZInstrukcji($"{command}{TAB}");

            return $"{STX}{command}{TAB}#{crc}{ETX}";
        }


        [Test]
        public void FullComandCrcTestTest()
        {

            string[] lineCommand = { "trline", "naChleb", "vt1", "pr200" };
            var fullLineCommand = fullCommandCrced(lineCommand);

            Assert.AreEqual("\u0002trline\u0009naChleb\u0009vt1\u0009pr200\u0009#B23A\u0003", fullLineCommand);
        }

        [SetUp]
        public void Setup()
        {
        }




        [Test]
        public void VatGetTest()
        {


            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = fullCommandCrced(new string[] { "vatget" });

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
                    var endLineCommand = fullCommandCrced(new string[] { "scnt" });

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
                    var endLineCommand = fullCommandCrced(new string[] { "sdev" });

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
                    var endLineCommand = fullCommandCrced(new string[] { "dailyrep"});

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
                    SendCommand(stream, new string[] { "hdrset", $"tx&c&1{nazwaFirmy}&1{LF}&c&b&2{kod}&2 &3 {miejscowosc}&3", "pr1" });
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
                    var endLineCommand = fullCommandCrced(new string[] { "prncancel" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        [Test]
        public void FiscalRecipeTest()
        {
            CultureInfo polishCulture = new CultureInfo("pl-PL");
            var receipt = new FiscalReceipt();
            receipt.FiscalReceiptItems = new List<ItemOnFiscalReceipt>();

            var line1 = new ItemOnFiscalReceipt("Piwerko", 20, 5, "0"); receipt.FiscalReceiptItems.Add(line1);



            //for (int i = 1; i <= 20; i++)
            //{
            var line2 = new ItemOnFiscalReceipt("Orzeszki", 100, 25, "1"); receipt.FiscalReceiptItems.Add(line2);
            //  var line3 = new ItemOnFiscalReceipt("Paluszki", 55, 5.5, "2"); receipt.FiscalReceiptItems.Add(line3);
            //   var line4 = new ItemOnFiscalReceipt("Rzodkiewki", 110, 5.5, "2"); receipt.FiscalReceiptItems.Add(line4);
            //  }

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
                            $"na{item.ItemName}",
                            $"vt{item.VatRate}",
                            $"pr{(int)price}",
                            $"il{formattedquantity}",
                            $"wa{(int)(item.GrossAmount * 100)}" });
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
                    SendCommand(stream, new string[] { "trline", "naSledzik", "vt0", "pr500" });
                    SendCommand(stream, new string[] { "trline", "naFlaszeczka", "vt2", "pr2330" });
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

            SendByEthernet(fullCommandCrced(command), stream);
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
                    SendByEthernet(fullCommandCrced(startCommand), stream);



                    SendByEthernet(fullCommandCrced(new string[] { "trline", "naChleb", "vt0", "pr200" }), stream);
                    SendByEthernet(fullCommandCrced(new string[] { "trline", "naPiwo", "vt1", "pr200" }), stream);
                    SendByEthernet(fullCommandCrced(new string[] { "trline", "naPampers", "vt2", "pr200" }), stream);
                    SendByEthernet(fullCommandCrced(new string[] { "trline", "naWhisky", "vt3", "pr200" }), stream);

                    // "\u0002trpayment\u0009ty0\u0009wa200\u0009#5EF7\u0003",

                    var paymentLineCommand = fullCommandCrced(new string[] { "trpayment", "ty0", "wa500" });

                    SendByEthernet(paymentLineCommand, stream);
                    var paymentLineCommand2 = fullCommandCrced(new string[] { "trpayment", "ty2", "wa100" });

                    SendByEthernet(paymentLineCommand2, stream);

                    var paymentLineCommand3 = fullCommandCrced(new string[] { "trpayment", "ty8", "wa200" });

                    SendByEthernet(paymentLineCommand3, stream);
                    //  "\u0002trend\u0009#2902\u0003"

                    var endLineCommand = fullCommandCrced(new string[] { "trend", "to800" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        private void SendByEthernet(string dataToSend, NetworkStream stream)
        {
            // Konwersja danych na tablicê bajtów
            byte[] data = Encoding.UTF8.GetBytes(dataToSend);

            // Wysy³anie danych
            stream.Write(data, 0, data.Length);

            //foreach (byte b in data)
            //{
            //    Console.Write($"{b:X2} ");
            //}
            Console.WriteLine();
            Console.WriteLine($"Wys³ano: {dataToSend}");

            // Odbieranie odpowiedzi
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine();
            Console.WriteLine($"OdpowiedŸ od serwera: {response}");
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



        private string LiczSumeKontrolnaZInstrukcji(string ciagZnakow)
        {
            byte[] crc16htab =
            {
                0x00, 0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70,
                0x81, 0x91, 0xa1, 0xb1, 0xc1, 0xd1, 0xe1, 0xf1,
                0x12, 0x02, 0x32, 0x22, 0x52, 0x42, 0x72, 0x62,
                0x93, 0x83, 0xb3, 0xa3, 0xd3, 0xc3, 0xf3, 0xe3,
                0x24, 0x34, 0x04, 0x14, 0x64, 0x74, 0x44, 0x54,
                0xa5, 0xb5, 0x85, 0x95, 0xe5, 0xf5, 0xc5, 0xd5,
                0x36, 0x26, 0x16, 0x06, 0x76, 0x66, 0x56, 0x46,
                0xb7, 0xa7, 0x97, 0x87, 0xf7, 0xe7, 0xd7, 0xc7,
                0x48, 0x58, 0x68, 0x78, 0x08, 0x18, 0x28, 0x38,
                0xc9, 0xd9, 0xe9, 0xf9, 0x89, 0x99, 0xa9, 0xb9,
                0x5a, 0x4a, 0x7a, 0x6a, 0x1a, 0x0a, 0x3a, 0x2a,
                0xdb, 0xcb, 0xfb, 0xeb, 0x9b, 0x8b, 0xbb, 0xab,
                0x6c, 0x7c, 0x4c, 0x5c, 0x2c, 0x3c, 0x0c, 0x1c,
                0xed, 0xfd, 0xcd, 0xdd, 0xad, 0xbd, 0x8d, 0x9d,
                0x7e, 0x6e, 0x5e, 0x4e, 0x3e, 0x2e, 0x1e, 0x0e,
                0xff, 0xef, 0xdf, 0xcf, 0xbf, 0xaf, 0x9f, 0x8f,
                0x91, 0x81, 0xb1, 0xa1, 0xd1, 0xc1, 0xf1, 0xe1,
                0x10, 0x00, 0x30, 0x20, 0x50, 0x40, 0x70, 0x60,
                0x83, 0x93, 0xa3, 0xb3, 0xc3, 0xd3, 0xe3, 0xf3,
                0x02, 0x12, 0x22, 0x32, 0x42, 0x52, 0x62, 0x72,
                0xb5, 0xa5, 0x95, 0x85, 0xf5, 0xe5, 0xd5, 0xc5,
                0x34, 0x24, 0x14, 0x04, 0x74, 0x64, 0x54, 0x44,
                0xa7, 0xb7, 0x87, 0x97, 0xe7, 0xf7, 0xc7, 0xd7,
                0x26, 0x36, 0x06, 0x16, 0x66, 0x76, 0x46, 0x56,
                0xd9, 0xc9, 0xf9, 0xe9, 0x99, 0x89, 0xb9, 0xa9,
                0x58, 0x48, 0x78, 0x68, 0x18, 0x08, 0x38, 0x28,
                0xcb, 0xdb, 0xeb, 0xfb, 0x8b, 0x9b, 0xab, 0xbb,
                0x4a, 0x5a, 0x6a, 0x7a, 0x0a, 0x1a, 0x2a, 0x3a,
                0xfd, 0xed, 0xdd, 0xcd, 0xbd, 0xad, 0x9d, 0x8d,
                0x7c, 0x6c, 0x5c, 0x4c, 0x3c, 0x2c, 0x1c, 0x0c,
                0xef, 0xff, 0xcf, 0xdf, 0xaf, 0xbf, 0x8f, 0x9f,
                0x6e, 0x7e, 0x4e, 0x5e, 0x2e, 0x3e, 0x0e, 0x1e
            };

            byte[] crc16ltab =
            {
                0x00, 0x21, 0x42, 0x63, 0x84, 0xa5, 0xc6, 0xe7,
                0x08, 0x29, 0x4a, 0x6b, 0x8c, 0xad, 0xce, 0xef,
                0x31, 0x10, 0x73, 0x52, 0xb5, 0x94, 0xf7, 0xd6,
                0x39, 0x18, 0x7b, 0x5a, 0xbd, 0x9c, 0xff, 0xde,
                0x62, 0x43, 0x20, 0x01, 0xe6, 0xc7, 0xa4, 0x85,
                0x6a, 0x4b, 0x28, 0x09, 0xee, 0xcf, 0xac, 0x8d,
                0x53, 0x72, 0x11, 0x30, 0xd7, 0xf6, 0x95, 0xb4,
                0x5b, 0x7a, 0x19, 0x38, 0xdf, 0xfe, 0x9d, 0xbc,
                0xc4, 0xe5, 0x86, 0xa7, 0x40, 0x61, 0x02, 0x23,
                0xcc, 0xed, 0x8e, 0xaf, 0x48, 0x69, 0x0a, 0x2b,
                0xf5, 0xd4, 0xb7, 0x96, 0x71, 0x50, 0x33, 0x12,
                0xfd, 0xdc, 0xbf, 0x9e, 0x79, 0x58, 0x3b, 0x1a,
                0xa6, 0x87, 0xe4, 0xc5, 0x22, 0x03, 0x60, 0x41,
                0xae, 0x8f, 0xec, 0xcd, 0x2a, 0x0b, 0x68, 0x49,
                0x97, 0xb6, 0xd5, 0xf4, 0x13, 0x32, 0x51, 0x70,
                0x9f, 0xbe, 0xdd, 0xfc, 0x1b, 0x3a, 0x59, 0x78,
                0x88, 0xa9, 0xca, 0xeb, 0x0c, 0x2d, 0x4e, 0x6f,
                0x80, 0xa1, 0xc2, 0xe3, 0x04, 0x25, 0x46, 0x67,
                0xb9, 0x98, 0xfb, 0xda, 0x3d, 0x1c, 0x7f, 0x5e,
                0xb1, 0x90, 0xf3, 0xd2, 0x35, 0x14, 0x77, 0x56,
                0xea, 0xcb, 0xa8, 0x89, 0x6e, 0x4f, 0x2c, 0x0d,
                0xe2, 0xc3, 0xa0, 0x81, 0x66, 0x47, 0x24, 0x05,
                0xdb, 0xfa, 0x99, 0xb8, 0x5f, 0x7e, 0x1d, 0x3c,
                0xd3, 0xf2, 0x91, 0xb0, 0x57, 0x76, 0x15, 0x34,
                0x4c, 0x6d, 0x0e, 0x2f, 0xc8, 0xe9, 0x8a, 0xab,
                0x44, 0x65, 0x06, 0x27, 0xc0, 0xe1, 0x82, 0xa3,
                0x7d, 0x5c, 0x3f, 0x1e, 0xf9, 0xd8, 0xbb, 0x9a,
                0x75, 0x54, 0x37, 0x16, 0xf1, 0xd0, 0xb3, 0x92,
                0x2e, 0x0f, 0x6c, 0x4d, 0xaa, 0x8b, 0xe8, 0xc9,
                0x26, 0x07, 0x64, 0x45, 0xa2, 0x83, 0xe0, 0xc1,
                0x1f, 0x3e, 0x5d, 0x7c, 0x9b, 0xba, 0xd9, 0xf8,
                0x17, 0x36, 0x55, 0x74, 0x93, 0xb2, 0xd1, 0xf0
            };

            byte hi = 0, lo = 0, index;
            string s = ciagZnakow;

            foreach (var ch in s)
            {
                index = (byte)(hi ^ (byte)ch);
                hi = (byte)(lo ^ crc16htab[index]);
                lo = crc16ltab[index];
            }


            //return ($"{(hi << 8) | lo}");
            return ((hi << 8) | lo).ToString("X");
        }



        // errorlist

     

      
    }




}