dotnet build -c Release
Set-Location bin\Release\net6.0\

Start-Process -FilePath “The Game Of Doom.exe”
Set-Location ..\..\..