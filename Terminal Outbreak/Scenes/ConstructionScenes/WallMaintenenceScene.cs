using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.ConstructionScenes
{
    internal class WallMaintenenceScene : Scene
    {
        public WallMaintenenceScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            string header = Utils.FrameText("Construction Options");
            string display = Utils.WrapText($"{Environment.NewLine}You can construct a wall to keep the Zombies from advancing beyond long range until they destroy it. Construction will cose 20 Wood and will take 6 hours to complete.{Environment.NewLine}");
            
            List<string> options = new List<string>();
            options.Add("Construct Barrier Wall");
            options.Add("RETURN");


            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    // TO DO //
                    // does player have 20 wood? if so, build wall, reduce time by 6 hours 
                    // set wallBuilt = 1, change Construct Wall to Repair Wall, and change display to would you like to repair barrier wall 2 hours, (5 wood)
                    break;
                case 1:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;

            }
        }
    }
}
