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
            Dictionary<string, int> resourceList = terminalOutbreakGame.baseManager.getResourceList(); // build a dictionary using resources stored in the baseManager

            string results = "";
            string trapsResults;
            int formatCounter = 0;

            foreach (var kvp in resourceList) // Display resource names and counts                                            
            {
                if (kvp.Key == "Food Rations")
                {
                    terminalOutbreakGame.baseManager.increaseFoodRations(kvp.Value);
                    continue;
                }
                
                if (formatCounter == 0)
                {
                    results += $"{Environment.NewLine}      {kvp.Key}: {kvp.Value}";
                    formatCounter++;
                }
                else if (formatCounter < 2)
                {
                    results += $"   {kvp.Key}: {kvp.Value}";
                    formatCounter++;
                }
                else
                {
                    results += $"    {kvp.Key}: {kvp.Value}";
                    formatCounter = 0;
                }
            }
            if (results == "")
            {
                results = "NONE";
            }
            if (terminalOutbreakGame.baseManager.GetTrapCount() == 0)
            {
                trapsResults = "NONE";
            }
            else
            {
                trapsResults = "PUT METHOD TO FETCH TRAPS NAME HERE"; // TO DO -------------------
            }

            string header = Utils.FrameText(terminalOutbreakGame.player.GetName() + "'s Outpost");
            string display = ($"{header}{Environment.NewLine}{Environment.NewLine}Health: {terminalOutbreakGame.player.getHealth()}{Environment.NewLine}");
            
            display += ($"Allies: 0{Environment.NewLine}");

            display += ($"Food Rations: {terminalOutbreakGame.baseManager.checkFoodRations()}{Environment.NewLine}");
            
            display += ($"{Environment.NewLine}Resources: {results}{Environment.NewLine}");

            display += ($"{Environment.NewLine}Traps: {trapsResults} {Environment.NewLine}");

            display += ($"{Environment.NewLine}Time remaining in day: {terminalOutbreakGame.baseManager.getTime()} hours{Environment.NewLine}");
            string[] options = {"Resupply", "Build/Repair", "Equipment", "Trade", "Exit Game"};

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
                    Console.Clear();

                    Console.WriteLine("---------");
                    Console.WriteLine("| Trade |");
                    Console.WriteLine("---------");
                    Console.WriteLine();

                    Utils.PressEnter();
                    this.Run();
                    break;
                case 4:
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
