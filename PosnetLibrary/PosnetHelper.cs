using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace PosnetLibrary
{
    public class PosnetHelper
    {
        static string host = "192.168.50.47";
        static int port = 6666;

        public static void SetConnectionSettings(string hostAddress, int portNumber)
        {
            host = hostAddress;
            port = portNumber;
        }


        const string STX = "\u0002";
        const string TAB = "\u0009";
        const string ETX = "\u0003";
        const string LF = "\u000A";

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

        public static void PrintRecipe(FiscalReceipt receipt)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SetFooter(receipt.TransactionNumber, receipt.Notes);

            CultureInfo polishCulture = new CultureInfo("pl-PL");
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    try
                    {

                        SendCommand(stream, new string[] { "trinit", "bm1" });

                        if (!string.IsNullOrEmpty(receipt.BuyerNIP))
                        {
                            var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "trnipset", $"ni{receipt.BuyerNIP}" });

                            SendByEthernet(endLineCommand, stream);
                        }
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
                    catch (SocketException ex)
                    {
                        Console.WriteLine($"Błąd połączenia sieciowego podczas drukowania paragonu: {ex.Message}");
                        try
                        {
                            AnulowanieTransakcji();
                        }
                        catch
                        {
                            // Ignoruj błędy podczas anulowania, jeśli połączenie jest zerwane
                        }
                        throw new Exception($"Błąd połączenia z drukarką podczas drukowania paragonu: {ex.Message}", ex);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Błąd I/O podczas drukowania paragonu: {ex.Message}");
                        try
                        {
                            AnulowanieTransakcji();
                        }
                        catch
                        {
                            // Ignoruj błędy podczas anulowania, jeśli połączenie jest zerwane
                        }
                        throw new Exception($"Błąd komunikacji z drukarką podczas drukowania paragonu: {ex.Message}", ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd podczas drukowania paragonu: {ex.Message}");
                        try
                        {
                            AnulowanieTransakcji();
                        }
                        catch
                        {
                            // Ignoruj błędy podczas anulowania
                        }
                        throw;
                    }

                }
            }
        }
        public static void EparagonGet()
        {

            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagondefaultget" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }


        public static void EparagonSetServer(string url)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagondefaultset", $"ad{url}", "ct0", "gi1", "hd1", "gb1", "td1" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void DailyReport()
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

        public static void SetFooter(string numerTransakcji, string opis = "")
        {
            string linia1 = FormatujLinie("Nr transakcji:", numerTransakcji, true);
            string linia3 = FormatujLinie("Wydrukowano z programu Fleetman", "www.fleetman.com.pl");
            SetFooter($"{linia1}{LF}Opis:{opis.Truncate(50)}{LF}{linia3}");
        }

        private static string FormatujLinie(string prefix, string postfix, bool posfixbolded = false)
        {
            int desiredLength = 56;
            int remainingSpaces = desiredLength - prefix.Length - postfix.Length;

            // Wypełnianie spacjami po obu stronach
            if (posfixbolded)
            {
                return $"{prefix}{new string(' ', remainingSpaces)}&s{postfix}";
            }

            return prefix + new string(' ', remainingSpaces) + postfix;

        }

        public static void SetFooter(string footer)
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                // Uzyskanie strumienia sieciowego
                using (NetworkStream stream = client.GetStream())
                {
                    SendCommand(stream, new string[] { "ftrinfoset", $"tx{footer}" });
                }
            }
        }

        public static void SetHeader(string nazwaFirmy, string miejscowosc, string kod)
        {
            using (TcpClient client = new TcpClient(host, port))
            {


                using (NetworkStream stream = client.GetStream())
                {
                    SendCommand(stream, new string[] { "hdrset", $"tx&c&b&1{nazwaFirmy}&1{LF}&c&b&2{kod}&2 &3 {miejscowosc}&3", "pr1" });
                }
            }
        }

        public static void AnulowanieTransakcji()
        {
            try
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
            catch (SocketException ex)
            {
                Console.WriteLine($"Błąd połączenia sieciowego podczas anulowania transakcji: {ex.Message}");
                throw new Exception($"Nie można połączyć się z drukarką podczas anulowania transakcji: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas anulowania transakcji: {ex.Message}");
                throw;
            }
        }

        public static void SetBuyerNIP(string nip)
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "trnipset", $"ni{nip}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        private static void SendCommand(NetworkStream stream, string[] command)
        {

            SendByEthernet(PosnetHelper.fullCommandEncodedCrced(command), stream);
        }
        private static void SendByEthernet(byte[] data, NetworkStream stream)
        {
            try
            {
                // Wysyłanie danych
                stream.Write(data, 0, data.Length);

                //foreach (byte b in data)
                //{
                //    Console.Write($"{b:X2} ");
                //}
                Console.WriteLine();
                Encoding win1250 = Encoding.GetEncoding(1250);
                Console.WriteLine($"Wysłano: {win1250.GetString(data)}");

                // Odbieranie odpowiedzi
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = win1250.GetString(buffer, 0, bytesRead);

                Console.WriteLine();
                Console.WriteLine($"Odpowiedź od serwera: {response}");
                if (response.Contains("ERR") || response.Contains("?"))
                {
                    ExtractError(response);
                    throw new Exception($"Posnet Error {response}");
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Błąd połączenia sieciowego: {ex.Message}");
                throw new Exception($"Błąd połączenia z drukarką: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
                throw new Exception($"Błąd komunikacji z drukarką: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
                throw;
            }
        }


        private static void SendByEthernet(string dataToSend, NetworkStream stream)
        {
            try
            {
                // Konwersja danych na tablicę bajtów
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);

                // Wysyłanie danych
                stream.Write(data, 0, data.Length);

                //foreach (byte b in data)
                //{
                //    Console.Write($"{b:X2} ");
                //}
                Console.WriteLine();
                Console.WriteLine($"Wysłano: {dataToSend}");

                // Odbieranie odpowiedzi
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Console.WriteLine();
                Console.WriteLine($"Odpowiedź od serwera: {response}");
                if (response.Contains("ERR") || response.Contains("?"))
                {
                    ExtractError(response);
                    throw new Exception($"Posnet Error {response}");
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Błąd połączenia sieciowego: {ex.Message}");
                throw new Exception($"Błąd połączenia z drukarką: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
                throw new Exception($"Błąd komunikacji z drukarką: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
                throw;
            }
        }


        private static void ExtractError(string response)
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
        }
        public static string fullCommand(string[] command)
        {

            string joinedString = string.Join(TAB, command);

            return $"{joinedString}{TAB}";
        }



        public static byte[] fullCommandEncodedCrced(string[] command)
        {


            string joinedString = fullCommand(command);


            Encoding win1250 = Encoding.GetEncoding(1250);
            byte[] bytes = win1250.GetBytes(joinedString);
            string crc = LiczSumeKontrolnaZInstrukcji(bytes);

            return win1250.GetBytes($"{STX}{joinedString}#{crc}{ETX}");
        }

        public static string fullCommandCrced(string[] command)
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
        public static string LiczSumeKontrolnaZInstrukcji(byte[] bytes)
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


            foreach (var ch in bytes)
            {
                index = (byte)(hi ^ ch);
                hi = (byte)(lo ^ crc16htab[index]);
                lo = crc16ltab[index];
            }


            //return ($"{(hi << 8) | lo}");
            return ((hi << 8) | lo).ToString("X");
        }
        public static string LiczSumeKontrolnaZInstrukcji(string ciagZnakow)
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




        public static void EparagonGetStatus()
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonstatusget" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }



        public static void EparagonSetStatus(int status)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonstatusset", $"st{status}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void EparagonSetNextIDZ(string idz)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonidznext", $"id{idz}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void EparagonNewDocumentByIDZ(string idz)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonidzprev", $"id{idz}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void EparagonTestServerConnection(string url)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonconnectiontest", $"ad{url}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }
        public static void EparagonSetServer(int recNo, string url)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonserverins", $"rn{recNo}", $"ad{url}", "ct0", "gi1", "hd1", "gb1", "td1" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void EparagonGetStatus(int recNo)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonserverget", $"rn{recNo}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void EparagonSetSchedule(int sa, int sb, int sc, int op, int tl)
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonsheduleset", $"sa{sa}", $"sb{sb}", $"sc{sc}", $"op{op}", $"tl{tl}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void EparagonGetSchedule()
        {
            using (TcpClient client = new TcpClient(host, port))
            {

                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "eparagonsheduleget" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        public static void VatGet()
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

        public static void VatSet(int vatId, double vatRate, bool active = true)
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "vatset", $"id{vatId}", $"rt{(int)(vatRate * 100)}", $"ac{(active ? 1 : 0)}" });

                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        /// <summary>
        /// Programowanie stawek PTU zgodnie z dokumentacją Posnet.
        /// Wartości specjalne: 100 = stawka zwolniona, 101 = stawka nieaktywna.
        /// </summary>
        /// <param name="va">Wartość stawki A w procentach (0-99.99, 100=zwolniona, 101=nieaktywna)</param>
        /// <param name="vb">Wartość stawki B w procentach</param>
        /// <param name="vc">Wartość stawki C w procentach</param>
        /// <param name="vd">Wartość stawki D w procentach</param>
        /// <param name="ve">Wartość stawki E w procentach</param>
        /// <param name="vf">Wartość stawki F w procentach</param>
        /// <param name="vg">Wartość stawki G w procentach</param>
        /// <param name="date">Opcjonalna data w formacie YYYY-MM-DD;HH:MM</param>
        public static void VatSetRates(double? va = null, double? vb = null, double? vc = null, double? vd = null, double? ve = null, double? vf = null, double? vg = null, string? date = null)
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    var commandParams = new List<string> { "vatset" };

                    if (va.HasValue)
                        commandParams.Add($"va{va.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (vb.HasValue)
                        commandParams.Add($"vb{vb.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (vc.HasValue)
                        commandParams.Add($"vc{vc.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (vd.HasValue)
                        commandParams.Add($"vd{vd.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (ve.HasValue)
                        commandParams.Add($"ve{ve.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (vf.HasValue)
                        commandParams.Add($"vf{vf.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (vg.HasValue)
                        commandParams.Add($"vg{vg.Value.ToString("0.##", CultureInfo.InvariantCulture)}");
                    if (!string.IsNullOrEmpty(date))
                        commandParams.Add($"da{date}");

                    var endLineCommand = PosnetHelper.fullCommandCrced(commandParams.ToArray());
                    SendByEthernet(endLineCommand, stream);
                }
            }
        }

        /// <summary>
        /// Wydruk raportu serwisowego zawierającego m.in. listę stawek VAT.
        /// Raport serwisowy zawiera informacje o stawkach PTU (A-G).
        /// </summary>
        public static void PrintVatRatesList()
        {
            using (TcpClient client = new TcpClient(host, port))
            {
                using (NetworkStream stream = client.GetStream())
                {
                    var endLineCommand = PosnetHelper.fullCommandCrced(new string[] { "servicerep" });
                    SendByEthernet(endLineCommand, stream);
                }
            }
        }
    }
}
