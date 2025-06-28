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
