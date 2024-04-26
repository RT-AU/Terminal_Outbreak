using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Items;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.EquippingScenes
{
    internal class EquipMeleeScene : Scene
    {
        
        public EquipMeleeScene(TerminalOutbreakGame game) : base(game)
        {
            
        }

        public override void Run()
        {
            // set first, second and third weapon IDs
            int fwID = 0;
            int swID = 1;
            int twID = 2;

            // get Currently Equipped melee Weapon ID and Name
            int cemwID = terminalOutbreakGame.player.GetEquippedMeleeWeaponID();
            string cemwName = string.Empty;
            if (cemwID == -1)
            {
                cemwName = "NONE";
            }
            else
            {
                cemwName = terminalOutbreakGame.equipmentManager.GetWeaponName(cemwID);
            }

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
            string header = Utils.FrameText("Equip Melee Weapons");
            string display = string.Empty;
            if (fwOwned == false && swOwned == false && twOwned == false)
            {
                display = Utils.WrapText($"{Environment.NewLine}You have no melee weapons to equip. Your current melee weapon is: {cemwName}{Environment.NewLine}");
            }
            else
            {
                display = Utils.WrapText($"{Environment.NewLine}Which melee weapon would you like to equip? Your current melee weapon is: {cemwName}.{Environment.NewLine}");
            }

            // weapon names and description
            if (fwOwned) { display += $"{Environment.NewLine}{firstWeaponName}{Environment.NewLine}{firstWeaponDescription}{Environment.NewLine}"; }
            if (swOwned) { display += $"{Environment.NewLine}{secondWeaponName}{Environment.NewLine}{secondWeaponDescription}{Environment.NewLine}"; }
            if (twOwned) { display += $"{Environment.NewLine}{thirdWeaponName}{Environment.NewLine}{thirdWeaponDescription}{Environment.NewLine}"; }
 
            // options
            List<string> options = new List<string>();
            if (fwOwned) { options.Add($"Equip {firstWeaponName}"); }
            if (swOwned) { options.Add($"Equip {secondWeaponName}"); }
            if (twOwned) { options.Add($"Equip {thirdWeaponName}"); }
            options.Add("RETURN");

            Menu equipMeleeMenu = new Menu(display, options, header);
            string selectedOption = equipMeleeMenu.RunRemovable(options);
            int selectedIndex = 4;

            if (selectedOption.Contains(firstWeaponName)) { selectedIndex = 0; }
            if (selectedOption.Contains(secondWeaponName)) { selectedIndex = 1; }
            if (selectedOption.Contains(thirdWeaponName)) { selectedIndex = 2; }
            if (selectedOption.Contains("RETURN")) { selectedIndex = 3; }

            switch (selectedIndex)
            {
                case 0:// First Weapon
                    if (cemwName == firstWeaponName) // IF IS ALREADY EQUIPPED
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Already Equipped"));
                        Console.WriteLine($"{Environment.NewLine}You already have the {firstWeaponName} equipped.{Environment.NewLine}{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        terminalOutbreakGame.player.equipMeleeWeapon(fwID); // sets the player's melee weapon to be equipped
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText($"{firstWeaponName} Equipped"));
                        Console.WriteLine($"{Environment.NewLine}You have equpped the {firstWeaponName}!{Environment.NewLine}");
                        Console.WriteLine("Press ENTER to continue");
                        Utils.PressEnter();
                    }
                    terminalOutbreakGame.equipmentScene.Run();
                    break;

                case 1: // Second Weapon
                    if (cemwName == secondWeaponName) // IF IS ALREADY EQUIPPED
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Already Equipped"));
                        Console.WriteLine($"{Environment.NewLine}You already have the {secondWeaponName} equipped.{Environment.NewLine}{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        terminalOutbreakGame.player.equipMeleeWeapon(swID); // sets the player's melee weapon to be equipped
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText($"{secondWeaponName} Equipped"));
                        Console.WriteLine($"{Environment.NewLine}You have equpped the {secondWeaponName}!{Environment.NewLine}");
                        Console.WriteLine("Press ENTER to continue");
                        Utils.PressEnter();
                    }

                    terminalOutbreakGame.equipmentScene.Run();
                    break;

                case 2:
                    if (cemwName == thirdWeaponName) // IF IS ALREADY EQUIPPED
                    {
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText("Already Equipped"));
                        Console.WriteLine($"{Environment.NewLine}You already have the {thirdWeaponName} equipped.{Environment.NewLine}{Environment.NewLine}Press ENTER to continue.");
                        Utils.PressEnter();
                    }
                    else
                    {
                        terminalOutbreakGame.player.equipMeleeWeapon(twID); // sets the player's melee weapon to be equipped
                        Console.Clear();
                        Console.WriteLine(Utils.FrameText($"{thirdWeaponName} Equipped"));
                        Console.WriteLine($"{Environment.NewLine}You have equpped the {thirdWeaponName}!{Environment.NewLine}");
                        Console.WriteLine("Press ENTER to continue");
                        Utils.PressEnter();
                    }

                    terminalOutbreakGame.equipmentScene.Run();
                    break;
                case 3:
                    terminalOutbreakGame.equipmentScene.Run();
                    break;
                case 4:
                    Console.WriteLine("Error in equip melee weapon selection");
                    break;
            }
        }
    }
}
