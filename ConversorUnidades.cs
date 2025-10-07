using System;

namespace UtilityCLI
{
    public static class ConversorUnidades
    {
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== CONVERSOR DE UNIDADES ===");
            Console.WriteLine("1. Metros a Pies");
            Console.WriteLine("2. Pies a Metros");
            Console.WriteLine("3. Kilogramos a Libras");
            Console.WriteLine("4. Libras a Kilogramos");
            Console.WriteLine("5. Celsius a Fahrenheit");
            Console.WriteLine("6. Fahrenheit a Celsius");
            Console.WriteLine("7. Volver al menú principal");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConvertirMetrosAPies();
                    break;
                case "2":
                    ConvertirPiesAMetros();
                    break;
                case "3":
                    ConvertirKgALibras();
                    break;
                case "4":
                    ConvertirLibrasAKg();
                    break;
                case "5":
                    ConvertirCelsiusAFahrenheit();
                    break;
                case "6":
                    ConvertirFahrenheitACelsius();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private static void ConvertirMetrosAPies()
        {
            Console.Write("Ingrese la cantidad en metros: ");
            if (double.TryParse(Console.ReadLine(), out double metros))
            {
                double pies = metros * 3.28084;
                Console.WriteLine($"{metros} metros = {pies:F2} pies");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }
       

        private static void ConvertirPiesAMetros()
        {
            Console.Write("Ingrese la cantidad en pies: ");
            if (double.TryParse(Console.ReadLine(), out double pies))
            {
                double metros = pies / 3.28084;
                Console.WriteLine($"{pies} pies = {metros:F2} metros");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }

        private static void ConvertirKgALibras()
        {
            Console.Write("Ingrese la cantidad en kilogramos: ");
            if (double.TryParse(Console.ReadLine(), out double kg))
            {
                double libras = kg * 2.20462;
                Console.WriteLine($"{kg} kg = {libras:F2} libras");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }

        private static void ConvertirLibrasAKg()
        {
            Console.Write("Ingrese la cantidad en libras: ");
            if (double.TryParse(Console.ReadLine(), out double libras))
            {
                double kg = libras / 2.20462;
                Console.WriteLine($"{libras} libras = {kg:F2} kg");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }

        private static void ConvertirCelsiusAFahrenheit()
        {
            Console.Write("Ingrese la temperatura en Celsius: ");
            if (double.TryParse(Console.ReadLine(), out double celsius))
            {
                double fahrenheit = (celsius * 9/5) + 32;
                Console.WriteLine($"{celsius}°C = {fahrenheit:F2}°F");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }

        private static void ConvertirFahrenheitACelsius()
        {
            Console.Write("Ingrese la temperatura en Fahrenheit: ");
            if (double.TryParse(Console.ReadLine(), out double fahrenheit))
            {
                double celsius = (fahrenheit - 32) * 5/9;
                Console.WriteLine($"{fahrenheit}°F = {celsius:F2}°C");
            }
            else
            {
                Console.WriteLine("Valor no válido.");
            }
        }
    }
}