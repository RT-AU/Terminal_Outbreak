using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Managers;
using Terminal_Outbreak.Scenes;
using Terminal_Outbreak.Scenes.CombatScenes;
using Terminal_Outbreak.Scenes.ConstructionScenes;
using Terminal_Outbreak.Scenes.InfoScreens;

namespace Terminal_Outbreak.Mainframe
{
    internal class TerminalOutbreakGame
    {
        // Initialise Scenes
        public TitleScene titleScene;
        public CreditsScene creditScene;
        public BaseScene baseScene;
        public ResupplyScene resupplyScene;
        public ConstructionChoiceScene constructionChoiceScene;
        public WallMaintenenceScene wallMaintenenceScene;
        public BuildTrapsScene buildTrapsScene;
        public RepairHelicopterScene repairHelicopterScene;
        public LongRangeCombatScene longRangeCombatScene;
        public MidRangeCombatScene midRangeCombatScene;
        public CloseQuartersCombatScene closeQuartersCombatScene;

        // Initialise Player
        public Player player;

        // Initialise Managers
        public BaseManager baseManager;
        public ResourceManager resourceManager;
        public EnemyManager enemyManager;

        public TerminalOutbreakGame()
        {
            // Build scenes
            titleScene = new TitleScene(this);
            creditScene = new CreditsScene(this);
            baseScene = new BaseScene(this);
            resupplyScene = new ResupplyScene(this);
            constructionChoiceScene = new ConstructionChoiceScene(this);
            wallMaintenenceScene = new WallMaintenenceScene(this);
            buildTrapsScene = new BuildTrapsScene(this);
            repairHelicopterScene = new RepairHelicopterScene(this);
            longRangeCombatScene = new LongRangeCombatScene(this);
            midRangeCombatScene = new MidRangeCombatScene(this);
            closeQuartersCombatScene = new CloseQuartersCombatScene(this);

            // Create Player Instance
            player = new Player();

            // Create Manager Instances
            baseManager = new BaseManager();
            resourceManager = new ResourceManager();
            enemyManager = new EnemyManager();
        }

        public void Start() // Run the game
        {
            baseScene.Run();
        }



    }
}
