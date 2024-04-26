using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.Trading
{
    internal class TradeScene : Scene
    {

        public TradeScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            string header = Utils.FrameText("Mysterious Trader");
            string display = Utils.WrapText($"{Environment.NewLine}You happen across someone with excellent connections, who claims the only thing he won't supply is his name. He's got an array of weapons for sale, and also knows some other survivors who'd be happy to join you if you agree to provide them with food.{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("Browse Primary Weapons");
            options.Add("Browse Secondary Weapons");
            options.Add("Browse Melee Weapons");
            options.Add("Hire Allies");
            options.Add("RETURN");

            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.tradePrimaryScene.Run();
                    break;
                case 1:
                    terminalOutbreakGame.tradeSecondaryScene.Run();
                    break;
                case 2:
                    terminalOutbreakGame.tradeMeleeScene.Run();
                    break;
                case 3:
                    terminalOutbreakGame.hireAlliesScene.Run();
                    break;
                case 4:
                    terminalOutbreakGame.baseScene.Run();
                    break;
            }
        }


    }
}
