```markdown
# serialCodigo

Proyecto C# (Console App) que lee datos de un Arduino por puerto serie. Incluye handshake para Arduino Uno.

Estructura propuesta:
- Program.cs
- serialCodigo.csproj
- .github/workflows/windows-build.yml
- arduino/ArduinoLectura_Handshake.ino
- .gitignore
- README.md

Cómo probar localmente
1. Conecta tu Arduino Uno y sube el sketch `arduino/ArduinoLectura_Handshake.ino` desde Arduino IDE.
2. En tu PC, abre el proyecto en Visual Studio o usa la CLI `dotnet`.
3. Para ejecutar con dotnet run:
   dotnet run -- COM3 9600
   (reemplaza COM3 por el puerto correcto).

Publicar EXE localmente (single file, self-contained, win-x64)
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

GitHub Actions
El workflow compila y publica el EXE automáticamente para Windows y sube los artefactos (desde la rama main o al ejecutar manualmente el workflow).
```
