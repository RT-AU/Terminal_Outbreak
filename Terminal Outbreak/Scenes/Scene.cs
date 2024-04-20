using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class Scene
    {
        protected TerminalOutbreakGame terminalOutbreakGame;
        public Scene(TerminalOutbreakGame game)
        {
            terminalOutbreakGame = game;
        }

        virtual public void Run()
        {
            
        }
    }
}
