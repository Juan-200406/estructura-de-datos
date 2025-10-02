using System;
using System.Collections.Generic;
using System.Diagnostics;

class Vuelo
{
    public string Destino { get; set; }
    public double Costo { get; set; }
    public string Aerolinea { get; set; }

    public Vuelo(string destino, double costo, string aerolinea)
    {
        Destino = destino;
        Costo = costo;
        Aerolinea = aerolinea;
    }
}

class Grafo
{
    public Dictionary<string, List<Vuelo>> Adyacencia = new();

    public void AgregarVuelo(string origen, string destino, double costo, string aerolinea)
    {
        if (!Adyacencia.ContainsKey(origen))
            Adyacencia[origen] = new List<Vuelo>();

        Adyacencia[origen].Add(new Vuelo(destino, costo, aerolinea));
    }

    public void MostrarGrafo()
    {
        Console.WriteLine("**REPORTERÍA: ESTRUCTURA DE VUELOS (BASE DE DATOS FICTICIA)**\n");
        foreach (var aeropuerto in Adyacencia)
        {
            Console.WriteLine($"🛫 Aeropuerto: **{NombreAeropuerto(aeropuerto.Key)}** ({aeropuerto.Key})");
            foreach (var vuelo in aeropuerto.Value)
            {
                Console.WriteLine($"  -> Vuelo a {vuelo.Destino}: **${vuelo.Costo:0.00}** con {vuelo.Aerolinea}");
            }
            Console.WriteLine();
        }
    }

    private string NombreAeropuerto(string codigo) => codigo switch
    {
        "UIO" => "Quito",
        "MDE" => "Medellín",
        "LIM" => "Lima",
        "JFK" => "Nueva York",
        "MAD" => "Madrid",
        "BOG" => "Bogotá",
        _ => "Desconocido"
    };

    // ---------------- ALGORITMO DE DIJKSTRA ----------------
    public (double costo, List<string> ruta) Dijkstra(string inicio, string fin)
    {
        var dist = new Dictionary<string, double>();
        var prev = new Dictionary<string, string>();
        var pq = new PriorityQueue<string, double>();

        foreach (var nodo in Adyacencia.Keys)
            dist[nodo] = double.PositiveInfinity;

        dist[inicio] = 0;
        pq.Enqueue(inicio, 0);

        while (pq.Count > 0)
        {
            var actual = pq.Dequeue();

            if (actual == fin) break;

            if (!Adyacencia.ContainsKey(actual)) continue;

            foreach (var vuelo in Adyacencia[actual])
            {
                double nuevoDist = dist[actual] + vuelo.Costo;
                if (nuevoDist < dist[vuelo.Destino])
                {
                    dist[vuelo.Destino] = nuevoDist;
                    prev[vuelo.Destino] = actual;
                    pq.Enqueue(vuelo.Destino, nuevoDist);
                }
            }
        }

        // reconstrucción de la ruta
        var ruta = new List<string>();
        var nodoRuta = fin;

        if (!prev.ContainsKey(fin) && inicio != fin)
            return (double.PositiveInfinity, new List<string>()); // ❌ sin ruta

        while (nodoRuta != null)
        {
            ruta.Insert(0, nodoRuta);
            prev.TryGetValue(nodoRuta, out nodoRuta);
        }

        return (dist[fin], ruta);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("✈️ **BUSCADOR DE VUELOS BARATOS (ALGORITMO DE DIJKSTRA)** ✈️\n");

        var grafo = new Grafo();

        // ------------------- BASE DE DATOS FICTICIA -------------------
        grafo.AgregarVuelo("UIO", "MDE", 150, "AeroX");
        grafo.AgregarVuelo("UIO", "LIM", 200, "AeroY");
        grafo.AgregarVuelo("UIO", "BOG", 120, "AeroY");

        grafo.AgregarVuelo("MDE", "JFK", 400, "AirZ");
        grafo.AgregarVuelo("MDE", "LIM", 100, "AeroX");
        grafo.AgregarVuelo("MDE", "MAD", 950, "AirZ");

        grafo.AgregarVuelo("LIM", "JFK", 600, "AeroY");

        grafo.AgregarVuelo("JFK", "MAD", 500, "DeltaAir");

        grafo.AgregarVuelo("MAD", "UIO", 700, "Latina");

        grafo.AgregarVuelo("BOG", "JFK", 350, "AirZ");
        grafo.AgregarVuelo("BOG", "MAD", 800, "Iberica");

        // ------------------- MOSTRAR GRAFO -------------------
        grafo.MostrarGrafo();

        Console.WriteLine("======================================================================\n");
        Console.WriteLine("**CONSULTANDO RUTA MÁS BARATA: UIO a MAD**\n");

        var sw = Stopwatch.StartNew();
        var (costo, ruta) = grafo.Dijkstra("UIO", "MAD");
        sw.Stop();

        if (double.IsInfinity(costo))
        {
            Console.WriteLine("❌ No se encontró una ruta de UIO a MAD.\n");
        }
        else
        {
            Console.WriteLine($"✅ Ruta encontrada: {string.Join(" → ", ruta)}");
            Console.WriteLine($"💲 Costo total: ${costo:0.00}\n");
        }

        Console.WriteLine("======================================================================\n");
        Console.WriteLine($"**ANÁLISIS DE TIEMPO DE EJECUCIÓN**\nAlgoritmo de Dijkstra ejecutado en: **{sw.Elapsed.TotalMilliseconds:0.000000} ms**.\n");
        Console.WriteLine("======================================================================\n");
    }
}
