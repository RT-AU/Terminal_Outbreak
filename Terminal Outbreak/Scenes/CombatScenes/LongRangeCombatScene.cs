using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.CombatScenes
{
    internal class LongRangeCombatScene : Scene
    {
        int roundNumber = 0;
        public LongRangeCombatScene(TerminalOutbreakGame game) : base(game)
        {

        }

        public override void Run()
        {
            roundNumber++;
            int weaponDamage = 5; // TO DO // this should changed for GETS on equipment, depending on if its Primary in long range, mid range, etc
            int targetNumber = 3; // TO DO // this should changed for GETS on equipment, depending on if its Primary in long range, mid range, etc

            string header = Utils.FrameText($"Nightfall - Long Range ROUND {roundNumber}");
            string display = "";
            int zombieCount = terminalOutbreakGame.enemyManager.GetZombieCount();
            int bossCount = terminalOutbreakGame.enemyManager.GetBossCount();
            int zombiesKilled = terminalOutbreakGame.enemyManager.GetZombiesKilled();
            int bossesKilled = terminalOutbreakGame.enemyManager.GetBossesKilled();

            int distance = terminalOutbreakGame.enemyManager.GetLongRangeDistance();

            if (distance <= 0)
            {
                // TO DO // If statement here to put the condition that they had to have broken down a barricade if there was one
                terminalOutbreakGame.midRangeCombatScene.Run();
            }

            if (roundNumber > 1)
            {
                display += $"{Environment.NewLine}You hit {targetNumber} enemies for {weaponDamage} damage each!";
            }

            if (zombiesKilled > 1 && bossesKilled > 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombies killed and {bossesKilled} Bosses killed!";
            }
            else if (zombiesKilled > 1 && bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombies killed and {bossesKilled} Boss killed!";
            }
            else if (zombiesKilled == 1 && bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombie killed and {bossesKilled} Boss killed!";
            }
            else if (zombiesKilled > 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombies killed!";
            }
            else if (zombiesKilled == 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombie killed!";
            }
            else if (bossesKilled > 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled}{bossesKilled} Bosses killed!";
            }
            else if (bossesKilled == 1) 
            {
                display += $"{Environment.NewLine}{bossesKilled} Boss killed!";
            }

            if (bossCount == 1)
            {
                display += $"{Environment.NewLine}{zombieCount} Zombies and {bossCount} Boss are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}"; // if distance = 0, AT THE BARRICADE
            }
            else if (bossCount > 1 && bossCount > bossesKilled)
            {
                display += $"{Environment.NewLine}{zombieCount} Zombies and {bossCount} Bosses are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}";
            }
            else if (zombieCount > 1)
            {
                display += $"{Environment.NewLine}{zombieCount} Zombies are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}";
            }
            else
            {
                display += $"{Environment.NewLine}{zombieCount} Zombie are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}";
            }


            List<string> options = new List<string>();
            options.Add("Primary Weapon");
            options.Add("Secondary Weapon");
            options.Add("None");

            Menu resupplyResultsMenu = new Menu(display, options, header);
            int selectedIndex = resupplyResultsMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    terminalOutbreakGame.enemyManager.DealDamage(weaponDamage, targetNumber); // TO DO - Set to use equipment stats
                    
                    if(distance > 0)
                    {
                        terminalOutbreakGame.enemyManager.ReduceLongRangeDistance();
                    }
                    else
                    {
                        // TO DO // Implement damage to wall or walk through system
                    }

                    terminalOutbreakGame.longRangeCombatScene.Run(); 
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine("Bang you kill some zombies"); // TO DO --- SET UP ACTUAL COMBAT
                    Utils.PressEnter();
                    terminalOutbreakGame.midRangeCombatScene.Run(); 
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("You kill 0 zombies. Your Allies killed 0 zombies. Your Traps killed 0 zombies."); // TO DO --- SET UP ACTUAL COMBAT for Allies and Traps
                    Utils.PressEnter();
                    terminalOutbreakGame.midRangeCombatScene.Run();
                    break;


            }
        }

    }
}
