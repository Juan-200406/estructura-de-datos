//El problema de las Torres de Hanoi es un rompecabezas matemático que se puede resolver de manera eficiente utilizando recursividad. Aunque la solución clásica de las Torres de Hanoi es recursiva, para cumplir con la recomendación de usar pilas, podemos simular el movimiento de los discos y el estado de las torres utilizando Stack<int> para representar cada torre.//
using System;
using System.Collections.Generic;
using System.Linq; // Necesario para Linq.Reverse()

public static class TowersOfHanoi
{
    // Se representan las tres torres como pilas de enteros (los discos).
    // Los números más pequeños representan discos más pequeños.
    public static Stack<int> sourceTower;
    public static Stack<int> auxiliaryTower;
    public static Stack<int> destinationTower;

    /// <summary>
    /// Inicializa las torres con un número dado de discos.
    /// </summary>
    /// <param name="n">Número de discos.</param>
    public static void InitializeTowers(int n)
    {
        sourceTower = new Stack<int>();
        auxiliaryTower = new Stack<int>();
        destinationTower = new Stack<int>();

        // Se apilan los discos en la torre de origen, del más grande al más pequeño.
        for (int i = n; i >= 1; i--)
        {
            sourceTower.Push(i);
        }
    }

    /// <summary>
    /// Muestra el estado actual de las torres.
    /// </summary>
    public static void PrintTowers()
    {
        Console.WriteLine("--- Estado actual de las torres ---");
        Console.WriteLine("Torre Origen:      " + string.Join(", ", sourceTower.Reverse())); // Reverse para mostrar de abajo hacia arriba
        Console.WriteLine("Torre Auxiliar:    " + string.Join(", ", auxiliaryTower.Reverse()));
        Console.WriteLine("Torre Destino:     " + string.Join(", ", destinationTower.Reverse()));
        Console.WriteLine("---------------------------------");
    }

    /// <summary>
    /// Resuelve el problema de las Torres de Hanoi de forma recursiva.
    /// </summary>
    /// <param name="n">Número de discos a mover.</param>
    /// <param name="source">La pila de la torre de origen.</param>
    /// <param name="auxiliary">La pila de la torre auxiliar.</param>
    /// <param name="destination">La pila de la torre de destino.</param>
    /// <param name="sourceName">Nombre de la torre de origen.</param>
    /// <param name="auxiliaryName">Nombre de la torre auxiliar.</param>
    /// <param name="destinationName">Nombre de la torre de destino.</param>
    public static void SolveHanoi(int n, Stack<int> source, Stack<int> auxiliary, Stack<int> destination,
                                  string sourceName, string auxiliaryName, string destinationName)
    {
        // Caso base: Si solo hay un disco, se mueve directamente de origen a destino.
        if (n == 1)
        {
            int disk = source.Pop(); // Se saca el disco de la torre de origen.
            destination.Push(disk); // Se coloca el disco en la torre de destino.
            Console.WriteLine($"Mover disco {disk} de {sourceName} a {destinationName}");
            PrintTowers();
            return;
        }

        // Paso 1: Mover n-1 discos de la torre de origen a la torre auxiliar.
        SolveHanoi(n - 1, source, destination, auxiliary, sourceName, destinationName, auxiliaryName);

        // Paso 2: Mover el disco más grande (el disco n) de la torre de origen a la torre de destino.
        int largestDisk = source.Pop();
        destination.Push(largestDisk);
        Console.WriteLine($"Mover disco {largestDisk} de {sourceName} a {destinationName}");
        PrintTowers();

        // Paso 3: Mover los n-1 discos de la torre auxiliar a la torre de destino.
        SolveHanoi(n - 1, auxiliary, source, destination, auxiliaryName, sourceName, destinationName);
    }

    public static void Main(string[] args)
    {
        int numberOfDisks = 3; // Puedes cambiar el número de discos aquí.
        Console.WriteLine($"Resolviendo las Torres de Hanoi con {numberOfDisks} discos.");

        InitializeTowers(numberOfDisks);
        PrintTowers(); // Muestra el estado inicial.

        // Inicia la resolución del problema.
        SolveHanoi(numberOfDisks, sourceTower, auxiliaryTower, destinationTower, "Torre Origen", "Torre Auxiliar", "Torre Destino");

        Console.WriteLine("\n--- ¡Problema de las Torres de Hanoi resuelto! ---");
    }
}