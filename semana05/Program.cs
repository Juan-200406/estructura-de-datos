// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic; // Necesario para usar List<T>

public class ProgramaAsignaturas
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
//ejerciccio2

public class cursos
{
    public static void Main(string[] args)
    {

        List<string> cursos = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        foreach (string cursos in cursos)
        {
            Console.WriteLine($"Yo estudio {cursos}");
        }
    }
}
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
// ejercicio04
public class LoteriaPrimitiva
{
    public static void Main(string[] args)
    {
        // Crear una lista para almacenar los números ganadores
        List<int> numerosGanadores = new List<int>();

        Console.WriteLine("¡Bienvenido al programa de la Lotería Primitiva!");
        Console.WriteLine("Por favor, introduce los 6 números ganadores (uno por uno).");
        Console.WriteLine("Los números deben estar entre 1 y 49.");

        // Bucle para pedir los 6 números al usuario
        for (int i = 0; i < 6; i++)
        {
            int numero;
            bool entradaValida = false;

            do
            {
                Console.Write($"Introduce el número {i + 1}: ");
                string entradaUsuario = Console.ReadLine();

                // Intentar convertir la entrada a un entero
                if (int.TryParse(entradaUsuario, out numero))
                {
                    // Validar que el número esté en el rango correcto y no esté duplicado
                    if (numero >= 1 && numero <= 49)
                    {
                        if (!numerosGanadores.Contains(numero))
                        {
                            numerosGanadores.Add(numero);
                            entradaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("¡Este número ya ha sido introducido! Por favor, introduce un número diferente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Número fuera de rango. Por favor, introduce un número entre 1 y 49.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número entero.");
                }
            } while (!entradaValida);
        }

        // Ordenar la lista de números de menor a mayor
        numerosGanadores.Sort();

        Console.WriteLine("\n--- Números Ganadores de la Lotería Primitiva ---");
        Console.Write("Los números introducidos y ordenados son: ");

        // Mostrar los números ordenados
        foreach (int num in numerosGanadores)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine(); // Para un salto de línea al final

        Console.WriteLine("\n¡Gracias por usar el programa!");
    }
}
//ejercicio 05
public class NumerosInversos
{
    public static void Main(string[] args)
    {
        // 1. Crear una lista de enteros
        List<int> numeros = new List<int>();

        // 2. Almacenar los números del 1 al 10 en la lista
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        // 3. Invertir el orden de la lista
        numeros.Reverse();

        // 4. Mostrar los números por pantalla separados por comas
        // Usamos String.Join para unir los elementos de la lista con una coma y un espacio
        Console.WriteLine(String.Join(", ", numeros));
    }
}
