// See https://aka.ms/new-console-template for more information

namespace RegistroEstudiantes
{
    // Definición de la clase Estudiante
    public class Estudiante
    {
        // Propiedades de la clase Estudiante
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } // Array para almacenar tres teléfonos

        // Constructor de la clase Estudiante
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            // Se asigna el array de teléfonos. Se asume que el array pasado siempre tendrá 3 elementos
            // o se manejará la validación en la lógica de negocio si el tamaño es variable.
            if (telefonos != null && telefonos.Length == 3)
            {
                // ¡Ojo! Aquí tienes un pequeño error de tipografía, debería ser 'Telefonos' no 'Teletonos'
                Telefonos = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    Telefonos[i] = telefonos[i];
                }
            }
            else
            {
                // Si no se proporcionan 3 teléfonos, se inicializa el array con valores predeterminados.
                // ¡Ojo! Aquí también, debería ser 'Telefonos' no 'Teletonos'
                Telefonos = new string[3] { "N/A", "N/A", "N/A" };
                Console.WriteLine("Advertencia: Se esperaban 3 números de teléfono. Inicializando con valores N/A.");
            }
        }

        // Método para mostrar los datos del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n--- Información del Estudiante ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  - Teléfono {i + 1}: {Telefonos[i]}");
            }
            Console.WriteLine("----------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // La línea corregida y colocada dentro de Main
            Console.WriteLine("Hello, World!"); // Ahora está bien cerrada y con ;

            Console.WriteLine("--- Sistema de Registro de Estudiantes ---");

            // Ejemplo de creación de un array de teléfonos
            string[] telefonosEstudiante1 = { "0987654321", "0912345678", "0998765432" };

            // Creación de una instancia de la clase Estudiante
            Estudiante estudiante1 = new Estudiante(
                id: 1,
                nombres: "Ana",
                apellidos: "García López",
                direccion: "Calle Principal 123, Ciudad",
                telefonos: telefonosEstudiante1
            );

            // Mostrar la información del estudiante
            estudiante1.MostrarInformacion();

            // Otro ejemplo con datos diferentes
            string[] telefonosEstudiante2 = { "0976543210", "0965432109", "N/A" }; // Un "N/A" como ejemplo
            Estudiante estudiante2 = new Estudiante(
                id: 2,
                nombres: "Juan",
                apellidos: "Pérez Rodríguez",
                direccion: "Avenida Siempre Viva 456, Pueblo",
                telefonos: telefonosEstudiante2
            );

            estudiante2.MostrarInformacion();

            // Ejemplo de cómo se manejaría si no se proporcionan 3 teléfonos (se usaría el valor por defecto "N/A")
            string[] telefonosEstudiante3 = { "0911223344", "0955667788" }; // Faltaría un teléfono
            Estudiante estudiante3 = new Estudiante(
                id: 3,
                nombres: "María",
                apellidos: "Fernández Solís",
                direccion: "Zona Central 789, Cantón",
                telefonos: telefonosEstudiante3
            );
            estudiante3.MostrarInformacion();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}