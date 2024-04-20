using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Scenes;

namespace Terminal_Outbreak.Mainframe
{
    internal class TerminalOutbreakGame
    {
        public Player player;
        public TitleScene titleScene;
        public CreditScene creditScene;

        public TerminalOutbreakGame()
        {
            titleScene = new TitleScene(this);
            creditScene = new CreditScene(this);
            player = new Player();
        }

        public void Start()
        {
            titleScene.Run();
        }



    }
}
