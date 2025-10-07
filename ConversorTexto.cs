using System;
using System.Linq;
using System.Text;

namespace UtilityCLI
{
    public static class ConversorTexto
    {
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== CONVERSOR DE TEXTO ===");
            Console.WriteLine("1. Convertir a MAYÚSCULAS");
            Console.WriteLine("2. Convertir a minúsculas");
            Console.WriteLine("3. Convertir a Formato Título");
            Console.WriteLine("4. Invertir texto");
            Console.WriteLine("5. Contar caracteres y palabras");
            Console.WriteLine("6. Eliminar espacios");
            Console.WriteLine("7. Reemplazar texto");
            Console.WriteLine("8. Volver al menú principal");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            if (opcion == "8") return;

            Console.Write("Ingrese el texto: ");
            string? texto = Console.ReadLine();

            if (string.IsNullOrEmpty(texto))
            {
                Console.WriteLine("Texto no válido.");
                return;
            }

            string resultado = opcion switch
            {
                "1" => ConvertirAMayusculas(texto),
                "2" => ConvertirAMinusculas(texto),
                "3" => ConvertirAFormatoTitulo(texto),
                "4" => InvertirTexto(texto),
                "5" => ContarCaracteresYPalabras(texto),
                "6" => EliminarEspacios(texto),
                "7" => ReemplazarTexto(texto),
                _ => "Opción no válida."
            };

            Console.WriteLine($"\nTexto original: {texto}");
            Console.WriteLine($"Resultado: {resultado}");
        }

        private static string ConvertirAMayusculas(string texto)
        {
            return texto.ToUpper();
        }

        private static string ConvertirAMinusculas(string texto)
        {
            return texto.ToLower();
        }

        private static string ConvertirAFormatoTitulo(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            StringBuilder resultado = new StringBuilder();
            bool siguienteEsMayuscula = true;

            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    if (siguienteEsMayuscula)
                    {
                        resultado.Append(char.ToUpper(c));
                        siguienteEsMayuscula = false;
                    }
                    else
                    {
                        resultado.Append(char.ToLower(c));
                    }
                }
                else
                {
                    resultado.Append(c);
                    if (char.IsWhiteSpace(c))
                        siguienteEsMayuscula = true;
                }
            }

            return resultado.ToString();
        }

        private static string InvertirTexto(string texto)
        {
            char[] array = texto.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private static string ContarCaracteresYPalabras(string texto)
        {
            int caracteres = texto.Length;
            int caracteressinEspacios = texto.Count(c => !char.IsWhiteSpace(c));
            int palabras = texto.Split(new char[] { ' ', '\t', '\n', '\r' }, 
                                     StringSplitOptions.RemoveEmptyEntries).Length;
            int lineas = texto.Split('\n').Length;

            return $@"
Estadísticas del texto:
- Caracteres (total): {caracteres}
- Caracteres (sin espacios): {caracteressinEspacios}
- Palabras: {palabras}
- Líneas: {lineas}";
        }

        private static string EliminarEspacios(string texto)
        {
            Console.WriteLine("\n1. Eliminar espacios al inicio y final");
            Console.WriteLine("2. Eliminar todos los espacios");
            Console.WriteLine("3. Eliminar espacios dobles");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            return opcion switch
            {
                "1" => texto.Trim(),
                "2" => texto.Replace(" ", "").Replace("\t", ""),
                "3" => System.Text.RegularExpressions.Regex.Replace(texto, @"\s+", " "),
                _ => "Opción no válida."
            };
        }

        private static string ReemplazarTexto(string texto)
        {
            Console.Write("Ingrese el texto a buscar: ");
            string? buscar = Console.ReadLine();

            Console.Write("Ingrese el texto de reemplazo: ");
            string? reemplazar = Console.ReadLine();

            if (string.IsNullOrEmpty(buscar))
            {
                return "Texto de búsqueda no válido.";
            }

            if (reemplazar == null)
                reemplazar = "";

            int ocurrencias = (texto.Length - texto.Replace(buscar, "").Length) / buscar.Length;
            string resultado = texto.Replace(buscar, reemplazar);

            return $"{resultado}\n\n(Se realizaron {ocurrencias} reemplazos)";
        }
    }
}