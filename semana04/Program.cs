// See https://aka.ms/new-console-template for more information
// Agenda TelefónicaPara la agenda telefónica, usaremos una clase Contacto para representar a cada persona y una clase AgendaTelefonica para gestionar la colección de contactos.
using System;
using System.Collections.Generic; // Esto debe estar fuera de cualquier Console.WriteLine
// using System.Linq; // Si lo necesitas para otras partes, también fuera de Console.WriteLine

// Definición de la clase Contacto
public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public Contacto(string nombre, string telefono, string email)
    {
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Teléfono: {Telefono}, Email: {Email}");
    }
}

// Definición de la clase AgendaTelefonica
public class AgendaTelefonica
{
    private List<Contacto> contactos; // Uso de List<T> como vector dinámico

    public AgendaTelefonica()
    {
        contactos = new List<Contacto>();
    }

    public void AgregarContacto(Contacto nuevoContacto)
    {
        contactos.Add(nuevoContacto);
        Console.WriteLine($"Contacto '{nuevoContacto.Nombre}' agregado correctamente.");
    }

    public void EliminarContacto(string nombre)
    {
        Contacto contactoAEliminar = contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (contactoAEliminar != null)
        {
            contactos.Remove(contactoAEliminar);
            Console.WriteLine($"Contacto '{nombre}' eliminado correctamente.");
        }
        else
        {
            Console.WriteLine($"No se encontró ningún contacto con el nombre '{nombre}'.");
        }
    }

    public Contacto BuscarContacto(string nombre)
    {
        return contactos.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public void MostrarTodosLosContactos()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("La agenda telefónica está vacía.");
            return;
        }
        Console.WriteLine("\n--- Lista de Contactos ---");
        foreach (var contacto in contactos)
        {
            contacto.MostrarInformacion();
        }
        Console.WriteLine("--------------------------");
    }
}

// Clase principal para probar la Agenda Telefónica
public class ProgramaAgendaTelefonica
{
    public static void Main(string[] args)
    {
        AgendaTelefonica miAgenda = new AgendaTelefonica();

        miAgenda.AgregarContacto(new Contacto("Juan Perez", "0987654321", "juan@example.com"));
        miAgenda.AgregarContacto(new Contacto("Maria Lopez", "0912345678", "maria@example.com"));

        miAgenda.MostrarTodosLosContactos();

        Contacto buscado = miAgenda.BuscarContacto("Juan Perez");
        if (buscado != null)
        {
            Console.WriteLine("\nContacto encontrado:");
            buscado.MostrarInformacion();
        }
        else
        {
            Console.WriteLine("\nContacto no encontrado.");
        }

        miAgenda.EliminarContacto("Maria Lopez");
        miAgenda.MostrarTodosLosContactos();
    }
}