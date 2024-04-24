using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class RepairHelicopterScene : Scene
    {
        public RepairHelicopterScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            string header = Utils.FrameText("Repair Helicopter");
            string display = $"{Environment.NewLine}To repair the helicopter, you will require the following resources and 12 Hours:{Environment.NewLine}";
            display += $"{Environment.NewLine}30 Metal{Environment.NewLine}20 Fuel{Environment.NewLine}10 Electrical Components{Environment.NewLine}";

            List<string> options = new List<string>();
            options.Add("Repair Helicopter");
            options.Add("RETURN");


            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    //if has materials and 12 hours remaining, repair helicopter and set repaired=1, and then change "Repair Helicopter" To escape // TO DO //
                    // maybe something about having to leave someone behind if there are more that 7 allies or something.
                    break;
                case 1:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;
            }
        }
        
    }
}
