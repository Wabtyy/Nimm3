menu("startscreen");

void Game()
{
    int rows = int.Parse(menu("rows"));
    Console.Clear();
                                                 
    int stäbchen = -1, //damit in der ersten reihe einer und in der dritte 3 gestzen werden
    spaces = rows, 
    bodendecke = spaces * 4 - 1,   //frag mich einfach nicht was die rechnung bewirkt, aber es klappt :)
    Animation = 10; 

    string deckenboden = new string('═', bodendecke); 

    Console.ForegroundColor = ConsoleColor.Magenta;

    while (rows > 0)
    {
        spaces--;
        stäbchen += 2;
        rows--;

        if (stäbchen == 1) Console.WriteLine("       ╔" + deckenboden + "╗");
        else Console.WriteLine("");

        Console.Write("       ║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(new string(' ', spaces * 2)); //füllt links von den "!" alles mit leerzeichen, so dass die "║" in einer reihe sind.

        for (int i = 0; i < stäbchen; i++)
        {
            Console.Write(" !");
            Thread.Sleep(rows > 8 ? (Animation / 2) / (rows / 2) : Animation * 2);
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string(' ', spaces * 2) + " ║");//füllt rechts von den "!" alles mit leerzeichen, so dass die "║" in einer reihe sind.
    }
    Console.WriteLine("\n       ╚" + deckenboden + "╝");
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
            if (abc > 2 && abc < 26) return abc.ToString();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rows cannot be less than 3, or greater than 25");
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
    Console.WriteLine("╚════════════════════════════════════════════════╝");
    Console.WriteLine("                        ║");
}

void Rules() => Console.Clear();


//danke fürs aufräumen chatgpt