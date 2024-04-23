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
        private bool closeQuartersCombat;

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }


        public void CreateWave(int waveNumber)
        {
            enemies.Clear();
            zombiesKilled = 0;
            bossCount = 0;
            switch (waveNumber)
            {
                case 1:
                    zombieCount = 5;
                    bossCount = 1;                      // TO DO // REset to 0 bosses
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
                    zombieCount = 35;
                    bossCount = 2;
                    break;

                case 11:
                    zombieCount = 40;
                    bossCount = 0;
                    break;

                case 12:
                    zombieCount = 45;
                    bossCount = 0;
                    break;

                case 13:
                    zombieCount = 50;
                    bossCount = 0;
                    break;

                case 14:
                    zombieCount = 55;
                    bossCount = 0;
                    break;

                case 15:
                    zombieCount = 60;
                    bossCount = 3;
                    break;

                case 16:
                    zombieCount = 65;
                    bossCount = 1;
                    break;

                case 17:
                    zombieCount = 70;
                    bossCount = 2;
                    break;

                case 18:
                    zombieCount = 80;
                    bossCount = 3;
                    break;

                case 19:
                    zombieCount = 90;
                    bossCount = 4;
                    break;

                case 20:
                    zombieCount = 100;
                    bossCount = 5;
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
            currentMidRangeDistance = 500;
            closeQuartersCombat = false;
        }
        public int GetZombieCount()
        {
            return zombieCount;
        }

        public int GetBossCount()
        {
            return bossCount;
        }

        public int GetZombiesKilled()
        {
            return zombiesKilled;
        }

        public int GetBossesKilled()
        {
            return bossesKilled;
        }

        public List<Enemy> GetWave()
        {
            return enemies;
        }

        public void DealDamage(int damageDealt, int numberOfTargets) // First to boss, then to others. If have time, extend this to another function so you can choose your target
        {
            bossesKilled = 0;
            zombiesKilled = 0;

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



            //if (bossCount >= numberOfTargets) // if there are more or equal bosses to targets, deal damage to bosses only
            //{
            //    foreach (Enemy enemy in enemies)
            //    {
            //        if (enemy.GetEnemyID() == "boss")
            //        {
            //            enemy.DealDamage(damageDealt);
            //        }
            //        numberOfTargets--;
            //        if (numberOfTargets == 0)
            //        {
            //            break;
            //        }
            //    }
            //}
            //    if (bossCount > 0) // If there are bosses, deal damage to bosses first
            //    {
            //        for (int i = enem)
            //        {
            //            if (enemy.GetEnemyID() == "boss")
            //            {
            //                enemy.DealDamage(damageDealt);
            //            }
            //            if (enemy.GetHealth() <= 0) // if enemy health is zero, remove it from the list
            //            {
            //                bossCount--;
            //                bossesKilled++;
            //                enemies.Remove(enemy);
            //            }
            //            numberOfTargets--;
            //            if (numberOfTargets == 0)
            //            {
            //                break;
            //            }
            //        }
            //        if (numberOfTargets > 0) // if there are more targets than there are bosses, deal damage to bosses first, then remaining zombies.
            //        {
            //            foreach (Enemy enemy in enemies)
            //            {
            //                if (enemy.GetEnemyID() == "zombie")
            //                {
            //                    enemy.DealDamage(damageDealt);
            //                }
            //                if (enemy.GetHealth() <= 0) // if enemy health is zero, remove it from the list
            //                {
            //                    zombieCount--;
            //                    zombiesKilled++;
            //                    enemies.Remove(enemy);
            //                }
            //                numberOfTargets--;
            //                if (numberOfTargets == 0)
            //                {
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //    else // when there are no bosses
            //    {
            //        foreach (Enemy enemy in enemies)
            //        {
            //            enemy.DealDamage(damageDealt);
            //            if (enemy.GetHealth() <= 0)
            //            {
            //                zombieCount--;
            //                zombiesKilled++;
            //                enemies.Remove(enemy);
            //            }
            //            numberOfTargets--;
            //            if (numberOfTargets == 0)
            //            {
            //                break;
            //            }
            //        }   
            //    }           
            //
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

        //    public int GetDistance(string currentRange)
        //    {
        //        int distance = 0;
        //        foreach(Enemy enemy in enemies)
        //        {
        //            switch (currentRange) 
        //            {
        //                case "LongRange":
        //                    distance = enemy.GetLongRangeDistance();
        //                    break;
        //                case "MidRange":
        //                    distance = enemy.GetLongRangeDistance();
        //                        break;
        //            }
        //            break;
        //        }
        //        return distance;
        //    }

        //    public bool IsInCQCombat()
        //    {
        //        bool cQ = false;
        //        foreach (Enemy enemy in enemies)
        //        {
        //            cQ = enemy.GetCloseQuarters();
        //            break;
        //        }
        //        return cQ;
        //    }
        //}


        public void ReduceLongRangeDistance()
        {
            currentLongRangeDistance -= 100;
        }

        public int GetLongRangeDistance()
        {
            return currentLongRangeDistance;
        }
        public void ReduceMidRangeDistance()
        {
            currentMidRangeDistance -= 1;
        }

        public int GetMidRangeDistance()
        {
            return currentMidRangeDistance;
        }
        public void SetCloseQuarters(bool inCQ)
        {
            closeQuartersCombat = inCQ;
        }

        public bool GetCloseQuarters()
        {
            return closeQuartersCombat;
        }



    }
}
