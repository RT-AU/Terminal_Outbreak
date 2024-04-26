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
using Terminal_Outbreak.Scenes.Trading;

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
        public AllocateResourcesScene allocateResourcesScene;
        public LongRangeCombatScene longRangeCombatScene;
        public MidRangeCombatScene midRangeCombatScene;
        public CloseQuartersCombatScene closeQuartersCombatScene;
        public TradeScene tradeScene;
        public TradePrimaryScene tradePrimaryScene;
        public TradeSecondaryScene tradeSecondaryScene;
        public TradeMeleeScene tradeMeleeScene;
        public HireAlliesScene hireAlliesScene;

        // Initialise Player
        public Player player;

        // Initialise Managers
        public BaseManager baseManager;
        public ResourceManager resourceManager;
        public EnemyManager enemyManager;
        public AlliesManager alliesManager;
        public EquipmentManager equipmentManager;

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
            allocateResourcesScene = new AllocateResourcesScene(this);
            longRangeCombatScene = new LongRangeCombatScene(this);
            midRangeCombatScene = new MidRangeCombatScene(this);
            closeQuartersCombatScene = new CloseQuartersCombatScene(this);
            tradeScene = new TradeScene(this);
            tradePrimaryScene = new TradePrimaryScene(this);
            tradeSecondaryScene = new TradeSecondaryScene(this);
            tradeMeleeScene = new TradeMeleeScene(this);
            hireAlliesScene = new HireAlliesScene(this);

            // Create Player Instance
            player = new Player();

            // Create Manager Instances
            baseManager = new BaseManager();
            resourceManager = new ResourceManager();
            enemyManager = new EnemyManager();
            alliesManager = new AlliesManager();
            equipmentManager = new EquipmentManager();
        }

        public void Start() // Run the game
        {
            baseScene.Run();
        }



    }
}
