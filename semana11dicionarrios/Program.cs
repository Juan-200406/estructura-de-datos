using System;
using System.Collections.Generic;

class Traductor
{
    // El diccionario principal para almacenar las traducciones
    private Dictionary<string, string> diccionarioInglesEspanol;

    public Traductor()
    {
        // Inicializamos el diccionario con las palabras base
        diccionarioInglesEspanol = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"Time", "Tiempo"},
            {"Person", "Persona"},
            {"Year", "Año"},
            {"Way", "Camino / Forma"},
            {"Day", "Día"},
            {"día", "day"},
            { "Thing", "Cosa"},
            {"Man", "Hombre"},
            {"World", "Mundo"},
            {"Life", "Vida"},
            {"Hand", "Mano"},
            {"Part", "Parte"},
            {"Child", "Niño/a"},
            {"ojo", "eye"},
            {"Este", "This"},
            { "Woman", "Mujer"},
            {"Place", "Lugar"},
            {"Work", "Trabajo"},
            {"Week", "Semana"},
            {"Case", "Caso"},
            {"Point", "Punto / Tema"},
            {"Government", "Gobierno"},
            {"Company", "Empresa / Compañía"}
        };
    }

    public void Iniciar()
    {
        bool continuar = true;
        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    TraducirFrase();
                    break;
                case "2":
                    AgregarPalabra();
                    break;
                case "0":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa. ¡Hasta la próxima!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
            Console.WriteLine();
        }
    }

    private void MostrarMenu()
    {
        Console.WriteLine("==================== MENÚ ====================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.Write("\nSeleccione una opción: ");
    }

    private void TraducirFrase()
    {
        Console.Write("Ingrese la frase a traducir: ");
        string fraseOriginal = Console.ReadLine();
        string[] palabras = fraseOriginal.Split(' ');
        List<string> palabrasTraducidas = new List<string>();

        foreach (var palabra in palabras)
        {
            string palabraNormalizada = NormalizarPalabra(palabra);
            
            if (diccionarioInglesEspanol.ContainsKey(palabraNormalizada))
            {
                string palabraTraducida = diccionarioInglesEspanol[palabraNormalizada];
                palabrasTraducidas.Add(palabraTraducida);
            }
            else
            {
                palabrasTraducidas.Add(palabra);
            }
        }
        
        string fraseTraducida = string.Join(" ", palabrasTraducidas);
        Console.WriteLine($"\nTraducción: {fraseTraducida}");
    }

    private void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en español: ");
        string ingles = Console.ReadLine();
        Console.Write("Ingrese la traducción al ingles: ");
        string espanol = Console.ReadLine();

        string inglesNormalizado = NormalizarPalabra(ingles);

        if (!diccionarioInglesEspanol.ContainsKey(inglesNormalizado))
        {
            diccionarioInglesEspanol.Add(inglesNormalizado, espanol);
            Console.WriteLine($"\n'{ingles}' ha sido agregada al diccionario con la traducción '{espanol}'.");
        }
        else
        {
            Console.WriteLine($"\nLa palabra '{ingles}' ya existe en el diccionario. No se ha agregado.");
        }
    }

    // Método para normalizar la palabra (quitar signos de puntuación)
    private string NormalizarPalabra(string palabra)
    {
        return palabra.TrimEnd('.', ',', '!', '?').Trim();
    }

    public static void Main(string[] args)
    {
        Traductor miTraductor = new Traductor();
        miTraductor.Iniciar();
    }
}


/*
Este día es hermoso, depende mucho del ojo que lo vea.
*/