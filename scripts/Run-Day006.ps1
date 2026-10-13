$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Write-Error '.NET SDK 未安裝；請先安裝 .NET 8 SDK。'
    exit 1
}
Push-Location $root
try {
    dotnet test '.\CSharpDailyAlgorithms.sln' --filter 'FullyQualifiedName~Day006' --nologo
    exit $LASTEXITCODE
}
finally {
    Pop-Location
}
