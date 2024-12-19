using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class PyramidGame
{
    private bool isPlayerOneTurn = true;
    private int rows = 0;
    private int moves = 0;
    private List<List<bool>> pyramidState;

    static void Main(string[] args)
    {
        PyramidGame game = new PyramidGame();
        game.StartMenu();
    }

    public void StartMenu()
    {
        while (true)
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
                case "1vs1": StartGame("1v1"); break;
                case "level1": StartGame("level1"); break;
                case "level2": Console.Clear(); Console.WriteLine("Coming soon!"); Thread.Sleep(2000); break;
                case "spielregeln": Rules(); break;
                case "exit": return;
                default: Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen."); Thread.Sleep(2000); break;
            }
        }
    }

    private void StartGame(string mode)
    {
        rows = int.Parse(menu("rows"));
        moves = int.Parse(menu("moves"));
        InitializePyramid(rows);

        while (true)
        {
            DrawPyramid();

            if (mode == "1v1")
            {
                PlayerTurn();
            }
            else if (mode == "level1")
            {
                if (isPlayerOneTurn)
                    PlayerTurn();
                else
                    AITurn();
            }

            if (CheckForWin())
            {
                Console.Clear();
                Console.WriteLine($"Spieler {(isPlayerOneTurn ? 2 : 1)} hat gewonnen!");
                Console.ReadLine();
                return;
            }

            if (--moves <= 0)
            {
                Console.Clear();
                Console.WriteLine("Das Spiel endet unentschieden, da keine Züge mehr übrig sind!");
                Console.ReadLine();
                return;
            }
        }
    }

    private void InitializePyramid(int rows)
    {
        pyramidState = new List<List<bool>>();
        for (int r = 1; r <= rows; r++)
        {
            pyramidState.Add(Enumerable.Repeat(true, r * 2 - 1).ToList());
        }
    }

    private void DrawPyramid()
    {
        Console.Clear();
        string deckenboden = new string('═', rows * 6 - 2);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n   ╔═══╦" + deckenboden + "╗");

        for (int row = 0; row < pyramidState.Count; row++)
        {
            int spaces = rows - row - 1;
            Console.Write("   ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{row + 1,2} ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("║");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(new string(' ', spaces * 3 + 1)); // Leerzeichen links

            for (int i = 0; i < pyramidState[row].Count; i++)
            {
                Console.Write(pyramidState[row][i] ? " ! " : "   ");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(new string(' ', spaces * 3)); // Leerzeichen rechts
            Console.WriteLine(" ║");
        }

        Console.WriteLine("   ╚═══╬" + deckenboden + "╣");

        Console.Write("      ║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int col = 1; col <= pyramidState[^1].Count; col++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{col,3}");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("  ║");
        Console.WriteLine("       ╚" + deckenboden.Substring(0, deckenboden.Length / 2) + "╦" + deckenboden.Substring(0, deckenboden.Length / 2) + "╝");
    }

    private void PlayerTurn()
    {
        Console.WriteLine($"Spieler {(isPlayerOneTurn ? 1 : 2)} ist am Zug.");
        string[] input = menu("coords").Split('-');

        if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int column))
        {
            Console.WriteLine("Ungültige Eingabe! Versuche es erneut.");
            Thread.Sleep(2000);
            return;
        }

        row -= 1;
        column -= 1;

        if (row < 0 || row >= rows || column < 0 || column >= pyramidState[row].Count || !pyramidState[row][column])
        {
            Console.WriteLine("Ungültige Koordinaten! Bitte erneut versuchen.");
            Thread.Sleep(2000);
            return;
        }

        pyramidState[row][column] = false;
        isPlayerOneTurn = !isPlayerOneTurn;
    }

    private void AITurn()
    {
        Console.WriteLine("KI ist am Zug...");
        Thread.Sleep(1000);

        Random rnd = new Random();
        while (true)
        {
            int row = rnd.Next(0, pyramidState.Count);
            int column = rnd.Next(0, pyramidState[row].Count);

            if (pyramidState[row][column])
            {
                pyramidState[row][column] = false;
                break;
            }
        }
        isPlayerOneTurn = !isPlayerOneTurn;
    }

    private bool CheckForWin()
    {
        return pyramidState.All(row => row.All(stick => !stick));
    }

    private string menu(string method)
    {
        if (method == "rows")
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
                if (int.TryParse(Console.ReadLine(), out int rows) && rows >= 3 && rows <= 9)
                {
                    return rows.ToString();
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
        else if (method == "moves")
        {
            Console.Clear();
            while (true)
            {
                Console.Clear();
                logo();
                Console.WriteLine("               ╔════════╩═══════╗");
                Console.Write("               ║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Number of moves ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("║\n               ╚════════╦═══════╝\n                     ╔══╩══╗\n                     ╠═►   ║\n                     ╚═════╝");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(25, Console.CursorTop - 1);
                if (int.TryParse(Console.ReadLine(), out int moves) && moves > 0)
                {
                    return moves.ToString();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Moves must be greater than 0.");
                    Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
            }
        }
        else if (method == "coords")
        {
            Console.WriteLine("Bitte Koordinaten eingeben (Reihe-Spalte): ");
            return Console.ReadLine();
        }
        return "";
    }

    private void Rules()
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
        if (Console.ReadLine() == "exit") { StartMenu(); } else { Rules(); }
    }

    private void logo()
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

    private int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value;
            Console.WriteLine($"Ungültige Eingabe. Bitte eine Zahl zwischen {min} und {max} eingeben.");
        }
    }
}
