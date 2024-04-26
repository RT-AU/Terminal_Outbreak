using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Defences;
using Terminal_Outbreak.Entities;
using Terminal_Outbreak.Mainframe;

namespace Terminal_Outbreak.Scenes.CombatScenes
{
    internal class CloseQuartersCombatScene : Scene
    {
        int roundNumber;
        int totalEnemies;
        int playerWeaponDamage;
        int playerTargetNumber;
        string chosenRoundWeapon;
        string alliesDamageReadout;
        string zombiesDamageReadout;
        public CloseQuartersCombatScene(TerminalOutbreakGame game) : base(game)
        {
            chosenRoundWeapon = string.Empty; // used to see which weapon Player is using for this round
            alliesDamageReadout = string.Empty; // gives a readout on the ally damage
            zombiesDamageReadout = string.Empty;
            roundNumber = 0;
            totalEnemies = 0;
            playerWeaponDamage = 0;
            playerTargetNumber = 0;
        }

        public override void Run()
        {
            roundNumber++;

            int playerEquippedPrimaryWeapon = terminalOutbreakGame.player.GetEquippedPrimaryWeaponID();
            int playerEquippedSecondaryWeapon = terminalOutbreakGame.player.GetEquippedSecondaryWeaponID();
            int playerEquippedMeleeWeapon = terminalOutbreakGame.player.GetEquippedMeleeWeaponID();


            string header = Utils.FrameText($"Nightfall - Close Quarters: ROUND {roundNumber}");
            string display = "";
            int zombieCount = terminalOutbreakGame.enemyManager.GetZombieCount();
            int bossCount = terminalOutbreakGame.enemyManager.GetBossCount();
            totalEnemies = zombieCount + bossCount;

            int zombiesKilled = terminalOutbreakGame.enemyManager.GetAndResetZombiesKilled();
            int bossesKilled = terminalOutbreakGame.enemyManager.GetAndResetBossesKilled();

            int distance = terminalOutbreakGame.enemyManager.GetMediumRangeDistance();


            

            if (roundNumber > 1)
            {
                switch (chosenRoundWeapon)
                {
                    case "primary":
                        if (playerEquippedPrimaryWeapon == -1)
                        {
                            display += $"{Environment.NewLine}You have no primary weapon equipped! Your unarmed attacks seem to do nothing at all.";
                        }
                        else
                        {
                            if (playerTargetNumber == 1)
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemy for {playerWeaponDamage} damage!";
                            }
                            else
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemies for {playerWeaponDamage} damage each!";
                            }
                        }
                        break;
                    case "secondary":
                        if (playerEquippedSecondaryWeapon == -1)
                        {
                            display += $"{Environment.NewLine}You have no secondary weapon equipped! Your unarmed attacks seem to do nothing at all.";
                        }
                        else
                        {
                            if (playerTargetNumber == 1)
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemy for {playerWeaponDamage} damage!";
                            }
                            else
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemies for {playerWeaponDamage} damage each!";
                            }
                        }
                        break;
                    case "melee":
                        if (playerEquippedMeleeWeapon == -1)
                        {
                            display += $"{Environment.NewLine}You have no melee weapon equipped! Your unarmed attacks seem to do nothing at all.";
                        }
                        else
                        {
                            if (playerTargetNumber == 1)
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemy for {playerWeaponDamage} damage!";
                            }
                            else
                            {
                                display += $"{Environment.NewLine}You hit {playerTargetNumber} enemies for {playerWeaponDamage} damage each!";
                            }
                        }
                        break;
                }


            }

            if (roundNumber > 1)
            {
                display += GetHoardInfo(zombieCount, bossCount, zombiesKilled, bossesKilled, distance); // call info on position and number of the hoard for display
                display += $"{Environment.NewLine}{zombiesDamageReadout}";
            }
            else
            {
                display += GetHoardInfo(zombieCount, bossCount, 0, 0, distance); // call info on position and number of the hoard for display
            }
            if (totalEnemies == 0)
            {
                VictoryResults(display);
            }
            if (terminalOutbreakGame.player.getHealth() <= 0)
            {
                terminalOutbreakGame.warningScene.GameOverKilled();
            }
            

            List<string> options = new List<string>();
            options.Add("Primary Weapon");
            options.Add("Secondary Weapon");
            options.Add("Melee Weapon");

            Menu mediumRangeMenu = new Menu(display, options, header);
            int selectedIndex = mediumRangeMenu.RunHeaderVersion();

            switch (selectedIndex)
            {
                case 0:
                    chosenRoundWeapon = "primary";
                    playerWeaponDamage = terminalOutbreakGame.equipmentManager.GetWeaponCQDamage(playerEquippedPrimaryWeapon);
                    playerTargetNumber = terminalOutbreakGame.equipmentManager.GetWeaponCQMulti(playerEquippedPrimaryWeapon);

                    if (playerTargetNumber > totalEnemies) // limits the number of hits to the actual number of zombies
                    {
                        playerTargetNumber = totalEnemies;
                    }
                    terminalOutbreakGame.enemyManager.DealDamage(playerWeaponDamage, playerTargetNumber);

                    zombiesDamageReadout = ZombiesAttack(); // calculates zombie damage
                    this.Run();
                    break;

                case 1:
                    chosenRoundWeapon = "secondary";
                    playerWeaponDamage = terminalOutbreakGame.equipmentManager.GetWeaponCQDamage(playerEquippedSecondaryWeapon);
                    playerTargetNumber = terminalOutbreakGame.equipmentManager.GetWeaponCQMulti(playerEquippedSecondaryWeapon);

                    if (playerTargetNumber > totalEnemies) // limits the number of hits to the actual number of zombies
                    {
                        playerTargetNumber = totalEnemies;
                    }

                    terminalOutbreakGame.enemyManager.DealDamage(playerWeaponDamage, playerTargetNumber);

                    zombiesDamageReadout = ZombiesAttack();
                    this.Run();
                    break;
                case 2:
                    chosenRoundWeapon = "melee";
                    playerWeaponDamage = terminalOutbreakGame.equipmentManager.GetWeaponCQDamage(playerEquippedMeleeWeapon);
                    playerTargetNumber = terminalOutbreakGame.equipmentManager.GetWeaponCQMulti(playerEquippedMeleeWeapon);

                    if (playerTargetNumber > totalEnemies) // limits the number of hits to the actual number of zombies
                    {
                        playerTargetNumber = totalEnemies;
                    }

                    terminalOutbreakGame.enemyManager.DealDamage(playerWeaponDamage, playerTargetNumber);

                    zombiesDamageReadout = ZombiesAttack();
                    this.Run();
                    break;

            }
        }

        public string ZombiesAttack()
        {
            int remainingZombies = terminalOutbreakGame.enemyManager.GetZombieCount();
            int remainingBosses = terminalOutbreakGame.enemyManager.GetBossCount();
            int damageRecieved = terminalOutbreakGame.enemyManager.RecieveDamage();
            string damageString = string.Empty;

            int remainingEnemies = remainingBosses + remainingZombies;

            terminalOutbreakGame.player.Damage(damageRecieved);

            if (remainingEnemies > 1)
            {
                damageString = $"You recieve {damageRecieved} damage from {remainingEnemies} enemies.";
            }
            else
            {
                damageString = $"You recieve {damageRecieved} damage from {remainingEnemies} enemy.";
            }
            if (damageString == $"You recieve {0} damage from {0} enemy.")
            {
                damageString = string.Empty;
            }
            return damageString;
        }

        public void VictoryResults(string results)
        {
            Console.Clear();
            Console.WriteLine(Utils.FrameText("Defeated The Horde"));
            results += Utils.WrapText($"{Environment.NewLine}You survived Night {terminalOutbreakGame.baseManager.GetDayNumber()} and defeated the horde! Brilliantly done!{Environment.NewLine}");
            Console.WriteLine(results);
            Console.WriteLine("Press ENTER to continue");
            Utils.PressEnter();

            //Reset all variables
            chosenRoundWeapon = string.Empty; // used to see which weapon Player is using for this round
            alliesDamageReadout = string.Empty; // gives a readout on the ally damage
            roundNumber = 0;
            totalEnemies = 0;
            playerWeaponDamage = 0;
            playerTargetNumber = 0;

            terminalOutbreakGame.baseManager.IncreaseDayNumber();
            terminalOutbreakGame.baseScene.Run();

        }
        public string GetHoardInfo(int zombieCount, int bossCount, int zombiesKilled, int bossesKilled, int distance)
        {
            string display = string.Empty;
            if (zombiesKilled > 1 && bossesKilled > 1) // formats for punctiation depening on enemy numbers
            {
                display += $"{Environment.NewLine}{bossesKilled} Bosses killed and {zombiesKilled} Zombies killed";
            }
            else if (zombiesKilled > 1 && bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{bossesKilled} Boss killed and {zombiesKilled} Zombies killed";
            }
            else if (zombiesKilled == 1 && bossesKilled == 1)
            {
                display += $"{Environment.NewLine}{bossesKilled} Boss killed and {zombiesKilled} Zombie killed ";
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

            if (totalEnemies > 0)
            {
                if (bossCount == 1) // display enemy distance and format according to enemy counts
                {
                    display += $"{Environment.NewLine}{bossCount} Boss and {zombieCount} Zombies are within Close Quarters. What weapon would you like to use?{Environment.NewLine}"; // if distance = 0, AT THE BARRICADE
                }
                else if (bossCount > 1 && bossCount > bossesKilled)
                {
                    display += $"{Environment.NewLine}{bossCount} Bosses and {zombieCount} Zombies are within Close Quarters. What weapon would you like to use?{Environment.NewLine}";
                }
                else if (zombieCount > 1)
                {
                    display += $"{Environment.NewLine}{zombieCount} Zombies are within Close Quarters. What weapon would you like to use?{Environment.NewLine}";
                }
                else
                {
                    display += $"{Environment.NewLine}{zombieCount} Zombie is within Close Quarters. What weapon would you like to use?{Environment.NewLine}";
                }
            }
            return display;
        }
    }
}
