$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path -Parent $PSScriptRoot

if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Error '.NET SDK 尚未安裝；請先安裝 .NET 8 SDK 或更新版本。'
    exit 1
}

Push-Location $projectRoot
try {
    dotnet test '.\CSharpDailyAlgorithms.sln' --nologo
    exit $LASTEXITCODE
}
finally {
    Pop-Location
}
