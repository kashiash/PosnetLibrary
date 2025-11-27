# Skrypt do formatowania dokumentacji Posnet - wersja 2
$ErrorActionPreference = "Stop"
$inputFile = "DOCS\pot-i-dev-37-5978-specyfikacja-protokolu-posnet-online-mr2021-2 (1).md"
$outputFile = "POSNET_PROTOKOL_FORMATOWANY.md"

Write-Host "Czytanie pliku źródłowego..."
$content = [System.IO.File]::ReadAllText((Resolve-Path $inputFile).Path, [System.Text.Encoding]::UTF8)

Write-Host "Przetwarzanie zawartości..."

# Usuń powtarzające się nagłówki stron
$content = $content -replace '(?m)^DKO 2\.11\.2023 oznaczenie dokumentu: POT-I-DEV-37 wersja: 5978\s*$', ''
$content = $content -replace '(?m)^\d+/\d+\s*$', ''

# Usuń nadmiarowe puste linie
$content = $content -replace '(?m)\r?\n{3,}', "`r`n`r`n"

# Zbierz wszystkie nagłówki sekcji do spisu treści
$tocEntries = @()
$lines = $content -split "`r?`n"
$formattedLines = @()
$inCodeBlock = $false
$codeBlockType = ""
$prevLineWasExample = $false
$sectionCounter = 0

for ($i = 0; $i -lt $lines.Length; $i++) {
    $line = $lines[$i]
    $trimmedLine = $line.Trim()
    
    # Formatuj nagłówki sekcji z poleceniami [command] Description
    if ($trimmedLine -match '^\[([^\]]+)\]\s+(.+)$') {
        if ($inCodeBlock) {
            $formattedLines += '```'
            $inCodeBlock = $false
        }
        $command = $matches[1]
        $description = $matches[2]
        $anchor = ($command + "-" + $description) -replace '[^\w\s-]', '' -replace '\s+', '-' -replace '-+', '-' -replace '^-|-$', '' -replace '^', '#'
        $anchor = $anchor.ToLower()
        $formattedLines += "## [$command] $description {#$anchor}"
        $tocEntries += @{
            Command = $command
            Description = $description
            Anchor = $anchor
        }
        $prevLineWasExample = $false
        continue
    }
    
    # Sprawdź czy linia zawiera przykład polecenia [STX]...[ETX]
    if ($trimmedLine -match '^\[STX\].*\[ETX\]') {
        if (-not $inCodeBlock) {
            $formattedLines += '```plaintext'
            $inCodeBlock = $true
            $codeBlockType = "plaintext"
        }
        $formattedLines += $line
        $prevLineWasExample = $true
        continue
    }
    
    # Sprawdź czy linia zawiera kod C
    if ($trimmedLine -match '^(unsigned char|const char|printf|for\s*\(|}\s*;|0x[0-9a-fA-F]+)') {
        if (-not $inCodeBlock) {
            $formattedLines += '```c'
            $inCodeBlock = $true
            $codeBlockType = "c"
        }
        $formattedLines += $line
        continue
    }
    
    # Sprawdź czy linia zawiera "Przykład:" lub "Przykład odpowiedzi:"
    if ($trimmedLine -match '^Przyk.*:') {
        if ($inCodeBlock) {
            $formattedLines += '```'
            $inCodeBlock = $false
        }
        $formattedLines += $line
        $prevLineWasExample = $true
        continue
    }
    
    # Sprawdź czy linia zawiera "Wydruk:"
    if ($trimmedLine -match '^Wydruk:') {
        if ($inCodeBlock) {
            $formattedLines += '```'
            $inCodeBlock = $false
        }
        $formattedLines += $line
        continue
    }
    
    # Sprawdź czy linia zawiera "Uwagi:" lub zaczyna się od cyfry z kropką
    if ($trimmedLine -match '^Uwagi:' -or $trimmedLine -match '^\d+\.\s+') {
        if ($inCodeBlock -and $prevLineWasExample) {
            $formattedLines += '```'
            $inCodeBlock = $false
        }
        $formattedLines += $line
        $prevLineWasExample = $false
        continue
    }
    
    # Sprawdź czy linia jest pusta i poprzednia była kodem
    if ($trimmedLine -eq '' -and $inCodeBlock) {
        # Sprawdź czy następna linia też nie jest kodem
        if ($i + 1 -lt $lines.Length) {
            $nextLine = $lines[$i + 1].Trim()
            if ($nextLine -notmatch '^\[STX\]|^(unsigned char|const char|printf|for\s*\()') {
                $formattedLines += '```'
                $inCodeBlock = $false
            }
        }
        $formattedLines += $line
        $prevLineWasExample = $false
        continue
    }
    
    # Zwykła linia
    $formattedLines += $line
    $prevLineWasExample = $false
}

# Zamknij ostatni blok kodu jeśli jest otwarty
if ($inCodeBlock) {
    $formattedLines += '```'
}

$content = $formattedLines -join "`r`n"

# Usuń podwójne bloki kodu
$content = $content -replace '```\s*```', '```'

# Generuj spis treści
$toc = "# Spis treści`r`n`r`n"
foreach ($entry in $tocEntries) {
    $anchor = $entry.Anchor
    $command = $entry.Command
    $description = $entry.Description
    $toc += "- [$command] $description`r`n"
}

# Dodaj nagłówek dokumentu
$header = @"
# Specyfikacja Protokołu POSNET

**Oznaczenie dokumentu:** POT-I-DEV-37  
**Wersja:** 5978  
**Data:** 2.11.2023

## Obsługiwane urządzenia

- POSNET THERMAL XL2 ONLINE 2.01
- POSNET THERMAL XL2 ONLINE S 2.01
- POSNET THERMAL HD ONLINE 2.01
- POSNET TEMO ONLINE 2.01
- POSNET TRIO ONLINE 2.01
- POSNET POSPAY ONLINE 2.01
- POSNET THERMAL HX 1.01
- POSNET THERMAL HX S 1.01
- POSNET VERO 2.01
- POSNET EVO 1.01
- FAWAG BOX 1.01

---

"@

$content = $header + "`r`n" + $toc + "`r`n---`r`n`r`n" + $content

Write-Host "Zapisywanie sformatowanego pliku..."
[System.IO.File]::WriteAllText((Resolve-Path .).Path + "\" + $outputFile, $content, [System.Text.Encoding]::UTF8)

Write-Host "Gotowe! Sformatowany plik zapisany jako: $outputFile"
$fileInfo = Get-Item $outputFile
Write-Host "Rozmiar: $($fileInfo.Length) bajtów"
Write-Host "Liczba sekcji w spisie treści: $($tocEntries.Count)"

