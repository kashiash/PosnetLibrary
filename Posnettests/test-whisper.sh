#!/bin/bash
cd "$(dirname "$0")"
echo "🔨 Kompilowanie..."
dotnet build -c Debug > /dev/null 2>&1
echo "✅ Gotowe!"
echo ""
echo "🎤 Uruchamianie testu Whisper..."
echo ""
dotnet exec bin/Debug/net9.0/PosnetTests.dll VoiceRecognition

