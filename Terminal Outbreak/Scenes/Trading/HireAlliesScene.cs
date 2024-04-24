using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.Trading
{
    internal class HireAlliesScene : Scene
    {
        private bool isabellaHired = false;
        private bool stevenHired = false;
        private bool nateHired = false;
        private bool mayaHired = false;

        public HireAlliesScene(TerminalOutbreakGame game) : base(game)
        {

        }


        public override void Run()
        {
            int isabellaHireCost = 5;
            int stevenHireCost = 5;
            int nateHireCost = 10;
            int mayaHireCost = 10;

            string header = Utils.FrameText("Hire Allies");
            string display = Utils.WrapText($"Who would you like to hire? Note that every Ally will consume 1 extra food ration a day, but will help in combat.");

            display += terminalOutbreakGame.alliesManager.HireAlliesReadout(isabellaHired, stevenHired, nateHired, mayaHired);
            display += Environment.NewLine;


            List<string> options = new List<string>();
            if (!isabellaHired) { options.Add($"Isabella \"Sheriff\" Barrett - Hire Fee: {isabellaHireCost} Rations"); }
            if (!stevenHired) { options.Add($"Steven \"Boomstick\" Adams - Hire Fee: {stevenHireCost} Rations"); }
            if (!nateHired) { options.Add($"Nathaniel \"Timmy\" Thomson - Hire Fee: {nateHireCost} Rations"); }
            if (!mayaHired) { options.Add($"Maya \"Valkyrie\" Carter - Hire Fee: {mayaHireCost} Rations"); }
            options.Add($"RETURN");

            if (options.Count == 1)
            {
                display = Utils.WrapText($"{Environment.NewLine}There is no one else available to hire!{Environment.NewLine}");
            }

            Menu resupplyResultsMenu = new Menu(display, options, header);
            string selectedOption= resupplyResultsMenu.RunRemovable(options);
            int selectedIndex = 5;
            if(selectedOption.Contains("Isabella")) { selectedIndex = 0; }
            if(selectedOption.Contains("Steven")) { selectedIndex = 1; }
            if(selectedOption.Contains("Nathaniel")) { selectedIndex = 2; }
            if(selectedOption.Contains("Maya")) { selectedIndex = 3; }
            if(selectedOption.Contains("RETURN")) { selectedIndex = 4; }


            switch (selectedIndex)
            {
                case 0:
                    // TO DO // IF RATIONS SUFFICIENT
                    terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                    isabellaHired = true;
                    this.Run();
                    break;
                case 1:
                    // TO DO // IF RATIONS SUFFICIENT
                    terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                    stevenHired = true;
                    this.Run();
                    break;
                case 2:
                    // TO DO // IF RATIONS SUFFICIENT
                    terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                    nateHired = true;
                    this.Run();
                    break;
                case 3:
                    // TO DO // IF RATIONS SUFFICIENT
                    terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                    mayaHired = true;
                    this.Run();
                    break;
                case 4:
                    terminalOutbreakGame.baseScene.Run(); // TO DO // SET UP RETURN TO POINT TO TRADE MENU, currently bypasses the Trade scene
                    break;
                case 5:
                    Console.WriteLine("Error in selection");
                    break;

            }

        }


    }
}
