/*using System;

// ============================================
// Feature 1: Primary Constructors
// ============================================
public class PlayerService(string databaseConnection)
{
    public void AddPlayer(string name)
    {
        Console.WriteLine($"[PlayerService] Speler '{name}' toegevoegd (DB: {databaseConnection})");
    }
}

public class Program
{
    public static void Main()
    {
        // Gebruik Feature 1: Primary Constructors
        var service = new PlayerService("Server=localhost;Database=PinTafelTennis");
        service.AddPlayer("Alice");

        // ============================================
        // Feature 2: Collection Expressions
        // ============================================
        string[] players = ["Alice", "Bob", "Charlie"]; // Nieuw in C# 12
        string[] morePlayers = [.. players, "Diana"];    // Spread operator

        Console.WriteLine("\n🔹 Spelerslijst:");
        foreach (var player in morePlayers)
        {
            Console.WriteLine($"- {player}");
        }

        // ============================================
        // Feature 3: Default Lambda Parameters
        // ============================================
        var logEvent = (string message, string level = "INFO") =>
            Console.WriteLine($"[{level}] {message}");

        logEvent("Wedstrijd gestart");          // Standaard "INFO"
        logEvent("Database error!", "ERROR");   // Custom level

        // ============================================
        // Toepassing in mijn project
        // ============================================
        Console.WriteLine("\n💡 Toepassing in mijn Blazor-app:");
        Console.WriteLine("- Primary Constructors: Mijn MatchService zou 30% minder code hebben.");
        Console.WriteLine("- Collection Expressions: Seeddata voor matches (bv. [match1, match2]).");
        Console.WriteLine("- Default Lambdas: Flexibele event handlers in LiveMatchHub.");
    }
}
*/



using System;

// ============================================
// Demo Console App voor C# 12 nieuwe features
// ============================================

/*
 * Feature 1: Primary Constructors
 * -----------------------------------
 * Met primary constructors kan je direct parameters aan de class geven zonder aparte velden en constructor.
 * Dit bespaart veel boilerplate code en maakt de klasse compact en overzichtelijk.
 * In mijn Blazor-project had ik dit kunnen toepassen in services zoals MatchService
 * om connectiestrings of configuraties eenvoudiger door te geven.
 */
public class PlayerService(string databaseConnection)
{
    public void AddPlayer(string name)
    {
        Console.WriteLine($"[PlayerService] Speler '{name}' toegevoegd (DB: {databaseConnection})");
    }
}

public class Program
{
    public static void Main()
    {
        // -----------------------------
        // Gebruik van Feature 1: Primary Constructors
        // -----------------------------
        var service = new PlayerService("Server=localhost;Database=PinTafelTennis");
        service.AddPlayer("Alice");

        // -----------------------------
        // Feature 2: Collection Expressions met Spread Operator
        // -----------------------------
        /*
         * Met collection expressions kan je arrays of lijsten op een korte manier initialiseren.
         * De spread operator (..) maakt het makkelijk om bestaande collecties uit te breiden.
         * Dit was handig geweest in mijn opleiding om snel testdata te creëren zonder veel code.
         * Ook in mijn project kan ik zo makkelijk seeddata voor spelers of matches aanmaken.
         */
        string[] players = ["Alice", "Bob", "Charlie"];      // Nieuwe array literal syntax
        string[] morePlayers = [.. players, "Diana"];         // Spread operator voegt "Diana" toe aan bestaande array

        Console.WriteLine("\n🔹 Spelerslijst:");
        foreach (var player in morePlayers)
        {
            Console.WriteLine($"- {player}");
        }

        // -----------------------------
        // Feature 3: Default Lambda Parameters
        // -----------------------------
        /*
         * Lambda-expressies kunnen nu parameters met standaardwaarden hebben.
         * Dit maakt de code flexibeler en vermindert overbelasting van methoden.
         * Bijvoorbeeld voor logging gebruik ik meestal level "INFO",
         * maar kan ik eenvoudig een ander level meegeven indien nodig.
         */
        var logEvent = (string message, string level = "INFO") =>
            Console.WriteLine($"[{level}] {message}");

        logEvent("Wedstrijd gestart");          // Gebruik standaard level "INFO"
        logEvent("Database error!", "ERROR");   // Specifiek level "ERROR"

        // -----------------------------
        // Toepassing van deze features in mijn Blazor-project en opleiding
        // -----------------------------
        Console.WriteLine("\n💡 Toepassing in mijn Blazor-app en opleiding:");
        Console.WriteLine("- Primary Constructors: mijn MatchService zou 30% minder code hebben door deze feature.");
        Console.WriteLine("- Collection Expressions: ideaal voor seeddata bij het testen van matches en spelerslijsten.");
        Console.WriteLine("- Default Lambdas: flexibele event handlers in bijvoorbeeld mijn LiveMatchHub (SignalR).");
        Console.WriteLine("\nDeze features maken mijn code compacter, leesbaarder en eenvoudiger onderhoudbaar.");
    }
}
