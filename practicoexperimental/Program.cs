using System;
using System.Collections.Generic;
using System.Linq;

namespace AsignacionAsientos
{
    // Clase que representa a una Persona
    public class Persona
    {
        public string Nombre { get; set; }
        public int Id { get; private set; }
        private static int _nextId = 1;

        public Persona(string nombre)
        {
            Nombre = nombre;
            Id = _nextId++;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}";
        }
    }

    // Clase que representa la Atracción y gestiona los asientos
    public class Atraccion
    {
        private const int CapacidadMaxima = 30;
        private Queue<Persona> _colaEspera;
        private List<Persona> _asientosOcupados;
        private int _totalPersonasAtendidas;

        public Atraccion()
        {
            _colaEspera = new Queue<Persona>();
            _asientosOcupados = new List<Persona>();
            _totalPersonasAtendidas = 0;
            Console.WriteLine($"Atracción inicializada con {CapacidadMaxima} asientos disponibles.");
        }

        /// <summary>
        /// Agrega una persona a la cola de espera.
        /// </summary>
        /// <param name="persona">La persona a agregar.</param>
        public void EncolarPersona(Persona persona)
        {
            _colaEspera.Enqueue(persona);
            Console.WriteLine($"'{persona.Nombre}' (ID: {persona.Id}) ha entrado a la cola.");
            MostrarEstadoActual();
        }

        /// <summary>
        /// Asigna asientos a las personas en la cola hasta llenar la capacidad.
        /// </summary>
        public void AsignarAsientos()
        {
            Console.WriteLine("\n--- Asignando Asientos ---");
            int asientosAsignadosEstaRonda = 0;

            while (_asientosOcupados.Count < CapacidadMaxima && _colaEspera.Count > 0)
            {
                Persona personaActual = _colaEspera.Dequeue();
                _asientosOcupados.Add(personaActual);
                _totalPersonasAtendidas++;
                asientosAsignadosEstaRonda++;
                Console.WriteLine($"'{personaActual.Nombre}' (ID: {personaActual.Id}) ha tomado un asiento.");
            }

            if (asientosAsignadosEstaRonda > 0)
            {
                Console.WriteLine($"Se asignaron {asientosAsignadosEstaRonda} asientos en esta ronda.");
                if (_asientosOcupados.Count == CapacidadMaxima)
                {
                    Console.WriteLine("¡Todos los asientos están ocupados!");
                }
            }
            else
            {
                Console.WriteLine("No hay personas en la cola o ya todos los asientos están ocupados.");
            }
            MostrarEstadoActual();
        }

        /// <summary>
        /// Libera todos los asientos.
        /// </summary>
        public void LiberarAsientos()
        {
            if (_asientosOcupados.Any())
            {
                Console.WriteLine("\n--- Liberando Asientos ---");
                _asientosOcupados.Clear();
                Console.WriteLine("Todos los asientos han sido liberados.");
            }
            else
            {
                Console.WriteLine("\nNo hay asientos ocupados para liberar.");
            }
            MostrarEstadoActual();
        }

        /// <summary>
        /// Muestra el estado actual de la atracción: personas en cola y asientos ocupados.
        /// </summary>
        public void MostrarEstadoActual()
        {
            Console.WriteLine("\n--- Estado Actual de la Atracción ---");
            Console.WriteLine($"Capacidad Total: {CapacidadMaxima}");
            Console.WriteLine($"Asientos Ocupados: {_asientosOcupados.Count}");
            Console.WriteLine($"Asientos Disponibles: {CapacidadMaxima - _asientosOcupados.Count}");
            Console.WriteLine($"Personas en Cola: {_colaEspera.Count}");
            Console.WriteLine($"Total Personas Atendidas (histórico): {_totalPersonasAtendidas}");

            if (_colaEspera.Any())
            {
                Console.WriteLine("\nPersonas en la Cola (Orden de Llegada):");
                foreach (var persona in _colaEspera)
                {
                    Console.WriteLine($"- {persona}");
                }
            }
            else
            {
                Console.WriteLine("\nLa cola de espera está vacía.");
            }

            if (_asientosOcupados.Any())
            {
                Console.WriteLine("\nAsientos Ocupados Actualmente:");
                foreach (var persona in _asientosOcupados)
                {
                    Console.WriteLine($"- {persona}");
                }
            }
            else
            {
                Console.WriteLine("\nNo hay asientos ocupados actualmente.");
            }
            Console.WriteLine("--------------------------------------");
        }

        /// <summary>
        /// Consulta una persona específica en la cola o en los asientos ocupados.
        /// </summary>
        /// <param name="nombreOId">Nombre o ID de la persona a buscar.</param>
        public void ConsultarPersona(string nombreOId)
        {
            Console.WriteLine($"\n--- Consultando persona: '{nombreOId}' ---");
            Persona personaEncontrada = null;

            // Intentar buscar por ID
            if (int.TryParse(nombreOId, out int idBuscado))
            {
                personaEncontrada = _colaEspera.FirstOrDefault(p => p.Id == idBuscado) ??
                                    _asientosOcupados.FirstOrDefault(p => p.Id == idBuscado);
            }

            // Si no se encontró por ID, intentar buscar por nombre (ignorando mayúsculas/minúsculas)
            if (personaEncontrada == null)
            {
                personaEncontrada = _colaEspera.FirstOrDefault(p => p.Nombre.Equals(nombreOId, StringComparison.OrdinalIgnoreCase)) ??
                                    _asientosOcupados.FirstOrDefault(p => p.Nombre.Equals(nombreOId, StringComparison.OrdinalIgnoreCase));
            }

            if (personaEncontrada != null)
            {
                Console.WriteLine($"Persona encontrada: {personaEncontrada}");
                if (_colaEspera.Contains(personaEncontrada))
                {
                    Console.WriteLine("Estado: Actualmente en la cola de espera.");
                }
                else if (_asientosOcupados.Contains(personaEncontrada))
                {
                    Console.WriteLine("Estado: Actualmente ocupando un asiento.");
                }
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna persona con el nombre/ID '{nombreOId}' en la cola o en los asientos ocupados.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion miAtraccion = new Atraccion();

            // Simulación de llegada de personas
            miAtraccion.EncolarPersona(new Persona("Alice"));
            miAtraccion.EncolarPersona(new Persona("Bob"));
            miAtraccion.EncolarPersona(new Persona("Charlie"));

            // Asignar algunos asientos
            miAtraccion.AsignarAsientos();

            // Llegan más personas
            miAtraccion.EncolarPersona(new Persona("David"));
            miAtraccion.EncolarPersona(new Persona("Eve"));

            // Asignar más asientos hasta llenar
            for (int i = 0; i < 25; i++) // 3 ya se asignaron, faltan 27. Añadimos 25 más
            {
                miAtraccion.EncolarPersona(new Persona($"Persona_{i + 1}"));
            }
            miAtraccion.AsignarAsientos(); // Esto debería llenar los 30 asientos

            // Intentar encolar a alguien cuando ya no hay espacio
            miAtraccion.EncolarPersona(new Persona("Frank")); // Frank se quedará en cola si no hay asientos libres

            // Consultar el estado completo
            miAtraccion.MostrarEstadoActual();

            // Consultar personas específicas
            miAtraccion.ConsultarPersona("Alice");
            miAtraccion.ConsultarPersona("Persona_10");
            miAtraccion.ConsultarPersona("Frank");
            miAtraccion.ConsultarPersona("NoExiste");

            // Liberar asientos y ver el nuevo estado
            miAtraccion.LiberarAsientos();

            // Asignar de nuevo con los que quedaron en cola
            miAtraccion.AsignarAsientos();

            miAtraccion.MostrarEstadoActual();

            Console.WriteLine("\nPresiona cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}