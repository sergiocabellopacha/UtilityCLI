---
post_title: "UtilityCLI - Herramientas de consola"
author1: "Sergio Cabello Pacha"
post_slug: "utilitycli"
microsoft_alias: "sergiocabellopacha"
featured_image: "/assets/utilitycli-featured.png"
categories:
	- "Utilities"
	- "CLI"
	- "Dotnet"
tags:
	- "cli"
	- "dotnet"
	- "csharp"
	- "utilities"
	- "password"
	- "hash"
ai_note: "Sí - contenido generado/organizado con asistencia de IA bajo petición del autor"
summary: "UtilityCLI es una pequeña colección de utilidades de consola (.NET 8) que incluye conversores de unidades y texto, un generador de contraseñas y una calculadora de hashes. Diseñado para uso local desde la línea de comandos."
post_date: 2025-10-07
---

## Descripción

UtilityCLI es una aplicación de consola construida con .NET 8 que agrupa varias herramientas útiles para tareas rápidas desde la terminal. Está pensada como una utilidad personal y didáctica para trabajar con conversiones de unidades y texto, generación de contraseñas seguras y cálculo de hashes.

## Funcionalidades principales

- Conversor de unidades (`ConversorUnidades`): metros ↔ pies, kilogramos ↔ libras, Celsius ↔ Fahrenheit.
- Generador de contraseñas (`GeneradorContraseñas`): genera contraseñas aleatorias con opciones para incluir mayúsculas, minúsculas, números y caracteres especiales; permite elegir longitud y evalúa la fortaleza.
- Calculadora de hashes (`CalculadoraHashes` / `CalculadoraDeHashes`): calcula MD5, SHA1, SHA256 y SHA512 de un texto dado.
- Conversor de texto (`ConversorTexto`): mayúsculas/minúsculas, formato título, invertir texto, contar caracteres/palabras/líneas, eliminar espacios y reemplazar texto.
- Programa principal (`Program.cs`): menú interactivo que permite seleccionar cualquiera de las utilidades anteriores.

## Estructura del proyecto

- `Program.cs` - Punto de entrada y menú principal.
- `ConversorUnidades.cs` - Menú y métodos para conversiones numéricas.
- `GeneradorContraseñas.cs` - Generador y evaluación de contraseñas.
- `CalculadoraHashes.cs` - Cálculo de hashes (MD5, SHA1, SHA256, SHA512). Incluye una clase con el nombre antiguo `CalculadoraHashes` que delega a `CalculadoraDeHashes` para compatibilidad.
- `ConversorTexto.cs` - Operaciones y utilidades sobre cadenas de texto.

## Cómo compilar y ejecutar

Requisitos: .NET 8 SDK instalado.

Desde PowerShell, en la carpeta raíz del proyecto (`UtilityCLI`):

```powershell
dotnet build -c Release
dotnet run --project . -c Release
```

O para ejecución rápida en modo depuración:

```powershell
dotnet run
```

El programa abrirá un menú interactivo. Seleccione la opción deseada y siga las instrucciones en pantalla.

## Ejemplos de uso

- Conversor de Unidades: seleccione "1" en el menú principal, luego "1" para metros → pies. Ingrese `2` y verá una salida similar a:

	2 metros = 6.56 pies

- Generador de Contraseñas: seleccione "2" en el menú principal. Ingrese longitud `12`, responda `s` o `n` para incluir mayúsculas, minúsculas, números y símbolos. Obtendrá la contraseña generada y una etiqueta de fortaleza.

- Calculadora de Hashes: seleccione "3" y el tipo (por ejemplo, `3` para SHA256). Ingrese `hola` y obtendrá el hash SHA256 en hexadecimal.

- Conversor de Texto: seleccione "4" y luego por ejemplo `1` para convertir a MAYÚSCULAS.

## Consideraciones técnicas y notas

- Las entradas numéricas usan la cultura del sistema para analizar separadores decimales (`,` o `.` según configuración).
- El generador de contraseñas utiliza `System.Random`. Para requisitos criptográficos más fuertes se recomienda usar `RNGCryptoServiceProvider` o `RandomNumberGenerator`.
- La clase `CalculadoraHashes` está marcada como obsoleta y delega a `CalculadoraDeHashes`.

## Buenas prácticas y mejoras sugeridas

- Reemplazar `Random` por `System.Security.Cryptography.RandomNumberGenerator` para generación de contraseñas más segura.
- Añadir opciones de línea de comando (por ejemplo con `System.CommandLine` o `McMaster.Extensions.CommandLineUtils`) para usar las utilidades sin entrar en el menú interactivo.
- Añadir pruebas unitarias para las funciones de conversión, hashing y generación de contraseñas.

## Licencia y contribuciones

Este repositorio es personal. Si desea contribuir, abra un issue o un pull request con cambios propuestos.

## Notas sobre categorías

El archivo `categories.txt` mencionado en las reglas de documentación no se encontró en el repositorio. He usado las categorías `Utilities`, `CLI` y `Dotnet` asumiendo que encajan con la naturaleza del proyecto; si su proceso de validación requiere categorías específicas, por favor indique el contenido esperado de `/categories.txt` y ajustaré el front matter en consecuencia.

---
Archivo generado/actualizado: `README.md` — incluye front matter requerido por las reglas internas del repositorio.
