string x1 = "   ═╗ ╔═ ", o1 = "    ╔═╗  ";
string x2 = "    ╚╦╝  ", o2 = "   ╔╝ ╚╗ ";
string x3 = "    ╔╩╗  ", o3 = "   ╚╗ ╔╝ ";
string x4 = "   ═╝ ╚═ ", o4 = "    ╚═╝  ";
bool playagain = true; // erneut spielen funktioniert noch nicht
while (playagain)
{
    playagain = false;
    Console.Clear();
    bool realgame = false, spieler = true, Aiopponent = true;
    int counter = 1, secondcounter = 0, one = 0, two = 3, three = -1, piece = 0, moves = 0, restmoves = 9;
    string[] data = { "1", "2", "3", "4", "5", "6", "7", "8", "9" }, ai = new string[9];
    string aa = " ; ; ; ; ; ; ; ; ";


    string check= menu("menu").ToLower().Replace(" ","").Replace("1vs1", "1").Replace("level1","2");
    if (check == "1" ? Aiopponent = false : Aiopponent = true) ;
    Console.Clear();

    if (menu("startanimation?").ToLower() == "y") //startanmation
    {
        for (int c = 0; c < 13; c++, one = 0, two = 3, counter = 1, secondcounter = 0)
        {
            if (three < 4) { three++; } else { Thread.Sleep(c * 35); }
            if (c < 12)
            {
                Random rnd = new Random();
                for (int t = 0; t < 9; t++)
                {
                    int a = three < 4 ? 1 : rnd.Next(1, 4);
                    switch (a)
                    {
                        case 1: data[t] = "x"; break;
                        case 2: data[t] = "o"; break;
                        case 3: data[t] = " "; break;
                    }
                }
            }
            else
            {
                Thread.Sleep(200);
                data = aa.Split(";");
                realgame = true;
            }
            Console.Clear();
            preprint();
        }
        if (!playagain) { menu("input"); }
    }
    else
    {
        resetvars();
        Console.Clear();
        data = aa.Split(";");
        realgame = true;
        preprint();
    }

    void preprint()
    {
        if (!playagain)
        {
            for (int z = 0; z < 4; z++, one += 3, two += 3, counter = 1)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("╠╬════════════╬════════════╬═══════════╬╣");
                for (int x = 0; x < three; x++, counter += 1)
                {
                    for (int i = one; i < two; i++)
                    {
                        try
                        {
                            piece = i;
                            switch (data[i])
                            {
                                case "x": print("x"); break;
                                case "o": print("o"); break;
                                case " ": print(" "); break;
                            }
                        }
                        catch { break; }
                    }
                }
                if (three < 4) { Thread.Sleep(20); }
            }
            if (realgame && !playagain) { menu("input"); }
        }// wenn es nicht die startaniamtion ist, spieler nach eingabe fragen
    }

    void resetvars()
    {
        one = 0; two = 3; counter = 1; secondcounter = 0; three = 4;
    }

    string menu(string str)
    {
        resetvars();
        switch (str)
        {
            case "input":
                Console.WriteLine(" ╚╦══════╗                 ╚═══╗    ╔══╝");
                Console.WriteLine("  ╠>     ║                 ╔═══╩════╩══╗");
                    Console.Write("  ╚══════╝                 ║ "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(spieler ? "Spieler 1" : "Spieler 2"); Console.ForegroundColor = ConsoleColor.White; Console.Write(" ║\n");
                Console.WriteLine("                           ╚═══════════╝");
            return "";

            case "logo":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
                Console.Write("║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" TTTTT  III  CCCCC TTTTT  AAAAA  CCCCC TTTTT  OOOO  EEEEE");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ║\n");

                Console.Write("║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   T     I   C       T    A   A  C       T   O   O E     ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ║\n");

                Console.Write("║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   T     I   C       T    AAAAA  C       T   O   O EEEE  ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ║\n");

                Console.Write("║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   T     I   C       T    A   A  C       T   O   O E     ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ║\n");

                Console.Write("║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   T    III  CCCCC   T    A   A  CCCCC   T    OOOO  EEEEE");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ║\n");

                Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
                return "";

            case "menu":
                menu("logo");
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
                Console.Write(" ║         ╠═>              ║\n  ║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("     LEVEL 2     ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("║         ╚════════════════╝");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n  ╚══════════════════╝");

                Console.SetCursorPosition(35, Console.CursorTop - 2);
                Console.ForegroundColor = ConsoleColor.Yellow;

            return Console.ReadLine();

            case "startanimation?":
                menu("logo");

                Console.WriteLine("           ╔════════════╩═════════╗");
                Console.WriteLine("  ╔══════════════════╗            ║");
                Console.Write("  ║");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Start-Anim (y/n)");
                //////////////////////////////////
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(" ║         ╔══╩══╗");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Magenta;
                
                Console.Write("\n  ╚══════════════════╝");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("         ╠═>   ║\n");
                Console.Write("                               ╚═════╝");
                Console.ForegroundColor = ConsoleColor.Magenta;
                

                Console.SetCursorPosition(35, Console.CursorTop - 1);
                Console.ForegroundColor = ConsoleColor.Yellow;

            return Console.ReadLine();
        }
        Console.SetCursorPosition(6, 17);
        Console.ForegroundColor = ConsoleColor.Red;

        switch (!spieler && Aiopponent ? AI() : Console.ReadLine())
        {
            case "1": if (data[0] != " ") { wronginput(); break; } data[0] = spieler ? "x" : "o"; moves++; break;
            case "2": if (data[1] != " ") { wronginput(); break; } data[1] = spieler ? "x" : "o"; moves++; break;
            case "3": if (data[2] != " ") { wronginput(); break; } data[2] = spieler ? "x" : "o"; moves++; break;
            case "4": if (data[3] != " ") { wronginput(); break; } data[3] = spieler ? "x" : "o"; moves++; break;
            case "5": if (data[4] != " ") { wronginput(); break; } data[4] = spieler ? "x" : "o"; moves++; break;
            case "6": if (data[5] != " ") { wronginput(); break; } data[5] = spieler ? "x" : "o"; moves++; break;
            case "7": if (data[6] != " ") { wronginput(); break; } data[6] = spieler ? "x" : "o"; moves++; break;
            case "8": if (data[7] != " ") { wronginput(); break; } data[7] = spieler ? "x" : "o"; moves++; break;
            case "9": if (data[8] != " ") { wronginput(); break; } data[8] = spieler ? "x" : "o"; moves++; break;
            default: wronginput(); break;
        }
        
        Console.ForegroundColor = ConsoleColor.White;

        spieler = !spieler;
        checkwin();
        Console.Clear();
        preprint();
        return "";
    }

    void wronginput()
    {
        Console.Clear();

        if (spieler)
        {
            Console.WriteLine("Ungültige eingabe!");
            Thread.Sleep(2000);
            Console.Clear();
        }
        preprint();
    }

    void print(string str)
    {
        secondcounter += 1;

        switch (str)
        {
            case "x":
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ║");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (counter == 1) { Console.Write(x1 + "  "); }
                if (counter == 2) { Console.Write(x2 + "  "); }
                if (counter == 3) { Console.Write(x3 + "  "); }
                if (counter == 4) { Console.Write(x4 + "  "); }
                print("backline");
                break;

            case "o":
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ║");
                Console.ForegroundColor = ConsoleColor.Red;
                if (counter == 1) { Console.Write(o1 + "  "); }
                if (counter == 2) { Console.Write(o2 + "  "); }
                if (counter == 3) { Console.Write(o3 + "  "); }
                if (counter == 4) { Console.Write(o4 + "  "); }
                print("backline");
                break;

            case " ":

                if (counter == 2 && realgame == true)
                {
                    Console.Write(" ║");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"     {piece + 1}     ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write($" ║           ");
                }
                print("backline");
                break;

            case "backline":
                Console.ForegroundColor = ConsoleColor.White;
                secondcounter -= 1;
                if (secondcounter == 3) { secondcounter = 0; Console.Write("║\n"); }
                break;
        }
    }


    void checkwin()
    {
        foreach (string Indicator in new[] { "x", "o" })
        {
            if (data[0] == Indicator && data[1] == Indicator && data[2] == Indicator) { Win(false); break; }
            if (data[3] == Indicator && data[4] == Indicator && data[5] == Indicator) { Win(false); break; }
            if (data[6] == Indicator && data[7] == Indicator && data[8] == Indicator) { Win(false); break; }

            if (data[0] == Indicator && data[3] == Indicator && data[6] == Indicator) { Win(false); break; }
            if (data[1] == Indicator && data[4] == Indicator && data[7] == Indicator) { Win(false); break; }
            if (data[3] == Indicator && data[5] == Indicator && data[8] == Indicator) { Win(false); break; }

            if (data[0] == Indicator && data[4] == Indicator && data[8] == Indicator) { Win(false); break; }
            if (data[2] == Indicator && data[4] == Indicator && data[6] == Indicator) { Win(false); break; }
        }
        if (moves == 9) { Win(true); }
    }
    void Win(bool unentschieden)
    {
        if (!playagain)
        {
            string c = "        ║ ";
            Console.Clear();
            realgame = false;
            preprint();
            Console.WriteLine("       ╠╬═════╩════════════╩═════╬╣");
            Console.WriteLine(unentschieden ? "        ║ " + "    Unentschieden!" + "     ║" : (!spieler ? "        ║ " + "Spieler 1 hat gewonnen" + " ║" : "        ║ " + "Spieler 2 hat gewonnen" + " ║"));
            Console.WriteLine("       ╠╬════════════════════════╬╣");
            Console.ReadLine();
            Console.Clear();
            playagain = true;
        }
    }

    string AI()
    {
        ai = new string[restmoves - 1];
        Random rnd = new Random();
        for (int aa = 0, bb = 0; aa < 9; aa++) //nach leeren stellen für den zufallsgenerator suchen
        {
            if (data[aa] != "x" && data[aa] != "o") { ai[bb] = (aa + 1).ToString(); bb++; }
        }
        restmoves -= 2;
        return ai[rnd.Next(0, ai.Length)];
    }
}
//spielende
