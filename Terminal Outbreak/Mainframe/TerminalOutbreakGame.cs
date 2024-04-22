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
        // Initialise Scenes
        public TitleScene titleScene;
        public CreditScene creditScene;
        public BaseScene baseScene;
        public ResupplyScene resupplyScene;
        public ConstructionChoiceScene constructionChoiceScene;
        public WallMaintenenceScene wallMaintenenceScene;
        public BuildTrapsScene buildTrapsScene;
        public RepairHelicopterScene repairHelicopterScene;

        // Initialise Player
        public Player player;

        // Initialise Managers
        public BaseManager baseManager;
        public ResourceManager resourceManager;

        public TerminalOutbreakGame()
        {
            // Build scenes
            titleScene = new TitleScene(this);
            creditScene = new CreditScene(this);
            baseScene = new BaseScene(this);
            resupplyScene = new ResupplyScene(this);
            constructionChoiceScene = new ConstructionChoiceScene(this);
            wallMaintenenceScene = new WallMaintenenceScene(this);
            buildTrapsScene = new BuildTrapsScene(this);
            repairHelicopterScene = new RepairHelicopterScene(this);

            // Create Player Instance
            player = new Player();

            // Create Manager Instances
            baseManager = new BaseManager();
            resourceManager = new ResourceManager();
        }

        public void Start() // Run the game
        {
            baseScene.Run();
        }



    }
}
