namespace PosnetTests;

/// <summary>
/// Program główny do uruchamiania aplikacji konsolowych do testowania.
/// Uruchom: dotnet run --project Posnettests/PosnetTests.csproj -- VoiceRecognition
/// </summary>
public class Program
{
    public static async Task Main(string[] args)
    {
        // Domyślnie uruchom VoiceRecognition jeśli nie podano argumentów
        if (args.Length == 0 || args[0].Equals("VoiceRecognition", StringComparison.OrdinalIgnoreCase))
        {
            await VoiceRecognitionConsoleApp.RunAsync();
        }
        else
        {
            Console.WriteLine("Dostępne opcje:");
            Console.WriteLine("  VoiceRecognition - test rozpoznawania mowy z Whisper");
            Console.WriteLine();
            Console.WriteLine("Użycie: dotnet run --project Posnettests/PosnetTests.csproj -- VoiceRecognition");
        }
    }
}
