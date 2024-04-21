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
        public BaseScene baseScene;
        public ResupplyScene resupplyScene;
        //public RepairScene repairScene;

        public BaseManager baseManager;
        public ResourceManager resourceManager;

        public TerminalOutbreakGame()
        {
            titleScene = new TitleScene(this);
            creditScene = new CreditScene(this);
            baseScene = new BaseScene(this);
            resupplyScene = new ResupplyScene(this);

            player = new Player();

            baseManager = new BaseManager();
            resourceManager = new ResourceManager();
        }

        public void Start()
        {
            baseScene.Run();
        }



    }
}
