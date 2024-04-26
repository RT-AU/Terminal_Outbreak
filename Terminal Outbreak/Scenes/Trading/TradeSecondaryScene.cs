using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.Trading
{
    internal class TradeSecondaryScene : Scene
    {
        public TradeSecondaryScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            // set first, second and third weapon IDs
            int fwID = 6;
            int swID = 7;
            int twID = 8;

            int fwCost = 5;
            int swCost = 15;
            int twCost = 25;

            int baseRationsCount = terminalOutbreakGame.resourceManager.GetFoodRations();

            bool fwOwned = terminalOutbreakGame.equipmentManager.IsWeaponOwned(fwID);
            bool swOwned = terminalOutbreakGame.equipmentManager.IsWeaponOwned(swID);
            bool twOwned = terminalOutbreakGame.equipmentManager.IsWeaponOwned(twID);

            string firstWeaponName = terminalOutbreakGame.equipmentManager.GetWeaponName(fwID); // Revolver
            string secondWeaponName = terminalOutbreakGame.equipmentManager.GetWeaponName(swID); // Pistol
            string thirdWeaponName = terminalOutbreakGame.equipmentManager.GetWeaponName(twID); // Sawn-Off

            string firstWeaponDescription = terminalOutbreakGame.equipmentManager.GetWeaponDescription(fwID);
            string secondWeaponDescription = terminalOutbreakGame.equipmentManager.GetWeaponDescription(swID);
            string thirdWeaponDescription = terminalOutbreakGame.equipmentManager.GetWeaponDescription(twID);

            // set up menu
            string header = Utils.FrameText("Purchase Secondary Weapons");
            
            string display = string.Empty;
            if (fwOwned == true && swOwned == true && twOwned == true)
            {
                display = Utils.WrapText($"{Environment.NewLine}There are no more secondary weapons available.{Environment.NewLine}");
            }
            else
            {
                display = Utils.WrapText($"{Environment.NewLine}There are a range of secondary weapons that you can buy. You currently have {baseRationsCount} Rations.{Environment.NewLine}");
            }
            

            // weapon names and description
            if (!fwOwned) { display += $"{Environment.NewLine}{firstWeaponName}{Environment.NewLine}{firstWeaponDescription}{Environment.NewLine}"; }
            if (!swOwned) { display += $"{Environment.NewLine}{secondWeaponName}{Environment.NewLine}{secondWeaponDescription}{Environment.NewLine}"; }
            if (!twOwned) { display += $"{Environment.NewLine}{thirdWeaponName}{Environment.NewLine}{thirdWeaponDescription}{Environment.NewLine}"; }

            // options
            List<string> options = new List<string>();
            if (!fwOwned) { options.Add($"Purchase {firstWeaponName} - Cost {fwCost} Rations"); }
            if (!swOwned) { options.Add($"Purchase {secondWeaponName} - Cost {swCost} Rations"); }
            if (!twOwned) { options.Add($"Purchase {thirdWeaponName} - Cost {twCost} Rations"); }
            options.Add("RETURN");

            Menu resupplyResultsMenu = new Menu(display, options, header);
            string selectedOption = resupplyResultsMenu.RunRemovable(options);
            int selectedIndex = 4;

            if (selectedOption.Contains(firstWeaponName)) { selectedIndex = 0; }
            if (selectedOption.Contains(secondWeaponName)) { selectedIndex = 1; }
            if (selectedOption.Contains(thirdWeaponName)) { selectedIndex = 2; }
            if (selectedOption.Contains("RETURN")) { selectedIndex = 3; }

            switch (selectedIndex)
            {
                case 0:// First Weapon
                    if (fwCost > baseRationsCount) // check if player has enough rations to buy weapon
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Purchase Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to buy the {firstWeaponName} {Environment.NewLine}{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        terminalOutbreakGame.equipmentManager.SetWeaponOwned(fwID, true);
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, fwCost);
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText($"{firstWeaponName} Obtained"));
                        Console.WriteLine($"{Environment.NewLine}You are now the proud owner of the {firstWeaponName}!{Environment.NewLine}");
                        Console.WriteLine("Press ENTER to continue");
                        Utils.PressEnter();
                    }

                    this.Run();
                    break;
                case 1: // Second Weapon
                    if (swCost > baseRationsCount) // check if player has enough rations to buy weapon
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Purchase Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to buy the {secondWeaponName} {Environment.NewLine}{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        terminalOutbreakGame.equipmentManager.SetWeaponOwned(swID, true);
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, swCost);
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText($"{secondWeaponName} Obtained"));
                        Console.WriteLine($"{Environment.NewLine}You are now the proud owner of the {secondWeaponName}!{Environment.NewLine}{Environment.NewLine}");
                        Console.WriteLine("Press ENTER to continue");
                        Utils.PressEnter();
                    }
                    this.Run();
                    break;
                case 2:
                    if (twCost > baseRationsCount) // check if player has enough rations to buy weapon
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Purchase Failed"));
                        Console.WriteLine($"{Environment.NewLine}You do not have enough rations to buy the {thirdWeaponName} {Environment.NewLine}{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        terminalOutbreakGame.equipmentManager.SetWeaponOwned(twID, true);
                        terminalOutbreakGame.resourceManager.ReduceResourceQuantity(0, twCost);
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText($"{thirdWeaponName} Obtained"));
                        Console.WriteLine($"{Environment.NewLine}You are now the proud owner of the {thirdWeaponName}!{Environment.NewLine}");
                        Console.WriteLine("Press ENTER to continue");
                        Utils.PressEnter();
                    }
                    this.Run();
                    break;
                case 3:
                    terminalOutbreakGame.tradeScene.Run();
                    break;
                case 4:
                    Console.WriteLine("Error in purchase weapon selection");
                    break;
            }
        }
    }
    
    
}
