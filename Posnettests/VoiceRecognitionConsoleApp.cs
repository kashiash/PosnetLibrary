using System;
using System.Threading;
using System.Threading.Tasks;

namespace PosnetTests
{
    /// <summary>
    /// Aplikacja konsolowa do testowania rozpoznawania mowy z Whisper.
    /// </summary>
    public class VoiceRecognitionConsoleApp
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("=== Test rozpoznawania mowy z Whisper ===");
            Console.WriteLine();

            // Wybór modelu
            var selectedModel = SelectModel();
            if (selectedModel == null)
            {
                Console.WriteLine("❌ Anulowano wybór modelu.");
                return;
            }

            // Inicjalizacja serwisu Whisper
            var whisperService = new WhisperSpeechRecognitionService();
            try
            {
                await whisperService.InitializeAsync(selectedModel.Value);
                Console.WriteLine();

                int recognitionCount = 0;

                while (true)
                {
                    Console.Write($"[Rozpoznawanie #{++recognitionCount}] ");
                    
                    var recognizedText = await whisperService.RecognizeFromMicrophoneAsync(10);
                    
                    if (string.IsNullOrWhiteSpace(recognizedText))
                    {
                        Console.WriteLine("❌ Nie rozpoznano żadnego tekstu.");
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine($"✅ Rozpoznano: \"{recognizedText}\"");
                    Console.WriteLine($"   Długość: {recognizedText.Length} znaków");
                    Console.WriteLine($"   Słowa: {recognizedText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length}");
                    Console.WriteLine();

                    // Sprawdź komendę zakończenia
                    if (recognizedText.Trim().Equals("koniec", StringComparison.OrdinalIgnoreCase) ||
                        recognizedText.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                        recognizedText.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("🏁 Zakończono test rozpoznawania mowy.");
                        break;
                    }
                }

                Console.WriteLine($"\n📊 Podsumowanie: Rozpoznano {recognitionCount} prób.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Błąd: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                whisperService.Dispose();
            }
        }

        /// <summary>
        /// Pozwala użytkownikowi wybrać model Whisper.
        /// </summary>
        private static WhisperModelSize? SelectModel()
        {
            Console.WriteLine("Wybierz model Whisper:");
            Console.WriteLine();

            var models = WhisperSpeechRecognitionService.GetAvailableModels();
            int index = 1;

            foreach (var model in models)
            {
                Console.WriteLine($"  {index}. {model.Key} - {model.Value.Description} ({model.Value.Size})");
                index++;
            }

            Console.WriteLine();
            Console.Write("Wybierz model (1-4, domyślnie 4 - Medium): ");

            var input = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(input))
            {
                return WhisperModelSize.Medium; // Domyślnie Medium
            }

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= models.Count)
            {
                return (WhisperModelSize)(choice - 1);
            }

            Console.WriteLine("⚠️ Nieprawidłowy wybór, używam domyślnego modelu (Medium).");
            return WhisperModelSize.Medium;
        }
    }
}
