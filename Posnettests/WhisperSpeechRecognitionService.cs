using Whisper.net;
using Whisper.net.Ggml;
using NAudio.Wave;
using System.Diagnostics;
using System.Text;
using System.Net.Http;

namespace PosnetTests
{
    /// <summary>
    /// Rozmiary modeli Whisper dostępne do wyboru.
    /// </summary>
    public enum WhisperModelSize
    {
        Tiny,
        Base,
        Small,
        Medium
    }

    /// <summary>
    /// Serwis rozpoznawania mowy używający Whisper.net.
    /// Obsługuje wiele modeli i nagrywanie z mikrofonu.
    /// </summary>
    public class WhisperSpeechRecognitionService
    {
        private WhisperFactory? _whisperFactory;
        private WhisperProcessor? _processor;
        private WhisperModelSize _currentModelSize;
        private bool _isInitialized = false;

        /// <summary>
        /// Inicjalizuje wybrany model Whisper.
        /// </summary>
        /// <param name="modelSize">Rozmiar modelu do użycia</param>
        public async Task InitializeAsync(WhisperModelSize modelSize = WhisperModelSize.Medium)
        {
            if (_isInitialized && _currentModelSize == modelSize)
            {
                return; // Już zainicjalizowany z tym modelem
            }

            _currentModelSize = modelSize;
            var ggmlType = GetGgmlType(modelSize);

            Console.WriteLine($"🔄 Inicjalizacja modelu Whisper: {modelSize}...");
            Console.WriteLine("📥 Pobieranie modelu (może to chwilę potrwać przy pierwszym użyciu)...");

            try
            {
                _whisperFactory = WhisperFactory.FromPath(await GetModelPathAsync(ggmlType));
                _processor = _whisperFactory.CreateBuilder()
                    .WithLanguage("pl") // Polski język
                    .Build();

                _isInitialized = true;
                Console.WriteLine($"✅ Model {modelSize} został załadowany pomyślnie!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Błąd podczas inicjalizacji modelu: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Rozpoznaje mowę z mikrofonu.
        /// </summary>
        /// <param name="timeoutSeconds">Maksymalny czas nagrywania w sekundach</param>
        /// <returns>Rozpoznany tekst lub null jeśli nie udało się rozpoznać</returns>
        public async Task<string?> RecognizeFromMicrophoneAsync(int timeoutSeconds = 10)
        {
            if (!_isInitialized || _processor == null)
            {
                throw new InvalidOperationException("Model nie został zainicjalizowany. Wywołaj InitializeAsync() najpierw.");
            }

            Console.WriteLine($"🎤 Nagrywanie audio przez {timeoutSeconds} sekund...");
            Console.WriteLine("💡 Mów teraz do mikrofonu...");

            try
            {
                // Nagraj audio z mikrofonu
                var audioData = await RecordAudioFromMicrophoneAsync(timeoutSeconds);

                if (audioData == null || audioData.Length == 0)
                {
                    Console.WriteLine("❌ Nie nagrano żadnego audio.");
                    return null;
                }

                Console.WriteLine("🔄 Przetwarzanie audio przez Whisper...");

                // Rozpoznaj mowę
                var result = new StringBuilder();
                using var stream = new MemoryStream(audioData);
                
                await foreach (var segment in _processor.ProcessAsync(stream))
                {
                    result.Append(segment.Text);
                }

                var recognizedText = result.ToString().Trim();
                
                if (string.IsNullOrWhiteSpace(recognizedText))
                {
                    Console.WriteLine("❌ Nie rozpoznano żadnego tekstu.");
                    return null;
                }

                return recognizedText;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Błąd podczas rozpoznawania mowy: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Rozpoznaje mowę z pliku audio.
        /// </summary>
        /// <param name="audioFilePath">Ścieżka do pliku audio</param>
        /// <returns>Rozpoznany tekst lub null jeśli nie udało się rozpoznać</returns>
        public async Task<string?> RecognizeFromFileAsync(string audioFilePath)
        {
            if (!_isInitialized || _processor == null)
            {
                throw new InvalidOperationException("Model nie został zainicjalizowany. Wywołaj InitializeAsync() najpierw.");
            }

            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine($"❌ Plik nie istnieje: {audioFilePath}");
                return null;
            }

            try
            {
                Console.WriteLine($"🔄 Przetwarzanie pliku audio: {audioFilePath}");

                var result = new StringBuilder();
                using var fileStream = File.OpenRead(audioFilePath);
                
                await foreach (var segment in _processor.ProcessAsync(fileStream))
                {
                    result.Append(segment.Text);
                }

                return result.ToString().Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Błąd podczas przetwarzania pliku: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Nagrywa audio z mikrofonu w formacie WAV (16kHz, mono).
        /// </summary>
        private async Task<byte[]?> RecordAudioFromMicrophoneAsync(int durationSeconds)
        {
            try
            {
                using var waveIn = new WaveInEvent
                {
                    WaveFormat = new WaveFormat(16000, 1) // 16kHz, mono - wymagane przez Whisper
                };

                var audioBuffer = new List<byte>();
                var stopwatch = Stopwatch.StartNew();
                var recordingTask = new TaskCompletionSource<byte[]>();

                waveIn.DataAvailable += (sender, e) =>
                {
                    if (stopwatch.Elapsed.TotalSeconds >= durationSeconds)
                    {
                        waveIn.StopRecording();
                        return;
                    }

                    audioBuffer.AddRange(e.Buffer.Take(e.BytesRecorded));
                };

                waveIn.RecordingStopped += (sender, e) =>
                {
                    stopwatch.Stop();
                    var audioData = audioBuffer.ToArray();
                    recordingTask.SetResult(audioData);
                };

                Console.WriteLine("🔴 Nagrywanie... (naciśnij Ctrl+C aby przerwać)");
                waveIn.StartRecording();

                // Timeout po określonym czasie
                var timeoutTask = Task.Delay(TimeSpan.FromSeconds(durationSeconds + 1));
                var completedTask = await Task.WhenAny(recordingTask.Task, timeoutTask);

                if (completedTask == timeoutTask)
                {
                    waveIn.StopRecording();
                    await recordingTask.Task;
                }

                var result = await recordingTask.Task;
                Console.WriteLine($"✅ Nagrano {result.Length} bajtów audio ({stopwatch.Elapsed.TotalSeconds:F1}s)");
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Błąd podczas nagrywania: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Pobiera ścieżkę do modelu, pobierając go jeśli nie istnieje.
        /// </summary>
        private async Task<string> GetModelPathAsync(GgmlType ggmlType)
        {
            var modelName = $"ggml-{ggmlType.ToString().ToLower()}.bin";
            var modelPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".cache", "whisper", modelName);

            var modelDir = Path.GetDirectoryName(modelPath);
            if (!string.IsNullOrEmpty(modelDir) && !Directory.Exists(modelDir))
            {
                Directory.CreateDirectory(modelDir);
            }

            if (!File.Exists(modelPath))
            {
                Console.WriteLine($"📥 Pobieranie modelu {modelName}...");
                Console.WriteLine("💡 Pobieranie z HuggingFace (może to chwilę potrwać)...");
                
                try
                {
                    // Pobierz model bezpośrednio z HuggingFace
                    var modelUrl = GetModelUrl(ggmlType);
                    using var httpClient = new HttpClient();
                    httpClient.Timeout = TimeSpan.FromMinutes(10); // Długi timeout dla dużych modeli
                    
                    var response = await httpClient.GetAsync(modelUrl);
                    response.EnsureSuccessStatusCode();
                    
                    using var modelStream = await response.Content.ReadAsStreamAsync();
                    using var fileStream = File.Create(modelPath);
                    await modelStream.CopyToAsync(fileStream);
                    
                    Console.WriteLine($"✅ Model pobrany: {modelPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Błąd podczas pobierania modelu: {ex.Message}");
                    Console.WriteLine($"💡 Możesz pobrać model ręcznie z HuggingFace i umieścić go w: {modelPath}");
                    throw;
                }
            }

            return modelPath;
        }

        /// <summary>
        /// Konwertuje WhisperModelSize na GgmlType.
        /// </summary>
        private GgmlType GetGgmlType(WhisperModelSize modelSize)
        {
            return modelSize switch
            {
                WhisperModelSize.Tiny => GgmlType.Tiny,
                WhisperModelSize.Base => GgmlType.Base,
                WhisperModelSize.Small => GgmlType.Small,
                WhisperModelSize.Medium => GgmlType.Medium,
                _ => GgmlType.Medium
            };
        }

        /// <summary>
        /// Zwraca URL do modelu na HuggingFace.
        /// </summary>
        private string GetModelUrl(GgmlType ggmlType)
        {
            var modelName = ggmlType.ToString().ToLower();
            // Modele Whisper z repozytorium ggerganov/whisper.cpp na HuggingFace
            return $"https://huggingface.co/ggerganov/whisper.cpp/resolve/main/ggml-{modelName}.bin";
        }

        /// <summary>
        /// Zwraca informacje o dostępnych modelach.
        /// </summary>
        public static Dictionary<WhisperModelSize, (string Description, string Size)> GetAvailableModels()
        {
            return new Dictionary<WhisperModelSize, (string, string)>
            {
                { WhisperModelSize.Tiny, ("Najszybszy, najmniej dokładny", "~75 MB") },
                { WhisperModelSize.Base, ("Dobry balans szybkości i dokładności", "~142 MB") },
                { WhisperModelSize.Small, ("Lepsza dokładność, wolniejszy", "~466 MB") },
                { WhisperModelSize.Medium, ("Najlepsza dokładność, najwolniejszy", "~1.5 GB") }
            };
        }

        /// <summary>
        /// Zwalnia zasoby.
        /// </summary>
        public void Dispose()
        {
            _processor?.Dispose();
            _whisperFactory?.Dispose();
            _isInitialized = false;
        }
    }
}

