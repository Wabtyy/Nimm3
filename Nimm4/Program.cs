bool spieler = true;
 int bodendecke = 0;
 int moves = 0;
 int remainingSticks3 = 0;
 int rows = 0;
 int rndout;
 int rndoutt;
 int rounds;
 
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
     if (moves != 0)
     {
         if (mode == "1vs1")
         {
             menu("coords");
             split = Console.ReadLine().Split("-");
             int.TryParse(split[0], out int selectedRow); selectedRow -= 1;
             int.TryParse(split[1], out int globalColumn); globalColumn -= 1;
             int rowStartColumn = pyramidState.Count - 1 - selectedRow; // Startposition der Zeile im globalen Koordinatensystem
             int rowEndColumn = rowStartColumn + pyramidState[selectedRow].Count - 1;
             int localColumn = globalColumn - rowStartColumn;
 
             try
             {
                 if (!pyramidState[selectedRow][localColumn])
                 {
                 }
                 else
                 {
                     pyramidState[selectedRow][localColumn] = false;
                 }
             }
             catch
             {
             }
         }
         else if (mode == "level1")
         {
             if (!spieler)
             {
                 menu("coords");
 
                 try
                 {
                     split = Console.ReadLine().Split("-");
                 }
                 catch
                 {
 
                 }
 
             }
             else
             {
                 Random rnd = new Random();
                 rounds = rnd.Next(1, 4);
 
                 while (rounds > -1)
                 {
                     int remainingSticks = 0;
                     foreach (var row in pyramidState)
                     {
                         remainingSticks += row.Count(stick => stick);
                     }
 
                     if (remainingSticks == 1) // Wenn nur noch ein Stäbchen übrig ist
                     {
                         for (int r = 0; r < pyramidState.Count; r++)
                         {
                             for (int c = 0; c < pyramidState[r].Count; c++)
                             {
                                 if (pyramidState[r][c]) // Das letzte Stäbchen entfernen
                                 {
                                     pyramidState[r][c] = false;
                                     spieler = false; // Zug beenden
                                     return;
                                 }
                             }
                         }
                     }
                     //generiert: {1-3}-{1-3}
                     rndout = rnd.Next(1, rows + 1);
                     rndoutt = rnd.Next(1, pyramidState[^1].Count + 1);
 
                     try
                     {
                         if (pyramidState[rndout][rndoutt] == true)
                         {
                             pyramidState[rndout][rndoutt] = false;
                             rounds--;
                         }
                     }
                     catch
                     {
 
                     }
                 }
                 string deckenboden = new string('═', bodendecke + 1);
                 spieler = false; DrawPyramid(rows, deckenboden); ShowTip(); menu("moves"); RemoveStick("level1");
             }
         }
         if (!spieler)
         {
             int.TryParse(split[0], out int selectedRow); selectedRow -= 1;
             int.TryParse(split[1], out int globalColumn); globalColumn -= 1;
             int rowStartColumn = pyramidState.Count - 1 - selectedRow; // Startposition der Zeile im globalen Koordinatensystem
             int rowEndColumn = rowStartColumn + pyramidState[selectedRow].Count - 1;
             int localColumn = globalColumn - rowStartColumn;
 
             try
             {
                 if (!pyramidState[selectedRow][localColumn])
                 {
                 }
                 else
                 {
                     pyramidState[selectedRow][localColumn] = false;
                 }
             }
             catch
             {
             }
         }
     }
     else
     {
         Console.ForegroundColor = ConsoleColor.Yellow;
         if (spieler)
         {
             Console.WriteLine(new string(' ', bodendecke / 2 - 1) + "Spieler 1");
             ShowTip();
             spieler = false;
             menu("moves");
         }
         else
         {
             if (mode == "level1")
             {
                 Console.WriteLine(new string(' ', bodendecke / 2 - 1) + "Spieler 2");
                 spieler = true;
             }
             else
             {
                 Console.WriteLine(new string(' ', bodendecke / 2 - 1) + "Spieler 2");
                 spieler = true;
                 ShowTip();
                 menu("moves");
             }
         }
     }
     moves--;
 }
 
 
 
 
 
 
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
 void ShowTip()
 {
     remainingSticks3 = 0;
 
     foreach (var row in pyramidState)
     {
         remainingSticks3 += row.Count(stick => stick);
     }
 
     Console.ForegroundColor = ConsoleColor.Yellow;
     if (remainingSticks3 < 5 && remainingSticks3 != 0)
     {
         Console.WriteLine($"{new string(' ', bodendecke / 2 - 1)} Tipp: mache {remainingSticks3 - 1} Züge");
     }
     else
     {
         Console.WriteLine($"{new string(' ', bodendecke / 2 - 1)} Tipp: mache 3 Züge");
     }
 }
 
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
 
     if (spieler)
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
         try
         {
             switch (Console.ReadLine()?.ToLower().Replace(" ", ""))
             {
                 case "1vs1": Game("1vs1"); break;
                 case "level1": Game("level1"); break;
                 case "level2": Console.Clear(); Console.WriteLine("Coming soon!"); Thread.Sleep(2000); menu("startscreen"); break;
                 case "spielregeln": Rules(); break;
             }
             return "";
         }
         catch
         {
 
         }
 
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
            
             int abc = 0;
             try
             {
                 int abc = int.Parse(Console.ReadLine());
                 abc = int.Parse(Console.ReadLine());
             }
             catch
             {
 
             }
 
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
         int outp = 0;
         try
         {
             outp = int.Parse(Console.ReadLine());
         }
         catch
         {
 
         }
 
         if (outp > 3 || outp < 1)
         {
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.Red;
             Console.WriteLine("Die ausgewählte zahl darf nicht größer als 3, oder kleiner als 1 sein!");
             Thread.Sleep(2500);
         }
         else
         {
             moves = outp + 1;
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
 
