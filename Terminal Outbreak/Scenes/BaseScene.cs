using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class BaseScene : Scene
    {

        public BaseScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        { 
            Dictionary<string, int> resourceList = terminalOutbreakGame.baseManager.GetResourceList(); // build a dictionary using resources stored in the baseManager

            string results = "";
            string trapsResults;
            int formatCounter = 0;




            foreach (var kvp in resourceList) // Display resource names and counts                                            
            {
                if (kvp.Key == "Food Rations")
                {
                    terminalOutbreakGame.baseManager.IncreaseFoodRations(kvp.Value);
                    continue;
                }
                
                if (formatCounter == 0)
                {
                    results += $"{Environment.NewLine}   {kvp.Key}: {kvp.Value}";
                    formatCounter++;
                }
                else if (formatCounter < 2)
                {
                    results += $"   {kvp.Key}: {kvp.Value}";
                    formatCounter++;
                }
                else
                {
                    results += $"   {kvp.Key}: {kvp.Value}";
                    formatCounter = 0;
                }
            }
            if (results == "")
            {
                results = "NONE";
            }
            if (terminalOutbreakGame.baseManager.GetTrapCount() == 0)
            {
                trapsResults = "TRAP NAMES ETC"; // TO DO // set up proper trap display in base
            }
            else
            {
                trapsResults = "NONE"; // TO DO // ------------------- triggering because traps is never 0, they exist, they just aren't set to built yet
            }

            string header = Utils.FrameText(terminalOutbreakGame.player.GetName() + $"'s Outpost - Day {terminalOutbreakGame.baseManager.GetDayNumber()}");
            string display = ($"{header}{Environment.NewLine}Health: {terminalOutbreakGame.player.getHealth()}{Environment.NewLine}");
            
            display += ($"{Environment.NewLine}Allies: {terminalOutbreakGame.alliesManager.GetAllyNames()}{Environment.NewLine}");

            display += ($"{Environment.NewLine}Food Rations: {terminalOutbreakGame.baseManager.CheckFoodRations()}{Environment.NewLine}");
            
            display += ($"{Environment.NewLine}Resources: {results}{Environment.NewLine}");

            display += ($"{Environment.NewLine}Traps: {trapsResults} {Environment.NewLine}");

            display += ($"{Environment.NewLine}Time remaining in day: {terminalOutbreakGame.baseManager.GetTime()} hours{Environment.NewLine}");

            List<string> options = new List<string>();
            options.Add("Resupply");
            options.Add("Build/Repair");
            options.Add("Equipment");
            options.Add("Trade");
            options.Add("End Preparation Phase");
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

                case 2:
                    Console.Clear();

                    Console.WriteLine("-------------");
                    Console.WriteLine("| Equipment |");
                    Console.WriteLine("-------------");
                    Console.WriteLine();

                    Utils.PressEnter();
                    this.Run();
                    break;
                case 3:
                    //Console.Clear();

                    //Console.WriteLine("---------");
                    //Console.WriteLine("| Trade |");
                    //Console.WriteLine("---------");
                    //Console.WriteLine();

                    //Utils.PressEnter();
                    //this.Run();

                    terminalOutbreakGame.hireAlliesScene.Run(); // TO DO // Currently bypasses the Trade Scene

                    break;
                case 4:
                    terminalOutbreakGame.enemyManager.CreateWave(terminalOutbreakGame.baseManager.GetDayNumber()); // create a wave using the enemyManger's CreateWave funtion with a parameter of the current day
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






            //terminalOutbreakGame.baseManager.buildTrap(0);
            //terminalOutbreakGame.baseManager.buildTrap(1);
            //terminalOutbreakGame.baseManager.getTraps();
        }


    }
}
