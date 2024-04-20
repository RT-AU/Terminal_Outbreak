using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Managers;
using Terminal_Outbreak.Scenes;

namespace Terminal_Outbreak.Mainframe
{
    internal class TerminalOutbreakGame
    {
        public Player player;
        public TitleScene titleScene;
        public CreditScene creditScene;
        public DayScene dayScene;

        public BaseManager baseManager;

        public TerminalOutbreakGame()
        {
            titleScene = new TitleScene(this);
            creditScene = new CreditScene(this);
            dayScene = new DayScene(this);
            baseManager = new BaseManager();
            player = new Player();
        }

        public void Start()
        {
            dayScene.Run();
        }



    }
}
