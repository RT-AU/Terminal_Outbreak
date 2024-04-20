﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes
{
    internal class DayScene : Scene
    {

        public DayScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {

            string display = ($"{terminalOutbreakGame.player.GetName()}'s Outpost.{Environment.NewLine}Health: {terminalOutbreakGame.player.getHealth()}{Environment.NewLine}");
            display += ($"Traps: {terminalOutbreakGame.baseManager.getTrapCount()} {Environment.NewLine}Food Rations: {terminalOutbreakGame.baseManager.checkFoodRations()}{Environment.NewLine}");
            display += ($"Resources: 0{Environment.NewLine}");
            display += ($"Allies: 0{Environment.NewLine}");
            string[] options = {"Scavange/Loot", "Build/Repair", "Equipment", "Trade", "Exit Game"};

            Menu dayMenu = new Menu(display, options);
            int selectedIndex = dayMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.Clear();

                    Console.WriteLine("-----------------");
                    Console.WriteLine("| Scavange/Loot |");
                    Console.WriteLine("-----------------");
                    Console.WriteLine();

                    Utilities.PressEnter();
                    this.Run();
                   
                    break;

                case 1:
                    Console.Clear();

                    Console.WriteLine("----------------");
                    Console.WriteLine("| Build/Repair |");
                    Console.WriteLine("----------------");
                    Console.WriteLine();

                    Utilities.PressEnter();
                    this.Run();
                    break;

                case 2:
                    Console.Clear();

                    Console.WriteLine("-------------");
                    Console.WriteLine("| Equipment |");
                    Console.WriteLine("-------------");
                    Console.WriteLine();

                    Utilities.PressEnter();
                    this.Run();
                    break;
                case 3:
                    Console.Clear();

                    Console.WriteLine("---------");
                    Console.WriteLine("| Trade |");
                    Console.WriteLine("---------");
                    Console.WriteLine();

                    Utilities.PressEnter();
                    this.Run();
                    break;
                case 4:
                    Console.WriteLine("Are you sure you want to quit? y/n");
                    Console.CursorVisible = true;
                    string? choice = Console.ReadLine()?.ToLower();
                    if (choice =="y" || choice == "yes")
                    {
                        Utilities.ExitGame();
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
