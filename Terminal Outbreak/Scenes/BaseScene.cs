using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class BaseScene : Scene
    {
        private bool isNight;
        public BaseScene(TerminalOutbreakGame game) : base(game)
        {
            isNight = false;
        }

        public override void Run()
        {
            if (isNight)
            {
                int rations = terminalOutbreakGame.resourceManager.GetFoodRations();
                if (rations <= 0)
                {
                    terminalOutbreakGame.warningScene.GameOverStarved();
                }
                isNight = false;
            }
            if (terminalOutbreakGame.baseManager.GetDayNumber() == 26)
            {
                terminalOutbreakGame.endingAndCreditsScene.RescueVictory(); // If Day 1 is reached, 
            }

            string traps = terminalOutbreakGame.baseManager.GetBuiltTrapsNames();
            string resources = terminalOutbreakGame.resourceManager.GetResources();
            bool helicopterFixed = terminalOutbreakGame.baseManager.IsHelicopterFixed();

            string header = Utils.FrameText(terminalOutbreakGame.player.GetName() + $"'s Outpost - Day {terminalOutbreakGame.baseManager.GetDayNumber()}");
            string display = ($"{header}{Environment.NewLine}Health: {terminalOutbreakGame.player.getHealth()}{Environment.NewLine}");
            
            display += ($"{Environment.NewLine}Allies: {terminalOutbreakGame.alliesManager.GetAllyNames()}{Environment.NewLine}");

            display += ($"{Environment.NewLine}Food Rations: {terminalOutbreakGame.resourceManager.GetFoodRations()}   ->   Ration Consumption: {terminalOutbreakGame.resourceManager.GetRationConsumption()}/Day{Environment.NewLine}" );
            
            display += ($"{Environment.NewLine}Resources: {resources}{Environment.NewLine}");

            display += ($"{Environment.NewLine}Traps: {traps} {Environment.NewLine}");

            display += ($"{Environment.NewLine}Time remaining in day: {terminalOutbreakGame.baseManager.GetTime()} hours{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("Resupply");
            options.Add("Build/Repair");
            options.Add("Equip Weapons");
            options.Add("Trade");
            if (helicopterFixed)
            {
                options.Add("Escape In Helicopter");
            }
            else
            {
                options.Add("End Preparation Phase");
            }
            
            options.Add("Exit Game");

            Menu dayMenu = new Menu(display, options);
            int selectedIndex = dayMenu.Run();

            switch (selectedIndex)
            {
                case 0: //Resupply
                    terminalOutbreakGame.resupplyScene.Run();
                   
                    break;
                    
                case 1:
                    terminalOutbreakGame.constructionChoiceScene.Run();
                    break;

                case 2: // Go to equipment scene
                    terminalOutbreakGame.equipmentScene.Run();
                    break;

                case 3: // Go to trader's scene
                    terminalOutbreakGame.tradeScene.Run();
                    break;

                case 4:
                    
                    if(helicopterFixed)
                    {
                        terminalOutbreakGame.endingAndCreditsScene.HelicopterVictory(); // End the game if Helicopter is Fixed.
                    }

                    if (terminalOutbreakGame.player.GetEquippedMeleeWeaponID() == -1 && terminalOutbreakGame.player.GetEquippedSecondaryWeaponID() == -1 && terminalOutbreakGame.player.GetEquippedPrimaryWeaponID() == -1)
                    {
                        terminalOutbreakGame.warningScene.RunNoWeaponWarning();
                    }
                    
                    terminalOutbreakGame.enemyManager.CreateWave(terminalOutbreakGame.baseManager.GetDayNumber()); // create a wave using the enemyManger's CreateWave funtion with a parameter of the current day

                    isNight = true;
                    terminalOutbreakGame.baseManager.ResetTime();
                    terminalOutbreakGame.resourceManager.ConsumeRations();
                    terminalOutbreakGame.longRangeCombatScene.Run();
                    break;

                case 5:
                    Console.WriteLine("Are you sure you want to quit? y/n");
                    Console.CursorVisible = true;
                    string? choice = Console.ReadLine()?.ToLower();
                    if (choice =="y" || choice == "yes")
                    {
                        Utils.ExitGame();
                    }
                    else
                    {
                        Console.CursorVisible = false;
                        this.Run();
                    }
                    break;
            }
        }
    }
}
