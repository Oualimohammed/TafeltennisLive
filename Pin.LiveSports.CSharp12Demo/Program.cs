// Onderstaande features zouden nuttig zijn in mijn tafeltennis-app.

// 1. PRIMARY CONSTRUCTOR (verkort klasse-definitie)
var player = new Player("Ma Long", 1);
Console.WriteLine($"PRIMARY CONSTRUCTOR: {player.Name} (Ranking: {player.Ranking})");

// 2. COLLECTION EXPRESSIONS (vereenvoudigt lijst-aanmaak)
List<string> players = ["Ma Long", "Fan Zhendong"]; // Geen 'new List' nodig
List<string> extendedTeam = [.. players, "Adrien Mattenet"]; // Combineren met spread operator
Console.WriteLine("\nCOLLECTION EXPRESSIONS:");
Console.WriteLine(string.Join(", ", extendedTeam));

// 3. DEFAULT LAMBDA PARAMETERS (flexibele filters)
var filterTopPlayers = (List<Player> players, int minRanking = 50) =>
    players.Where(p => p.Ranking >= minRanking).ToList();

var topPlayers = filterTopPlayers([
    new("Ma Long", 1),      // Blijft behouden (ranking 1 >= 50)
    new("Cédric Nuytinck", 45) // Wordt gefilterd (ranking 45 < 50)
]);
Console.WriteLine($"\nAantal top-spelers (standaard 50+): {topPlayers.Count}");

// --- Helper class ---
class Player(string name, int ranking)
{
    public string Name { get; } = name;  // Property via primary constructor
    public int Ranking { get; } = ranking;
}
