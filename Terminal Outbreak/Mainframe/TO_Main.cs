using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Mainframe
{
    class TO_Main
    {

        static void Main(string[] args)
        {
            Console.Title = "Terminal Outbreak: Outlive The Undead";
            Console.CursorVisible = false;

            TerminalOutbreakGame terminalOutbreakGame = new TerminalOutbreakGame();
            terminalOutbreakGame.Start();

        }





    }
}
