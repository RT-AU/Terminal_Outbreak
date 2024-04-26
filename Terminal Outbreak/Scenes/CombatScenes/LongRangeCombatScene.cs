using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.CombatScenes
{
    internal class LongRangeCombatScene : Scene
    {
        int roundNumber;
        int totalEnemies;
        int playerWeaponDamage;
        int playerTargetNumber;
        string chosenRoundWeapon;
        string alliesDamageReadout;
        string trapDamageReadout;
        public LongRangeCombatScene(TerminalOutbreakGame game) : base(game)
        {
            chosenRoundWeapon = string.Empty; // used to see which weapon Player is using for this round
            alliesDamageReadout = string.Empty; // gives a readout on the ally damage
            trapDamageReadout = string.Empty; // gives a readout on the trap damage
            roundNumber = 0;
            totalEnemies = 0;
            playerWeaponDamage = 0;
            playerTargetNumber = 0;
        }

        public override void Run()
        {
            roundNumber++;
            bool barrierBuilt = terminalOutbreakGame.baseManager.IsBarrierBuilt();
            bool barrierDestroyed = terminalOutbreakGame.baseManager.IsBarrierDestroyed();
            int barrierHealth = terminalOutbreakGame.baseManager.GetBarrierHealth();
            
            int playerEquippedPrimaryWeapon = terminalOutbreakGame.player.GetEquippedPrimaryWeaponID();
            int playerEquippedSecondaryWeapon = terminalOutbreakGame.player.GetEquippedSecondaryWeaponID();

            string header = Utils.FrameText($"Nightfall - Long Range: ROUND {roundNumber}");
            string display = "";
            int zombieCount = terminalOutbreakGame.enemyManager.GetZombieCount();
            int bossCount = terminalOutbreakGame.enemyManager.GetBossCount();
            totalEnemies = zombieCount + bossCount;
            
            int zombiesKilled = terminalOutbreakGame.enemyManager.GetAndResetZombiesKilled();
            int bossesKilled = terminalOutbreakGame.enemyManager.GetAndResetBossesKilled();

            int distance = terminalOutbreakGame.enemyManager.GetLongRangeDistance();

            if (roundNumber > 1)
            {
                switch (chosenRoundWeapon) 
                {
                    case "primary":
                        if (playerEquippedPrimaryWeapon == -1)
                        {
                            display += $"{Environment.NewLine}You have no primary weapon equipped! You have no way to deal damage at long range.{Environment.NewLine}";
                        }
                        else
                        {
                            if (playerTargetNumber == 1)
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemy for {playerWeaponDamage} damage!{Environment.NewLine}";
                            }
                            else
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemies for {playerWeaponDamage} damage each!{Environment.NewLine}";
                            }
                            
                        }
                        break;
                    case "secondary":
                        if (playerEquippedSecondaryWeapon == -1)
                        {
                            display += $"{Environment.NewLine}You have no secondary weapon equipped! You have no way to deal damage at long range.{Environment.NewLine}";
                        }
                        else
                        {
                            if (playerTargetNumber == 1)
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemy for {playerWeaponDamage} damage!{Environment.NewLine}";
                            }
                            else
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemies for {playerWeaponDamage} damage each!{Environment.NewLine}";
                            }
                        }
                        break;
                }
                
                if (alliesDamageReadout != string.Empty) { display += alliesDamageReadout; }
                
                if (trapDamageReadout != string.Empty) { display += trapDamageReadout; }
         
            }

            display += GetHoardInfo(zombieCount, bossCount, zombiesKilled, bossesKilled, distance); // call info on position and number of the hoard for display
            
            if (totalEnemies == 0)
            {
                VictoryResults(display);
            }

            if (distance <= 0)
            {
                if(barrierBuilt && !barrierDestroyed)
                {
                    //Console.Clear();
                    display += $"{Environment.NewLine}[Zombies Halted By Barrier]{Environment.NewLine}";
                    display += ($"{Environment.NewLine}The Zombies have been stopped by the barrier. Kill them before they break through!{Environment.NewLine}Barrier Health: {barrierHealth}");
                    terminalOutbreakGame.baseManager.DamageBarrier();
                    if (terminalOutbreakGame.baseManager.GetBarrierHealth() <= 0)
                    {
                        terminalOutbreakGame.baseManager.DestroyBarrier();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(Utils.FrameText("Zombies Advance To Medium Range"));
                    Console.WriteLine($"{display}{Environment.NewLine}The Zombies have made it into the outpost. Stop them before they reach close quarters!{Environment.NewLine}");
                    Console.WriteLine("Press ENTER to Continue");
                    Utils.PressEnter();
                    terminalOutbreakGame.midRangeCombatScene.Run();
                }

                
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
                    chosenRoundWeapon = "primary";
                    playerWeaponDamage = terminalOutbreakGame.equipmentManager.GetWeaponLRDamage(playerEquippedPrimaryWeapon);
                    playerTargetNumber = terminalOutbreakGame.equipmentManager.GetWeaponLRMulti(playerEquippedPrimaryWeapon);

                    if(playerTargetNumber > totalEnemies) // limits the number of hits to the actual number of zombies
                    {
                        playerTargetNumber = totalEnemies;
                    }
                    terminalOutbreakGame.enemyManager.DealDamage(playerWeaponDamage, playerTargetNumber);
                    alliesDamageReadout = AlliesDamage(); // calculate ally damage
                    trapDamageReadout = TrapDamage();

                    LRZombiesAdvance(); // if zombies at 0, either attack wall or continue to medium range. If not, repeat LR scene
                    Run();
                    break;

                case 1:
                    chosenRoundWeapon = "secondary";
                    playerWeaponDamage = terminalOutbreakGame.equipmentManager.GetWeaponLRDamage(playerEquippedSecondaryWeapon);
                    playerTargetNumber = terminalOutbreakGame.equipmentManager.GetWeaponLRMulti(playerEquippedSecondaryWeapon);

                    if (playerTargetNumber > totalEnemies) // limits the number of hits to the actual number of zombies
                    {
                        playerTargetNumber = totalEnemies;
                    }

                    terminalOutbreakGame.enemyManager.DealDamage(playerWeaponDamage, playerTargetNumber);
                    alliesDamageReadout = AlliesDamage(); // calculate ally damage
                    trapDamageReadout = TrapDamage();

                    LRZombiesAdvance();
                    
                    Run();
                    break;
                case 2:

                    alliesDamageReadout = AlliesDamage(); // calculate ally damage
                    trapDamageReadout = TrapDamage();
                    LRZombiesAdvance();
                    
                    Run();
                    break;

            }
        }

        public string AlliesDamage()
        {
            string totalAllyDamage = $"";
            int allyCount = 0;
            List<Ally> allies = terminalOutbreakGame.alliesManager.GetAlliesList();
            foreach (Ally ally in allies)
            {
                if (ally.GetIsHired() == false)
                {
                    continue;
                }
                if(ally.GetLRDamage()  == 0)
                {
                    continue;
                }
                allyCount++;
                string allyName = ally.GetName();
                int allyDamage = ally.GetLRDamage();
                int allyTargetMulti = ally.GetLRTargetMulti();
                
                if (allyTargetMulti > totalEnemies)
                {
                    allyTargetMulti = totalEnemies;
                }
                
                terminalOutbreakGame.enemyManager.DealDamage(allyDamage, allyTargetMulti);
                
                totalAllyDamage += $"{ Environment.NewLine}{allyName} deals {allyDamage} damage to {allyTargetMulti} enemies.";
            }
            if (allyCount == 0)
            {
                totalAllyDamage = string.Empty;
            }
            else
            {
                totalAllyDamage += Environment.NewLine;
            }
            return totalAllyDamage;

        }

        public string TrapDamage()
        {
            string totalTrapDamage = $"";
            int trapCount = 0;
            List<Trap> traps = terminalOutbreakGame.baseManager.GetTrapList();
            foreach (Trap trap in traps)
            {
                if(trap.IsBuilt() == false)
                {
                    continue;
                }
                if (trap.GetLRDamage() == 0)
                {
                    continue;
                }
                trapCount++;
                string trapName = trap.GetTrapName();
                int trapDamage = trap.GetLRDamage();
                int trapMulti = trap.GetMulti();

                if (trapDamage > totalEnemies)
                {
                    trapMulti = totalEnemies;
                }
                terminalOutbreakGame.enemyManager.DealDamage(trapDamage, trapMulti);

                totalTrapDamage += $"{Environment.NewLine}{trapName} deals {trapDamage} damage to {trapMulti} enemies.";
            }
            if (trapCount == 0)
            {
                totalTrapDamage = string.Empty;
            }
            else
            {
                totalTrapDamage += Environment.NewLine;
            }
            return totalTrapDamage;
        }
        public void LRZombiesAdvance()
        {
            int distance = terminalOutbreakGame.enemyManager.GetLongRangeDistance();

            if (distance > 0)
            {
                terminalOutbreakGame.enemyManager.ReduceLongRangeDistance();
            }

        }

        public void VictoryResults(string results)
        {
            Console.Clear();
            Console.WriteLine(Utils.FrameText("Defeated The Horde"));
            Console.WriteLine(results);
            //results += Utils.WrapText();
            Console.WriteLine($"You survived Night {terminalOutbreakGame.baseManager.GetDayNumber()} and defeated the horde! Brilliantly done!{Environment.NewLine}");
            Console.WriteLine("Press ENTER to continue");
            Utils.PressEnter();

            //Reset all variables
            chosenRoundWeapon = string.Empty; // used to see which weapon Player is using for this round
            alliesDamageReadout = string.Empty; // gives a readout on the ally damage
            trapDamageReadout = string.Empty; // gives a readout on the ally damage
            roundNumber = 0;
            totalEnemies = 0;
            playerWeaponDamage = 0;
            playerTargetNumber = 0;
            terminalOutbreakGame.baseManager.ResetBarrierHealth();
            terminalOutbreakGame.baseManager.IncreaseDayNumber();
            terminalOutbreakGame.baseScene.Run();

        }
        public string GetHoardInfo(int zombieCount, int bossCount, int zombiesKilled, int bossesKilled, int distance)
        {
            string display = string.Empty;
            if (zombiesKilled > 1 && bossesKilled > 1) // formats for punctiation depening on enemy numbers
            {
                display += $"{Environment.NewLine}{bossesKilled} Bosses killed and {zombiesKilled} Zombies killed{Environment.NewLine}";
            }
            else if (zombiesKilled > 1 && bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{bossesKilled} Boss killed and {zombiesKilled} Zombies killed{Environment.NewLine}";
            }
            else if (zombiesKilled == 1 && bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{bossesKilled} Boss killed and {zombiesKilled} Zombie killed{Environment.NewLine}";
            }
            else if (zombiesKilled > 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombies killed!{Environment.NewLine}";
            }
            else if (zombiesKilled == 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled} Zombie killed!{Environment.NewLine}";
            }
            else if (bossesKilled > 1)
            {
                display += $"{Environment.NewLine}{zombiesKilled}{bossesKilled} Bosses killed!{Environment.NewLine}";
            }
            else if (bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{bossesKilled} Boss killed!{Environment.NewLine}";
            }

            if (distance > 0 && totalEnemies > 0)
            {
                if (bossCount == 1) // display enemy distance and format according to enemy counts
                {
                    display += $"{Environment.NewLine}{bossCount} Boss and {zombieCount} Zombies are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}"; // if distance = 0, AT THE BARRICADE
                }
                else if (bossCount > 1 && bossCount > bossesKilled)
                {
                    display += $"{Environment.NewLine}{bossCount} Bosses and {zombieCount} Zombies are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}";
                }
                else if (zombieCount > 1)
                {
                    display += $"{Environment.NewLine}{zombieCount} Zombies are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}";
                }
                else
                {
                    display += $"{Environment.NewLine}{zombieCount} Zombie are approaching at {distance}m distance. What weapon would you like to use?{Environment.NewLine}";
                }
            }
            
            return display ;
        }

        
    }
}
