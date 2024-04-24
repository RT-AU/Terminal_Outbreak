using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class ConstructionChoiceScene : Scene
    {

        public ConstructionChoiceScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {

            string header = Utils.FrameText("Construction Options");
            string display = $"{Environment.NewLine}Would you like to construct or repair a barrier, install traps, or repair the helicopter?{Environment.NewLine}";

            List<string> options = new List<string>();
            options.Add("Construct/Repair Barrier Wall");
            options.Add("Install Traps");
            options.Add("Repair Helicopter");   
            options.Add("RETURN");

            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.wallMaintenenceScene.Run();
                    break;
                case 1:
                    terminalOutbreakGame.buildTrapsScene.Run();
                    break;
                case 2:
                    terminalOutbreakGame.repairHelicopterScene.Run();
                    break;
                case 3:
                    terminalOutbreakGame.baseScene.Run();
                    break;

            }

        }
    }
}