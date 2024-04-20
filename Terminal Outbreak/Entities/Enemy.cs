using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Outbreak.Entities
{
    internal class Enemy(string enemyType)
    {
        private string enemyType = enemyType;
        private int maxHealth;
        private int enemyDamage;
        private int barrierDamage;
        private int currentLongRangeDistance;
        private int currentMidRangeDistance;
        private bool closeQuartersCombat;

        private int currentHealth;



        public void createEnemy()
        {
            if (enemyType == "zombie")
            {
                maxHealth = 5;
                enemyDamage = 5;
                barrierDamage = 1;
                currentLongRangeDistance = 5;
            }
            else if (enemyType == "boss")
            {
                maxHealth = 30;
                enemyDamage = 20;
                barrierDamage = 10;
                currentLongRangeDistance = 5;
            }
        }

        public void setHealth(int damage)
        {
            currentHealth -= damage;
        }



        public int getHealth() { return currentHealth; }













    }
}
