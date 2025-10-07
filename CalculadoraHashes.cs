using System;
using System.Security.Cryptography;
using System.Text;

namespace UtilityCLI
{
    // Renombrada: CalculadoraHashes -> CalculadoraDeHashes
    public static class CalculadoraDeHashes
    {
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== CALCULADORA DE HASHES ===");
            Console.WriteLine("1. MD5");
            Console.WriteLine("2. SHA1");
            Console.WriteLine("3. SHA256");
            Console.WriteLine("4. SHA512");
            Console.WriteLine("5. Volver al menú principal");
            Console.WriteLine();
            Console.Write("Seleccione el tipo de hash: ");

            string? opcion = Console.ReadLine();

            if (opcion == "5") return;

            Console.Write("Ingrese el texto para calcular el hash: ");
            string? texto = Console.ReadLine();

            if (string.IsNullOrEmpty(texto))
            {
                Console.WriteLine("Texto no válido.");
                return;
            }

            string resultado = opcion switch
            {
                "1" => CalcularMD5(texto),
                "2" => CalcularSHA1(texto),
                "3" => CalcularSHA256(texto),
                "4" => CalcularSHA512(texto),
                _ => "Opción no válida."
            };

            Console.WriteLine($"\nTexto original: {texto}");
            Console.WriteLine($"Hash {GetHashName(opcion ?? "")}: {resultado}");
        }

        private static string CalcularMD5(string input)
        {
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return ConvertirAHexadecimal(hashBytes);
        }

        private static string CalcularSHA1(string input)
        {
            using SHA1 sha1 = SHA1.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha1.ComputeHash(inputBytes);
            return ConvertirAHexadecimal(hashBytes);
        }

        private static string CalcularSHA256(string input)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return ConvertirAHexadecimal(hashBytes);
        }

        private static string CalcularSHA512(string input)
        {
            using SHA512 sha512 = SHA512.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha512.ComputeHash(inputBytes);
            return ConvertirAHexadecimal(hashBytes);
        }

        private static string ConvertirAHexadecimal(byte[] bytes)
        {
            StringBuilder resultado = new StringBuilder();
            foreach (byte b in bytes)
            {
                resultado.Append(b.ToString("x2"));
            }
            return resultado.ToString();
        }

        private static string GetHashName(string opcion)
        {
            return opcion switch
            {
                "1" => "MD5",
                "2" => "SHA1",
                "3" => "SHA256",
                "4" => "SHA512",
                _ => "Desconocido"
            };
        }
    }


    // Wrapper para mantener compatibilidad con referencias existentes.
    [Obsolete("Use CalculadoraDeHashes en su lugar.")]
    public static class CalculadoraHashes
    {
        public static void MostrarMenu()
        {
            CalculadoraDeHashes.MostrarMenu();
        }
    }
}