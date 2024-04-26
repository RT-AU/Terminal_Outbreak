using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;
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
            int isabellaHireCost = 20;
            int stevenHireCost = 20;
            int nateHireCost = 30;
            int mayaHireCost = 30;

            int baseRationsCount = terminalOutbreakGame.resourceManager.GetFoodRations();

            string header = Utils.FrameText("Hire Allies");
            string display = Utils.WrapText($"Who would you like to hire? Note that every Ally will consume 1 extra food ration a day, but will help in combat. You currently have {baseRationsCount} Rations");

            display += terminalOutbreakGame.alliesManager.HireAlliesReadout(isabellaHired, stevenHired, nateHired, mayaHired);
            display += Environment.NewLine;


            List<string> options = new List<string>();
            if (!isabellaHired) { options.Add($"Isabella \"Sheriff\" Barrett - Hire Fee: {isabellaHireCost} Rations"); }
            if (!stevenHired) { options.Add($"Dr Steven \"Boomstick\" Adams - Hire Fee: {stevenHireCost} Rations"); }
            if (!nateHired) { options.Add($"Nathaniel \"Timmy\" Thomson - Hire Fee: {nateHireCost} Rations"); }
            if (!mayaHired) { options.Add($"Maya \"Valkyrie\" Carter - Hire Fee: {mayaHireCost} Rations"); }
            options.Add($"RETURN");

            if (options.Count == 1)
            {
                display = Utils.WrapText($"{Environment.NewLine}There is no one else available to hire!{Environment.NewLine}");
            }

            Menu resupplyResultsMenu = new Menu(display, options, header);
            string selectedOption = resupplyResultsMenu.RunRemovable(options);
            int selectedIndex = 5;
            if(selectedOption.Contains("Isabella")) { selectedIndex = 0; }
            if(selectedOption.Contains("Steven")) { selectedIndex = 1; }
            if(selectedOption.Contains("Nathaniel")) { selectedIndex = 2; }
            if(selectedOption.Contains("Maya")) { selectedIndex = 3; }
            if(selectedOption.Contains("RETURN")) { selectedIndex = 4; }

            

            switch (selectedIndex)
            {
                case 0:
                    if (isabellaHireCost > baseRationsCount) // check if player has enough rations to hire ally
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Hire Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to hire Isabella. {Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Isabella Hired"));
                        Console.WriteLine($"{Environment.NewLine}You hired Isabella! From now on she will help you in battle, but make sure you keep an eye on your rations!{Environment.NewLine}Press ENTER to continue."); 
                        Utils.PressEnter();
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, isabellaHireCost);
                        terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                        isabellaHired = true;
                        terminalOutbreakGame.resourceManager.IncreaseRationConsumption();
                    }
                    this.Run();
                    break;
                case 1:
                    if (stevenHireCost > baseRationsCount) // check if player has enough rations to hire ally
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Hire Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to hire Steven. {Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Steven Hired"));
                        Console.WriteLine($"{Environment.NewLine}You hired Steven! From now on he will help you in battle, but make sure you keep an eye on your rations! {Environment.NewLine}Press ENTER to continue."); 
                        Utils.PressEnter();
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, stevenHireCost);
                        terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                        stevenHired = true;
                        terminalOutbreakGame.resourceManager.IncreaseRationConsumption();
                    }
                    this.Run();
                    break;
                case 2:
                    if (nateHireCost > baseRationsCount) // check if player has enough rations to hire ally
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Hire Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to hire Nathaniel. {Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Nathaniel Hired"));
                        Console.WriteLine($"{Environment.NewLine}You hired Nathaniel! From now on he will help you in battle, but make sure you keep an eye on your rations! {Environment.NewLine}Press ENTER to continue."); 
                        Utils.PressEnter();
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, nateHireCost);
                        terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                        nateHired = true;
                        terminalOutbreakGame.resourceManager.IncreaseRationConsumption();
                    }
                    this.Run();
                    break;
                case 3:
                    if (mayaHireCost > baseRationsCount) // check if player has enough rations to hire ally
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Hire Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to hire Maya. {Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Maya Hired"));
                        Console.WriteLine($"{Environment.NewLine}You hired Maya! From now on she will help you in battle, but make sure you keep an eye on your rations! {Environment.NewLine}Press ENTER to continue."); 
                        Utils.PressEnter();
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, mayaHireCost);
                        terminalOutbreakGame.alliesManager.HireAlly(selectedIndex);
                        mayaHired = true;
                        terminalOutbreakGame.resourceManager.IncreaseRationConsumption();
                    }
                    this.Run();
                    break;
                case 4:
                    terminalOutbreakGame.tradeScene.Run(); // returns to trade scene
                    break;
                case 5:
                    Console.WriteLine("Error in selection");
                    break;

            }

        }


    }
}
