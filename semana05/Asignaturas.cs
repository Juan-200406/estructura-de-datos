
public class Asignaturas
{
    public static void Main(string[] args)
    {
        // 1. Crear una lista para almacenar las asignaturas
        List<string> asignaturas = new List<string>();

        // 2. Añadir las asignaturas a la lista
        asignaturas.Add("Matemáticas");
        asignaturas.Add("Física");
        asignaturas.Add("Química");
        asignaturas.Add("Historia");
        asignaturas.Add("Lengua");

        // 3. Mostrar las asignaturas por pantalla
        Console.WriteLine("Asignaturas del curso:");
        Console.WriteLine("---------------------");

        // Iterar sobre la lista y mostrar cada asignatura
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine(asignatura);
        }

        // Mantener la consola abierta hasta que se presione una tecla
        Console.WriteLine("\nPresiona cualquier tecla para salir.");
        Console.ReadKey();
    }
}
