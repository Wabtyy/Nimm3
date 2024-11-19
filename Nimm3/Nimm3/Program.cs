using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;



menu("startscreen");

void Game()
{
    int rows = int.Parse(menu("rows"));
    Console.Clear();
    int stäbchen = -1;
    int spaces = rows; 

    int spacesbackup=spaces;
    int stäbchenbackup = stäbchen;
    int rowsbackup=rows;
    int stäbchencounter=stäbchen;
    int spacescounter = spaces;
    int bodendecke = 0;
    int Animation = 10;

    string SPC="";
    string deckenboden = "";
    bodendecke= spacesbackup*4+4;
    while (bodendecke > 1)
    {
        bodendecke--;
        deckenboden += "═";
    }
    Console.ForegroundColor = ConsoleColor.Magenta;


    while (rowsbackup != 0)
    {

        spacescounter--;
        spacesbackup = spacescounter;

        rowsbackup--;

        stäbchencounter += 2;
        stäbchenbackup = stäbchencounter;

        Console.ForegroundColor = ConsoleColor.Magenta;
        if(stäbchencounter==1)
        {

            Console.WriteLine("       ╔" + deckenboden + "╗");
        }
        else
        {
            Console.WriteLine("");
        }

        Console.Write("       ║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        while (spacesbackup > -1)
        {
            spacesbackup--;
            Console.Write(" ");
            Console.Write(" ");
            
        }

        while (stäbchenbackup != 0)
        {
            stäbchenbackup--;
            Animation += 1;
            Console.Write(" ");
            Console.Write("!");
            Thread.Sleep(Animation);
        }
        Console.ForegroundColor = ConsoleColor.Magenta;
        spacesbackup = spacescounter;
        while (spacesbackup > -1)
        {
            spacesbackup--;
            Console.Write(" ");
            Console.Write(" ");

        }

        Console.Write(SPC+" ║");
    }
    Console.WriteLine("");
    Console.WriteLine("       ╚" + deckenboden + "╝");
}



 

























string menu(string method)
{
    Console.Clear();
    if (method == "startscreen")
    {
        #region design
        logo();
        Console.WriteLine("           ╔════════════╩══════════════╗");
        Console.WriteLine("  ╔══════════════════╗                 ║");
        Console.Write("  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("      1VS1      ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" ║         ╔═══════╩════════╗");
        Console.WriteLine("");
        Console.Write("  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("     LEVEL 1    ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(" ║         ╠═►              ║");
        Console.WriteLine("");
        Console.Write("  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("     LEVEL 2     ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║         ╚════════════════╝");
        Console.WriteLine("");
        Console.Write("  ║ ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("   SPIELREGELN   ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("║");
        Console.WriteLine("");
        Console.Write("  ╚══════════════════╝");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(35, Console.CursorTop - 3);

        switch (Console.ReadLine()?.ToLower().Replace(" ", ""))
        {
            case "1vs1": break;

            case "level1": Game(); break;

            case "level2": Game(); break;

            case "spielregeln": Rules(); break;
        }
        return "";
    }
    else if(method=="rows")
    { bool repeat = true;
        while (repeat)
        {
            Console.Clear();
            logo();

            Console.WriteLine("               ╔════════╩═══════╗");
            Console.Write("               ║ "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(""); Console.Write("Number of rows "); Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("║");
            Console.WriteLine("");
            Console.WriteLine("               ╚════════╦═══════╝");
            Console.WriteLine("                     ╔══╩══╗");
            Console.WriteLine("                     ╠═►   ║");
            Console.WriteLine("                     ╚═════╝");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, Console.CursorTop - 2);
            int abc = int.Parse(Console.ReadLine());
            if (abc > 2)
            {
                repeat = false;
                return abc.ToString();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rows cannot be less then 3.");
                Thread.Sleep(2500);
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
    }
    #endregion
    return "";



}
void logo()
{
    Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("╔════════════════════════════════════════════════╗"); Console.Write("║ "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("███╗  ██╗██╗███╗   ███╗███╗   ███╗    ██████╗ "); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" ║");

    Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("║ "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("████╗ ██║██║████╗ ████║████╗ ████║    ╚════██╗"); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" ║"); Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("║ ");

    Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("██╔██╗██║██║██╔████╔██║██╔████╔██║     █████╔╝"); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" ║");

    Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("║ "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("██║╚████║██║██║╚██╔╝██║██║╚██╔╝██║     ╚═══██╗"); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" ║");

    Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("║ "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("██║ ╚███║██║██║ ╚═╝ ██║██║ ╚═╝ ██║    ██████╔╝"); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" ║");

    Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("║ "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("╚═╝  ╚══╝╚═╝╚═╝     ╚═╝╚═╝     ╚═╝    ╚═════╝ "); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine(" ║");

    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("╚════════════════════════════════════════════════╝");
    Console.WriteLine("                        ║");
}
void Rules()
{
    Console.Clear();
}