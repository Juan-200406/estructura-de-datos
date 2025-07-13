
int numberOfDisks = 3; // Puedes cambiar el número de discos aquí.
Console.WriteLine($"Resolviendo las Torres de Hanoi con {numberOfDisks} discos.");

TowersOfHanoi.InitializeTowers(numberOfDisks);
TowersOfHanoi.PrintTowers(); // Muestra el estado inicial.

// Inicia la resolución del problema.
TowersOfHanoi.SolveHanoi(numberOfDisks, TowersOfHanoi.sourceTower, TowersOfHanoi.auxiliaryTower, TowersOfHanoi.destinationTower, "Torre Origen", "Torre Auxiliar", "Torre Destino");

Console.WriteLine("\n--- ¡Problema de las Torres de Hanoi resuelto! ---");
