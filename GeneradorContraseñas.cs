using System;
using System.Text;

namespace UtilityCLI
{
    public static class GeneradorContraseñas
    {
        private const string CaracteresMinusculas = "abcdefghijklmnopqrstuvwxyz";
        private const string CaracteresMayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string CaracteresNumeros = "0123456789";
        private const string CaracteresEspeciales = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        public static void GenerarContraseña()
        {
            Console.Clear();
            Console.WriteLine("=== GENERADOR DE CONTRASEÑAS ===");
            
            // Obtener longitud
            Console.Write("Ingrese la longitud de la contraseña (8-128): ");
            if (!int.TryParse(Console.ReadLine(), out int longitud) || longitud < 8 || longitud > 128)
            {
                Console.WriteLine("Longitud no válida. Debe ser entre 8 y 128 caracteres.");
                return;
            }

            // Opciones de caracteres
            Console.WriteLine("\nSeleccione los tipos de caracteres a incluir:");
            Console.Write("¿Incluir minúsculas? (s/n): ");
            bool incluirMinusculas = Console.ReadLine()?.ToLower() == "s";

            Console.Write("¿Incluir mayúsculas? (s/n): ");
            bool incluirMayusculas = Console.ReadLine()?.ToLower() == "s";

            Console.Write("¿Incluir números? (s/n): ");
            bool incluirNumeros = Console.ReadLine()?.ToLower() == "s";

            Console.Write("¿Incluir caracteres especiales? (s/n): ");
            bool incluirEspeciales = Console.ReadLine()?.ToLower() == "s";

            if (!incluirMinusculas && !incluirMayusculas && !incluirNumeros && !incluirEspeciales)
            {
                Console.WriteLine("Debe seleccionar al menos un tipo de carácter.");
                return;
            }

            // Generar contraseña
            string contraseña = Generar(longitud, incluirMinusculas, incluirMayusculas, incluirNumeros, incluirEspeciales);
            
            Console.WriteLine($"\nContraseña generada: {contraseña}");
            
            // Evaluar fortaleza
            string fortaleza = EvaluarFortaleza(contraseña);
            Console.WriteLine($"Fortaleza de la contraseña: {fortaleza}");
        }

        private static string Generar(int longitud, bool minusculas, bool mayusculas, bool numeros, bool especiales)
        {
            StringBuilder caracteresDisponibles = new StringBuilder();
            StringBuilder contraseña = new StringBuilder();
            Random random = new Random();

            // Construir conjunto de caracteres disponibles
            if (minusculas) caracteresDisponibles.Append(CaracteresMinusculas);
            if (mayusculas) caracteresDisponibles.Append(CaracteresMayusculas);
            if (numeros) caracteresDisponibles.Append(CaracteresNumeros);
            if (especiales) caracteresDisponibles.Append(CaracteresEspeciales);

            string todosLosCaracteres = caracteresDisponibles.ToString();

            // Asegurar que al menos un carácter de cada tipo seleccionado esté presente
            if (minusculas && contraseña.Length < longitud)
                contraseña.Append(CaracteresMinusculas[random.Next(CaracteresMinusculas.Length)]);
            if (mayusculas && contraseña.Length < longitud)
                contraseña.Append(CaracteresMayusculas[random.Next(CaracteresMayusculas.Length)]);
            if (numeros && contraseña.Length < longitud)
                contraseña.Append(CaracteresNumeros[random.Next(CaracteresNumeros.Length)]);
            if (especiales && contraseña.Length < longitud)
                contraseña.Append(CaracteresEspeciales[random.Next(CaracteresEspeciales.Length)]);

            // Completar el resto de la contraseña
            while (contraseña.Length < longitud)
            {
                contraseña.Append(todosLosCaracteres[random.Next(todosLosCaracteres.Length)]);
            }

            // Mezclar los caracteres
            return MezclarString(contraseña.ToString());
        }

        private static string MezclarString(string input)
        {
            char[] array = input.ToCharArray();
            Random random = new Random();
            
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
            
            return new string(array);
        }

        private static string EvaluarFortaleza(string contraseña)
        {
            int puntuacion = 0;

            if (contraseña.Length >= 8) puntuacion++;
            if (contraseña.Length >= 12) puntuacion++;
            if (contraseña.Any(c => char.IsLower(c))) puntuacion++;
            if (contraseña.Any(c => char.IsUpper(c))) puntuacion++;
            if (contraseña.Any(c => char.IsDigit(c))) puntuacion++;
            if (contraseña.Any(c => CaracteresEspeciales.Contains(c))) puntuacion++;

            return puntuacion switch
            {
                <= 2 => "Débil",
                <= 4 => "Media",
                <= 5 => "Fuerte",
                _ => "Muy Fuerte"
            };
        }
    }
}