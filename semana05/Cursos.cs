//ejerciccio2

public class Cursos
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

        foreach (string curso in cursos)
        {
            Console.WriteLine($"Yo estudio {cursos}");
        }
    }
}