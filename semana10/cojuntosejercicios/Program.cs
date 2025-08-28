public class CampanaVacunacion
{
    public static void Main(string[] args)
    {
        // 1. Generar datos ficticios
        Console.WriteLine("Generando datos ficticios...");
        var ciudadanosTotales = GenerarCiudadanos(500, 1);
        var vacunadosPfizer = GenerarCiudadanos(75, 1);
        var vacunadosAstraZeneca = GenerarCiudadanos(75, 76);

        // Simular que algunos ciudadanos han recibido ambas dosis
        var ciudadanosConDosDosis = new HashSet<string>();
        var random = new Random();
        for (int i = 0; i < 50; i++) // 50 ciudadanos con ambas dosis
        {
            var ciudadano = vacunadosPfizer.ElementAt(random.Next(vacunadosPfizer.Count));
            if (vacunadosAstraZeneca.Add(ciudadano))
            {
                ciudadanosConDosDosis.Add(ciudadano);
            }
        }
        
        Console.WriteLine("\nDatos generados:");
        Console.WriteLine($"- Total de ciudadanos: {ciudadanosTotales.Count}");
        Console.WriteLine($"- Vacunados con Pfizer: {vacunadosPfizer.Count}");
        Console.WriteLine($"- Vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}");
        
        Console.WriteLine("\nRealizando operaciones de teoría de conjuntos...");

        // 2. Aplicar operaciones de teoría de conjuntos para obtener los listados
        
        // a) Ciudadanos que no se han vacunado
        var ciudadanosVacunados = new HashSet<string>(vacunadosPfizer);
        ciudadanosVacunados.UnionWith(vacunadosAstraZeneca);
        var ciudadanosNoVacunados = new HashSet<string>(ciudadanosTotales);
        ciudadanosNoVacunados.ExceptWith(ciudadanosVacunados);
        
        // b) Ciudadanos que han recibido ambas dosis
        var ambasDosis = new HashSet<string>(vacunadosPfizer);
        ambasDosis.IntersectWith(vacunadosAstraZeneca);
        
        // c) Ciudadanos que solo han recibido la vacuna de Pfizer
        var soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(ambasDosis);

        // d) Ciudadanos que solo han recibido la vacuna de AstraZeneca
        var soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(ambasDosis);

        // 3. Mostrar resultados
        Console.WriteLine("\n--- Reporte de Vacunación ---");

     
        
        Console.WriteLine("\n--- Fin del Reporte ---");
    }

    // Método para generar un conjunto de ciudadanos ficticios
    public static HashSet<string> GenerarCiudadanos(int cantidad, int inicioId)
    {
        var ciudadanos = new HashSet<string>();
        for (int i = 0; i < cantidad; i++)
        {
            ciudadanos.Add($"Ciudadano {inicioId + i}");
        }
        return ciudadanos;
    }

    // Método para mostrar los ciudadanos en un conjunto
    public static void MostrarLista(HashSet<string> lista)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine("  - Ninguno.");
        }
        foreach (var ciudadano in lista) // Mostrar solo los primeros 10 para brevedad
        {
            Console.WriteLine(ciudadano);
        }
    }
}
 