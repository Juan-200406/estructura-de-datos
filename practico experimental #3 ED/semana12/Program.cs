// Program.cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace TorneoFutbol
{
    // Representa un jugador
    public class Player
    {
        public int Id { get; set; }           // Identificador único
        public string Name { get; set; }
        public int Dorsal { get; set; }      // Número en la camiseta
        public string Position { get; set; } // Ej: Delantero, Defensa
        public string TeamName { get; set; } // Nombre del equipo (puede ser null)

        public Player(int id, string name, int dorsal, string position)
        {
            Id = id;
            Name = name;
            Dorsal = dorsal;
            Position = position;
            TeamName = null;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Name} | Dorsal: {Dorsal} | Pos: {Position} | Equipo: {(TeamName ?? "Sin equipo")}";
        }
    }

    // Representa un equipo
    public class Team
    {
        public string Name { get; set; }                 // Clave en el Dictionary
        public string Coach { get; set; }
        public List<Player> Players { get; set; }

        public Team(string name, string coach)
        {
            Name = name;
            Coach = coach;
            Players = new List<Player>();
        }

        public override string ToString()
        {
            return $"Equipo: {Name} | DT: {Coach} | Jugadores: {Players.Count}";
        }
    }

    // Manager principal que usa Dictionary = map y HashSet = conjunto
    public class TournamentManager
    {
        // Map: nombreEquipo -> Team
        private Dictionary<string, Team> teams = new Dictionary<string, Team>(StringComparer.OrdinalIgnoreCase);

        // Map de jugadores por id para búsquedas rápidas (opcional)
        private Dictionary<int, Player> playersById = new Dictionary<int, Player>();

        // Set para garantizar dorsales únicos a nivel de torneo
        private HashSet<int> dorsalesRegistrados = new HashSet<int>();

        private int nextPlayerId = 1;

        // Registrar equipo
        public bool AddTeam(string teamName, string coach)
        {
            if (string.IsNullOrWhiteSpace(teamName)) return false;
            if (teams.ContainsKey(teamName)) return false; // ya existe
            teams[teamName] = new Team(teamName.Trim(), coach?.Trim() ?? "");
            return true;
        }

        // Registrar jugador (no asignado a equipo aún)
        public Player AddPlayer(string name, int dorsal, string position)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nombre inválido");
            // comprobar dorsal único
            if (dorsalesRegistrados.Contains(dorsal)) throw new ArgumentException($"Dorsal {dorsal} ya registrado en el torneo.");

            var player = new Player(nextPlayerId++, name.Trim(), dorsal, position?.Trim() ?? "");
            playersById[player.Id] = player;
            dorsalesRegistrados.Add(dorsal);
            return player;
        }

        // Asignar jugador a equipo (por id jugador y nombre equipo)
        public bool AssignPlayerToTeam(int playerId, string teamName)
        {
            if (!playersById.TryGetValue(playerId, out var player)) return false;
            if (!teams.TryGetValue(teamName, out var team)) return false;

            // si ya pertenece a otro equipo, remover de ese equipo
            if (!string.IsNullOrEmpty(player.TeamName) && teams.TryGetValue(player.TeamName, out var prevTeam))
            {
                prevTeam.Players.RemoveAll(p => p.Id == playerId);
            }

            player.TeamName = team.Name;
            team.Players.Add(player);
            return true;
        }

        // Remover jugador
        public bool RemovePlayer(int playerId)
        {
            if (!playersById.TryGetValue(playerId, out var player)) return false;
            // remover de equipo si aplica
            if (!string.IsNullOrEmpty(player.TeamName) && teams.TryGetValue(player.TeamName, out var team))
            {
                team.Players.RemoveAll(p => p.Id == playerId);
            }
            playersById.Remove(playerId);
            dorsalesRegistrados.Remove(player.Dorsal);
            return true;
        }

        // Consultas / reportería
        public IEnumerable<Team> ListTeams() => teams.Values.OrderBy(t => t.Name);

        public IEnumerable<Player> ListPlayers() => playersById.Values.OrderBy(p => p.Id);

        public IEnumerable<Player> ListPlayersByTeam(string teamName)
        {
            if (!teams.TryGetValue(teamName, out var team)) return Enumerable.Empty<Player>();
            return team.Players.OrderBy(p => p.Dorsal);
        }

        public Player? FindPlayerById(int id) => playersById.TryGetValue(id, out var p) ? p : null;

        public IEnumerable<Player> FindPlayersByName(string partial)
        {
            partial = partial?.Trim() ?? "";
            if (partial == "") return Enumerable.Empty<Player>();
            return playersById.Values.Where(p => p.Name.IndexOf(partial, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public Team? FindTeam(string teamName) => teams.TryGetValue(teamName, out var t) ? t : null;

        // Exportar a CSV (equipos y jugadores)
        public string ExportCsv()
        {
            var sb = new StringBuilder();
            sb.AppendLine("TeamName,Coach,PlayerId,PlayerName,Dorsal,Position");
            foreach (var t in teams.Values)
            {
                if (t.Players.Count == 0)
                {
                    sb.AppendLine($"{EscapeCsv(t.Name)},{EscapeCsv(t.Coach)},,,," );
                }
                else
                {
                    foreach (var p in t.Players)
                    {
                        sb.AppendLine($"{EscapeCsv(t.Name)},{EscapeCsv(t.Coach)},{p.Id},{EscapeCsv(p.Name)},{p.Dorsal},{EscapeCsv(p.Position)}");
                    }
                }
            }
            return sb.ToString();
        }

        private string EscapeCsv(string s) => $"\"{(s ?? "").Replace("\"","\"\"")}\"";

        // Método de prueba para simular N inserciones y medir tiempos (usa Stopwatch)
        public static void BenchmarkInsertions(int n)
        {
            var sw = new Stopwatch();
            var manager = new TournamentManager();
            manager.AddTeam("EquipoA", "DT A");
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                var player = manager.AddPlayer($"Jugador_{i}", 1000 + i, "Mediocampista");
                manager.AssignPlayerToTeam(player.Id, "EquipoA");
            }
            sw.Stop();
            Console.WriteLine($"Insertados {n} jugadores en {sw.ElapsedMilliseconds} ms");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var manager = new TournamentManager();
            SeedSampleData(manager);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Menú Torneo Fútbol ---");
                Console.WriteLine("1) Agregar equipo");
                Console.WriteLine("2) Agregar jugador");
                Console.WriteLine("3) Asignar jugador a equipo");
                Console.WriteLine("4) Listar equipos");
                Console.WriteLine("5) Listar jugadores");
                Console.WriteLine("6) Listar jugadores por equipo");
                Console.WriteLine("7) Buscar jugador por nombre");
                Console.WriteLine("8) Exportar CSV");
                Console.WriteLine("9) Ejecutar benchmark (inserciones)");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");
                var opt = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    switch (opt)
                    {
                        case "1":
                            Console.Write("Nombre equipo: ");
                            var teamName = Console.ReadLine();
                            Console.Write("Director técnico: ");
                            var coach = Console.ReadLine();
                            if (manager.AddTeam(teamName, coach)) Console.WriteLine("Equipo agregado.");
                            else Console.WriteLine("No se pudo agregar (ya existe o nombre inválido).");
                            break;
                        case "2":
                            Console.Write("Nombre jugador: ");
                            var name = Console.ReadLine();
                            Console.Write("Dorsal (número): ");
                            var dorsalStr = Console.ReadLine();
                            Console.Write("Posición: ");
                            var pos = Console.ReadLine();
                            if (!int.TryParse(dorsalStr, out var dorsal)) { Console.WriteLine("Dorsal inválido."); break; }
                            var player = manager.AddPlayer(name, dorsal, pos);
                            Console.WriteLine($"Jugador creado: {player}");
                            break;
                        case "3":
                            Console.Write("ID jugador: ");
                            if (!int.TryParse(Console.ReadLine(), out var pid)) { Console.WriteLine("ID inválido."); break; }
                            Console.Write("Nombre equipo: ");
                            var equipo = Console.ReadLine();
                            if (manager.AssignPlayerToTeam(pid, equipo)) Console.WriteLine("Asignado correctamente.");
                            else Console.WriteLine("No se pudo asignar (verifique ID o equipo).");
                            break;
                        case "4":
                            foreach (var t in manager.ListTeams()) Console.WriteLine(t);
                            break;
                        case "5":
                            foreach (var p in manager.ListPlayers()) Console.WriteLine(p);
                            break;
                        case "6":
                            Console.Write("Nombre equipo: ");
                            var eq = Console.ReadLine();
                            foreach (var p in manager.ListPlayersByTeam(eq)) Console.WriteLine(p);
                            break;
                        case "7":
                            Console.Write("Texto búsqueda: ");
                            var txt = Console.ReadLine();
                            foreach (var p in manager.FindPlayersByName(txt)) Console.WriteLine(p);
                            break;
                        case "8":
                            var csv = manager.ExportCsv();
                            var file = $"torneo_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                            File.WriteAllText(file, csv, Encoding.UTF8);
                            Console.WriteLine($"Exportado a {file}");
                            break;
                        case "9":
                            Console.Write("Número de inserciones para benchmark: ");
                            if (!int.TryParse(Console.ReadLine(), out var n)) { Console.WriteLine("Número inválido."); break; }
                            TournamentManager.BenchmarkInsertions(n);
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Saliendo...");
        }

        static void SeedSampleData(TournamentManager manager)
        {
            // datos de ejemplo
            manager.AddTeam("París Saint-Germain", "Luis enrique");
            manager.AddTeam("chelsea ", "Maresca");

            var p1 = manager.AddPlayer("Moises Caicedo", 9, "Delantero".);
            var p2 = manager.AddPlayer("Piero Hincapie", 1, "Arquero");
            manager.AssignPlayerToTeam(p1.Id, "chelsea");
            manager.AssignPlayerToTeam(p2.Id, "¿arsenal");

        }
    }
}
