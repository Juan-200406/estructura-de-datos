using System;
using System.Collections.Generic;
using System.Linq;

// La clase Program contiene la lógica principal de la aplicación
public class Program
{
    // Una lista de strings para almacenar los títulos de las revistas.
    private static List<string> catalogoRevistas = new List<string>();


    // El método principal Main, punto de entrada de la aplicación
    public static void Main(string[] args)
    {
        // 1. Inicializar el catálogo con al menos 10 títulos
        InicializarCatalogo();

        // 2. Mostrar el menú interactivo para el usuario
        MenuPrincipal();
    }

    /// <summary>
    /// Inicializa el catálogo de revistas con datos de ejemplo.
    /// </summary>
    private static void InicializarCatalogo()
    {
        // Agregamos al menos 10 títulos de revistas.
        catalogoRevistas.Add("National Geographic");
        catalogoRevistas.Add("Time");
        catalogoRevistas.Add("The Economist");
        catalogoRevistas.Add("Scientific American");
        catalogoRevistas.Add("Vogue");
        catalogoRevistas.Add("Forbes");
        catalogoRevistas.Add("PC Magazine");
        catalogoRevistas.Add("Wired");
        catalogoRevistas.Add("Newsweek");
        catalogoRevistas.Add("Bloomberg Businessweek");
    }

    /// <summary>
    /// Muestra el menú principal y gestiona las interacciones del usuario.
    /// </summary>
    private static void MenuPrincipal()
    {
        string opcion;
        do
        {
            // Limpiar la consola para una mejor experiencia de usuario.
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║      Catálogo de Revistas - Menú      ║");
            Console.WriteLine("╠═══════════════════════════════════════╣");
            Console.WriteLine("║ 1. Buscar una revista                 ║");
            Console.WriteLine("║ 2. Salir                              ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            Console.WriteLine("📚 Revistas disponibles:");
            Console.WriteLine("📚 Nation");
            Console.Write("\nSeleccione una opción: ");

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Opción para buscar una revista.
                    BuscarRevista();
                    break;
                case "2":
                    // Opción para salir del programa.
                    Console.WriteLine("\n¡Gracias por usar la aplicación!");
                    break;
                default:
                    // Manejar opciones no válidas.
                    Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                    break;
            }

            // Pausar para que el usuario pueda ver el resultado antes de que el menú se limpie.
            if (opcion != "2")
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != "2");
    }

    /// <summary>
    /// Solicita un título al usuario y realiza la búsqueda.
    /// </summary>
    private static void BuscarRevista()
    {
        Console.Write("\nIngrese el título de la revista a buscar: ");
        string tituloBuscado = Console.ReadLine();

        // Se llama al método de búsqueda iterativa.
        bool encontrado = BusquedaIterativa(tituloBuscado);

        // Se muestra el resultado de la búsqueda.
        if (encontrado)
        {
            Console.WriteLine("\n🎉 ¡Encontrado! 🎉");
        }
        else
        {
            Console.WriteLine("\n❌ ¡No encontrado! ❌");
        }
    }

    /// <summary>
    /// Realiza una búsqueda iterativa de un título en el catálogo.
    /// </summary>
    /// <param name="titulo">El título a buscar.</param>
    /// <returns>True si el título se encuentra, False en caso contrario.</returns>
    private static bool BusquedaIterativa(string titulo)
    {
        // Convertimos el título a buscar a minúsculas para una búsqueda sin distinción de mayúsculas/minúsculas.
        string tituloNormalizado = titulo.ToLower();

        // Iteramos sobre cada elemento de la lista.
        foreach (var revista in catalogoRevistas)
        {
            
            // Comparamos el título de la revista (normalizado) con el título buscado.
            if (revista.ToLower() == tituloNormalizado)
            {
                // Si encontramos una coincidencia, retornamos true inmediatamente.
                return true;
            }
        }

        // Si el bucle termina sin encontrar el título, retornamos false.
        return false;
    }
}
