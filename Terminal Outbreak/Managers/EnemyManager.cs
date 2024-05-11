using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Outbreak.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Terminal_Outbreak.Managers
{
    internal class EnemyManager
    {
        private List<Enemy> enemies;
        private int zombieCount;
        private int bossCount;
        private int zombiesKilled;
        private int bossesKilled;

        private int currentLongRangeDistance; // Max of 500m from the barrier, min of 0m from the barrier
        private int currentMidRangeDistance; // Max of 5m from the player, min of 0m = enter close combat

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public void CreateWave(int waveNumber)
        {
            enemies.Clear();
            zombieCount = 0;
            bossCount = 0;
            zombiesKilled = 0;
            bossesKilled = 0;
            
            switch (waveNumber)
            {
                case 1:
                    zombieCount = 5;
                    bossCount = 0;                      
                    break;

                case 2:
                    zombieCount = 7;
                    bossCount = 0;
                    break;

                case 3:
                    zombieCount = 10;
                    bossCount = 0;
                    break;

                case 4:
                    zombieCount = 15;
                    bossCount = 0;
                    break;

                case 5:
                    zombieCount = 15;
                    bossCount = 1;
                    break;

                case 6:
                    zombieCount = 20;
                    bossCount = 0;
                    break;

                case 7:
                    zombieCount = 25;
                    bossCount = 0;
                    break;

                case 8:
                    zombieCount = 30;
                    bossCount = 0;
                    break;

                case 9:
                    zombieCount = 35;
                    bossCount = 0;
                    break;

                case 10:
                    zombieCount = 50;
                    bossCount = 2;
                    break;

                case 11:
                    zombieCount = 60;
                    bossCount = 0;
                    break;

                case 12:
                    zombieCount = 70;
                    bossCount = 0;
                    break;

                case 13:
                    zombieCount = 80;
                    bossCount = 0;
                    break;

                case 14:
                    zombieCount = 90;
                    bossCount = 0;
                    break;

                case 15:
                    zombieCount = 80;
                    bossCount = 3;
                    break;

                case 16:
                    zombieCount = 100;
                    bossCount = 1;
                    break;

                case 17:
                    zombieCount = 110;
                    bossCount = 2;
                    break;

                case 18:
                    zombieCount = 120;
                    bossCount = 3;
                    break;

                case 19:
                    zombieCount = 130;
                    bossCount = 4;
                    break;

                case 20:
                    zombieCount = 140;
                    bossCount = 5;
                    break;
                case 21:
                    zombieCount = 150;
                    bossCount = 5;
                    break;
                case 22:
                    zombieCount = 160;
                    bossCount = 6;
                    break;
                case 23:
                    zombieCount = 180;
                    bossCount = 6;
                    break;
                case 24:
                    zombieCount = 200;
                    bossCount = 5;
                    break;
                case 25:
                    zombieCount = 250;
                    bossCount = 10;
                    break;
                case 26: // in case of overflow, although currently no discovered issues
                    zombieCount = 1; 
                    bossCount = 1;
                    break;
            }

            for (int i = 0; i < zombieCount; i++)
            {
                enemies.Add(new Enemy("zombie"));
            }
            for (int i = 0; i < bossCount; i++)
            {
                enemies.Add(new Enemy("boss"));
            }
            currentLongRangeDistance = 500;
            currentMidRangeDistance = 5;
        }
        public int GetZombieCount()
        {
            return zombieCount;
        }

        public int GetBossCount()
        {
            return bossCount;
        }

        public int GetAndResetZombiesKilled()
        {
            int roundKills = zombiesKilled;
            zombiesKilled = 0;
            return roundKills;
        }

        public int GetAndResetBossesKilled()
        {
            int roundKills = bossesKilled;
            bossesKilled = 0;
            return roundKills;
        }

        public List<Enemy> GetWave()
        {
            return enemies;
        }

        public void DealDamage(int damageDealt, int numberOfTargets) // Deal damage function used during combat.
        {
            if (bossCount > 0) // If there are bosses, deal damage to bosses first
            {
                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    if (enemies[i].GetEnemyID() == "boss")
                    {
                        enemies[i].DealDamage(damageDealt);
                        if (enemies[i].GetHealth() <= 0)
                        {
                            bossCount--;
                            bossesKilled++;
                            enemies.RemoveAt(i);
                        }
                        numberOfTargets--;
                        if (numberOfTargets == 0)
                        {
                            break;
                        }
                    }
                }

                if (numberOfTargets > 0) // remaing damage then dealt to normal zombies.
                {
                    for (int i = enemies.Count - 1; i >= 0; i--)
                    {
                        if (enemies[i].GetEnemyID() == "zombie")
                        {
                            enemies[i].DealDamage(damageDealt);
                            if (enemies[i].GetHealth() <= 0)
                            {
                                zombieCount--;
                                zombiesKilled++;
                                enemies.RemoveAt(i);
                            }
                            numberOfTargets--;
                            if (numberOfTargets == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else // when there are no bosses
            {
                for (int i = enemies.Count - 1; i >= 0; i--)
                {
                    enemies[i].DealDamage(damageDealt);
                    if (enemies[i].GetHealth() <= 0)
                    {
                        zombieCount--;
                        zombiesKilled++;
                        enemies.RemoveAt(i);
                    }
                    numberOfTargets--;
                    if (numberOfTargets == 0)
                    {
                        break;
                    }
                }
            }

        }

        public int RecieveDamage() // To be called each round of a "Close Quarters" encounter 
        {
            int damage = 0; // Calculate damage dealt to player
            foreach (Enemy enemy in enemies)
            {
                damage += enemy.GetDamage();
            }
            return damage;
        }

        public void ReduceLongRangeDistance()
        {
            currentLongRangeDistance -= 100;
        }

        public int GetLongRangeDistance()
        {
            return currentLongRangeDistance;
        }

        public void ReduceMediumRangeDistance()
        {
            currentMidRangeDistance -= 1;
        }

        public int GetMediumRangeDistance()
        {
            return currentMidRangeDistance;
        }
    }
}
