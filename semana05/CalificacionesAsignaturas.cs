//ejercicio03
public class CalificacionesAsignaturas
{
    public static void Main(string[] args)
    {
        // 1. Almacenar las asignaturas en una lista
        List<string> asignaturas = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        // 2. Crear un diccionario para almacenar las notas de cada asignatura
        // Usamos un diccionario para asociar cada asignatura con su nota.
        Dictionary<string, double> notas = new Dictionary<string, double>();

        // 3. Preguntar al usuario la nota de cada asignatura
        foreach (string asignatura in asignaturas)
        {
            double nota;
            // Bucle para asegurar que el usuario introduce un número válido
            while (true)
            {
                Console.Write($"¿Qué nota has sacado en {asignatura}?: ");
                string input = Console.ReadLine();

                // Intentar convertir la entrada del usuario a un número (double)
                if (double.TryParse(input, out nota))
                {
                    // Verificar que la nota esté en un rango razonable (por ejemplo, de 0 a 10)
                    if (nota >= 0 && nota <= 10)
                    {
                        notas.Add(asignatura, nota); // Añadir la asignatura y su nota al diccionario
                        break; // Salir del bucle si la entrada es válida
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduce una nota entre 0 y 10.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número para la nota.");
                }
            }
        }

        // 4. Mostrar las asignaturas y sus notas por pantalla
        Console.WriteLine("\n--- Resumen de tus calificaciones ---");
        foreach (KeyValuePair<string, double> entry in notas)
        {
            // entry.Key es la asignatura y entry.Value es la nota
            Console.WriteLine($"En {entry.Key} has sacado {entry.Value}");
        }
    }
}
/