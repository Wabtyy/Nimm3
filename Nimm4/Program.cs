bool spieler = true;
int bodendecke = 0;
int moves = 0;
int rows = 0;
string[] split = null;
List<List<bool>> pyramidState = null;
menu("startscreen");
void Game(string mode)
{
    rows = int.Parse(menu("rows"));
    Console.Clear();
    int spaces = rows;
    bodendecke = spaces * 6 - 2;
    string deckenboden = new string('═', bodendecke + 1);
    Console.ForegroundColor = ConsoleColor.Magenta;
    pyramidState = new List<List<bool>>();
    //pyramide aufbauen
    for (int r = 1; r <= rows; r++)
    {
        pyramidState.Add(new List<bool>());
        for (int i = 0; i < r * 2 - 1; i++)
        {
            pyramidState[r - 1].Add(true); // Alle Positionen aktivieren
        }
    }
    while (true)
    {
        DrawPyramid(rows, deckenboden);
        RemoveStick(mode);
        Check4Win();
    }
}
void DrawPyramid(int rows, string deckenboden)
{
    Console.Clear();
    int spaces = rows;
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("\n   ╔═══╦" + deckenboden + "╗");
    for (int row = 0; row < pyramidState.Count; row++)
    {
        spaces--;
        Console.Write("\n");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("   ║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{row + 1,2} ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(new string(' ', spaces * 3 + 1)); // Leerzeichen links
        for (int i = 0; i < pyramidState[row].Count; i++)
        {
            //Thread.Sleep(row * 4);
            Console.Write(pyramidState[row][i] ? " | " : "   "); // "!" oder Leerzeichen 
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string(' ', spaces * 3)); // Leerzeichen rechts
        Console.Write(" ║");
    }
    Console.WriteLine("\n   ╚═══╬" + deckenboden + "╣");
    // Koordinaten anzeigen
    Console.Write("      ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(" ║");
    Console.ForegroundColor = ConsoleColor.Yellow;
    for (int col = 1; col <= pyramidState[^1].Count; col++) //zählt die stäbchen in der letzen reihe
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"{col,3}");
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("  ║");
    Console.WriteLine("\n       ╚" + deckenboden.Substring(0, deckenboden.Length / 2) + "╦" + deckenboden.Substring(0, deckenboden.Length / 2) + "╝");
}
void RemoveStick(string mode)
{
    if (moves <= 0) // Keine Züge mehr übrig
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Keine Züge mehr übrig. Spielerwechsel!");
        spieler = !spieler; // Spieler wechseln

        // Spieler auffordern, die Anzahl der Züge einzugeben
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(spieler ? "Spieler 1 ist an der Reihe." : "Spieler 2 ist an der Reihe.");
        menu("moves"); // Eingabe der Anzahl der Züge
        Console.Clear();
        DrawPyramid(rows, new string('═', bodendecke + 1)); // Aktualisieren der Pyramide
        return;
    }

    Console.Clear();
    if (mode == "1vs1")
    {
        menu("coords");
        string[] split = Console.ReadLine()?.Split("-");

        if (split == null ||
            split.Length != 2 ||
            !int.TryParse(split[0], out int selectedRow) ||
            !int.TryParse(split[1], out int globalColumn))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ungültige Eingabe! Bitte geben Sie Koordinaten in der Form 'Reihe-Spalte' ein.");
            Thread.Sleep(2000);
            return;
        }

        selectedRow -= 1; // Anpassung der Indizes
        globalColumn -= 1;

        if (selectedRow < 0 || selectedRow >= pyramidState.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ungültige Reihe. Bitte innerhalb des gültigen Bereichs bleiben.");
            Thread.Sleep(2000);
            return;
        }

        // Berechnung des Startwerts der globalen Spaltennummer für die gewählte Reihe
        int startGlobalColumn = 0;
        for (int i = 0; i < selectedRow; i++)
        {
            startGlobalColumn += pyramidState[i].Count;
        }

        int localColumn = globalColumn - startGlobalColumn;

        if (localColumn < 0 || localColumn >= pyramidState[selectedRow].Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ungültige Spalte. Bitte innerhalb des gültigen Bereichs bleiben.");
            Thread.Sleep(2000);
            return;
        }

        if (!pyramidState[selectedRow][localColumn])
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Diese Position ist bereits leer!");
            Thread.Sleep(2000);
            return;
        }

        // Stäbchen entfernen
        pyramidState[selectedRow][localColumn] = false;
        moves--; // Züge reduzieren
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Stäbchen entfernt! Verbleibende Züge: {moves}");

        if (moves <= 0) // Spielerwechsel
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Keine Züge mehr übrig. Spielerwechsel!");
            Thread.Sleep(2000);
            Console.Clear();
            DrawPyramid(rows, new string('═', bodendecke + 1));
            spieler = !spieler; // Spieler wechseln

            menu("moves"); // Eingabe der Anzahl der Züge
            Console.Clear();
        }

        DrawPyramid(rows, new string('═', bodendecke + 1)); // Aktualisieren der Pyramide
    }
    else if (mode == "level1")
    {
        // Logik für den Computer bleibt gleich
        if (!spieler) // Spieler 2 (Mensch)
        {
            menu("coords");
            string[] split = Console.ReadLine()?.Split("-");

            if (split == null ||
                split.Length != 2 ||
                !int.TryParse(split[0], out int selectedRow) ||
                !int.TryParse(split[1], out int globalColumn))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe! Bitte geben Sie Koordinaten in der Form 'Reihe-Spalte' ein.");
                Thread.Sleep(2000);
                return;
            }

            selectedRow -= 1;
            globalColumn -= 1;

            if (selectedRow < 0 || selectedRow >= pyramidState.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Reihe. Bitte innerhalb des gültigen Bereichs bleiben.");
                Thread.Sleep(2000);
                return;
            }

            int startGlobalColumn = 0;
            for (int i = 0; i < selectedRow; i++)
            {
                startGlobalColumn += pyramidState[i].Count;
            }

            int localColumn = globalColumn - startGlobalColumn;

            if (localColumn < 0 || localColumn >= pyramidState[selectedRow].Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Spalte. Bitte innerhalb des gültigen Bereichs bleiben.");
                Thread.Sleep(2000);
                return;
            }

            if (!pyramidState[selectedRow][localColumn])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Diese Position ist bereits leer!");
                Thread.Sleep(2000);
                return;
            }

            pyramidState[selectedRow][localColumn] = false;
            moves--; // Züge reduzieren
        }
        else // Computer (Spieler 1)
        {
            // Computer-Logik bleibt unverändert
            Random rnd = new Random();
            while (true)
            {
                int selectedRow = rnd.Next(0, pyramidState.Count);
                int localColumn = rnd.Next(0, pyramidState[selectedRow].Count);

                if (pyramidState[selectedRow][localColumn])
                {
                    pyramidState[selectedRow][localColumn] = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Computer entfernt Stäbchen in Reihe {selectedRow + 1}, Spalte {localColumn + 1}.");
                    break;
                }
            }

            moves--; // Züge reduzieren
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Verbleibende Züge: {moves}");

        if (moves <= 0) // Spielerwechsel
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Keine Züge mehr übrig. Spielerwechsel!");
            spieler = !spieler; // Spieler wechseln
            menu("moves"); // Eingabe der Anzahl der Züge
            Console.Clear();
        }
        Check4Win();
        DrawPyramid(rows, new string('═', bodendecke + 1)); // Aktualisieren der Pyramide
    }
}




/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void Check4Win()
{
    foreach (var row in pyramidState)
    {
        if (row.Contains(true))
        {
            return;
        }
    }
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    if (!spieler)
    {
        Console.WriteLine("Spieler 2 hat gewonnen!");
    }
    else
    {
        Console.WriteLine("Spieler 1 hat gewonnen!");
    }
    Console.ReadLine();
    menu("startscreen");
}
string menu(string method)
{
    if (method == "startscreen")
    {
        Console.Clear();
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
            case "1vs1": Game("1vs1"); break;
            case "level1": Game("level1"); break;
            case "level2": Console.Clear(); Console.WriteLine("Coming soon!"); Thread.Sleep(2000); menu("startscreen"); break;
            case "spielregeln": Rules(); break;
        }
        return "";
    }
    else if (method == "rows")
    {
        Console.Clear();
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
            if (abc > 2 && abc < 10)
            {
                return abc.ToString();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rows cannot be less than 3, or greater than 9");
                Thread.Sleep(2500);
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
    }
    else if (method == "coords")
    {
        string deckenboden = new string('═', bodendecke + 1);
        DrawPyramid(rows, deckenboden);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string(' ', deckenboden.Length / 2) + "╔═══════╩═══════╗\n" + new string(' ', deckenboden.Length / 2) + "║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Select coords ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║\n" + new string(' ', deckenboden.Length / 2) + "╚═══════╦═══════╝\n   ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string(' ', deckenboden.Length / 2) + "╔════╩════╗\n  " + new string(' ', deckenboden.Length / 2) + " ╠═► ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("      ║\n" + new string(' ', deckenboden.Length / 2 + 3) + "╚═════════╝\n   ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(deckenboden.Length / 2 + 7, Console.CursorTop - 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else if (method == "moves")
    {
        string deckenboden = new string('═', bodendecke + 1);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string(' ', deckenboden.Length / 2 - 1) + "╔════════╩════════╗\n" + new string(' ', deckenboden.Length / 2 - 1) + "║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Number of Moves ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║\n" + new string(' ', deckenboden.Length / 2 - 1) + "╚════════╦════════╝\n   ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(new string(' ', deckenboden.Length / 2 + 2) + "╔══╩══╗\n  " + new string(' ', deckenboden.Length / 2 + 2) + " ╠► ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("   ║\n" + new string(' ', deckenboden.Length / 2 + 5) + "╚═════╝\n   ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(deckenboden.Length / 2 + 8, Console.CursorTop - 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        int outp = int.Parse(Console.ReadLine());
        if (outp > 3 || outp < 1)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Die ausgewählte zahl darf nicht größer als 3, oder kleiner als 1 sein!");
            Thread.Sleep(2500);
        }
        else
        {
            moves = outp;
            Console.Clear();
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
    if (Console.ReadLine() == "exit") { menu("startscreen"); } else { Rules(); }
}
//danke fürs aufräumen chatgpt :)
