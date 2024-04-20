using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class CreditScene : Scene 
    {
        public CreditScene(TerminalOutbreakGame game) : base (game) 
        { 

        }

        public override void Run()
        {
            Console.Clear();
            Console.WriteLine(terminalOutbreakGame.player.GetName()) ;
        }
    }
}
