using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PosnetTests
{
    /// <summary>
    /// Serwis obsługujący syntezę mowy na różnych platformach.
    /// </summary>
    public class SpeechService
    {
        /// <summary>
        /// Główna metoda do odczytu tekstu przy użyciu natywnych możliwości systemu operacyjnego.
        /// </summary>
        /// <param name="text">Tekst do odczytania</param>
        /// <param name="voice">Opcjonalna nazwa głosu (dla macOS)</param>
        public static async Task SpeakAsync(string text, string? voice = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                await SpeakOnMacOSAsync(text, voice);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                await SpeakOnWindowsAsync(text);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                await SpeakOnLinuxAsync(text);
            }
            else
            {
                Console.WriteLine($"Synteza mowy nie jest obsługiwana na tej platformie. Tekst: {text}");
            }
        }

        /// <summary>
        /// Implementacja syntezy mowy dla macOS używająca natywnego narzędzia 'say'.
        /// </summary>
        private static async Task SpeakOnMacOSAsync(string text, string? voice = null)
        {
            var voiceToUse = voice ?? GetMacOSVoice(text);
            
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "/usr/bin/say",
                Arguments = $"-v {voiceToUse} \"{text}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using var process = Process.Start(processStartInfo);
                if (process != null)
                {
                    await process.WaitForExitAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas syntezy mowy na macOS: {ex.Message}");
            }
        }

        /// <summary>
        /// Implementacja syntezy mowy dla Windows używająca PowerShell z System.Speech.Synthesis.
        /// </summary>
        private static async Task SpeakOnWindowsAsync(string text)
        {
            var script = $@"
                Add-Type -AssemblyName System.Speech
                $speak = New-Object System.Speech.Synthesis.SpeechSynthesizer
                $speak.Speak('{text.Replace("'", "''")}')
            ";

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"{script}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using var process = Process.Start(processStartInfo);
                if (process != null)
                {
                    await process.WaitForExitAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas syntezy mowy na Windows: {ex.Message}");
            }
        }

        /// <summary>
        /// Implementacja syntezy mowy dla Linux używająca 'espeak'.
        /// </summary>
        private static async Task SpeakOnLinuxAsync(string text)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "espeak",
                Arguments = $"-v pl \"{text}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            try
            {
                using var process = Process.Start(processStartInfo);
                if (process != null)
                {
                    await process.WaitForExitAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas syntezy mowy na Linux: {ex.Message}");
                Console.WriteLine("Upewnij się, że espeak jest zainstalowany: sudo apt-get install espeak");
            }
        }

        /// <summary>
        /// Automatycznie wybiera odpowiedni głos w zależności od języka tekstu (dla macOS).
        /// </summary>
        private static string GetMacOSVoice(string text)
        {
            // Domyślnie używamy polskiego głosu Zosia
            // Można rozszerzyć logikę wykrywania języka
            return "Zosia";
        }
    }
}



