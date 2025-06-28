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
