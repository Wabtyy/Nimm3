menu("startscreen");

void Game()
{
    int rows = int.Parse(menu("rows"));
    Console.Clear();

    int stäbchen = -1, // Damit in der ersten Reihe einer und in der dritten 3 gesetzt werden
        spaces = rows,
        bodendecke = spaces * 6 - 2, // Frag mich einfach nicht, was die Rechnung bewirkt, aber es klappt :)
        Animation = 25;

    string deckenboden = new string('═', bodendecke + 1);

    Console.ForegroundColor = ConsoleColor.Magenta;

    int originalRows = rows; // Speichern der ursprünglichen Reihenanzahl

    while (rows > 0)
    {
        spaces--;
        stäbchen += 2;
        rows--;

        if (stäbchen == 1) Console.WriteLine("   ╔═══╦" + deckenboden + "╗");
        else Console.WriteLine("");

        // Zeilennummer links anzeigen
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("   ║"); 
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{originalRows - rows,2} "); // Zeilennummer rechtsbündig mit 3 Stellen
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║");
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.Write(new string(' ', spaces * 3 + 1)); // Füllt links von den "!" alles mit Leerzeichen, so dass die "║" in einer Reihe sind.

        for (int i = 0; i < stäbchen; i++)
        {
            Console.Write(" ! ");
            Thread.Sleep(stäbchen);
        }

        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.Write(new string(' ', spaces * 3)); // Füllt rechts von den "!" alles mit Leerzeichen, so dass die "║" in einer Reihe sind.

        Console.Write(" ║");
    }

    Console.WriteLine("\n   ╚═══╬" + deckenboden + "╣");

    // Koordinaten unter der Pyramide anzeigen
    int koordinatenBreite = bodendecke / 6; // Breite der Koordinaten

    Console.Write("      "); // Abstände für Ausrichtung
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(" ║");
    Console.ForegroundColor = ConsoleColor.Yellow;
    for (int i = -koordinatenBreite; i <= koordinatenBreite; i++)
    {
        if (i < 0)
        {
            Console.Write($"{i,3}"); // Negative Zahlen mit drei Stellen
        }
        else
        {
            Console.Write($"{i,3}"); // Positive Zahlen mit drei Stellen
        }
    }
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("  ║");
    Console.WriteLine("\n       ╚" + deckenboden + "╝");
    Console.ResetColor();
    Console.WriteLine();
    Console.SetCursorPosition(35, Console.CursorTop - 3);
    Console.ReadLine();


    //int cursorLeft = Console.CursorLeft;
    //int cursorTop = Console.CursorTop;
    //Console.WriteLine(cursorLeft + cursorTop);

}

string menu(string method)
{
    Console.Clear();
    if (method == "startscreen")
    {
        logo();
        Console.WriteLine("           ╔════════════╩══════════════╗");
        Console.WriteLine("  ╔══════════════════╗                 ║");
        Console.Write("  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("      1VS1      ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" ║         ╔═══════╩════════╗\n  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("     LEVEL 1    ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" ║         ╠═►              ║\n  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("     LEVEL 2     ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║         ╚════════════════╝\n  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("   SPIELREGELN   ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║\n  ╚══════════════════╝");

        Console.SetCursorPosition(35, Console.CursorTop - 3);
        Console.ForegroundColor = ConsoleColor.Yellow;

        switch (Console.ReadLine()?.ToLower().Replace(" ", ""))
        {
            case "1vs1": break;
            case "level1": Game(); break;
            case "level2": Game(); break;
            case "spielregeln": Rules(); break;
        }
        return "";
    }
    else if (method == "rows")
    {
        while (true)
        {
            Console.Clear();
            logo();
            Console.WriteLine("               ╔════════╩═══════╗");
            Console.Write("               ║ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Number of rows ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("║\n               ╚════════╦═══════╝\n                     ╔══╩══╗\n                     ╠═►   ║\n                     ╚═════╝");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, Console.CursorTop - 1);
            int abc = int.Parse(Console.ReadLine());
            if (abc > 2 && abc < 10) return abc.ToString();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rows cannot be less than 3, or greater than 9");
            Thread.Sleep(2500);
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
    return "";
}

void logo()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("╔════════════════════════════════════════════════╗");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("███╗  ██╗██╗███╗   ███╗███╗   ███╗    ██████╗ ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" ║");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("████╗ ██║██║████╗ ████║████╗ ████║    ╚════██╗");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" ║");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("██╔██╗██║██║██╔████╔██║██╔████╔██║     █████╔╝");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" ║");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("██║╚████║██║██║╚██╔╝██║██║╚██╔╝██║     ╚═══██╗");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" ║");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("██║ ╚███║██║██║ ╚═╝ ██║██║ ╚═╝ ██║    ██████╔╝");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" ║");
    Console.Write("║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("╚═╝  ╚══╝╚═╝╚═╝     ╚═╝╚═╝     ╚═╝    ╚═════╝ ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(" ║");
    Console.WriteLine("╚═══════════════════════╦════════════════════════╝");
    Console.WriteLine("                        ║");
}

void Rules()
{
    Console.Clear();
    logo();
    Console.WriteLine("                ╔═══════╩═══════╗");
    Console.Write("                ║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(" Spielregeln  ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("║\n                ╚═══════════════╝");
    Console.Write("\n  ╔═════════════════════╩══════════════════════╗");
    Console.Write("\n  ║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("    Dass spiel besteht aus 2 Spielern,");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("     ║");
    Console.Write("\n  ║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(" die abwechselnd 1 Bis 3 Stäbchen ziehen. ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(" ║");
    Console.Write("\n  ║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(" Derjenige der dass letzte Stäbchen zieht,");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(" ║");
    Console.Write("\n  ║ ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("   hat dass spiel automatisch verloren.");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("    ║\n  ╠════════════════════════════════════════════╝");
    Console.Write("\n  ╠═[");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\"exit\"");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("]");
    Console.Write("\n  ╚══►");
    Console.ForegroundColor = ConsoleColor.Yellow;
    if (Console.ReadLine()=="exit"){ menu("startscreen");  } else { Rules(); }
}


//danke fürs aufräumen chatgpt