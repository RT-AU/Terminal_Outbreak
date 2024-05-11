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
using Terminal_Outbreak.Scenes.EquippingScenes;
using Terminal_Outbreak.Scenes.InfoScreens;
using Terminal_Outbreak.Scenes.Trading;

namespace Terminal_Outbreak.Mainframe
{
    internal class TerminalOutbreakGame
    {
        // Declare Objects &
        // Initialise Scenes
        public TitleScene titleScene;
        public BaseScene baseScene;
        public ResupplyScene resupplyScene;
        //Build & Repair Scenes
        public ConstructionChoiceScene constructionChoiceScene;
        public WallMaintenenceScene wallMaintenenceScene;
        public BuildTrapsScene buildTrapsScene;
        public RepairHelicopterScene repairHelicopterScene;
        public AllocateResourcesScene allocateResourcesScene;
        //CombatScenes
        public LongRangeCombatScene longRangeCombatScene;
        public MidRangeCombatScene midRangeCombatScene;
        public CloseQuartersCombatScene closeQuartersCombatScene;

        //Trading Scenes
        public TradeScene tradeScene;
        public TradePrimaryScene tradePrimaryScene;
        public TradeSecondaryScene tradeSecondaryScene;
        public TradeMeleeScene tradeMeleeScene;
        public HireAlliesScene hireAlliesScene;
        //Equipment Scenes
        public EquipmentScene equipmentScene;
        public EquipPrimaryScene equipPrimaryScene;
        public EquipSecondaryScene equipSecondaryScene;
        public EquipMeleeScene equipMeleeScene;
        //Info Scenes
        public WarningScene warningScene;
        public EndingAndCreditsScene endingAndCreditsScene;

        // Initialise Player
        public Player player;

        // Initialise Managers
        public BaseManager baseManager;
        public ResourceManager resourceManager;
        public EnemyManager enemyManager;
        public AlliesManager alliesManager;
        public EquipmentManager equipmentManager;

        public TerminalOutbreakGame() // Constructor
        {
            // Build scenes
            titleScene = new TitleScene(this);

            baseScene = new BaseScene(this);
            resupplyScene = new ResupplyScene(this);
            // Build and Repair Scenes
            constructionChoiceScene = new ConstructionChoiceScene(this);
            wallMaintenenceScene = new WallMaintenenceScene(this);
            buildTrapsScene = new BuildTrapsScene(this);
            repairHelicopterScene = new RepairHelicopterScene(this);
            allocateResourcesScene = new AllocateResourcesScene(this);
            //Combat Scenes
            longRangeCombatScene = new LongRangeCombatScene(this);
            midRangeCombatScene = new MidRangeCombatScene(this);
            closeQuartersCombatScene = new CloseQuartersCombatScene(this);
            // Trading Scenes
            tradeScene = new TradeScene(this);
            tradePrimaryScene = new TradePrimaryScene(this);
            tradeSecondaryScene = new TradeSecondaryScene(this);
            tradeMeleeScene = new TradeMeleeScene(this);
            hireAlliesScene = new HireAlliesScene(this);
            // Equipment Scenes
            equipmentScene = new EquipmentScene(this);
            equipPrimaryScene = new EquipPrimaryScene(this);
            equipSecondaryScene = new EquipSecondaryScene(this);
            equipMeleeScene = new EquipMeleeScene(this);
            //Info Scenes
            warningScene = new WarningScene(this);
            endingAndCreditsScene = new EndingAndCreditsScene(this);

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
            titleScene.Run();
        }



    }
}
