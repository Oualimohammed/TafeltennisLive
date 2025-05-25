


// ===== OPDRACHT 3: C# 12 FEATURES DEMO =====
// Deze demo toont nieuwe C# 12-features die nuttig zouden zijn
// in mijn tafeltennis-applicatie.

// 1️⃣ PRIMARY CONSTRUCTOR
// - Vervangt boilerplate constructor-code
// - Ideaal voor DTOs zoals Player, Match, etc. in mijn Blazor-app
var player = new Player("Ma Long", 1);
Console.WriteLine($"PRIMARY CONSTRUCTOR: {player.Name} (Ranking: {player.Ranking})");

// 2️⃣ COLLECTION EXPRESSIONS
// - Vereenvoudigt list-initialisatie
// - Handig voor snelle team/speler-lijsten in tafeltennis:
//   Bijv. voor seeding-data of wedstrijdschema's
List<string> topPlayers = ["Ma Long", "Fan Zhendong"];
List<string> allPlayers = [.. topPlayers, "Adrien Mattenet"];
Console.WriteLine("\nCOLLECTION EXPRESSIONS:");
Console.WriteLine(string.Join(", ", allPlayers));

// 3️⃣ DEFAULT LAMBDA PARAMETERS
// - Maakt herbruikbare filters eenvoudiger
// - Zou ik kunnen gebruiken voor ranking-filters in mijn PlayerService
var filterPlayers = (List<Player> players, int minRanking = 50) =>
    players.Where(p => p.Ranking >= minRanking).ToList();

var filtered = filterPlayers([
    new("Ma Long", 1),
    new("Cédric Nuytinck", 45)  // Wordt gefilterd bij default (50+)
]);
Console.WriteLine($"\nAantal top-spelers (50+): {filtered.Count}");

// ===== TYPE DECLARATIES (onder aan bestand) =====
class Player(string name, int ranking)
{
    public string Name { get; } = name;  // Primary constructor syntax
    public int Ranking { get; } = ranking;

    // In mijn echte app zou ik hier ook:
    // - Handicap (links/rechts)
    // - Speelstijl (aanval/verdediging) toevoegen
}








