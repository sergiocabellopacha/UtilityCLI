using System;

namespace UtilityCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bienvenido a UtilityCLI ===");
            Console.WriteLine();

            bool continuar = true;
            while (continuar)
            {
                MostrarMenuPrincipal();
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConversorUnidades.MostrarMenu();
                        break;
                    case "2":
                        GeneradorContraseñas.GenerarContraseña();
                        break;
                    case "3":
                        CalculadoraHashes.MostrarMenu();
                        break;
                    case "4":
                        ConversorTexto.MostrarMenu();
                        break;
                    case "5":
                        continuar = false;
                        Console.WriteLine("¡Gracias por usar UtilityCLI!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Conversor de unidades");
            Console.WriteLine("2. Generador de contraseñas aleatorias");
            Console.WriteLine("3. Calculadora de hashes");
            Console.WriteLine("4. Conversor de texto");
            Console.WriteLine("5. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");
        }
    }
}